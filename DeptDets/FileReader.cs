using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DeptDets
{
    class FileReader
    {
        string strFileName;

        public FileReader( string strFR)
        {
            strFileName = strFR;
        }

        private string ConvertLatinChars(string strOriginal)
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
/*            Encoding destE = Encoding.UTF8;
            Encoding srcE = Encoding.GetEncoding("ISO-8859-15");

            byte[] srcEBytes = srcE.GetBytes(strName);
            byte[] destBytes = Encoding.Convert(srcE, destE, srcEBytes);

            string msg = destE.GetString(destBytes);*/
        }
        
        public string[,] LoadFile( ref int nLength)
        {
            string[,] arrRows = new string[500,20]; // the maximum for any file?!

            try 
            {

                using (StreamReader sR = new StreamReader(strFileName))
                {
                    int i = 0;

                    // skip headings..

                    if (sR.Peek() > 0)
                    {
                        string strLine = sR.ReadLine();
                    }

                    // process each line..

                    while (sR.Peek() > 0)
                    {
                        string strLine = sR.ReadLine();

                        strLine = ConvertLatinChars(strLine);

                        string[] strFields = strLine.Split(',');

                        for (int j = 0; j < strFields.Length; j++)
                        {
                            arrRows[i, j] = strFields[j];
                        }

                        i++;
                    }

                    nLength = i;
                }
            }
            catch( Exception err)
            {
                nLength = -1;
                return null;
            }

            return arrRows;
            
        }

    }
}
