namespace console_game
{
    public class GameObject : IDrawable, IMoveable
    {
        private Vector _position { get; set; }
        public Vector Position { get => _position; set { _position.X = value.X; _position.Y = value.Y; } }
        public Vector Speed { get; set; }

        public Vector MinBounds { get; set; }
        public Vector MaxBounds { get; set; }
        public Collider Collider { get; set; }
        public Image Image { get; set; }

        public Action OnDestroy { get; set; }

        public GameObject(Vector position)
        {
            _position = position;
            Speed = new Vector(0, 0);
            MinBounds = new Vector(int.MinValue, int.MaxValue);
            MaxBounds = new Vector(int.MaxValue, int.MaxValue);
        }

        public void Draw(string[,] scene)
        {
            Image.Draw(scene);
        }

        public virtual void Move()
        {
            _position.Add(Speed);
        }
        public bool CollideWith(Collider other)
        {
            return Collider.CollideWith(other);
        }
    }
}