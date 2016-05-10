using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDIDrawer;
using System.Drawing;

namespace A04Ervin
{
    class Ball
    {
        static private CDrawer _Canvas;
        static private Random _Rng = new Random();
        private int _Radius;
        public int _SetRadius
        {
            set {_Radius = Math.Abs(value); }
        }
        private Color _Color;
        private Point _center;
        static Ball()
        {
            _Canvas = new CDrawer(_Rng.Next(600, 901), _Rng.Next(500, 801), false);
            //_Canvas.ContinuousUpdate = false;
        }
        public Ball(int radius)
        {
            _SetRadius = radius;

            _Color = RandColor.GetColor();
            _center.X = _Rng.Next(_Radius, _Canvas.ScaledWidth - _Radius);
            _center.Y = _Rng.Next(_Radius, _Canvas.ScaledHeight - _Radius);
        }
        public void Addball()
        {
            _Canvas.AddCenteredEllipse(_center.X, _center.Y, _Radius * 2, _Radius * 2, _Color);
        }
        static public bool Loading
        {
            set
            {
                if (value)
                    _Canvas.Clear();
                else
                    _Canvas.Render();
            }
        }
        public override bool Equals(object obj)
        {
            double distanceball;
            double distanceRadius;
            
            if (!(obj is Ball))
                return false;
            Ball temp = obj as Ball;
            distanceball = Math.Pow((this._center.X - temp._center.X), 2) + Math.Pow((this._center.Y - temp._center.Y), 2);
            distanceRadius = Math.Pow((this._Radius + temp._Radius),2);
            return (distanceball < distanceRadius) ;
        }
        public override int GetHashCode()
        {
            return 1;
        }
    }
}
