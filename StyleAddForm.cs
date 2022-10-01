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
    public partial class StyleAddForm : Form
    {
        public StyleAddForm()
        {
            InitializeComponent();
            BuyerLoad();
        }

        
        //SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-D829SPB\SQLEXPRESS;Initial Catalog=bestwooldb;Integrated Security=True");
        SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-NUPR82VN;Initial Catalog=bestwooldb;Integrated Security=True");
        //SqlConnection conn = new SqlConnection(@"Data Source=192.168.1.101,1433;Initial Catalog=bestwooldb;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e) //insert button
        {
            string buyer = comboBox1.Text;
            string style = textBox2Style.Text;
            string process = textBox3Process.Text;

            if (comboBox1.Text == string.Empty)
            {
                MessageBox.Show("Empty Buyer Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);            
            }
            else if (textBox2Style.Text == string.Empty)
            {
                MessageBox.Show("Empty Style Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);            
            }
            else if (textBox3Process.Text == string.Empty)
            {
                MessageBox.Show("Empty Process Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);            
            }
            else
            {
                conn.Open();
                string query = "INSERT INTO [dbo].[tbl_style_info]([buyer] ,[style],[process]) VALUES('" + comboBox1.Text + "', '" + textBox2Style.Text.ToUpper()+ "', '" + textBox3Process.Text.ToUpper() + "')";
                SqlCommand insertCommand = new SqlCommand(query,conn);
                insertCommand.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Style saved success.","Information Saved",MessageBoxButtons.OK,MessageBoxIcon.Information);
                BindData();
                BoxClear();
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        public void BindData()
        {
            conn.Open();
            string query = "select * from tbl_style_info";
            SqlCommand command = new SqlCommand(query,conn);
            SqlDataAdapter sd = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            conn.Close();
            dataGridView1.DataSource = dt;
        }
        public void BuyerLoad()
        {
            conn.Open();
            string query = "select * from tbl_buyer_info";
            SqlCommand command = new SqlCommand(query, conn);            
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                string cName = dr["buyer"].ToString();
                comboBox1.Items.Add(cName);
            }
            conn.Close();                     
        }

        public void BoxClear()
        {            
            textBox2Style.Clear();
            textBox3Process.Clear();
        }

        private void StyleAddForm_Load(object sender, EventArgs e)
        {            
            BindData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewRow delRow = dataGridView1.Rows[i];
                if(delRow.Selected == true)
                {
                    string query1 = "DELETE FROM tbl_style_info where id = '" + dataGridView1.Rows[i].Cells[0].Value + "'";
                    SqlCommand command2 = new SqlCommand(query1, conn);
                    command2.ExecuteNonQuery();
                    dataGridView1.Rows.RemoveAt(i);
                    MessageBox.Show("Record deleted.", "Information",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
            }
            conn.Close();
        }

        public int readerID;
        private void button2_Click(object sender, EventArgs e) // edit button
        {
            conn.Open();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewRow delRow = dataGridView1.Rows[i];
                if (delRow.Selected == true)
                {
                    string query1 = "select * FROM tbl_style_info where id = '" + dataGridView1.Rows[i].Cells[0].Value + "'";
                    SqlCommand command2 = new SqlCommand(query1, conn);
                    SqlDataReader reader = command2.ExecuteReader();
                    while (reader.Read())
                    {
                        readerID = int.Parse(reader["id"].ToString());
                        comboBox1.Text = reader["buyer"].ToString();
                        textBox2Style.Text = reader["style"].ToString();
                        textBox3Process.Text = reader["process"].ToString();
                    }                    
                    MessageBox.Show("Row selected. Change and update information", "Information Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e) // update button
        {

            
                conn.Open();
                string query = "update tbl_style_info set buyer='"+comboBox1.Text+"',style='"+textBox2Style.Text.ToUpper()+"',process='"+textBox3Process.Text.ToUpper()+"' where id='"+readerID+"'";
                SqlCommand insertCommand = new SqlCommand(query, conn);
                insertCommand.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Update success.", "Information Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BindData();
                BoxClear();
            
        }    
    }
}
