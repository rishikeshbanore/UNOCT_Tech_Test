
namespace UNOCT_Tech_Test
{
    public static class ProjectConfiguration
    {
        #region Variable declaration
        public static Dictionary<string, string> GetProjectConfig { get; }
        public static string Selenium_ApplicationName;
        public static string Selenium_Environment;
        public static string Selenium_URL;
        public static string Selenium_Browser;
        public static string Selenium_UserName;
        public static string Selenium_Email;
        public static string Selenium_Password;
        public static string Selenium_Search_Term;
        public static string Selenium_Search_Result_Count;
        public static string Selenium_Search_Result_Term;

        #endregion

        // Static constructor
        static ProjectConfiguration()
        {
            // Get the project's assembly path (<Project_Name>\bin\Debug) 
            var Path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            // Read LocalConfig.json
            string projectconfig = System.IO.File.ReadAllText(Path + "\\config\\LocalConfig.json");

            // Serialize & Deserialize JSON using JavaScriptSerializer
            GetProjectConfig =  JsonConvert.DeserializeObject<Dictionary<string, string>>(projectconfig);

            Selenium_ApplicationName = GetProjectConfig["Selenium_ApplicationName"];
            Selenium_Environment = GetProjectConfig["Selenium_Environment"];
            Selenium_URL = GetProjectConfig["Selenium_URL"];
            Selenium_Browser = GetProjectConfig["Selenium_Browser"];
            Selenium_UserName = GetProjectConfig["Selenium_UserName"];
            Selenium_Password = GetProjectConfig["Selenium_Password"];
            Selenium_Email = GetProjectConfig["Selenium_Email"];
            Selenium_Search_Result_Count = GetProjectConfig["Selenium_Search_Result_Count"];
            Selenium_Search_Term = GetProjectConfig["Selenium_Search_Term"];
            Selenium_Search_Result_Term = GetProjectConfig["Selenium_Search_Result_Term"];
        }

    }
}
