using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace Fast_Fourier_Transform
{
    public partial class MainFrm : Form
    {
        
        Bitmap InputImage;
        Bitmap SelectedImage;  //selected Palmprint Image
        Bitmap bmp;  // Selected area Bitmap
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
                ppen.Color = Color.Red;
                g.DrawLine(ppen, ImageInput.Width / 2, ImageInput.Top, ImageInput.Width / 2, ImageInput.Height);
                g.DrawLine(ppen, 0, ImageInput.Height / 2, ImageInput.Width, ImageInput.Height / 2);
                ppen.Color = Color.LightBlue;
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
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
            ImgFFT.FFTPlot(ImgFFT.FFTShifted);
            FourierMag.Image = (Image)ImgFFT.FourierPlot;
            FourierPhase.Image = (Image)ImgFFT.PhasePlot; 





            //InvFourier.Image = (Image)ImgFFT.Displayimage();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //ImgFFT.RemoveFFTShift();
            ImgFFT.InverseFFT();
            InvFourier.Image = (Image)ImgFFT.Obj;
            
        }

        private void toolStripLabel4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
    }
}