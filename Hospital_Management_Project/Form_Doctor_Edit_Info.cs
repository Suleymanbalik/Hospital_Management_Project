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
    public partial class Form_Doctor_Edit_Info : Form
    {
        public Form_Doctor_Edit_Info()
        {
            InitializeComponent();
        }

        SQL_baglanti lnkConnection = new SQL_baglanti();
        public string TCNO;
        private void Form_Doctor_Edit_Info_Load(object sender, EventArgs e)
        {
            mskTCNo.Text = TCNO;  // 44 - Form_doctor_info formundan bu forma tc yi taşımak

            // 45  -  veri tababnından form_doctor_edit_info formna ver çekmek

            SqlCommand komut = new SqlCommand("select * from Table_Doctors where DoctorTC =@p1",lnkConnection.baglanti());
            komut.Parameters.AddWithValue("@p1", mskTCNo.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txtName.Text = dr[1].ToString();
                txtSurname.Text = dr[2].ToString();
                cmbBranch.Text = dr[3].ToString();
                txtPassword.Text = dr[5].ToString();
            }
            lnkConnection.baglanti().Close();

        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
           // 46 - Form_Doctor_Edit_Info formunda Update butonunu aktif etme kodları
            
            SqlCommand komutupdate = new SqlCommand("Update Table_Doctors set DoctorName=@p1,DoctorSurname=@p2,DoctorBranch=@p3,DoctorPassword=@p4 where DoctorTC=@p5", lnkConnection.baglanti());
            komutupdate.Parameters.AddWithValue("@p1", txtName.Text);
            komutupdate.Parameters.AddWithValue("@p2", txtSurname.Text);
            komutupdate.Parameters.AddWithValue("@p3", cmbBranch.Text);
            komutupdate.Parameters.AddWithValue("@p4", txtPassword.Text);
            komutupdate.Parameters.AddWithValue("@p5", mskTCNo.Text);
            komutupdate.ExecuteNonQuery();
            lnkConnection.baglanti().Close();
            MessageBox.Show("Information Updated!","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
        
    }
}
