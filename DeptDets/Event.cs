using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DeptDets
{
    class Event
    {
        string strEventTime;
        string strEventCategory;
        string strEventDetail;

        public Event()
        {
            strEventTime = "";
            strEventCategory = "";
            strEventDetail = "";
        }

        public Event( string strC, string strD, string strT)
        {
            strEventCategory = strC;
            strEventDetail = strD;
            strEventTime = strT;
        }

        public string GetEventCategory() { return strEventCategory; }
        public string GetEventTime() { return strEventTime; }
        public string GetEventDetail() { return strEventDetail; }

        public void SetEventCategory(string strC) { strEventCategory = strC; }
        public void SetEventTime(string strE) { strEventTime = strE; }
        public void SetEventDetail( string strED) {  strEventDetail = strED; }


        public bool IsValid()
        {
            // all fields must be populated..

            if(( strEventTime.Length == 0) || ( strEventCategory.Length == 0) || (strEventDetail.Length == 0))
            {
                return false;
            }

            return true;

        }

        public void UpdateBehaviourLog(string strStaffEmail, Pupil p)
        {
            using (StreamWriter sW = new StreamWriter("event.csv", true))
            {
                // update behaviour log with.. 

                sW.WriteLine(strStaffEmail, DateTime.Now.ToString(), p.GetForm(), p.GetName(), GetEventTime(), GetEventCategory(), GetEventDetail());
            }

        }

    }
}
