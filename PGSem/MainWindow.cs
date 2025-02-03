using MathNet.Numerics.Interpolation;
using PGSem.EdgeDetection;
using PGSem.HelpAlgorithms;
using PGSem.ImageLoader;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace PGSem
{
    public partial class MainWindow : Form
    {
        private bool showAll = false;
        private byte[,]? image = null;
        private byte[,]? gaussImage = null;
        private byte[,]? sobelImage = null;
        private byte[,]? otsuBinaryImage = null;
        private Bitmap? bezierCurve = null;
        private Stopwatch sw = new Stopwatch();
        private DrawImage drawImage = new();
        List<byte[,]> images = new List<byte[,]>();
        private bool clear = false;

        public MainWindow()
        {
            InitializeComponent();
            CreateCurve.Enabled = false;
            GaussBut.Enabled = false;
            SobelBut.Enabled = false;
            OtsuBut.Enabled = false;
            BezierBut.Enabled = false;
        }
        private void CreateCurveButton(object sender, EventArgs e)
        {
            sw.Start();
            image = LoadImage.loadedImage ?? throw new Exception("Image was null");
            gaussImage = GaussFilter.ApplyGaussFilter(image);
            sobelImage = SobelOperator.SobelEdgeDetection(gaussImage);
            otsuBinaryImage = OtsuTreshold.ApplyOtsuTreshold(sobelImage);
            List<(double x, double y)> centerLine = BezierCurve.FindCenterLine(otsuBinaryImage);
            CubicSpline bezierSpline = BezierCurve.FitBezierCurve(centerLine);
            var bezierPoints = BezierCurve.SampleBezierCurve(bezierSpline, LoadImage.BYTES);
            bezierCurve = BezierCurve.DrawBezierOnBitmap(bezierPoints, LoadImage.BYTES, LoadImage.BYTES);
            LoadImage.bitMapImage = bezierCurve;
            sw.Stop();
            TimeTextBox.Text = sw.ElapsedMilliseconds.ToString() + "ms";
            sw.Reset();
            showAll = true;
            images.Add(image);
            images.Add(gaussImage);
            images.Add(sobelImage);
            images.Add(otsuBinaryImage);
            doubleBuffPanel.Invalidate();
        }

        private void ShowImageChckBox(object sender, EventArgs e)
        {
            if (LoadImage.loadedImage != null)
            {
                LoadImage.ShowImage = ImageChckBox.Checked;
            }
            doubleBuffPanel.Invalidate();
        }

        private void SelectImageOnClick(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:/Users/Lukas/Desktop/Zimny semester/PG/Sem/PGSem/PGSem/Images";
                openFileDialog.Title = "Select an image";
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    LoadImage load = new LoadImage(openFileDialog.FileName.Replace(@"//", @"/"));
                    image = LoadImage.loadedImage;
                    CreateCurve.Enabled = true;
                    GaussBut.Enabled = true;
                }
            }
        }

        private void DoubleBuffPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (clear)
            {
                g.Clear(Color.White);
                clear = false;
                return;
            }
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            if (showAll)
            {
                drawImage.Draw(g, images);
            }
            if (LoadImage.bitMapImage != null)
            {
                drawImage.Draw(g);
            }
        }

        private void GaussFilterOnClick(object sender, EventArgs e)
        {
            sw.Start();
            showAll = false;
            if (image != null)
            {
                gaussImage = GaussFilter.ApplyGaussFilter(image);
                SobelBut.Enabled = true;
                LoadImage.bitMapImage = LoadImage.ToBitMap(gaussImage, LoadImage.BYTES);
                using (Graphics g = Graphics.FromImage(LoadImage.bitMapImage))
                {
                    drawImage.Draw(g);
                    doubleBuffPanel.Invalidate();
                }
            }
            else
            {
                throw new Exception("Image was not loaded correctly");
            }
            sw.Stop();
            TimeTextBox.Text = sw.ElapsedMilliseconds.ToString() + "ms";
            sw.Reset();
        }

        private void SobelEdgeOnClick(object sender, EventArgs e)
        {
            sw.Start();
            showAll = false;
            if (gaussImage != null)
            {
                sobelImage = SobelOperator.SobelEdgeDetection(gaussImage);
                OtsuBut.Enabled = true;
                LoadImage.bitMapImage = LoadImage.ToBitMap(sobelImage, LoadImage.BYTES);
                using (Graphics g = Graphics.FromImage(LoadImage.bitMapImage))
                {
                    drawImage.Draw(g);
                    doubleBuffPanel.Invalidate();
                }
            }
            else
            {
                throw new Exception("Gauss filter wasn't applied");
            }
            sw.Stop();
            TimeTextBox.Text = sw.ElapsedMilliseconds.ToString() + "ms";
            sw.Reset();
        }

        private void OtsuTresholdOnClick(object sender, EventArgs e)
        {
            sw.Start();
            showAll = false;
            if (sobelImage != null)
            {
                otsuBinaryImage = OtsuTreshold.ApplyOtsuTreshold(sobelImage);
                BezierBut.Enabled = true;
                LoadImage.bitMapImage = LoadImage.ToBitMap(otsuBinaryImage, LoadImage.BYTES);
                using (Graphics g = Graphics.FromImage(LoadImage.bitMapImage))
                {
                    drawImage.Draw(g);
                    doubleBuffPanel.Invalidate();
                }
            }
            else
            {
                throw new Exception("Sobel Edge Detector failed");
            }
            sw.Stop();
            TimeTextBox.Text = sw.ElapsedMilliseconds.ToString() + "ms";
            sw.Reset();
        }

        private void BezierCurveOnClick(object sender, EventArgs e)
        {
            sw.Start();
            showAll = false;
            if (otsuBinaryImage != null)
            {
                List<(double x, double y)> centerLine = BezierCurve.FindCenterLine(otsuBinaryImage);
                CubicSpline bezierSpline = BezierCurve.FitBezierCurve(centerLine);
                var bezierPoints = BezierCurve.SampleBezierCurve(bezierSpline, LoadImage.BYTES);
                bezierCurve = BezierCurve.DrawBezierOnBitmap(bezierPoints, LoadImage.BYTES, LoadImage.BYTES);
                LoadImage.bitMapImage = bezierCurve;
                doubleBuffPanel.Invalidate();
            }
            else
            {
                throw new Exception("Otsu Treshold failed");
            }
            sw.Stop();
            TimeTextBox.Text = sw.ElapsedMilliseconds.ToString() + "ms";
            sw.Reset();
        }

        private void ClearOnClick(object sender, EventArgs e)
        {
            clear = true;
            doubleBuffPanel.Invalidate();
        }

        private void CyclicOnClick(object sender, EventArgs e)
        {
            int iterations = (NumericField.Value == 0) ? 1000 : (int)NumericField.Value;

            for (int i = 0; i < iterations; i++)
            {
                sw.Start();
                if (i % 3 == 0)
                {
                    LoadImage load = new LoadImage("C:\\Users\\Lukas\\Desktop\\Zimny semester\\PG\\Sem\\PGSem\\PGSem\\Images\\NewImage.txt");
                } else if (i % 3 == 1)
                {
                    LoadImage load = new LoadImage("C:\\Users\\Lukas\\Desktop\\Zimny semester\\PG\\Sem\\PGSem\\PGSem\\Images\\NewImage2.txt");
                } else
                {
                    LoadImage load = new LoadImage("C:\\Users\\Lukas\\Desktop\\Zimny semester\\PG\\Sem\\PGSem\\PGSem\\Images\\NewImage3.txt");
                }
                image = LoadImage.loadedImage ?? throw new Exception("Image was null");
                gaussImage = GaussFilter.ApplyGaussFilter(image);
                sobelImage = SobelOperator.SobelEdgeDetection(gaussImage);
                otsuBinaryImage = OtsuTreshold.ApplyOtsuTreshold(sobelImage);
                List<(double x, double y)> centerLine = BezierCurve.FindCenterLine(otsuBinaryImage);
                CubicSpline bezierSpline = BezierCurve.FitBezierCurve(centerLine);
                var bezierPoints = BezierCurve.SampleBezierCurve(bezierSpline, LoadImage.BYTES);
                bezierCurve = BezierCurve.DrawBezierOnBitmap(bezierPoints, LoadImage.BYTES, LoadImage.BYTES);
                LoadImage.bitMapImage = bezierCurve;
                TimeTextBox.Text = sw.ElapsedMilliseconds.ToString() + "ms";
            }
            sw.Stop();
            TimeTextBox.Text = sw.ElapsedMilliseconds.ToString() + "ms";
            sw.Reset();
        }
    }
}
