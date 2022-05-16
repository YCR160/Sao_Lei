namespace Utils.Point
{
    public class Point
    {
        public int X;
        public int Y;

        public Point(int a, int b)
        {
            X = a;
            Y = b;
        }

        public Point(string s)
        {
            if (s == null)
            {
                s = "0,0";
            }
            var pos = s.Split(',');
            if (!int.TryParse(pos[0], out X)) X = 0;
            if (!int.TryParse(pos[0], out Y)) Y = 0;
        }
    }
}