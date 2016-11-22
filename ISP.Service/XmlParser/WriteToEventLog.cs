using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.Xml
{
    partial class XmlParser
    {
        private void WriteToEventLog(string _eventMessage, decimal _percentComplete)
        {
            EventLog = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss tt") + " - " + _eventMessage + Environment.NewLine + EventLog;
            PercentComplete = _percentComplete;
        }
    }
}
