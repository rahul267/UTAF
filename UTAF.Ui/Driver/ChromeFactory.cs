using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTAF.Ui.Driver
{
    public class ChromeFactory
    {
        public static IWebDriver GetWebDriver()
        {
            string localDriverPath = @"C:\Users\UX508696\Downloads\chromedriver-121\chromedriver-win64\chromedriver";
            if (File.Exists(localDriverPath))
            {
                return GetLocalWebDriver(localDriverPath);
            }

            // Attempt to download WebDriver executable automatically
            try
            {
                return GetRemoteWebDriver();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to download WebDriver executable: {ex.Message}");
                // Fall back to using a pre-installed WebDriver executable on your system
                string preinstalledDriverPath = @"C:\Users\UX508696\Downloads\chromedriver-121\chromedriver-win64\chromedriver";
                return GetLocalWebDriver(preinstalledDriverPath);
            }
        }

        private static IWebDriver GetLocalWebDriver(string driverPath)
        {
            
            var options = new ChromeOptions(); 
            options.BinaryLocation = driverPath; 
            return new ChromeDriver(options); 
        }

        private static IWebDriver GetRemoteWebDriver()
        {
            return new ChromeDriver();
        }
    }

   

    }

