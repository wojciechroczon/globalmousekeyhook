using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using AutoIt;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;


namespace SAPMouse
{
	public class EmguImageProcessing
    {
		[DllImport("User32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		static extern bool PrintWindow(IntPtr hwnd, IntPtr hDC, uint nFlags);
		[DllImport("user32.dll")]
		static extern bool GetWindowRect(IntPtr handle, ref Rectangle rect);
		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        public void FindPattern()
        {
            var daneObszaruZbytu = CvInvoke.Imread(@"D:\balluff.png");
            var zrzutEkranu = CvInvoke.Imread(@"D:\screenwindows.png");
          var btndaneObszaruZbutuWidth =   daneObszaruZbytu.Width;
          var btndaneObszaruZbutuHeight =   daneObszaruZbytu.Height;


            CvInvoke.MatchTemplate(zrzutEkranu, daneObszaruZbytu, zrzutEkranu, TemplateMatchingType.Ccoeff);
            double minValues = 0;
            double maxValues = 200;
            Point minLocations = new Point();
            Point maxLocations = new Point();


            CvInvoke.MinMaxLoc(zrzutEkranu, ref minValues, ref maxValues, ref minLocations, ref maxLocations);
            var x = maxLocations.X;
            var y = maxLocations.Y;

            var sssss = AutoIt.AutoItX.WinGetHandle(@"Odbiorca Zmiana: Ekran poczatkowy - \\Remote");



            //AutoIt.AutoItX.MouseClick("RIGHT", x+btndaneObszaruZbutuWidth/2, y+btndaneObszaruZbutuHeight/2, 1, 80);
            






           // CvInvoke.MinMaxLoc(zrzutEkranu, out minValues, out maxValues, out minLocations, out maxLocations );
           








        }

		public void ShowImageEmgussss()
        {
           var daneObszaruZbytu =  CvInvoke.Imread(@"D:\DaneObszaruZbytu.png");


			string win1 = "Test Window"; //The name of the window
			CvInvoke.NamedWindow(win1); //Create the window using the specific name

            Mat imger = new Mat();
			Mat img = new Mat(200, 400, DepthType.Cv8U, 3); //Create a 3 channel image of 400x200
			img.SetTo(new Bgr(255, 0, 0).MCvScalar); // set it to Blue color

			Emgu.CV.CvInvoke.PutText(img, "Wojtek bez portek", new Point(100, 100), Emgu.CV.CvEnum.FontFace.HersheyPlain, 1.0, new Bgr(0,0,255).MCvScalar);
			CvInvoke.Imshow(win1, img);
			CvInvoke.WaitKey(0);  //Wait for the key pressing event
			CvInvoke.DestroyWindow(win1); //Destroy the window if key is pressed

		}

        static public string CaptureWindow(IntPtr handle)
        {
            string path = System.IO.Path.GetTempPath();


            // Get the size of the window to capture
            Rectangle rect = new Rectangle();
            GetWindowRect(handle, ref rect);

            // GetWindowRect returns Top/Left and Bottom/Right, so fix it
            rect.Width = rect.Width - rect.X;
            rect.Height = rect.Height - rect.Y;

            // Create a bitmap to draw the capture into
            using (Bitmap bitmap = new Bitmap(rect.Width, rect.Height))
            {
                // Use PrintWindow to draw the window into our bitmap
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    IntPtr hdc = g.GetHdc();
                    if (!PrintWindow(handle, hdc, 0))
                    {
                        int error = Marshal.GetLastWin32Error();
                        var exception = new System.ComponentModel.Win32Exception(error);
                        Debug.WriteLine("ERROR: " + error + ": " + exception.Message);
                        // TODO: Throw the exception?
                    }
                    g.ReleaseHdc(hdc);
                }
                //return bitmap;
                // Save it as a .png just to demo this
                bitmap.Save(path + "a.png");
                Console.WriteLine("Capture Window path: " + path + "a.png");
            }
            return path + "a.png";
        }





    }
//    String win1 = "Test Window"; //The name of the window
//    CvInvoke.NamedWindow(win1); //Create the window using the specific name
//			Mat img = new Mat(200, 400, DepthType.Cv8U, 3); //Create a 3 channel image of 400x200
//    img.SetTo(new Bgr(255, 0, 0).MCvScalar); // set it to Blue color

//Draw "Hello, world." on the image using the specific font
//CvInvoke.PutText(
//   img,
//   "Hello, world", 
//   new System.Drawing.Point(10, 80), 
//   FontFace.HersheyComplex, 
//   1.0, 
//   new Bgr(0, 255, 0).MCvScalar);
		 

//CvInvoke.Imshow(win1, img); //Show the image
//CvInvoke.WaitKey(0);  //Wait for the key pressing event
//CvInvoke.DestroyWindow(win1); //Destroy the window if key is pressed
	}

