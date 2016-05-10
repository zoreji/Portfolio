using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDIDrawer;
using System.Drawing;

namespace Ervin13
{
    class Light
    {
        protected Point _center;
        private bool KillMe;
        protected Color _color;
        public bool SetKillMe { get { return KillMe; } protected set { KillMe = value; } }
        public Light(Point center)
        {
            _center = center;
            _color = RandColor.GetColor();
            SetKillMe = false;
        }
        virtual public void Animate()
        {

        }
        virtual public void Draw(CDrawer obj)
        {
            obj.AddCenteredEllipse(_center.X, _center.Y, 4 * 2, 4 * 2, Color.Red);
        }
    }
    class FadeLight : Light
    {
        int _opacity = 255;
        public FadeLight(Point cen) : base(cen)
        {

        }
        public override void Animate()
        {
            if (_opacity < 10)
                SetKillMe = true;
            else
                _opacity -= 10;
        }
        public override void Draw(CDrawer obj)
        {
            obj.AddCenteredEllipse(_center.X, _center.Y, 30 * 2, 30 * 2, Color.FromArgb(_opacity, _color));
            base.Draw(obj);
        }
    }
    class ShrinkLight : Light
    {
        double _radius = 40;
        public ShrinkLight(Point p) : base(p)
        {

        }
        public override void Animate()
        {
            if (_radius < 2)
                SetKillMe = true;
            else
                _radius -= 2;
        }
        public override void Draw(CDrawer obj)
        {
            obj.AddPolygon(_center.X - (int)_radius, _center.Y - (int)_radius, (int)_radius, 8, Math.PI / 8, _color);
            base.Draw(obj);
        }
    }
    class SpinLight : Light
    {
        double spin = 2 * Math.PI;
        public SpinLight(Point p) : base(p)
        {

        }
        public override void Animate()
        {
            if (spin < 0.1)
                SetKillMe = true;
            else
                spin -= 0.1;
        }
        public override void Draw(CDrawer obj)
        {
            obj.AddPolygon(_center.X - 40, _center.Y - 40, 40, 3, spin, _color);
            base.Draw(obj);
        }

    }
}
