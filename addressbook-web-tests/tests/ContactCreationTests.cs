// using System;
// using System.Text;
// using System.Text.RegularExpressions;
// using System.Threading;
// using addressbook_web_tests;
// using NUnit.Framework;
// using NUnit.Framework.Legacy;
// using OpenQA.Selenium;
// using OpenQA.Selenium.Chrome;
// using OpenQA.Selenium.Support.UI;
//
// namespace WebAddressBookTests
// {
//     [TestFixture]
//     public class ContactCreationTests : TestBase
//     {
//         [Test]
//         public void ContactCreationTest()
//         {
//             app.Navigation.OpenHomePage();
//             app.Auth.Login(new AccountData("admin", "secret"));
//             GoToContactPage();
//             ContactData contact = new ContactData("aa", "cc");
//             FillContactForm(contact);
//             SubmitContactCreation();
//             ReturnToHomePage();
//         }
//
//         private void ReturnToHomePage()
//         {
//             driver.FindElement(By.LinkText("home")).Click();
//             driver.Navigate().GoToUrl("http://localhost/addressbook/");
//         }
//
//         private void SubmitContactCreation()
//         {
//             driver.FindElement(By.XPath("//input[20]")).Click();
//             driver.Navigate().GoToUrl("http://localhost/addressbook/");
//         }
//
//         private void FillContactForm(ContactData contact)
//         {
//             driver.FindElement(By.Name("firstname")).Click();
//             driver.FindElement(By.Name("firstname")).Clear();
//             driver.FindElement(By.Name("firstname")).SendKeys(contact.FirstName);
//             driver.FindElement(By.Name("lastname")).Click();
//             driver.FindElement(By.Name("lastname")).Clear();
//             driver.FindElement(By.Name("lastname")).SendKeys(contact.LastName);
//         }
//
//         private void GoToContactPage()
//         {
//             driver.FindElement(By.LinkText("add new")).Click();
//             driver.Navigate().GoToUrl("http://localhost/addressbook/edit.php");
//         }
//     }
// }