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
    public partial class ScheduleView : Form, IScheduleView
    {
        private readonly ApplicationContext _context;
        public ScheduleView(ApplicationContext context)
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

        public event Action GoBack;
        public event Action<string> Save;
        //public event Action<bool> AddMark;

        public string TurnDurationLimit
        {
            get => tb_TurnDurationLimit.Text;
            set => tb_TurnDurationLimit.Text = value;
        }

        private void GoBackBtn_Click(object sender, EventArgs e)
        {
            GoBack?.Invoke();
        }

        /*private void AddBtn_Click(object sender, EventArgs e)
        {
            bool flag = true;
            AddMark?.Invoke(flag);
        }*/

        public void ShowError(string message)
        {
            lbl_Error.Text = message;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            Save?.Invoke(TurnDurationLimit);
        }
    }
}
