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
    public partial class Reports : Form
    {
        Pupil[] arrPupils = new Pupil[500];
        CommentGroup commentGrp = null;

        public Reports()
        {
            InitializeComponent();
        }

        //*************************************************************** Event Handlers**********************************************************

        private void btnClass5_Click(object sender, EventArgs e)
        {
            LoadPupils(5);
        }

        private void btnClass6_Click(object sender, EventArgs e)
        {
            LoadPupils(6);
        }

        private void btnClass7_Click(object sender, EventArgs e)
        {
            LoadPupils(7);
        }

        private void btnClass8_Click(object sender, EventArgs e)
        {
            LoadPupils(8);
        }

        private void btnClass9_Click(object sender, EventArgs e)
        {
            LoadPupils(9);
        }

        private void btnClassIB_Click(object sender, EventArgs e)
        {
            LoadPupils(1);
        }

        private void btnCT1_Click(object sender, EventArgs e)
        {
            UpdatePupilComment(0);
        }

        private void btnCT2_Click(object sender, EventArgs e)
        {
            UpdatePupilComment(1);
        }

        private void btnCT3_Click(object sender, EventArgs e)
        {
            UpdatePupilComment(2);
        }

        private void btnCT4_Click(object sender, EventArgs e)
        {
            UpdatePupilComment(3);
        }

        private void btnCT5_Click(object sender, EventArgs e)
        {
            UpdatePupilComment(4);
        }

        private void btnCT6_Click(object sender, EventArgs e)
        {
            UpdatePupilComment(5);
        }

        private void btnCT7_Click(object sender, EventArgs e)
        {
            UpdatePupilComment(6);
        }

        private void btnCT8_Click(object sender, EventArgs e)
        {
            UpdatePupilComment(7);
        }

        private void btnCT9_Click(object sender, EventArgs e)
        {
            UpdatePupilComment(8);
        }

        private void btnCT10_Click(object sender, EventArgs e)
        {
            UpdatePupilComment(9);
        }

        //*************************************************************** Event Handlers**********************************************************

        private void LoadPupilsFromFile()
        {
            int nCount = 0;
            FileReader r = new FileReader("Pupils.csv");
            string[,] strFields = r.LoadFile(ref nCount);
                    
            for( int i = 0; i < nCount; i++)
            {
                arrPupils[i] = new Pupil(strFields[i, 0], strFields[i, 1], strFields[i, 2], strFields[i, 3], strFields[i, 4], strFields[i, 5], strFields[i, 6], strFields[i, 7], strFields[i, 8]);
                lstPupils.Items.Add(strFields[i,0]);

                // also add comment target class..
                
                arrPupils[i].SetCommentGroup(commentGrp);
            }
        }

        private void LoadPupils(int nClass)
        {
            lstPupils.Items.Clear();

            // process each pupil in the array..

            for (int i = 0; i < 500; i++)
            {
                Pupil p = arrPupils[i];

                if (p == null)
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

        private void UpdateButton( int nPos, string strLabel)
        {
            switch( nPos)
            {
                case 0:
                    btnCT1.Text = strLabel;
                    break;
                case 1:
                    btnCT2.Text = strLabel;
                    break;
                case 2:
                    btnCT3.Text = strLabel;
                    break;
                case 3:
                    btnCT4.Text = strLabel;
                    break;
                case 4:
                    btnCT5.Text = strLabel;
                    break;
                case 5:
                    btnCT6.Text = strLabel;
                    break;
                case 6:
                    btnCT7.Text = strLabel;
                    break;
                case 7:
                    btnCT8.Text = strLabel;
                    break;
                case 8:
                    btnCT9.Text = strLabel;
                    break;
                case 9:
                    btnCT10.Text = strLabel;
                    break;
            }
        }

        private void Reports_Load(object sender, EventArgs e)
        {
            commentGrp = new CommentGroup();

            // load Comments and Targets from file and store in object array..

            int nCount = commentGrp.LoadTargets();

            for (int i = 0; i < commentGrp.GetCount(); i++)
            {
                UpdateButton(i, commentGrp.GetLabel(i));
            }
                    
            LoadPupilsFromFile(); // also sets initial CommandTarget
            LoadPupils(5); // start with Class 5 displayed.
        }

        private Pupil FindPupil(string strName)
        {
            // process each pupil in the array..

            for (int i = 0; i < 500; i++)
            {
                Pupil p = arrPupils[i];

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

        private void UpdatePupilComment(int nCommentNo)
        {
            // for each pupil update with the new comment..

            for (int i = 0; i < lstPupils.SelectedItems.Count; i++)
            {
                string strSelectedPupil = lstPupils.SelectedItems[i].ToString();

                Pupil p = FindPupil(strSelectedPupil);

                if (p != null)
                {
                  p.UpdatePupilComment( nCommentNo);
                }
            }

            // refresh the report comments in the list..

            lstReport.Items.Clear();

            // process each pupil in the array..

            for (int i = 0; i < 500; i++)
            {
                Pupil p = arrPupils[i];

                if (p != null)
                {
                    lstReport.Items.Add(p.GetFullComment());
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // open file Reports..

            using (StreamWriter sW = new StreamWriter("Reports.csv", false))
            {
                // process each pupil in the array..

                for (int i = 0; i < arrPupils.Count(); i++)
                {
                    Pupil p = arrPupils[i];

                    if (p != null)
                    {
                        sW.WriteLine(p.GetName() + "," + p.GetFullComment());
                    }
                }
            }
        }

        private void lstReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show(lstReport.SelectedItem.ToString());
        }

    }
}
