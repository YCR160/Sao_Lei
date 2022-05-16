using System;
using Utils.Point;
namespace test
{
    class Program
    {
        const int field = 10;
        static int[,] lei = new int[field, field];
        /// <summary>
        /// 数数的
        /// </summary>
        /// <param name="row">行</param>
        /// <param name="col">列</param>
        /// <returns></returns>
        static int Count(int row, int col)
        {
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
            Console.Title = "捏";
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
            int num = 0;
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
            lei[point.X, point.Y] = Count(point.X, point.Y);
            while (true)
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (lei[i, j] < 0 || lei[i, j] == 114) Console.Write("?");
                        else Console.Write(lei[i, j]);
                        Console.Write(" ");
                    }
                    Console.Write("\n");
                }
                point = new Point(Console.ReadLine());
                if (lei[point.X, point.Y] == -1)
                {
                    Console.WriteLine("ji");
                    break;
                }
                else
                {
                    lei[point.X, point.Y] = Count(point.X, point.Y);
                }
            }
            Console.ReadKey();
        }
    }
}