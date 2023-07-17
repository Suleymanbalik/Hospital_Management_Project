using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Management_Project
{
    public partial class Form_Main : Form
    {
        public Form_Main()
        {
            InitializeComponent();
        }

        // 1- önce formları loginlere yonlendirdik
        private void buttonPatientEnter_Click(object sender, EventArgs e)
        {
            Form_Patient_Login fr =new Form_Patient_Login();
            fr.Show();
            this.Hide();
        }

        private void buttonDoctorEnter_Click(object sender, EventArgs e)
        {
            Form_Doctor_Login fr = new Form_Doctor_Login();
            fr.Show();
            this.Hide();
        }

        private void buttonSecretaryEnter_Click(object sender, EventArgs e)
        {
            Form_Secretary_Login fr = new Form_Secretary_Login();
            fr.Show();
            this.Hide();
        }
    }
}
