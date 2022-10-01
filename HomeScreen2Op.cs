using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkyTree
{
    public partial class HomeScreen2Op : Form
    {
        public HomeScreen2Op()
        {
            InitializeComponent();
        }

        private void HomeScreen2Op_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void productionEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductionEntryForm pef = new ProductionEntryForm();
            pef.MdiParent = ActiveForm;
            pef.Show();
        }

        private void employeeInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeInfoForm pef = new EmployeeInfoForm();
            pef.MdiParent = ActiveForm;
            pef.Show();
        }

        private void buyerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuyerAddForm pef = new BuyerAddForm();
            pef.MdiParent = ActiveForm;
            pef.Show();
        }

        private void styleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StyleAddForm pef = new StyleAddForm();
            pef.MdiParent = ActiveForm;
            pef.Show();
        }
    }
}
