using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace SkyTree
{
    public partial class DepartmentForm : Form
    {
        public DepartmentForm()
        {
            InitializeComponent();
            BindData();
        }
        //SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-D829SPB\SQLEXPRESS;Initial Catalog=bestwooldb;Integrated Security=True");
        SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-NUPR82VN;Initial Catalog=bestwooldb;Integrated Security=True");
        //SqlConnection conn = new SqlConnection(@"Data Source=192.168.1.101,1433;Initial Catalog=bestwooldb;Integrated Security=True");

        private void DepartmentForm_Load(object sender, EventArgs e)
        {

        }


        public void BindData()
        {
            string query = "select * from tbl_department";
            conn.Open();
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataAdapter sda = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            conn.Close();
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e) //save data
        {
            string dept = textBox1Buyer.Text;

            if(dept == string.Empty)
            {
                MessageBox.Show("Empty department name");
            } else
            {
                conn.Open();
                string InsertQuery = "INSERT INTO[dbo].[tbl_department]([department],[createdtime]) VALUES('" + dept + "','"+DateTime.Now.ToString("MM/dd/yyyy")+"')";
                SqlCommand command = new SqlCommand(InsertQuery, conn);
                command.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Saved", "", MessageBoxButtons.YesNo);
                textBox1Buyer.Clear();
                BindData();
            }
        }
        
        private void button3Delete_Click(object sender, EventArgs e) //delete data
        {
            conn.Open();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewRow delData = dataGridView1.Rows[i];
                if(delData.Selected == true)
                {
                    string query3 = "delete tbl_department where dept_id = '"+dataGridView1.Rows[i].Cells[0].Value+"'";
                    SqlCommand command4 = new SqlCommand(query3, conn);
                    command4.ExecuteNonQuery();
                    MessageBox.Show("Data deleted");
                    
                }
            }
            conn.Close();
            BindData();
        }
        public int dept_id;
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e) //for edit option
        {
            conn.Open();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewRow delRow = dataGridView1.Rows[i];
                if(delRow.Selected == true)
                {
                    string query2 = "select * from tbl_department where dept_id = '"+dataGridView1.Rows[i].Cells[0].Value+"'";
                    SqlCommand command3 = new SqlCommand(query2, conn);
                    SqlDataReader reader = command3.ExecuteReader();
                    while (reader.Read())
                    {
                        dept_id = int.Parse(reader["dept_id"].ToString());
                        textBox1Buyer.Text = reader["department"].ToString();
                    }
                }
            }
            conn.Close();
            BindData();
        }

        private void button4Update_Click(object sender, EventArgs e) //update data
        {
            conn.Open();
            SqlCommand command2 = new SqlCommand("update tbl_department set department = '" + textBox1Buyer.Text + "', updatetime='" + DateTime.Now + "' where dept_id = '" + dept_id + "'", conn);
            command2.ExecuteNonQuery();
            conn.Close();
            textBox1Buyer.Clear();
            MessageBox.Show("Information Updated");
            BindData();
        }
    }
}
