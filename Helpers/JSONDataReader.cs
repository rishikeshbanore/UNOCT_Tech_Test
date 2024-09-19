
namespace UNOCT_Tech_Test
{
    public static class JSONDataReader
    {
        #region TestData_Files_Variable_declaration

        public static TestData_UNOCT_Tech_Test TestData { get; }

        //public static string SourceName;
        public static string? Attachment1;
        public static string? Attachment2;
        public static string? Home_Page_Title;


        #endregion TestData_Files_Variable_declaration

        // Static constructor for the class
        static JSONDataReader()
        {
            // Get the project's assembly path (<Project_Name>\bin\Debug) 
            var assemblyPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            //Read Test Data file
            string ReadTestData = System.IO.File.ReadAllText(assemblyPath + "\\TestData\\TestData_UNOCT_Tech_Test.json");

            //De serelize the Test Data File
            TestData = JsonConvert.DeserializeObject<TestData_UNOCT_Tech_Test>(ReadTestData);

            #region Get_Test_Data_Files_Variables

            Attachment1 = TestData.Attachment1;
            Attachment2 = TestData.Attachment2;
            Home_Page_Title = TestData.Home_Page_Title;


            #endregion Get_Test_Data_Files_Variables

            //  updates the document path with local config.

            if (TestData.Equals("Attachment1"))
            {
                Attachment1 = GetTestDataPath(TestData.Attachment1);
            }

            if (TestData.Equals("Attachment2"))
            {
                Attachment2 = GetTestDataPath(TestData.Attachment2);
            }
        }

        private static string GetTestDataPath(string testDataFile)
        {
            //  pull testdata from testdata folder (in bin)
            var fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $@"TestData\{testDataFile}");

            return fullPath;
        }
    }
}
