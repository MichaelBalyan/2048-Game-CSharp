using System;
using System.Collections.Generic;

namespace Game2048
{
    class Game
    {
        private List<int> rowValues = new List<int>();
        private bool win = false;
        private bool canPlay = true;

        private int[,] board = new int[4, 4];

        public bool IsThereFreeField()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (board[i, j] == 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        public bool IsPlayable()
        {
            canPlay = IsThereFreeField();

            if (!canPlay)
            {

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
            }

            if (!canPlay)
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

        public void AddRandomNumber()
        {
            bool canAdd = canPlay;

            if (canAdd)
            {
                Random rnd = new Random();
                int probability = rnd.Next(1, 6);
                int num = 4;
                if (probability < 3)
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
        }

        public void Fill()
        {
            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    board[i, j] = 0;
                }
            }

            for (int i = 0; i < 2; i++)
            {
                AddRandomNumber();
            }
        } 

        public bool IsWinning()
        {
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

        public void PrintBoard()
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

        public void MoveUp()
        {
            for(int j = 0; j < 4; j++)
            { 
                for(int i = 0; i < 4; i++)
                {
                    if (board[i, j] != 0)
                    {
                        rowValues.Add(board[i, j]);
                    }
                }
                
                for(int i = 0; i < rowValues.Count - 1; i++)
                {
                    if (rowValues[i] == rowValues[i + 1])
                    {
                        rowValues[i] *= 2;
                        rowValues.RemoveAt(i + 1);
                    }
                }

                while(rowValues.Count < 4)
                {
                    rowValues.Add(0);
                }

                for(int i = 0; i < 4; i++)
                {
                    board[i, j] = rowValues[i];
                }

                rowValues.Clear();
            }
        }

        public void MoveDown()
        {
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (board[i, j] != 0)
                    {
                        rowValues.Add(board[i, j]);
                    }
                }

                for (int i = rowValues.Count - 1; i >= 1; i--)
                {
                    if (rowValues[i] == rowValues[i - 1])
                    {
                        rowValues[i] *= 2;
                        rowValues.RemoveAt(i - 1);
                        i--;
                    }
                }

                while (rowValues.Count < 4)
                {
                    rowValues.Insert(0, 0);
                }

                for (int i = 0; i < 4; i++)
                {
                    board[i, j] = rowValues[i];
                }

                rowValues.Clear();
            }
        }

        public void MoveLeft()
        {
            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    if (board[i, j] != 0)
                    {
                        rowValues.Add(board[i, j]);
                    }
                }

                for (int j = 0; j < rowValues.Count - 1; j++)
                {
                    if (rowValues[j] == rowValues[j + 1])
                    {
                        rowValues[j] *= 2;
                        rowValues.RemoveAt(j + 1);
                    }
                }

                while (rowValues.Count < 4)
                {
                    rowValues.Add(0);
                }

                for (int j = 0; j < 4; j++)
                {
                    board[i, j] = rowValues[j];
                }

                rowValues.Clear();
            }
        }

        public void MoveRight()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (board[i, j] != 0)
                    {
                        rowValues.Add(board[i, j]);
                    }
                }

                for (int j = rowValues.Count - 1; j >= 1; j--)
                {
                    if (rowValues[j] == rowValues[j - 1])
                    {
                        rowValues[j] *= 2;
                        rowValues.RemoveAt(j - 1);
                        j--;
                    }
                }

                while (rowValues.Count < 4)
                {
                    rowValues.Insert(0, 0);
                }

                for (int j = 0; j < 4; j++)
                {
                    board[i, j] = rowValues[j];
                }

                rowValues.Clear();
            }
        }

        public void StartGame()
        {
            Fill();

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
                    PrintBoard();
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("> ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    char input = char.Parse(Console.ReadLine().ToLower());
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
                            MoveUp();
                            break;
                        case 's':
                            MoveDown();
                            break;
                        case 'a':
                            MoveLeft();
                            break;
                        case 'd':
                            MoveRight();
                            break;
                    }

                    if (IsThereFreeField())
                    {
                        AddRandomNumber();
                    }

                    win = IsWinning();
                    canPlay = IsPlayable();
                }
                catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void CheckWin()
        {
            if (win)
            {
                PrintBoard();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Great! You have WON this game!!!");
                Console.ResetColor();
            }
            if (!canPlay)
            {
                PrintBoard();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Oops! You have lose the game...");
                Console.ResetColor();
            }
        }

        public void Play()
        {
            StartGame();
            CheckWin();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Play();
        }
    }
}
