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
    public partial class Form_SingUp : Form
    {
        public Form_SingUp()
        {
            InitializeComponent();
        }
        SQL_baglanti lnkconnect = new SQL_baglanti();
        private void buttonSave_Click(object sender, EventArgs e)
        {
            // 3- Patient Kayıt kısmını burda veri tabanı ile eşleştirdik ve kayıt işlemleri
            // gerçekleştirdik
            
            SqlCommand komutSingUp = new SqlCommand("insert into Table_Patients (PatientName,PatientSurname,PatientTC,PatientPhoneNumber,PatientPassword,PatientGender) values (@p1,@p2,@p3,@p4,@p5,@p6)",lnkconnect.baglanti());
            komutSingUp.Parameters.AddWithValue("@p1",txtName.Text);
            komutSingUp.Parameters.AddWithValue("@p2",txtSurname.Text);
            komutSingUp.Parameters.AddWithValue("@p3", mskTCNo.Text);
            komutSingUp.Parameters.AddWithValue("@p4", mskPhoneNumber.Text);
            komutSingUp.Parameters.AddWithValue("@p5",txtPassword.Text);
            komutSingUp.Parameters.AddWithValue("@p6", cmbGender.Text);
            komutSingUp.ExecuteNonQuery();
            lnkconnect.baglanti().Close();
            MessageBox.Show("Your registration has been completed! Your Password :" + txtPassword.Text ,"Information",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
