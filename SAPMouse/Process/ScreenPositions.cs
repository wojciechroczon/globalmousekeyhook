using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Aruco;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Emgu.CV.CvEnum;
using System.IO;

namespace SAPMouse.Process
{
    public class ScreenPositions
    {
        public int MyProperty { get; set; }
        public double TemplateScore { get; set; }
       

        public Bitmap ScreeNCapture()
        {
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;

            Bitmap captureBitmap = new Bitmap(screenWidth, screenHeight, PixelFormat.Format32bppArgb);
            var sss = Screen.AllScreens;
            Rectangle captureRectangle = Screen.AllScreens[0].Bounds;
            Graphics captureGraphics = Graphics.FromImage(captureBitmap);
            captureGraphics.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, 0, 0, captureRectangle.Size);
            return captureBitmap;
            
        }

        public Point GetPosition(string fileName)
        {
            Image<Bgr, Byte> capturedScreen = ScreeNCapture().ToImage<Bgr, Byte>();
            string startupPath = System.IO.Directory.GetParent(@"../../../").FullName;
            string path = startupPath + @"\images" +  fileName;
            var daneObszaruZbytu = CvInvoke.Imread(path);

            CvInvoke.MatchTemplate(capturedScreen, daneObszaruZbytu, capturedScreen, TemplateMatchingType.CcoeffNormed);
            double minValues = 0;
            double maxValues = 200;
            Point minLocations = new Point();
            Point maxLocations = new Point();


            CvInvoke.MinMaxLoc(capturedScreen, ref minValues, ref maxValues, ref minLocations, ref maxLocations);
            var x = maxLocations.X;
            var y = maxLocations.Y;
            TemplateScore = maxValues;
            var btndaneObszaruZbutuWidth = daneObszaruZbytu.Width;
            var btndaneObszaruZbutuHeight = daneObszaruZbytu.Height;

            var xPosition = x + btndaneObszaruZbutuWidth/2;
            var yPosition = y + btndaneObszaruZbutuHeight / 2;

            return new Point(xPosition, yPosition);

        }
    }
}
