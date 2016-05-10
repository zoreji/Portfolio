using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDIDrawer;
using System.Drawing;

namespace Ervin12
{
    class Img :CDrawer
    {
        public Img(Bitmap image) : base(image.Width, image.Height)
        {
            int gray;
            for (int y = 0; y < ScaledHeight; y++)
                for (int x = 0; x < ScaledWidth; x++)
                {
                    Color temp = image.GetPixel(x, y);
                    gray = (temp.R + temp.B + temp.G) / 3;

                    SetBBPixel(x, y, Color.FromArgb(gray, gray, gray));
                }
        }
        new public void Render()
        {
            AddText(ScaledWidth.ToString() + " X " + ScaledHeight.ToString() + " : " + GetType().ToString(), 14, ScaledWidth / 100, ScaledHeight / 100, 300, 50, Color.Red);
            base.Render();
        }
    }
}
