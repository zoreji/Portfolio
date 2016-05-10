/*****************************************************
*   Program:        Server.cs
*   Description:    Server that recieve data from multiple clients
                    and send the data back to all clients that are
                    connected
*   Author:         Ervin Hernandez
*   Class:          CMPE2800
*   Date:           2016/03/30
******************************************************/
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
using System.Threading;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using mdtypes;
using GenericSocket_ica2_D;


//****NOTE*****
//Some of the stats/math from the generic Socket are inaccurate


namespace ErvinLab2
{
    public partial class Server : Form
    {
        Socket _listener = null;
        Thread _connectThr = null;
        Thread _sendthr = null;
        //genericSocket gensock = null;
        Dictionary<Socket, genericSocket> dicClient = new Dictionary<Socket, genericSocket>();
        Queue<object> sendQ = new Queue<object>();
        volatile bool _running = true;
        object _key = new object(); // master key
        public Server()
        {
            InitializeComponent();
            //listen();
            _connectThr = new Thread(listen);
            _connectThr.IsBackground = true;
            _connectThr.Start();

            _sendthr = new Thread(process);
            _sendthr.IsBackground = true;
            _sendthr.Start();
                
        }
        private void listen()
        {
            // a thread that runs in the background to continuously listen for a client to connect 
            // and send it to the dictionary 
            try {
                _listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                _listener.Bind(new IPEndPoint(IPAddress.Any, 1666));
                _listener.Listen(0);
                while (_running)
                {
                    Thread.Sleep(0);
                    Socket _client = null;
                    _client = _listener.Accept();
                    // create a generic Socket for that client socket and store in it the dictionary
                    lock (_key)
                    {
                        dicClient.Add(_client, new genericSocket(_client, recieveData, recieveErr));
                    }
                    updateList();
                }
            }catch
            {

            }
            
        }
        /// <summary>
        /// A Method that runs in the background and dequeue the stack to send 
        /// data to all clients in the dictionary if there is any in the
        /// queue
        /// </summary>
        private void process()
        {
            object temp = null;
            while (_running)
            {
                Thread.Sleep(0);
                if (sendQ.Count != 0)
                {
                    lock(_key)
                    {
                        temp = sendQ.Dequeue();
                    }
                    if (temp is LineSegment)
                    {
                        foreach (var item in dicClient)
                        {
                            item.Value.sendData(temp);
                        }
                    }
                    else
                    {
                        Console.WriteLine("error data");
                    }
                    updateList();
                }
            }
        }
        /// <summary>
        /// call back function that is related to the generic socket that is used in
        /// each of the clients in the dictionary and send it to a queue
        /// </summary>
        /// <param name="data"></param>
        private void recieveData(object data)
        {
            lock(_key)
                sendQ.Enqueue(data);
        }
        /// <summary>
        /// if any of the generic socket disconnect or crash in the dictionary
        /// it will send an error in a form of the socket is self and will be remove from the 
        /// dictionary and the listbox 
        /// </summary>
        /// <param name="e"></param>
        private void recieveErr(object e)
        {
            lock(_key)
            {
                if (e is genericSocket)
                    dicClient.Keys.ToList().FindAll(x => dicClient[x] == (genericSocket)e).ForEach(x => dicClient.Remove(x));
            }
            updateList();
        }
        /// <summary>
        /// A Method that update the list box information to the form
        /// </summary>
        private void updateList()
        {
            this.Invoke((MethodInvoker)(() => { listBox1.Items.Clear(); }));
            foreach (var item in dicClient)
            {
                IPEndPoint ip = item.Key.RemoteEndPoint as IPEndPoint;
                double b = item.Value.BytesRX;
                double c = item.Value.DestackAvg;
                double e = item.Value.Fragments;
                this.Invoke((MethodInvoker)(() => { listBox1.Items.Add(ip.Address.ToString() + "  Bytes " + item.Value.stringformat(b).ToString() + "  Destack " + item.Value.stringformat(c).ToString() + "  Fragments " + item.Value.stringformat(e).ToString()); }));
            }
        }
    }
}
