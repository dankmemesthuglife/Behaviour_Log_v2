using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DeptDets
{
    public partial class MessageTeacher : Form
    {
        string strMessage = "";
        string strSubject = "";
        string strStaffEmail = "";
        string strStaffPassword = "";
        string strStaffFirstName = "";
        StaffGroup staffGrp = new StaffGroup(); // massive hack, should be able to use the one from behaviour log class?!
        BehaviourLog bLog = null;

        public MessageTeacher( string strSE, string strP, string strSFN, string strS, string strM)
        {
            strStaffPassword = strP;
            strStaffEmail = strSE;
            strStaffFirstName = strSFN;
            strSubject = strS;
            strMessage = strM;
            InitializeComponent();
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            string strCCEmail = "";

            // get the teacher´s email address..

            string strSelectedTeacher = lstTeachers.SelectedItems[0].ToString();
            string strToEmail = staffGrp.FindStaffEmail(strSelectedTeacher);
            
            if( strToEmail.Length == 0)
            {
                MessageBox.Show("No email for the selected teacher");
                return;
            }

            // get the copied teacher if any ( up to one for now!)

            if (lstTeachers.SelectedItems.Count > 1)
            {
                strCCEmail = staffGrp.FindStaffEmail(lstTeachers.SelectedItems[1].ToString());
            }

            // send the email..

           Emailer eMail = new Emailer( strStaffEmail, strStaffPassword);

            if (strCCEmail == "")
            {
                eMail.SendMessage(strToEmail, "", strSubject, strMessage, false);
            }
            else
            {
                eMail.SendMessage(strToEmail,strCCEmail, strSubject, strMessage, true);
            }
        }

       

        private void MessageTeacher_Load(object sender, EventArgs e)
        {
            lblTitle.Text = "";
            ConvertChars c = new ConvertChars();

            // get the staff emails from the array..

            for (int i = 0; i < staffGrp.GetStaffCount(); i++)
            {
                // add the staff name..

                lstTeachers.Items.Add(staffGrp.FindStaffFirstName(i));

                // add the staff title..

                lblTitle.Text += staffGrp.FindStaffTitle(i) + c.NL();
            }

            
        }

    }
}
