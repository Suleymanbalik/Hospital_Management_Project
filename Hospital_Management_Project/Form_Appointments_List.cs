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
    public partial class Form_Appointments_List : Form
    {
        public Form_Appointments_List()
        {
            InitializeComponent();
        }
        SQL_baglanti lnkConnection = new SQL_baglanti();
        private void Form_Appointments_List_Load(object sender, EventArgs e)
        {
            // 35 - bu forma veri tababından veri çekme ( Gride)
            DataTable dt1  = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("select * from Table_Appointments",lnkConnection.baglanti());
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;
            lnkConnection.baglanti().Close();


        }

        
    }
}
