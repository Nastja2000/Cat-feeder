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

        public event Action<string, string> GoBack;
        public event Action<IEnumerable<string>> Save;

        public string ownerName { get; set; }
        public string feederName { get; set; }
        public string scheduleName { get; set; }
        //  public event Action<bool> AddMark;

        public string TurnDurationLimit
        {
            get => tb_TurnDurationLimit.Text;
            set => tb_TurnDurationLimit.Text = value;
        }

        public string TurnFoodAmount
        {
            get => tb_amount.Text;
            set => tb_amount.Text = value;
        }

        private void GoBackBtn_Click(object sender, EventArgs e)
        {
            GoBack?.Invoke(ownerName,feederName);
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
            //TODO проверка на пустоту
            List<string> fields = new List<string>();
            fields.Add(scheduleName);
            fields.Add(TurnFoodAmount);
            fields.Add(TurnDurationLimit);
            Save?.Invoke(fields);
        }
    }
}
