using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement
{
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AddStudent_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm?", "Alert", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSName.Clear();
            txtSNo.Clear();
            txtSDepartment.Clear();
            txtSSem.Clear();
            txtSContact.Clear();
            txtSEmail.Clear();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtSName.Text != "" && txtSNo.Text != "" && txtSDepartment.Text != "" && txtSSem.Text != "" && txtSContact.Text != "" && txtSEmail.Text!="")
            {
                String name = txtSName.Text;
                String enroll = txtSNo.Text;
                String dep = txtSDepartment.Text;
                String sem = txtSSem.Text;
                Int64 mobile = Int64.Parse(txtSContact.Text);
                String email = txtSEmail.Text;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source=DESKTOP-IA1RTIE\\SQLEXPRESS; database=library;integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                con.Open();
                cmd.CommandText = "insert into NewStudent(sname,enroll,dep,sem,contact,email)values ('" + name + "','" + enroll + "','" + dep + "','" + sem + "'," + mobile + ",'" + email + "')";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data Save!", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("please fill empty field", "Suggest", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }



        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
