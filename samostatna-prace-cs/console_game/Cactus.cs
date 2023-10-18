namespace console_game
{
    public class Cactus : GameObject
    {
        public Cactus(Vector position) : base(position)
        {
            Image = new Image(new string[,] {
                { "# ", "# ", " ", "# ", "# "},
                { "# ", "# ", " ", "# ", "# "},
                { "# ", "# ", "# ", "# ", "# "},
                { "# ", "# ", "# ", "# ", " "},
                { " ", "# ", "# ", " ", " "},
                { " ", "# ", "# ", " ", " "}}, Position);
            Collider = new RectCollider(Position, Image.Width, Image.Height);
            Speed = new Vector(-1.4f, 0);
        }

        public override void Move()
        {
            base.Move();
            if (Collider.RightEdge < MinBounds.X) OnDestroy();
        }
    }
}