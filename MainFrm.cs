using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;

namespace Fast_Fourier_Transform
{

    public partial class MainFrm : Form
    {
        public int[,] otvet = new int[256, 256];
        public int[,] ki1 = new int[256, 256];
        public int[,] ki2 = new int[256, 256];
        public int[,] otvetL = new int[256, 256];
        public int[,] ki3 = new int[256, 256];

      public double [,] OpZ = new double[256, 256];
     //   public double[,] Op2 = new double[256, 256];

        public int[,] mt = new int[256, 256];
        public int[,] pt = new int[256, 256];
        public int[,] P1 = new int[256, 256];
        public int[,] M1 = new int[256, 256];
        public int[,] P2 = new int[256, 256];
        public int[,] M2 = new int[256, 256];
        public int[,] keyP = new int[256, 256];
        public int[,] keyM = new int[256, 256];
        public int[,] mtwithKey = new int[256, 256];
        public int[,] ptwithKey = new int[256, 256];

        public int[,] output = new int[256, 256];

        public int[,] OutReal = new int[256, 256];
        public int[,] OutImag = new int[256, 256];
        

        COMPLEX[,] Out1 = new COMPLEX[256, 256];
        COMPLEX[,] Out2 = new COMPLEX[256, 256];
        COMPLEX[,] Out3 = new COMPLEX[256, 256];

        COMPLEX[,] FourierO = new COMPLEX[256, 256];
        COMPLEX[,] outtut = new COMPLEX[256, 256];
        COMPLEX[,] outnew = new COMPLEX[256, 256];

        Bitmap InputImage;
        Bitmap SelectedImage;  //selected Palmprint Image
        Bitmap Selectedopor;
        Bitmap bmp;  // Selected area Bitmap
        Bitmap bmp1;
        Bitmap bmp2;
        Bitmap bmp3;

        public Point current;
        Color mlinecolor;
        FFT ImgFFT;
       
        public int rec_width, rec_height;
        public int scale = 25; // Scaling percentage
        public int WindowSize = 256;  // Dimension of Image Selection Window
        public MainFrm()
        {
            InitializeComponent();
            mlinecolor = Color.Red;
        }
        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            string path;
            OpenFileDialog od = new OpenFileDialog();
            ImageInput.Width = 400;
            ImageInput.Height = 600;
            ImageInput.SizeMode = PictureBoxSizeMode.Normal;
            scale = Convert.ToInt32(scalepercentage.Text);
            rec_width = rec_height = (int)(512 * ((float)scale / 100));
            try
            {
                od.ShowDialog();
                path = od.FileName;
                if (path == "")
                {
                    return;
                }
                InputImage = new Bitmap(path);  //selected Palmprint Image
                ImageInput.SizeMode = PictureBoxSizeMode.AutoSize;
                ImageInput.Image = ScaleByPercent((Image)InputImage, Convert.ToInt32(scalepercentage.Text));
       
                toolStripStatusLabel2.Text = InputImage.Width.ToString() + "  X " + InputImage.Height.ToString();
                toolStripStatusLabel4.Text = ImageInput.Image.Width.ToString() + "  X " + ImageInput.Image.Height.ToString();
            }
            catch (System.ArgumentException)
            {
                MessageBox.Show("Invalid File Type", "Error");
            }

            
        }
        /// <summary>
        /// Scales Image By Given Percentage
        /// </summary>
        /// <param name="imgPhoto"></param>
        /// <param name="Percent"></param>
        /// <returns></returns>
        static Image ScaleByPercent(Image imgPhoto, int Percent)
        {
            float nPercent = ((float)Percent / 100);
            int sourceWidth = imgPhoto.Width;
            int sourceHeight = imgPhoto.Height;
            int sourceX = 0;
            int sourceY = 0;
            int destX = 0;
            int destY = 0;
            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap bmPhoto = new Bitmap(destWidth, destHeight);
            bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);
            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;
            grPhoto.DrawImage(imgPhoto,
            new Rectangle(destX, destY, destWidth, destHeight),
            new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
            GraphicsUnit.Pixel);
            grPhoto.Dispose();
            return bmPhoto;
        }
        private void ImageInput_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            toolTip1.SetToolTip(ImageInput, e.X.ToString() + ", " + e.Y.ToString());
            Pen ppen = new Pen(mlinecolor, 1);
            Graphics g;
            ImageInput.Refresh();
            try
            {
                g = ImageInput.CreateGraphics();
                Rectangle rec = new Rectangle(e.X, e.Y, (int)(WindowSize * Convert.ToInt32(scalepercentage.Text) / 100), (int)(WindowSize * Convert.ToInt32(scalepercentage.Text) / 100));
                g.DrawRectangle(ppen, rec);
                current.X = e.X;
                current.Y = e.Y;
                ppen.Color = Color.Coral;
                g.DrawLine(ppen, ImageInput.Width / 2, ImageInput.Top, ImageInput.Width / 2, ImageInput.Height);
                g.DrawLine(ppen, 0, ImageInput.Height / 2, ImageInput.Width, ImageInput.Height / 2);
                ppen.Color = Color.Azure;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void selectFullImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int x, y, width, height;
            //Code for Preview
            //Application.DoEvents();
            try
            {
                Bitmap temp = (Bitmap)InputImage.Clone();
                width = height = (int)(WindowSize * Convert.ToInt32(scalepercentage.Text) / 100);
                bmp = new Bitmap(width, height, InputImage.PixelFormat);

                x = (int)((float)current.X * (100 / Convert.ToDouble(scalepercentage.Text)));
                y = (int)((float)current.Y * (100 / Convert.ToDouble(scalepercentage.Text)));
                width = height = (int)(rec_width * (100 / (float)scale));
                if (width > WindowSize )
                {
                    width = height = WindowSize;
                }

                Rectangle area = new Rectangle(x, y, width, height);
                bmp = (Bitmap)InputImage.Clone(area, InputImage.PixelFormat);
                SelectedImage = bmp;
            }
            catch (System.OutOfMemoryException ex)
            {
                MessageBox.Show("Select Area Inside Image only : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ImSelected.Image = (Image)SelectedImage;
            //palm_scroll.Picture = (Image)palm_selected;
            toolStripStatusLabel6.Text = ImSelected.Width.ToString() + "  X " + ImSelected.Height.ToString();
            ImSelected.Invalidate();
        }

    

        private void MainFrm_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Finding Forward FFT of Selected Bitmap
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
             //1. Create FFT Object
            ImgFFT = new FFT(bmp);
        
                    ImgFFT.ForwardFFT();// Finding 2D FFT of Image
            ImgFFT.FFTShift();
            for (int i = 0; i < 255; i++)
            {
                for (int j = 0; j < 255; j++)
                {
                    Out1[i,j] = ImgFFT.FFTShifted[i, j];
                   // OutReal[i, j] = (int)ImgFFT.FFTShifted[i, j].real;
                   // OutImag[i, j] = (int)ImgFFT.FFTShifted[i, j].imag;
                }
            }
            
            ImgFFT.FFTPlot(ImgFFT.FFTShifted);
          
            //ImgFFT.InverseFFT();
            for (int i = 0; i < 255; i++)
            {
                for (int j = 0; j < 255; j++)
                {
                  
                    M1[i, j] = ImgFFT.PhasePlot1[i, j];
                    P1[i, j] = ImgFFT.MagniturePlot1[i, j];
                    }
            }
            furiebox1.Image = (Image)ImgFFT.Displayimage(P1);
            //   Dehologram.Image = (Image)ImgFFT.Obj;
           // Dehologram.Image = (Image)ImgFFT.Displayimage(OutReal);

            //furiebox1.Image = (Image)ImgFFT.Displayimage(OutImag);



            ImgFFT = new FFT(bmp1);
            ImgFFT.ForwardFFT();// Finding 2D FFT of Image
            ImgFFT.FFTShift();
            for (int i = 0; i < 255; i++)
            {
                for (int j = 0; j < 255; j++)
                {
                    Out2[i, j] = ImgFFT.FFTShifted[i, j];

                }
            }
           
            ImgFFT.FFTPlot(ImgFFT.FFTShifted);

           
        
            for (int i = 0; i < 255; i++)
            {
                for (int j = 0; j < 255; j++)
                {
                    M2[i, j] = ImgFFT.PhasePlot1[i, j];
                    P2[i, j]=   ImgFFT.MagniturePlot1[i, j] ;
                }
            }
            furiebox2.Image = (Image)ImgFFT.Displayimage(P2);



         






            ImgFFT = new FFT(bmp3);

            ImgFFT.ForwardFFT();// Finding 2D FFT of Image
            ImgFFT.FFTShift();
            for (int i = 0; i < 255; i++)
            {
                for (int j = 0; j < 255; j++)
                {
                    Out3[i, j] = ImgFFT.FFTShifted[i, j];

                }
            }

           
            ImgFFT.FFTPlot(ImgFFT.FFTShifted);


            for (int i = 0; i < 255; i++)
            {
                for (int j = 0; j < 255; j++)
                {

                    keyP[i, j] = ImgFFT.PhasePlot1[i, j];

                    keyM[i, j] = ImgFFT.MagniturePlot1[i, j];
                }
            }



            kMag.Image = (Image)ImgFFT.Displayimage(keyM);

        }

        private void button2_Click(object sender, EventArgs e)
        {

              int[,] FFTNormalized = new int[256, 256];
            ImgFFT.MultMass(Out1, Out2);
                 double max = Math.Log(ImgFFT.RealOUT[0, 0]* ImgFFT.RealOUT[0, 0] + ImgFFT.ImagOUT[0, 0]* ImgFFT.ImagOUT[0, 0]);
                 for (int i = 0; i <=255; i++)
                     for (int j = 0; j <= 255; j++)
                     {
                         if (Math.Log(ImgFFT.RealOUT[i, j] * ImgFFT.RealOUT[i, j] + ImgFFT.ImagOUT[i, j] * ImgFFT.ImagOUT[i, j]) > max)//Math.Log
                        max = Math.Log(ImgFFT.RealOUT[i, j] * ImgFFT.RealOUT[i, j] + ImgFFT.ImagOUT[i, j] * ImgFFT.ImagOUT[i, j]);
                     }
                 for (int i = 0; i <= 255; i++)
                     for (int j = 0; j <= 255; j++)
                     {
                      /*   FFTLog[i, j] = FFTLog[i, j] / max;
                     }
                 for (i = 0; i <= Width - 1; i++)
                     for (j = 0; j <= Height - 1; j++)
                     {*/
                           FFTNormalized[i, j] = (int)(255 * Math.Log(ImgFFT.RealOUT[i, j] * ImgFFT.RealOUT[i, j] + ImgFFT.ImagOUT[i, j] * ImgFFT.ImagOUT[i, j])/max);
                         }
                     //Transferring Image to Fourier Plot
                   //  FourierPlot = Displayimage(FFTNormalized);
                     Dehologram.Image = (Image)ImgFFT.Displayimage(FFTNormalized);

                     


         //   ImgFFT.MultMass(Out1, Out2);
            for (int i = 0; i < 255; i++)
            {
                for (int j = 0; j < 255; j++)
                {
                    OpZ[i, j] = /*Math.Sqrt */( ImgFFT.RealOUT[i, j]* ImgFFT.RealOUT[i, j] + ImgFFT.ImagOUT[i, j] * ImgFFT.ImagOUT[i, j]);
                    
   

                }
            }

       //   Dehologram.Image = (Image)ImgFFT.Displayimage(OpZ);
            for (int i = 0; i < 255; i++)
            {
                for (int j = 0; j < 255; j++)
                {
                    FourierO[i, j].real = ImgFFT.RealOUT[i, j];
                    FourierO[i, j].imag = ImgFFT.ImagOUT[i, j];
                    // pt[i, j] = (int) Out1[i, j].real;
                    //  mt[i, j] = (int) Out1[i, j].imag;
                    //  ptwithKey[i, j] = (int)Out2[i, j].real;
                    //  mtwithKey[i, j] = (int)Out2[i, j].imag;
                }
            }
    



           // ImgFFT.FFTPlot(FourierO);
            //ImgFFT.InverseFFT();
         
            //ImgFFT = new FFT(mt);

            /*  ImgFFT.ForwardFFT();
              ImgFFT.FFTShift();

              ImgFFT.FFTmult(ImgFFT.FFTShifted);*/
            
         //Dehologram.Image = (Image)ImgFFT.Displayimage(ImgFFT.MagniturePlot1);
          //  furiebox2.Image = (Image)ImgFFT.Displayimage(pt);
          //  kMag.Image = (Image)ImgFFT.Displayimage(mt);
        }
        

   

       

        private void ïîäîáðàòüÊëþ÷ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int x, y, width, height;
            //Code for Preview
            //Application.DoEvents();
            try
            {
                Bitmap temp = (Bitmap)InputImage.Clone();
                width = height = (int)(WindowSize * Convert.ToInt32(scalepercentage.Text) / 100);
                bmp3 = new Bitmap(width, height, InputImage.PixelFormat);

                x = (int)((float)current.X * (100 / Convert.ToDouble(scalepercentage.Text)));
                y = (int)((float)current.Y * (100 / Convert.ToDouble(scalepercentage.Text)));
                width = height = (int)(rec_width * (100 / (float)scale));
                if (width > WindowSize)
                {
                    width = height = WindowSize;
                }

                Rectangle area = new Rectangle(x, y, width, height);
                bmp3 = (Bitmap)InputImage.Clone(area, InputImage.PixelFormat);
                Selectedopor = bmp3;
            }
            catch (System.OutOfMemoryException ex)
            {
                MessageBox.Show("Select Area Inside Image only : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            KeyImg.Image = (Image)Selectedopor;
            //palm_scroll.Picture = (Image)palm_selected;
            toolStripStatusLabel6.Text = KeyImg.Width.ToString() + "  X " + KeyImg.Height.ToString();
            KeyImg.Invalidate();


        }

        private void KeySelect_Click(object sender, EventArgs e)
        {
            //ImgFFT.InverseFFT();

            // Dehologram.Image = (Image)ImgFFT.Obj;
            //  Dehologram.Image = (Image)ImgFFT.Displayimage(key);


   
           
/*
            for (int i = 0; i < 255; i++)
            {
                for (int j = 0; j < 255; j++)
                {
                    Out3[i, j].real = 1 / Out3[i,j].real;


                }
            }
            */
            ImgFFT.MultMass(Out3, FourierO);
            for (int i = 0; i < 255; i++)
            {
                for (int j = 0; j < 255; j++)
                {
                    outtut[i, j].real = ImgFFT.RealOUT[i, j] ;
                    outtut[i, j].imag = ImgFFT.ImagOUT[i, j];


                }
            }
           
        }
      

        private void RevreseFFT_Click(object sender, EventArgs e)
        {


            ImgFFT.InverseFFT(outtut);

          ImgFFT.InverseFFT(outtut);
         ImgFFT.InverseFFT(outtut);


            Dehologram.Image = (Image)ImgFFT.Obj;

            //Dehologram.Image = (Image)ImgFFT.Displayimage(output);
            /*
                        ImgFFT = new FFT(mtwithKey);

                        ImgFFT.ForwardFFT();// Finding 2D FFT of Image


                        ImgFFT.FFTShift();
                        ImgFFT.FFTPlot(ImgFFT.FFTShifted);
                        ImgFFT.InverseFFT();
                        Dehologram.Image = (Image)ImgFFT.Obj;
                */

        }

        private void showMag_Click(object sender, EventArgs e)
        {
            furiebox1.Image = (Image)ImgFFT.Displayimage(P1);
            furiebox2.Image = (Image)ImgFFT.Displayimage(P2);
            kMag.Image = (Image)ImgFFT.Displayimage(keyM);
        }

        private void showPhase_Click(object sender, EventArgs e)
        {
            furiebox1.Image = (Image)ImgFFT.Displayimage(M1);
            furiebox2.Image = (Image)ImgFFT.Displayimage(M2);
            kMag.Image = (Image)ImgFFT.Displayimage(keyP);
        }

        private void âûáîðÎïîðíîãîToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int x, y, width, height;
            //Code for Preview
            //Application.DoEvents();
            try
            {
                Bitmap temp = (Bitmap)InputImage.Clone();
                width = height = (int)(WindowSize * Convert.ToInt32(scalepercentage.Text) / 100);
                bmp1 = new Bitmap(width, height, InputImage.PixelFormat);

                x = (int)((float)current.X * (100 / Convert.ToDouble(scalepercentage.Text)));
                y = (int)((float)current.Y * (100 / Convert.ToDouble(scalepercentage.Text)));
                width = height = (int)(rec_width * (100 / (float)scale));
                if (width > WindowSize)
                {
                    width = height = WindowSize;
                }

                Rectangle area = new Rectangle(x, y, width, height);
                bmp1 = (Bitmap)InputImage.Clone(area, InputImage.PixelFormat);
                Selectedopor = bmp1;
            }
            catch (System.OutOfMemoryException ex)
            {
                MessageBox.Show("Select Area Inside Image only : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            StendIMG.Image = (Image)Selectedopor;
            //palm_scroll.Picture = (Image)palm_selected;
            toolStripStatusLabel6.Text = ImSelected.Width.ToString() + "  X " + ImSelected.Height.ToString();
            ImSelected.Invalidate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //1. Create FFT Object
            FFT FourObj;
            FourObj = new FFT(bmp);
            FourObj.ForwardFFT();// Finding 2D FFT of Image

            FFT FourRef1;
            FourRef1 = new FFT(bmp1);
            FourRef1.ForwardFFT();// Finding 2D FFT of Image

            FFT FourRef2;
            FourRef2 = new FFT(bmp3);
            FourRef2.ForwardFFT();// Finding 2D FFT of Image

            FFT outTmp;
            outTmp = new FFT(bmp);



            //////////////////////////////////////////
            for (int i = 0; i < 255; i++)
            {
                for (int j = 0; j < 255; j++)
                {
                    outnew[i, j].real = FourObj.Output[i, j].real * FourRef1.Output[i, j].real * FourRef2.Output[i, j].real - FourObj.Output[i, j].imag * FourRef1.Output[i, j].real * FourRef2.Output[i, j].imag +
                                               FourObj.Output[i, j].real * FourRef1.Output[i, j].imag * FourRef2.Output[i, j].imag + FourObj.Output[i, j].imag * FourRef1.Output[i, j].imag * FourRef2.Output[i, j].real;
                    outnew[i, j].imag = FourObj.Output[i, j].real* FourRef1.Output[i, j].real * FourRef2.Output[i, j].imag + FourObj.Output[i, j].imag * FourRef1.Output[i, j].real * FourRef2.Output[i, j].real -
                                     FourObj.Output[i, j].real * FourRef1.Output[i, j].imag * FourRef2.Output[i, j].real + FourObj.Output[i, j].imag * FourRef1.Output[i, j].imag * FourRef2.Output[i, j].imag;
                }
            }
            
            outTmp.InverseFFT(outnew);

          //  Dehologram.Image = (Image)ImgFFT.Obj;


            int[,] FFTNormalized = new int[256, 256];
            
            double max = (outnew[0, 0].real * outnew[0, 0].real + outnew[0, 0].imag * outnew[0, 0].imag);
            for (int i = 0; i <= 255; i++)
                for (int j = 0; j <= 255; j++)
                {
                    if ((outnew[i, j].real * outnew[i, j].real + outnew[i, j].imag * outnew[i, j].imag) > max)//Math.Log
                        max = (outnew[i, j].real * outnew[i, j].real + outnew[i, j].imag * outnew[i, j].imag);
                }
            for (int i = 0; i <= 255; i++)
                for (int j = 0; j <= 255; j++)
                {
                    /*   FFTLog[i, j] = FFTLog[i, j] / max;
                   }
               for (i = 0; i <= Width - 1; i++)
                   for (j = 0; j <= Height - 1; j++)
                   {*/
                    FFTNormalized[i, j] = (int)(255 * (outnew[i, j].real * outnew[i, j].real + outnew[i, j].imag * outnew[i, j].imag) / max);
                }
            //Transferring Image to Fourier Plot
            //  FourierPlot = Displayimage(FFTNormalized);
            Dehologram.Image = (Image)ImgFFT.Displayimage(FFTNormalized);

            ////////////////////////////////////////////////
        }

        private void furiebox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripLabel4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
    }
}