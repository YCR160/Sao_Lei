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
        /// <param name="r">行</param>
        /// <param name="c">列</param>
        /// <returns></returns>
        static int Count(int r, int c)
        {
            int ans = 0;
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if (i == 0 && j == 0) continue;
                    if (lei[r + i, c + j] == -1) ans++;
                }
            }
            return ans;
        }
        static void Main(string[] args)
        {
            Console.Title = "捏";
            for (int i = 0; i < lei.GetLength(0); i++)
            {
                for (int j = 0; j < lei.GetLength(1); j++)
                {
                    lei[i, j] = 0;
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
                if (lei[row, col] == 0 && !(row == point.X && col == point.Y))
                {
                    lei[row, col] = -1;
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
                        if (lei[i, j] <= 0) Console.WriteLine("?");
                        else Console.WriteLine(lei[i, j]);
                    }
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