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
    public partial class HomeScreen1 : Form
    {
        public HomeScreen1()
        {
            InitializeComponent();
        }

        private void buyerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuyerAddForm baf = new BuyerAddForm();
            baf.MdiParent = HomeScreen1.ActiveForm;
            baf.Show();
        }

        private void styleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StyleAddForm saf = new StyleAddForm();
            saf.MdiParent = HomeScreen1.ActiveForm;
            saf.Show();
        }

        private void rateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StyleRateForm saf = new StyleRateForm();
            saf.MdiParent = HomeScreen1.ActiveForm;
            saf.Show();
        }

        private void productionEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductionEntryForm saf = new ProductionEntryForm();
            saf.MdiParent = HomeScreen1.ActiveForm;
            saf.Show();
        }

        private void HomeScreen1_Load(object sender, EventArgs e)
        {

        }

        private void HomeScreen1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserForm saf = new UserForm();
            saf.MdiParent = HomeScreen1.ActiveForm;
            saf.Show();
        }

        private void employeeInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeInfoForm saf = new EmployeeInfoForm();
            saf.MdiParent = HomeScreen1.ActiveForm;
            saf.Show();
        }

        private void monthlyJobcardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Jobcard jb = new Jobcard();
            //jb.MdiParent = HomeScreen1.ActiveForm;
            //jb.Show();
        }

        private void departmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DepartmentForm df = new DepartmentForm();
            df.MdiParent = HomeScreen1.ActiveForm;
            df.Show();
        }

        private void sectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SectionForm df = new SectionForm();
            df.MdiParent = HomeScreen1.ActiveForm;
            df.Show();
        }

        private void productionReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Jobcard df = new Jobcard();
            df.MdiParent = HomeScreen1.ActiveForm;
            df.Show();
        }

        private void companyInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompanyInformation df = new CompanyInformation();
            df.MdiParent = HomeScreen1.ActiveForm;
            df.Show();
        }
    }
}
