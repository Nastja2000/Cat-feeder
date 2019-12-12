using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Presentation;

namespace CatFeeder
{
    public partial class ImitationView : Form, IImitationView
    {
        private bool _imitation;
        private string[] _food;
        private readonly ApplicationContext _context;

        public ImitationView(ApplicationContext context)
        {
            _context = context;
            InitializeComponent();
            ResetView();
            ToolStripMenuItem logAs = new ToolStripMenuItem("Log As");
            ToolStripMenuItem adminItem = new ToolStripMenuItem("Admin");
            ToolStripMenuItem userItem = new ToolStripMenuItem("User");

            menuStrip1.Items.Add(logAs);
        }

        public new void Show()
        {
            ResetView();
            _context.MainForm = this;
            base.Show();
        }
        public string EatingQuantVal => tb_QuantityPerCatEating.Text;
        public string EatingFreqVal => tb_Cat_Eating_Frequency.Text;

        public event Action ShowAdmin;
        public event Action ShowUser;
        public event Action StartImmitation;
        public event Action StopImmitation;
        public event Action addFood;
        //public event Action Step;
        public event Action setEatingQuan;
        public event Action setEatingFreq;
        public event Action setStepSize;



        public string CountOfFood => tb_AddFood.Text;        
        public string StepSizeVal => tb_StepSize.Text;
        public int id => int.Parse(tb_name.Text);

        public void ShowFood(IEnumerable<string> food)
        {
            _food = food.ToArray();  // backup food to operate with it during imitation
            lv_Food.Items.Clear();
            foreach (var item in _food)
            {
                lv_Food.Items.Add(item);
            }

            StartImitButton.Enabled = _imitation || _food.Any();
        }

        public void ShowFeederStatus(int countOfFood)
        {
            lv_Food.Items.Clear();

            // Draw Round number
            lv_Food.Items.Add(new ListViewItem { Text = $"Count of added food =  {countOfFood + 1}", Font = new Font(lv_Food.Font, FontStyle.Bold )});

        }

        public void ShowTime(TimeSpan imitation_duration)
        {
            tb_ImitationDuration.Text = $@"{imitation_duration:h\:mm\:ss}";
        }


        public void ImitationStarted()
        {
            _imitation = true;
            StepSizeButton.Text = @"Set Up";
            CatEatFreqButton.Text = @"Set Up";
            QuantPerCatEatButton.Text = @"Set Up";
            button3.Text = @"Set Up";
            AddFoodButton.Text = @"ADD";
            StepButton.Text = @"Step";
            StartImitButton.Text = @"Start";
            StopImitButton.Text = @"Stop";

            StartImitButton.Enabled = true;
            tb_AddFood.Enabled = true;
            tb_Cat_Eating_Frequency.Enabled = true;
            tb_QuantityDispersion.Enabled = true;
            tb_QuantityPerCatEating.Enabled = true;
        }

        private void ResetView()
        {
            _imitation = false;
            StepSizeButton.Text = @"Set Up";
            CatEatFreqButton.Text = @"Set Up";
            QuantPerCatEatButton.Text = @"Set Up";
            button3.Text = @"Set Up";
            AddFoodButton.Text = @"ADD";
            StepButton.Text = @"Step";
            StartImitButton.Text = @"Start";
            StopImitButton.Text = @"Stop";

            StopImitButton.Enabled = false;
            tb_AddFood.Enabled = true;
            tb_Cat_Eating_Frequency.Enabled = true;
            tb_QuantityDispersion.Enabled = true;
            tb_QuantityPerCatEating.Enabled = true;
            ShowTime(TimeSpan.Zero);
        }

        public void ImitationStopped()
        {
            ResetView();
        }



        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*UserForm newForm = new UserForm(this);
            newForm.Show();*/
            ShowUser?.Invoke();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*AdminForm lodedAdmin = new AdminForm(this);
            lodedAdmin.Show();*/
            ShowAdmin?.Invoke();
        }

        private void StepSizeButton_Click(object sender, EventArgs e)
        {
            setStepSize?.Invoke();
        }

        

        private void StartImitButton_Click(object sender, EventArgs e)
        {
            StartImmitation?.Invoke();
        }

        private void StopImitButton_Click(object sender, EventArgs e)
        {
            StopImmitation.Invoke();
        }

        public void ShowError(string message)
        {
            lbl_Error.Text = message;
        }

        private void CatEatFreqButton_Click(object sender, EventArgs e)
        {
            setEatingFreq?.Invoke();
        }

        private void QuantPerCatEatButton_Click(object sender, EventArgs e)
        {
            setEatingQuan?.Invoke();
        }

        private void AddFoodButton_Click(object sender, EventArgs e)
        {
            addFood?.Invoke();
        }

        

        /* private void StepButton_Click(object sender, EventArgs e)
         {
             Step?.Invoke();
         }*/


    }
}
