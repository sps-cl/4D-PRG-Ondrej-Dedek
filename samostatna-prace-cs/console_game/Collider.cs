namespace console_game
{
    public abstract class Collider
    {
        public Vector Position { get; }
        public abstract float LeftEdge { get; set; }
        public abstract float RightEdge { get; set; }
        public abstract float TopEdge { get; set; }
        public abstract float BottomEdge { get; set; }

        public Collider(Vector position)
        {
            Position = position;
        }

        public abstract bool CollideWith(Collider collider);
        public abstract bool CollideWith(RectCollider collider);
        public abstract bool CollideWith(CircleCollider collider);
    }
}