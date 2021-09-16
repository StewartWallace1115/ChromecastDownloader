using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ChromecastDownloader
{
    public class FileManager
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)] // used to set background when updating image
        private static extern Int32 SystemParametersInfo(UInt32 uiAction, UInt32 uiParam, String pvParam, UInt32 fWinIni);

        private const int AMOUNT_IMAGES_SAVED_ON_COMPUTER = 10;
        private static UInt32 SPI_SETDESKWALLPAPER = 20;
        private static UInt32 SPIF_UPDATEINIFILE = 0x1;
        private int imageCounter = 0;
        public string directoryLocation { get; set; } = "";
        public string downloadFileLocation { get; set; } = "";

        /// <summary>
        /// Set the wallpaper to the file location
        /// </summary>
        public void updateBackground()
        {
            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, downloadFileLocation, SPIF_UPDATEINIFILE);
        }

        /// <summary>
        /// Create a new filename for the image to be downloaded.
        /// </summary>
        /// <param name="webDriver">Used to download images from Chromecast website</param>
        public void downloadNewImage(WebDriver webDriver)
        {
            downloadFileLocation = directoryLocation +"\\" + imageCounter + ".png";
            webDriver.downloadImageFromUrl(downloadFileLocation);

            imageCounter++;

            if (imageCounter > AMOUNT_IMAGES_SAVED_ON_COMPUTER)
            {
                imageCounter = 0;
            }

        }

        /// <summary>
        /// Check if directory location was set.
        /// </summary>
        public bool isDirectoryLocationSet()
        {
            return !directoryLocation.Equals("");
        }
    }
}
