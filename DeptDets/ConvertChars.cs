using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeptDets
{
    class ConvertChars // RENAME THIS CLASS!!
    {
        public string ConvertLatinChars(string strOriginal)
        {
            string strValue = "";

            for (int i = 0; i < strOriginal.Length; i++)
            {
                int n = strOriginal[i];

                // huge hack that wont work!
                if (n == 65533)
                {
                    strValue += (char)227;
                }
                else
                {
                    strValue += (char)n;
                }
            }

            return strValue;
        }

        public string ConvertNameAndGender( string strName, bool bIsMale,string s)
        {
            string strHeShe = bIsMale? "He" : "She";
            string strHisHer = bIsMale? "His" : "Her";
            string strheshe = bIsMale? "he" : "she";
            string strhisher = bIsMale? "his" : "her";

            string strDest = "";

            string[] strWords = s.Split(' ');
            {
                for( int i=0; i < strWords.Length; i++)
                {
                    if(( strWords[i].CompareTo("name")==0) || ( strWords[i].CompareTo("name")==0))
                    {
                        strWords[i] = strName;
                    }
                    else if(( strWords[i].CompareTo("He")==0) || ( strWords[i].CompareTo("She")==0))
                    {
                        strWords[i] = strHeShe;
                    }
                    else if ((strWords[i].CompareTo("His") == 0) || (strWords[i].CompareTo("Her") == 0))
                    {
                        strWords[i] = strHisHer;
                    }
                    else if ((strWords[i].CompareTo("he") == 0) || (strWords[i].CompareTo("she") == 0))
                    {
                        strWords[i] = strheshe;
                    }
                    else if ((strWords[i].CompareTo("his") == 0) || (strWords[i].CompareTo("her") == 0))
                    {
                        strWords[i] = strhisher;
                    }

                    strDest += " "+strWords[i];
                }
            }

            return strDest;
        }

        public string NL()
        {
            return Environment.NewLine;
        }

        public string DoubleNL()
        {
            return Environment.NewLine + Environment.NewLine;
        }

    }
}
