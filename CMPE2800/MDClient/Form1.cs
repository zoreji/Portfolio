using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GenericSocket_ica2_D;
using System.Net;
using System.Net.Sockets;
using mdtypes;

namespace MDClient
{
    public partial class Form1 : Form
    {
        private Connect Con;
        bool Drawing = false;
        private volatile bool Connected = false;
        ushort Thickness = 1;
        PointF Startp;
        PointF Endp;
        Color Colour;
        genericSocket GenSock;
        Socket clientSock;
        LineSegment draw = null;
        LineSegment render = null;
        bool AlphaFlag = false;
        byte Alpha = 255;
        
        public Form1()
        {
            InitializeComponent();
            MouseWheel += Form1_MouseWheel;
            _LBThickness.Text = $"Thickness: {Thickness}";
            _LBAlpha.Text = $"Alpha: {Alpha}";
            //MouseMove = Form1_MouseMove;
        }

        //TODO: need member for start point and a drawing flag
        //TODO: Mouse Up/Down - set flags that we ARE or ARE NOT drawing, combine with connected flag to know if it matters
        //TODO: Mouse Down also sets the initial start point
        //TODO: MouseMove - IF we ARE drawing AND we care - make seg with member start and current point - send it, then save start as current end.. Yes ??
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Drawing = true;
            if(Drawing && Connected)
            {
                draw = new LineSegment();
                if (e.Button == MouseButtons.Left)
                {
                    Startp = e.Location;
                    draw.Start = Startp;
                }
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Drawing && Connected && draw != null) 
            {
                //draw.Start = e.Location;
                draw.Alpha = Alpha;
                draw.Colour = Colour;
                draw.Thickness = Thickness;
                Endp = e.Location;
                draw.Start = Startp;
                draw.End = Endp;
                GenSock.sendData(draw);
                Startp = Endp;
                //draw.Start = e.Location;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (Drawing && Connected && draw != null)
            {
                draw.Alpha = Alpha;
                draw.Colour = Colour;
                draw.Thickness = Thickness;
                draw.Start = Startp;
                draw.End = Endp;
                GenSock.sendData(draw);
                Drawing = false;
            }
        }

        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            int value = e.Delta;
            if(!AlphaFlag)
            {
                if (value > 0)
                {
                    Thickness += 2;
                    _LBThickness.Text = $"Thickness: {Thickness}";
                }
                else if (value < 0 && Thickness != 1)
                {
                    Thickness -= 2;
                    _LBThickness.Text = $"Thickness: {Thickness}";
                }
            }
            else
            {
                if (value > 0)
                {
                    Alpha += 2;
                    _LBAlpha.Text = $"Alpha: {Alpha}";
                }
                else if (value < 0 && Thickness != 1)
                {
                    Alpha -= 2;
                    _LBAlpha.Text = $"Alpha: {Alpha}";
                }
            }
        }

        private void _LBConnect_Click(object sender, EventArgs e)
        {
            if (!Connected)
            {
                Con = new Connect();
                Con.sendText = new DelVoidVoid(GetData);
                Con.Show();
                _LBConnect.Text = "Disconnect...";
            }
            else
            {
                Connected = false;
                //_LBConnect.Enabled = true;
                _LBConnect.Text = "Connect...";
                clientSock.Close();
            }
        }

        private void GetData(object Rec)
        {
            List<string> ConnectData = (List<string>)Rec;
            for (int i = 0; i < ConnectData.Count; i++)
            {
                Text = "Connected to: " + ConnectData[0] + " Port: " + ConnectData[1];
            }

            clientSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            string host = ConnectData[0];
            int port = Convert.ToInt32(ConnectData[1]);
            clientSock.BeginConnect(host, port, clientEndConnect, clientSock);
            Connected = true;

        }

        private void _LBColor_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                _LBColor.BackColor = colorDialog1.Color;
                Colour = colorDialog1.Color;
            }
        }

        private void clientEndConnect(IAsyncResult asr)
        {
            Socket tempSock = (Socket)asr.AsyncState;
            try
            {
                tempSock.EndConnect(asr);
                GenSock = new genericSocket(clientSock, RenderFormPaint, ErrorFormPaint);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void RenderFormPaint(object obj)
        {
            render = (LineSegment)obj;
            Graphics gr = CreateGraphics();
            render.Render(gr);
        }
        private void ErrorFormPaint(object obj)
        {
            Console.WriteLine("Error Sockect disconnect");
            Connected = false;
            _LBConnect.Enabled = true;
            _LBConnect.Text = "Connect...";
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (GenSock == null)
            {
                _LBFrames.Text = "Frames RX'ed : " + 0;
                _LBFragments.Text = "Fragments : " + 0;
                _LBDestack.Text = "Destack Avg : " + 0;
                _LBBytes.Text = "Bytes RX'ed : " + 0;
            }
            else
            {
                _LBFrames.Text = "Frames RX'ed : " + GenSock.FramesRX.ToString();
                _LBFragments.Text = "Fragments : " + GenSock.Fragments.ToString();
                _LBDestack.Text = "Destack Avg : " + GenSock.DestackAvg.ToString("G2");
                _LBBytes.Text = "Bytes RX'ed : " + GenSock.stringformat(GenSock.BytesRX);
            }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.A)
            {
                AlphaFlag = true;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                AlphaFlag = false;
            }
        }
    }
}
