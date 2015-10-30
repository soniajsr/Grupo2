using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Sismuni.Presentacion.Web.Helpers.Log
{
    public class LogError
    {
        private string sLogFormat;
        private string sErrorTime;

        public LogError()
        {
            //sLogFormat used to create log files format :
            // dd/mm/yyyy hh:mm:ss AM/PM ==> Log Message
            sLogFormat = DateTime.Now.ToShortDateString().ToString()+" "+DateTime.Now.ToLongTimeString().ToString()+" ==> ";
            
            //this variable used to create log filename format "
            //for example filename : ErrorLogYYYYMMDD
            string sYear    = DateTime.Now.Year.ToString();
            string sMonth    = DateTime.Now.Month.ToString();
            string sDay    = DateTime.Now.Day.ToString();
            sErrorTime = sYear+sMonth+sDay;
        }

        public void AgregarError(string sPathName, string sErrMsg,string spaso, string serror)
        {
            StreamWriter sw = new StreamWriter(sPathName, true);
            sw.WriteLine(sLogFormat + sErrMsg + " ==>" + spaso + " ==>" + serror);
            sw.Flush();
            sw.Close();
        }
    }
}