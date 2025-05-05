using System;
using System.ComponentModel.Design;
using System.IO;
using System.Threading;

namespace TicTacToe
{
    public class Program
    {
        static char[] cell = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
        static int gamer = 1;
        static int step;

        private static void field()   
        {
            Console.WriteLine(  "  1   |  2   |  3   ");
            Console.WriteLine("  {0}   |  {1}   |  {2}", cell[1], cell[2], cell[3]);
            Console.WriteLine(  "______|______|______ ");
            Console.WriteLine(  "  4   |  5   |  6   ");
            Console.WriteLine("  {0}   |  {1}   |  {2}", cell[4], cell[5], cell[6]);
            Console.WriteLine(  "______|______|______ ");
            Console.WriteLine(  "  7   |  8   |  9   ");
            Console.WriteLine("  {0}   |  {1}   |  {2}", cell[7], cell[8], cell[9]);
            Console.WriteLine(  "      |      |      ");
        }

        static int combo = 0;
        static void Main(string[] args) 
        {
            do
            {
                Console.Clear();

                Console.WriteLine("Игра Крестики-нолики с двумя игроками. В свой ход игроку нужно ввести номер ячейки на поле цифрой от 1 до 9\n\n");

                if (gamer % 2 == 0)  Console.WriteLine("Ходит второй игрок (О) \n\n");
                else                  Console.WriteLine("Ходит первый игрок (Х) \n\n");

                field();

                step = int.Parse(Console.ReadLine());

                if (step >= 1 && step <= 9)
                {
                    if (cell[step] != 'X' && cell[step] != 'O')
                    {
                        if (gamer % 2 == 0)
                        {
                            cell[step] = 'O';
                            gamer++;
                        }
                        else
                        {
                            cell[step] = 'X';
                            gamer++;
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n\nЯчейка {0} уже занята {1} \nДождитесь перезагрузки доски и сделайте другой ход", step, cell[step]);
                        Thread.Sleep(2000);
                    }
                }
                else
                {
                    Console.WriteLine("\n\nВы вводите недопустимое число \nДождитесь перезагрузки доски и сделайте другой ход");
                    Thread.Sleep(2000);
                }
                combo = luck();
            }
            while (combo != 1 && combo != -1);

            Console.Clear();
            Console.WriteLine("Конец игры\n\n");

            field();
            if (combo == 1)  Console.WriteLine("\n\nИгрок {0} выйграл!", (gamer % 2) + 1);
            else Console.WriteLine("\n\nНичья");
            Console.ReadLine();
        }

        private static int luck()
        {
            if (((cell[1] == cell[2] && cell[2] == cell[3]) && (cell[1] != ' ' && cell[2] != ' ' && cell[3] != ' ')) ||
                ((cell[4] == cell[5] && cell[5] == cell[6]) && (cell[4] != ' ' && cell[5] != ' ' && cell[6] != ' ')) ||
                ((cell[6] == cell[7] && cell[7] == cell[8]) && (cell[6] != ' ' && cell[7] != ' ' && cell[8] != ' ')) ||
                ((cell[1] == cell[4] && cell[4] == cell[7]) && (cell[1] != ' ' && cell[4] != ' ' && cell[7] != ' ')) ||
                ((cell[2] == cell[5] && cell[5] == cell[8]) && (cell[2] != ' ' && cell[5] != ' ' && cell[5] != ' ')) ||
                ((cell[3] == cell[6] && cell[6] == cell[9]) && (cell[3] != ' ' && cell[6] != ' ' && cell[9] != ' ')) ||
                ((cell[1] == cell[5] && cell[5] == cell[9]) && (cell[1] != ' ' && cell[5] != ' ' && cell[9] != ' ')) ||
                ((cell[3] == cell[5] && cell[5] == cell[7]) && (cell[3] != ' ' && cell[5] != ' ' && cell[7] != ' '))) return 1;

            else if (cell[1] != ' ' && cell[2] != ' ' && cell[3] != ' ' && cell[4] != ' ' && cell[5] != ' ' && cell[6] != ' ' && cell[7] != ' ' && cell[8] != ' ' && cell[9] != ' ')    return -1;
           
            else   return 0;
        }

    }
}