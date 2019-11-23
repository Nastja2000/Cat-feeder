using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatFeeder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ToolStripMenuItem logAs = new ToolStripMenuItem("Log As");


            ToolStripMenuItem adminItem = new ToolStripMenuItem("Admin");
            ToolStripMenuItem userItem = new ToolStripMenuItem("User");

            menuStrip1.Items.Add(logAs);
            /* Text = "Log In";
             this.BackColor = Color.Bisque;
             this.Size = new Size(590, 397);
             this.ForeColor = Color.Black;

             button1.Text = "User";
             button1.Size = new Size(100, 80);
             button2.Text = "Admin";
             button2.Size = new Size(100, 80);

             label1.Text = "Log as ...";
             label1.Size = new Size(500, 80);
             */

        }

        public string StepSize => tb_StepSize.Text;
       
        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminForm lodedAdmin = new AdminForm(this);
            lodedAdmin.Show();
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserForm newForm = new UserForm(this);
            newForm.Show();
        }

       
       

        private void btn_SetUp_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           //здесь будет кормушка
        }



        /* private void button1_Click(object sender, EventArgs e)
         {
             UserForm newForm = new UserForm(this);
             newForm.Show();
         }

         private void button2_Click(object sender, EventArgs e)
         {
             AdminForm lodedAdmin = new AdminForm(this);
             lodedAdmin.Show();
         }

         private void Form1_Load(object sender, EventArgs e)
         {

         }*/



        /*private void button1_Click(object sender, EventArgs e)
        {
            UserForm newForm = new UserForm(this);
            newForm.Show();
        }*/
    }
}
