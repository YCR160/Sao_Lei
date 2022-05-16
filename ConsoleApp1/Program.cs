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
        /// 数数的
        /// </summary>
        /// <param name="row">行</param>
        /// <param name="col">列</param>
        /// <returns></returns>
        static int Count(int row, int col)
        {
            if (lei[row, col] != 114) return -1;
            int ans = 0;
            for (int i = row - 1; i < row + 2; i++)
            {
                for (int j = col - 1; j < col + 2; j++)
                {
                    if (i == row && j == col) continue;
                    if (i > 9 || j > 9) continue;
                    if (i < 0 || j < 0) continue;
                    if (lei[i, j] == -1) ans++;
                }
            }
            lei[row, col] = ans;
            num--;
            if (ans == 0) Find(row, col);
            return ans;
        }
        static void Find(int row, int col)
        {
            for (int i = row - 1; i < row + 2; i++)
            {
                for (int j = col - 1; j < col + 2; j++)
                {
                    if (i == row && j == col) continue;
                    if (i > 9 || j > 9) continue;
                    if (i < 0 || j < 0) continue;
                    if (lei[i, j] == 114)
                    {
                        Count(i, j);
                    }
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
                Console.WriteLine("hai hai");
                Console.WriteLine("输入一个坐标开始，坐标格式“a,b”");
                var point = new Point(Console.ReadLine());
                num = 0;
                while (num < field)
                {
                    Random rnd = new Random();
                    int row = rnd.Next(0, 10);
                    int col = rnd.Next(0, 10);
                    if (lei[row, col] == 114 && !(row == point.X && col == point.Y))
                    {
                        lei[row, col] = -1;//埋雷
                        num++;
                    }
                }
                num = 90;
                lei[point.X, point.Y] = Count(point.X, point.Y);
                while (true)
                {
                    if (num == 0) Console.WriteLine(" 你好扫啊 ");
                    Console.WriteLine("  0 1 2 3 4 5 6 7 8 9");
                    for (int i = 0; i < 10; i++)
                    {
                        Console.Write(i + " ");
                        for (int j = 0; j < 10; j++)
                        {
                            if (lei[i, j] < 0 || lei[i, j] == 114) Console.Write("▅");
                            else Console.Write(lei[i, j]);
                            Console.Write(" ");
                        }
                        Console.Write("\n");
                    }
                    point = new Point(Console.ReadLine());
                    if (point.X < 0 || point.Y < 0) continue;
                    if (point.X > 9 && point.Y > 9) continue;
                    if (lei[point.X, point.Y] == -1)
                    {
                        Console.WriteLine("ji");
                        break;
                    }
                    else
                    {
                        Count(point.X, point.Y);
                    }
                }
            }
            Console.ReadKey();
        }
    }
}