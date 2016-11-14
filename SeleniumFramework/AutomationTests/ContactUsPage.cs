using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.Framework.AutomationTests
{
    public class ContactUsPage
    {
        public static void Goto()
        {
            var URL = ConfigurationManager.AppSettings["Url"];
            var ContactUsLink = "CONTACT Us".ToUpper();
            Driver.Instance.Navigate().GoToUrl(URL);
            Driver.Instance.FindElement(By.LinkText(ContactUsLink)).Click();

        }
        public static void SubmitEnquiry(string name, string phone, string email, string subject, string comment)
        {
            Driver.Instance.FindElement(By.Id("Name")).Clear();
            Driver.Instance.FindElement(By.Id("Name")).SendKeys(name);
            Driver.Instance.FindElement(By.Id("PhoneNo")).Clear();
            Driver.Instance.FindElement(By.Id("PhoneNo")).SendKeys(phone);
            Driver.Instance.FindElement(By.Id("EmailFrom")).Clear();
            Driver.Instance.FindElement(By.Id("EmailFrom")).SendKeys(email);

            var SubjectSelect = Driver.Instance.FindElement(By.Id("Subject"));
            var selectElement = new SelectElement(SubjectSelect);
            selectElement.SelectByText(subject);

            Driver.Instance.FindElement(By.Id("Comment")).Clear();
            Driver.Instance.FindElement(By.Id("Comment")).SendKeys(comment);

            // click | css=input[type="submit"] | 
            Driver.Instance.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();

        }

        public static int RequiredFields()
        {
            WebDriverWait wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementExists(By.CssSelector("span.field-validation-error")));
            var ElementLenght = Driver.Instance.FindElements(By.CssSelector("span.field-validation-error"));
            return ElementLenght.Count();
        }

        public static string WrongEmailFormat()
        {
            WebDriverWait wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(10));
            var reslutElement = wait.Until(d => {

                var elements = Driver.Instance.FindElements(By.XPath("//span[@for='EmailFrom']"));

                if (elements.Count > 0)
                    return elements[0];
                return null;
            });
            return reslutElement == null ? string.Empty : reslutElement.Text;
        }

        public static string SuccessFull()
        {
            WebDriverWait wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(10));
            var reslutElement = wait.Until(d =>
            {
                var elements = Driver.Instance.FindElements(By.CssSelector("p.errorSummary.success"));
                if (elements.Count > 0)
                    return elements[0];
                return null;
            });
            return reslutElement == null ? string.Empty : reslutElement.Text;
        }

    }
}
//wait.Until(ExpectedConditions.ElementToBeSelected(By.PartialLinkText("Message Sent!"))); //Locate element by partial linkText. 
//return driver.FindElement(By.CssSelector("p.errorSummary.success"));
//use either line above or below
