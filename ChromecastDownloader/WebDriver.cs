using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ChromecastDownloader
{
    public class WebDriver
    {
        private const string GOOGLE_CHROMECAST_URL = "https://clients3.google.com/cast/chromecast/home";
        IWebDriver driver;

        /// <summary>
        /// Setup web driver 
        /// TODO: Add support for other browsers. 
        /// </summary>
        public void start()
        {
            setupChromeDriver();
        }

        /// <summary>
        /// Setup Chrome to run in background with no logging and navigate to Chromecast website.
        /// </summary>
        void setupChromeDriver()
        {
            ChromeOptions options = new ChromeOptions();
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();

            options.AddArgument("--headless");
            options.AddArgument("--log-level=3");
            service.SuppressInitialDiagnosticInformation = true;
            service.HideCommandPromptWindow = true;
            driver = new ChromeDriver(service, options);
            driver.Navigate().GoToUrl(GOOGLE_CHROMECAST_URL);
            
        }

        /// <summary>
        /// Download image from Chromecast website to local  location. 
        /// </summary>
        /// <param name="downloadFileLocation">Location to download images</param>
        public void downloadImageFromUrl(string downloadFileLocation)
        {

            String str = driver.PageSource;

            var htmldoc = new HtmlAgilityPack.HtmlDocument();
            htmldoc.LoadHtml(str);
            var element = htmldoc.GetElementbyId("picture-background");
            var downloadImageURL = element.Attributes["ng-src"].Value;

            using (WebClient client = new WebClient())
            {
                client.DownloadFile(new Uri(downloadImageURL), downloadFileLocation);
            }
        }

        /// <summary>
        /// Closes webdriver
        /// </summary>
        public void cleanup()
        {
            if (driver != null)
            {
                driver.Close();
            }
        }
    }
}
