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
    public partial class Form_Announcements : Form
    {
        public Form_Announcements()
        {
            InitializeComponent();
        }
        SQL_baglanti lnkConnection = new SQL_baglanti();
        private void Form_Announcements_Load(object sender, EventArgs e)
        {
            // 36 - bu forma veri tabanından gride veri çekme
            
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("select * from Table_Announcements",lnkConnection.baglanti());
            da1.Fill(dt1);
            dataGridView1.DataSource= dt1;
            lnkConnection.baglanti().Close();
        }
    }
}
