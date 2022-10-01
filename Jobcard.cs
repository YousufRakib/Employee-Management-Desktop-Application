using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using SkyTree.Reports;
using System.IO;
using CrystalDecisions.Windows.Forms;
using SkyTree.ModelClass;
using CrystalDecisions.CrystalReports.Engine;
using System.Reflection;

namespace SkyTree
{
    public partial class Jobcard : Form
    {
        public Jobcard()
        {
            InitializeComponent();
            BindData();
        }
        //LAPTOP-NUPR82VN
        //SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-D829SPB\SQLEXPRESS;Initial Catalog=bestwooldb;Integrated Security=True");
        SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-NUPR82VN;Integrated Security=True;Initial Catalog=bestwooldb");
        //SqlConnection conn = new SqlConnection(@"Data Source=192.168.1.101,1433;Initial Catalog=bestwooldb;Integrated Security=True");

        private void Jobcard_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet1Production.tbl_production_info' table. You can move, or remove it, as needed.
            //this.tbl_production_infoTableAdapter.Fill(this.DataSet1Production.tbl_production_info);

            //this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void loadBtn_Click(object sender, EventArgs e)
        {
            try
            {
                CrystalReportViewer crystalReportViewer = new CrystalReportViewer();
                ReportDocument rprt = new ReportDocument();
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                DataSet dataSet = new DataSet();

                List<ProductionInfoReportModel> productionInfoList = new List<ProductionInfoReportModel>();
                List<ProductionWiseReportModel> productionWiseInfoList = new List<ProductionWiseReportModel>();

                DateTime dateFrom = Convert.ToDateTime(fromDate.Text);
                DateTime dateTo = Convert.ToDateTime(toDate.Text);
                string idCardNo = cardnoTxt.Text;
                string section = sectionCombo.SelectedItem == null ? "" : sectionCombo.SelectedItem.ToString();

                if (radioButton2.Checked == false && radioButton1.Checked == false)
                {
                    System.Windows.MessageBox.Show("You must have select 1 report from CheckBox!");
                    return;
                }

                if (idCardNo == "" && section == "")
                {
                    System.Windows.MessageBox.Show("You must have select a Section or Insert IdcardNo!");
                    return;
                }
                else
                {
                    if (radioButton1.Checked == true)
                    {
                        SqlCommand sqlComm = new SqlCommand("ProductionReport_sp", conn);
                        sqlComm.Parameters.AddWithValue("@IdCardNo", idCardNo);
                        sqlComm.Parameters.AddWithValue("@Section", section);
                        sqlComm.Parameters.AddWithValue("@DateFrom", dateFrom);
                        sqlComm.Parameters.AddWithValue("@DateTo", dateTo);
                        sqlComm.CommandType = CommandType.StoredProcedure;
                        dataAdapter.SelectCommand = sqlComm;
                        dataAdapter.Fill(dataSet);

                        foreach (DataRow row in dataSet.Tables[0].Rows)
                        {
                            ProductionInfoReportModel productionInfo = new ProductionInfoReportModel();
                            productionInfo.IdCardNo = row["IdCardNo"].ToString();
                            productionInfo.ReportMonth = dateFrom.ToString("MMMM") + "/" + dateTo.ToString("MMMM");
                            productionInfo.EmployeeName = row["EmployeeName"].ToString();
                            productionInfo.Section = row["Section"].ToString();
                            productionInfo.ProductionDay = row["ProductionDay"].ToString();
                            productionInfo.Style = row["Style"].ToString();
                            productionInfo.Size = row["Size"].ToString();
                            productionInfo.Total = Convert.ToDouble(row["Total"].ToString());
                            productionInfoList.Add(productionInfo);
                        }

                        string workingDirectory = Environment.CurrentDirectory;
                        //string workingDirectory = Application.StartupPath;

                        string filePath = Directory.GetParent(workingDirectory).Parent.FullName + "\\Reports\\ProductionSheetReport.rpt";
                        rprt.Load(filePath);

                        rprt.SetDataSource(productionInfoList);
                        crystalReportViewer1.ReportSource = rprt;
                    }
                    else
                    {
                        SqlCommand sqlComm = new SqlCommand("ProductionWiseReport_sp", conn);
                        sqlComm.Parameters.AddWithValue("@IdCardNo", idCardNo);
                        sqlComm.Parameters.AddWithValue("@Section", section);
                        sqlComm.Parameters.AddWithValue("@DateFrom", dateFrom);
                        sqlComm.Parameters.AddWithValue("@DateTo", dateTo);
                        sqlComm.CommandType = CommandType.StoredProcedure;
                        dataAdapter.SelectCommand = sqlComm;
                        dataAdapter.Fill(dataSet);

                        foreach (DataRow row in dataSet.Tables[0].Rows)
                        {
                            ProductionWiseReportModel productionWiseInfo = new ProductionWiseReportModel();
                            productionWiseInfo.IdCardNo = row["IdCardNo"].ToString();
                            productionWiseInfo.ReportMonth = dateFrom.ToString("MMMM") + "/" + dateTo.ToString("MMMM");
                            productionWiseInfo.EmployeeName = row["EmployeeName"].ToString();
                            productionWiseInfo.Section = row["Section"].ToString();
                            productionWiseInfo.ProductionDay = row["ProductionDay"].ToString();
                            productionWiseInfo.Style = row["Style"].ToString();
                            productionWiseInfo.Size = row["Size"].ToString();
                            productionWiseInfo.Present = row["Present"].ToString();
                            productionWiseInfo.TotalQuantity = Convert.ToDouble(row["TotalQuantity"].ToString());
                            productionWiseInfo.Rate = row["Rate"].ToString()==""?0: Convert.ToDouble(row["Rate"].ToString());
                            productionWiseInfo.StyleWiseTotalPrice = Convert.ToDouble(row["StyleWiseTotalPrice"].ToString());
                            productionWiseInfo.TotalPriceWithoutBonus = row["TotalPriceWithoutBonus"].ToString();
                            productionWiseInfo.BonusPercent = row["BonusPercent"].ToString();
                            productionWiseInfo.GrossAmount = ((row["StyleWiseTotalPrice"].ToString() == "" ? 0 : Convert.ToDouble(row["StyleWiseTotalPrice"].ToString()))
                                                           + (row["TotalPriceWithoutBonus"].ToString() == "" ? 0 : Convert.ToDouble(row["TotalPriceWithoutBonus"].ToString()))
                                                           + (row["BonusPercent"].ToString() == "" ? 0 : Convert.ToDouble(row["BonusPercent"].ToString()))).ToString(); 
                            productionWiseInfo.AttendanceBonus = row["AttendanceBonus"].ToString();
                            productionWiseInfoList.Add(productionWiseInfo);
                        }

                        string workingDirectory = Environment.CurrentDirectory;
                        //string workingDirectory = Application.StartupPath;

                        string filePath = Directory.GetParent(workingDirectory).Parent.FullName + "\\Reports\\rptProductionWiseSheetReport.rpt";
                        rprt.Load(filePath);

                        rprt.SetDataSource(productionWiseInfoList);
                        crystalReportViewer1.ReportSource = rprt;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void BindData()
        {
            conn.Open();
            SqlCommand command = new SqlCommand("select * from tbl_section", conn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                sectionCombo.Items.Add(reader["section"].ToString());
            }
            conn.Close();
        }
    }
}
