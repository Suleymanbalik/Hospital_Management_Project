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
    public partial class Form_Patient_Info : Form
    {
        public Form_Patient_Info()
        {
            InitializeComponent();
        }
        SQL_baglanti lnkConnection = new SQL_baglanti();
        public string tc;
        private void Form_Patient_Info_Load(object sender, EventArgs e)
        {
            // 5- girişteki tc yi table_Patient_Info formundaki labele yazdırma
            lblTC.Text = tc;



            // 6- veri tabanından ad soyadı Table_Patient_Info sayfasındaki labele yazdırma

            SqlCommand komut = new SqlCommand("select PatientName,PatientSurname from Table_Patients where PatientTC=@p1", lnkConnection.baglanti());
            komut.Parameters.AddWithValue("@p1", lblTC.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lblFullName.Text = dr[0] + " " + dr[1];

            }
            lnkConnection.baglanti().Close();

            // 7- datagride randevu geçmişini ekleme

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Table_Appointments where PatientTC =" + tc, lnkConnection.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            // 8 - Branşları çekme

            SqlCommand komut2 = new SqlCommand("select BranchName from Table_Branches", lnkConnection.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                cmbBranch.Items.Add(dr2[0]);
            }
            lnkConnection.baglanti().Close();



        }

        private void cmbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 9- Seçtiğimiz branşa göre doktor seçeceğiz.

            cmbDoctor.Items.Clear();
            SqlCommand komut3 = new SqlCommand("select DoctorName,DoctorSurname from Table_Doctors where DoctorBranch =@p1", lnkConnection.baglanti());
            komut3.Parameters.AddWithValue("@p1", cmbBranch.Text);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                cmbDoctor.Items.Add(dr3[0] + " " + dr3[1]);
            }
            lnkConnection.baglanti().Close();




        }

        private void cmbDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 10 - aktif randevu görüntüleme

            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("select * from Table_Appointments where AppointmentBranch = '" + cmbBranch.Text + "'" + " and AppointmentDoctor='" + cmbDoctor.Text + "'and AppointmentSituation =0", lnkConnection.baglanti());
            da1.Fill(dt1);
            dataGridView2.DataSource = dt1;

        }

        private void lnkUpdateInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // 11 - Update info kısmına tıkladıgımda Form_Edit_Doctor formuna gidecek
            // ordaki bilgileri düzenleyceğiz

            Form_Update_Information fr = new Form_Update_Information();
            fr.tcPatient = lblTC.Text;
            fr.Show();


        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 37 -  Datagride bir tık yaptıgımızda id soldaki ver girişi kısmına gelsin
            
            int SlctdCell = dataGridView2.SelectedCells[0].RowIndex;
            txtID.Text = dataGridView2.Rows[SlctdCell].Cells[0].Value.ToString();
        }

        private void buttonMakeAnAppointment_Click(object sender, EventArgs e)
        {
            // 38 - Randevu Alma işlemi Update komutu gibi çalışacak

            SqlCommand komutgetappointment = new SqlCommand("Update Table_Appointments set AppointmentSituation =1,PatientTC=@p1,PatienceCompliments=@p2 where AppointmentID=@p3",lnkConnection.baglanti());  
            komutgetappointment.Parameters.AddWithValue("@p1", lblTC.Text);
            komutgetappointment.Parameters.AddWithValue("@p2", rchComplaint.Text);
            komutgetappointment.Parameters.AddWithValue("@p3", txtID.Text);
            komutgetappointment.ExecuteNonQuery();
            lnkConnection.baglanti().Close();
            MessageBox.Show("Appointment has been created!","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);


        }
    }
}
