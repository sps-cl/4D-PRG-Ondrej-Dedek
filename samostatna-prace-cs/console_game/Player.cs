namespace console_game
{
    public class Player : GameObject
    {
        private Image _crouchingImage { get; set; }
        private Image _standingImage { get; set; }
        private Collider _crouchingCollider { get; set; }
        private Collider _standingCollider { get; set; }
        private bool _grounded { get; set; }
        private bool _crouching { get; set; }
        public Player(Vector position) : base(position)
        {
            _standingImage = new Image(new string[,] {
                {"  ", "  ", "  ", "  ", "# ", "# ", "  ", "  "},
                {"  ", "  ", "  ", "  ", "# ", "# ", "# ", "# "},
                {"  ", "  ", "  ", "  ", "# ", "# ", "# ", "# "},
                {"  ", "  ", "  ", "  ", "# ", "# ", "  ", "  "},
                {"  ", "  ", "  ", "# ", "# ", "# ", "  ", "  "},
                {"  ", "  ", "# ", "# ", "# ", "# ", "# ", "  "},
                {"  ", "# ", "# ", "# ", "# ", "# ", "  ", "  "},
                {"# ", "# ", "# ", "# ", "# ", "# ", "  ", "  "},
                {"  ", "  ", "# ", "  ", "  ", "# ", "  ", "  "},
                {"  ", "  ", "# ", "# ", "  ", "# ", "# ", "  "}}, Position);
            _crouchingImage = new Image(new string[,] {
                {"  ", "  ", "  ", "  ", "# ", "# ", "  ", "  "},
                {"  ", "  ", "  ", "  ", "# ", "# ", "# ", "# "},
                {"  ", "  ", "  ", "  ", "# ", "# ", "# ", "# "},
                {"  ", "  ", "  ", "# ", "# ", "# ", "  ", "  "},
                {"  ", "  ", "# ", "# ", "# ", "# ", "# ", "  "},
                {"# ", "# ", "# ", "# ", "# ", "# ", "  ", "  "},
                {"  ", "  ", "# ", "# ", "  ", "# ", "# ", "  "}}, Position);
            _standingCollider = new RectCollider(Position, _standingImage.Width, _standingImage.Height);
            _crouchingCollider = new RectCollider(Position, _crouchingImage.Width, _crouchingImage.Height);
            Image = _standingImage;
            Collider = _standingCollider;
            _grounded = false;
            _crouching = false;
        }

        public override void Move()
        {
            Speed.Y += 0.3f;
            base.Move();
            if (Collider.BottomEdge > MaxBounds.Y)
            {
                _grounded = true;
                Collider.BottomEdge = MaxBounds.Y;
                Speed.Y = 0;
            }
            else _grounded = false;
        }

        public void StandUp()
        {
            Image = _standingImage;
            Collider = _standingCollider;
            _crouching = false;
        }
        public void Jump()
        {
            if (!_grounded) return;
            StandUp();
            Speed.Y = -3;
        }
        public void Crouch()
        {
            if (_crouching) return;
            Image = _crouchingImage;
            Collider = _crouchingCollider;
            _crouching = true;

            Position.Y += _standingCollider.BottomEdge - _crouchingCollider.BottomEdge;
        }
    }
}