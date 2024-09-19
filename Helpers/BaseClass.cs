
namespace UNOCT_Tech_Test
{   
    public class BaseClass : Driver
    {
        public ExtentReports reportsclass { get; set; }
        public ExtentTest ReportLogger { get; set; }
        public SeleniumSetMethodLibrary objSeleniumMethodLib { get; set; }
        public OR_CT_Travel objCTTravel { get; set; }
        
        public string testCaseName { get; set; }

        // Contructor for the class
        public BaseClass()
        {
            objSeleniumMethodLib = new SeleniumSetMethodLibrary(driver);
            objCTTravel = new OR_CT_Travel(driver);
        }

        // Generic TestCleanup() method for all the test scripts
        public void TestCleanup()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
