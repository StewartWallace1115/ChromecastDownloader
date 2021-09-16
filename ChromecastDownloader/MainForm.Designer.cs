namespace ChromecastDownloader
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
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.secondsTimerBtn = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.secondsTimerTextField = new System.Windows.Forms.TextBox();
            this.startStopBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.errorLabel = new System.Windows.Forms.Label();
            this.directoryLocationTextBox = new System.Windows.Forms.TextBox();
            this.setDownloadDirectoryButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 91);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1414, 535);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // secondsTimerBtn
            // 
            this.secondsTimerBtn.Location = new System.Drawing.Point(448, 43);
            this.secondsTimerBtn.Name = "secondsTimerBtn";
            this.secondsTimerBtn.Size = new System.Drawing.Size(75, 23);
            this.secondsTimerBtn.TabIndex = 1;
            this.secondsTimerBtn.Text = "Set seconds ";
            this.secondsTimerBtn.UseVisualStyleBackColor = true;
            this.secondsTimerBtn.Click += new System.EventHandler(this.secondsTimerBtn_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // secondsTimerTextField
            // 
            this.secondsTimerTextField.Location = new System.Drawing.Point(285, 43);
            this.secondsTimerTextField.Name = "secondsTimerTextField";
            this.secondsTimerTextField.Size = new System.Drawing.Size(138, 20);
            this.secondsTimerTextField.TabIndex = 2;
            this.secondsTimerTextField.Text = "Default 30";
            // 
            // startStopBtn
            // 
            this.startStopBtn.Location = new System.Drawing.Point(908, 44);
            this.startStopBtn.Name = "startStopBtn";
            this.startStopBtn.Size = new System.Drawing.Size(75, 23);
            this.startStopBtn.TabIndex = 3;
            this.startStopBtn.Text = "Start";
            this.startStopBtn.UseVisualStyleBackColor = true;
            this.startStopBtn.Click += new System.EventHandler(this.startStop_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Updates even if image on Chromecast has not updated.";
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(9, 65);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(0, 13);
            this.errorLabel.TabIndex = 5;
            // 
            // directoryLocationTextBox
            // 
            this.directoryLocationTextBox.Location = new System.Drawing.Point(543, 43);
            this.directoryLocationTextBox.Name = "directoryLocationTextBox";
            this.directoryLocationTextBox.ReadOnly = true;
            this.directoryLocationTextBox.Size = new System.Drawing.Size(138, 20);
            this.directoryLocationTextBox.TabIndex = 8;
            this.directoryLocationTextBox.Text = "FilePath";
            // 
            // setDownloadDirectoryButton
            // 
            this.setDownloadDirectoryButton.Location = new System.Drawing.Point(699, 44);
            this.setDownloadDirectoryButton.Name = "setDownloadDirectoryButton";
            this.setDownloadDirectoryButton.Size = new System.Drawing.Size(184, 23);
            this.setDownloadDirectoryButton.TabIndex = 7;
            this.setDownloadDirectoryButton.Text = "Set Directory Location";
            this.setDownloadDirectoryButton.UseVisualStyleBackColor = true;
            this.setDownloadDirectoryButton.Click += new System.EventHandler(this.setDownloadDirectoryButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1453, 638);
            this.Controls.Add(this.directoryLocationTextBox);
            this.Controls.Add(this.setDownloadDirectoryButton);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.startStopBtn);
            this.Controls.Add(this.secondsTimerTextField);
            this.Controls.Add(this.secondsTimerBtn);
            this.Controls.Add(this.pictureBox1);
            this.Name = "MainForm";
            this.Text = "Chromecast Image Downloader";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button secondsTimerBtn;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox secondsTimerTextField;
        private System.Windows.Forms.Button startStopBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.TextBox directoryLocationTextBox;
        private System.Windows.Forms.Button setDownloadDirectoryButton;
    }
}

