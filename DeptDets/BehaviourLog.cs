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
    public partial class BehaviourLog : Form
    {
        StaffGroup staffGrp = new StaffGroup();
        Tutor[] arrTutors = new Tutor[5];
        YearHead[] arrYearHeads = new YearHead[4];
        PupilGroup pupilGrp = new PupilGroup();
        EventGroup eventGrp = new EventGroup();
        EventGroup PresetEvents =  new EventGroup();

        Event currentEvent = null;
        Emailer eMail = null;
        bool bUpdateBLog = false;

        string strStaffEmail = "";
        string strStaffPassword = "";
        string strStaffFirstName = "";

        public BehaviourLog(string strEmail, string strPassword)
        {
            // store staff login details..

            strStaffEmail = strEmail;
            strStaffPassword = strPassword;
            

            InitializeComponent();
        }

        private void btnPeriod1_Click(object sender, EventArgs e)
        {
            SetEventTime("Period 1");
            ToggleButton(btnPeriod1);
        }

        private void btnPeriod2_Click(object sender, EventArgs e)
        {
            SetEventTime("Period 2");
            ToggleButton(btnPeriod2);
        }

        private void btnPeriod3_Click(object sender, EventArgs e)
        {
            SetEventTime("Period 3");
            ToggleButton(btnPeriod3);
        }

        private void btnPeriod4_Click(object sender, EventArgs e)
        {
            SetEventTime("Period 4");
            ToggleButton(btnPeriod4);
        }

        private void btnPeriod5_Click(object sender, EventArgs e)
        {
            SetEventTime("Period 5");
            ToggleButton(btnPeriod5);
        }

        private void btnPeriod6_Click(object sender, EventArgs e)
        {
            SetEventTime("Period 6");
            ToggleButton(btnPeriod6);
        }

        private void btnPeriod7_Click(object sender, EventArgs e)
        {
            SetEventTime("Period 7");
            ToggleButton(btnPeriod7);
        }

        private void btnCat1_Click(object sender, EventArgs e)
        {
            Event ev = PresetEvents.GetEvent(0);
            if (ev != null)
            {
                SetEventDetails(ev.GetEventCategory(), ev.GetEventDetail());
            }
            ToggleButton(btnCat1);
        }

        private void btnCat2_Click(object sender, EventArgs e)
        {
            Event ev = PresetEvents.GetEvent(1);
            
            if( ev != null)
            {
                SetEventDetails(ev.GetEventCategory(), ev.GetEventDetail());
            }

            ToggleButton(btnCat2);
        }

        private void btnCat3_Click(object sender, EventArgs e)
        {
            Event ev = PresetEvents.GetEvent(2);
            if (ev != null)
            {
                SetEventDetails(ev.GetEventCategory(), ev.GetEventDetail());
            }

            ToggleButton(btnCat3);
        }

        private void btnCat4_Click(object sender, EventArgs e)
        {
            Event ev = PresetEvents.GetEvent(3);

            if (ev != null)
            {
                SetEventDetails(ev.GetEventCategory(), ev.GetEventDetail());
            }

            ToggleButton(btnCat4);
        }

        private void btnCat5_Click(object sender, EventArgs e)
        {
            Event ev = PresetEvents.GetEvent(4);

            if (ev != null)
            {
                SetEventDetails(ev.GetEventCategory(), ev.GetEventDetail());
            }

            ToggleButton(btnCat5);
        }

        private void btnCat6_Click(object sender, EventArgs e)
        {
            Event ev = PresetEvents.GetEvent(5);

            if (ev != null)
            {
                SetEventDetails(ev.GetEventCategory(), ev.GetEventDetail());
            }

            ToggleButton(btnCat6);
        }

        private void btnClass5_Click(object sender, EventArgs e)
        {
            LoadPupils(5);
            ToggleButton(btnClass5);
        }

        private void btnClass6_Click(object sender, EventArgs e)
        {
            LoadPupils(6);
            ToggleButton(btnClass6);
        }

        private void btnClass7_Click(object sender, EventArgs e)
        {
            LoadPupils(7);
            ToggleButton(btnClass7);
        }

        private void btnClass8_Click(object sender, EventArgs e)
        {
            LoadPupils(8);
            ToggleButton(btnClass8);
        }

        private void btnClass9_Click(object sender, EventArgs e)
        {
            LoadPupils(9);
            ToggleButton(btnClass9);
        }

        private void btnClassIB_Click(object sender, EventArgs e)
        {
            LoadPupils(1);
            ToggleButton(btnClassIB);

        }

        private void cBehaviourLog_CheckedChanged(object sender, EventArgs e)
        {
            bUpdateBLog = !bUpdateBLog;
        }
      
        private void ToggleButton(Button b)
        {
            if (b.BackColor == System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255))))))
            {
                b.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
                return;
            }

            b.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
        }

        private void BehaviourLog_Load(object sender, EventArgs e)
        {
            strStaffFirstName = staffGrp.FindStaffFirstName(strStaffEmail);

            if( strStaffFirstName.Length == 0)
            {
                MessageBox.Show("Staff email not found, please try again"); // change login code
                return;
            }

            PresetEvents.LoadPresetEvents();

            // then update the buttons for each event category..

            UpdateEventButtons();

            // read from file..

            LoadPupils();

            // initialise with Class 5..

            LoadPupils(5);
        }

        private void LoadPupils()
        {
            for (int i = 0; i < pupilGrp.GetCount(); i++ )
            {
                Pupil p = pupilGrp.GetPupil(i);
                lstPupils.Items.Add(p.GetName());
            }
        }

        private void LoadPupils(int nClass)
        {
            lstPupils.Items.Clear();

            // process each pupil in the array..
                
            for( int i = 0; i < 500; i++)
            {
                Pupil p = pupilGrp.GetPupil(i);

                if(( p == null ) || (p.GetYear() == null))
                {
                    break;
                }
                string strClass = nClass.ToString();

                if (p.GetYear().CompareTo(strClass) == 0)
                {
                    lstPupils.Items.Add(p.GetName());
                }
            }

        }

        private bool UpdateEventButton( Button b, int nPos)
        {
            if( b == null)
            {
                return false;
            }

            Event e = PresetEvents.GetEvent(nPos);
                
            if( e == null)
            {
                return false;
            }

            b.Text = e.GetEventCategory();
            return true;
        }

        private void UpdateEventButtons()
        {
            // Load 6 present event buttons..

            UpdateEventButton(btnCat1, 0);
            UpdateEventButton(btnCat2, 1);
            UpdateEventButton(btnCat3, 2);
            UpdateEventButton(btnCat4, 3);
            UpdateEventButton(btnCat5, 4);
            UpdateEventButton(btnCat6, 5);
        }

        private void SetEventTime(string strED)
        {
            if (currentEvent == null)
            {
                currentEvent = new Event();
            }

            currentEvent.SetEventTime(strED);
        }

        private void btnBeforeSchool_Click(object sender, EventArgs e)
        {
            SetEventTime("Before School");
            ToggleButton(btnBeforeSchool);
        }

        private void btnBreak_Click(object sender, EventArgs e)
        {
            SetEventTime("Break");
            ToggleButton(btnBreak);
        }

        private void btnLunch_Click(object sender, EventArgs e)
        {
            SetEventTime("Lunch Time");
            ToggleButton(btnLunch);
        }

        private void btnAfterSchool_Click(object sender, EventArgs e)
        {
            SetEventTime("After School");
            ToggleButton(btnAfterSchool);
        }

        private void SetEventDetails( string strC, string strD)
        {
            if (currentEvent == null)
            {
                currentEvent = new Event();
            }

            currentEvent.SetEventCategory(strC);
            currentEvent.SetEventDetail(strD); 

        }

        private Pupil FindPupil(string strName)
        {
            // process each pupil in the array..

            for (int i = 0; i < 500; i++)
            {
                Pupil p = pupilGrp.GetPupil(i);

                if (p == null)
                {
                    break;
                }
                if (p.GetName().CompareTo(strName) == 0)
                {
                    return p;
                }
            }

            return null;

        }

        private int LoadTutors()
        {
            int nTutorCount = 0;

            for (int i = 0; i < lstPupils.SelectedItems.Count; i++)
            {
                string strSelectedPupil = lstPupils.SelectedItems[i].ToString();

                Pupil p = FindPupil(strSelectedPupil);

                if (p != null)
                {
                    // add to existing tutor..

                    bool bTutorFound = false;

                    for (int j = 0; j < nTutorCount; j++)
                    {
                        string strTutorName = arrTutors[j].GetTutor();

                        if (strTutorName.CompareTo(p.GetTutor()) == 0)
                        {
                            arrTutors[j].AddPupil(p);
                            bTutorFound = true;
                        }
                    }

                    // add a new tutor..

                    if (!bTutorFound)
                    {
                        arrTutors[nTutorCount++] = new Tutor(p);
                    }
                }
            }

            return nTutorCount;
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            // organise pupils by tutor..

            int nTutorCount = LoadTutors();

            // SEND Emails for each set of pupils grouped by tutor..

            SendEmails( nTutorCount, true, true);

        }

        public void SendEmails( int nTutorCount, bool bStandardMessage, bool bCC)
        {
            // must have chosen options for a standard message..

            if (bStandardMessage && currentEvent.IsValid() == false) 
            {
                MessageBox.Show("Please select all options");
                return;
            }

            ConvertChars c = new ConvertChars();
            string strSubject = "";

            // organise by tutor..

            for (int i = 0; i < nTutorCount; i++)
            {
                Tutor t = arrTutors[i];

                string strPupilNames = t.GetPupilNames();

                // start message..

                string strMessage = "Dear " + t.GetTutor() + ",";

                if (bStandardMessage == true)
                {
                    // create message..
                    strMessage += c.DoubleNL() + "Just to let you know that the following pupil" + t.GetS() + " ";
                    strMessage += (t.IsPural() ? currentEvent.GetEventDetail() : currentEvent.GetEventDetail()); // check
                    strMessage += " " + currentEvent.GetEventTime() + " today: ";
                    strMessage += strPupilNames + c.NL();
                    strMessage += "I will add this to the behaviour log." + c.DoubleNL();
                    strSubject = currentEvent.GetEventCategory();
                }
                else
                {
                    strMessage += c.DoubleNL();
                    strMessage += txtMessage.Text + c.DoubleNL();

                    strSubject = strPupilNames; // set category to pupil name..
                }

                strMessage += "Kind Regards, " + c.NL() + strStaffFirstName;

                
                bCC = true;

                // send each message..
                if( eMail == null)
                {
                    eMail = new Emailer(strStaffEmail,strStaffPassword);
                }

                eMail.SendMessage(t.GetTutorEmail(), t.GetYearEmail(), strSubject, strMessage, bCC);

                // update the behaviour log file..

                //  currentEvent.UpdateBehaviourLog(strStaffEmail, p); // only for preset.
            }
        }

        private void btnMessageTutor_Click(object sender, EventArgs e)
        {
            // organise pupils by tutor..

            int nTutorCount = LoadTutors();

            // SEND Emails..

            SendEmails(nTutorCount, false, false);
        }

        private void btnMessageYearHead_Click(object sender, EventArgs e)
        {
         /*   // get the year heads..

            string strMessage = "Dear " + "strYearHead" + "," + DoubleNL();

            // send message.. 

            eMail.SendMessage("Year Head email", "", "Pupil for subject", "message", false);*/
        }

        private void btnMessageTeacher_Click(object sender, EventArgs e)
        {
            string strPupils = "";
            int nCount = lstPupils.SelectedItems.Count;
            
            for (int i = 0; i < nCount; i++)
            {
                strPupils += lstPupils.SelectedItems[i].ToString();
                strPupils += (i < nCount - 1 ? ", " : ".");
            }

            MessageTeacher mT = new MessageTeacher(strStaffEmail, strStaffPassword, strStaffFirstName, strPupils, txtMessage.Text); // set pupil names as subject
            mT.Show();
        }

        private void btnParents_Click(object sender, EventArgs e)
        {
            Emailer eM = new Emailer( strStaffEmail,strStaffPassword);

            // update spreadsheet for mail merge..

            // for each pupil..
            
            for (int i = 0; i < lstPupils.SelectedItems.Count; i++)
            {
                string strSelectedPupil = lstPupils.SelectedItems[i].ToString();

                Pupil p = FindPupil(strSelectedPupil);

                if (p != null)
                {
                    // 1. create email message.. ( store in array earlier?)

                    // 2. send email..
              
                    eM.SendMessage(p.GetParentEmail(),"","The BritishSchool of Rio de Janeiro: " + p.GetName(),txtMessage.Text,false);
                    
                    if (bUpdateBLog)
                    {
                        Event Ev = new Event( txtMessage.Text,"CAT","TIME");
                        Ev.UpdateBehaviourLog(strStaffEmail, p);
                    }
                }
            }
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            Reports r = new Reports();
            r.Show();
        }

        
        

    }
}
