using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDIDrawer;
using System.Drawing;

namespace Ervin11
{
    class Img : CDrawer
    {
        public Img() : base(Properties.Resources.doge.Width,Properties.Resources.doge.Height)
        {
            int gray;
            Bitmap i = new Bitmap(Properties.Resources.doge);
            for (int y = 0; y < ScaledHeight; y++)
                for (int x = 0; x < ScaledWidth; x++)
                {
                    Color temp = i.GetPixel(x, y);
                    gray = (temp.R + temp.B + temp.G) / 3;

                    SetBBPixel(x, y, Color.FromArgb(gray, gray, gray));
                }
        }
    }
}
