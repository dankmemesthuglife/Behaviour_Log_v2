using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeptDets
{
    class CommentGroup // Should be Comments and Targets
    {
        Comment[] arrComments = null; 
        int nCount = 0;

        // constructor

        public CommentGroup()
        {
            arrComments = new Comment[10];
            nCount = 0;
        }

        public CommentGroup( Comment[] arrCs, int nC)
        {
            arrComments = new Comment[10];
            nCount = nC;

            for( int i =0; i < nCount; i++)
            {
                arrComments[i] = arrCs[i];
            }

        }

        // accessor functions..

        public int GetCount() { return nCount; }
        public Comment[] GetComments() { return arrComments; }
        
        // access by index..

        public Comment GetTarget( int n)
        {
            if( n >= nCount)
            {
                return null;
            }

            return arrComments[n];
        }
        public string GetLabel(int n) 
        { 
            if( n >= nCount)
            {
                return "";
            }

            return arrComments[n].GetLabel();
        }
        public string GetPhrase( int n)
        {
            if( n >= nCount)
            {
                return "";
            }

            return arrComments[n].GetCurrentPhrase();
        }

        public string UpdatePhrase(int n, string strName,bool bIsMale)
        {
            if (n >= nCount)
            {
                return "";
            }

            return arrComments[n].UpdatePhrase( strName, bIsMale);
        }
        
        public int LoadTargets()
        {
            FileReader r = new FileReader("ReportCommentsAndTargets.csv");

            string[,] strFields = r.LoadFile(ref nCount);

            if( nCount == -1)
            {
                return -1;
            }

            for (int i = 0; i < nCount; i++)
            {
                Comment c = new Comment(strFields[i,0], strFields[i,1], strFields[i,2], strFields[i,3]);
                
                // add to the list..
                arrComments[i] = c;
            }

            return nCount;
        }
    }
}
