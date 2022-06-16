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

namespace ExeCRUDWinForm
{
    public partial class Form2 : Form
    {

        SqlConnection con = new SqlConnection("data source=LAPTOP-GHEF0MBM\\EGY;database=exercise;User ID=sa;Password=egyputradbncr78");
        public Form2()
        {
            InitializeComponent();
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            GetList();
        }

        void GetList()
        {
            SqlCommand cmd = new SqlCommand("exec ListData", con);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            string nama = txtNama.Text,
                    matkul = txtMatkul.Text,
                    nim = txtNIM.Text;
            double nilai = double.Parse(TxtNilai.Text);
            con.Open();
            SqlCommand cmd = new SqlCommand("exec UpdateData '" + id + "','" + nama + "','" + nim + "','" + matkul + "','" + nilai + "'", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("BErhasil Kawan ");
            GetList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            con.Open();
            SqlCommand cmd = new SqlCommand("exec DeleteNilai '" + id + "'", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("BErhasil Kawan ");
            GetList();
        }
    }
}
