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
    public partial class Form_Update_Information : Form
    {
        public Form_Update_Information()
        {
            InitializeComponent();
        }
        public string tcPatient;
        SQL_baglanti lnkConnection = new SQL_baglanti();
        private void Form_Update_Information_Load(object sender, EventArgs e)
        {
            mskTCNo.Text = tcPatient;
            // 12 - Form_Update_Information formuna bilgileri databaseden çekeceğiz
            SqlCommand komut = new SqlCommand("select * from Table_Patients where PatientTC =@p1", lnkConnection.baglanti());
            komut.Parameters.AddWithValue("@p1", mskTCNo.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txtName.Text = dr[1].ToString();
                txtSurname.Text = dr[2].ToString();
                mskPhoneNumber.Text = dr[4].ToString();
                txtPassword.Text = dr[5].ToString();
                cmbGender.Text = dr[6].ToString();

            }
            lnkConnection.baglanti().Close();

        }

        private void buttonUpdateInformation_Click(object sender, EventArgs e)
        {
            // 13 - Form_Update_Information formundaki Update butonunun kodlarını yazacağız
            SqlCommand komut2 = new SqlCommand("update Table_Patients set PatientName=@p1,PatientSurname=@p2,PatientPhoneNumber=@p3,PatientPassword=@p4,PatientGender=@p5 where PatientTC=@p6", lnkConnection.baglanti());
            komut2.Parameters.AddWithValue("@p1", txtName.Text);
            komut2.Parameters.AddWithValue("@p2", txtSurname.Text);
            komut2.Parameters.AddWithValue("@p3", mskPhoneNumber.Text);
            komut2.Parameters.AddWithValue("@p4", txtPassword.Text);
            komut2.Parameters.AddWithValue("@p5", cmbGender.Text);
            komut2.Parameters.AddWithValue("@p6", mskTCNo.Text);
            komut2.ExecuteNonQuery();
            lnkConnection.baglanti().Close();
            MessageBox.Show("Information Updated!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

    }
}
