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
    public partial class Issuebook : Form
    {
        public Issuebook()
        {
            InitializeComponent();
        }

        int count;

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtEnrollNo.Text !="")
            {
                String eid = txtEnrollNo.Text;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source=DESKTOP-IA1RTIE\\SQLEXPRESS; database = library; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from NewStudent where enroll='" + eid + "'";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);


                //code to count how many book has been issued on this enroll no
                cmd.CommandText = "select count(senroll)from IRBook where  senroll='" + eid + "' and brdate is null";
                SqlDataAdapter DA1 = new SqlDataAdapter(cmd);
                DataSet DS1 = new DataSet();
                DA1.Fill(DS1);

                count = int.Parse(DS1.Tables[0].Rows[0][0].ToString());



                if (DS.Tables[0].Rows.Count!=0)
                {
                    txtName.Text = DS.Tables[0].Rows[0][1].ToString();
                    txtDepartment.Text = DS.Tables[0].Rows[0][3].ToString();
                    txtSem.Text = DS.Tables[0].Rows[0][4].ToString();
                    txtContact.Text = DS.Tables[0].Rows[0][5].ToString();
                    txtEmail.Text = DS.Tables[0].Rows[0][6].ToString();

                }
                else
                {
                    txtName.Clear();
                    txtDepartment.Clear();     
                    txtSem.Clear();
                    txtContact.Clear();
                    txtEmail.Clear();
                    MessageBox.Show("Invalid Enrollment No", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you Sure", "confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtEnrollNo.Clear();

        }

        private void Issuebook_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source=DESKTOP-IA1RTIE\\SQLEXPRESS; database = library; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();

            cmd = new SqlCommand("select bName from NewBook", con);
            SqlDataReader Sdr = cmd.ExecuteReader();

            while(Sdr.Read())
            {
                for(int i=0;i<Sdr.FieldCount;i++)
                {
                    comboBoxBooks.Items.Add(Sdr.GetString(i));
                }
            }
            Sdr.Close();
            con.Close();
        }

        private void btnIssueBook_Click(object sender, EventArgs e)
        {
            if(txtName.Text!="")
            {
                if(comboBoxBooks.SelectedIndex!=-1 && count<=2)
                {
                    String enroll = txtEnrollNo.Text;
                    String sname = txtName.Text;
                    String sdep = txtDepartment.Text;
                    String ssem = txtSem.Text;
                    Int64 scontact = Int64.Parse(txtContact.Text);
                    String semail = txtEmail.Text;
                    String bname = comboBoxBooks.Text;
                    String bidate = dateTimePicker1.Text;


                    String eid = txtEnrollNo.Text;
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = "data source=DESKTOP-IA1RTIE\\SQLEXPRESS; database = library; integrated security = True";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    con.Open();

                    cmd.CommandText = "insert into IRBook (senroll,sname,sdep,ssem,scontact,semail,bname,bidate) values ('" + enroll + "','" + sname + "','" + sdep + "','" + ssem + "'," + scontact + ",'" + semail + "','" + bname + "','" + bidate + "')";
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Book Issued", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Select Book. OR Maximum no of book has been Issued", "No Book Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                MessageBox.Show("enter valid Enrollment No","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtEnrollNo_TextChanged(object sender, EventArgs e)
        {
            if(txtEnrollNo.Text=="")
            {
                txtName.Clear();
                txtDepartment.Clear();
                txtSem.Clear();
                txtContact.Clear();
                txtEmail.Clear();
            }
        }
    }
}
