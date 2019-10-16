using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bitirme_Sudoku
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        TextBox[,] cell = new TextBox[9, 9];
        TextBox[,] cell2 = new TextBox[9, 9];
        String sudoku_ekle = "";
        SudokuCozum cozum = new SudokuCozum();
        int rnd2 = 0;
        int durum = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            int en = 35;
            int boy = 35;
            int yukseklik = 20;

            //  this.Text = "Sudoku Bitirme Projesi - Muhammed Zeki Beyazpolat";
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
                    if (cozum.sudoku[satir, sutun] != 0)
                    {
                        cell[satir, sutun].Text = Convert.ToString(cozum.sudoku[satir, sutun]);
                    }

                }

                yukseklik += boy;
            }
        }



       

        private void Onayla_Click(object sender, EventArgs e)
        {
                int en = 35;
                int boy = 35;
                int yukseklik = 20;
                cozum.bulmacaCoz(0, 0);
                for (int satir = 0; satir < 9; satir++)
                {
                    int sol = 450;
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
                        cell2[satir, sutun].ForeColor = Color.Blue;
                        cell2[satir, sutun].MaxLength = 1;
                        if (cozum.sudoku2[satir, sutun] == 0)
                        {
                            cell2[satir, sutun].ForeColor = Color.Black;
                        }
                        cell2[satir, sutun].Tag = satir + ";" + sutun;

                        this.Controls.Add(cell2[satir, sutun]);
                        sol += en;

                        int a = satir / 3 + sutun / 3;
                        if (a % 2 == 1)
                        {
                            cell2[satir, sutun].BackColor = Color.Brown;
                        }
                        else
                        {
                            cell2[satir, sutun].BackColor = Color.Honeydew;
                        }
                        //arayüze cözümlü değerler yazılıyor
                        if (cozum.sudoku[satir, sutun] != 0)
                        {
                            cell2[satir, sutun].Text = Convert.ToString(cozum.sudoku[satir, sutun]);
                        }
                    }
                    yukseklik += boy;
                }
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

