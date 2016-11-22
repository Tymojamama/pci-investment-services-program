using PensionConsultants.Data.Access;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ISP.Xml
{
    public partial class XmlParser
    {
        #region PublicModifiers

        public XmlParser.DataSet ResultSet;
        public PackageTypes PackageType;

        public string EventLog;
        public string ErrorLog;

        public decimal PercentComplete;

        public int CurrentFileIndex { get; private set; }

        public Guid UserId;

        public List<Utilities.ImportFileItem> FilesToImport;

        public Utilities.ImportFileItem CurrentFile { get; private set; }

        public DateTime ImportStartTime { get; private set; }
        public DateTime ImportEndTime { get; private set; }
        public DateTime CurrentFileStartTime { get; private set; }
        public DateTime CurrentFileEndTime { get; private set; }

        public bool ContinueProcess;
        public bool ProcessIsRunning { get; private set; }

        #endregion
        #region PrivateModifiers

        private FileStream fileStream;
        private XmlReader xmlReader;
        private static DataAccessComponent _accessStage = new DataAccessComponent(DataAccessComponent.Connections.PCIISP_PCI_ISP_ImportStage);

        private bool nodeIsElement() { return xmlReader.NodeType == XmlNodeType.Element; }
        private bool nodeIsEndElement() { return xmlReader.NodeType == XmlNodeType.EndElement; }

        #endregion

        /// <summary>
        /// Creates an object for parsing, staging, and insterting XML data into the production ISP Database.
        /// </summary>
        /// <param name="_userId"></param>
        public XmlParser(Guid _userId)
        {
            UserId = _userId;
            FilesToImport = new List<Utilities.ImportFileItem>();
            ContinueProcess = true;
            ProcessIsRunning = false;
            PercentComplete = 0.0m;
        }
    }
}
