using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeptDets
{
    public partial class Form1 : Form
    {
        // LIST of pupils..

        PupilEvent[] PupilEvents = new PupilEvent[20];
        int nPupilCount;
        
 

        private string GetFileName( PupilEvent tmpP)
        {
            return tmpP.GetName() + ".doc";
        }

        public Form1()
        {
            InitializeComponent();
        }

      

      

        private string NL() { return Environment.NewLine;}

        private string DoubleNL() { return Environment.NewLine + Environment.NewLine;}

        

        private string GetEmailAttachmentMessage(string strPupilFirstName, string strPupilName, string strHisHer, string strHeShe, string strClass)
        {
            string strMessage = "Dear Tatiana," + DoubleNL() + "Could you send the attached letter to the parents of ";
            strMessage += strPupilName + ".";
            strMessage += DoubleNL();
            strMessage += DoubleNL() + "Many Thanks, " + DoubleNL() + "Kamini Mahendran";
            return strMessage;
        }

       

        private void btnAgenda_Click(object sender, EventArgs e)
        {

        }
    }
}
