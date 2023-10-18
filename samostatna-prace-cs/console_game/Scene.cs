using System.Text;

namespace console_game
{
    public class Scene
    {
        private string[,] _scene;
        private int _width, _height;

        public Scene(int width, int height)
        {
            _width = width;
            _height = height;
            _scene = new string[height, width];
        }
        private void Clear()
        {
            for (int i = 0; i < _height; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    _scene[i, j] = "  ";
                }
            }
            Console.Clear();
        }
        public void Draw(params IDrawable[] drawables)
        {
            Clear();
            for (int i = 0; i < drawables.Length; i++)
            {
                drawables[i].Draw(_scene);
            }
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < _height; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    stringBuilder.Append(_scene[i, j]);
                }
                stringBuilder.Append("\n");
            }
            Console.Write(stringBuilder.ToString());
        }
    }
}