using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomacaoDesktop
{
    public static class Extensions
    {
        public static string getShortTimeFileName(this string appendedName)
        {
            var dateTimeFileName = appendedName + string.Format("_{0:hh-mm-ss_dd-MM-yyyy}", DateTime.Now);

            return dateTimeFileName;
        }
    }
}
