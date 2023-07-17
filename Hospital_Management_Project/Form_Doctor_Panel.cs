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
    public partial class Form_Doctor_Panel : Form
    {
        public Form_Doctor_Panel()
        {
            InitializeComponent();
        }
       SQL_baglanti lnkConnection = new SQL_baglanti(); 
        
        
        private void Form_Doctor_Panel_Load(object sender, EventArgs e)
        {
            // 23 -  Bu formdaki data gride veri tabanından veri çekme
            
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("select * from Table_Doctors", lnkConnection.baglanti());
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;
            lnkConnection.baglanti().Close();

            // 28 - Bu formdaki combo box a bilgi yükleme Table_doctors tan
            
            SqlCommand komut2 = new SqlCommand("select BranchName from Table_Branches", lnkConnection.baglanti());
            SqlDataReader dr1 = komut2.ExecuteReader();
            while (dr1.Read())
            {
                cmbBranch.Items.Add(dr1[0]);
            }

            

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            // 24 -  Bu fordaki Add ( Ekle) butonunu aktif etme
            SqlCommand komut1 = new SqlCommand("insert into Table_Doctors (DoctorName,DoctorSurname,DoctorBranch,DoctorTC,DoctorPassword) values (@p1,@p2,@p3,@p4,@p5)", lnkConnection.baglanti());
            komut1.Parameters.AddWithValue("@p1", txtName.Text);
            komut1.Parameters.AddWithValue("@p2", txtSurname.Text);
            komut1.Parameters.AddWithValue("@p3", cmbBranch.Text);
            komut1.Parameters.AddWithValue("@p4", mskTCNo.Text);
            komut1.Parameters.AddWithValue("@p5", txtPassword.Text);
            komut1.ExecuteNonQuery();
            lnkConnection.baglanti().Close();
            MessageBox.Show("Information has been saved!");


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            // 25 - datagriddten bir hucre seçildiğinde bilgilerin sola aktarılması
            int Slctdcell = dataGridView1.SelectedCells[0].RowIndex;
            // anlamı: datagrdiviewden seçilen hücrenin sıfırıncı satırındaki  göre indeksini alsın
            txtName.Text = dataGridView1.Rows[Slctdcell].Cells[1].Value.ToString();
            // anlamı: datagrid ten seçilen 1 satırın birince huhcresndeki degerini to string olarak txtName 
            // ksımına atsın
            txtSurname.Text = dataGridView1.Rows[Slctdcell].Cells[2].Value.ToString();
            mskTCNo.Text = dataGridView1.Rows[Slctdcell].Cells[4].Value.ToString();
            cmbBranch.Text = dataGridView1.Rows[Slctdcell].Cells[3].Value.ToString();
            txtPassword.Text = dataGridView1.Rows[Slctdcell].Cells[5].Value.ToString();

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            // 26 - Bur formdaki silme komutunu gerçekleştirme
            
            SqlCommand komutdelete = new SqlCommand("delete from Table_Doctors where DoctorTC=@p1", lnkConnection.baglanti());
            komutdelete.Parameters.AddWithValue("@p1",mskTCNo.Text);
            komutdelete.ExecuteNonQuery();
            lnkConnection.baglanti().Close();
            MessageBox.Show("Information has been deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            // 27 -  Bu Formdaki guncelleme işlemini gerçekleştirme
            
            SqlCommand komutUpdate = new SqlCommand("Update Table_Doctors set DoctorName=@p1,DoctorSurname=@p2,DoctorBranch=@p3,DoctorPassword=@p5 where DoctorTC=@p4", lnkConnection.baglanti());
            komutUpdate.Parameters.AddWithValue("@p1", txtName.Text);
            komutUpdate.Parameters.AddWithValue("@p2", txtSurname.Text);
            komutUpdate.Parameters.AddWithValue("@p3", cmbBranch.Text);
            komutUpdate.Parameters.AddWithValue("@p4", mskTCNo.Text);
            komutUpdate.Parameters.AddWithValue("@p5", txtPassword.Text);
            komutUpdate.ExecuteNonQuery();
            lnkConnection.baglanti().Close();
            MessageBox.Show("Information has been saved!");
        }

        
    }
}
