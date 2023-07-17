using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Hospital_Management_Project
{
    public partial class Form_Patient_Login : Form
    {
        public Form_Patient_Login()
        {
            InitializeComponent();
        }

        SQL_baglanti lnkConnect = new SQL_baglanti();
        private void lnkSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //  2- Patient giriş ekranından linke basıp patient kayıt kısmına girdik
            
            Form_SingUp fr = new Form_SingUp();
            fr.Show();

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
           // 4 - tc ve şifre ile giriş kısmını yatık veritabanından eşleştirdk şifreyi
            
            SqlCommand komutPatientLogin = new SqlCommand("Select * from Table_Patients where PatientTC=@p1 and PatientPassword = @p2", lnkConnect.baglanti());
            komutPatientLogin.Parameters.AddWithValue("@p1", mskTCNo.Text);
            komutPatientLogin.Parameters.AddWithValue("@p2", txtPassword.Text);
            SqlDataReader dr = komutPatientLogin.ExecuteReader();
            if (dr.Read())
            {
                Form_Patient_Info fr = new Form_Patient_Info();
                fr.tc=mskTCNo.Text;
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Password or TC Number");
            }
            lnkConnect.baglanti().Close();
        }

        private void Form_Patient_Login_Load(object sender, EventArgs e)
        {

        }
    }
}
