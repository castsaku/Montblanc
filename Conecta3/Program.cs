using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conecta3
{
    internal class Program
    {
        static string[,] symbols = new string[3, 3] { { "1", "4", "7" }, { "2", "5", "8" }, { "3", "6", "9" } };
        static int[,] gridnum = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        static int x = 0, y = 0, turn = 1, finish = 0, seleccion;
        static void Main(string[] args)
        {
            do
            {
                PrintGrid();

                CheckWinner();

                if(finish == 0)
                {
                    AskSelection();

                    SelectionToGrid();

                    turn += 1;

                    MarkGrid();
                }
            }
            while (finish == 0 && turn != 10);
            AnnounceWinner();
        }



        static int CheckWinner()
        {
            int firstRow, secondRow, thirdRow, firstColumn, secondColumn, thirdColumn, diagRight, diagLeft;

            firstRow = gridnum[0,0] + gridnum[1,0] + gridnum[2,0];
            secondRow = gridnum[0, 1] + gridnum[1, 1] + gridnum[2, 1];
            thirdRow = gridnum[0, 2] + gridnum[1, 2] + gridnum[2, 2];

            firstColumn = gridnum[0, 0] + gridnum[0, 1] + gridnum[0, 2];
            secondColumn = gridnum[1, 0] + gridnum[1, 1] + gridnum[1, 2];
            thirdColumn = gridnum[2, 0] + gridnum[2, 1] + gridnum[2, 2];

            diagRight = gridnum[0, 0] + gridnum[1, 1] + gridnum[2, 2];
            diagLeft = gridnum[2, 0] + gridnum[1, 1] + gridnum[0, 2];

            if (firstRow == 3 || firstRow == 30)
            {
                finish = 1;
            }

            if (secondRow == 3 || secondRow == 30)
            {
                finish = 1;
            }

            if (thirdRow == 3 || thirdRow == 30)
            {
                finish = 1;
            }

            if (firstColumn == 3 || firstColumn == 30)
            {
                finish = 1;
            }

            if (secondColumn == 3 || secondColumn == 30)
            {
                finish = 1;
            }

            if (thirdColumn == 3 || thirdColumn == 30)
            {
                finish = 1;
            }

            if (diagRight == 3 || diagRight == 30)
            {
                finish = 1;
            }

            if (diagLeft == 3 || diagLeft == 30)
            {
                finish = 1;
            }

            firstRow = 0;
            secondRow = 0;
            thirdRow = 0;

            firstColumn = 0;
            secondColumn = 0;
            thirdColumn = 0;

            diagRight = 0;
            diagLeft = 0;

            return finish;
        }

        static void SelectionToGrid()
        {
            if (seleccion == 1)
            {
                x = 0;
                y = 0;
            }

            if (seleccion == 2)
            {
                x = 1;
                y = 0;
            }

            if (seleccion == 3)
            {
                x = 2;
                y = 0;
            }

            if (seleccion == 4)
            {
                x = 0;
                y = 1;
            }

            if (seleccion == 5)
            {
                x = 1;
                y = 1;
            }

            if (seleccion == 6)
            {
                x = 2;
                y = 1;
            }

            if (seleccion == 7)
            {
                x = 0;
                y = 2;
            }

            if (seleccion == 8)
            {
                x = 1;
                y = 2;
            }

            if (seleccion == 9)
            {
                x = 2;
                y = 2;
            }
        }

        static void PrintGrid()
        {
            Console.Clear();

            Console.Write(symbols[0, 0]);
            Console.Write("|");
            Console.Write(symbols[1, 0]);
            Console.Write("|");
            Console.Write(symbols[2, 0]);

            Console.WriteLine();

            Console.Write(symbols[0, 1]);
            Console.Write("|");
            Console.Write(symbols[1, 1]);
            Console.Write("|");
            Console.Write(symbols[2, 1]);

            Console.WriteLine();

            Console.Write(symbols[0, 2]);
            Console.Write("|");
            Console.Write(symbols[1, 2]);
            Console.Write("|");
            Console.Write(symbols[2, 2]);

            Console.WriteLine();
            Console.WriteLine();
        }

        static void AskSelection()
        {
            do
            {
                Console.WriteLine("¿Que espacio desea ocupar?");
                Console.WriteLine();

                seleccion = int.Parse(Console.ReadLine());

                if (seleccion < 0 || seleccion > 9)
                {
                    Console.Clear();

                    PrintGrid();

                    Console.WriteLine("Selecciona una casilla entre 1 y 9");
                }
            }
            while (seleccion < 0 || seleccion > 9);
        }
        static void AnnounceWinner()
        {
            if (finish == 0)
            {
                PrintGrid();
                Console.WriteLine("GANADOR: NADIE");
            }
            else
            {
                if (turn % 2 == 0)
                {
                    PrintGrid();
                    Console.WriteLine("GANADOR: JUGADOR 1");
                }
                else
                {
                    PrintGrid();
                    Console.WriteLine("GANADOR: JUGADOR 2");
                }
            }
            Console.ReadKey();
        }

        static void MarkGrid()
        {
            if (gridnum[x, y] == 0)
            {
                if (turn % 2 == 0)
                {
                    symbols[x, y] = "O";
                    gridnum[x, y] = 10;
                }
                else
                {
                    symbols[x, y] = "X";
                    gridnum[x, y] = 1;
                }
            }
        }
    }
}
