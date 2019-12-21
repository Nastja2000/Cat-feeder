using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Presentation;

namespace CatFeeder
{
    public partial class FeederView : Form, IFeederView
    {
        private readonly ApplicationContext _context;
        public FeederView(ApplicationContext context)
        {
            _context = context;
            InitializeComponent();
        }

        public new void Show()
        {
            _context.MainForm = this;
            ShowError(string.Empty);
            base.Show();
        }

        public event Action<string, string, string> ShowSch;
        public event Action<string> GoBack;
        public event Action<string,string> CreateSchedule;
        public event Action<string, string> ImportSchedule;
        public event Action<string, string> ExportSchedule;
        public event Action<string, string> SetActive;

        public string feederName { get; set; }
        public string ownerName { get; set; }


        public void ShowSchs(IEnumerable<string> users)
        {
            lv_users.Items.Clear();
            foreach (var name in users)
            {
                lv_users.Items.Add(name);
            }
        }

        public void ShowError(string message)
        {
            lbl_Error.Text = message;
        }

        private void btn_Import_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK) 
            {
                ImportSchedule?.Invoke(openFileDialog.FileName, feederName);
            }
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ExportSchedule?.Invoke(saveFileDialog.FileName, feederName);
            }
        }
        
        private void ChooseBtn_Click_1(object sender, EventArgs e)
        {
            if (scheduleName.Length > 0)
            {
                ShowSch?.Invoke(ownerName, feederName, scheduleName);
            } else
            {
                ShowError("U should choose from list before clicking button");
            }
           
        }

        private string scheduleName = "";
        private void lv_users_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lv_users.SelectedItems.Count > 0)
            {
               scheduleName = lv_users.SelectedItems[0].Text;
            }
        }

        private void setActive_Click(object sender, EventArgs e)
        {
            if (scheduleName.Length > 0)
            {
                SetActive?.Invoke(feederName,scheduleName);
            }
            else
            {
                ShowError("U should choose from list before clicking button");
            }
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            CreateSchedule?.Invoke(feederName, tb_Name.Text);
        }

        private void GoBackBtn_Click_1(object sender, EventArgs e)
        {
            GoBack?.Invoke(ownerName);
        }
    }
}
