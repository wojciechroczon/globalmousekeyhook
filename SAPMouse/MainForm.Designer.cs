namespace SAPMouse
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.regionDesignationTextBox = new System.Windows.Forms.TextBox();
            this.contactPersonNumberTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.startProcess = new System.Windows.Forms.Button();
            this.saveCoordinatesBtn = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.createFileBtn = new System.Windows.Forms.Button();
            this.clearTextBoxBtn = new System.Windows.Forms.Button();
            this.customerNoTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.teamNameTextBox = new System.Windows.Forms.TextBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.automaticWorkCheck = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxLog
            // 
            this.textBoxLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxLog.Location = new System.Drawing.Point(12, 116);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.Size = new System.Drawing.Size(776, 232);
            this.textBoxLog.TabIndex = 0;
            this.textBoxLog.TabStop = false;
            // 
            // regionDesignationTextBox
            // 
            this.regionDesignationTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.regionDesignationTextBox.Location = new System.Drawing.Point(162, 72);
            this.regionDesignationTextBox.Name = "regionDesignationTextBox";
            this.regionDesignationTextBox.Size = new System.Drawing.Size(159, 22);
            this.regionDesignationTextBox.TabIndex = 2;
            this.regionDesignationTextBox.Text = "N06";
            // 
            // contactPersonNumberTextBox
            // 
            this.contactPersonNumberTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.contactPersonNumberTextBox.Location = new System.Drawing.Point(327, 72);
            this.contactPersonNumberTextBox.Name = "contactPersonNumberTextBox";
            this.contactPersonNumberTextBox.Size = new System.Drawing.Size(159, 22);
            this.contactPersonNumberTextBox.TabIndex = 3;
            this.contactPersonNumberTextBox.Text = "70004056";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(19, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Zespół";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(159, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Oznaczenie regionu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(324, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Numer odp pracownika";
            // 
            // startProcess
            // 
            this.startProcess.Location = new System.Drawing.Point(657, 13);
            this.startProcess.Name = "startProcess";
            this.startProcess.Size = new System.Drawing.Size(131, 97);
            this.startProcess.TabIndex = 9;
            this.startProcess.Text = "Rozpocznij wprowadzenie";
            this.startProcess.UseVisualStyleBackColor = true;
            this.startProcess.Click += new System.EventHandler(this.startProcess_Click);
            // 
            // saveCoordinatesBtn
            // 
            this.saveCoordinatesBtn.Location = new System.Drawing.Point(156, 362);
            this.saveCoordinatesBtn.Name = "saveCoordinatesBtn";
            this.saveCoordinatesBtn.Size = new System.Drawing.Size(131, 76);
            this.saveCoordinatesBtn.TabIndex = 10;
            this.saveCoordinatesBtn.Text = "Zapisz koordynaty do pliku";
            this.saveCoordinatesBtn.UseVisualStyleBackColor = true;
            this.saveCoordinatesBtn.Click += new System.EventHandler(this.SaveToTxtFile_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(657, 362);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(131, 76);
            this.exitButton.TabIndex = 11;
            this.exitButton.Text = "EXIT";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // createFileBtn
            // 
            this.createFileBtn.Location = new System.Drawing.Point(12, 362);
            this.createFileBtn.Name = "createFileBtn";
            this.createFileBtn.Size = new System.Drawing.Size(119, 76);
            this.createFileBtn.TabIndex = 12;
            this.createFileBtn.Text = "Przygotuj plik";
            this.createFileBtn.UseVisualStyleBackColor = true;
            this.createFileBtn.Click += new System.EventHandler(this.createFile_Click);
            // 
            // clearTextBoxBtn
            // 
            this.clearTextBoxBtn.Location = new System.Drawing.Point(313, 362);
            this.clearTextBoxBtn.Name = "clearTextBoxBtn";
            this.clearTextBoxBtn.Size = new System.Drawing.Size(120, 76);
            this.clearTextBoxBtn.TabIndex = 13;
            this.clearTextBoxBtn.Text = "Clear Text Field";
            this.clearTextBoxBtn.UseVisualStyleBackColor = true;
            // 
            // customerNoTextBox
            // 
            this.customerNoTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.customerNoTextBox.Location = new System.Drawing.Point(21, 31);
            this.customerNoTextBox.Name = "customerNoTextBox";
            this.customerNoTextBox.Size = new System.Drawing.Size(126, 22);
            this.customerNoTextBox.TabIndex = 14;
            this.customerNoTextBox.Text = "358290";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(19, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 15);
            this.label5.TabIndex = 15;
            this.label5.Text = "Nr klienta";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(501, 383);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(111, 55);
            this.button4.TabIndex = 16;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // teamNameTextBox
            // 
            this.teamNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.teamNameTextBox.Location = new System.Drawing.Point(21, 72);
            this.teamNameTextBox.Name = "teamNameTextBox";
            this.teamNameTextBox.Size = new System.Drawing.Size(126, 22);
            this.teamNameTextBox.TabIndex = 1;
            this.teamNameTextBox.Text = "PLTN";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(515, 72);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 17;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.readExcellValues);
            // 
            // automaticWorkCheck
            // 
            this.automaticWorkCheck.AutoSize = true;
            this.automaticWorkCheck.Location = new System.Drawing.Point(515, 14);
            this.automaticWorkCheck.Name = "automaticWorkCheck";
            this.automaticWorkCheck.Size = new System.Drawing.Size(124, 17);
            this.automaticWorkCheck.TabIndex = 18;
            this.automaticWorkCheck.Text = "Praca Automatyczna";
            this.automaticWorkCheck.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(227, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.automaticWorkCheck);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.customerNoTextBox);
            this.Controls.Add(this.clearTextBoxBtn);
            this.Controls.Add(this.createFileBtn);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.saveCoordinatesBtn);
            this.Controls.Add(this.startProcess);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.contactPersonNumberTextBox);
            this.Controls.Add(this.regionDesignationTextBox);
            this.Controls.Add(this.teamNameTextBox);
            this.Controls.Add(this.textBoxLog);
            this.Name = "MainForm";
            this.Text = "SAP Mouse";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.TextBox regionDesignationTextBox;
        private System.Windows.Forms.TextBox contactPersonNumberTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button startProcess;
        private System.Windows.Forms.Button saveCoordinatesBtn;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button createFileBtn;
        private System.Windows.Forms.Button clearTextBoxBtn;
        private System.Windows.Forms.TextBox customerNoTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox teamNameTextBox;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.CheckBox automaticWorkCheck;
        private System.Windows.Forms.Button button1;
    }
}

