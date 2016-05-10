using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDIDrawer;
using System.Drawing;
namespace Ervin11
{
    class GDI : CDrawer
    {
        Drawer draw;
        //static private CDrawer Canvas;
        public GDI() : base(800, 400)
        {
            draw = new Drawer(ScaledWidth / 5);
            BBColour = Color.White;

            for (int i = 0; i < 100; i++)
            {
                Rectangle temp = draw.NextDarwerRect(this);
                AddRectangle(temp.X, temp.Y, temp.Width, temp.Height, RandColor.GetKnownColor());
            }
        }
    }
}
