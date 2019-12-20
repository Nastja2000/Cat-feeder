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
    public partial class ListOfOwnersView : Form, IListOfOwnersViewcs
    {
        private readonly ApplicationContext _context;
        public ListOfOwnersView(ApplicationContext context)
        {
            _context = context;
            InitializeComponent();
        }

        public new void Show()
        {
            _context.MainForm = this;
            base.Show();

        }

        public event Action GoBack;
        public event Action<int> ShowOwner;

        public void ShowOwners(IEnumerable<string> users)
        {
            lv_users.Items.Clear();
            foreach (var name in users)
            {
                lv_users.Items.Add(name);
            }
        }

        private void ChooseBtn_Click(object sender, EventArgs e)
        {
            //TODO сюда из под кнопки должен прилетать айдишник (или ещё как это решить)
            ShowOwner?.Invoke(0);
        }

        private void GoBackBtn_Click(object sender, EventArgs e)
        {
            GoBack?.Invoke();
        }

    }
}
