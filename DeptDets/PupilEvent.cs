using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeptDets
{
    class PupilEvent
    {
        string strClass;
        string strName;
        string strFirstName;
        string strHisHer;
        string strHeShe;
        string strEmailMessage;
        string strIncidentDate;

        public PupilEvent()
        {
            strClass = "";
            strName = "";
            strEmailMessage = "";

        }

        private string GetASCIIString(string strPupilName)
        {
            Encoding iso = Encoding.GetEncoding("ISO-8859-1");
            Encoding utf8 = Encoding.UTF8;
            byte[] utfBytes = utf8.GetBytes(strPupilName);
            byte[] isoBytes = Encoding.Convert(utf8, iso, utfBytes);
            string msg = iso.GetString(isoBytes);

            return msg;
        }

        public PupilEvent(string strC, string strG, string strFN, string strN, string strIDate)
        {
            strClass = strC;
            strName = strN;
            strFirstName = strFN;
            strEmailMessage = "";
            strIncidentDate = strIDate;
            
            if (strG == "F")
            {
                strHisHer = "her";
                strHeShe = "She";
            }
            else
            {
                strHisHer = "his";
                strHeShe = "He";
            }

        }

        public string GetName() { return GetASCIIString(strName); }
        public string GetFirstName() { return strFirstName; }
        public string GetClass() { return strClass; }
        public string GetHisHer() {return strHisHer;}
        public string GetHeShe() { return strHeShe; }
        public string GetIncidentDate() { return strIncidentDate; }



        public void SetEmailMessage(string strM) { strEmailMessage = strM; }
        public string GetEmailMessage() { return strEmailMessage; }


    }
   
}
