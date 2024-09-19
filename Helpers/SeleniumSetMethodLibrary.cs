
namespace UNOCT_Tech_Test
{
    public class SeleniumSetMethodLibrary
    {
        private readonly IWebDriver driver;
        private readonly string testCaseName;
        private readonly ExtentTest reportLogger;

        // Constructor for the class
        public SeleniumSetMethodLibrary(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentNullException(nameof(driver));
        }

        // -------------------- Generic Methods ----------------------

        // Navigate to Browser
        public void NavigateToURL(string url)
        {
            try
            {
                driver.Navigate().GoToUrl(url);
            }
            catch (WebDriverException ex) // Catch specific WebDriver exceptions
            {
                string message = ex.Message;
                throw;
            }
        }

        // Maximize the Browser
        public void Maximize()
        {
            try
            {
                driver.Manage().Window.Maximize();
                WaitForLoad(100); // Use explicit wait instead of Thread.Sleep
            }
            catch (WebDriverException ex)
            {
                string message = ex.Message;
                throw;
            }
        }

        // Explicit wait method (to replace Thread.Sleep)
        public void WaitForLoad(int milliseconds)
        {
            // Consider using WebDriverWait or FluentWait instead of hard wait
            var wait = new WebDriverWait(new SystemClock(), driver, TimeSpan.FromMilliseconds(milliseconds), TimeSpan.FromMilliseconds(100));
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").ToString() == "complete");
        }

        // Get current timestamp
        public string GetTimestamp(DateTime value)
        {
            return value.ToString("yyyy-MM-dd_HH-mm-ss");
        }


        public async Task ClickElement(IWebElement webElement)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(webElement)).Click();
            }
            catch (WebDriverTimeoutException ex)
            {
                string message = ex.Message;
                throw;
            }
        }

        public async Task EnterText(IWebElement webElement, string value)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(webElement)).SendKeys(value);
            }
            catch (WebDriverTimeoutException ex)
            {
                string message = ex.Message;
                throw;
            }
        }

        public void SelectDropDown(IWebElement element, string text)
        {
            const string methodName = "SelectDropDown";
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
                new SelectElement(element).SelectByText(text);
            }
            catch (NoSuchElementException ex)
            {
                string message = ex.Message;
                throw;
            }
            catch (WebDriverTimeoutException ex)
            {
                string message = ex.Message;
                throw;
            }
        }

        public void SelectCheckBox(IWebElement webElement)
        {
            try
            {
                if (webElement.Displayed && !webElement.Selected)
                {
                    webElement.Click();
                }
                else
                {
                }
            }
            catch (ElementNotVisibleException ex)
            {
                string message = ex.Message;
                throw;
            }
        }

        public void SelectRadioButton(IWebElement element)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element)).Click();
            }
            catch (WebDriverTimeoutException ex)
            {
                string message = ex.Message;
                throw;
            }
        }

        public string GetText(IWebElement webElement)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(webElement));
                string text = webElement.Text;
                return text;
            }
            catch (WebDriverTimeoutException ex)
            {
                string message = ex.Message;
                return message;
            }
        }

        public void SwitchToActiveWindow()
        {
            try
            {
                driver.SwitchTo().ActiveElement();
            }
            catch (NoSuchWindowException ex)
            {
                string message = ex.Message;
                throw;
            }
        }

        public void SwitchToFrame(IWebElement frame)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(frame));
                driver.SwitchTo().Frame(frame);
            }
            catch (NoSuchFrameException ex)
            {
                string message = ex.Message;
                throw;
            }
        }

        public void SwitchToDefaultFrame()
        {
            try
            {
                driver.SwitchTo().DefaultContent();
              }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw;
            }
        }

        public void ClearText(IWebElement webElement)
        {
            try
            {
                if (webElement.Displayed)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(webElement)).Clear();
                }
            }
            catch (ElementNotVisibleException ex)
            {
                string message = ex.Message;
                throw;
            }
        }

        public void AcceptAlert()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                alert.Accept();
            }
            catch (NoAlertPresentException ex)
            {
                string message = ex.Message;
                throw;
            }
        }

        // Method to select a checkbox if it is not already selected
        public void selectCheckbox(IWebElement webElement, string elementInfo, By byLocator)
        {
             try
            {
                bool elementDisplayed = WaitTillElementIsDisplayed(driver, byLocator, 10);
                if (elementDisplayed && !webElement.Selected)
                {
                    webElement.Click();
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        // Method to deselect a checkbox if it is selected
        public void deselectCheckbox(IWebElement webElement, string elementInfo)
        {
            try
            {
                if (!webElement.Selected)
                {
                    webElement.Click();
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        // Method to check if a web element is visible
        public bool isWebElementVisible(IWebElement webElement, string elementInfo)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(16));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(webElement));
                return webElement.Displayed;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // Method to verify if the page title matches the expected title
        public bool verifyPageTitle(string expectedTitle)
        {
            string methodName = "verifyPageTitle";
            try
            {
                if (driver.Title.Trim().Equals(expectedTitle.Trim()))
                {
                    Thread.Sleep(1000);
                    return true;
                }
                else
                {
                    throw new ElementNotVisibleException(expectedTitle + " is not the valid title!");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // Method to check if a web element is not visible
        public bool isWebElementNotVisible(IWebElement webElement, string elementInfo)
        {
            string methodName = "isWebElementNotVisible";
            try
            {
                if (!webElement.Displayed)
                {
                    Thread.Sleep(1000);
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // Method to check if an input field is editable
        public bool isInputFieldEditable(IWebElement webElement)
        {
            string methodName = "isInputFieldEditable";
            try
            {
                webElement.Clear();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // Method to verify if the text of a web element matches the expected text
        public void verifyText(IWebElement webElement, string expectedText)
        {
            string methodName = "verifyText";
            try
            {
                if (!webElement.Text.Trim().Equals(expectedText.Trim()))
                {
                    throw new Exception("Wrong Text: " + webElement.Text + " => Expected Text: " + expectedText);
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        // Method to switch to another window by page title
        public void windowSwitch(string pageTitle)
        {
            string methodName = "windowSwitch";
            try
            {
                ReadOnlyCollection<string> handles = driver.WindowHandles;
                foreach (string handle in handles)
                {
                    if (driver.SwitchTo().Window(handle).Title.Equals(pageTitle))
                    {
                        reportLogger.Pass("Redirected to correct page: " + driver.Title);
                        return;
                    }
                }
                reportLogger.Fail("The expected page " + pageTitle + " was not opened.");
            }
            catch (Exception e)
            {
                throw;
            }
        }

        // Handle window pop-ups
        public void windowHandler(IWebElement webElement)
        {
            string methodName = "windowHandler";
            try
            {
                string parentWindow = driver.CurrentWindowHandle;
                PopupWindowFinder finder = new PopupWindowFinder(driver);
                string popupWindowHandle = finder.Click(webElement);
                driver.SwitchTo().Window(popupWindowHandle);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        // Switch back to the parent window
        public void switchToParentWindow()
        {
            string methodName = "switchToParentWindow";
            try
            {
                string parentWindow = driver.CurrentWindowHandle;
                driver.Close();
                driver.SwitchTo().Window(parentWindow);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        // Close the current browser window
        public void windowClose()
        {
            string methodName = "windowClose";
            try
            {
                driver.Close();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        // Navigate to the previous page
        public void navigateToPreviousPage()
        {
            string methodName = "navigateToPreviousPage";
            try
            {
                driver.Navigate().Back();
                Thread.Sleep(3000);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        // Change the current URL
        public void changeURL(string url)
        {
            string methodName = "changeURL";
            try
            {
                driver.Navigate().GoToUrl(url);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        // Additional helper methods

        public static bool WaitTillElementIsDisplayed(IWebDriver driver, By byLocator, int timeoutInSeconds)
        {
            bool elementDisplayed = false;
            try
            {
                if (timeoutInSeconds > 0)
                {
                    var myWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                    myWait.Until(drv => drv.FindElement(byLocator).Displayed && drv.FindElement(byLocator).Enabled);
                }
                elementDisplayed = driver.FindElement(byLocator).Displayed;
            }
            catch (Exception e)
            {
                Assert.Fail("Exception in WaitTillElementIsDisplayed method: " + e.Message);
            }
            return elementDisplayed;
        }

    }
}
