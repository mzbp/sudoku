using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;

namespace Bitirme_Sudoku
{
    class SudokuCozum
    {
        public int[,] sudoku2 = new int[9, 9] ;
        public int[,] sudoku = new int[9, 9];
        int a = 0;  
        public SudokuCozum()
        {
            string file = "sudoku.txt";
            StreamReader sr = new StreamReader(file);
            string otherLines = sr.ReadToEnd();
            string[] degerler = otherLines.Split(' ');
            sr.Close();

            for (int i=0; i<9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    sudoku[i, j] = Convert.ToInt32(degerler[a]);
                    sudoku2[i, j] = Convert.ToInt32(degerler[a]);
                    a++;
                }
            }
        }
        int ayniSutun(int x, int y, int rakam)
        {
            
            for (int i = 0; i < 9; i++)
            {
                if (sudoku[x, i] == rakam)
                {
                    return 1;
                }
            }
            return 0;
        }
        int ayniSatir(int x, int y, int rakam)
        {
            for (int i = 0; i < 9; i++)
            {
                if (sudoku[i, y] == rakam)
                {
                    return 1;
                }
            }
            return 0;
        }
        int ayniKare(int x, int y, int rakam)
        {
            if (x < 3)
                x = 0;
            else if (x < 6)
                x = 3;
            else
                x = 6;

            if (y < 3)
                y = 0;
            else if (y < 6)
                y = 3;
            else
                y = 6;

            for (int i = x; i < x + 3; i++)
            {
                for (int j = y; j < y + 3; j++)
                {
                    if (sudoku[i, j] == rakam)
                    {
                        return 1;
                    }
                }
            }
            return 0;
        }
        public int bulmacaCoz(int x, int y)
        {
            int rakam = 1;
            int tx = 0;
            int ty = 0;

            if (sudoku[x, y] != 0)
            {
                if (x == 8 && y == 8)
                {
                    return 1;
                }
                if (x < 8)
                {
                    x++;
                }
                else
                {
                    if (y < 8)
                    {
                        x = 0;
                        y++;
                    }

                }
                if (bulmacaCoz(x, y) == 1)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            if (sudoku[x, y] == 0)
            {

                while (rakam < 10)
                {

                    if (ayniSutun(x, y, rakam) == 0 && ayniSatir(x, y, rakam) == 0 && ayniKare(x, y, rakam) == 0)
                    {
                        sudoku[x, y] = rakam;
                        if (x == 8 && y == 8)
                        {
                            return 1;
                        }
                        if (x < 8)
                        {
                            tx = x + 1;
                        }
                        else
                        {
                            if (y < 8)
                            {
                                tx = 0;
                                ty = y + 1;
                            }
                        }
                        if (bulmacaCoz(tx, ty) == 1)
                        {
                            return 1;
                        }
                    }
                    rakam++;
                }
                sudoku[x, y] = 0;
                return 0;
            }
            return 0;
        }

    }
}
