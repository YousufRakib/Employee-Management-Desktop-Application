using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkyTree
{
    public partial class StyleRateForm : Form
    {
        public StyleRateForm()
        {
            InitializeComponent();
            StyleProcessLoad();
            BindData();
        }
        //SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-D829SPB\SQLEXPRESS;Initial Catalog=bestwooldb;Integrated Security=True");
        SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-NUPR82VN;Initial Catalog=bestwooldb;Integrated Security=True");
       //SqlConnection conn = new SqlConnection(@"Data Source=192.168.1.101,1433;Initial Catalog=bestwooldb;Integrated Security=True");

        
        private void button1_Click(object sender, EventArgs e)
        {
            string style = comboBox1Style.Text;
            string process = comboBox2Process.Text;
            double price = Convert.ToDouble(textBox3Price.Text);
            

            if(style == "" && process == "" && price == 0)
            {
                MessageBox.Show("Invalid information");
            } else
            {
                conn.Open();
                string query = "INSERT INTO [dbo].[tbl_style_rate]([style],[process],[price]) VALUES('" + style + "', '" + process + "', '" + price + "')";
                SqlCommand insertCommand = new SqlCommand(query,conn);
                int result = insertCommand.ExecuteNonQuery();
                conn.Close();
                if (result == 1)
                {
                    MessageBox.Show("Saved");
                    textBox3Price.Text = "0";
                }
                else
                {
                    MessageBox.Show("DB not connected.");
                }
                BindData();
            }
        }

        private void StyleRateForm_Load(object sender, EventArgs e)
        {
            
        }
        public void StyleProcessLoad()
        {
            conn.Open();
            string query = "select * from tbl_style_info";
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                string cName = dr.GetString(2);
                comboBox1Style.Items.Add(cName);
                string pName = dr.GetString(3);
                comboBox2Process.Items.Add(pName);
            }
            conn.Close();
        }

        public void BindData()
        {
            conn.Open();
            string query1 = "select * from tbl_style_rate";
            SqlCommand command = new SqlCommand(query1,conn);
            SqlDataAdapter sd = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            conn.Close();
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public int readerID;
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            conn.Open();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewRow delRow = dataGridView1.Rows[i];
                if (delRow.Selected == true)
                {
                    string query1 = "select * FROM tbl_style_rate where id = '" + dataGridView1.Rows[i].Cells[0].Value + "'";
                    SqlCommand command2 = new SqlCommand(query1, conn);
                    SqlDataReader reader = command2.ExecuteReader();
                    while (reader.Read())
                    {
                        readerID = int.Parse(reader["id"].ToString());
                        comboBox1Style.Text = reader["style"].ToString();
                        comboBox2Process.Text = reader["process"].ToString();
                        textBox3Price.Text = reader["price"].ToString();
                    }
                    MessageBox.Show("Row selected. Change and update information", "Information Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e) //update
        {
            double price = Convert.ToDouble(textBox3Price.Text);
            conn.Open();
            string query = "update tbl_style_rate set style='" + comboBox1Style.Text.ToUpper() + "',process='" + comboBox2Process.Text.ToUpper() + "',price='" + price + "' where id='" + readerID + "'";
            SqlCommand insertCommand = new SqlCommand(query, conn);
            insertCommand.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Update success.", "Information Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            BindData();
            textBox3Price.Text = "0";
        }

        private void button4_Click(object sender, EventArgs e) //delete button
        {
            conn.Open();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewRow delRow = dataGridView1.Rows[i];
                if (delRow.Selected == true)
                {
                    string query1 = "DELETE FROM tbl_style_rate where id = '" + dataGridView1.Rows[i].Cells[0].Value + "'";
                    SqlCommand command2 = new SqlCommand(query1, conn);
                    command2.ExecuteNonQuery();
                    dataGridView1.Rows.RemoveAt(i);
                    MessageBox.Show("Record deleted.", "Delete Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            conn.Close();
        }
    }
}
