/******************************************************************************************************************
*       Author:       Ervin Hernandez
*       Class:        CMPE 2300
*       Programme:    Bouncing Ball
*       File:         Ball.cs
*       Assignment:   A02
*       Date:         2015/09/23
*******************************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDIDrawer;
using System.Drawing;
namespace ICA02_Ervin
{
    class Ball
    {
        static Random RNG = new Random();
        private Point _center;
        private int Xvel;
        private int Yvel;
        private Color Colorball;
        public const int BallRadius = 40;
        public Point Location
        {
            get
            {
                return _center;
            }
        }
        public int XSpeed
        {
            set
            {
                Xvel = value;
            }
        }
        public int YSpeed
        {
            set
            {
                if (Yvel > 10)
                    Yvel = 10;
                else if (Yvel < (-10))
                    Yvel = -10;
                else
                    Yvel = value;
            }
        }
        public int Opacity
        {
            private get;
            set;
        }
        public Ball (Point center)
        {
            Colorball = RandColor.GetColor();
            _center = center;
            XSpeed = RNG.Next(-10, 11);
            YSpeed = RNG.Next(-10, 11);
            Opacity = 128;
        }
        public void MoveBall(CDrawer canvas)
        {
            if (((_center.X + BallRadius) > canvas.m_ciWidth) || (_center.X - BallRadius) < 0) 
                Xvel = -Xvel;
            if (((_center.Y + BallRadius) > canvas.m_ciHeight) || (_center.Y - BallRadius)  < 0)
                Yvel = -Yvel;
            _center.X += Xvel;
            _center.Y += Yvel;
        }
        public void ShowBall(CDrawer canvas)
        {
            canvas.AddCenteredEllipse(_center.X, _center.Y, BallRadius*2, BallRadius*2, Color.FromArgb(Opacity, Colorball));
        }
        public override string ToString()
        {
            return string.Format("X = " + _center.X.ToString() + " Y = " + _center.Y.ToString() + " Opacity: " + Opacity.ToString());
        }
    }
}
