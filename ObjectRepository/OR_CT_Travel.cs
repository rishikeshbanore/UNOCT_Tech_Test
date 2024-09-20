
namespace UNOCT_Tech_Test
{
    public class OR_CT_Travel
    {
        public IWebDriver driver;
        SeleniumSetMethodLibrary objSeleniumMethodLib;

        public OR_CT_Travel(IWebDriver driver)
        {
            this.driver = driver;
            objSeleniumMethodLib = new SeleniumSetMethodLibrary(this.driver);
        }

        #region Locators for CT Travel Home Page

        //Locator for Search Text Box Container
        public IWebElement TB_Search => driver.FindElement(By.Name("search_block_form"));

        //Locator for Submit Button
        public IWebElement Button_Submit => driver.FindElements(By.XPath("//button[@type='submit']")).First();

        //Locator for Search Results 
        public IList<IWebElement> SearchResults => driver.FindElements(By.CssSelector("ol.search-results li.search-result h3.title a"));

        //Locator for goTravel Image
        public IWebElement Image => driver.FindElement(By.ClassName("panopoly-image-full"));

        #endregion Locators for CT Travel Home Page


        public bool AssergoTravelLogoPresence()
        {
            return Image?.Displayed ?? false;
        }

        #region Methods for CT Travel Home  Page

        public void SearchTerm(string? searchTerm)
        {
            objSeleniumMethodLib.EnterText(TB_Search, searchTerm);
            objSeleniumMethodLib.ClickElement(Button_Submit);
        }

        public bool AssertSearchResults(string ? searchResultTitle, string? searchResultCount)
        {
            List<string> resultTitle = new List<string>();

            foreach (var result in SearchResults) 
            {
                resultTitle.Add(result.Text);
            }

            return (resultTitle.Count == Int32.Parse(searchResultCount) && (resultTitle.Contains(searchResultTitle)));
      
        }
        #endregion Methods for CT Travel Home Page
    }
}