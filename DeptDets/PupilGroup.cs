using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeptDets
{
    class PupilGroup
    {
        Pupil[] arrPupils = new Pupil[500]; // should be larger..
        string strFile = "Pupils.csv";
        int nCount = 0;

        public PupilGroup()
        {
            FileReader r = new FileReader(strFile);

            string[,] strPupilRows = r.LoadFile(ref nCount);

            for (int i = 0; i < nCount; i++) 
            {
                if( strPupilRows[i,0] == null) // end of contents..
                {
                    return;
                }

                Pupil p = new Pupil(strPupilRows[i, 0], strPupilRows[i, 1], strPupilRows[i, 2], strPupilRows[i, 3], strPupilRows[i, 4], strPupilRows[i, 5], strPupilRows[i, 6], strPupilRows[i, 7], strPupilRows[i, 8]);
                arrPupils[i] = p;
            }
         }

        public Pupil GetPupil(int nPos) { return arrPupils[nPos]; }
        public int GetCount() { return nCount; }

    }
}
