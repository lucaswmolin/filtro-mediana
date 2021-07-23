using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCT2
{
    public class ImageProcessor
    {
        public int threadCount { get; set; }
        public int maskSize { get; set; }
        private Score score { get; set; }

        public Bitmap oldImage { get; set; }
        public Bitmap newImage { get; set; }

        Color[][] oldArray { get; set; }
        Color[][] newArray { get; set; }

        public String ChooseFile()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    score = new Score();

                    LoadFileToMemory(openFileDialog.FileName);

                    return openFileDialog.FileName;
                }
                else
                {
                    throw new Exception("Ocorreu uma falha ao tentar encontrar o arquivo.");
                }
            }
        }

        public void LoadFileToMemory(string path)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            oldImage = new Bitmap(path);
            newImage = oldImage.Clone(new Rectangle(0, 0, oldImage.Width, oldImage.Height), PixelFormat.Format32bppRgb);

            oldArray = new Color[oldImage.Height][];
            for (int i = 0; i < oldImage.Height; i++)
            {
                oldArray[i] = new Color[oldImage.Width];
            }

            newArray = new Color[newImage.Height][];
            for (int i = 0; i < newImage.Height; i++)
            {
                newArray[i] = new Color[newImage.Width];
            }

            for (int i = 0; i < oldImage.Height; i++)
            {
                for (int j = 0; j < oldImage.Width; j++)
                {
                    oldArray[i][j] = oldImage.GetPixel(j, i);
                }
            }

            for (int i = 0; i < newImage.Height; i++)
            {
                for (int j = 0; j < newImage.Width; j++)
                {
                    newArray[i][j] = newImage.GetPixel(j, i);
                }
            }

            stopwatch.Stop();

            score.readFile = stopwatch.ElapsedMilliseconds;
        }

        public void ProcessImage()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            int nThreads = threadCount;
            int height = oldImage.Height;
            int piece = height / nThreads;
            int add = height % nThreads;

            int start = 0;
            int end = piece - 1;

            List<ThreadParameters> listThreadParameters = new List<ThreadParameters>();
            for (var i = 1; i <= nThreads; i++)
            {
                if (i == nThreads)
                {
                    end += add;
                }

                ThreadParameters tf = new ThreadParameters(start, end);
                listThreadParameters.Add(tf);

                start += piece;
                end += piece;
            }

            List<Thread> listThread = new List<Thread>();
            foreach (ThreadParameters t in listThreadParameters)
            {
                Thread thread = new Thread(() => ThreadProcessImage(t.start, t.end));
                listThread.Add(thread);

                thread.Start();
            }

            foreach (Thread t in listThread)
            {
                t.Join();
            }

            stopwatch.Stop();

            score.threadTime = stopwatch.ElapsedMilliseconds;
        }

        public void ThreadProcessImage(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                for (int j = 0; j < oldArray[0].Length; j++)
                {
                    //Gray(i, j);
                    Median(i, j, oldArray.Length, oldArray[0].Length);
                }
            }
        }

        public void Gray(int i, int j)
        {
            Color color = oldArray[i][j];
            
            int gray = (color.R + color.G + color.B) / 3;
            
            Color newColor = Color.FromArgb(gray, gray, gray);
            
            newArray[i][j] = newColor;
        }

        public void Median(int i, int j, int altura, int largura)
        {
            int s = (maskSize - 1) / 2;
            int size = maskSize * maskSize;

            if (isValid(i, j, altura, largura, s))
            {

                List<int> vr = new List<int>();
                List<int> vg = new List<int>();
                List<int> vb = new List<int>();

                int ii = i - s;
                int jj = j - s;
                int im = i + s;
                int jm = j + s;
                for (ii = i - s; ii <= im; ii++)
                {
                    for (jj = j - s; jj <= jm; jj++)
                    {
                        vr.Add(oldArray[ii][jj].R);
                        vg.Add(oldArray[ii][jj].G);
                        vb.Add(oldArray[ii][jj].B);                      
                    }
                }

                vr.Sort();
                vg.Sort();
                vb.Sort();

                int m = size / 2 + size % 2;

                newArray[i][j] = Color.FromArgb(vr[m], vg[m], vb[m]);
            }
            else
            {
                newArray[i][j] = oldArray[i][j];
            }
        }

        bool isValid(int i, int j, int altura, int largura, int s)
        {
            return (i >= s) && (i < (altura - s - 1)) && (j >= s) && (j < (largura - s - 1));
        }

        public Score WriteNewFile()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < newImage.Height; i++)
            {
                for (int j = 0; j < newImage.Width; j++)
                {
                    newImage.SetPixel(j, i, newArray[i][j]);
                }
            }

            string pathDirectory = Directory.GetCurrentDirectory();
            string newFileName = System.IO.Path.GetRandomFileName();
            string newFilePath = pathDirectory + "\\" + newFileName + ".bmp";

            score.path = newFilePath;

            newImage.Save(newFilePath);

            stopwatch.Stop();

            score.writeFile = stopwatch.ElapsedMilliseconds;

            return score;
        }
    }
}
