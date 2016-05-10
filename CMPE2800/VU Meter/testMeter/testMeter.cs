using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace testMeter
{
    public partial class testMeter: UserControl
    {
        float _minLvl = -60;
        [Browsable(true), Description("Minimum Level"), Category("Meter Level")]
        public float minLvl
        {
            get { return _minLvl; }
            set { _minLvl = value < _maxLvl ? value : _maxLvl; Invalidate(); }
        }
        float _maxLvl = 1;
        [Browsable(true), Description("Maximum Level"), Category("Meter Level")]
        public float maxLvl
        {
            get { return _maxLvl; }
            set { _maxLvl = value > _minLvl ? value : _minLvl; Invalidate(); }
        }
        PointF _value = new PointF();
        [Browsable(true), Description("Value..."), Category("Meter Level")]
        public PointF Value
        {
            get { return _value; }
            set { _value = value; Invalidate(); }
        }
        float _alert_Lvl = 0;
        [Browsable(true), Description("(╯°□°）╯︵ ┻━┻"), Category("Meter Level")]
        public float alert_Lvl
        {
            get { return _alert_Lvl; }
            set { _alert_Lvl = value; Invalidate(); }
        }
        int Meter_type = 0;
        [Browsable(true), Description("The Meter Type"), Category("Meter Type")]

        float right_degrees = 0;
        [Browsable(true), Description("Degrees of the line arc of right"), Category("Meter")]
        public float rg_degrees
        {
            get { return right_degrees; }
            set { right_degrees = value + 30; Invalidate(); }
        }
        float left_degrees = 0;
        [Browsable(true), Description("Degrees of the line arc of left"), Category("Meter")]
        public float lf_degrees
        {
            get { return left_degrees; }
            set { left_degrees = value + 30; Invalidate(); }
        }
        float _dB = 0;
        [Browsable(true), Description("Values of the dB in float"), Category("Meter")]
        public float dB
        {
            get { return _dB; }
            set { _dB = value; Invalidate(); }
        }
        public testMeter()
        {
            InitializeComponent();
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //base.OnPaintBackground(e);

        }

        private void transferFunction()
        {
            lf_degrees = Value.Y;
            right_degrees = Value.X;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            
            using (BufferedGraphicsContext bgc = new BufferedGraphicsContext())
            {
                using (BufferedGraphics bg = bgc.Allocate(CreateGraphics(), ClientRectangle))
                {
                    gr = bg.Graphics;
                    Meter(gr);
                    gr.DrawPath(Pens.Yellow, moveright());
                    gr.FillPath(new SolidBrush(Color.Yellow), moveright());
                    gr.DrawPath(Pens.Yellow, moveleft());
                    gr.FillPath(new SolidBrush(Color.Yellow), moveleft());
                    bg.Render();
                }
            }
        }
        private GraphicsPath moveright()
        {
            GraphicsPath gp = (GraphicsPath)line().Clone();
            Matrix mat = new Matrix();
            mat.Translate(170, 200);
            mat.RotateAt((float)right_degrees, new PointF(0, 0));
            gp.Transform(mat);
            //Pen p = new Pen(Color.Yellow);
            return gp;
            
        }
        private GraphicsPath moveleft()
        {
            GraphicsPath gp = (GraphicsPath)line().Clone();
            Matrix mat = new Matrix();
            mat.Translate(570, 200);
            mat.RotateAt((float)left_degrees, new PointF(0, 0));
            gp.Transform(mat);
            //Pen p = new Pen(Color.Yellow);
            return gp;
        }
        private void Meter(Graphics gr)
        {
            if (gr == null)
                gr = CreateGraphics();
            gr.Clear(Color.Black);
            gr.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            if (right_degrees > 120)
                gr.DrawArc(new Pen(Color.Red, 3), 20, 50, 300, 300, 210, 110);
            else
                gr.DrawArc(new Pen(Color.DarkRed, 3), 20, 50, 300, 300, 210, 110);
            if (left_degrees > 120) 
                gr.DrawArc(new Pen(Color.Red, 3), 420, 50, 300, 300, 210, 110);
            else
                gr.DrawArc(new Pen(Color.DarkRed, 3), 420, 50, 300, 300, 210, 110);
            gr.DrawArc(new Pen(Color.Blue, 3), 20, 50, 300, 300, 210, 90);
            gr.DrawArc(new Pen(Color.Blue, 3), 420, 50, 300, 300, 210, 90);
        }
        private GraphicsPath line()
        {
            GraphicsPath gc = new GraphicsPath();
            PointF p = new PointF(-100, 0);
            PointF testp = new PointF(-175, 0);
            gc.AddLine(p, testp);
            return gc;
        }
        private void math()
        {

        }
    }
}
