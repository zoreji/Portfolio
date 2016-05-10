using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDIDrawer;
using System.Drawing;

namespace Ervin12
{
    class GDI : CDrawer // the derived class base to access the another class
    {
        RandDrawer draw;
        private List<Rectangle> rect;
        public GDI(int width = 600, int height  = 300) : base(width, height)
        {
            draw = new RandDrawer(ScaledWidth / 5);
            rect = new List<Rectangle>();
            BBColour = Color.White;
            for (int i = 0; i < 20; i++)
                rect.Add(draw.NextDarwerRect(this));
        }
        //replace the old render function of the GDI Drawer
        new public void Render()
        {
            AddText(ScaledWidth.ToString() + " X " + ScaledHeight.ToString() + " : " + GetType().ToString(), 14, ScaledWidth / 100, ScaledHeight / 100, 300, 50, Color.Red);
            base.Render();
        }
        // replace the old clear function of the GDI drawer
        new public void Clear()
        {
            base.Clear();
            foreach(Rectangle temp in rect)
                AddRectangle(temp.X, temp.Y, temp.Width, temp.Height, Color.Transparent, 2, Color.Blue);
        }
    }
}
