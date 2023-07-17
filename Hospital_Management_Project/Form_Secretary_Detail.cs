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
    public partial class Form_Secretary_Detail : Form
    {
        public Form_Secretary_Detail()
        {
            InitializeComponent();
        }
        public string tcsecretary;
        SQL_baglanti lnkConnection = new SQL_baglanti();
        private void Form_Secretary_Detail_Load(object sender, EventArgs e)
        {
            // 15 -  Secretary login formundan buraya tc taşıdık.
            lblTC.Text = tcsecretary;
            // 16 - bu forma veri tabanından isim çekme
            SqlCommand komut1 = new SqlCommand("select SecretaryNameSurname from Table_Secretaries where SecretaryTC=@p1", lnkConnection.baglanti());
            komut1.Parameters.AddWithValue("@p1", lblTC.Text);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                lblFullName.Text = dr1[0].ToString();
            }
            lnkConnection.baglanti().Close();

            // 17 -  Branşları Data Gride aktarma 

            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("select * from Table_Branches", lnkConnection.baglanti());
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;
            lnkConnection.baglanti().Close();

            // 18 - Doktorları Listeye Aktarma

            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select (DoctorName + ' ' + DoctorSurname) as 'Doctors', DoctorBranch from Table_Doctors", lnkConnection.baglanti());
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;
            lnkConnection.baglanti().Close();

            // 19 - Bransları Kombo box a getirme
            // bransları otomatik combo box a getireceği için forma çift tıklayıp yazıyoruz kodları

            SqlCommand komutgetbranches = new SqlCommand("select BranchName from Table_Branches", lnkConnection.baglanti());
            SqlDataReader drgetbranches = komutgetbranches.ExecuteReader();
            while (drgetbranches.Read())
            {
                cmbBranch.Items.Add(drgetbranches[0]);
                ;
            }
            lnkConnection.baglanti().Close();
           

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            // 20 - Save Butonunu Aktif etme

            SqlCommand komutSave = new SqlCommand("insert into Table_Appointments (AppointmentDate,AppointmentTime,AppointmentBranch,AppointmentDoctor) values (@p1,@p2,@p3,@p4)", lnkConnection.baglanti());
            komutSave.Parameters.AddWithValue("@p1", mskDate.Text);
            komutSave.Parameters.AddWithValue("@p2", mskTime.Text);
            komutSave.Parameters.AddWithValue("@p3", cmbBranch.Text);
            komutSave.Parameters.AddWithValue("@p4", cmbDoctor.Text);
            komutSave.ExecuteNonQuery();
            lnkConnection.baglanti().Close();

            MessageBox.Show("Appointments has been created!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cmbDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cmbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 21 - Branşlara bastgımızda Doktorlar da alt kısımdaki kombo box a gelsin
            // branşa tıkladıgımızda doctor kombo box ına bilgi vermek istedğimiz için 
            // bu kodları branch combo box ına yazdık.

            cmbDoctor.Items.Clear();
            SqlCommand komutgetdoctor = new SqlCommand("select DoctorName, DoctorSurname from Table_Doctors where DoctorBranch =@p1", lnkConnection.baglanti());
            komutgetdoctor.Parameters.AddWithValue("@p1", cmbBranch.Text);
            SqlDataReader drgetdoctor = komutgetdoctor.ExecuteReader();
            while (drgetdoctor.Read())
            {
                cmbDoctor.Items.Add(drgetdoctor[0] + " " + drgetdoctor[1]);
            }
            lnkConnection.baglanti().Close();
        }

        private void buttonCreateAppointments_Click(object sender, EventArgs e)
        {
           // 22 -  duyuru geçme kısmını yaptık 
            
            SqlCommand komutannouncement = new SqlCommand("insert into Table_Announcements (Anouncements) values (@p1)", lnkConnection.baglanti());
            komutannouncement.Parameters.AddWithValue("@p1", rchAnnouncements.Text);
            komutannouncement.ExecuteNonQuery();
            lnkConnection.baglanti().Close();
            MessageBox.Show("Announcement Has Been Created!");
        }

        private void buttonDoctorPanel_Click(object sender, EventArgs e)
        {
           // 22 -  Doktor Panelini açma
            
            Form_Doctor_Panel fropenDpanel = new Form_Doctor_Panel();
            fropenDpanel.Show();
            this.Hide();
        }

        private void buttonBranchesPanel_Click(object sender, EventArgs e)
        {
            // 29 - doktor paneli formunu açacak kısım
            Form_Branch_Panel fr = new Form_Branch_Panel();
            fr.Show();
            this.Hide();
        }

        private void buttonAppointmentList_Click(object sender, EventArgs e)
        {
            // 34 - Randevu listesine gitme kısmı

            Form_Appointments_List fr = new Form_Appointments_List();
            fr.Show();
        }

        private void buttonAnnouncements_Click(object sender, EventArgs e)
        {
            // 35  - duyurular formuna gitme kısmı
            Form_Announcements fr = new Form_Announcements();
            fr.Show();
        }

        
    }
}
