using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeptDets
{
    class StaffGroup
    {
        Staff[] arrStaff = new Staff[300]; 
        string strFile = "StaffEmails.csv";
        int nStaffCount = 0;


        public StaffGroup()
        {
            FileReader r = new FileReader(strFile);

            string[,] strStaffRows = r.LoadFile(ref nStaffCount);

            for (int i = 0; i < nStaffCount; i++) // very dangerous! Need a global getMax function!
            {
                Staff s = new Staff(strStaffRows[i, 0],strStaffRows[i, 1],strStaffRows[i, 2]);
                arrStaff[i] = s;
            }
        }

        public string FindStaffFirstName( string strEmail)
        {
            if( strEmail.Length == 0)
            {
                return "";
            }

            for (int i = 0; i < nStaffCount; i++) // very dangerous! Need a global getMax function!
            {
                Staff s = arrStaff[i];
                if( s.GetEmail().CompareTo(strEmail) == 0)
                {
                    return s.GetFirstName();
                }
            }

            return "";
        }

        public string FindStaffEmail(string strFirstName)
        {
            if (strFirstName.Length == 0)
            {
                return "";
            }

            for (int i = 0; i < nStaffCount; i++) // very dangerous! Need a global getMax function!
            {
                Staff s = arrStaff[i];
                if (s.GetFirstName().CompareTo(strFirstName) == 0)
                {
                    return s.GetEmail();
                }
            }

            return "";
        }

        public string FindStaffFirstName(int nPos)
        {
            if( nPos >= nStaffCount)
            {
                return "";
            }

            return arrStaff[nPos].GetFirstName();

        }

        public string FindStaffTitle(int nPos)
        {
            if (nPos >= nStaffCount)
            {
                return "";
            }

            return arrStaff[nPos].GetTitle();
        }

        public int GetStaffCount() { return nStaffCount; }

    }
}
