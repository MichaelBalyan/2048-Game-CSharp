using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Game_2048
{
    internal class Program
    {
        class MatrixManager
        {
            public int[,] CreateMatrix()
            {
                int[,] matrix = new int[4, 4];

                Random rnd = new Random();
                int index_i_1 = rnd.Next(0, 4);
                int index_j_1 = rnd.Next(0, 4);
                int index_i_2 = rnd.Next(0, 4);
                int index_j_2 = rnd.Next(0, 4);

                int rndNumDecisive = rnd.Next(1, 10);

                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        matrix[i, j] = 0;
                        if (rndNumDecisive <= 6)
                        {
                            matrix[index_i_1, index_j_1] = 2;
                            matrix[index_i_2, index_j_2] = 2;
                        }
                        else if (rndNumDecisive > 6 && rndNumDecisive <= 8)
                        {
                            matrix[index_i_1, index_j_1] = 4;
                            matrix[index_i_2, index_j_2] = 2;
                        }
                        else
                        {
                            matrix[index_i_1, index_j_1] = 4;
                            matrix[index_i_2, index_j_2] = 4;
                        }
                    }
                }
                return matrix;
            }
            public int[,] AddRandomNumber(int[,] matrix)
            {
                Random rnd = new Random();
                int rndIndex_i = rnd.Next(0, 4);
                int rndIndex_j = rnd.Next(0, 4);

                while (matrix[rndIndex_i, rndIndex_j] != 0)
                {
                    rndIndex_i = rnd.Next(0, 4);
                    rndIndex_j = rnd.Next(0, 4);
                }

                int rndNumDecisive = rnd.Next(1, 10);
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (rndNumDecisive <= 7)
                        {
                            matrix[rndIndex_i, rndIndex_j] = 2;
                        }
                        else
                        {
                            matrix[rndIndex_i, rndIndex_j] = 4;
                        }
                    }
                }
                return matrix;
            }
            public void Print(int [,] matrix)
            {
                Console.WriteLine("=====================================");
                Console.WriteLine("====== Welcome to the Game 2048! ====");
                Console.WriteLine("=====================================");
                Console.WriteLine();
                Console.WriteLine("Tips: You cane use only 'w', 'a', 's', 'd' keys for move.");
                Console.WriteLine();
                Console.WriteLine();

                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        Console.Write(matrix[i, j] + "\t");
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                }
            }
            public int[,] MoveRight(int[,] matrix)
            {
                for(int i = 0; i < 4; i++)
                {
                    List<int> values = new List<int>();
                    for(int j = 0; j < 4; j++)
                    {
                        if (matrix[i, j] != 0)
                        {
                            values.Add(matrix[i, j]);
                        }
                    }
                    
                    List<int> merge = new List<int>();
                    for(int v = values.Count - 1 ; v >= 0; v--)
                    {
                        if (v > 0 && values[v] == values[v - 1])
                        {
                            merge.Add(values[v] * 2);
                            v--;
                        }
                        else
                        {
                            merge.Add(values[v]);
                        }
                    }

                    int col = 3;
                    for(int m = 0; m < merge.Count; m++)
                    {
                        matrix[i, col] = merge[m];
                        col--;
                    }
                    
                    while(col >= 0)
                    {
                        matrix[i, col] = 0;
                        col--;
                    }
                }

                return matrix;
            }
            public int[,] MoveLeft(int[,] matrix)
            {
                for(int i = 0; i < 4; i++)
                {
                    List<int> values = new List<int>();
                    for(int j = 0; j < 4; j++)
                    {
                        if (matrix[i, j] != 0)
                        {
                            values.Add(matrix[i, j]);
                        }
                    }

                    List<int> merge = new List<int>();
                    for(int v = 0; v < values.Count; v++)
                    {
                        if (v < values.Count - 1 && values[v] == values[v + 1])
                        {
                            merge.Add(values[v] * 2);
                            v++;
                        }
                        else
                        {
                            merge.Add(values[v]);
                        }
                    }

                    int col = 0;
                    for(int m = 0; m < merge.Count; m++)
                    {
                        matrix[i, col] = merge[m];
                        col++;
                    }
                    while(col < 4)
                    {
                        matrix[i, col] = 0;
                        col++;
                    }
                }

                return matrix;
            }

            public int[,] MoveUp(int[,] matrix)
            {
                for(int j = 0; j < 4; j++)
                {
                    List<int> values = new List<int>();
                    for(int i = 0; i < 4; i++)
                    {
                        if (matrix[i, j] != 0)
                        {
                            values.Add(matrix[i, j]);
                        }
                    }

                    List<int> merge = new List<int>();
                    for(int v = 0; v < values.Count; v++)
                    {
                        if(v < values.Count - 1 && values[v] == values[v + 1])
                        {
                            merge.Add(values[v] * 2);
                            v++;
                        }
                        else
                        {
                            merge.Add(values[v]);
                        }
                    }

                    int row = 0;
                    for(int m = 0; m < merge.Count; m++)
                    {
                        matrix[row, j] = merge[m];
                        row++;
                    }

                    while( row < 4)
                    {
                        matrix[row, j] = 0;
                        row++;
                    }
                }

                return matrix;
            }

            public int[,] MoveDown(int[,] matrix)
            {
                for(int j = 0; j < 4; j++)
                {
                    List<int> values = new List<int>();
                    for(int i = 0; i < 4; i++)
                    {
                        if (matrix[i, j] != 0)
                        {
                            values.Add(matrix[i, j]);
                        }
                    }

                    List<int> merge = new List<int>();
                    for(int v = values.Count - 1; v >= 0; v--)
                    {
                        if(v > 0 && values[v] == values[v - 1])
                        {
                            merge.Add(values[v] * 2);
                            v--;
                        }
                        else
                        {
                            merge.Add(values[v]);
                        }
                    }

                    int row = 3;
                    for(int m = 0; m < merge.Count; m++)
                    {
                        matrix[row, j] = merge[m];
                        row--;
                    }

                    while(row >= 0)
                    {
                        matrix[row, j] = 0;
                        row--;
                    }
                }

                return matrix;
            }
        }
        static void Main(string[] args)
        {
            MatrixManager manager = new MatrixManager();

            int[,] matrix = manager.CreateMatrix();
            manager.Print(matrix);


            bool gameOver = false;

            while (gameOver == false)
            {
                Console.Write("> ");
                string move = Console.ReadLine();
                Console.Clear();

                if(move == "d")
                {
                    int[,] matrix1 = manager.MoveRight(matrix);
                    int[,] matrix2 = manager.AddRandomNumber(matrix1);
                    matrix = matrix2;
                    manager.Print(matrix);
                    Console.WriteLine();
                }
                else if(move == "a")
                {
                    int[,] matrix1 = manager.MoveLeft(matrix);
                    int[,] matrix2 = manager.AddRandomNumber(matrix1);
                    matrix = matrix2;
                    manager.Print(matrix);
                    Console.WriteLine();
                }
                else if(move == "w")
                {
                    int[,] matrix1 = manager.MoveUp(matrix);
                    int[,] matrix2 = manager.AddRandomNumber(matrix1);
                    matrix = matrix2;
                    manager.Print(matrix);
                    Console.WriteLine();
                }
                else if(move == "s")
                {
                    int[,] matrix1 = manager.MoveDown(matrix);
                    int[,] matrix2 = manager.AddRandomNumber(matrix1);
                    matrix = matrix2;
                    manager.Print(matrix);
                    Console.WriteLine();
                }
                else
                {
                    manager.Print(matrix);
                    Console.WriteLine();
                    Console.WriteLine("You can only enter 'w', 'a', 's' or 'd'!");
                    Console.WriteLine();
                }
            }
        }
    }
}
