using System;
using System.IO;
using ChromecastDownloader;
using Xunit;

namespace TestChromecastDownloader
{
    public class ChromecastDownloaderTests
    {
        
        [Fact]
        public void TestEmptyDirectoryLocation()
        {
            FileManager fileManger = new FileManager();
            Assert.False(fileManger.isDirectoryLocationSet());
        }


        [Fact]
        public void TestNonEmptyDirectoryLocation()
        {
            FileManager fileManger = new FileManager();
            fileManger.directoryLocation = @"C:\test\";
            Assert.True(fileManger.isDirectoryLocationSet());
        }


        [Fact]
        public void TestDownloadImageSuccessful()
        {
            string path = @"c:\temp\0.png";
       

            WebDriver webDriver = new WebDriver();
            webDriver.start();
            webDriver.downloadImageFromUrl(path);
            
            Assert.True(File.Exists(path));
            webDriver.cleanup();
        }

        [Fact]
        public void TestFileDownloadImageSuccessful()
        {
            string path = @"c:\temp";
            string filePath = @"c:\temp\0.png";

            WebDriver webDriver = new WebDriver();
            webDriver.start();
            FileManager fileManager = new FileManager();
            fileManager.directoryLocation = path;
            fileManager.downloadNewImage(webDriver);

            Assert.True(File.Exists(filePath));
            webDriver.cleanup();
        }

        [Fact]
        public void TestFileDownloadImageCounterResets()
        {
            string path = @"c:\temp";
            string filePath = @"c:\temp\11.png";

            WebDriver webDriver = new WebDriver();
            webDriver.start();
            FileManager fileManager = new FileManager();
            fileManager.directoryLocation = path;

            for(int i = 0; i < 11; ++i)
                fileManager.downloadNewImage(webDriver);

            Assert.False(File.Exists(filePath));
            webDriver.cleanup();
        }
    }
}
