using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2048
{
    class Game
    {
        public bool IsPlayable(int[,] board)
        {
            bool canPlay = false;

            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    if (board[i, j] == 0)
                    {
                        canPlay = true;
                        break;
                    }
                }
                if(canPlay == true)
                {
                    break;
                }
            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == board[i, j + 1])
                    {
                        canPlay = true;
                        break;
                    }
                }
                if (canPlay == true)
                {
                    break;
                }
            }

            if (canPlay == false)
            {
                for (int j = 0; j < 4; j++)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (board[i, j] == board[i + 1, j])
                        {
                            canPlay = true;
                            break;
                        }
                    }
                    if (canPlay == true)
                    {
                        break;
                    }
                }
            }

            return canPlay;
        }

        public int[,] AddRandomNumber(int[,] board)
        {
            bool canAdd = false;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (board[i, j] == 0)
                    {
                        canAdd = true;
                    }
                }
            }

            if (canAdd == true)
            {
                Random rnd = new Random();
                int probabillity = rnd.Next(1, 4);
                int num = 4;
                if (probabillity < 3)
                {
                    num = 2;
                }

                int index_i = rnd.Next(0, 4);
                int index_j = rnd.Next(0, 4);

                while (board[index_i, index_j] != 0)
                {
                    index_i = rnd.Next(0, 4);
                    index_j = rnd.Next(0, 4);
                }

                board[index_i, index_j] = num;
            }
            

            return board;
        }

        public int[,] Fill(int[,] board)
        {
            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    board[i, j] = 0;
                }
            }

            board = AddRandomNumber(board);
            board = AddRandomNumber(board);

            return board;
        } 

        public bool IsWinning(int[,] board)
        {
            bool win = false; 
            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    if (board[i, j] == 2048)
                    {
                        win = true;
                    }
                }
            }

            return win;
        }

        public void Print(int[,] board)
        {
            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    if (board[i, j] == 0)
                    {
                        Console.Write(". " + "\t");
                    }
                    else
                    {
                        switch(board[i, j])
                        {
                            case 2:
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                break;
                            case 4:
                                Console.ForegroundColor = ConsoleColor.Green;
                                break;
                            case 8:
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                break;
                            case 16:
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                break;
                            case 32:
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                break;
                            case 64:
                                Console.ForegroundColor = ConsoleColor.Red;
                                break;
                            case 128:
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                break;
                            case 256:
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                break;
                            case 512:
                                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                break;
                            case 1024:
                                Console.ForegroundColor = ConsoleColor.Blue;
                                break;
                            case 2048:
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                break;

                        }
                        Console.Write(board[i, j] + "\t");
                    }
                    Console.ResetColor();
                }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        public int[,] MoveUp(int[,] board)
        {
            List<int> list = new List<int>();

            for(int j = 0; j < 4; j++)
            { 
                for(int i = 0; i < 4; i++)
                {
                    if (board[i, j] != 0)
                    {
                        list.Add(board[i, j]);
                    }
                }
                
                for(int i = 0; i < list.Count - 1; i++)
                {
                    if (list[i] == list[i + 1])
                    {
                        list[i] *= 2;
                        list.RemoveAt(i + 1);
                    }
                }

                while(list.Count < 4)
                {
                    list.Add(0);
                }

                for(int i = 0; i < 4; i++)
                {
                    board[i, j] = list[i];
                }

                list.Clear();
            }

            board = AddRandomNumber(board);

            return board;
        }

        public int[,] MoveDown(int[,] board)
        {
            List<int> list = new List<int>();

            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (board[i, j] != 0)
                    {
                        list.Add(board[i, j]);
                    }
                }

                for (int i = list.Count - 1; i >= 1; i--)
                {
                    if (list[i] == list[i - 1])
                    {
                        list[i] *= 2;
                        list.RemoveAt(i - 1);
                        i--;
                    }
                }

                while (list.Count < 4)
                {
                    list.Insert(0, 0);
                }

                for (int i = 0; i < 4; i++)
                {
                    board[i, j] = list[i];
                }

                list.Clear();
            }

            board = AddRandomNumber(board);

            return board;
        }

        public int[,] MoveLeft(int[,] board)
        {
            List<int> list = new List<int>();

            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    if (board[i, j] != 0)
                    {
                        list.Add(board[i, j]);
                    }
                }

                for (int j = 0; j < list.Count - 1; j++)
                {
                    if (list[j] == list[j + 1])
                    {
                        list[j] *= 2;
                        list.RemoveAt(j + 1);
                    }
                }

                while (list.Count < 4)
                {
                    list.Add(0);
                }

                for (int j = 0; j < 4; j++)
                {
                    board[i, j] = list[j];
                }

                list.Clear();
            }

            board = AddRandomNumber(board);

            return board;
        }

        public int[,] MoveRight(int[,] board)
        {
            List<int> list = new List<int>();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (board[i, j] != 0)
                    {
                        list.Add(board[i, j]);
                    }
                }

                for (int j = list.Count - 1; j >= 1; j--)
                {
                    if (list[j] == list[j - 1])
                    {
                        list[j] *= 2;
                        list.RemoveAt(j - 1);
                        j--;
                    }
                }

                while (list.Count < 4)
                {
                    list.Insert(0, 0);
                }

                for (int j = 0; j < 4; j++)
                {
                    board[i, j] = list[j];
                }

                list.Clear();
            }

            board = AddRandomNumber(board);

            return board;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] board = new int[4, 4];
            bool win = false;
            bool canPlay = true;

            Game game = new Game();
            board = game.Fill(board);

            while (canPlay == true && win == false)
            {
                try
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("=== Game 2048 ===");
                    Console.ResetColor();
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Press 'w', 'a', 's', 'd' for moves.");
                    Console.WriteLine("Press 'p' for end.");
                    Console.ResetColor();
                    Console.WriteLine();
                    Console.WriteLine();
                    game.Print(board);
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("> ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    char input = char.Parse(Console.ReadLine());
                    Console.ResetColor();
                    Console.WriteLine();

                    if (input == 'p') 
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You have breaked the game!");
                        Console.ResetColor();
                        break;
                    }

                    switch (input)
                    {
                        case 'w':
                            board = game.MoveUp(board);
                            win = game.IsWinning(board);
                            canPlay = game.IsPlayable(board);
                            break;
                        case 's':
                            board = game.MoveDown(board);
                            win = game.IsWinning(board);
                            canPlay = game.IsPlayable(board);
                            break;
                        case 'a':
                            board = game.MoveLeft(board);
                            win = game.IsWinning(board);
                            canPlay = game.IsPlayable(board);
                            break;
                        case 'd':
                            board = game.MoveRight(board);
                            win = game.IsWinning(board);
                            canPlay = game.IsPlayable(board);
                            break;
                    }

                   
                }
                catch (Exception) { }
            }
            if(win == true)
            {
                game.Print(board);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Great! You have WON this game!!!");
                Console.ResetColor();
            }
            if(canPlay == false)
            {
                game.Print(board);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Oops! You have lose the game...");
                Console.ResetColor();
            }
            
        }
    }
}
