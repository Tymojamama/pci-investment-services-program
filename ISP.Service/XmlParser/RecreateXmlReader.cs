using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ISP.Xml
{
    partial class XmlParser
    {
        private void CreateXmlReader()
        {
            try
            {
                fileStream = new FileStream(CurrentFile.FileName, FileMode.Open);
            }
            catch
            {
                WriteToErrorLog("Cannot open file for FileStream.");
                return;
            }

            xmlReader = XmlReader.Create(fileStream, new XmlReaderSettings { DtdProcessing = DtdProcessing.Prohibit });
        }
    }
}
