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
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
            this.BackColor = Color.Bisque;
            label1.Text = "Choose or add a feeder";

            button1.Size = new Size(100, 80);
            button1.Text = "Back to log in";
            button6.Text = "Add";
            button6.Size = new Size(100, 100);

        }

        /*ivate void AdminForm_Load(object sender, EventArgs e)
        {

        }*/

        public AdminForm(ImitationView f)
        {
            InitializeComponent();
            f.BackColor = Color.Red;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void button6_Click(object sender, EventArgs e)
        {
            Button imANewUser= new Button();
            imANewUser.Text = "User";
            tableLayoutPanel1.Controls.Add(imANewUser);
           

        }
      /*private void imANewUser_Click(object sender, EventArgs e)
        {
            UserForm newUser = new UserForm();
            newUser.Show();
        }*/

        private void button4_Click_1(object sender, EventArgs e)
        {
            UserForm newFeeder = new UserForm();
            newFeeder.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UserForm newFeeder = new UserForm();
            newFeeder.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UserForm newFeeder = new UserForm();
            newFeeder.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserForm newFeeder = new UserForm();
            newFeeder.Show();
        }
    }
}
