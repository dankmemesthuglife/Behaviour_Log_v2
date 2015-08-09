using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeptDets
{
    class Comment
    {
        public int nCount;
        string strLabel;
        string strCurrentPhrase;
        string strPhrase1;
        string strPhrase2;
        string strPhrase3;
        int nPhraseIndex;

        // constructors..

        public Comment(string strL, string strP1, string strP2, string strP3)
        {
            nCount = 0;
            strLabel = strL;
            strPhrase1 = strP1;
            strPhrase2 = strP2;
            strPhrase3 = strP3;
            nPhraseIndex = 0;
            strCurrentPhrase = "";
        }

        // accessor functions..

        public string GetPhrase1() { return strPhrase1; }
        public string GetPhrase2() { return strPhrase2; }
        public string GetPhrase3() { return strPhrase3; }
        public int GetCount() { return nCount; }

        public string GetCurrentPhrase() { return strCurrentPhrase; }

        public string GetLabel() { return strLabel; }
        
        public string UpdatePhrase( string strName, bool bIsMale)
        {
            ConvertChars c = new ConvertChars();

            switch (nPhraseIndex++)
            {
                case 0:
                    strCurrentPhrase = c.ConvertNameAndGender(strName, bIsMale, strPhrase1);
                    break;
                case 1:
                    strCurrentPhrase = c.ConvertNameAndGender(strName, bIsMale, strPhrase2);
                    break;
                case 2:
                    strCurrentPhrase = c.ConvertNameAndGender(strName, bIsMale, strPhrase3);
                    break;
                case 3:
                    return strCurrentPhrase;
                default:
                    return "";
            }

            return strCurrentPhrase;
        }
    }
}
