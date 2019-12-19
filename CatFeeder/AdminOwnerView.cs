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
    public partial class AdminOwnerView : Form, IAdminOwnerView
    {
        private readonly ApplicationContext _context;

        public AdminOwnerView(ApplicationContext context)
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

        public event Action ShowFeeder;
        public event Action GoBack;
        public event Action<string> addFeeder;
        public event Action<string> deleteFeeder;


        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            foreach (var item in lv_users.SelectedItems)
            {
                var lvItem = item as ListViewItem;
                deleteFeeder?.Invoke(lvItem?.Text);
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


        private void AddBtn_Click(object sender, EventArgs e)
        {
            addFeeder?.Invoke(tb_Name.Text);
        }

        private void ChooseBtn_Click(object sender, EventArgs e)
        {
            ShowFeeder?.Invoke();
        }

        private void GoBackBtn_Click(object sender, EventArgs e)
        {
            GoBack?.Invoke();
        }
    }
}
