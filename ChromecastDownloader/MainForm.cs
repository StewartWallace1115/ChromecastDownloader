using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace ChromecastDownloader
{
    public partial class MainForm : Form
    {
        WebDriver driver;
        FileManager fileManager;
        bool areImagesDownloading = false; // Starts false so user has to start the program
        const int SECONDS_CONVERTER = 1000;
        const string SECOND_NON_NUMBER = "Seconds must be a number greater than 0";
        const string SECOND_BLANK = "Seconds field cannot be blank";
        const string DIRECTORY_ERROR_MESSAGE = "Directory path is not set";
        private const int DEFAULT_SECONDS_30 = 30000;

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Download new image from Chromecast website, and update both picturebox and background.
        /// </summary>
        private void timer1_Tick(object sender, EventArgs e)
        {
            fileManager.downloadNewImage(driver);
            updatePictureBox();
            fileManager.updateBackground();
        }

        /// <summary>
        /// Update picturebox
        /// </summary>
        private void updatePictureBox()
        {
            pictureBox1.Image = Image.FromFile(fileManager.downloadFileLocation);
        }

        /// <summary>
        /// Change the state of the program to either stop or start. 
        /// The filepath must be set before starting.
        /// </summary>
        private void startStop_Click(object sender, EventArgs e)
        {
            if (areImagesDownloading)
            {
                timer1.Stop();
                areImagesDownloading = false;
                startStopBtn.Text = "Start";
                // Clear error Label if program started or stopped successfully 
                errorLabel.Text = "";
            }
            else
            {
                if (fileManager.isDirectoryLocationSet())
                {
                    timer1_Tick(null, null); 
                    timer1.Start();
                    areImagesDownloading = true;
                    startStopBtn.Text = "Stop";
                    // Clear error Label if program started or stopped successfully
                    errorLabel.Text = "";
                }
                else
                {
                    errorLabel.Text = DIRECTORY_ERROR_MESSAGE;
                }
            }
        }
        /// <summary>
        /// Change the amount of seconds before updating background and picturebox.
        /// </summary>
        private void secondsTimerBtn_Click(object sender, EventArgs e)
        {          
            string secondsTimerText = secondsTimerTextField.Text;
            if (!string.IsNullOrWhiteSpace(secondsTimerText))
            {
                bool isNumeric = int.TryParse(secondsTimerText, out int number);
                if (isNumeric && number > 0)
                {
                    timer1.Interval = number * SECONDS_CONVERTER;
                    errorLabel.Text = "";
                }
                else
                {
                    errorLabel.Text = SECOND_NON_NUMBER;
                }
            }
            else
            { 
                errorLabel.Text = SECOND_BLANK; 
            }
        }

        /// <summary>
        /// Set the current directory for image download location.
        /// </summary>
        private void setDownloadDirectoryButton_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                DialogResult result = folderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    fileManager.directoryLocation = folderBrowserDialog.SelectedPath;
                    directoryLocationTextBox.Text = fileManager.directoryLocation;
                }
            }
        }

        /// <summary>
        /// Starts webdriver and file manager objects. Creates timer with default value.
        /// </summary>
        private void mainForm_Load(object sender, EventArgs e)
        {
            driver = new WebDriver();
            driver.start();
            fileManager = new FileManager();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = DEFAULT_SECONDS_30;
        }

        /// <summary>
        /// Autosizes picturebox when form is resized.
        /// </summary>
        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
        }
        /// <summary>
        /// Cleans up webdriver
        /// </summary>
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            driver.cleanup();
        }
    }
}
