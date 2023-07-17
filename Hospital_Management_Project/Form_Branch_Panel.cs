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
    public partial class Form_Branch_Panel : Form
    {
        public Form_Branch_Panel()
        {
            InitializeComponent();
        }
        SQL_baglanti lnkConnection = new SQL_baglanti();
        private void Form_Branch_Panel_Load(object sender, EventArgs e)
        {
            // 30 - doktor paneline veri tabanından gride doktor bilgilerini yükleme
            // bilgiler hemen gelmesi için form ksımına yazdık
            
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("select * from Table_Branches",lnkConnection.baglanti());
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;
            lnkConnection.baglanti().Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
           // 31 - bu formdaki ekle butonunu aktif etme kodları
            
            SqlCommand komutadd = new SqlCommand("insert into Table_Branches (BranchName) values (@p1)",lnkConnection.baglanti());
            komutadd.Parameters.AddWithValue("@p1", txtBranchName.Text);
            komutadd.ExecuteNonQuery();
            lnkConnection.baglanti().Close();
            MessageBox.Show("Information has been added!");
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            // 33 - bu frmdaki silme komutunu aktif etme kodları
            SqlCommand komutdelete = new SqlCommand("delete from Table_Branches where BranchID=@p1", lnkConnection.baglanti());
            komutdelete.Parameters.AddWithValue("@p1", txtBranchID.Text);
            komutdelete.ExecuteNonQuery();
            lnkConnection.baglanti().Close();
            MessageBox.Show("Information has been deleted!");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 32 -  gridteki verilere tek tık yaptıgımızda veriler soldaki ver girişi kısımlarına otomatik gelsin

            int SlctdCell = dataGridView1.SelectedCells[0].RowIndex;
            txtBranchID.Text= dataGridView1.Rows[SlctdCell].Cells[0].Value.ToString();
            txtBranchName.Text = dataGridView1.Rows[SlctdCell].Cells[1].Value.ToString();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
           // 33 - bu formdaki guncelleme işlemini yaptgımız kısım
            
            SqlCommand komutUpdate = new SqlCommand("update Table_Branches set BranchName=@p1 where BranchID=@p2",lnkConnection.baglanti());
            komutUpdate.Parameters.AddWithValue("@p1", txtBranchName.Text);
            komutUpdate.Parameters.AddWithValue("@p2",txtBranchID.Text);
            komutUpdate.ExecuteNonQuery();
            lnkConnection.baglanti().Close();
            MessageBox.Show("Information bas been updated","Information",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
