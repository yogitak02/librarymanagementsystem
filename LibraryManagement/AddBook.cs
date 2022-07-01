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
    public partial class AddBook : Form
    {
        public AddBook()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtBookName.Text != "" && txtBookAuthor.Text != "" && txtBookPublication.Text != "" && txtBookPrice.Text != "" && txtBookQuantity.Text != "")
            {


                String bName = txtBookName.Text;
                String bAuthor = txtBookAuthor.Text;
                String publication = txtBookPublication.Text;
                String pdate = dateTimePicker1.Text;
                Int64 price = Int64.Parse(txtBookPrice.Text);
                Int64 quan = Int64.Parse(txtBookQuantity.Text);

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source=DESKTOP-IA1RTIE\\SQLEXPRESS; database=library;integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                con.Open();
                cmd.CommandText = "insert into NewBook (bName,bAuthor,bPubl,bPDate,bPrice,bQuan) values('" + bName + "','" + bAuthor + "','" + publication + "','" + pdate + "'," + price + "," + quan + ")";
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Data saved", "sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBookName.Clear();
                txtBookAuthor.Clear();
                txtBookPublication.Clear();
                txtBookPrice.Clear();
                txtBookQuantity.Clear();
            }
            else
            {
                MessageBox.Show("Empty Field not  Allowed","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(" This will delete your unsaved data", "Are You Sure?", MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                    this.Close();
            }
        }
    }
}
