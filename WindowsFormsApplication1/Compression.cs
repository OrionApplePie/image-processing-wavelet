using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApplication1
{
    class Compression
    {
        public Compression()
        {

        }

        public Bitmap[] PicToRGBchannels(Bitmap img)
        {
            // array of 3 bitmaps: 0 - Red, 1 - Green and 2 - Blue

            Bitmap[] channels = new Bitmap[3];
            for(int i=0;i<3;i++)
                channels[i] = new Bitmap(img.Width, img.Height);
            
            Color cPix;

            int width = img.Width;
            int heigth = img.Height;

            for(int i=0;i<width;i++)
                for(int j=0;j<heigth;j++)
                {
                    cPix = img.GetPixel(i, j);
                    Color nPixR, nPixG, nPixB;
                    nPixR = Color.FromArgb(cPix.R, 0, 0);
                    nPixG = Color.FromArgb(0, cPix.G, 0);
                    nPixB = Color.FromArgb(0, 0, cPix.B);

                    channels[0].SetPixel(i, j, nPixR);
                    channels[1].SetPixel(i, j, nPixG);
                    channels[2].SetPixel(i, j, nPixB);
                }     
            return channels;
        }
        public Bitmap RGBchannelsToPic(Bitmap[] channels)
        {
            int w = channels[0].Width;
            int h = channels[0].Height;

            Bitmap img = new Bitmap(w, h);
            Color PixR, PixG, PixB;

            for(int i=0;i<w;i++)
                for(int j=0;j<h;j++)
                {
                    PixR = channels[0].GetPixel(i, j);
                    PixG = channels[1].GetPixel(i, j);
                    PixB = channels[2].GetPixel(i, j);
                    Color nPix;
                    nPix = Color.FromArgb(PixR.R, PixG.G, PixB.B);
                    img.SetPixel(i, j, nPix);
                }

            return img; 
        }
        //
        public Bitmap[] RGBtoYCbCr(Bitmap img)
        {
            int w = img.Width;
            int h = img.Height;
            Bitmap YCbCr = new Bitmap(w, h);

            // array for YCrCb components
            Bitmap[] components = new Bitmap[3];
            for (int i = 0; i < 3; i++)
                components[i] = new Bitmap(w, h);

            // ITU-R BT.601
            Color pix, pixG, pixB;
            byte Y, Cb, Cr;

            for(int i=0;i<w;i++)
                for(int j=0;j<h;j++)
                {
       
                        pix = img.GetPixel(i, j);

                        Color nPix;
                        // used R' G' and B' - div 255
                        Y = Convert.ToByte(16 + (65.481 * ((double)pix.R / 255.0)     + 128.553 * ((double)pix.G / 255.0) + 24.966 * ((double)pix.B / 255.0)));
                        Cb = Convert.ToByte(128 + (-37.797 * ((double)pix.R / 255.0)  - 74.203 * ((double)pix.G / 255.0) + 112.0 * ((double)pix.B / 255.0)));
                        Cr = Convert.ToByte(128 + (112.0 * ((double)pix.R / 255.0)    - 93.768 * ((double)pix.G / 255.0) - 18.214 * ((double)pix.B / 255.0)));


                        //Y = (byte)(0 + (0.299 * pix.R + 0.587 * pix.G + 0.114 * pix.B));
                        //Cb = (byte)(128 -  (0.168736 * pix.R - 0.331264 * pix.G + 0.5 * pix.B));
                        //Cr = (byte)(128 + (0.5 * pix.R - 0.418688 * pix.G - 0.081312 * pix.B));

                        nPix = Color.FromArgb(Y, Y, Y);
                        components[0].SetPixel(i, j, nPix);

                        nPix = Color.FromArgb(Cb, Cb, Cb);
                        components[1].SetPixel(i, j, nPix);

                        nPix = Color.FromArgb(Cr, Cr, Cr);
                        components[2].SetPixel(i, j, nPix);
                }

            return components;
        }
        //
        public Bitmap hoar(Bitmap img)
        {
            int w = img.Width;
            int h = img.Height;
            int[,] map = new int[w, h];
            Color p;

            for (int i = 0; i < w; i++)
                for (int j = 0; j < h; j++)
                {
                    p = img.GetPixel(i, j);
                    map[i, j] = p.R;
                }
            //
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"C:\cool\es2.txt"))
            {

                for (int i = 0; i < w; i++)
                {
                    for (int j = 0; j < h; j++)
                    {
                        file.Write(map[i, j] + "   ");
                    }
                    file.Write("\n");

                }
            }
            //
            for (int i = 0; i < w; i++)
            {
                int[] s = new int[w];
                int tmp;
                int ind = 0;
                for (int j = 0; j < w; j+=2)
                {
                    s[ind] = map[i, j] + map[i, j + 1];
                    ind++;
                }
                for (int j = 0; j < w; j += 2)
                { 
                    s[ind] = map[i, j] - map[i, j + 1];
                    ind++;
                }
                ind = 0;
                for(int j =0; j<w;j++)
                    map[i,j] = s[j];

            }
            using (System.IO.StreamWriter file =
           new System.IO.StreamWriter(@"C:\cool\es2.txt"))
            {

                for (int i = 0; i < w; i++)
                {
                    for (int j = 0; j < h; j++)
                    {
                        file.Write(map[i, j] + "   ");
                    }
                    file.Write("\n");

                }
            }
            Bitmap b = new Bitmap(1, 1);
            return b;
        }

    }
}
