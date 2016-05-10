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

namespace ervin10
{
    public partial class Form1 : Form
    {
        SortedDictionary<string, int> Archive = new SortedDictionary<string, int>();
        List<string> library = new List<string>();
        //StreamReader ReadFile;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void BT_Load_Click(object sender, EventArgs e)
        {
            keywordList();
            Archive.Clear();
            if(openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    foreach (string s in System.IO.File.ReadLines(openFileDialog.FileName))
                        foreach (string k in s.Split(' ', '(', ')', ';', '=', ',', '.', '{', '}'))
                        { 
                            if (library.Contains(k))
                                if (Archive.ContainsKey(k))
                                    Archive[k]++;
                                else
                                    Archive.Add(k, 1);
                        }
                    ShowDictionary();
                }
                catch { MessageBox.Show("Cannot load File", "Loading Error"); }
            }
        }
        private void keywordList()
        {
            library.Clear();
            foreach (string s in System.IO.File.ReadLines(@"..\..\Keywords.txt"))
                foreach(string c in s.Split(' '))
                    library.Add(c);
        }
        private void ShowDictionary()
        {
            LV_dictionary.Items.Clear();
            foreach (KeyValuePair<string, int> l in Archive)
            {
                ListViewItem ll = LV_dictionary.Items.Add(l.Key);
                ll.SubItems.Add(l.Value.ToString());
            }
        }

        private void BT_Load_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Add:
                    Archive.Keys.ToList().FindAll(i => Archive[i] < 10).ForEach(x => Archive.Remove(x));
                    ShowDictionary();
                    break;
            }
        }
    }
}
