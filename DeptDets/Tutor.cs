using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeptDets
{
    class Tutor
    {
        string strTutor = "";
        string strTutorEmail = "";
        string strYearEmail = "";
        Pupil[] arrPupils = new Pupil[30];
        int nCurrentCount = 0;

        public Tutor(Pupil p)
        {
            strTutor = p.GetTutor();
            strTutorEmail = p.GetTutorEmail();
            strYearEmail = p.GetHoYEmail();
            arrPupils[nCurrentCount++] = p;
        }

        public string GetTutor() { return strTutor; }
        public string GetTutorEmail() { return strTutorEmail; }
        public string GetYearEmail() { return strYearEmail; }
        public int GetCurrentCount() { return nCurrentCount; }

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

        public bool IsPural()
        {
            return (nCurrentCount > 1);
        }
    }
}
