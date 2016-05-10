using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;
using ErvinDrawer;

namespace Ervin14
{
    public abstract class CShape
    {
        public static Img canvas { get; set; }
        protected static Random rng = new Random();
        protected Point _pLocation;
        protected Color _color = RandColor.GetColor();
        protected int _iRadius;
        static CShape()
        {
            rng = new Random(0);
        }
        public CShape(Point p)
        {
            _pLocation = p;
            _iRadius = rng.Next(25, 51);
        }
        public void Render()
        {
            string text = _pLocation.X.ToString() + ", " + _pLocation.Y.ToString();
            VirtualRender();
            canvas.AddText(text, 5, _pLocation.X -(_iRadius/2), _pLocation.Y, _iRadius, 8, Color.Black);
        }
        protected abstract void VirtualRender();
    } 
    interface IMoveable
    {
        void Move();
    }
    interface IAnimate
    {
        void Animate();
    }
    class MovingBall : CShape, IMoveable 
    {
        //private Point _pLocation;
        private int Xvel;
        private int Yvel;
        //private Color Colorball;
        //public const int BallRadius = 40;
        public Point Location
        {
            get
            {
                return _pLocation;
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
        public MovingBall(Point p):base(p)
        {
            //Colorball = RandColor.GetColor();
            _pLocation = p;
            XSpeed = rng.Next(-8, 9);
            YSpeed = rng.Next(-8, 9);
            Opacity = 128;
        }
        public void Move()
        {
            if (((_pLocation.X + _iRadius) > canvas.m_ciWidth) || (_pLocation.X - _iRadius) < 0)
                Xvel = -Xvel;
            if (((_pLocation.Y + _iRadius) > canvas.m_ciHeight) || (_pLocation.Y - _iRadius) < 0)
                Yvel = -Yvel;
            _pLocation.X += Xvel;
            _pLocation.Y += Yvel;
        }
        protected override void VirtualRender()
        {
            canvas.AddCenteredEllipse(_pLocation.X, _pLocation.Y, _iRadius * 2, _iRadius * 2, _color);
            //base.Render();
        }
    }
    class SpinnerBall : CShape, IAnimate
    {
        private double angle;
        private double deltaAngle;
        private Point center;
        //public const int BallRadius = 40;
        //private Color Colorball;
        public SpinnerBall(Point p) : base(p)
        {
            center = p;
            deltaAngle = rng.NextDouble() * 0.2;
            //Colorball = RandColor.GetColor();
        }
        public void Animate()
        {
            angle += deltaAngle;
        }
        protected override void VirtualRender()
        {
            canvas.AddCenteredEllipse(_pLocation.X, _pLocation.Y, _iRadius * 2, _iRadius * 2, _color,2,Color.White);
            canvas.AddLine(center, _iRadius, angle, Color.White);
            //base.Render();
        }

    }
    class PentaBall : CShape, IMoveable, IAnimate
    {
        private double angle;
        private double deltaAngle;
        //private Point _pLocation;
        private int Xvel;
        private int Yvel;
        //private Color Colorball;
        public const int BallRadius = 40;
        public Point Location
        {
            get
            {
                return _pLocation;
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
        public PentaBall(Point p) : base(p)
        {
            //Colorball = RandColor.GetColor();
            _pLocation = p;
            XSpeed = rng.Next(-8, 9);
            YSpeed = rng.Next(-8, 9);
            deltaAngle = rng.NextDouble() * 0.2;
            Opacity = 128;
        }
        public void Move()
        {
            if (((_pLocation.X + _iRadius) > canvas.m_ciWidth) || (_pLocation.X - _iRadius) < 0)
                Xvel = -Xvel;
            if (((_pLocation.Y + _iRadius) > canvas.m_ciHeight) || (_pLocation.Y - _iRadius) < 0)
                Yvel = -Yvel;
            _pLocation.X += Xvel;
            _pLocation.Y += Yvel;
        }
        public void Animate()
        {
            angle += deltaAngle;
        }
        protected override void VirtualRender()
        {
            canvas.AddPolygon(_pLocation.X - BallRadius, _pLocation.Y - BallRadius, BallRadius, 5,angle, _color,2,Color.White);
            canvas.AddLine(_pLocation, BallRadius-6, -angle, Color.White);
            //base.Render();
        }
    }
}
