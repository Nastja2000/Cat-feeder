using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Presentation;

namespace CatFeeder
{
    public partial class AdminView : Form, IAdminView
    {
        private readonly ApplicationContext _context;
        public AdminView(ApplicationContext context)
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

        public event Action ShowUser;
        public event Action ShowFeeder;
      public event Action GoBack;
      public event Action<string> AddUser;
        public event Action<string> DeleteUser;

        private void GoBackBtn_Click(object sender, EventArgs e)
        {
            GoBack?.Invoke();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            AddUser?.Invoke(tb_Name.Text);
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        { 
            foreach (var item in lv_users.SelectedItems)
            {
                var lvItem = item as ListViewItem;
                DeleteUser?.Invoke(lvItem?.Text);
            }
        }

        public void ShowUsers(IEnumerable<string> users)
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

        private void button1_Click(object sender, EventArgs e)
        {
            ShowUser?.Invoke();
        }
    }
}
