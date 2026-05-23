using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace NAMMMHDotNetInternshipTraining.WinFormsAppSample
{
    
    public partial class FrmBlog : Form
    {
        private readonly SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
        {
            DataSource = ".",
            InitialCatalog = "NAMMMHDotNetInternshipTraining",
            IntegratedSecurity = true,
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true


        };
        public FrmBlog()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            using IDbConnection db = new SqlConnection(builder.ConnectionString);
            {
                db.Open();
                dataGridView1.DataSource = db.Query<Blog>("select * from Tbl_Blogs");
            }

        }

        private void FrmBlog_Load(object sender, EventArgs e)
        {

            string qusery = "select * from Tbl_Blogs";
            using IDbConnection db = new SqlConnection(builder.ConnectionString);
            db.Open();
            dataGridView1.DataSource = db.Query<Blog>("select * from Tbl_Blogs").ToList();

        }
    }
}
