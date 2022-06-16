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
    public partial class Form3 : Form
    {
        SqlConnection con = new SqlConnection("data source=LAPTOP-GHEF0MBM\\EGY;database=exercise;User ID=sa;Password=egyputradbncr78");

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            GetList();
        }
        void GetList()
        {
            SqlCommand cmd = new SqlCommand("exec ListData", con);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);

        }
    }
}
