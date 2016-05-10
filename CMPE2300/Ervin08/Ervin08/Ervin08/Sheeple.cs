using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;
namespace Ervin08
{
    class Sheeple
    {
        private static Random rng = new Random();
        public int _ItemsTotal { get; private set; }
        public int _ItemsCurrent { get; private set; }
        public int _Race { get; private set; }
        public bool Done { get { return _ItemsCurrent <= 0; } }
        public Sheeple()
        {
            _ItemsTotal = rng.Next(2, 6);
            _ItemsCurrent = _ItemsTotal;
            _Race = RandColor.GetColor().ToArgb();
        }
        public void CavitySearch() { _ItemsCurrent--; }
    }
}
