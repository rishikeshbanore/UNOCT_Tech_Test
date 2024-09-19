
namespace UNOCT_Tech_Test
{
    public class Driver
    {
        public IWebDriver driver = null;

        public Driver()
        {
            String Browser = ProjectConfiguration.Selenium_Browser;
            String URL = ProjectConfiguration.Selenium_URL;
            try
            {
                if (driver == null)
                {
                    switch (Browser.ToLower())
                    {
                        case "chrome":

                            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
                            var options = new ChromeOptions();
                            options.AddArgument("--disable-search-engine-choice-screen");
                            driver = new ChromeDriver(options);
                            break;
                    }
                    driver.Navigate().GoToUrl(URL);
                    driver.Manage().Window.Maximize();
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Driver instance is not null. Close all the drivers and try again" + e.Message);
            }
        }
    }

}


