using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.Xml
{
    public partial class XmlParser
    {
        public partial class Utilities
        {
            public class ImportFileItem
            {
                public string FileName;
                public string SafeName;

                public ImportFileItem(string fileName, string safeName)
                {
                    FileName = fileName;
                    SafeName = safeName;
                }
            }
        }
    }
}
