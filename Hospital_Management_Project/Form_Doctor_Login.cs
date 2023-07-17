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
    public partial class Form_Doctor_Login : Form
    {
        public Form_Doctor_Login()
        {
            InitializeComponent();
        }
        SQL_baglanti lnkConnection = new SQL_baglanti();
        private void buttonLogin_Click(object sender, EventArgs e)
        {
           
            // 39 - form_doctor_infoya giriş yapmak
            SqlCommand komutDoctorLogin = new SqlCommand("select * from Table_Doctors where DoctorTC =@p1 and DoctorPassword=@p2",lnkConnection.baglanti());
            komutDoctorLogin.Parameters.AddWithValue("@p1", mskTCNo.Text);
            komutDoctorLogin.Parameters.AddWithValue("@p2", txtPassword.Text);
            SqlDataReader dr1 = komutDoctorLogin.ExecuteReader();
            if (dr1.Read())
            {
                
                Form_Doctor_Info fr = new Form_Doctor_Info();
                fr.drtc = mskTCNo.Text;  // 40 - Tc yi login kısmından doctor_detay_infoya taşımak
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid TC Number or password");
            }
            lnkConnection.baglanti().Close();
        }
    }
}
