function kameradan_sudokuyu_al()
blksize = 92;  
tracking = 1; %izleme durumu i�in tutulan degisken
imaqreset 
%%winvideo kamera paketi 
obj = videoinput('winvideo',1,'YUY2_640x480');
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
try
    %kameradan alinacak kare sayisi belirtilir
    set(obj,'framesperTrigger',10,'TriggerRepeat',Inf);
    start(obj);
    
    A_tmin = 30; % rakam piksel alani i�in isnirlar 
    A_tmax = 1000;
    digitbox_minarea = 20; % kutu alani i�in sinirlar
    digitbox_maxarea = 25^2;
    
    found = 0; % izlemeye baslayin
    h = imshow(zeros(480,640));%ekran boyutu ayarlanir ve piksel degerleri 0'lan?r
    hold on;
    h_g = plot(90+[0 460 460 0 0],10+[0 0 460 460 0],'g');
    h_pts  = [];
    % konumlari ve degerleri kontrol etmek i�in degisken olusturulur
    Plocal_old = []; 
    %algoritmayi bir ka� kez �ali?tirmak i�in durum �zerinde de?i?iklik
    %yapilabilir
    durum = 0;
    durummax = 1;
    %g�r�nt�y� kaydirma
    hslider = uicontrol('style','slider','units','n','pos',[0 0 1 0.05],'min',1.1,'max',1.4,'val',1.3);
    while islogging(obj);
        bwthresh = get(hslider,'value'); %e?ik degeri alinir
        Icam = getdata(obj,1);    
        % yesil kare olu?turma
        I0 = Icam(10+(1:460),90+(1:460));
        flushdata(obj); %anlik g�r�nt�y� alma
        
        %resmi 0 ve 1'liyor.
        makebw2 = @(I) im2bw(I.data,median(double(I.data(:)))/bwthresh/255);
        IBW = ~blockproc(I0,[blksize blksize],makebw2);
        %g�r�lt� giderme i?lemi yapiliyor
        IBW = imclose(IBW,[1 1; 1 1]);%yapisal eleman yardimiyla kapama i?lemi yapiyor
        I = IBW;
        I = bwareaopen(I,A_tmin); %30 piksel k���k nesneleri kaldirir
        I = imclearborder(I); %4'l� kom?ularina bakilir
        
        % I resmini �iki? i�in 640x480 boyutuna getiriyor
        Iout = zeros(480,640);
        Iout(10+(1:460),90+(1:460)) = I;
        
        % �iki? g�sterilir
        if ~tracking || ~found
            set(h,'Cdata',Iout);
        end
        
        R = regionprops(I,'Area','BoundingBox','PixelList');
        NR = numel(R);
        
        % en b�y�k nesneyi bulma yani sudokunu en b�y�k karesi bulunur
        maxArea = 0;
        for k = 1:NR
            A(k) = prod(R(k).BoundingBox(3:4));
            if R(k).Area > maxArea
                maxArea = R(k).Area;
                kmax = k;
            end
        end
        itsok = 0;
        % bulunan karenin k�?eleri bulunur ve b�y�k kare mavi renge boyanir
        if maxArea > 1000 && A(kmax) > 150^2 
            itsok = 1;
            set(h_g,'color','g');
            BBmax = R(kmax).BoundingBox;
            DIAG1 = sum(R(kmax).PixelList,2);
            DIAG2 = diff(R(kmax).PixelList,[],2);
            
            [m,dUL] = min(DIAG1);
            [m,dDR] = max(DIAG1);
            [m,dDL] = min(DIAG2);
            [m,dUR] = max(DIAG2);
            pts = R(kmax).PixelList([dUL dDL dDR dUR dUL],:);
            h_pts = plot(90+pts(:,1),10+pts(:,2),'b');
            
            XYLIMS = [BBmax(1) + [0 BBmax(3)] BBmax(2) + [0 BBmax(4)]];
        end
        set(h,'Cdata',Iout);
        drawnow;
        % ��z�lecek bulmaca bulunamadiginda ye?il kareyi kirmiziya
        % d�n�st�r�r
        if ~itsok
            set(h_g,'color','r');
            continue
        end
        %ekrandaki kareleri sifirlama
        try, delete(h_y); end; h_y = [];
        try, delete(h_pts); end; h_pts = [];
        if found, continue; end
        
        h_digitcircles = [];
        kgood = zeros(1,NR);
        Pnew = zeros(NR,2);
        % bulmacanin i�indeki kareleri olu?turma
        for k = 1:NR
            if R(k).Area < A_tmax && A(k) > digitbox_minarea && A(k) < digitbox_maxarea ...
                    && R(k).BoundingBox(3) < 40 && R(k).BoundingBox(4) < 40 ...
                    && R(k).BoundingBox(3) > 2 && R(k).BoundingBox(4) > 2
                
                Pnew(k,:) = [R(k).BoundingBox(1)+R(k).BoundingBox(3)/2 R(k).BoundingBox(2)+R(k).BoundingBox(4)/2];
      
                if inpolygon(Pnew(k,1),Pnew(k,2),pts(:,1),pts(:,2))
                    h_digitcircles(k) = plot(90+Pnew(k,1),10+Pnew(k,2),'ro','markersize',24);%kutular?n i�i doluysa say?lar? yuvarlak i�ine al?r
                    kgood(k) = 1;
                end
            end
        end
        [kgoodvals,kgoodlocs] = find(kgood);
        Pnew = Pnew(kgoodlocs,:);
        load syilarin_degerleri % sayilari temsil eden matris degi?keni y�kleniyor
        %bulmacanin i�indeki sayilari tanimlama ve matrise d�kme 
        [Plocal,del] = sayilari_bulma(pts,Pnew,NT,IBW);
      
       % rakamlari �er�eveliyen kirmizi yuvarlak �emberi silme islemi
        try
            delete(h_digitcircles(kgoodlocs(del)));
            h_digitcircles(kgoodlocs(del)) = 0;
        catch
            keyboard
        end
        drawnow; 
        try, delete(nonzeros(h_digitcircles)); end;
        
        
        % bulunan sayilar matise ve txt uzantili dosyaya yazilir
        if isequal(Plocal_old, Plocal) && ~isempty(Plocal)
            durum = durum;
            if durum == durummax-1
                title([num2str(durum+1) ' / ' num2str(durummax)],'FontSize',12);
                M = zeros(9);
                M2 = zeros(9);
                for k = 1:size(Plocal,1)
                    M(Plocal(k,2),Plocal(k,1)) = Plocal(k,3);
                    M2(Plocal(k,1),Plocal(k,2)) = Plocal(k,3);
                end
                disp(M);
                deger=zeros(1,9);
                hata=0;
                %satirlar kontrol ediliyor
                for i=1:9
                    deger=zeros(1,9);
                    for j=1:9
                    if M(i,j)~=0
                    deger(M(i,j))=deger(M(i,j))+1;    
                    end    
                    end 
                    if max(deger)>1
                    hata=1;
                    break
                    end    
                end
                %sutunlar kontrol ediliyor
                if hata==0
                for i=1:9
                    deger=zeros(1,9);
                    for j=1:9
                    if M(j,i)~=0
                    deger(M(j,i))=deger(M(j,i))+1;    
                    end    
                    end 
                    if max(deger)>1
                    hata=1;
                    break
                    end    
                end 
                end
                %3x3'l�k matrisler kontrol ediliyor
                if hata==0
                for k=0:2
                for l=0:2
                    deger=zeros(1,9);
                for i=1:3
                    for j=1:3
                    if M(l*3+i,k*3+j)~=0
                    deger(M(l*3+i,k*3+j))=deger(M(l*3+i,k*3+j))+1;    
                    end    
                    end 
                    
                end 
                if max(deger)>1
                    hata=1;
                    break
                    end    
                end
                if max(deger)>1
                    hata=1;
                    break
                    end    
                end
                end
                %sudoku hatal? ise if'e girer
                if hata==1
                message = sprintf('SUDOKUNUZ HATALI LUTFEN FARKLI BIR SUDOKU DENEYINIZ');
                uiwait(msgbox(message));
                else
                komhedos=fopen('sudoku.txt','w');
                fprintf(komhedos,'%d %d %d %d %d %d %d %d %d \n',M2); 
                fclose(komhedos);
                message = sprintf('SUDOKU BASARILI BIR SEKILDE KAYDEDILDI');
                uiwait(msgbox(message));
                
                end
                if ~hata
                if ~isempty(M_sol)
                    if ~tracking, return; end
                    found = 1;
                         
                else
                    durum = 0;
                end
                end
            end
        else
            durum = 0;
        end
        title([num2str(durum+1) ' / ' num2str(durummax)],'FontSize',12);
        Plocal_old = Plocal;   
    end
catch
    stop(obj);
end
