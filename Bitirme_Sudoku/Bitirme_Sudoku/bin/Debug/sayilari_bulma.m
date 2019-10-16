function [Plocal,del] = sayilari_bulma(pts,Pnew,NT,IBW)

% bulmacanin karelerini kullanarak rakamlarin konumlari bulunup
% karsilastirma yapilir
if isempty(Pnew)
    Plocal = nan;
    del = [];
    return
end
try
    T = cp2tform(pts(1:4,:),[0.5 0.5; 9.5 0.5; 9.5 9.5; 0.5 9.5],'projective');
catch
    Plocal = nan;
    del = [];
    return
end
Plocal = (tformfwd(T,Pnew));
Plocal = round(2*Plocal)/2;

% rakam olmayan kutular kontrol edilip 0'lanir
del = find(sum(Plocal - floor(Plocal) > 0 |  Plocal < 1 | Plocal > 9,2)) ;
Plocal(del,:) = [];
Pnew(del,:) = [];

if any(isnan(Plocal(:))) || isempty(Plocal)
    Plocal = nan;
    del = [];
    return
end


% içi dolu kutularin sayilari tanimlanir
try
    Plocal(end,3) = 0;
    
    for k = 1:size(Pnew,1)
        for s = [0 -1 1 -2 2 -3 3 -4 4 -5 5]
            N = bwselect(IBW,Pnew(k,1) + s ,Pnew(k,2));

            if any(N(:))
                break
            end
        end
        if s == 5
            Plocal = nan;
            return
        end
        [i,j] = find(N);
        N = N(min(i):max(i),min(j):max(j));
        N0 = N;
        
        % 20x20 olarak yeniden boyutlandirilir
        N = imresize(N,[20 20]);
        
        %rakamlara yakinlik dereceleri hesaplanir
        for v = 1:9
            S(v) = sum(sum(N.*NT{v}));
        end
        
        Plocal(k,3) = find(S == max(S),1);
        
        if (Plocal(k,3) == 5 || Plocal(k,3) == 6) && abs(S(5) - S(6)) < 0.1
            E = regionprops(N,'EulerNumber');
            if ~E(1).EulerNumber
                Plocal(k,3) = 6;
            end
        end
        
    end
catch
end
Plocal = sortrows(Plocal);
