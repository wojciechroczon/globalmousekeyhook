using AutoIt;
using System;
using SAPMouse.Process;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;

namespace SAPMouse
{
    internal class ProcessSequence
    {
        public int moveSpeed = 10;
        public string text, errorMessage;
        private System.Drawing.Point templatePoint;
        public int delay = 300;
        private readonly string contactPersonNumber;
        public string CustomerNumber { get; set; }
        public string Team { get; }
        public string Region { get; }
        private ScreenPositions screenPositions;
        public Templates templates { get; set; }
        public Stopwatch stopwatch;
        public MainForm mainForm;
        public bool turnOffAutomation;
       
        
        
        public ProcessSequence(string customerNumber, string team, string region, string contactPersonName)
        {
            errorMessage = "";
            CustomerNumber = customerNumber;
            Team = team;
            Region = region;
            this.contactPersonNumber = contactPersonName;
            screenPositions = new ScreenPositions();
            templates = new Templates();
            stopwatch = new Stopwatch();
           mainForm = new MainForm();
        }  
        public bool enterCustomer()
        {
            turnOffAutomation = true;
            if (windowControl("oknoEkranPoczatkowy", 0.8, 15000, false) == false) 
            { errorMessage = "Zle okno poczatkowe"; turnOffAutomation = false; return false;  } 
            
            AutoItX.MouseClick("LEFT", 246, 183, 1, moveSpeed);
            AutoItX.MouseClick("LEFT", 302, 187, 1, moveSpeed);

            if (windowControl("ograniczenieZakresu",0.8,6000, false) == false)
            { errorMessage = "Nie ma okna ogranoczenie zakresu"; return false; }


            templatePoint = screenPositions.GetPosition(templates.GetTemplate("cancel"));
            AutoItX.MouseClick("LEFT", templatePoint.X, templatePoint.Y, 1, moveSpeed);
            Thread.Sleep(1000);

            SendKeys.SendWait(CustomerNumber);
            Thread.Sleep(2000);

            if (windowControl("wyborKlienta", 0.4, 6000, false) == false)
            { errorMessage = "Brak listy wyboru klienta"; return false; }

            AutoItX.MouseClick("LEFT", 224, 224, 1, moveSpeed);
            Thread.Sleep(delay);

            if (windowControl("windowAcceptGotowe", 0.4, 4000, false) == false)
            { errorMessage = "Okno do akceptacji klienta nie było gotowe"; return false; }

            text = templates.GetTemplate("accept");
            templatePoint = screenPositions.GetPosition(text);

            AutoItX.MouseClick("LEFT", templatePoint.X, templatePoint.Y, 1, moveSpeed);

            //Thread.Sleep(delay);

            //if (windowControl("windowError", 0.97, 1000, true) == false)
            //{ 
            //    errorMessage = "Wyświetlił się błąd";
               
            //    return false; }

            //if (windowControl("errorOstrzezenie", 0.7, 1000, true) == false)
            //{
            //    Console.WriteLine(  "Ostzreznie");
            //    Thread.Sleep(delay);
            //    errorMessage = "Wyświetliło sie ostrzeżenie";

            //    text = templates.GetTemplate("btnacceptOstrzerenie");
            //    templatePoint = screenPositions.GetPosition(text);

            //    AutoItX.MouseClick("LEFT", templatePoint.X-70, templatePoint.Y, 1, moveSpeed);

            //    Thread.Sleep(delay);
            //    return true;
            //}

            Thread.Sleep(delay);

            return true;
        }
        public void CheckCurrentWindow()
        {
            text = templates.GetTemplate("oknoDaneObszaruZbytu");
            templatePoint = screenPositions.GetPosition(text);
            var resultDaneObszaruZbytu = screenPositions.TemplateScore;

            text = templates.GetTemplate("oknoDaneOgolne");
            templatePoint = screenPositions.GetPosition(text);
            var resultDaneOgolne = screenPositions.TemplateScore;

            if (resultDaneObszaruZbytu < resultDaneOgolne)
            {
                text = templates.GetTemplate("btnDaneObszaruZbytu");
                templatePoint = screenPositions.GetPosition(text);
                AutoItX.MouseClick("LEFT", templatePoint.X, templatePoint.Y, 1, moveSpeed);
            }
        }
        public bool enterTeam()
        {
            turnOffAutomation = true;

            Thread.Sleep(3000);
            AutoItX.MouseClick("LEFT", 58, 261, 1, moveSpeed);
            

            if (windowControl("windowInformacja", 0.7, 1200, false) == true) 
                {
                    text = templates.GetTemplate("accept");
                    templatePoint = screenPositions.GetPosition(text);
                    AutoItX.MouseClick("LEFT", templatePoint.X, templatePoint.Y, 1, moveSpeed);
                }


            if (windowControl("errorOdbiorcaDoUsuniecia", 0.8, 1200, false) == true)
            {
                errorMessage = "Klient przeznaczony do usunięcia";
                exitCusrtomerForm();
                turnOffAutomation = false;
                return false;
                }

            Thread.Sleep(delay);


            if (windowControl("windowSprzedaz", 0.7, 10000, false) == false)
            { errorMessage = "Nie ma właściwego okna"; return false; }

            
            AutoItX.MouseClick("LEFT", 148, 348, 1, moveSpeed);
            Thread.Sleep(delay);
            AutoItX.MouseClick("LEFT", 173, 349, 1, moveSpeed);


            if (windowControl("windowWyborBiuraSprzedazy", 0.6, 6000, false) == false)
            { errorMessage = "Brak okna PL_TS PL_TN ..."; return false; }

            if (Team == "PLTN")
            {
                AutoItX.MouseClick("LEFT", 174, 306, 2, moveSpeed);
               Thread.Sleep(delay);
                return true;
            }
            if (Team == "PLTS")
            {
                AutoItX.MouseClick("LEFT", 180, 328, 2, moveSpeed);
                Thread.Sleep(delay);
                return true;

            }
            if (Team == "PLDS")
            {
                AutoItX.MouseClick("LEFT", 243, 293, 2, moveSpeed);
                Thread.Sleep(delay);
                return true;

            }
            return true;

        }
        public bool enterRegion()
        {
            AutoItX.MouseClick("LEFT", 147, 374, 1, moveSpeed);
            Thread.Sleep(delay);
            AutoItX.MouseClick("LEFT", 167, 373, 1, moveSpeed);
            Thread.Sleep(delay);


            if (windowControl("windowBiuroMiasto", 0.8, 8000, false) == false)
            { errorMessage = "Brak okna Wrocław Olsztyn ..."; return false; }
            if (Region == "N01")
            {
                AutoItX.MouseClick("LEFT", 193, 357, 2, moveSpeed);
                Thread.Sleep(delay);
                return true;

            }
            if (Region == "N02")
            {
                AutoItX.MouseClick("LEFT", 193, 369, 2, moveSpeed);
                Thread.Sleep(delay);
                return true;

            }
            if (Region == "N03")
            {
                AutoItX.MouseClick("LEFT", 193, 388, 2, moveSpeed);
                Thread.Sleep(delay);
                return true;
            }

            if (Region == "N04")
            {
                AutoItX.MouseClick("LEFT", 193, 404, 2, moveSpeed);
                Thread.Sleep(delay);
                return true;

            }
            if (Region == "N05")
            {
                AutoItX.MouseClick("LEFT", 193, 418, 2, moveSpeed);
                Thread.Sleep(delay);
                return true;
            }
            
            if (Region == "N06")
            {
                AutoItX.MouseClick("LEFT", 182, 436, 2, moveSpeed);
                Thread.Sleep(delay);
                return true;
            }
            if (Region == "N07")
            {
                AutoItX.MouseClick("LEFT", 182, 449, 2, moveSpeed);
                Thread.Sleep(delay);
                return true;
            }
            if (Region == "NXX")
            {
                AutoItX.MouseClick("LEFT", 224, 354, 2, moveSpeed);
                Thread.Sleep(delay);
                return true;


            }
            if (Region == "S01")
            {
                AutoItX.MouseClick("LEFT", 197, 353, 2, moveSpeed);
                Thread.Sleep(delay);
                return true;

            }
            if (Region == "S02")
            {
                AutoItX.MouseClick("LEFT", 195, 368, 2, moveSpeed);
                Thread.Sleep(delay);
                return true;

            }
            if (Region == "S03")
            {
                AutoItX.MouseClick("LEFT", 195, 387, 2, moveSpeed);
                Thread.Sleep(delay);
                return true;

            }
            if (Region == "S04")
            {
                AutoItX.MouseClick("LEFT", 197, 402, 2, moveSpeed);
                Thread.Sleep(delay);
                return true;

            }
            if (Region == "S05")
            {
                AutoItX.MouseClick("LEFT", 195, 416, 2, moveSpeed);
                Thread.Sleep(delay);
                return true;

            }
            if (Region == "S06")
            {
                AutoItX.MouseClick("LEFT", 195, 431, 2, moveSpeed);
                Thread.Sleep(delay);
                return true;

            }
            if (Region == "S07")
            {
                AutoItX.MouseClick("LEFT", 195, 452, 2, moveSpeed);
                Thread.Sleep(delay);
                return true;

            }
            if (Region == "S08")
            {
                AutoItX.MouseClick("LEFT", 195, 467, 2, moveSpeed);
                Thread.Sleep(delay);
                return true;

            }
            return true;
        }
        public bool enterEmployee()
        {
            AutoItX.MouseClick("LEFT", 295, 263, 1, 30);
            Thread.Sleep(delay);
            var contactPersonExists = false;
            stopwatch.Start();

            while (!contactPersonExists)
            {
                text = templates.GetTemplate("fieldOsobaKontaktowa");
                templatePoint = screenPositions.GetPosition(text);

                if (screenPositions.TemplateScore > 0.8) contactPersonExists = true; System.Console.WriteLine(screenPositions.TemplateScore.ToString());
                if (stopwatch.ElapsedMilliseconds > 4000)
                {
                    stopwatch.Stop();
                    stopwatch.Reset();
                    return true;
                }

            }


            Clipboard.SetText(contactPersonNumber);
            System.Console.WriteLine("Dalsza praca");
            AutoItX.MouseClick("LEFT", templatePoint.X+180, templatePoint.Y, 1, moveSpeed);
            AutoItX.Send("^a");
            AutoItX.Send(contactPersonNumber);
            Thread.Sleep(2500);
            return true;
        }
        public bool exitCusrtomerForm()
        {
            Thread.Sleep(delay);
            if (windowControl("DaneSterowaniaNIP", 0.7, 10000, false) == false) return false;
            AutoItX.MouseClick("LEFT", 230, 55, 1, moveSpeed);
            Thread.Sleep(delay);
            AutoItX.MouseClick("LEFT", 24, 53, 1, moveSpeed);
            Thread.Sleep(delay);

            if (windowControl("errorKodPodatku", 0.6, 3000, true) == false)
            { errorMessage = "Błędny NIP";
                AutoIt.AutoItX.Send("{BACKSPACE}");
                Thread.Sleep(1000);
                AutoItX.MouseClick("LEFT", 24, 53, 1, 20);
                Thread.Sleep(1000);
                AutoItX.MouseClick("LEFT", 24, 53, 1, 20);
                Thread.Sleep(1000);

            }

            AutoItX.MouseClick("LEFT", 24, 53, 1, moveSpeed);

            return true;
        }
        private bool windowControl(string windowName, double score, int timeOut, bool errorCheck)
        {
            stopwatch.Start();
            while (true)
            {
                text = templates.GetTemplate(windowName);
                templatePoint = screenPositions.GetPosition(text);  
                if ((screenPositions.TemplateScore > score))
                {
                    System.Console.WriteLine(screenPositions.TemplateScore);
                    stopwatch.Stop();
                    stopwatch.Reset();
                    return !errorCheck;

                }
                if (stopwatch.ElapsedMilliseconds > timeOut)
                {
                    stopwatch.Stop();
                    stopwatch.Reset();
                    Console.WriteLine("Wynik = " + errorCheck);
                    return errorCheck;
                } 
                Console.WriteLine("lece z koksem");
            }
        }
    }
}