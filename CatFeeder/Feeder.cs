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
    public partial class Feeder : Form
    {
        public Feeder()
        {
            InitializeComponent();
           // this.BackgroundImage = Image.FromFile("D:\\University\\тех прога\\Кормушка( интерфейс)\\CatFeeder\\feederImage.jpg");
            //this.BackgroundImageLayout = ImageLayout.Stretch;
           
        }

        public Feeder(UserForm f)
        {
            InitializeComponent();
            f.BackColor = Color.Yellow;
        }

        public Feeder(AdminForm f)
        {
            InitializeComponent();
            f.BackColor = Color.Yellow;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackgroundImage = Image.FromFile("D:\\University\\тех_прога\\Кормушка( интерфейс)\\CatFeeder\\feederImage.jpg");
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //choose a mark
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //change a mark
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //add some food
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //change timetable
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //add timetable
        }

        
    }
}
