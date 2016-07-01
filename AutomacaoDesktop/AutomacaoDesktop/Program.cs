using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Threading;


namespace AutomacaoDesktop
{
    class Program
    {
        private static string pathArquivoTextoEntrada = "automacao_desktop_texto_entrada.txt";
        private static string evidencesFolder = @"C:\Projeto\";

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        static void Main(string[] args)
        {

            if(AppBrowser.Initialize())
            {

                var inputText = FileManager.ReadFile(evidencesFolder + pathArquivoTextoEntrada);

                var arquivoVazio = string.IsNullOrEmpty(inputText);

                if (!arquivoVazio)
                {
                    AppBrowser.SetTextInWord(inputText);

                    Thread.Sleep(1000);

                    AppBrowser.TakeScreenShot(evidencesFolder);

                    AppBrowser.SaveDocument(evidencesFolder);
                }
                else
                {
                    log.Error("Arquivo de entrada está vazio.");
                }

                AppBrowser.Close();

                if (!arquivoVazio)
                    FileManager.DeleteFile(evidencesFolder + pathArquivoTextoEntrada);
            }
            else
            {
                log.Error("Por favor, verifique se o servidor remoto está escutando na porta 9999");
            }
            
        }
    }
}
