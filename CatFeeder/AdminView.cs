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

        public event Action ShowOwner;
      //public event Action ShowFeeder;
      public event Action GoBack;
      public event Action<string> addOwner;
        public event Action<string> deleteOwner;

        private void GoBackBtn_Click(object sender, EventArgs e)
        {
            GoBack?.Invoke();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            addOwner?.Invoke(tb_Name.Text);
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        { 
            foreach (var item in lv_users.SelectedItems)
            {
                var lvItem = item as ListViewItem;
                deleteOwner?.Invoke(lvItem?.Text);
            }
        }

        public void ShowOwners(IEnumerable<string> users)
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

        private void ChooseBtn_Click(object sender, EventArgs e)
        {
            ShowOwner?.Invoke();
        }
    }
}
