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
using HiLoTransport_2016jan;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Threading;

namespace Server
{
    public partial class _fmServer : Form
    {
        static private Random _rng = new Random();
        Socket _listener = null;
        Socket _client = null;
        volatile bool _run = true;
        Thread _thr = null;
        public _fmServer()
        {
            InitializeComponent();
            listen();
        }
        private void listen()
        {
            _listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _listener.Bind(new IPEndPoint(IPAddress.Any, 1666));
            _listener.Listen(5);
            _listener.BeginAccept(ServerEndAccept, _listener);
        }
        private void ServerEndAccept(IAsyncResult ia)
        {
            Socket tmpServer = (Socket)ia.AsyncState;
            try
            {
                _client = tmpServer.EndAccept(ia);
                _listener.BeginAccept(ServerEndAccept, _listener);
                this.Invoke((MethodInvoker)(() => { Text += " - " + _client.RemoteEndPoint.ToString();
                    _lbOutput.Items.Add("Connect");}));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error {ex.Message}");
            }

            _thr = new Thread(ClientReceive);
            _thr.IsBackground = true;
            _thr.Start(_client);
        }
        //Receiving the client data
        private void ClientReceive(object obj)
        {
            int secretNum = _rng.Next(1001);
            HiLoTransport data = null;
            Byte[] buff = new Byte[10000];
            Socket clientData = (Socket)obj;
            clientData.ReceiveTimeout = 0;

            while (_run)
            {
                int bytesCheck = 0;
                //setup the requirements to deserialize the data back into an object
                try
                {
                    bytesCheck = clientData.Receive(buff);//waiting for a response..
                }
                catch (Exception err)
                {
                    Console.WriteLine("Connection Loss!! " + err.Message);
                    return;
                }
                if(bytesCheck == 0)
                {
                    Console.WriteLine("Client Disconnected");
                    //listen();
                    return;
                }

                BinaryFormatter bf = new BinaryFormatter();
                object frame = bf.Deserialize(new MemoryStream(buff));
                if (frame is HiLoTransport)
                {
                    Console.WriteLine("The data received");

                    //once recieved the data. Analyze the data and send a response back to the client
                    data = (HiLoTransport)frame;
                    Invoke((MethodInvoker)(() => _lbOutput.Items.Add((data.Payload.ToString()))));

                    // the game...
                    int result = checkNum(secretNum, data.Payload);
                    if (result == 0)
                        secretNum = _rng.Next(1001);
                    data = new HiLoTransport(result);

                    //send the reused frame back to the client
                    MemoryStream ms = new MemoryStream();
                    bf.Serialize(ms, data);
                    clientData.Send(ms.GetBuffer(), (int)ms.Length, SocketFlags.None);
                }
                else
                {
                    Console.WriteLine("ERROR Data have not received!!");
                }
                Thread.Sleep(100);
            }
        }
        private int checkNum(int num, int guess)
        {
            int result = 0;
            //guess is small -- low
            if (num > guess)
                result = -1;
            else if (num < guess) //guess is big -- high
                result = 1;
            //else if it the correct num -- send 0
            return result;
        }
    }
}
