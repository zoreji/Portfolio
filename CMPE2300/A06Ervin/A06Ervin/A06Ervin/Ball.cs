using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;
namespace A06Ervin
{
    class Ball
    {
        static private Random rng = new Random();
        private int _ballradius;
        private int _xvel;
        private int _yvel;
        private Point _centerball;
        public Color _ballcolor
        {
            get; set;
        }
        public int _setXvel
        {
            set
            {
                _xvel = value;
            }
        }
        public int _setYvel
        {
            set
            {
                _yvel = value;
            }
        }
        public int _setradius
        {
            set
            {
                _ballradius = value;
            }
        }
        public Ball(Point center, Color color)
        {
            _centerball = center;
            _ballcolor = color;
            _setradius = rng.Next(20, 51);
            _setXvel = rng.Next(-5, 6);
            _setYvel = rng.Next(-5, 6);
        }
        public void MoveBall(CDrawer Canvas)
        {
            if (((_centerball.X + _ballradius) > Canvas.m_ciWidth))
            {
                _centerball.X = Canvas.m_ciWidth - _ballradius;
                _xvel = -_xvel;
            }
            else if ((_centerball.X - _ballradius) < 0)
            {
                _centerball.X = _ballradius;
                _xvel = -_xvel;
            }
            if (((_centerball.Y + _ballradius) > Canvas.m_ciHeight))
            {
                _centerball.Y = Canvas.m_ciHeight - _ballradius;
                _yvel = -_yvel;
            }
            else if ((_centerball.Y - _ballradius) < 0)
            {
                _centerball.Y = _ballradius;
                _yvel = -_yvel;
            }

            _centerball.X += _xvel;
            _centerball.Y += _yvel;
        }
        public void ShowBall(CDrawer Canvas, int Index)
        {
            Canvas.AddCenteredEllipse(_centerball.X, _centerball.Y, _ballradius * 2, _ballradius * 2, _ballcolor);
            Canvas.AddText(Index.ToString(), 14, _centerball.X - _ballradius, _centerball.Y - _ballradius, _ballradius * 2, _ballradius * 2,Color.FromArgb(_ballcolor.ToArgb()^ 0x00FFFFFF));
        }
        public override bool Equals(object obj)
        {
            if (!(obj is Ball))
                return false;
            Ball ballTemp = obj as Ball;
            double distance = Math.Sqrt(Math.Pow((ballTemp._centerball.X - _centerball.X), 2) + Math.Pow((ballTemp._centerball.Y - _centerball.Y), 2));
            if (distance <= (_ballradius + ballTemp._ballradius))
                return distance <= (_ballradius + ballTemp._ballradius);
            else
                return false;

        }
        public override int GetHashCode()
        {
            return 1;
        }
    }
}
