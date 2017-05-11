using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Labyrinth
{
    class Field
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int thicknessObstacles;              // толщина преграды
        public List<Rectangle> obstacles;           // препятствия
        public Size fielddCell;                     // количество ячеек по горизонтали и по верикали поля
        public int SizeCell { get; set; }           // размер одной ячейки
        public Point point;                         // координаты левого верхнего угла
    
        public Field(int x = 0, int y = 0, int sizeCell = 50, int t = 5, int col = 20, int row = 10)
        {
            point.X = x;
            point.Y = y;
            thicknessObstacles = t;
            SizeCell = sizeCell;
            fielddCell.Width = col;
            fielddCell.Height = row;
            Width = sizeCell * col + thicknessObstacles * (col + 1);
            Height = sizeCell * row + thicknessObstacles * (row + 1);
            obstacles = new List<Rectangle>();
            inicializeObstacles();
        }

        public Rectangle getStart()
        {
            return new Rectangle(point.X + thicknessObstacles, point.Y + thicknessObstacles, SizeCell - 5, SizeCell - 5);
        }

        public Rectangle getFinish()
        {
            return new Rectangle(point.X + (thicknessObstacles + SizeCell) * 19, point.Y + (thicknessObstacles + SizeCell) * 2, SizeCell, SizeCell);
        }

         public List<Rectangle> getRandomRectlist(int count)
        {
            Random rand = new Random();
            List<Rectangle> rect = new List<Rectangle>();
            Rectangle start = getStart();
            Rectangle finish = getFinish();
            for (int i = 0; i < count; ++i)
            {
                int col = rand.Next(0, fielddCell.Width);
                int row = rand.Next(0, fielddCell.Height);
                if(col == 0 && row == 0 || col == 19 && row == 2)
                {
                    continue;
                }
                else
                {
                    Rectangle tmp = new Rectangle(point.X + (thicknessObstacles + SizeCell) * col, point.Y + (thicknessObstacles + SizeCell) * row, SizeCell, SizeCell);
                    rect.Add(tmp);
                }
            }
            return rect;            
        }

        // заполнение листа преградами (пока не из файла)
        public void inicializeObstacles()
        {
            addObstacles();
        }

        private void addObstacles()
        {
            // Рамки
            obstacles.Add(new Rectangle(point.X, point.Y, Width, thicknessObstacles));
            obstacles.Add(new Rectangle(point.X, point.Y + Height - thicknessObstacles, Width, thicknessObstacles));
            obstacles.Add(new Rectangle(point.X, point.Y, thicknessObstacles, Height));
            obstacles.Add(new Rectangle(point.X + Width - thicknessObstacles, point.Y, thicknessObstacles, Height));
            
            // Горизонтальные препятствия
            obstacles.Add(new Rectangle(point.X + thicknessObstacles + SizeCell, point.Y + thicknessObstacles + SizeCell, thicknessObstacles * 2 + SizeCell, thicknessObstacles));
            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 4, point.Y + thicknessObstacles + SizeCell, thicknessObstacles * 3 + SizeCell * 2, thicknessObstacles));
            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 11, point.Y + thicknessObstacles + SizeCell, thicknessObstacles * 2 + SizeCell, thicknessObstacles));
            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 17, point.Y + thicknessObstacles + SizeCell, thicknessObstacles * 2 + SizeCell, thicknessObstacles));
            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 19, point.Y + thicknessObstacles + SizeCell, thicknessObstacles * 2 + SizeCell, thicknessObstacles));

            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 0, point.Y + (thicknessObstacles + SizeCell) * 2, thicknessObstacles * 2 + SizeCell, thicknessObstacles));
            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 3, point.Y + (thicknessObstacles + SizeCell) * 2, thicknessObstacles * 3 + SizeCell*2, thicknessObstacles));
            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 10, point.Y + (thicknessObstacles + SizeCell) * 2, thicknessObstacles * 4 + SizeCell * 3, thicknessObstacles));
            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 15, point.Y + (thicknessObstacles + SizeCell) * 2, thicknessObstacles * 3 + SizeCell * 2, thicknessObstacles));
            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 18, point.Y + (thicknessObstacles + SizeCell) * 2, thicknessObstacles * 2 + SizeCell, thicknessObstacles));

            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 2, point.Y + (thicknessObstacles + SizeCell) * 3, thicknessObstacles * 3 + SizeCell * 2, thicknessObstacles));
            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 5, point.Y + (thicknessObstacles + SizeCell) * 3, thicknessObstacles * 2 + SizeCell, thicknessObstacles));
            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 7, point.Y + (thicknessObstacles + SizeCell) * 3, thicknessObstacles * 2 + SizeCell, thicknessObstacles));
            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 13, point.Y + (thicknessObstacles + SizeCell) * 3, thicknessObstacles * 3 + SizeCell * 2, thicknessObstacles));
            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 18, point.Y + (thicknessObstacles + SizeCell) * 3, thicknessObstacles * 3 + SizeCell * 2, thicknessObstacles));

            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 1, point.Y + (thicknessObstacles + SizeCell) * 4, thicknessObstacles * 4 + SizeCell * 3, thicknessObstacles));
            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 6, point.Y + (thicknessObstacles + SizeCell) * 4, thicknessObstacles * 2 + SizeCell, thicknessObstacles));
            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 9, point.Y + (thicknessObstacles + SizeCell) * 4, thicknessObstacles * 5 + SizeCell * 4, thicknessObstacles));
            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 15, point.Y + (thicknessObstacles + SizeCell) * 4, thicknessObstacles * 4 + SizeCell * 3, thicknessObstacles));
            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 19, point.Y + (thicknessObstacles + SizeCell) * 4, thicknessObstacles * 2 + SizeCell, thicknessObstacles));

            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 0, point.Y + (thicknessObstacles + SizeCell) * 5, thicknessObstacles * 2 + SizeCell, thicknessObstacles));
            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 3, point.Y + (thicknessObstacles + SizeCell) * 5, thicknessObstacles * 4 + SizeCell * 3, thicknessObstacles));
            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 7, point.Y + (thicknessObstacles + SizeCell) * 5, thicknessObstacles * 3 + SizeCell * 2, thicknessObstacles));
            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 10, point.Y + (thicknessObstacles + SizeCell) * 5, thicknessObstacles * 2 + SizeCell, thicknessObstacles));
            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 13, point.Y + (thicknessObstacles + SizeCell) * 5, thicknessObstacles * 4 + SizeCell * 3, thicknessObstacles));
            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 18, point.Y + (thicknessObstacles + SizeCell) * 5, thicknessObstacles * 2 + SizeCell, thicknessObstacles));

            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 1, point.Y + (thicknessObstacles + SizeCell) * 6, thicknessObstacles * 3 + SizeCell * 2, thicknessObstacles));
            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 6, point.Y + (thicknessObstacles + SizeCell) * 6, thicknessObstacles * 2 + SizeCell, thicknessObstacles));
            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 9, point.Y + (thicknessObstacles + SizeCell) * 6, thicknessObstacles * 2 + SizeCell, thicknessObstacles));
            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 13, point.Y + (thicknessObstacles + SizeCell) * 6, thicknessObstacles * 2 + SizeCell, thicknessObstacles));
            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 16, point.Y + (thicknessObstacles + SizeCell) * 6, thicknessObstacles * 2 + SizeCell, thicknessObstacles));
            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 18, point.Y + (thicknessObstacles + SizeCell) * 6, thicknessObstacles * 3 + SizeCell * 2, thicknessObstacles));

            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 0, point.Y + (thicknessObstacles + SizeCell) * 7, thicknessObstacles * 3 + SizeCell * 2, thicknessObstacles));
            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 4, point.Y + (thicknessObstacles + SizeCell) * 7, thicknessObstacles * 6 + SizeCell * 5, thicknessObstacles));
            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 13, point.Y + (thicknessObstacles + SizeCell) * 7, thicknessObstacles * 2 + SizeCell, thicknessObstacles));
            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 15, point.Y + (thicknessObstacles + SizeCell) * 7, thicknessObstacles * 2 + SizeCell * 1, thicknessObstacles));
            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 17, point.Y + (thicknessObstacles + SizeCell) * 7, thicknessObstacles * 3 + SizeCell * 2, thicknessObstacles));

            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 1, point.Y + (thicknessObstacles + SizeCell) * 8, thicknessObstacles * 4 + SizeCell * 3, thicknessObstacles));
            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 5, point.Y + (thicknessObstacles + SizeCell) * 8, thicknessObstacles * 6 + SizeCell * 5, thicknessObstacles));
            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 12, point.Y + (thicknessObstacles + SizeCell) * 8, thicknessObstacles * 3 + SizeCell * 2, thicknessObstacles));
            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 15, point.Y + (thicknessObstacles + SizeCell) * 8, thicknessObstacles * 3 + SizeCell * 2, thicknessObstacles));

            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 5, point.Y + (thicknessObstacles + SizeCell) * 9, thicknessObstacles * 3 + SizeCell * 2, thicknessObstacles));
            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 8, point.Y + (thicknessObstacles + SizeCell) * 9, thicknessObstacles * 3 + SizeCell * 2, thicknessObstacles));
            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 16, point.Y + (thicknessObstacles + SizeCell) * 9, thicknessObstacles * 4 + SizeCell * 3, thicknessObstacles));

            // Вертикальные препятствия
            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 1, point.Y + (thicknessObstacles + SizeCell) * 2, thicknessObstacles, thicknessObstacles * 3 + SizeCell * 2));
            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 1, point.Y + (thicknessObstacles + SizeCell) * 5, thicknessObstacles, thicknessObstacles * 2 + SizeCell * 1));
            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 1, point.Y + (thicknessObstacles + SizeCell) * 8, thicknessObstacles, thicknessObstacles * 2 + SizeCell * 1));

            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 2, point.Y + (thicknessObstacles + SizeCell) * 1, thicknessObstacles, thicknessObstacles * 3 + SizeCell * 2));
            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 2, point.Y + (thicknessObstacles + SizeCell) * 4, thicknessObstacles, thicknessObstacles * 2 + SizeCell * 1));
            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 2, point.Y + (thicknessObstacles + SizeCell) * 9, thicknessObstacles, thicknessObstacles * 2 + SizeCell * 1));

            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 3, point.Y + (thicknessObstacles + SizeCell) * 0, thicknessObstacles, thicknessObstacles * 3 + SizeCell * 2));
            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 3, point.Y + (thicknessObstacles + SizeCell) * 6, thicknessObstacles, thicknessObstacles * 2 + SizeCell * 1));
            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 3, point.Y + (thicknessObstacles + SizeCell) * 8, thicknessObstacles, thicknessObstacles * 2 + SizeCell * 1));

            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 4, point.Y + (thicknessObstacles + SizeCell) * 3, thicknessObstacles, thicknessObstacles * 2 + SizeCell * 1));
            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 4, point.Y + (thicknessObstacles + SizeCell) * 5, thicknessObstacles, thicknessObstacles * 2 + SizeCell * 1));
            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 4, point.Y + (thicknessObstacles + SizeCell) * 7, thicknessObstacles, thicknessObstacles * 4 + SizeCell * 3));

            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 5, point.Y + (thicknessObstacles + SizeCell) * 3, thicknessObstacles, thicknessObstacles * 3 + SizeCell * 2));
            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 5, point.Y + (thicknessObstacles + SizeCell) * 6, thicknessObstacles, thicknessObstacles * 2 + SizeCell * 1));
            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 5, point.Y + (thicknessObstacles + SizeCell) * 8, thicknessObstacles, thicknessObstacles * 2 + SizeCell * 1));

            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 6, point.Y + (thicknessObstacles + SizeCell) * 1, thicknessObstacles, thicknessObstacles * 4 + SizeCell * 3));
            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 6, point.Y + (thicknessObstacles + SizeCell) * 5, thicknessObstacles, thicknessObstacles * 2 + SizeCell * 1));

            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 7, point.Y + (thicknessObstacles + SizeCell) * 0, thicknessObstacles, thicknessObstacles * 4 + SizeCell * 3));
            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 7, point.Y + (thicknessObstacles + SizeCell) * 5, thicknessObstacles, thicknessObstacles * 2 + SizeCell * 1));

            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 8, point.Y + (thicknessObstacles + SizeCell) * 1, thicknessObstacles, thicknessObstacles * 5 + SizeCell * 4));
            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 8, point.Y + (thicknessObstacles + SizeCell) * 6, thicknessObstacles, thicknessObstacles * 2 + SizeCell * 1));

            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 9, point.Y + (thicknessObstacles + SizeCell) * 1, thicknessObstacles, thicknessObstacles * 4 + SizeCell * 3));
            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 9, point.Y + (thicknessObstacles + SizeCell) * 5, thicknessObstacles, thicknessObstacles * 2 + SizeCell * 1));

            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 10, point.Y + (thicknessObstacles + SizeCell) * 1, thicknessObstacles, thicknessObstacles * 3 + SizeCell * 2));
            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 10, point.Y + (thicknessObstacles + SizeCell) * 6, thicknessObstacles, thicknessObstacles * 3 + SizeCell * 2));
            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 10, point.Y + (thicknessObstacles + SizeCell) * 9, thicknessObstacles, thicknessObstacles * 2 + SizeCell * 1));

            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 11, point.Y + (thicknessObstacles + SizeCell) * 0, thicknessObstacles, thicknessObstacles * 2 + SizeCell * 1));
            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 11, point.Y + (thicknessObstacles + SizeCell) * 3, thicknessObstacles, thicknessObstacles * 7 + SizeCell * 6));

            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 12, point.Y + (thicknessObstacles + SizeCell) * 2, thicknessObstacles, thicknessObstacles * 3 + SizeCell * 2));
            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 12, point.Y + (thicknessObstacles + SizeCell) * 5, thicknessObstacles, thicknessObstacles * 5 + SizeCell * 4));

            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 13, point.Y + (thicknessObstacles + SizeCell) * 0, thicknessObstacles, thicknessObstacles * 3 + SizeCell * 2));
            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 13, point.Y + (thicknessObstacles + SizeCell) * 5, thicknessObstacles, thicknessObstacles * 2 + SizeCell * 1));
            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 13, point.Y + (thicknessObstacles + SizeCell) * 9, thicknessObstacles, thicknessObstacles * 2 + SizeCell * 1));

            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 14, point.Y + (thicknessObstacles + SizeCell) * 0, thicknessObstacles, thicknessObstacles * 6 + SizeCell * 5));
            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 14, point.Y + (thicknessObstacles + SizeCell) * 7, thicknessObstacles, thicknessObstacles * 3 + SizeCell * 2));

            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 15, point.Y + (thicknessObstacles + SizeCell) * 1, thicknessObstacles, thicknessObstacles * 2 + SizeCell * 1));
            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 15, point.Y + (thicknessObstacles + SizeCell) * 6, thicknessObstacles, thicknessObstacles * 2 + SizeCell * 1));
            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 15, point.Y + (thicknessObstacles + SizeCell) * 8, thicknessObstacles, thicknessObstacles * 3 + SizeCell * 2));

            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 16, point.Y + (thicknessObstacles + SizeCell) * 0, thicknessObstacles, thicknessObstacles * 2 + SizeCell * 1));
            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 16, point.Y + (thicknessObstacles + SizeCell) * 2, thicknessObstacles, thicknessObstacles * 2 + SizeCell * 1));
            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 16, point.Y + (thicknessObstacles + SizeCell) * 5, thicknessObstacles, thicknessObstacles * 2 + SizeCell * 1));
            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 16, point.Y + (thicknessObstacles + SizeCell) * 7, thicknessObstacles, thicknessObstacles * 2 + SizeCell * 1));

            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 17, point.Y + (thicknessObstacles + SizeCell) * 1, thicknessObstacles, thicknessObstacles * 2 + SizeCell * 1));
            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 17, point.Y + (thicknessObstacles + SizeCell) * 3, thicknessObstacles, thicknessObstacles * 5 + SizeCell * 4));

            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 18, point.Y + (thicknessObstacles + SizeCell) * 1, thicknessObstacles, thicknessObstacles * 3 + SizeCell * 2));
            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 18, point.Y + (thicknessObstacles + SizeCell) * 5, thicknessObstacles, thicknessObstacles * 2 + SizeCell * 1));
            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 18, point.Y + (thicknessObstacles + SizeCell) * 8, thicknessObstacles, thicknessObstacles * 2 + SizeCell * 1));

            obstacles.Add(new Rectangle(point.X + (thicknessObstacles + SizeCell) * 19, point.Y + (thicknessObstacles + SizeCell) * 7, thicknessObstacles, thicknessObstacles * 3 + SizeCell * 2));
        }
    }
}
