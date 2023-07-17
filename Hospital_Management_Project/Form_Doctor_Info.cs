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
    public partial class Form_Doctor_Info : Form
    {
        public Form_Doctor_Info()
        {
            InitializeComponent();
        }
        SQL_baglanti lnkConnection = new SQL_baglanti();
        public string drtc;
        private void Form_Doctor_Info_Load(object sender, EventArgs e)
        {
            lblTC.Text = drtc; // 40 -  tc yi buraya taşımak ve yukarda public değişken tanımlamak

            // 41 - TC yi girdikten sonra forma sol üste doktor ismini yazdırma

            SqlCommand komutgetdrname = new SqlCommand("select DoctorName, DoctorSurname from Table_Doctors where DoctorTC =@p1", lnkConnection.baglanti());
            komutgetdrname.Parameters.AddWithValue("@p1", lblTC.Text);
            SqlDataReader dr1 = komutgetdrname.ExecuteReader();
            while (dr1.Read())
            {
                lblFullName.Text = dr1[0] + " " + dr1[1];
            }
            lnkConnection.baglanti().Close();

            // 42 -  bu doktora ait randevular getirme

            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("select * from Table_Appointments where AppointmentDoctor = '"+lblFullName.Text+"'",lnkConnection.baglanti());
            da1.Fill(dt1);
            dataGridView1.DataSource= dt1;
            lnkConnection.baglanti().Close();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
           // 43 - bu formdan form_doctor_edit_info formuna gitmek
            
            Form_Doctor_Edit_Info fr1 = new Form_Doctor_Edit_Info();
            fr1.TCNO = lblTC.Text; // 44 - bu formdaki tc yi form_doctor_edit_infoya taşımak
            fr1.Show();
        }

        private void buttonAnnouncements_Click(object sender, EventArgs e)
        {
            // 47 -  Bu formdaki duyurular formunu açmak
            Form_Announcements fr2 = new Form_Announcements();
            fr2.Show();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            // 48 - Bu formdaki çıkış formuna basıp çıkış almak
            Application.Exit();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int slctdcell = dataGridView1.SelectedCells[0].RowIndex;
            rchComplaint.Text = dataGridView1.Rows[slctdcell].Cells[7].Value.ToString();
        }
    }
}
