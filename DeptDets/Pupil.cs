using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeptDets
{
    class Pupil
    {
        string strFirstName; // generated programatically
        string strName;
        string strForm;
        string strTutor;
        string strTutorEmail;
        string strYearHead;
        string strYearEmail;
        string strParentEmail;
        string nYear;
        bool bIsMale;
        CommentGroup CommentGrp;

        // Year	- Form - Name - Gender - Form Tutor	 - Year Head  - Form Email  - Year Head Email - ParentEmail

        public Pupil(string nY, string strF, string strN, string strGender, string strFT,string strYH, string strFE, string strYE, string ParentE )
        {
            nYear = nY;
            strForm = strF;
            strName = strN;
            strTutor = strFT;
            strTutorEmail = strFE;
            strYearHead = strYH;
            strYearEmail = strYE;
            strParentEmail = ParentE;

            bIsMale = ( strGender.CompareTo("M")== 0? true:false);

            // generate first name..

            strFirstName = GetFirstName(strName);
        }

        public string GetName(){return strName;}
        public string GetForm(){ return strForm;}
        public string GetTutor(){ return strTutor;}
        public string GetTutorEmail() { return strTutorEmail; }
        public string GetYearHead(){return strYearHead;}
        public string GetHoYEmail(){return strYearEmail;}
        public string GetParentEmail(){return strParentEmail;}
        public string GetYear(){return nYear;}

        // generate first name..

        private string GetFirstName(string n)
        {
            string strFN = "";

            string[] strDoubleFN = { "Ana", "Anna", "Joao", "Maria", "Jose" };

            string[] strNames = n.Split(' ');

            if (strNames.Length == 0)
            {
                return "";
            }

            // get the first name..

            strFN = strNames[0];

            // check if it should be two names

            for (int i = 0; i < strDoubleFN.Length; i++)
            {
                if (strFN.CompareTo(strDoubleFN[i]) == 0)
                {
                    strFN += strNames[1];
                    break;
                }
            }

            return strFN;
        }

        public void SetCommentGroup( CommentGroup c)
        {
            Comment[] arrCommentSource = c.GetComments();
            int nCount = c.GetCount();

            Comment[] arrCommentDest = new Comment[nCount];

            for( int i=0; i< nCount; i++)
            {
                arrCommentDest[i] = new Comment(arrCommentSource[i].GetLabel(), arrCommentSource[i].GetPhrase1(), arrCommentSource[i].GetPhrase2(), arrCommentSource[i].GetPhrase3());
            }

            CommentGrp = new CommentGroup( arrCommentDest,nCount);
        }

        public string GetFullComment()
        {
            string strComment = "";

            for (int i = 0; i < 10; i++ )
            {
                strComment += CommentGrp.GetPhrase(i);
            }

            return strComment;
        }

        public void UpdatePupilComment( int nCommentNo)
        {
            if( CommentGrp == null)
            {
                return;
            }

            CommentGrp.UpdatePhrase(nCommentNo, strFirstName, bIsMale );
        }
    }
}
