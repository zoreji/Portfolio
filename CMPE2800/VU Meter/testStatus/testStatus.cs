using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace testStatus
{
    public partial class testStatus: UserControl
    {
        Thread enQ;
        Thread calAvg;
        object key = new object(); // master key
        Queue<PointF> Avg;
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
        float _alert_Lvl = 0;
        [Browsable(true), Description("(╯°□°）╯︵ ┻━┻"), Category("Meter Level")]
        public float alert_Lvl
        {
            get { return _alert_Lvl; }
            set { _alert_Lvl = value; Invalidate(); }
        }
        public enum Meter_type { Peak = 1,Fast,Medium,Slow}
        Meter_type _speed = Meter_type.Medium;
        [Browsable(true), Description("The Meter Type"), Category("Meter Type")]
        public Meter_type Speed
        {
            get { return _speed; }
            set { _speed = value; Invalidate(); }
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
        Font f = null;
        public testStatus()
        {
            InitializeComponent();
            f = new Font("Comic Sans", 14);
            //Avg = new Queue<PointF>();
            left = new List<float>();
            right = new List<float>();

        }
        public event EventHandler onAlarm = null;

        public delegate void delVoidInt(int value);
        public event delVoidInt alarmCount = null;
        public event EventHandler changeSpeed = null;
        public delegate void delVoidtype(int value);
        public event EventHandler changetype = null;
        private void checkalert(PointF value)
        {
            if (value.X > alert_Lvl || value.Y > alert_Lvl)
                onAlarm?.Invoke(this, new EventArgs());

        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //base.OnPaintBackground(e);
        }
        private void transferFunction()
        {
            double leftd = (20 * Math.Log10((double)left_avgLvl));
            double rightd = (20 * Math.Log10((double)right_avgLvl));
            checkalert(_value);
            left_degrees = (float)leftd;
            right_degrees = (float)rightd;
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
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            setLimit(_speed);
            sampleAverage();
            data(gr);
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
            left.Clear();
            right.Clear();
        }
        private void data(Graphics gr)
        {
            //sampleAverage();
            if (gr == null)
                gr = CreateGraphics();
            gr.Clear(Color.Black);
            gr.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            PointF pf = new PointF(10, 10);
            gr.DrawString("Max:     " + _maxLvl.ToString(), f, new SolidBrush(Color.White), pf);
            pf = new PointF(10, 30);
            gr.DrawString("Min:     " + _minLvl.ToString(), f, new SolidBrush(Color.White), pf);
            pf = new PointF(10, 50);
            gr.DrawString("Alert:   " + _alert_Lvl.ToString(), f, new SolidBrush(Color.White), pf);
            pf = new PointF(10, 70);
            gr.DrawString("Value-right:   " + _value.Y.ToString(), f, new SolidBrush(Color.White), pf);
            pf = new PointF(10, 90);
            gr.DrawString("Value-left:   " + _value.X.ToString(), f, new SolidBrush(Color.White), pf);
            pf = new PointF(10, 110);
            gr.DrawString("Left:   " + left_degrees.ToString("F1"), f, new SolidBrush(Color.White), pf);
            pf = new PointF(10, 130);
            gr.DrawString("Right:   " + right_degrees.ToString("F1"), f, new SolidBrush(Color.White), pf);
            pf = new PointF(10, 150);
            gr.DrawString("Speed:   " + _speed.ToString(), f, new SolidBrush(Color.White), pf);
            pf = new PointF(10, 170);
        }
    }
}
