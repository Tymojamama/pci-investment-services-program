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
    partial class XmlParser
    {
        public void Process()
        {
            ProcessIsRunning = true;

            CurrentFileIndex = 0;

            if (FilesToImport.Count <= 0)
                throw new Exception("There are not any files in FilesToImport List.");

            CurrentFile = FilesToImport[CurrentFileIndex];

            ImportStartTime = DateTime.Now;

            CreateXmlReader();

            BackgroundWorker backgroundWorker = new BackgroundWorker();

            backgroundWorker.DoWork += new DoWorkEventHandler(
            delegate(object o, DoWorkEventArgs args)
            {
                BackgroundWorker b = o as BackgroundWorker;

                CurrentFileStartTime = DateTime.Now;

                try
                {
                    WriteToEventLog("Import process initiated.", 0.0m);

                    this.TransformPackage();

                    fileStream.Close();
                    xmlReader.Close();

                    this.SendPackageToServer();
                }
                catch (Exception ex)
                {
                    WriteToErrorLog(ex.Message);
                }
            });

            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(
            delegate(object o, RunWorkerCompletedEventArgs args)
            {
                CurrentFileEndTime = DateTime.Now;
                TimeSpan _timeSpan = CurrentFileEndTime - CurrentFileStartTime;

                if (ContinueProcess)
                {
                    string _eventLogEntry = "Import process completed (" + _timeSpan.Minutes.ToString() + "min " + _timeSpan.Seconds.ToString() + "sec).";
                    WriteToEventLog(_eventLogEntry, 1.00m);

                    CurrentFileIndex++;

                    if (CurrentFileIndex <= FilesToImport.Count - 1)
                    {
                        CurrentFile = FilesToImport[CurrentFileIndex];
                        CreateXmlReader();

                        EventLog = "-----------------------------------------------------------------------------------------------------------" + Environment.NewLine + EventLog;

                        ProcessIsRunning = true;
                        backgroundWorker.RunWorkerAsync();
                        return;
                    }

                    FilesToImport.Clear();

                    ImportEndTime = DateTime.Now;
                    ProcessIsRunning = false;
                }
                else if (!ContinueProcess)
                {
                    string _eventLogEntry = "Import process canceled (" + _timeSpan.Minutes.ToString() + "min " + _timeSpan.Seconds.ToString() + "sec).";
                    WriteToEventLog(_eventLogEntry, 1.00m);

                    FilesToImport.Clear();
                    CurrentFile = null;

                    ImportEndTime = DateTime.Now;

                    fileStream.Close();
                    xmlReader.Close();

                    ProcessIsRunning = false;
                }
            });

            backgroundWorker.RunWorkerAsync();
        }
    }
}
