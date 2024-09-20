namespace UNOCT_Tech_Test
{
    [TestFixture]
    public class TC_002_Assert_goTravel_Logo : BaseClass
    {
        [Test]
        public void TC_002_AssertGoTravelLogo()
        {
            //GIVEN:user navigate to the goTravel Software Solutions webpage
            driver.Navigate().GoToUrl(ProjectConfiguration.Selenium_URL + "/goTravel");

            //WHEN: user checks if the logo is loaded
            var isPresent = objCTTravel.AssergoTravelLogoPresence();

            //THEN: user is able to know that logo is present on the webpage

            Assert.That(isPresent, Is.True, "goTravel Logo is loaded on the webpage");
        }

        [TearDown]
        public void TearDown() 
        {
            TestCleanup();
        }
    }
}
