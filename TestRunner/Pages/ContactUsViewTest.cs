
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using Selenium.Framework;
using Selenium.Framework.AutomationTests;

namespace Test.Runner.Pages
{
    [TestClass]
    public class ContactUsViewTest
    {

        [TestInitialize]
        public void init()
        {
            Driver.Initialize();
        }


        [TestMethod]
        public void ContactUsChrome_Should_be_successfull()
        {
            ContactUsPage.Goto();
            ContactUsPage.SubmitEnquiry("Test Name", "0453215487", ConfigurationManager.AppSettings["Email"], Enums.ContactUs_Subject.optionExpiredCard.GetDescription(), "Test Comment");
            var reslutElement = ContactUsPage.SuccessFull();
            var Msg = "Message Sent! We will endeavour to respond to your enquiry within 24 hours.";
            Assert.AreEqual(reslutElement.ToUpper(), Msg.ToUpper());
        }


      
        [TestMethod]
        public void ContactUsChrome_Should_Fail_WrongEmailFormat()
        {

            ContactUsPage.Goto();
            ContactUsPage.SubmitEnquiry("", "", "xxxx.com", Enums.ContactUs_Subject.CardNotWorking.GetDescription(), "");
            var reslutElement = ContactUsPage.WrongEmailFormat();
            var Msg = "The Email Address field is not a valid e-mail address.";
            Assert.AreEqual(reslutElement.ToUpper(), Msg.ToUpper());
            

 
        }


        [TestMethod]
        public void ContactUsChrome_Should_Fail_RequiredFields()
        {

            ContactUsPage.Goto();
            ContactUsPage.SubmitEnquiry("", "", "", Enums.ContactUs_Subject.CardNotWorking.GetDescription(), "");
            var reslutElement = ContactUsPage.RequiredFields();
            Assert.AreEqual(reslutElement, 4);
        }


        [TestCleanup]
        public void CleanUp()
        {
            Driver.Close();
        }



    }
}





