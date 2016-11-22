using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.Xml
{
    partial class XmlParser
    {
        private void WriteToErrorLog(string _errorMessage)
        {
            ErrorLog = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss tt") + " - " + _errorMessage + Environment.NewLine + ErrorLog;
        }
    }
}
