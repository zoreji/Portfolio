using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDIDrawer;
using System.Drawing;

namespace Ervin07
{
    class Block : IComparable
    {
        private static Random rng = new Random();
        private Color _color;
        public static CDrawer _Canvas{ get; private set; }
        public static int _Height{ get; private set; }
        public int _Width { get; private set; }
        public bool _HighLight { get; set; }

        static Block()
        {
            _Height = 20;
            _Canvas = new CDrawer();
            _Canvas.BBColour = Color.White;
            _Canvas.ContinuousUpdate = false;
        }
        public Block()
        {
            _Width = rng.Next(1, 20) * 10;
            _HighLight = false;
            _color = Color.FromArgb(rng.Next(2, 8) * 32, rng.Next(2, 8) * 16, rng.Next(2, 8) * 16);
        }
        public void ShowBlock(Point p)
        {
            if(_HighLight)
                _Canvas.AddRectangle(p.X, p.Y, _Width, _Height, _color, 2, Color.Yellow);
            else
                _Canvas.AddRectangle(p.X, p.Y, _Width, _Height, _color, 1, Color.Black);
        }
        public override bool Equals(object obj)
        {
            if (!(obj is Block))
                return false;
            Block temp = obj as Block;
            return ((this._Width == temp._Width) && (this._color == temp._color));
        }
        public override int GetHashCode()
        {
            return 1;
        }
        public int CompareTo(object obj)
        {
            if (!(obj is Block))
                return -1;
            Block temp = obj as Block;
            return this._color.ToArgb() - temp._color.ToArgb();
        }
        public static int CompareWidth(object left, object right)
        {
            if (!(left is Block))
                return -1;
            if (!(right is Block))
                return -1;
            Block templeft = left as Block;
            Block tempright = right as Block;
            return templeft._Width.CompareTo(tempright._Width);
        }
        public static int CompareDescWidth(Block left, Block right)
        {
            if (!(left is Block))
                return -1;
            if (!(right is Block))
                return -1;
            return right._Width.CompareTo(left._Width);
        }
        public static int CompareWidthColor(Block left, Block right)
        {
            if (!(left is Block))
                return -1;
            if (!(right is Block))
                return -1;
            if (left._Width == right._Width)
                return left._color.ToArgb() - right._color.ToArgb();
            else
                return left._Width - right._Width;
        }
        public static bool RemoveBright(Block bright)
        {
            if (!(bright is Block))
                return false;
            return (bright._color.GetBrightness() > 0.5);

        }
    }
}
