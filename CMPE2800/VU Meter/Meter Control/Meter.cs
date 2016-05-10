/*****************************************************
*   Program:        Meter.cs
*   Description:    A user Control that measure values and
                    translate it to a graphical meter
                    and displaying the values
*   Author:         Ervin Hernandez
*   Class:          CMPE2800
*   Date:           2016/04/22
******************************************************/
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

namespace Meter_Control
{
    public partial class Meter: UserControl
    {
        double rightd;
        double leftd;
        List<float> left;
        List<float> right;
        int Limit = 8;
        float _minLvl = 0;
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
            set { _value = value; enque(_value); Invalidate(); }
        }
        double _alert_Lvl = 0.89;
        [Browsable(true), Description("(╯°□°）╯︵ ┻━┻"), Category("Meter Level")]
        public double alert_Lvl
        {
            get { return _alert_Lvl; }
            set { _alert_Lvl = value; Invalidate(); }
        }
        public enum Meter_type { Peak = 1, Fast, Medium, Slow }
        Meter_type _speed = Meter_type.Medium;
        [Browsable(true), Description("The Meter Type"), Category("Meter Type")]
        public Meter_type Speed
        {
            get { return _speed; }
            set { _speed = value; setLimit(value); Invalidate(); }
        }

        float right_degrees = 1;
        [Browsable(true), Description("Degrees of the line arc of right"), Category("Meter")]
        public float rg_degrees
        {
            get { return right_degrees; }
            set { right_degrees = value; Invalidate(); }
        }
        float left_degrees = 1;
        [Browsable(true), Description("Degrees of the line arc of left"), Category("Meter")]
        public float lf_degrees
        {
            get { return left_degrees; }
            set { left_degrees = value; Invalidate(); }
        }
        float _dB = 0;
        [Browsable(true), Description("Values of the dB in float"), Category("Meter")]
        public float dB
        {
            get { return _dB; }
            set { _dB = value; Invalidate(); }
        }
        float left_avgLvl = 0;
        [Browsable(true), Description("The average left values of the raw data"), Category("Meter")]
        public float LeftavgLvl
        {
            get { return left_avgLvl; }
            set { left_avgLvl = value; Invalidate(); }
        }
        float right_avgLvl = 0;
        [Browsable(true), Description("The average right values of the raw data"), Category("Meter")]
        public float RightavgLvl
        {
            get { return right_avgLvl; }
            set { right_avgLvl = value; Invalidate(); }
        }
        public event EventHandler onAlarm = null;
        public delegate void delVoidInt(int value);

        Font f = null;

        public Meter()
        {
            InitializeComponent();
            f = new Font("Comic Sans", 14);
            left = new List<float>();
            right = new List<float>();
        }
        private void checkalert(PointF value)
        {
            if (value.X > _alert_Lvl || value.Y > _alert_Lvl)
                onAlarm?.Invoke(this, new EventArgs());

        }
        private void transferFunction()
        {
            leftd = (20 * Math.Log10((double)left_avgLvl));
            rightd = (20 * Math.Log10((double)right_avgLvl));
            checkalert(_value);
            if (_speed == Meter_type.Peak)
            {
                left_degrees = (float)(120 * _value.X + 20);
                right_degrees = (float)(120 * _value.Y + 20);
            }
            else
            {
                left_degrees = (float)(120 * left_avgLvl + 20);
                right_degrees = (float)(120 * right_avgLvl + 20);
            }
        }
        private void setLimit(Meter_type type)
        {
            switch (type)
            {
                case Meter_type.Peak:
                    Limit = 1;
                    break;
                case Meter_type.Fast:
                    Limit = 3;
                    break;
                case Meter_type.Medium:
                    Limit = 8;
                    break;
                case Meter_type.Slow:
                    Limit = 12;
                    break;
            }
        }
        private void enque(PointF value)
        {
            //Avg.Enqueue(value);
            left.Add(value.X);
            right.Add(value.Y);
        }
        private void sampleAverage()
        {
            float leftsum = 0;
            float rightsum = 0;
            if (left.Count < Limit || right.Count < Limit)
                return;
            foreach (var x in left)
                leftsum += x;
            foreach (var y in right)
                rightsum += y;
            left_avgLvl = leftsum / Limit;
            right_avgLvl = rightsum / Limit;
            transferFunction();
            left.RemoveAt(0);
            right.RemoveAt(0);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            graphicBuffer(gr);
            
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            graphicBuffer(gr);
        }
        private void graphicBuffer(Graphics gr)
        {
            using (BufferedGraphicsContext bgc = new BufferedGraphicsContext())
            {
                using (BufferedGraphics bg = bgc.Allocate(CreateGraphics(), ClientRectangle))
                {
                    gr = bg.Graphics;
                    //setLimit(_speed);
                    sampleAverage();
                    drawMeter(gr);
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
            mat.Translate(470, 200);
            mat.RotateAt((float)left_degrees, new PointF(0, 0));
            gp.Transform(mat);
            //Pen p = new Pen(Color.Yellow);
            return gp;
        }
        private void drawMeter(Graphics gr)
        {
            if (gr == null)
                gr = CreateGraphics();
            gr.Clear(Color.Black);
            gr.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            if (right_degrees > 110)
                gr.DrawArc(new Pen(Color.Red, 3), 20, 50, 300, 300, 200, 120);
            else
                gr.DrawArc(new Pen(Color.DarkRed, 3), 20, 50, 300, 300, 200, 120);
            if (left_degrees > 110)
                gr.DrawArc(new Pen(Color.Red, 3), 320, 50, 300, 300, 200, 120);
            else
                gr.DrawArc(new Pen(Color.DarkRed, 3), 320, 50, 300, 300, 200, 120);
            gr.DrawArc(new Pen(Color.Blue, 3), 20, 50, 300, 300, 200, 90);
            gr.DrawArc(new Pen(Color.Blue, 3), 320, 50, 300, 300, 200, 90);

            drawStatus(10, gr);
            drawStatus(310, gr);
        }
        private GraphicsPath line()
        {
            GraphicsPath gc = new GraphicsPath();
            PointF p = new PointF(-100, 0);
            PointF testp = new PointF(-175, 0);
            gc.AddLine(p, testp);
            return gc;
        }
        private void drawStatus(float x, Graphics gr)
        {
            PointF pf = new PointF(x, 210);
            gr.DrawString("Max:     " + _maxLvl.ToString(), f, new SolidBrush(Color.White), pf);
            pf = new PointF(x, 230);
            gr.DrawString("Min:     " + _minLvl.ToString(), f, new SolidBrush(Color.White), pf);
            pf = new PointF(x, 250);
            gr.DrawString("Alert:   " + _alert_Lvl.ToString("F2"), f, new SolidBrush(Color.White), pf);
            pf = new PointF(x, 270);
            gr.DrawString("Value-right:   " + _value.Y.ToString(), f, new SolidBrush(Color.White), pf);
            pf = new PointF(x, 290);
            gr.DrawString("Value-left:   " + _value.X.ToString(), f, new SolidBrush(Color.White), pf);
            pf = new PointF(x, 310);
            gr.DrawString("Left:   " + rightd.ToString("F1")+"dB", f, new SolidBrush(Color.White), pf);
            pf = new PointF(x, 330);
            gr.DrawString("Right:   " + leftd.ToString("F1") +"dB", f, new SolidBrush(Color.White), pf);
            pf = new PointF(x, 350);
            gr.DrawString("Speed:   " + _speed.ToString(), f, new SolidBrush(Color.White), pf);
            pf = new PointF(x, 370);
        }
    }
}
