namespace console_game
{
    public class Vector
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float SquareSize { get => X * X + Y * Y; }
        public Vector(float x, float y)
        {
            X = x;
            Y = y;
        }

        public void Add(Vector other)
        {
            X += other.X;
            Y += other.Y;
        }

        public static Vector operator -(Vector a, Vector b)
        {
            return new Vector(a.X - b.X, a.Y - b.Y);
        }
    }
}