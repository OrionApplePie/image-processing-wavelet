using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class MainForm : Form
    {
        // подготовка объектов и для работы с выводом картинок
        string fileName;
        Bitmap picOriginal, picRes;
        Graphics gPicOriginal, gRGBchannel_R, gRGBchannel_G, gRGBchannel_B, gPicRes;
        Graphics gYCbCr_1, gYCbCr_2, gYCbCr_3;


        Bitmap[] RGBchannels = new Bitmap[3];

        Compression comp = new Compression();

        private void buttonWaveletCompress_Click(object sender, EventArgs e)
        {
            Bitmap test = comp.hoar(picOriginal);
        }

        //
        public MainForm()
        {
            InitializeComponent();
            Color bg_col = this.BackColor;
             
            gPicOriginal = pbLoad.CreateGraphics();
            gPicRes = pbResult.CreateGraphics();

            gYCbCr_1 = pbYCbCr_1.CreateGraphics();
            gYCbCr_2 = pbYCbCr_2.CreateGraphics();
            gYCbCr_3 = pbYCbCr_3.CreateGraphics();


            gRGBchannel_R = pbRGB_R.CreateGraphics();
            gRGBchannel_G = pbRGB_G.CreateGraphics();
            gRGBchannel_B = pbRGB_B.CreateGraphics();

            gPicOriginal.Clear(bg_col);
            gPicRes.Clear(bg_col);

            gRGBchannel_R.Clear(bg_col);
            gRGBchannel_G.Clear(bg_col);
            gRGBchannel_B.Clear(bg_col);

            gYCbCr_1.Clear(bg_col);
            gYCbCr_2.Clear(bg_col);
            gYCbCr_3.Clear(bg_col);

        }

        private void buttonYCbCr_conv_Click(object sender, EventArgs e)
        {
            if (RGBchannels != null)
            {
                Bitmap[] YcbCrComponents;// = new Bitmap[3];
                //for (int i = 0; i < 3; i++)
                //    YcbCrComponents[i] = new Bitmap(picOriginal.Width, picOriginal.Height);

                YcbCrComponents = comp.RGBtoYCbCr(picOriginal);
                gYCbCr_1.DrawImage(YcbCrComponents[0], 0, 0, pbYCbCr_1.Width, pbYCbCr_1.Height);
                gYCbCr_2.DrawImage(YcbCrComponents[1], 0, 0, pbYCbCr_2.Width, pbYCbCr_2.Height);
                gYCbCr_3.DrawImage(YcbCrComponents[2], 0, 0, pbYCbCr_3.Width, pbYCbCr_3.Height);

            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonRGBrecov_Click(object sender, EventArgs e)
        {
            if (RGBchannels[0] != null)
            {
                picRes = comp.RGBchannelsToPic(RGBchannels);
                gPicRes.DrawImage(picRes, 0, 0, pbResult.Width, pbResult.Height);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void buttonLoadImage_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog1.FileName;
                picOriginal = new Bitmap(fileName);
                gPicOriginal.DrawImage(picOriginal, 0, 0, pbLoad.Width, pbLoad.Height);
            }

        }

        private void buttonRGBconv_Click(object sender, EventArgs e)
        {
            if (picOriginal != null)
            {
                RGBchannels = comp.PicToRGBchannels(picOriginal);
                gRGBchannel_R.DrawImage(RGBchannels[0], 0, 0, pbRGB_R.Width, pbRGB_R.Height);
                gRGBchannel_G.DrawImage(RGBchannels[1], 0, 0, pbRGB_G.Width, pbRGB_G.Height);
                gRGBchannel_B.DrawImage(RGBchannels[2], 0, 0, pbRGB_B.Width, pbRGB_B.Height);
            }
        }
    }
}
