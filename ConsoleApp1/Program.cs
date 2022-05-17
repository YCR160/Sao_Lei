using System;
using Utils.Point;
namespace test
{
    class Program
    {
        const int field = 10;
        static int[,] lei = new int[field, field];
        static int num;

        /// <summary>
        /// 附近有多少个雷
        /// </summary>
        /// <param name="row">行</param>
        /// <param name="col">列</param>
        /// <returns></returns>
        static void Count(int row, int col)
        {
            if (lei[row, col] != 114) return;//已经数过或者是雷
            lei[row, col] = 0;
            for (int i = row - 1; i < row + 2; i++)
            {
                for (int j = col - 1; j < col + 2; j++)
                {
                    if (i == row && j == col) continue;
                    if ((i > field - 1 || j > field - 1) || (i < 0 || j < 0)) continue;
                    if (lei[i, j] == -1) lei[row, col]++;
                }
            }
            num--;
            if (lei[row, col] == 0) Find(row, col);
        }
        static void Find(int row, int col)
        {
            for (int i = row - 1; i < row + 2; i++)
            {
                for (int j = col - 1; j < col + 2; j++)
                {
                    if (i == row && j == col) continue;
                    if ((i > field - 1 || j > field - 1) || (i < 0 || j < 0)) continue;
                    if (lei[i, j] == 114) Count(i, j);
                }
            }
        }
        static void Main(string[] args)
        {
            Console.Title = "捏mama";
            while (true)
            {
                for (int i = 0; i < lei.GetLength(0); i++)
                {
                    for (int j = 0; j < lei.GetLength(1); j++)
                    {
                        lei[i, j] = 114;//未知
                    }
                }
                Console.WriteLine(" hai hai \n 输入一个坐标开始，坐标格式“a,b” \n");
                var point = new Point(Console.ReadLine());
                num = 0;
                while (num < field)
                {
                    Random rnd = new Random();
                    int row = rnd.Next(0, field);
                    int col = rnd.Next(0, field);
                    if (lei[row, col] == 114 && !(row == point.X && col == point.Y))
                    {
                        lei[row, col] = -1;//埋雷
                        num++;
                    }
                }
                num = field * field - field;
                Count(point.X, point.Y);
                while (true)
                {
                    Console.Write("    ");
                    for (int i = 0; i < field; i++) Console.Write(i < 10 ? "  " + i : " " + i);
                    Console.Write("\n    ");
                    for (int i = 0; i < field; i++) Console.Write("---");
                    for (int i = 0; i < field; i++)
                    {
                        Console.Write("\n" + i + (i < 10 ? "  | " : " | "));
                        for (int j = 0; j < field; j++)
                        {
                            if (lei[i, j] < 0 || lei[i, j] == 114) Console.Write("▅  ");
                            else Console.Write(lei[i, j] + "  ");
                        }
                    }
                    point = new Point(Console.ReadLine());
                    if ((point.X > field - 1 || point.Y > field - 1) || (point.X < 0 || point.Y < 0)) continue;
                    if (lei[point.X, point.Y] == -1)
                    {
                        Console.WriteLine(" 寄寄寄寄寄寄寄寄寄寄寄寄寄寄寄寄寄寄寄寄 ");
                        break;
                    }
                    else Count(point.X, point.Y);
                    if (num == 0) Console.WriteLine(" 你好扫啊~ ");
                }
            }
            Console.ReadKey();
        }
    }
}