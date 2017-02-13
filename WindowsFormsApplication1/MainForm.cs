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
using System.IO;
using System.IO.Compression;
using System.Drawing.Imaging;
using Ionic.Zip;

namespace WindowsFormsApplication1
{
    public partial class MainForm : Form
    {
        // подготовка объектов и для работы с выводом картинок
        string fileName;
        Bitmap picOriginal, picRes;
        Graphics gPicOriginal, gRGBchannel_R, gRGBchannel_G, gRGBchannel_B, gPicRes;
        Graphics gYCbCr_1, gYCbCr_2, gYCbCr_3;
        Graphics gWavelet_1, gWavelet_2, gWavelet_3;

        Bitmap W1 = null;
        Bitmap W2, W3;

        Bitmap[] RGBchannels = new Bitmap[3];
        Bitmap[] YcbCrComponents;

        int[,] map1, map2, map3;
        private static string directoryPath = @"c:\cool\tmp\";

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //
        public static void Compress(DirectoryInfo directorySelected)
        {
            foreach (FileInfo fileToCompress in directorySelected.GetFiles())
            {
                using (FileStream originalFileStream = fileToCompress.OpenRead())
                {
                    if ((File.GetAttributes(fileToCompress.FullName) &
                       FileAttributes.Hidden) != FileAttributes.Hidden & fileToCompress.Extension != ".gz")
                    {
                        using (FileStream compressedFileStream = File.Create(fileToCompress.FullName + ".gz"))
                        {
                            using (GZipStream compressionStream = new GZipStream(compressedFileStream,
                               CompressionMode.Compress))
                            {
                                originalFileStream.CopyTo(compressionStream);

                            }
                        }
                        //FileInfo info = new FileInfo(directoryPath + "\\" + fileToCompress.Name + ".gz");
                       
                    }

                }
            }
        }

        private void buttonYCbCr_recov_Click(object sender, EventArgs e)
        {
            if (YcbCrComponents[0] != null)
            {
                picRes = comp.YCbCrYoRGB(YcbCrComponents[0], YcbCrComponents[1], YcbCrComponents[2]);
                gPicRes.DrawImage(picRes, 0, 0, pbResult.Width, pbResult.Height);
            }
        }

        private void buttonWaveletDecompress_Click(object sender, EventArgs e)
        {
            if (W1 != null)
            {
                YcbCrComponents[0] = comp.revert_hoar_recu(W1);
                YcbCrComponents[1] = comp.revert_hoar_recu(W2);
                YcbCrComponents[2] = comp.revert_hoar_recu(W3);
          
                //YcbCrComponents[0].Save(@"C:\cool\YCbCr_compon1_after_decomp.bmp");
     
                gYCbCr_1.DrawImage(YcbCrComponents[0], 0, 0, pbYCbCr_1.Width, pbYCbCr_1.Height);
                gYCbCr_2.DrawImage(YcbCrComponents[1], 0, 0, pbYCbCr_2.Width, pbYCbCr_2.Height);
                gYCbCr_3.DrawImage(YcbCrComponents[2], 0, 0, pbYCbCr_3.Width, pbYCbCr_3.Height);
            }
        }

        Compression comp = new Compression();

        private void buttonWaveletCompress_Click(object sender, EventArgs e)
        {
            //YcbCrComponents[0].Save(@"C:\cool\YcbCr_compon1.bmp");

            W1 = comp.hoar_recu(YcbCrComponents[0]);
            W2 = comp.hoar_recu(YcbCrComponents[1]);
            W3 = comp.hoar_recu(YcbCrComponents[2]);

            gWavelet_1.DrawImage(W1, 0, 0, pbWavelet_1.Width, pbWavelet_1.Height);
            gWavelet_2.DrawImage(W2, 0, 0, pbWavelet_2.Width, pbWavelet_2.Height);
            gWavelet_3.DrawImage(W3, 0, 0, pbWavelet_3.Width, pbWavelet_3.Height);
            // prepear archive zip file
            
            W1.Save(@"C:\cool\tmp\wavelet1.bmp", ImageFormat.Bmp);
            W2.Save(@"C:\cool\tmp\wavelet2.bmp", ImageFormat.Bmp);
            W3.Save(@"C:\cool\tmp\wavelet3.bmp", ImageFormat.Bmp);
    
            using (ZipFile zip = new ZipFile())
            {
                zip.AddDirectory(@"C:\cool\tmp\");
                zip.Save(@"C:\cool\compressed_image.zip");
                long zipsize;
                var ms = new MemoryStream();
                zip.Save(ms);
                zipsize = ms.Length;
                // calculate original bitmap size in bytes          
                long orig_size = picOriginal.Width * picOriginal.Height * 3;
                textBox1.Text = Convert.ToString((double)orig_size/zipsize);
            }
        }


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

            gWavelet_1 = pbWavelet_1.CreateGraphics();
            gWavelet_2 = pbWavelet_2.CreateGraphics();
            gWavelet_3 = pbWavelet_3.CreateGraphics();

            gPicOriginal.Clear(bg_col);
            gPicRes.Clear(bg_col);

            gRGBchannel_R.Clear(bg_col);
            gRGBchannel_G.Clear(bg_col);
            gRGBchannel_B.Clear(bg_col);

            gYCbCr_1.Clear(bg_col);
            gYCbCr_2.Clear(bg_col);
            gYCbCr_3.Clear(bg_col);

            gWavelet_1.Clear(bg_col);
            gWavelet_2.Clear(bg_col);
            gWavelet_3.Clear(bg_col);
            
        }

        private void buttonYCbCr_conv_Click(object sender, EventArgs e)
        {
            if (RGBchannels != null)
            {
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

        private void buttonLoadImage_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog1.FileName;
                picOriginal = new Bitmap(fileName);
                gPicOriginal.DrawImage(picOriginal, 0, 0, pbLoad.Width, pbLoad.Height);
                tbImagePath.Text = fileName;
            }

        }

        private void buttonRGBconv_Click(object sender, EventArgs e)
        {
            if (picOriginal != null)
            {
                RGBchannels = comp.PicToRGBchannels(picOriginal);

                Thread t = new Thread(new ThreadStart(delegate {
                    for (int i = 0; i < 100; ++i)
                    {
                        this.Invoke(new ThreadStart(delegate
                        { 
                            //ProgressBar1.Value++;
                        }));
                       
                    }
                }));
                t.Start();

                gRGBchannel_R.DrawImage(RGBchannels[0], 0, 0, pbRGB_R.Width, pbRGB_R.Height);
                gRGBchannel_G.DrawImage(RGBchannels[1], 0, 0, pbRGB_G.Width, pbRGB_G.Height);
                gRGBchannel_B.DrawImage(RGBchannels[2], 0, 0, pbRGB_B.Width, pbRGB_B.Height);

            }
        }
    }
}
