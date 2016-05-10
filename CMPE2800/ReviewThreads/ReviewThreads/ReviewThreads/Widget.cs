using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;

namespace ReviewThreads
{
	public abstract class Widget
	{
		public Color _color { get; } = RandColor.GetColor();
		public Point _pt { get; }
		static Random _rnd = new Random();
		public Widget(CDrawer can)
		{
			_pt = new Point(_rnd.Next(can.ScaledWidth), _rnd.Next(can.ScaledHeight));
		}
		protected abstract void Render(CDrawer can);
		public void SuperRender(CDrawer can)
		{
			Render(can);
		}
	}
	public class RoundWidget : Widget
	{
		public RoundWidget(CDrawer can) : base(can) { }
		protected override void Render(CDrawer can)
		{
			can.AddCenteredEllipse(_pt.X, _pt.Y, 20, 20, _color);
		}
	}
	public class SquareWidget : Widget
	{
		public SquareWidget(CDrawer can) : base(can) { }
		protected override void Render(CDrawer can)
		{
			can.AddCenteredRectangle(_pt.X, _pt.Y, 20, 20, _color);
		}
	}

}
