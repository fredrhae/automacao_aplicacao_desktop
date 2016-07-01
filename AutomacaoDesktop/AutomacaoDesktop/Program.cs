using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;


namespace AutomacaoDesktop
{
    class Program
    {
        static void Main(string[] args)
        {
            var dc = new DesiredCapabilities();
            dc.SetCapability("app", @"C:/Program Files (x86)/Microsoft Office/Office14/WINWORD.EXE");
            var driver = new RemoteWebDriver(new Uri("http://localhost:9999"), dc);

            var textField = driver.FindElementByClassName("_WwG");
            textField.Click();
            textField.SendKeys("Alô alô testando");

            var saveButton = driver.FindElementByName("Save");
            saveButton.Click();

            var savePopup = driver.FindElementByName("Save As");
            var fileName = savePopup.FindElement(By.Id("1001"));
            fileName.Click();
            fileName.SendKeys("nome_qualquer");
            savePopup.FindElement(By.Name("Save")).Click();

            driver.Quit();
        }
    }
}
