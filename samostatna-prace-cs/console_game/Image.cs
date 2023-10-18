namespace console_game
{
    public class Image : IDrawable
    {
        private string[,] _image { get; set; }
        private Vector _position { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }

        public Image(string[,] image, Vector position)
        {
            _image = image;
            _position = position;
            Height = image.GetLength(0);
            Width = image.GetLength(1);
        }
        public void Draw(string[,] scene)
        {
            int sceneHeight = scene.GetLength(0);
            int sceneWidth = scene.GetLength(1);

            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    int X = (int)(_position.X + i);
                    int Y = (int)(_position.Y + j);

                    if (X < 0 || X >= sceneWidth ||
                        Y < 0 || Y >= sceneHeight) continue;

                    scene[Y, X] = _image[j, i];
                }
            }
        }
    }
}