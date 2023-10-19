using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace console_game
{
    public class TextBox : IDrawable
    {
        public Vector Position { get; set; }
        public Image Image { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int InnerWidth { get => Width - 2; set => Width = value + 2; }
        public int InnerHeight { get => Height - 2; set => Height = value + 2; }
        public TextBox(Vector position, int width, int height)
        {
            Position = position;
            Width = width;
            Height = height;

            UpdateText("");
        }
        public void Draw(string[,] scene)
        {
            Image.Draw(scene);
        }
        public void UpdateText(string text)
        {
            string[,] img = new string[Height, Width];
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    if (i == 0 || j == 0 || i == Width - 1 || j == Height - 1) img[j, i] = "# ";
                    else img[j, i] = "  ";
                }
            }
            for (int i = 0; i < InnerWidth * InnerHeight && i < text.Length; i++)
            {
                img[i / InnerWidth + 1, i % InnerWidth + 1] = text[i].ToString() + " ";
            }
            Image = new Image(img, Position);
        }
    }
}