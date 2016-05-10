/*****************************************************
*   Program:        Lab01Review.cs
*   Description:    Load and Check 1 bits of a large file
*   Author:         Ervin Hernandez
*   Class:          CMPE2800
*   Date:           2016/01/25
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
using System.IO;
using System.Threading;

namespace ErvinLab01
{
    public partial class _fmFileStats : Form
    {
        FileInfo _file;
        volatile bool _run = true;
        // main key to access the lock program
        object _key = new object();
        Queue<byte[]> byteQue = null;
        Thread queThr = null;
        Thread deQue = null;
        public _fmFileStats()
        {
            InitializeComponent();
            byteQue = new Queue<byte[]>();
        }

        private void _btOpen_Click(object sender, EventArgs e)
        {
            if (OFD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _pbUpdate.Value = 0;
                _file = new FileInfo(OFD.FileName);
                //set the file name and the bar size and clear textbox
                _tbName.Text = OFD.FileName.ToString();
                _tbSize.Text = _file.Length.ToString();
                _pbUpdate.Maximum = (int)_file.Length;

                _tbResult.Text = "";
                //run the que thread
                queThr = new Thread(queThread);
                queThr.IsBackground = true;
                queThr.Start(_file);
                //run the count 1s deque thread
                deQue = new Thread(dequeThread);
                deQue.IsBackground = true;
                deQue.Start(_file);

            }
            
        }
        /// <summary>
        /// Method:     void queThread(object obj)
        /// Summary:    the thread method that take an object and alters it to a
        ///             FileInfo so the method could que the files into 
        ///             2048 chucks.
        /// </summary>
        /// <param name="obj"></param>
        private void queThread(object obj)
        {
            FileInfo File = (FileInfo)obj;
            FileStream readFile = File.OpenRead();
            byte[] byteFile = new byte [2048];

            //while (readFile.Read(byteFile, 0, ) > 0)
            //{
            //    byte[] temp = new byte[byteFile.Length];
            //    Array.Copy(byteFile, temp, temp.Length);
            //    byteQue.Enqueue(byteFile);
            //}

            //run while the reader is in within the file length
            while (readFile.Position < readFile.Length)
            {
                lock (_key)
                {
                    if (readFile.Length - readFile.Position < 2048)
                        byteFile = new byte[readFile.Length - readFile.Position];

                    readFile.Read(byteFile, 0, byteFile.Length);
                    byte[] temp = new byte[byteFile.Length];
                    // make a copy of the file and add the later portion of the data
                    Array.Copy(byteFile, temp, temp.Length);
                    byteQue.Enqueue(byteFile);
                    Thread.Sleep(10);
                }
            }
        }

        /// <summary>
        /// Method:     void dequeThread(object obj)
        /// Summary:    the thread method that take in an object and changes it to a 
        ///             FileInfo so the method could deque and count the number of one's
        ///             in the file that have been pass through the main form.
        /// </summary>
        /// <param name="obj"></param>
        private void dequeThread(object obj)
        {
            FileInfo File = (FileInfo)obj;
            byte[] tempByte = null;
            double total = 0;
            //double count = 0;
            double counter = 0;
            //long size = File.Length;
            //int step = (int)( size / 100);
            while( _run)
            {
                lock(_key)
                {
                    // break if there is nothing the que
                    if (byteQue.Count == 0)
                        break;
                    tempByte = byteQue.Dequeue();
                    //count += tempByte.Length;
                    for (int i = 0; i < tempByte.Length; i++)
                    {
                        for (int x = 0; x < 8; x++)
                        {
                            // check if there is a one in the file by an AND gate
                            total += ((tempByte[i] & 0x01) == 1) ? 1 : 0;
                            tempByte[i] >>= 1;
                            //the counter iteration
                            counter++;
                        }
                        Invoke((MethodInvoker)(() => { _pbUpdate.Value++; }));
                    }
                    Thread.Sleep(100);
                }
            }
            double percent = (total / counter)*100;
            Invoke((MethodInvoker)(() => _tbResult.Text = string.Format("Percentage of file that is 1s : {0: ##.##}%",percent)));
        }
    }
}
