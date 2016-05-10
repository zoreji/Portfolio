/******************************************************************************************************************
*       Author:       Ervin Hernandez
*       Class:        CMPE 2300
*       Programme:    Decoding Image
*       File:         ehernandezLab01.cs
*       Assignment:   Lab01
*       Date:         2015/09/30
*******************************************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ehernandezLab01
{
    /// <summary>
    /// Object of the Programme is to obtain a sample image and decode the image into
    /// various colors that are avaliable to the user
    /// and output a different image in the color provided in the programme
    /// </summary>
    public partial class Form1 : Form
    {
        PicData bitPic;
        public Form1()
        {
            InitializeComponent();
        }
        /// <PicData>
        /// Store and contains the loaded image to a struct
        /// and also retains the modded image that have been alter by 
        /// the program
        /// </PicData>
        public struct PicData
        {
            public Bitmap _image;
            public Bitmap _modImage;
            public PicData(Bitmap ModImage, Bitmap image)
            {
                _modImage = ModImage;
                _image = image;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Decode_Image_CB.Items.Add("All");
            Decode_Image_CB.Items.Add("Red");
            Decode_Image_CB.Items.Add("Green");
            Decode_Image_CB.Items.Add("Blue");
        }

        private void Decode_TL_Click(object sender, EventArgs e)
        {
           switch(Decode_Image_CB.SelectedText)
            {
                case "All":
                    AllConverter(bitPic);
                    break;
                case "Red":
                    RedConverter(bitPic);
                    break;
                case "Green":
                    GreenConverter(bitPic);
                    break;
                case "Blue":
                    BlueConverter(bitPic);
                    break;
            }

        }
        /// <LoadImage_TL_Click>
        /// opens a browser to obtain the sample image and 
        /// load it to the struct PicData into the main, original
        /// image.
        /// </LoadImage_TL_Click>
        private void LoadImage_TL_Click(object sender, EventArgs e)
        {
            if (OFD_LoadPic.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    bitPic = new PicData((Bitmap)(Bitmap.FromFile(OFD_LoadPic.FileName)), (Bitmap)(Bitmap.FromFile(OFD_LoadPic.FileName)));
                    PicBox_main.Image = bitPic._image;
                }
                catch
                {
                    MessageBox.Show("Cannot Load File", "Loading Error");
                }
            }
        }
        /// <bit_check>
        /// The method ask for a pixel/ bit and does an 
        /// bitoperator AND with the mask to able the LSB
        /// of the pixel/bit that have been provided.
        /// </bit_check>
        /// <param name="bit">
        /// Ask for the pixel value in a form of a integer
        /// </param>
        /// <returns>
        /// A boolean return whether or not the pixel/ bit is a 0 or a 1
        /// </returns>
        private bool bit_check(int bit)
        {
            byte Mask = 0x01;
            return ((bit & Mask) == 1);
        }
        /// <RedConverter>
        /// A converter that changes each of the pixel to new color by going throught the bit_check method 
        /// once it individually check each pixel it will save the modded picture to the _modImage in the 
        /// PicData struct (which it is pass throught)
        /// </RedConverter>
        /// <param name="pic">
        /// Ask for the struct pic to obtain the original and modded image in the container
        /// </param>
        private void RedConverter(PicData pic)
        {
            Color pixel;
            for (int x = 0; x < pic._image.Width; ++x)
            {
                for (int y = 0; y < pic._image.Height; ++y)
                {
                    pixel = pic._image.GetPixel(x, y);
                    if (bit_check(pixel.R))
                        pic._modImage.SetPixel(x, y, Color.Red);
                    else
                        pic._modImage.SetPixel(x, y, Color.Black);
                }
            }
            PicBox_main.Image = pic._modImage;
        }
        private void BlueConverter(PicData pic)
        {
            Color pixel;
            for (int x = 0; x < pic._image.Width; ++x)
            {
                for (int y = 0; y < pic._image.Height; ++y)
                {
                    pixel = pic._image.GetPixel(x, y);
                    if (bit_check(pixel.B))
                        pic._modImage.SetPixel(x, y, Color.Blue);
                    else
                        pic._modImage.SetPixel(x, y, Color.Black);
                }
            }
            PicBox_main.Image = pic._modImage;
        }
        private void GreenConverter(PicData pic)
        {
            Color pixel;
            for (int x = 0; x < pic._image.Width; ++x)
            {
                for (int y = 0; y < pic._image.Height; ++y)
                {
                    pixel = pic._image.GetPixel(x, y);
                    if (bit_check(pixel.G))
                        pic._modImage.SetPixel(x, y, Color.Green);
                    else
                        pic._modImage.SetPixel(x, y, Color.Black);
                }
            }
            PicBox_main.Image = pic._modImage;
        }
        /// <AllConverter>
        /// Similar to the color converter, the all converter converts each pixel to a preset value color
        /// using the bit_check, it check each pixel for LSB with the value of the pixel that sent through
        /// and alter the picture
        /// </AllConverter>
        /// <param name="pic">
        /// Ask for the struct pic to obtain the original and modded image in the container
        /// </param>
        private void AllConverter(PicData pic)
        {
            Color pixel;
            int b;
            int r;
            int g;
            for (int x = 0; x < pic._image.Width; ++x)
            {
                for (int y = 0; y < pic._image.Height; ++y)
                {
                    b = 0;
                    r = 0;
                    g = 0;
                    pixel = pic._image.GetPixel(x, y);
                        if (bit_check(pixel.R))
                            r = 255;
                        if (bit_check(pixel.B))
                            b = 255;
                        if (bit_check(pixel.G))
                            g = 255;

                    pic._modImage.SetPixel(x, y, Color.FromArgb(r, g, b));
                    
                }
            }
            PicBox_main.Image = pic._modImage;
        }
    }
}
