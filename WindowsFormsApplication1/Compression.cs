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

        public Bitmap YCbCrYoRGB(Bitmap imgY, Bitmap imgCb, Bitmap imgCr)
        {
            int w = imgY.Width;
            int h = imgY.Height;
            Bitmap RGB = new Bitmap(w, h);
            Color pxl;
            int Y, Cb, Cr, R, G, B;

            for(int i=0;i<w;i++)
                for(int j=0;j<h;j++)
                {
                    Y = imgY.GetPixel(i, j).R;
                    Cb = imgCb.GetPixel(i, j).G;
                    Cr = imgCr.GetPixel(i, j).R;

                    R = (int)(298.082 * Y / 256 + 408.583 * Cr / 256 - 222.921);
                    G = (int)(298.082 * Y / 256 - 100.291 * Cb / 256 - 208.120 * Cr / 256 + 135.576);
                    B = (int)(298.082 * Y / 256 + 516.412 * Cb / 256 - 276.836);

                    pxl = Color.FromArgb((byte)R, (byte)G, (byte)B);
                    RGB.SetPixel(i, j, pxl);

                }

            return RGB;

        }


        public Bitmap hoar(Bitmap img, out int[,] map)
        {
            int w = img.Width;
            int h = img.Height;
            map = new int[w, h];
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
                        file.Write(map[i, j] + " ");
                    }
                    file.WriteLine("");

                }
                file.Close();
            }
            //
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
          new System.IO.StreamWriter(@"C:\cool\es2.txt", true))
            {
                file.WriteLine("--------------------");

                for (int i = 0; i < w; i++)
                {
                    for (int j = 0; j < h; j++)
                    {
                        file.Write(map[i, j] + " ");
                    }
                    file.WriteLine("");

                }
                file.Close();
            }
            // for columns
            for (int i = 0; i < w; i++)
            {
                int[] s = new int[h];
                int ind = 0;
                for (int j = 0; j < h; j += 2)
                {
                    s[ind] = map[j, i] + map[j+1, i];
                    ind++;
                }
                for (int j = 0; j < h; j += 2)
                {
                    s[ind] = map[j, i] - map[j+1, i];
                    ind++;
                }
                ind = 0;
                for (int j = 0; j < w; j++)
                    map[j, i] = s[j];

            }

            using (System.IO.StreamWriter file =
           new System.IO.StreamWriter(@"C:\cool\es2.txt", true))
            {
                file.WriteLine("------------------++++++-----------------");
                for (int i = 0; i < w; i++)
                {
                    for (int j = 0; j < h; j++)
                    {
                        file.Write(String.Format("{0,5:0}", map[i, j]));
                    }
                    file.WriteLine("");
                }
                file.Close();
            }

            Bitmap b = new Bitmap(w, h);
            float pp;
            for (int i = 0; i < w; i++)
                for (int j = 0; j < h; j++)
                {
                    
                    pp = map[i, j]/4.0F;
                    float eps = 25F;
                    if (Math.Abs(pp) <= eps) pp = 0; // compression!?!?!
                    pp = (255 + pp) % 255;
                   // if (pp <= 0.5) pp = 0; // compression!?!?!
                    //b.SetPixel(i, j, Color.FromArgb((int)pp, (int)pp, (int)pp));
                    b.SetPixel(i, j, Color.FromArgb((int)pp, (int)pp, (int)pp));

                }
            return b;
        }
        //override recursion hoar
        public double[,] hoar(double[,] map, int w, int h)
        { 
            int min_w, min_h;
            min_w = 128;
            min_h = 128;   
 
            for (int i = 0; i < w; i++)
            {
                double[] s = new double[w];
                int ind = 0;
                for (int j = 0; j < w; j += 2)
                {
                    s[ind] = ( map[i, j] + map[i, j + 1])/2.0;
                    ind++;
                }
                for (int j = 0; j < w; j += 2)
                {
                    s[ind] = ( map[i, j] - map[i, j + 1] )/2.0;
                    ind++;
                }
                ind = 0;
                for (int j = 0; j < w; j++)
                    map[i, j] = s[j];

            }
          
            // for columns
            for (int i = 0; i < w; i++)
            {
                double[] s = new double[h];
                int ind = 0;
                for (int j = 0; j < h; j += 2)
                {
                    s[ind] = ( map[j, i] + map[j + 1, i])/2.0;
                    ind++;
                }
                for (int j = 0; j < h; j += 2)
                {
                    s[ind] = ( map[j, i] - map[j + 1, i] )/2.0;
                    ind++;
                }
                ind = 0;
                for (int j = 0; j < w; j++)
                    map[j, i] = s[j];

            }

            if(w > min_w)
            {
                double[,]  res = hoar(map, w / 2, h / 2);  
                return res;
            }
            return map;
        }
        //
        public double[,] BitmapToDoubleArr(Bitmap img)
        {
            int w = img.Width;
            int h = img.Height;
            double[,] map = new double[w, h];

            Color p;
            for (int i = 0; i < w; i++)
                for (int j = 0; j < h; j++)
                {
                    p = img.GetPixel(i, j);
                    map[i, j] = p.R; // they equal: R=G=B
                }
            return map;
        }
        //
        public Bitmap DoubleArrToBitmapCompression(double[,] map)
        {
            int w = map.GetLength(0);
            int h = w;
            Bitmap b = new Bitmap(w, h);
            double pp;
            for (int i = 0; i < w; i++)
                for (int j = 0; j < h; j++)
                {
                    pp = map[i, j];
                    double eps = 1.0;
                    if (Math.Abs(pp) <= eps) pp = 0; // compression!?!?!
                    pp = (255 + pp) % 255;
                    // if (pp <= 0.5) pp = 0; // compression!?!?!
                    //b.SetPixel(i, j, Color.FromArgb((int)pp, (int)pp, (int)pp));
                    b.SetPixel(i, j, Color.FromArgb((int)pp, (int)pp, (int)pp));
                }
            return b;
        }
        //

        //override only by bitmap
        public Bitmap reverthoar(Bitmap img)
        {

            int w = img.Width;
            int h = img.Height;
            int[,] map = new int[w, h];
            Color p;
            
            for (int i = 0; i < w; i++)
                for (int j = 0; j < h; j++)
                {
                    p = img.GetPixel(i, j);
                    map[i, j] = (p.R * 4);
                }
            //
            // for columns
            for (int i = 0; i < w; i++)
            {
                int[] s = new int[h];
                int ind = 0;
                for (int j = 0; j < h / 2; j++)
                {
                    s[ind] = (map[j, i] + map[j + h / 2, i]) / 2;
                    s[ind + 1] = (map[j, i] - map[j + h / 2, i]) / 2;
                    ind += 2;
                }
                ind = 0;
                for (int j = 0; j < w; j++)
                    map[j, i] = s[j];

            }
            //for rows
            for (int i = 0; i < w; i++)
            {
                int[] s = new int[h];
                int ind = 0;
                for (int j = 0; j < h / 2; j++)
                {
                    s[ind] = (map[i, j] + map[i, j + h / 2]) / 2;
                    s[ind + 1] = (map[i, j] - map[i, j + h / 2]) / 2;
                    ind += 2;
                }
                ind = 0;
                for (int j = 0; j < w; j++)
                    map[i, j] = s[j];

            }
            //
            using (System.IO.StreamWriter file =
         new System.IO.StreamWriter(@"C:\cool\es2.txt", true))
            {
                file.WriteLine("------------------+++%%%*****%%%+++-----------------");
                for (int i = 0; i < w; i++)
                {
                    for (int j = 0; j < h; j++)
                    {
                        file.Write(String.Format("{0,5:0}", (byte)map[i, j]));
                    }
                    file.WriteLine("");
                }
                file.Close();
            }
            //

            Bitmap b = new Bitmap(w, h);
            float pp;
            for (int i = 0; i < w; i++)
                for (int j = 0; j < h; j++)
                {

                    pp = map[i, j];
                    
                    //pp = (255 + pp) % 255;

                    b.SetPixel(i, j, Color.FromArgb((byte)pp, (byte)pp, (byte)pp));

                }
            return b;
        }
        //
        //
        // recursion!!!
        public double[,] reverthoar(double[,] map, int w, int h)
        {
            int end = 0;

                // for columns
                for (int i = 0; i < w; i++)
                {
                    double[] s = new double[h];
                    int ind = 0;
                    for (int j = 0; j < h / 2; j++)
                    {
                        s[ind] = (map[j, i] + map[j + h / 2, i]);
                        s[ind + 1] = (map[j, i] - map[j + h / 2, i]);
                        ind += 2;
                    }
                    ind = 0;
                    for (int j = 0; j < w; j++)
                        map[j, i] = s[j];

                }
                //for rows
                for (int i = 0; i < w; i++)
                {
                    double[] s = new double[h];
                    int ind = 0;
                    for (int j = 0; j < h / 2; j++)
                    {
                        s[ind] = (map[i, j] + map[i, j + h / 2]) ;
                        s[ind + 1] = (map[i, j] - map[i, j + h / 2]);
                        ind += 2;
                    }
                    ind = 0;
                    for (int j = 0; j < w; j++)
                        map[i, j] = s[j];
                }
                //

                if(w*2 > map.GetLength(0))
                {
                    return map;
                }
                double[,] res = reverthoar(map, w * 2, h * 2);
                return res;
            }
        public Bitmap ArrDoubleToBitmapDecompress(double[,] map)
        {
            int w = map.GetLength(0);
            int h = w;

            Bitmap b = new Bitmap(w, h);
            double pp;
            for (int i = 0; i < w; i++)
                for (int j = 0; j < h; j++)
                {
                    pp = map[i, j];
                    //pp = (255 + pp) % 255;
                    b.SetPixel(i, j, Color.FromArgb((byte)pp, (byte)pp, (byte)pp)); //!!!
                }
            return b;
        }
        public Bitmap hoar_recu(Bitmap img)
        {
            double[,] map = BitmapToDoubleArr(img);
            int w = map.GetLength(0);
            int h = w;
            double[,] wvlt = hoar(map, w, h);
            Bitmap res = DoubleArrToBitmapCompression(wvlt);
            return res;
        }
        //
        public Bitmap revert_hoar_recu(Bitmap img)
        {
            double[,] map = BitmapToDoubleArr(img);
          
            double[,] wvlt_decomp = reverthoar(map, 128, 128);
            Bitmap res = ArrDoubleToBitmapDecompress(wvlt_decomp);
            return res;
        }
    }
}
