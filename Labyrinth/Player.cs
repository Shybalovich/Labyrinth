using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Labyrinth
{
    class Player
    {
        public Bitmap pictures;
        public Bitmap picturesOriginal;
        public Rectangle rectangle;
        public Player(string filename, int x = 0, int y = 0, int width = 10, int height = 10)
        {
            picturesOriginal = new Bitmap(Image.FromFile(filename), width, height);
            rectangle.X = x;
            rectangle.Y = y;
            rectangle.Width = width;
            rectangle.Height = height;
            pictures = picturesOriginal.Clone() as Bitmap;
        }
        public void resize(float coefficient)
        {
            rectangle.X = Convert.ToInt32(rectangle.X * coefficient);
            rectangle.Y = Convert.ToInt32(rectangle.Y * coefficient);
            rectangle.Width = Convert.ToInt32(rectangle.Width * coefficient);
            rectangle.Height = Convert.ToInt32(rectangle.Height * coefficient);
        }
        // поворачиваем картинку в зависимости от направления движения
        public void setPictures(Direction direction)
        {
            pictures = picturesOriginal.Clone() as Bitmap;
            switch(direction)
            {
                case Direction.Left:
                    pictures.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    break;
                case Direction.Right:
                    pictures.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    break;
                case Direction.Down:
                    break;
                case Direction.Up:
                    pictures.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    break;
                default:
                    break;
            }
        }
    }
}
