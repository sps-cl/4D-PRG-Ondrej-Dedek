namespace console_game
{
    public interface IMoveable
    {
        public Vector Position { get; set; }
        public Vector Speed { get; set; }
        public void Move();
    }
}