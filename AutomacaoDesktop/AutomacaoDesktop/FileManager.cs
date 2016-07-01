using System;
using System.IO;

namespace AutomacaoDesktop
{
    public static class FileManager
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static string ReadFile(string pathToFile)
        {
            log.Info("Lendo o arquivo de entrada: " + pathToFile);
            var fileContent = "";
            try
            {
                using (StreamReader sr = new StreamReader(pathToFile))
                {
                    fileContent = sr.ReadToEnd();
                }
            } 
            catch(IOException ex)
            {
                fileContent = null;
                log.Error("Erro ao abrir arquivo " + pathToFile + "\n\n" + ex.Message);
            }

            return fileContent;
        }

        public static void DeleteFile(string pathToFile)
        {
            try
            {
               File.Delete(pathToFile);
            }
            catch (DirectoryNotFoundException dirNotFound)
            {
                log.Error("Erro ao tentar deletar arquivo " + pathToFile + "\n\n" + dirNotFound.Message);
            }
        }
    }
}
