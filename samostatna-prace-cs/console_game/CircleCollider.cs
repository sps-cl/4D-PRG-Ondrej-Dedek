namespace console_game
{
    public class CircleCollider : Collider
    {
        public override float LeftEdge { get => Position.X; set => Position.X = value; }
        public override float RightEdge { get => Position.X + Radius * 2; set => Position.X = value - Radius * 2; }
        public override float TopEdge { get => Position.Y; set => Position.Y = value; }
        public override float BottomEdge { get => Position.Y + Radius * 2; set => Position.Y = value - Radius * 2; }

        public float Radius { get; set; }

        public CircleCollider(Vector position, float radius) : base(position)
        {
            Radius = radius;
        }

        public override bool CollideWith(Collider collider)
        {
            return collider.CollideWith(this);
        }

        public override bool CollideWith(RectCollider collider)
        {
            return CollisionDetection.CheckCollision(collider, this);
        }

        public override bool CollideWith(CircleCollider collider)
        {
            return CollisionDetection.CheckCollision(collider, this);
        }
    }
}