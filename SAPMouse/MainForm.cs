using AutoIt;
using Gma.System.MouseKeyHook;
using SAPMouse.Process;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;

namespace SAPMouse
{
    public partial class MainForm : Form
    {
        private IKeyboardMouseEvents m_Events = null;
        private ExcellHandling ExcellHandling;
        FileStream fileWithCoordinates;
        int mouseX, mouseY;
        string filePath = @"D:\log.txt", customerNumber, team, region, contactPersonNumber;


        public MainForm()
        {
            System.Globalization.CultureInfo.DefaultThreadCurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo("en-US");
            InitializeComponent();
            SubscribeGlobal();
            FormClosing += Main_Closing;

        }
        private void StopAutomation()
        {
            automaticWorkCheck.Checked = false;
        }
        private void Main_Closing(object sender, FormClosingEventArgs e)
        {
            Unsubscribe();
            try
            {
                ExcellHandling.wb.Close();

                ExcellHandling.excelApplication.Quit();
                Marshal.ReleaseComObject(ExcellHandling.ws);
                Marshal.ReleaseComObject(ExcellHandling.wb);
                Marshal.ReleaseComObject(ExcellHandling.excelApplication);
            }
            catch (Exception)
            {
                Console.WriteLine("Problem");
            }
        }
        private void SubscribeGlobal()
        {
            Unsubscribe();
            Subscribe(Hook.GlobalEvents());
        }
        private void Unsubscribe()
        {
            if (m_Events == null) return;
            m_Events.MouseClick -= OnMouseClick;
            m_Events.MouseDoubleClick -= OnMouseDoubleClick;
            m_Events.Dispose();
            m_Events = null;
        }
        private void Subscribe(IKeyboardMouseEvents events)
        {
            m_Events = events;
            var map = new Dictionary<Combination, Action> {{Combination.FromString("Control+Shift+O"), () => StopAutomation()} };
            m_Events.MouseClick += OnMouseClick;
            m_Events.MouseDoubleClick += OnMouseDoubleClick;
            m_Events.OnCombination(map);
        }
        private void OnMouseClick(object sender, MouseEventArgs e)
        {
            var mousePosition = AutoItX.MouseGetPos();
            mouseX = mousePosition.X;
            mouseY = mousePosition.Y;
            Log(string.Format("MouseClick \t {0} \t {1}", mouseX.ToString(), mouseY.ToString()));
        }
        private void OnMouseDoubleClick(object sender, MouseEventArgs e)
        {
            var mousePosition = AutoItX.MouseGetPos();
            mouseX = mousePosition.X;
            mouseY = mousePosition.Y;
            Log(string.Format("MouseDoubleClick \t {0} \t {1}\t{2}", e.Button, mouseX.ToString(), mouseY.ToString()));
        }
        public void Log(string text)
        {
            if (IsDisposed) return;
            textBoxLog.AppendText(Environment.NewLine);
            textBoxLog.AppendText(text);
            textBoxLog.ScrollToCaret();
        }
        private void exitButton_Click(object sender, EventArgs e)
        {
            //ExcellHandling.wb.Close();
            //ExcellHandling.excelApplication.Quit();
            //Marshal.ReleaseComObject(ExcellHandling.wb);
            //Marshal.ReleaseComObject(ExcellHandling.excelApplication);
            Form.ActiveForm.Close();
        }
        private void createFile_Click(object sender, EventArgs e)
        {
            fileWithCoordinates = File.Create(filePath);
            fileWithCoordinates.Dispose();
        }
        private void SaveToTxtFile_Click(object sender, EventArgs e)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(filePath, true))
            {
                var lines = textBoxLog.Lines;

                foreach (var line in lines)
                {
                    file.WriteLine(line);
                }
            }
        }
        private void startProcess_Click(object sender, EventArgs e)
        {
            readExcellValues(null, null);

            customerNumber = customerNoTextBox.Text;
            team = teamNameTextBox.Text;
            region = regionDesignationTextBox.Text;
            contactPersonNumber = contactPersonNumberTextBox.Text;

            ProcessSequence sequence = new ProcessSequence(customerNumber, team, region, contactPersonNumber);

            if (sequence.enterCustomer())
            {
                //sequence.CheckCurrentWindow();

                if (sequence.enterTeam())
                {
                    sequence.enterRegion();
                }
                else
                { 
                    ErrorReport(sequence);
                }

                if (!sequence.enterEmployee()) ErrorReport(sequence);
                if (!sequence.exitCusrtomerForm()) ErrorReport(sequence);
                if (automaticWorkCheck.Checked) AutomaticProcess();
            }
            else
            {
                ErrorReport(sequence);
            }
        }
        private void AutomaticProcess()
        {
            numericUpDown1.UpButton();
            startProcess_Click(null, null);
        }
        private void readExcellValues(object sender, EventArgs e)
        {
            ExcellHandling = new ExcellHandling();



            var row = numericUpDown1.Value;
            customerNoTextBox.Text = ExcellHandling.readCustNumber((int)row);
            teamNameTextBox.Text = ExcellHandling.readTeamNumber((int)row);
            regionDesignationTextBox.Text = ExcellHandling.readRegionNumber((int)row);
            contactPersonNumberTextBox.Text = ExcellHandling.readContactPersonNumber((int)row);

            ExcellHandling.wb.Close();
            ExcellHandling.excelApplication.Quit();

            Marshal.ReleaseComObject(ExcellHandling.ws);
                Marshal.ReleaseComObject(ExcellHandling.wb);
                Marshal.ReleaseComObject(ExcellHandling.excelApplication);
            

            System.Diagnostics.Process[] excelProcs = System.Diagnostics.Process.GetProcessesByName("EXCEL");
            foreach (var proc in excelProcs)
            {
                proc.Kill();
            }


        }
        private void button1_Click(object sender, EventArgs e)
        {
            ScreenPositions screenPositions = new ScreenPositions();
         //   screenPositions.GetPosition();
            
        }
        private void ErrorReport(ProcessSequence sequence)
        {
            textBoxLog.AppendText(Environment.NewLine);
            textBoxLog.AppendText(sequence.errorMessage);
            Thread.Sleep(200);
            SaveToTxtFile_Click(null, null);
            if(sequence.turnOffAutomation) StopAutomation();
            // Thread.Sleep(5000);
           // Application.Exit();
        }

        private void automaticProcessStart()
        {
            readExcellValues(null, null);

            customerNumber = customerNoTextBox.Text;
            team = teamNameTextBox.Text;
            region = regionDesignationTextBox.Text;
            contactPersonNumber = contactPersonNumberTextBox.Text;

            ProcessSequence sequence = new ProcessSequence(customerNumber, team, region, contactPersonNumber);

            if (automaticWorkCheck.Checked==true) sequence.enterCustomer();
            if (automaticWorkCheck.Checked == true) sequence.enterTeam();
            if (automaticWorkCheck.Checked == true) sequence.enterRegion();
            if (automaticWorkCheck.Checked == true) sequence.exitCusrtomerForm();

            if (automaticWorkCheck.Checked)
            {
                AutomaticProcess();
            }

        }
    }
}
