
namespace UNOCT_Tech_Test
{
    public class SeleniumSetMethodLibrary
    {
        private readonly IWebDriver driver;


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
            catch (WebDriverException) // Catch specific WebDriver exceptions
            {
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
            catch (WebDriverException)
            {
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


        public void ClickElement(IWebElement webElement)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(webElement)).Click();
            }
            catch (WebDriverTimeoutException)
            {
                throw;
            }
        }

        public void EnterText(IWebElement webElement, string value)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(webElement)).SendKeys(value);
            }
            catch (WebDriverTimeoutException)
            {
                throw;
            }
        }

        public void SelectDropDown(IWebElement element, string text)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
                new SelectElement(element).SelectByText(text);
            }
            catch (NoSuchElementException)
            {
 
                throw;
            }
            catch (WebDriverTimeoutException)
            {
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
            catch (ElementNotVisibleException)
            {
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
            catch (WebDriverTimeoutException)
            {
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
            catch (NoSuchWindowException)
            {
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
            catch (NoSuchFrameException)
            {
                throw;
            }
        }

        public void SwitchToDefaultFrame()
        {
            try
            {
                driver.SwitchTo().DefaultContent();
            }
            catch (Exception)
            {
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
            catch (ElementNotVisibleException)
            {
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
            catch (NoAlertPresentException)
            {
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
            catch (Exception)
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
            catch (Exception)
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
            catch (Exception)
            {
                throw;
            }
        }

        // Method to verify if the page title matches the expected title
        public bool verifyPageTitle(string expectedTitle)
        {
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
            catch (Exception)
            {
                throw;
            }
        }

        // Method to check if a web element is not visible
        public bool isWebElementNotVisible(IWebElement webElement, string elementInfo)
        {
            try
            {
                if (!webElement.Displayed)
                {
                    Thread.Sleep(1000);
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Method to check if an input field is editable
        public bool isInputFieldEditable(IWebElement webElement)
        {
            try
            {
                webElement.Clear();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Method to verify if the text of a web element matches the expected text
        public void verifyText(IWebElement webElement, string expectedText)
        {
            try
            {
                if (!webElement.Text.Trim().Equals(expectedText.Trim()))
                {
                    throw new Exception("Wrong Text: " + webElement.Text + " => Expected Text: " + expectedText);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Method to switch to another window by page title
        public void windowSwitch(string pageTitle)
        {
            try
            {
                ReadOnlyCollection<string> handles = driver.WindowHandles;
                foreach (string handle in handles)
                {
                    if (driver.SwitchTo().Window(handle).Title.Equals(pageTitle))
                    {
                        return;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Handle window pop-ups
        public void windowHandler(IWebElement webElement)
        {
            try
            {
                string parentWindow = driver.CurrentWindowHandle;
                PopupWindowFinder finder = new PopupWindowFinder(driver);
                string popupWindowHandle = finder.Click(webElement);
                driver.SwitchTo().Window(popupWindowHandle);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Switch back to the parent window
        public void switchToParentWindow()
        {
            try
            {
                string parentWindow = driver.CurrentWindowHandle;
                driver.Close();
                driver.SwitchTo().Window(parentWindow);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Close the current browser window
        public void windowClose()
        {
            try
            {
                driver.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Navigate to the previous page
        public void navigateToPreviousPage()
        {
            try
            {
                driver.Navigate().Back();
                Thread.Sleep(3000);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Change the current URL
        public void changeURL(string url)
        {
            try
            {
                driver.Navigate().GoToUrl(url);
            }
            catch (Exception)
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
