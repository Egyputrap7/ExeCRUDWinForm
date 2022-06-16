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
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection("data source=LAPTOP-GHEF0MBM\\EGY;database=exercise;User ID=sa;Password=egyputradbncr78");
        
        public Form1()
        {
            InitializeComponent();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetList();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            string  nama = txtNama.Text,
                    matkul = txtMatkul.Text,
                    nim = txtNIM.Text;
            double nilai = double.Parse(txtNilai.Text);
            con.Open();
            SqlCommand cmd = new SqlCommand("exec InsertNilai '" + id+ "','" + nama + "','" + nim + "','" + matkul + "','" + nilai + "'",con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("BErhasil Kawan ");
            GetList();
            
        }

        void GetList()
        {
            SqlCommand cmd = new SqlCommand("exec ListData", con);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
            this.Hide();
        }
    }
}
