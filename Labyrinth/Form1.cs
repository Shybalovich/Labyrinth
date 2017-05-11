using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labyrinth
{
    public partial class Form1 : Form
    {
        private Player player;                                      // игрок
        private Field field;                                        // игровое поле
        private Bitmap finish;                                      // значек конца игры
        private Dictionary<Rectangle, bool> badges;                 // собираемые значки
        private Bitmap picturesBadges;                              // значек собираемых элементов
        public int count;                                           // количество ненайденых значков
        bool thereIsGame;                                           // игра запущена

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            thereIsGame = false;
            int x0 = 400;
            int y0 = 200;
            field = new Field(x0, y0);
            Rectangle end = field.getFinish();
            Rectangle start = field.getStart();
            finish = new Bitmap(Image.FromFile(@"../../Finish.png"), end.Width, end.Height);
            picturesBadges = new Bitmap(Image.FromFile(@"../../Candies.png"), end.Width, end.Height);
            finish.Tag = end;
            player = new Player(@"../../Smiley.png", start.X, start.Y, start.Width, start.Height);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if(thereIsGame)
            {
                Brush brush = new SolidBrush(Color.Black);
                // прорисовка поля
                foreach (var it in field.obstacles)
                {
                    e.Graphics.FillRectangle(brush, it);
                }
                e.Graphics.DrawImage(player.pictures, player.rectangle);
                if (count != 0)
                {
                    foreach(var it in badges)
                    {
                        if(it.Value == true)
                        {
                            e.Graphics.DrawImage(picturesBadges, it.Key);
                        }
                    }
                }
                else
                {
                    e.Graphics.DrawImage(finish, (Rectangle)finish.Tag);
                }
            }
            else
            {
                e.Graphics.Clear(Color.WhiteSmoke);
            }
            

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                int step = 5;
                Point resizablePoint = new Point(0, step);
                Direction direction = Direction.Down;
                if (e.KeyCode == Keys.Up)
                {
                    direction = Direction.Up;
                    resizablePoint.Y = -step;
                }                
                else if (e.KeyCode == Keys.Left)
                {
                    direction = Direction.Left;
                    resizablePoint.X = -step;                    
                    resizablePoint.Y = 0;
                }
                else if (e.KeyCode == Keys.Right)
                {
                    direction = Direction.Right;
                    resizablePoint.X = step;                    
                    resizablePoint.Y = 0;
                }                
                player.setPictures(direction);
                Rectangle newRect = Rectangle.Inflate(player.rectangle, 0, 0);
                newRect.Offset(resizablePoint);
                bool overlapping = false;                                       // попадаем ли на преграду
                foreach (Rectangle it in field.obstacles)
                {
                    if (newRect.IntersectsWith(it))
                    {
                        overlapping = true;
                        break;
                    }
                }                
                if (!overlapping)
                {
                    player.rectangle = newRect;
                    if (count == 0 && player.rectangle.IntersectsWith((Rectangle)finish.Tag))
                    {
                        thereIsGame = false;
                        MessageBox.Show("Поздравляем!!!! Вы прошли лабиринт!!!");
                    }
                    else
                    {
                        Rectangle tmp = new Rectangle();
                        foreach (var it in badges)
                        {
                            if (player.rectangle.IntersectsWith(it.Key))
                            {
                                tmp = it.Key;
                            }
                        }
                        if (badges.ContainsKey(tmp))
                        {
                            badges[tmp] = false;
                            --count;
                        }
                    }
                    
                }                
                this.Invalidate();
            }
            
        }
    
        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Помогите смайлику\nпройти лабиринт");
        }

        private void butt_end_Click(object sender, EventArgs e)
        {
            thereIsGame = false;
            this.Invalidate();
        }

        private void butt_begin_Click(object sender, EventArgs e)
        {
            player.rectangle = field.getStart();
            List<Rectangle> rect = field.getRandomRectlist(5);
            badges = new Dictionary<Rectangle, bool>();
            foreach(var it in rect)
            {
                badges.Add(it, true);
            }
            count = badges.Count;
            thereIsGame = true;
            this.Invalidate();
        }
    }
}
