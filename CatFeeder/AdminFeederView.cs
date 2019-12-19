﻿using System;
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
    public partial class AdminFeederView : Form, IAdminFeederView
    {
        private readonly ApplicationContext _context;
        public AdminFeederView(ApplicationContext context)
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

        public event Action ShowSch;
        public event Action GoBack;
// public event Action<string> AddSch;
        public event Action<string> ImportSchedule;
        public event Action<string> ExportSchedule;
       // public event Action<string> DeleteSch;

        private void GoBackBtn_Click(object sender, EventArgs e)
        {
            GoBack?.Invoke();
        }

        /*  private void AddBtn_Click(object sender, EventArgs e)
        {
            AddSchedule?.Invoke(tb_Name.Text);
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            foreach (var item in lv_users.SelectedItems)
            {
                var lvItem = item as ListViewItem;
                DeleteSchedule?.Invoke(lvItem?.Text);
            }
        }*/

        public void ShowSchs(IEnumerable<string> users)
        {
            lv_users.Items.Clear();
            foreach (var name in users)
            {
                lv_users.Items.Add(name);
            }
        }

        //public void ShowError(string message)
        //{
        //    lbl_Error.Text = message;
        //}



        private void btn_Export_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ExportSchedule?.Invoke(saveFileDialog.FileName);
            }
        }

        private void ChooseBtn_Click(object sender, EventArgs e)
        {
            //TODO переход на админский schedule который по сути обычный shedule только с запретом на изменение 
            ShowSch?.Invoke();
        }

        private void btn_Import_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ImportSchedule?.Invoke(openFileDialog.FileName);
            }
        }
    }
}
