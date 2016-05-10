/**********************************************************************************
*       Author:       Ervin Hernandez
*       Class:        CMPE 2300
*       Programme:    Missle Command
*       File:         Missle.cs
*       Assignment:   Lab02
*       Date:         2015/11/16
**********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDIDrawer;
using System.Drawing;

namespace Missle_Command
{
    /// <summary>
    /// Class:      Missle
    /// Summary:    the Class code where it hold all the values
    ///             and the proprieties of the Missle Class
    ///             and is use by the Main Forum for the game
    ///             Missle Command
    /// </summary>
    class Missle
    {
        private static Random rng;
        private static CDrawer canvas;
        private static int explosion;
        private Point origin;
        private double angle;
        private double path;
        private double altitude;
        private int radius;
        public int alpha;
        private int speed;
        private bool foe;
        public static CDrawer Setcanvas
        {
            set { canvas = value; }
        }
        static int Setexplosion
        {
            set { explosion = value; }
        }
        static Missle()
        {
            rng = new Random();
            Setcanvas = null;
            Setexplosion = 50;
        }
        // foe missles
        /// <summary>
        /// Method:     Missle()
        /// Summary:    Contructor that create and set the values of the foe 
        ///             Missles and position them at the top of the canvas 
        /// </summary>
        public Missle()
        {
            origin = new Point(rng.Next(0, canvas.ScaledWidth), 0);
            angle = rng.NextDouble() * ((5 * Math.PI / 4) - (3 * Math.PI / 4)) + (3 * Math.PI / 4);
            path = 5;
            altitude = 0;
            speed = 5;
            alpha = 175;
            radius = 10;
            //Setexplosion = 80;
            foe = true;
        }
        //friendly missle
        /// <summary>
        /// Method:     Missle()
        /// Summary:    Contructor that create and set the values of the friendly
        ///             Missles and position them at the bottom center of the canvas 
        /// </summary>
        public Missle(Point p)
        {
            origin = new Point(canvas.ScaledWidth / 2, canvas.ScaledHeight);
            angle = Math.Atan(-1.0 * (p.X - origin.X) / (p.Y - origin.Y));
            altitude = p.Y;
            radius = 10;
            speed = 20;
            alpha = 175;
            foe = false;
        }
        public Point Where()
        {
            return new Point((int)(Math.Sin(angle) * path) + origin.X, (int)(-1.0 * Math.Cos(angle) * path) + origin.Y);
        }
        /// <summary>
        /// Method:     void Move()
        /// Summary:    check if the missle is a foe then check if the missle reach it destination 
        ///             if does the the method reduce the alpha value and increase the radius for the 
        ///             explosion. if not then just add move the missle
        /// </summary>
        public void Move()
        {
            if (foe)
            {
                if (Where().Y >= canvas.ScaledHeight)
                {
                    if (radius > explosion)
                        alpha -= 10;
                    else
                        radius += 20;
                }
                else
                    path += speed;
            }
            else if (altitude >= Where().Y )
            {
                if (radius > explosion)
                    alpha -= 10;
                else
                    radius += 5;
            }
            else
                path += speed;
        }
        /// <summary>
        /// Method:     void Render()
        /// Summary:    check if foe, if so, then render the missle red if the alpha is over 20
        ///             otherwise render the missle green for friendly
        /// </summary>
        public void Render()
        {
            //check if it a foe missle
            if(foe)
            {
                if (alpha >= 20)
                {
                    canvas.AddLine(origin, path, angle, Color.FromArgb(alpha, Color.Red));
                    canvas.AddCenteredEllipse(Where().X, Where().Y, radius * 2, radius * 2, Color.FromArgb(alpha, Color.Red));
                }
            }
            //otherwise its friendly
            else
            {
                canvas.AddLine(origin, path, angle, Color.FromArgb(alpha, Color.Green));
                canvas.AddCenteredEllipse(Where().X, Where().Y, radius * 2, radius * 2, Color.FromArgb(alpha, Color.Green));
            }
        }
        /// <summary>
        /// Method:     override bool Equals(object obj)
        /// Summary:    a compairson method that check if the foe missle collide with the friendly missle
        /// return:     return d <= (this.radius + temp.radius)
        /// </summary>
        public override bool Equals(object obj)
        {
            if (!(obj is Missle))
                return false;
            Missle temp = obj as Missle;
            double d = Math.Sqrt(Math.Pow((temp.Where().X - this.Where().X), 2) + Math.Pow((temp.Where().Y - this.Where().Y), 2));
            return d <= (this.radius + temp.radius);
        }
        public override int GetHashCode()
        {
            return 1;
        }
    }
}
