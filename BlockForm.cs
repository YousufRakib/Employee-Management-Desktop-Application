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
    public partial class BlockForm : Form
    {
        public BlockForm()
        {
            InitializeComponent();
            
            BindData();
        }
        //SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-D829SPB\SQLEXPRESS;Initial Catalog=bestwooldb;Integrated Security=True");
        SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-NUPR82VN;Initial Catalog=bestwooldb;Integrated Security=True");
        //SqlConnection conn = new SqlConnection(@"Data Source=192.168.1.101,1433;Initial Catalog=bestwooldb;Integrated Security=True");


        private void button1_Click(object sender, EventArgs e) //save data
        {
            if(comboBox2.Text != string.Empty)
            {
                string query1 = "insert into tbl_block (block,createdtime) values ('"+comboBox2.Text+"','"+DateTime.Now+"')";
                conn.Open();
                SqlCommand command2 = new SqlCommand(query1, conn);
                command2.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Information Saved");
                BindData();
            } else
            {
                MessageBox.Show("Both field needs");
            }
        }

        private void button4Update_Click(object sender, EventArgs e) //update data
        {
            string query4 = "update tbl_block set block='"+comboBox2.Text+"',updatetime='"+DateTime.Now+"' where id='"+block_id+"'";
            conn.Open();
            SqlCommand command5 = new SqlCommand(query4, conn);
            command5.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Information updated");
            BindData();
        }

        private void button3Delete_Click(object sender, EventArgs e) //delete data
        {
            conn.Open();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewRow delData = dataGridView1.Rows[i];
                if(delData.Selected == true)
                {
                    SqlCommand command5 = new SqlCommand("delete from tbl_block where id = '" + dataGridView1.Rows[i].Cells[0].Value + "'",conn);
                    command5.ExecuteNonQuery();
                    MessageBox.Show("Data deleted");
                }
            }
            conn.Close();
            BindData();
        }

        public void BindData()
        {
            string query = "select * from tbl_block order by block asc";
            conn.Open();
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataAdapter sda = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            conn.Close();
            dataGridView1.DataSource = dt;
        }
        
        public int block_id;
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            conn.Open();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewRow selData = dataGridView1.Rows[i];
                if(selData.Selected == true)
                {
                    SqlCommand command4 = new SqlCommand("select * from tbl_block where id = '"+dataGridView1.Rows[i].Cells[0].Value+"'", conn);
                    SqlDataReader reader2 = command4.ExecuteReader();
                    while (reader2.Read())
                    {
                        block_id = int.Parse(reader2["id"].ToString());                       
                        string bName = reader2["block"].ToString();
                        comboBox2.Text = bName;
                    }
                }
            }
            conn.Close();
        }
    }
}
