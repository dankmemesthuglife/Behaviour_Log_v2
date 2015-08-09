using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeptDets
{
    class YearHead
    {
        public string strYearHead = "";
        public string strYearEmail = "";

        public Pupil[] arrPupils = new Pupil[30];
        private int nCurrentCount = 0;

        public YearHead(Pupil p)
        {
            strYearEmail = p.GetHoYEmail();
            arrPupils[nCurrentCount++] = p;
        }

        public void AddPupil(Pupil p)
        {
            arrPupils[nCurrentCount++] = p;
        }

        public string GetPupilNames()
        {
            string strPupilNames = "";

            for( int i = 0; i < nCurrentCount; i++)
            {
                strPupilNames += arrPupils[i].GetName();
                strPupilNames += (i < nCurrentCount-1? ", ":".");
            }

            return strPupilNames;
        }

        public string GetS()
        {
            return (nCurrentCount == 1 ? "" : "s");
        }
    }
}
