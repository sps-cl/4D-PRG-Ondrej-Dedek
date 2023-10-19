namespace console_game
{
    public class Meteor : GameObject
    {
        public Meteor(Vector position) : base(position)
        {
            Image = new Image(new string[,] {
                {"  ", "# ", "# ", "# ", "# ", "  ", "# "},
                {"# ", "  ", "  ", "# ", "  ", "# ", "  "},
                {"# ", "# ", "# ", "  ", "  ", "# ", "# "},
                {"# ", "  ", "  ", "# ", "  ", "# ", "  "},
                {"# ", "  ", "  ", "  ", "# ", "# ", "  "},
                {"  ", "# ", "# ", "# ", "# ", "  ", "# "}}, Position);
            Collider = new CircleCollider(Position, Image.Width / 2);
            Speed = new Vector(-1.4f, 0);
        }

        public override void Move()
        {
            base.Move();
            if (Collider.RightEdge < MinBounds.X) OnDestroy();
        }
    }
}