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
    public partial class Form_Secretary_Login : Form
    {
        public Form_Secretary_Login()
        {
            InitializeComponent();
        }
        SQL_baglanti lnkConnection = new SQL_baglanti();
        private void buttonLogin_Click(object sender, EventArgs e)
        {
           // 14 - Sekreter girişinin yapıldıgı yer
            
            SqlCommand komut= new SqlCommand("select * from Table_Secretaries where SecretaryTC=@p1 and SecretaryPassword=@p2",lnkConnection.baglanti());
            komut.Parameters.AddWithValue("@p1",mskTCNo.Text);
            komut.Parameters.AddWithValue("@p2", txtPassword.Text);
            SqlDataReader dr =komut .ExecuteReader();
            if (dr.Read())
            {
                Form_Secretary_Detail fr = new Form_Secretary_Detail();
                // 15 -  tc yi burdan secretary detail formuna taşıdık.
                fr.tcsecretary= mskTCNo.Text; 
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid TC Number or Password!");
            }
            lnkConnection.baglanti().Close();
        }
    }
}
