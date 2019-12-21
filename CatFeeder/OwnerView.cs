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
    public partial class OwnerView : Form, IOwnerView
    {
        private readonly ApplicationContext _context;



        public OwnerView(ApplicationContext context)
        {
            _context = context;
            InitializeComponent();
        }

        public new void Show()
        {
            //_context.MainForm = this;
            ShowError(string.Empty);
            base.Show();
        }

        public event Action<string, string> ShowFeeder;
        public event Action GoBack;
        public event Action<string> AddFeeder;
        public event Action<string> DeleteFeeder;
        public string ownerName { get; set; }

        private void GoBackBtn_Click(object sender, EventArgs e)
        {
            GoBack?.Invoke();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            AddFeeder?.Invoke(tb_Name.Text);
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            foreach (var item in lv_users.SelectedItems)
            {
                var lvItem = item as ListViewItem;
                DeleteFeeder?.Invoke(lvItem?.Text);
            }
        }

        public void ShowFeeders(IEnumerable<string> feeders)
        {
            lv_users.Items.Clear();
            foreach (var name in feeders)
            {
                lv_users.Items.Add(name);
            }
        }

        public void ShowError(string message)
        {
            lbl_Error.Text = message;
        }

        private void ChooseBtn_Click(object sender, EventArgs e)
        {
            if (lv_users.SelectedItems.Count > 0)
            {
                ShowFeeder?.Invoke(ownerName, lv_users.SelectedItems[0].Text);
            }
            else
            {
                ShowError("U should choose from list before clicking button");
            }

        }
    }
}
