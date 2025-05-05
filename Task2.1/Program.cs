
using System;
using System.IO;
using System.Threading;

namespace TicTacToe
{
    public class Program
    {
        static char[] cell = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
        static int player = 1;
        static int step;

        private static void field()
        {
            Console.WriteLine("  1   |  2   |  3   ");
            Console.WriteLine("  {0}   |  {1}   |  {2}", cell[1], cell[2], cell[3]);
            Console.WriteLine("______|______|______ ");
            Console.WriteLine("  4   |  5   |  6   ");
            Console.WriteLine("  {0}   |  {1}   |  {2}", cell[4], cell[5], cell[6]);
            Console.WriteLine("______|______|______ ");
            Console.WriteLine("  7   |  8   |  9   ");
            Console.WriteLine("  {0}   |  {1}   |  {2}", cell[7], cell[8], cell[9]);
            Console.WriteLine("      |      |      ");
        }

        static int combo = 0;
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();

                Console.WriteLine("Игра Крестики-нолики с двумя игроками. Игроки ходят по очереди.\n\n");

                if (player % 2 == 0) Console.WriteLine("Ходит второй игрок (О) \n\n");
                else Console.WriteLine("Ходит первый игрок (Х) \n\n");

                field();

                step = int.Parse(Console.ReadLine());


                if (cell[step] != 'X' && cell[step] != 'O')
                {
                    if (player % 2 == 0)
                    {
                        cell[step] = 'O';
                        player++;
                    }
                    else
                    {
                        cell[step] = 'X';
                        player++;
                    }
                }
                else
                {
                    Console.WriteLine("\n\nЯчейка {0} уже занята {1}", step, cell[step]);
                    Console.WriteLine("\nДождитесь перезагрузки доски и сделайте другой ход");
                    Thread.Sleep(1000);
                }

                combo = luck();
            }
            while (combo != 1 && combo != -1);

            Console.Clear();
            field();
            if (combo == 1) Console.WriteLine("\n\nИгрок {0} выйграл!", (player % 2) + 1);
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

            else if (cell[1] != ' ' && cell[2] != ' ' && cell[3] != ' ' && cell[4] != ' ' && cell[5] != ' ' && cell[6] != ' ' && cell[7] != ' ' && cell[8] != ' ' && cell[9] != ' ') return -1;

            else return 0;
        }

    }
}









/*
//Оригинал игры
using System;
using System.IO;
using System.Threading;

namespace TicTacToe
{
    public class Program
    {
        
        static char[] arr = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
        static int player = 1; 
        static int choice; 

        
        static int checkWon = 0;
        static void Main(string[] args)
        {
            do
            {
                
                Console.Clear();
                
                Console.WriteLine("Первый игрок проставляет: X, второй игрок: O");

                Console.WriteLine();
                Console.WriteLine();

                if (player % 2 == 0)
                {
                    Console.WriteLine("Ход игрока 2");
                }
                else
                {
                    Console.WriteLine("Ход игрока 1");
                }

                Console.WriteLine();
                Console.WriteLine();
                
                DrawBoard();
                
                choice = int.Parse(Console.ReadLine());

                
                if (arr[choice] != 'X' && arr[choice] != 'O')
                {
                    if (player % 2 == 0) 
                    {
                        arr[choice] = 'O';
                        player++;
                    }
                    else
                    {
                        arr[choice] = 'X';
                        player++;
                    }
                }
                else
                {
                    

                    Console.WriteLine("Ячейка {0} уже занята {1}", choice, arr[choice]);
                    Console.WriteLine("\n");
                    Console.WriteLine("Дождитесь перезагрузки доски");
                    Thread.Sleep(1000);
                }
                
                checkWon = CheckWin();
            }
            while (checkWon != 1 && checkWon != -1);
            

            Console.Clear();
            DrawBoard();
            if (checkWon == 1)
            {
                
                Console.WriteLine("Игрок {0} выйграл!", (player % 2) + 1);
            }
            else
            {
                Console.WriteLine("Ничья");
            }
            Console.ReadLine();


        }
        
        private static void DrawBoard()
        {
            Console.WriteLine("  1   |  2   |  3   ");
            Console.WriteLine("  {0}   |  {1}   |  {2}", arr[1], arr[2], arr[3]);
            Console.WriteLine("______|______|______ ");
            Console.WriteLine("  4   |  5   |  6   ");
            Console.WriteLine("  {0}   |  {1}   |  {2}", arr[4], arr[5], arr[6]);
            Console.WriteLine("______|______|______ ");
            Console.WriteLine("  7   |  8   |  9   ");
            Console.WriteLine("  {0}   |  {1}   |  {2}", arr[7], arr[8], arr[9]);
            Console.WriteLine("      |      |      ");
        }
        
        private static int CheckWin()
        {
            #region Horzontal Winning Condtion

            
            if ((arr[1] == arr[2] && arr[2] == arr[3]) && (arr[1] != ' ' && arr[2] != ' ' && arr[3] != ' '))
            {
                return 1;
            }
            
            else if ((arr[4] == arr[5] && arr[5] == arr[6]) && (arr[4] != ' ' && arr[5] != ' ' && arr[6] != ' '))
            {
                return 1;
            }
            
            else if ((arr[6] == arr[7] && arr[7] == arr[8]) && (arr[6] != ' ' && arr[7] != ' ' && arr[8] != ' '))
            {
                return 1;
            }
            #endregion
            #region vertical Winning Condtion
            
            else if ((arr[1] == arr[4] && arr[4] == arr[7]) && (arr[1] != ' ' && arr[4] != ' ' && arr[7] != ' '))
            {
                return 1;
            }
            
            else if ((arr[2] == arr[5] && arr[5] == arr[8]) && (arr[2] != ' ' && arr[5] != ' ' && arr[5] != ' '))
            {
                return 1;
            }
            
            else if ((arr[3] == arr[6] && arr[6] == arr[9]) && (arr[3] != ' ' && arr[6] != ' ' && arr[9] != ' '))
            {
                return 1;
            }
            #endregion
            #region Diagonal Winning Condition
            else if ((arr[1] == arr[5] && arr[5] == arr[9]) && (arr[1] != ' ' && arr[5] != ' ' && arr[9] != ' '))
            {
                return 1;
            }
            else if ((arr[3] == arr[5] && arr[5] == arr[7]) && (arr[3] != ' ' && arr[5] != ' ' && arr[7] != ' '))
            {
                return 1;
            }
            #endregion
            #region Checking For Draw
            
            else if (arr[1] != ' ' && arr[2] != ' ' && arr[3] != ' ' && arr[4] != ' ' && arr[5] != ' ' && arr[6] != ' ' && arr[7] != ' ' && arr[8] != ' ' && arr[9] != ' ')
            {
                return -1;
            }
            #endregion
            else
            {
                return 0;
            }
        }

    }
}*/