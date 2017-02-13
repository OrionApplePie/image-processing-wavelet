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
        // Класс. реализующий методы для компресии битмап изображения
        // с помощью Вейвлет-Преобразования Хоара (ВПХ)

        public Compression()
        {
        }

        // размер до которого рекурсивно работает метод преобр. Хоара
        const int MIN_BLOCK = 128;
        // граница, значения меньше которой приравниваются к 0, лучше поставить =1
        const double EPS_COMPRESS = 0.05;

        //метод извлекающий RGB каналы из битмапа в массив 3х бимапов 
        public Bitmap[] PicToRGBchannels(Bitmap img)
        {
            // array of 3 bitmaps: 0 - Red, 1 - Green and 2 - Blue
            //создание массива из 3х битмапов, соотв. 3х каналам R, G и B
            Bitmap[] channels = new Bitmap[3];
            for(int i=0;i<3;i++)
                channels[i] = new Bitmap(img.Width, img.Height);
            
            Color cPix;

            int width = img.Width;
            int heigth = img.Height;

            // проходимся по картинк/е и извлекаем компоненты пикселей (R, G, B)
            // и сохраняем в соответсвующий битмап из массива
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
        
        
        //метод преобразования RGB каналов в 1 битмап
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
        
        
        //метод извлечения компонент Y, Cb и Cr 
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
            Color pix;
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

                        nPix = Color.FromArgb(Y, Y, Y);
                        components[0].SetPixel(i, j, nPix);

                        nPix = Color.FromArgb(Cb, Cb, Cb);
                        components[1].SetPixel(i, j, nPix);

                        nPix = Color.FromArgb(Cr, Cr, Cr);
                        components[2].SetPixel(i, j, nPix);
                }

            return components;
        }
        
        // метод который собирает из компонент Y, Cb и Cr RGB-битмап
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

        // Метод создает 2мерный массив из битмапа.
        // R, G и B значения предполагаются равными (битмап - это YCbCr разложения)
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

        // Метод реализующий вейвлет преобразование Хоара. Рекурсивный.
        // w и h - соответствуют ширине и высоте в пикселях исходного изображения.
        // Текущая версия работает только при w = h, и w и h должны быть степенями двойки ( 128, 25, 512  и тд).
        // Битмап предварительно необходимо перевести в двумерныц массив чисел типа double.
        // 
        public double[,] hoar(double[,] map, int w, int h)
        { 
            // указыают когда закончить рекурсивно обрабатывать массив
            
            int min_w, min_h;
            min_w = MIN_BLOCK;
            min_h = MIN_BLOCK;   
                 
            //вычисление полусумм и полуразностей соглсно формулам
            //проход по строкам

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
          
            // проход по столбцам
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

            // если размер все еще больше минимального - то продолжить рекурсивный вызов
            if(w > min_w)
            {
                //передать массив и половины ширины и высоты ( согласно алгоритму ВПХ )
                double[,]  res = hoar(map, w / 2, h / 2);
                // и вернуть   
                return res;
            }
            // иначе вернуть вычисленное в циклах выше
            return map;
        }

       
        // Метод который создает битмап из 2-мерного массива чисел типа double.
        // Все элементы которые по модулю меньше EPS_COMPRESS заменяются нулем.
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
                    double eps = EPS_COMPRESS;
                    if (Math.Abs(pp) <= eps) pp = 0; // compression!?!?!

                    // На случай если значение отрицательное
                    //pp = (255 + pp) % 255;

                    // b.SetPixel(i, j, Color.FromArgb((int)pp, (int)pp, (int)pp));
                    b.SetPixel(i, j, Color.FromArgb((byte)pp, (byte)pp, (byte)pp));

                }
            return b;
        }

        // Метод реализующий обратное преобразование Хоара.
        // При первом вызове передаются миниальные размеры.
        public double[,] reverthoar(double[,] map, int w, int h)
        {
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
    
                if(w*2 > map.GetLength(0))
                {
                    return map;
                }
                double[,] res = reverthoar(map, w * 2, h * 2);
                return res;
            }

        // Метод преобразующий массив в битмап. Применяется после обратного ВПХ.

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
                    b.SetPixel(i, j, Color.FromArgb((byte)pp, (byte)pp, (byte)pp));
                }
            return b;
        }

        // Методы где собраны все методы для компрессии и декомпрессии.

        // Компрессия. Принимает на вход одну из компонент YCbCR-разложения и
        // применяет ВПХ. На выходе битмап.
        public Bitmap hoar_recu(Bitmap img)
        {
            double[,] map = BitmapToDoubleArr(img);
            int w = map.GetLength(0);
            int h = w;
            double[,] wvlt = hoar(map, w, h);
            Bitmap res = DoubleArrToBitmapCompression(wvlt);
            return res;
        }

        // Декомпрессия.
        public Bitmap revert_hoar_recu(Bitmap img)
        {
            double[,] map = BitmapToDoubleArr(img); 
            double[,] wvlt_decomp = reverthoar(map, MIN_BLOCK, MIN_BLOCK);
            Bitmap res = ArrDoubleToBitmapDecompress(wvlt_decomp);
            return res;
        }
    }
}
