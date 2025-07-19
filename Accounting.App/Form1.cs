using Accounting.Business;
using Accounting.Utility.Convertor;
using Accounting.ViewModels.Accounting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Accounting.App
{
    public partial class Form1 : Form
    {
        internal static string LoginUser = "";
            public Form1()
        {
            InitializeComponent();
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            frmCustomers frmCustomers = new frmCustomers();
            frmCustomers.ShowDialog();
        }

        private void btnNewTransaction_Click(object sender, EventArgs e)
        {
            frmNewTransaction frmNewTransaction = new frmNewTransaction();

            frmNewTransaction.ShowDialog();
            MainReport();
        }

        private void btnGetReport_Click(object sender, EventArgs e)
        {
            frmReport frmGetReport = new frmReport();
            frmGetReport.TypeID = 1;
            frmGetReport.ShowDialog();
            MainReport();
        }

        private void btnPayReport_Click(object sender, EventArgs e)
        {
            frmReport frmPayReport = new frmReport();
            frmPayReport.TypeID = 2;
            frmPayReport.ShowDialog();
            MainReport();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin frmLogin = new frmLogin();
            if (frmLogin.ShowDialog() == DialogResult.OK)
            {
                lblDate.Text = DateTime.Now.ToShamsi();
                lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
                lblUser.Text = LoginUser;
                this.Show();
                MainReport();
            }
            else
            {
                Application.Exit();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void btnChangeUserOrPass_Click(object sender, EventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            frmLogin.IsEdit = true;
            frmLogin.ShowDialog();
        }
        void MainReport()
        {
            ReportViewModel report = Account.ReportMain();
            lblTotalPay.Text = report.Pay.ToString("#,0") + "  ریال";
            lblTotalGet.Text = report.Recive.ToString("#,0") + "  ریال";
            lblRemain.Text = report.RemainBalance.ToString("#,0") + "  ریال";
        }


    }
}
