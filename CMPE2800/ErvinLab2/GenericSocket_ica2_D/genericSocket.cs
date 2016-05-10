using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Threading;
//TODO:  Looks good, just need to resolve how errors correctly propogate out
//TODO:  perhaps for your structure, inject an empty object or null into q, then let Rx terminate, don't set running flag
//TODO:      then let process q pull, recognize and invoke appropriate data/error message, let it set running flag on error ? Rx will already have terminated ? No ?
//TODO:  MAKE SURE ALL THREADS SLEEP(0) in their loops - behavior will be spastic....without (check)
namespace GenericSocket_ica2_D
{
    public class genericSocket
    {
        private volatile bool _running = true;
        private object _Key = new object();// master key
        Thread SendThread;
        Thread ReceiveThread;
        Thread ProcessThread;
        private Queue<object> TxQ = new Queue<object>();
        private Queue<object> RxQ = new Queue<object>();
        Socket _GenSoc = null;
        public delegate void DelObjVoidErr(object Error);
        public DelObjVoidErr dispatchError = null;
        public delegate void DelObjVoidData(object Data);
        public DelObjVoidData dispatchData = null;
        //public static object Data{ get; set; }
        public double FramesRX { get; private set; } = 0;
        public int BytesRX { get; private set; } = 0;
        public int Fragments { get; private set; } = 0;
        public double DestackAvg { get; private set; } = 0;
        private double dequeCount { get; set; } = 0;

        public genericSocket(Socket genSoc, DelObjVoidData callData, DelObjVoidErr callErr)
        {
            _GenSoc = genSoc;
            SendThread = new Thread(ThreadSend);
            SendThread.IsBackground = true;
            SendThread.Start();

            ReceiveThread = new Thread(ThreadRecieve);
            ReceiveThread.IsBackground = true;
            ReceiveThread.Start();

            ProcessThread = new Thread(ThreadProcess);
            ProcessThread.IsBackground = true;
            ProcessThread.Start();

            //Initialize Data Callback delegate
            dispatchData = callData;
            //Initialize Error Callback delegate
            dispatchError = callErr;
        }
        public void sendData(object obj) // receive the data from the client
        {
            lock (_Key)
            {
                TxQ.Enqueue(obj);
                //_running = true;
            }
        }
        private void ThreadSend()
        {
            
            BinaryFormatter bf = new BinaryFormatter();
            object tempObj = null;
            while (_running)
            {
                Thread.Sleep(0);
                if (TxQ.Count != 0)
                {
                    //_running = false;
                    lock (_Key)
                    {
                        tempObj = TxQ.Dequeue();
                    }
                    
                    // Serialize the dequeue objec obtain in the client
                    MemoryStream ms = new MemoryStream();
                    bf.Serialize(ms, tempObj);
                    _GenSoc.Send(ms.GetBuffer(), (int)ms.Length, SocketFlags.None);
                }
            }
        }

        private void ThreadRecieve()
        {
            object tempObj = null;
            _GenSoc.ReceiveTimeout = 0;
            byte[] buffer = new byte[20480];
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            while (_running)
            {
                int iByte = 0;
                try
                {
                    
                    // wait for the data
                    iByte = _GenSoc.Receive(buffer);

                    //add the receiving data to the end of the stream
                    // and place the stream postion back to where it was
                    long lpos = ms.Position;
                    ms.Seek(0, SeekOrigin.End);
                    ms.Write(buffer, 0, iByte);
                    ms.Position = lpos;
                    BytesRX += buffer.Count();
                    // start extracting one or more compete objects
                    do
                    {
                        // save the position incase the stream dies
                        long lstartPos = ms.Position;
                        try
                        {
                            //send to the queue for processing
                            tempObj = bf.Deserialize(ms);
                            //tempObj = null;
                            lock(_Key){
                                RxQ.Enqueue(tempObj);
                                dequeCount++;
                            }
                        }
                        catch (System.Runtime.Serialization.SerializationException)
                        {
                            // if there is any error in the streamreading
                            // move the pointer back to the last save position
                            ms.Position = lstartPos;
                            Fragments++;
                            // and exit the loop for the next set of data
                            break;
                        }
                    } while (ms.Position < ms.Length);

                    // clear stream if all data processed
                    if (ms.Position == ms.Length)
                    {
                        ms.Position = 0;
                        ms.SetLength(0);
                        FramesRX++;
                    }
                }
                catch(Exception error)
                {
                    Console.WriteLine("ERROR(receive): " + error.Message);
                    tempObj = "Error(receive)" + error.Message;
                    lock (_Key)
                    {
                        RxQ.Enqueue(tempObj);
                    }
                    //_running = false;
                }
                if (iByte == 0)
                {
                    Console.WriteLine("Soft Disconnect");
                    tempObj = "Soft Disconnect";
                    lock (_Key)
                    {
                        RxQ.Enqueue(tempObj);
                    }
                    // Enable the connect button and change the text to "Connect" by invoking it
                    //_running = false;
                }
                Thread.Sleep(0);
            }
        }

        private void ThreadProcess()
        {
            object tempObj = null;

            do
            {
                if (RxQ.Count != 0)
                {
                    //_running = false;
                    lock (_Key)
                    {
                        tempObj = RxQ.Dequeue();
                    }
                    if (tempObj is mdtypes.LineSegment)
                    {
                        dispatchData(tempObj);
                    }
                    else
                    {
                        //Dispatch Delegate Data
                        dispatchError(this);
                        _running = false;
                    }
                    DestackAvg = FramesRX / dequeCount;
                }
                Thread.Sleep(0);
            } while (_running);
        }
        public string stringformat(double value)
        {
            double unit = value / 1000;
            double mega = unit / 1000;
            if (unit > 1000)
                return mega.ToString("G4") + "M";
            else if (unit > 1 && unit < 1000)
                return unit.ToString("G4") + "K";
            else
                return value.ToString("G4") + "B";
        }
    }
}
