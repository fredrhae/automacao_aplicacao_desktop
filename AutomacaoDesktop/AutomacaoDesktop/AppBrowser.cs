using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Drawing.Imaging;


namespace AutomacaoDesktop
{
    public static class AppBrowser
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static string remoteAddress = "http://localhost:9999";
        private static string capabilityValue = @"C:/Program Files (x86)/Microsoft Office/Office14/WINWORD.EXE";
        private static string capability = "app";
        private static RemoteWebDriver webDriver;
        private static IWebElement wordWindows;

        public static bool Initialize()
        {
            log.Info("Inicializando driver do word no servidor remoto: " + remoteAddress);
            try
            {
                webDriver = new RemoteWebDriver(new Uri(remoteAddress), getCapability());
                wordWindows = webDriver.FindElementByClassName("OpusApp");
            } 
            catch (OpenQA.Selenium.WebDriverException ex)
            {
                log.Error("Servidor remoto não está respondendo: " + ex.Message);
                return false;
            }

            return true;
        }

        private static DesiredCapabilities getCapability()
        {
            var dc = new DesiredCapabilities();
            dc.SetCapability(capability, capabilityValue);

            return dc;
        }

        public static void TakeScreenShot(string pathToFolder)
        {

            log.Info("Criando a evidência de screenshot da aplicação em teste.");

            Screenshot ss = ((ITakesScreenshot)webDriver).GetScreenshot();

            var fileName = "screenshot".getShortTimeFileName() + ".png";

            ss.SaveAsFile(pathToFolder + fileName, ImageFormat.Png);
        }

        public static void SetTextInWord(string text)
        {
            var documentTextField = wordWindows.FindElement(By.ClassName("_WwG"));
            documentTextField.Click();
            documentTextField.SendKeys(text);
        }

        public static void SaveDocument(string pathToFolder)
        {

            var saveButton = wordWindows.FindElement(By.Name("Save"));
            saveButton.Click();

            // Find the popup save window
            var savePopup = webDriver.FindElementByName("Save As");

            // Set the filename of document
            var fileName = savePopup.FindElement(By.Id("1001"));
            fileName.Click();
            fileName.SendKeys(pathToFolder + "document".getShortTimeFileName());

            // Save the document
            savePopup.FindElement(By.Name("Save")).Click();
        }

        public static void Close()
        {
            log.Info("Fechando o arquivo word...");

            var closeButton = wordWindows.FindElement(By.Name("Fechar"));

            closeButton.Click();

            log.Info("Fechando a conexão com o driver remoto e saindo...");

            webDriver.Quit();
        }
    }
}
