/***************************************************************************
 * Program:     PicBender.cs
 * Description: Manipulate the picture the user uploaded into the program
 * Author:      Ervin Hernandez
 * Class:       CMPE1600
 * Date:        2015/04/02
 **************************************************************************/
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

namespace PicBender
{
    public partial class PicBen_Main : Form
    {
        PicData bitfile;
        public static Random rng = new Random();
        // a struct that retains all the data for the user and be able to send it into the thread 
        // so that it be able to access a the modifidy image
        public struct PicData
        {
            public Bitmap _modImage;
            public Bitmap _image;
            public int _Trackvalue;
            public PicData(Bitmap ModImage, Bitmap image, int trackvalue)
            {
                _modImage = ModImage;
                _image = image;
                _Trackvalue = trackvalue;
            }
        }
        public PicBen_Main()
        {
            InitializeComponent();
        }
        private void TB_Mod_Scroll(object sender, EventArgs e)
        {
            label3.Text = TB_Mod.Value.ToString();
        }
        private void BT_Load_Click(object sender, EventArgs e)
        {  
            if (OFD_LoadPic.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    // creating a copy of the picture so it be modifyable in the thread
                    bitfile = new PicData((Bitmap)(Bitmap.FromFile(OFD_LoadPic.FileName)),(Bitmap)(Bitmap.FromFile(OFD_LoadPic.FileName)),TB_Mod.Value);
                    PicBox_Main.Image = bitfile._image;
                    BT_Transform.Enabled = true;
                }
                catch
                {
                    MessageBox.Show("Cannot load File", "Loading Error");
                }
            }
        }
        private void BT_Transform_Click(object sender, EventArgs e)
        {
            PB_LoadBar.Value = 0;
            bitfile._Trackvalue = TB_Mod.Value;
            Thread transform;
            // These check if any of the radio buttons are selected and activate the thread when choosen
            if (RB_Contrast.Checked)
            {
                transform = new Thread(new ParameterizedThreadStart(Contrast));
                transform.IsBackground = true;
                transform.Start(bitfile);
            }
            if (RB_Blk_Wht.Checked)
            {
                transform = new Thread(new ParameterizedThreadStart(Blk_Wht));
                transform.IsBackground = true;
                transform.Start(bitfile);
            }
            if (RB_Tint.Checked)
            {
                transform = new Thread(new ParameterizedThreadStart(Tint));
                transform.IsBackground = true;
                transform.Start(bitfile);
            }
            if (RB_Noise.Checked)
            {
                transform = new Thread(new ParameterizedThreadStart(Noise));
                transform.IsBackground = true;
                transform.Start(bitfile);
            }
        }
        // Delegate that is a void and accepts a bitmap image;
        private delegate void delvoidBitmap(Bitmap image);
        // The call back of the delegate to update the image in the picture
        private void UpdateImage(Bitmap image)
        {
            PicBox_Main.Image = image;
            PicBox_Main.Refresh();
        }
        // Delegate that a void and accepts a int for the progress bar
        private delegate void delvoidInt(int value);
        // a Call back that Update the progress
        private void UpdatePB(int Value)
        {
            PB_LoadBar.Maximum = (bitfile._image.Width);
            PB_LoadBar.Value = Value;
        }
        private void Contrast(object file)
        {
            Color pixel;
            PicData image = (PicData)file;
            int counter = 0;
            int red;
            int blue;
            int green;
            int effect = image._Trackvalue / 5;
            for (int x = 0; x < image._modImage.Width; ++x) 
            {
                for (int y = 0; y < image._modImage.Height; ++y)
                {
                    // math for contrast
                    pixel = image._modImage.GetPixel(x, y);
                    if (pixel.R <128)
                        red = pixel.R - effect;
                    else
                        red = pixel.R + effect;
                    if (pixel.G < 128)
                        green = pixel.G - effect;
                    else
                        green = pixel.G + effect;
                    if (pixel.B < 128)
                        blue = pixel.B - effect;
                    else
                        blue = pixel.B + effect;
                    // esuring that it doesn't excced limits of the picture
                    if (red < 0)
                        red = 0;
                    if (blue < 0)
                        blue = 0;
                    if (green < 0)
                        green = 0;
                    if (red > 255)
                        red = 255;
                    if (blue > 255)
                        blue = 255;
                    if (green > 255)
                        green = 255;
                    image._modImage.SetPixel(x, y, Color.FromArgb(red, green, blue));
                }
                counter++;
                Invoke(new delvoidInt(UpdatePB), counter);
            }
            // send the newly modfidy image into the main UI
            Invoke(new delvoidBitmap(UpdateImage), image._modImage);
            Invoke(new delvoidInt(UpdatePB), 0);
        }
        private void Blk_Wht(object file)
        {
            // red = redValue + ((grayscale - redValue) * Track%);
            Color pixel;
            PicData image = (PicData)file;
            int counter = 0;
            double red;
            double blue;
            double green;
            double grayscale;
            double effect = (double)image._Trackvalue / 100;
            for (int x = 0; x < image._modImage.Width; ++x)
            {
                for (int y = 0; y < image._modImage.Height; ++y)
                {
                    pixel = image._modImage.GetPixel(x, y);
                    grayscale = (pixel.G + pixel.R + pixel.B) / 3;
                    red = (pixel.R + ((grayscale - pixel.R) * effect));
                    green = (pixel.G + ((grayscale - pixel.G) * effect));
                    blue = (pixel.B + ((grayscale - pixel.B) * effect));
                    if (red < 0)
                        red = 0;
                    if (blue < 0)
                        blue = 0;
                    if (green < 0)
                        green = 0;
                    if (red > 255)
                        red = 255;
                    if (blue > 255)
                        blue = 255;
                    if (green > 255)
                        green = 255;
                    image._modImage.SetPixel(x, y, Color.FromArgb((int)red, (int)green, (int)blue));
                }
                counter++;
                Invoke(new delvoidInt(UpdatePB), counter);
            }
            Invoke(new delvoidBitmap(UpdateImage), image._modImage);
            Invoke(new delvoidInt(UpdatePB), 0);
        }
        private void Tint(object file)
        {
            Color pixel;
            PicData image = (PicData)file;
            int counter = 0;
            int red;
            int blue;
            int green;
            int effect = image._Trackvalue;
            for (int x = 0; x < image._modImage.Width; ++x)
            {
                for (int y = 0; y < image._modImage.Height; ++y)
                {
                    pixel = image._modImage.GetPixel(x, y);
                    blue = pixel.B;
                    red = pixel.R;
                    green = pixel.G;
                    if (effect < 50)
                        red = pixel.R + (50 - effect);
                    else
                        green = pixel.G + (effect - 50);
                    if (red < 0)
                        red = 0;
                    if (green < 0)
                        green = 0;
                    if (red > 255)
                        red = 255;
                    if (green > 255)
                        green = 255;
                    image._modImage.SetPixel(x, y, Color.FromArgb(red, green, blue));
                }
                counter++;
                Invoke(new delvoidInt(UpdatePB), counter);
            }
            Invoke(new delvoidBitmap(UpdateImage), image._modImage);
            Invoke(new delvoidInt(UpdatePB), 0);
        }
        private void Noise(object file)
        {
            Color pixel;
            PicData image = (PicData)file;
            int counter = 0;
            int red;
            int blue;
            int green;
            for (int x = 0; x < image._modImage.Width; ++x)
            {
                for (int y = 0; y < image._modImage.Height; ++y)
                {
                    pixel = image._modImage.GetPixel(x, y);
                    red = pixel.R + (rng.Next(256) % ((image._Trackvalue + 1) * 2)) - image._Trackvalue;
                    green = pixel.G + (rng.Next(256) % ((image._Trackvalue + 1) * 2)) - image._Trackvalue;
                    blue = pixel.B + (rng.Next(256) % ((image._Trackvalue + 1) * 2)) - image._Trackvalue;
                    if (red < 0)
                        red = 0;
                    if (blue < 0)
                        blue = 0;
                    if (green < 0)
                        green = 0;
                    if (red > 255)
                        red = 255;
                    if (blue > 255)
                        blue = 255;
                    if (green > 255)
                        green = 255;
                    image._modImage.SetPixel(x, y, Color.FromArgb(red, green, blue));
                }
                counter++;
                Invoke(new delvoidInt(UpdatePB), counter);
            }
            Invoke(new delvoidBitmap(UpdateImage), image._modImage);
            Invoke(new delvoidInt(UpdatePB), 0);
        }

        private void RB_Tint_CheckedChanged(object sender, EventArgs e)
        {
            // set and changes the labels to the correct indication
            if(RB_Tint.Checked)
            {
                label1.Text = "Red";
                label2.Text = "Green";
            }
            else
            {
                label1.Text = "Less";
                label2.Text = "More";
            }
        }
    }
}
