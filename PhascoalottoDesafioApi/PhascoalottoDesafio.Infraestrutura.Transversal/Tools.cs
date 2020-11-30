using System;
using System.IO;

namespace PhascoalottoDesafio.Infraestrutura.Transversal
{
    public static class Tools
    {
        public static string GetLastInnerException(this Exception exception)
        {
            Exception exLast = exception;

            if (exLast.InnerException == null)
                return exLast.Message;

            while (exLast != null)
            {
                if (exLast.InnerException != null && exLast.InnerException.InnerException == null)
                {
                    return exLast.InnerException.Message;
                }
                else
                {
                    exLast = exLast.InnerException;
                }
            }

            return "Falha Ao pegar último exception";
        }

        public static void CreateDirectory(string directory)
        {
            string[] path = directory.Split('\\');
            string full = string.Empty;
            foreach (var folder in path)
            {
                if (!string.IsNullOrEmpty(full))
                    Directory.CreateDirectory(full + @"\" + folder);

                full += folder + @"\";
            }
        }
    }
}
