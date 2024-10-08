﻿using UNOCT_Tech_Test;

namespace UNOCT_Tech_Test
{
    [TestFixture]
    public class TC_001_Search_Home_Page : BaseClass
    {
        [Test]
        public void TC_001_SearchVerificationTest()
        {
            //GIVEN: user is on the home of ctt is able to use searh functionality
            objCTTravel.SearchTerm(ProjectConfiguration.Selenium_Search_Term);

            //WHEN: user search for the title and count of the search results
            var result = objCTTravel.AssertSearchResults(ProjectConfiguration.Selenium_Search_Result_Term, ProjectConfiguration.Selenium_Search_Result_Count);

            //THEN: user is able to see the expected search title and expectyed search result count
            Assert.That(result, Is.True, "Search Result File is found and Search result Count is matched.");
        }

        [TearDown]
        public void TearDown() 
        {
            TestCleanup();
        }
    }
}