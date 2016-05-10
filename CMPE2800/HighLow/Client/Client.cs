using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
//using System.Threading;
using HiLoTransport_2016jan;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;


namespace Client
{
    public partial class _fmClient : Form
    {
        //class server -- 10.132.8.25
        Socket _SokClient = null;
        HiLoTransport _HiLoFrame = null;
        int userGuess = 0;
        
        public _fmClient()
        {
            InitializeComponent();
            _lbHigh.Text = 1000.ToString();
            _lbLow.Text = 0.ToString();
            _trbGuess.Maximum = 1000;
            _trbGuess.Minimum = 0;
            _tbHost.Text = "localhost";
            _tbPort.Text = "1666";
            _tbGuess.Text = _trbGuess.Value.ToString();
            _gbHiLo.Enabled = false;
        }

        private void _btnConnect_Click(object sender, EventArgs e)
        {
            _SokClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            if (_tbPort.Enabled && _tbHost.Enabled)
            {
                try
                {
                    string host = _tbHost.Text.ToString();
                    int port = Convert.ToInt32(_tbPort.Text);
                    _SokClient.BeginConnect(host, port, clientEndConnect, _SokClient);
                    _tbHost.Enabled = false;
                    _tbPort.Enabled = false;
                    _btnConnect.Enabled = false;
                }
                catch
                {
                    Console.WriteLine("Invalid Connection or Port");
                }
            }
            else
            {
                //disconnect the clients socket from the server
                //_SokClient.Shutdown(SocketShutdown.Both);
                //_SokClient.Disconnect(true);
                _tbHost.Enabled = true;
                _tbPort.Enabled = true;
                _btnConnect.Enabled = true;
                _btnConnect.Text = "Connect";
                _lbResult.Items.Clear();
                _gbHiLo.Enabled = false;
            }
        }
        private void clientEndConnect(IAsyncResult result)
        {
            Socket tmpClient = (Socket)result.AsyncState;
            try
            {
                tmpClient.EndConnect(result);
                this.Invoke((MethodInvoker)(() => 
                {
                    Text += " - " + tmpClient.RemoteEndPoint.ToString();
                    _lbResult.Items.Add("Connect");
                    _btnConnect.Text = "Disconnect";
                    _gbHiLo.Enabled = true;
                    _btnConnect.Enabled = true;
                }));
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error {ex.Message}");
                this.Invoke((MethodInvoker)(() => { _lbResult.Items.Add("Cannot connect Connection TimeOut");
                    _tbHost.Enabled = true;
                    _tbPort.Enabled = true;
                    _btnConnect.Text = "Connect";
                    _btnConnect.Enabled = true;
                }));
            }
        }
        private void checkValues(int num)
        {
            if (num == -1)//low guess
            {
                _lbLow.Text = (userGuess + 1).ToString();
                _trbGuess.Minimum = userGuess + 1;
                _lbResult.Items.Add("Low guess");
            }
            else if(num == 1)//high guess
            {
                _lbHigh.Text = (userGuess - 1).ToString();
                _trbGuess.Maximum = userGuess - 1;
                _lbResult.Items.Add("High guess");
            }
            else// correct guess
            {
                _lbResult.Items.Add("You Win... Play Again");
                _lbHigh.Text = 1000.ToString();
                _lbLow.Text = 0.ToString();
                _trbGuess.Maximum = 1000;
                _trbGuess.Minimum = 0;
            }
            //_trbGuess.Value = (int)(_trbGuess.Maximum / _trbGuess.Minimum);

        }

        private void _fmClient_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.G)
                game();
        }
        private void game()
        {
            int bytesCheck = 0;
            //sending to the server
            //userGuess
            userGuess = _trbGuess.Value;
            _tbGuess.Text = userGuess.ToString();
            _HiLoFrame = new HiLoTransport(userGuess);
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();

            bf.Serialize(ms, _HiLoFrame);

            _SokClient.Send(ms.GetBuffer(), (int)ms.Length, SocketFlags.None);

            byte[] buff = new byte[10000];

            // recieve the incoming data that send from the server
            _SokClient.ReceiveTimeout = 0;
            //_SokClient.Receive(buff);
            try
            {
                bytesCheck = _SokClient.Receive(buff);//waiting for a response...
            }
            catch (Exception err)
            {
                Console.WriteLine("Connection Loss!! " + err.Message);
                Invoke((MethodInvoker)(() => _lbResult.Items.Add("Connection Loss!! " + err.Message)));
                return;
            }
            if (bytesCheck == 0)
            {
                Console.WriteLine("Server Disconnected");
                Invoke((MethodInvoker)(() => _lbResult.Items.Add("Server Disconnected ")));
                return;
            }
            object frame = bf.Deserialize(new MemoryStream(buff));
            if (frame is HiLoTransport)
            {
                Console.WriteLine("Client Recieved");
                _HiLoFrame = (HiLoTransport)frame;
                // the game...
                checkValues(_HiLoFrame.Payload);
            }
        }

        private void _btGuess_Click(object sender, EventArgs e)
        {
            game();
        }
    }
}
