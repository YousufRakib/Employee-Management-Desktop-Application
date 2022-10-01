using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SkyTree
{
    public partial class SectionForm : Form
    {
        public SectionForm()
        {
            InitializeComponent();
            LoadDeptCombo();
            BindData();
        }
        //SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-D829SPB\SQLEXPRESS;Initial Catalog=bestwooldb;Integrated Security=True");
        SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-NUPR82VN;Initial Catalog=bestwooldb;Integrated Security=True");
        //SqlConnection conn = new SqlConnection(@"Data Source=192.168.1.101,1433;Initial Catalog=bestwooldb;Integrated Security=True");

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) // save data
        {
            string dept = comboBox1.Text;
            string section = txtSection.Text;

            if (dept == string.Empty || section == string.Empty)
            {
                MessageBox.Show("Invalid");
            }
            else
            {
                conn.Open(); 
                string InsertQuery = "INSERT INTO [dbo].[tbl_section] ([department] ,[section] ,[createdTime] ) VALUES ('"+dept+"','"+section+"','"+DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + "')";
                SqlCommand command = new SqlCommand(InsertQuery, conn);
                command.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Saved", "", MessageBoxButtons.YesNo);
                comboBox1.Text="";
                txtSection.Clear();
                BindData();
            }
        }
        public int sec_id;
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            conn.Open();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewRow selData = dataGridView1.Rows[i];
                if(selData.Selected == true)
                {
                    string query = "select * from tbl_section where sec_id = '"+dataGridView1.Rows[i].Cells[0].Value+"'";
                    SqlCommand command2 = new SqlCommand(query, conn);
                    SqlDataReader reader = command2.ExecuteReader();
                    while (reader.Read())
                    {
                        sec_id = int.Parse(reader["sec_id"].ToString());
                        string dName = reader["department"].ToString();
                        comboBox1.Text = dName;
                        string sName = reader["section"].ToString();
                        txtSection.Text = sName;
                    }
                }
            }
            conn.Close();
        }

        private void button4Update_Click(object sender, EventArgs e) //update data
        {
            conn.Open();
            SqlCommand command2 = new SqlCommand("update tbl_section set department = '" + comboBox1.Text + "', section='"+txtSection.Text+"',updatetime='" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + "' where sec_id = '" + sec_id + "'", conn);
            command2.ExecuteNonQuery();
            conn.Close();
            comboBox1.Text = "";
            txtSection.Clear();
            MessageBox.Show("Information Updated");
            BindData();
        }

        private void button3Delete_Click(object sender, EventArgs e) //delete data
        {
            conn.Open();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewRow delData = dataGridView1.Rows[i];
                if (delData.Selected == true)
                {
                    string query3 = "delete tbl_section where sec_id = '" + dataGridView1.Rows[i].Cells[0].Value + "'";
                    SqlCommand command4 = new SqlCommand(query3, conn);
                    command4.ExecuteNonQuery();
                    MessageBox.Show("Data deleted");

                }
            }
            conn.Close();
            BindData();
        }

        public void BindData()
        {
            conn.Open();
            string query = "select * from tbl_section";
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataAdapter sd = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            conn.Close();
            dataGridView1.DataSource = dt;
        }
        public void LoadDeptCombo()
        {
            conn.Open();
            string query = "select * from tbl_department";
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                string cName = dr["department"].ToString();
                comboBox1.Items.Add(cName);
            }
            conn.Close();
        }

        
    }
}
