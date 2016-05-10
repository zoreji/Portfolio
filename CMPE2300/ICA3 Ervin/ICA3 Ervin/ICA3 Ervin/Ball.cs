using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDIDrawer;
using System.Drawing;

namespace ICA3_Ervin
{
    class Ball
    {
        static Random rng = new Random();
        static CDrawer Canvas;
        static public int ball_Radius;
        public static int Set_Radius
        {
            set
            {
                ball_Radius = Math.Abs(value);
            }
        }
        private Color ball_Color;
        private Point ball_Location;
        private int _iAlive;
        private int ball_Xvel;
        private int ball_Yvel;
        static Ball()
        {
            Canvas = new CDrawer(rng.Next(600, 901), rng.Next(500, 801), false);
            ball_Radius = rng.Next(10, 81);
        }
        public Ball()
        {
            ball_Color = RandColor.GetColor();
            ball_Xvel = rng.Next(-10, 11);
            ball_Yvel = rng.Next(-10, 11);
            ball_Location.X = rng.Next(ball_Radius, (Canvas.m_ciWidth - ball_Radius));
            ball_Location.Y = rng.Next(ball_Radius, (Canvas.m_ciHeight - ball_Radius));
        }
        public void ShowBall()
        {
            Canvas.AddCenteredEllipse(ball_Location.X, ball_Location.Y, ball_Radius * 2, ball_Radius * 2, Color.FromArgb(_iAlive,ball_Color));
        }
        public void MoveBall()
        {
            _iAlive--;
            if (_iAlive < 1)
            {
                ball_Location.X = rng.Next(ball_Radius, (Canvas.m_ciWidth-ball_Radius));
                ball_Location.Y = rng.Next(ball_Radius, (Canvas.m_ciHeight-ball_Radius));
                _iAlive = rng.Next(50, 128);
            }
            if (((ball_Location.X + ball_Radius) > Canvas.m_ciWidth))
            {
                ball_Location.X = Canvas.m_ciWidth - ball_Radius;
                ball_Xvel = -ball_Xvel;
            } 
            else if((ball_Location.X - ball_Radius) < 0)
            {
                ball_Location.X = ball_Radius;
                ball_Xvel = -ball_Xvel;
            }
            if (((ball_Location.Y + ball_Radius) > Canvas.m_ciHeight))
            {
                ball_Location.Y = Canvas.m_ciHeight - ball_Radius;
                ball_Yvel = -ball_Yvel;
            }
            else if ((ball_Location.Y - ball_Radius) < 0)
            {
                ball_Location.Y = ball_Radius;
                ball_Yvel = -ball_Yvel;
            }

            ball_Location.X += ball_Xvel;
            ball_Location.Y += ball_Yvel;
        }
        static public bool Loading
        {
            set
            {
                if (value)
                    Canvas.Clear();
                else
                    Canvas.Render();
            }
        }
    }
}
