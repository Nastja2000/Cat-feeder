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
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();
            this.BackColor = Color.Bisque;
            label1.Text = "Choose or add a feeder";

            button1.Size = new Size(80, 50);
            button1.Text = "Back to log in";
            button6.Text = "Add";
            button6.Size = new Size(80, 65);
        
        }

        public UserForm(ImitationView f)
        {
            InitializeComponent();
            f.BackColor = Color.Yellow;
        }

        public UserForm(AdminForm f)
        {
            InitializeComponent();
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Feeder newFeeder = new Feeder();
            newFeeder.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Feeder newFeeder = new Feeder();
            newFeeder.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Feeder newFeeder = new Feeder();
            newFeeder.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Feeder newFeeder = new Feeder();
            newFeeder.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Button imANewFeeder = new Button();
            imANewFeeder.Text = "Feeder";
            tableLayoutPanel1.Controls.Add(imANewFeeder);
        }

        private void imANewFeeder_Click(object sender, EventArgs e)
        {
            Feeder newFeeder = new Feeder();
            newFeeder.Show();
        }

    }
}
