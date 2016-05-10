using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ReviewThreads
{
	public partial class Form1 : Form
	{
		GDIDrawer.CDrawer _canvas = new GDIDrawer.CDrawer(bContinuousUpdate: false);
		object key = new object(); // The key for _q marshalled access
		Queue<Widget> _q = new Queue<Widget>();
		Thread _thrMakeRound = null;
		Thread _thrMakeSquare = null;
		Thread _thrShowWidgets = null;
		volatile bool _running = true;

		delegate int delIntString(string s);
		delIntString _dGetSleepTime = null;
		public Form1()
		{
			InitializeComponent();

			_dGetSleepTime = GetSleepTime;

		}
		private void Form1_Shown(object sender, EventArgs e)
		{
			// This should be done in onShown..
			_thrMakeRound = new Thread(MakeRounds);
			_thrMakeRound.IsBackground = true;
			_thrMakeRound.Start();

			_thrMakeSquare = new Thread(MakeSquares);
			_thrMakeSquare.IsBackground = true;
			_thrMakeSquare.Start();

			_thrShowWidgets = new Thread(ShowWidgets);
			_thrShowWidgets.IsBackground = true;
			_thrShowWidgets.Start(25);
		}
		private int GetSleepTime( string s )
		{
			return s.Length * 20;
		}
		// Producer Thread
		private void MakeRounds()
		{
			while (_running)
			{
				lock (key)
				{
					_q.Enqueue(new RoundWidget(_canvas));
				}
				Thread.Sleep(500);
			}
		}
		private void MakeSquares()
		{
			Thread.Sleep(100);
			int iSleep = (int)Invoke(_dGetSleepTime, "onethreso");
			while (_running)
			{
				lock (key)
				{
					_q.Enqueue(new SquareWidget(_canvas));
				}
				Thread.Sleep(iSleep);
			}
		}
		// Consumer
		private void ShowWidgets( object obj )
		{
			int iCount = 0;
			int iSleep = (int)obj;
			Widget w = null;
			while( _running )
			{
				lock( key )
				{
					w = null; // no widget
					if (_q.Count > 0)
					{
						w = _q.Dequeue();
						iCount++;
					}
				}
				// Show my widget
				w?.SuperRender(_canvas);
				_canvas.Render();
				if( iCount % 10 == 0 )
				{
					// Update title text
					Invoke((MethodInvoker)(() => Text = "Have rendered : " + iCount));
					Invoke((Action<int>)(( cnt ) => Text = "Have TOO rendered : " + cnt ), iCount );
				}
				Thread.Sleep(iSleep);
			}
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			_running = false;
		}
	}
}
