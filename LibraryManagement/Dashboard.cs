using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to exit","confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
            {
                Application.Exit();
            }
           

        }

        private void addNewBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddBook abs = new AddBook();
            abs.Show();
        }

        private void viewBoooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewBook vb = new NewBook();
            vb.Show();


        }

        private void addStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStudent ast = new AddStudent();
            ast.Show();
        }

        private void viewStudentDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewStudent vsa = new ViewStudent();
            vsa.Show();
        }


        private void issueBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Issuebook ib = new Issuebook();
            ib.Show();
        }

        private void returnBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReturnBook ib = new ReturnBook();
            ib.Show();
        }

        private void completeBooToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompleteBookDetail ib = new CompleteBookDetail();
            ib.Show();
        }

        private void booksToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
