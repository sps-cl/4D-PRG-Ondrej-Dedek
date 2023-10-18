namespace console_game
{
    public class RectCollider : Collider
    {
        public override float LeftEdge { get => Position.X; set => Position.X = value; }
        public override float RightEdge { get => Position.X + _width; set => Position.X = value - _width; }
        public override float TopEdge { get => Position.Y; set => Position.Y = value; }
        public override float BottomEdge { get => Position.Y + _height; set => Position.Y = value - _height; }

        private float _width { get; set; }
        private float _height { get; set; }

        public RectCollider(Vector position, float width, float height) : base(position)
        {
            _width = width;
            _height = height;
        }

        public override bool CollideWith(Collider collider)
        {
            return collider.CollideWith(this);
        }

        public override bool CollideWith(RectCollider collider)
        {
            return CollisionDetection.CheckCollision(this, collider);
        }

        public override bool CollideWith(CircleCollider collider)
        {
            return CollisionDetection.CheckCollision(this, collider);
        }
    }
}