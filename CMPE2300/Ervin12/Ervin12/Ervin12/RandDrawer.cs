using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDIDrawer;
using System.Drawing;

namespace Ervin12
{
    class RandDrawer : Random
    {
        private int Max;
        public RandDrawer(int Maximum)
        {
            Max = Maximum;
        }
        public Rectangle NextDarwerRect(CDrawer canvas)
        {
            int i = Next(10, Max);
            int u = Next(10, Max);
            int x = Next(0, canvas.ScaledWidth - i);
            int y = Next(0, canvas.ScaledHeight - u);

            Rectangle rect = new Rectangle(x, y, i, u);
            return rect;
        }
    }
}
