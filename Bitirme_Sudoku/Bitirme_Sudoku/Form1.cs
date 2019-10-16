using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Bitirme_Sudoku
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        TextBox[,] cell = new TextBox[9, 9];
        TextBox[,] cell2 = new TextBox[9, 9];

        Genome gen = new Genome();

        private void Form1_Load(object sender, EventArgs e)
        {
            
           
            int en = 35;
            int boy = 35;
            int yukseklik = 20;
            this.Text = "Sudoku Bitirme Projesi - Muhammed Zeki Beyazpolat";
            //giriş alanı
            for (int satir = 0; satir < 9; satir++)
            {
                int sol = 20;
                for (int sutun = 0; sutun < 9; sutun++)
                {
                    
                    cell[satir, sutun] = new TextBox();
                    cell[satir, sutun].Size = new Size(en, boy);
                    cell[satir, sutun].Left = sol;
                    cell[satir, sutun].Top = yukseklik;
                    cell[satir, sutun].BorderStyle = BorderStyle.FixedSingle;
                    cell[satir, sutun].AutoSize = false;
                    cell[satir, sutun].TextAlign = HorizontalAlignment.Center;
                    cell[satir, sutun].Font = new Font(Font.FontFamily, 18);
                    cell[satir, sutun].ForeColor = Color.Blue;
                    cell[satir, sutun].Tag = satir + ";" + sutun;
                    cell[satir, sutun].MaxLength = 1;
                    this.Controls.Add(cell[satir, sutun]);
                    sol += en;

                    int a = satir / 3 + sutun / 3;
                    if (a % 2 == 1)
                    {
                        cell[satir, sutun].BackColor = Color.Ivory;
                    }
                    else
                    {
                        cell[satir, sutun].BackColor = Color.Honeydew;
                    }
                    //arayüze sabit değerler yazılıyor
                    if (gen.staticValues2[satir, sutun] != 0)
                    {
                        cell[satir, sutun].Text = Convert.ToString(gen.staticValues2[satir, sutun]);
                    }
                    
                }
                     
                yukseklik += boy;
            }

            yukseklik = 20;
            for (int satir = 0; satir < 9; satir++)
            {
                int sol = 350;
                for (int sutun = 0; sutun < 9; sutun++)
                {
                    cell2[satir, sutun] = new TextBox();
                    cell2[satir, sutun].Size = new Size(en, boy);
                    cell2[satir, sutun].Left = sol;
                    cell2[satir, sutun].Top = yukseklik;
                    cell2[satir, sutun].BorderStyle = BorderStyle.FixedSingle;
                    cell2[satir, sutun].AutoSize = false;
                    cell2[satir, sutun].TextAlign = HorizontalAlignment.Center;
                    cell2[satir, sutun].Font = new Font(Font.FontFamily, 18);
                    cell2[satir, sutun].Tag = satir + ";" + sutun;

                    this.Controls.Add(cell2[satir, sutun]);
                    sol += en;

                    int a = satir / 3 + sutun / 3;
                    if (a % 2 == 1)
                    {
                        cell2[satir, sutun].BackColor = Color.Ivory;
                    }
                    else
                    {
                        cell2[satir, sutun].BackColor = Color.Honeydew;
                    }
                }
                yukseklik += boy;

            }
        }
        private void Onayla_Click(object sender, EventArgs e)
        {
                genetikAlgoritma(Convert.ToInt32(jenerasyon.Text));
        }
        Genome g = null;
        int a = 0;
        public void genetikAlgoritma(int GenerationSayisi)
        {
            Population TestPopulation = new Population();
            TestPopulation.set_baslangicPopulasyonu(Convert.ToInt32(textbox_population.Text));
            TestPopulation.set_mutasyonOranı((float.Parse(mutate.Text) / 100));


            for (int i = 0; i < GenerationSayisi + 1; i++)
            {
                TestPopulation.yeniJenerasyon();
                g = TestPopulation.getEnYuksekFitness_genomes();

                if (i % 5 == 0)
                {
                    if (g.fitness > 0.9999)
                    {
                        break;
                    }
                    this.Text = "Sudoku Bitirme Projesi - Muhammed Zeki Beyazpolat|||Durum:Çalışıyor";
                    a = i;
                }
            }
            // ekrana (cell2) yazdıran kısım
            for (int satir = 0; satir < 9; satir++)
            {
                for (int sutun = 0; sutun < 9; sutun++)
                {
                    if(gen.staticValues2[satir,sutun]!=0)
                    cell2[satir, sutun].ForeColor = Color.Blue;
                    else
                    cell2[satir, sutun].ForeColor = Color.Black;
                    cell2[satir, sutun].Text = Convert.ToString(g.getIntArray(satir, sutun));
                }
            }
            fitness.Text = "Fitness: " + g.fitness;
            generation.Text = "Generation: " + a;
            durum2.Text = "Durum: Bitti.";
            this.Text = "Sudoku Bitirme Projesi - Muhammed Zeki Beyazpolat|||Durum:Bitti";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Close();
            Form2 frm2 = new Form2();
            frm2.Show();
            this.Hide();
        }
    }
}
