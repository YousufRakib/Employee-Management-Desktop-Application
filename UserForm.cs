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
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();
            BindData();
        }
        
        //SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-D829SPB\SQLEXPRESS;Initial Catalog=bestwooldb;Integrated Security=True");
        SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-NUPR82VN;Initial Catalog=bestwooldb;Integrated Security=True");
        //SqlConnection conn = new SqlConnection(@"Data Source=192.168.1.101,1433;Initial Catalog=bestwooldb;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e) // insert button
        {
            string name = textBox1Name.Text;
            string username = textBox2Username.Text;
            string password = textBox3Password.Text;
            string role = comboBox1.Text;           
            int active = 1;
            if (name == "" && username == "" && password == "" && role == "")
            {
                MessageBox.Show("Invalid Information");
            } else
            {
                conn.Open();
                string query = "INSERT INTO [dbo].[tbl_users]([name],[username],[password],[active],[role]) VALUES ('"+name+"','"+username+"','"+password+"','"+ active +"','"+role+"')";
                SqlCommand insertCommand = new SqlCommand(query,conn);
                int result = insertCommand.ExecuteNonQuery();
                conn.Close();
                if (result == 1)
                {
                    MessageBox.Show("User saved");
                    textBox1Name.Clear();
                    textBox2Username.Clear();
                    textBox3Password.Clear();                    
                }
                else
                {
                    MessageBox.Show("DB not connected.");
                }
                BoxClear();
                BindData();
            }
            
        }

        private void button2_Click(object sender, EventArgs e) // update button
        {
            conn.Open();
            string query = "update tbl_users set name='" + textBox1Name.Text + "',username='" + textBox2Username.Text + "',password='" + textBox3Password.Text + "',role='"+comboBox1.Text+"' where id='" + readerID + "'";
            SqlCommand insertCommand = new SqlCommand(query, conn);
            insertCommand.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Update success.", "Information Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            BoxClear();
            BindData();
        }

        private void button3_Click(object sender, EventArgs e) // delete button
        {
            conn.Open();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewRow delRow = dataGridView1.Rows[i];
                if (delRow.Selected == true)
                {
                    string query1 = "DELETE FROM tbl_users where id = '" + dataGridView1.Rows[i].Cells[0].Value + "'";
                    SqlCommand command2 = new SqlCommand(query1, conn);
                    command2.ExecuteNonQuery();
                    dataGridView1.Rows.RemoveAt(i);
                    MessageBox.Show("Record deleted.", "Delete Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            conn.Close();
            BindData();
        }

        public void BindData()
        {
            conn.Open();
            string query1 = "select * from tbl_users";
            SqlCommand command = new SqlCommand(query1, conn);
            SqlDataAdapter sd = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            conn.Close();
            dataGridView1.DataSource = dt;
        }

        public void BoxClear()
        {
            textBox1Name.Clear();
            textBox2Username.Clear();
            textBox3Password.Clear();
        }
        public int readerID;
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e) // select row for update
        {
            conn.Open();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewRow delRow = dataGridView1.Rows[i];
                if (delRow.Selected == true)
                {
                    string query1 = "select * FROM tbl_users where id = '" + dataGridView1.Rows[i].Cells[0].Value + "'";
                    SqlCommand command2 = new SqlCommand(query1, conn);
                    SqlDataReader reader = command2.ExecuteReader();
                    while (reader.Read())
                    {
                        readerID = int.Parse(reader["id"].ToString());
                        textBox1Name.Text = reader["name"].ToString();
                        textBox2Username.Text = reader["username"].ToString();
                        textBox3Password.Text = reader["password"].ToString();
                        comboBox1.Text = reader["role"].ToString();
                    }
                    MessageBox.Show("Row selected. Change and update information", "Information Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            conn.Close();
        }
    }
}
