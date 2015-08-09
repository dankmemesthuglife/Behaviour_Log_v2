using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeptDets
{
    class Staff
    {
        string strFirstName;
        string strEmail;
        string strTitle;

        // constructor..
    
        public Staff( string strN, string strT, string strE)
        {
            strFirstName = strN;
            strTitle = strT;
            strEmail = strE;
        }

        // accessor functions..

        public string GetFirstName() { return strFirstName; }
        public string GetEmail() { return strEmail; }
        public string GetTitle() { return strTitle; }

    }
}
