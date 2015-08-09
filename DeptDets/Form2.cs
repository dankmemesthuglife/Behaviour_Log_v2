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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
            StreamReader reader = new StreamReader("SeniorSchoolPupils.csv");
            
            while( reader.Peek() > 0)
            {
                string strValue = reader.ReadLine();

                lstPupils.Items.Add(strValue);
            }

        }
    }
}
