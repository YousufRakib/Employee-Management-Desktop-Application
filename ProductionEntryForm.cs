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
    public partial class ProductionEntryForm : Form
    {
        public ProductionEntryForm()
        {
            InitializeComponent();
            BindData();
            StyleProcessLoads();
        }

        
        //SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-D829SPB\SQLEXPRESS;Initial Catalog=bestwooldb;Integrated Security=True");
        SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-NUPR82VN;Integrated Security=True;Initial Catalog=bestwooldb");
        //SqlConnection conn = new SqlConnection(@"Data Source=192.168.1.101,1433;Initial Catalog=bestwooldb;Integrated Security=True");


        public int readerID;
        private void button1_Click(object sender, EventArgs e) // INSERT BUTTON
        {
            
            string cardno = textBox1Cardno.Text;
            string style = comboBox1.Text;
            string process = comboBox2.Text;
            string quantity = textBox2Quantity.Text;
            string emp_name = textBox1EmpName.Text;
            string department = textBox1Department.Text;
            string section = textBox4Section.Text;
            string block = textBox5Block.Text;            

            if (IsValid())
            {
                conn.Open();
                string query = "INSERT INTO [dbo].[tbl_production_info]([prod_date],[department],[section],[block],[cardno],[emp_name],[style],[process],[quantity],[createdtime]) VALUES('" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "','"+department+"','"+section+"','"+block+"', '" + cardno.ToUpper() + "','"+emp_name+"', '" + style + "','" + process + "','" + double.Parse(quantity) + "','"+ DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                SqlCommand insertCommand = new SqlCommand(query,conn);
                insertCommand.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Information saved", "Saved");
                ClearData();
                BindData();                
            }
        }

        private void ProductionEntryForm_Load(object sender, EventArgs e)
        {
            
        }
        

        private void button4_Click(object sender, EventArgs e) // delete data
        {            
            conn.Open();
            for(int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewRow delRow = dataGridView1.Rows[i];

                if(delRow.Selected == true)
                {                    
                    string query1 = "DELETE FROM tbl_production_info where id = '"+ dataGridView1.Rows[i].Cells[0].Value +"'";
                    SqlCommand command2 = new SqlCommand(query1, conn);
                    command2.ExecuteNonQuery();
                    dataGridView1.Rows.RemoveAt(i);
                    MessageBox.Show("Record deleted.","Information");                    
                }
            }
            conn.Close();
            BindData();
        }

        
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            conn.Open();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewRow delRow = dataGridView1.Rows[i];
                if (delRow.Selected == true)
                {                    
                    string query1 = "select * FROM tbl_production_info where id = '" + dataGridView1.Rows[i].Cells[0].Value + "'";
                    SqlCommand command2 = new SqlCommand(query1, conn);
                    SqlDataReader reader = command2.ExecuteReader();
                    while (reader.Read())
                    {
                        readerID = int.Parse(reader["id"].ToString());
                        textBox1Cardno.Text = reader["cardno"].ToString();
                        comboBox1.Text = reader["style"].ToString();
                        comboBox2.Text = reader["process"].ToString();
                        textBox2Quantity.Text = reader["quantity"].ToString();
                        textBox1Department.Text = reader["department"].ToString();
                        textBox4Section.Text = reader["section"].ToString();
                        textBox5Block.Text = reader["block"].ToString();
                        textBox1EmpName.Text = reader["emp_name"].ToString();
                    }
                    MessageBox.Show("Row selected. Change and update information", "Information Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            conn.Close();
        }
        private void button3_Click(object sender, EventArgs e) // update button
        {
            conn.Open();
            string query1 = "update tbl_production_info set prod_date='"+dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss") +"',cardno='"+textBox1Cardno.Text.ToUpper()+"',style='"+comboBox1.Text+"',process='"+comboBox2.Text+"',quantity='"+int.Parse(textBox2Quantity.Text)+"',updatetime='"+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+"' where id = '" + readerID + "'";
            SqlCommand command3 = new SqlCommand(query1, conn);
            command3.ExecuteNonQuery();            
            conn.Close();
            MessageBox.Show("Information updated successfully.", "Information Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearData();
            BindData();
        }

        public bool IsValid()
        {
            if (textBox1Cardno.Text == string.Empty)
            {
                MessageBox.Show("Invalid Cardno", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            } else if (comboBox1.Text == string.Empty)
            {
                MessageBox.Show("Invalid Style No", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            } else if (comboBox2.Text == string.Empty)
            {
                MessageBox.Show("Invalid Process Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            } else if (textBox2Quantity.Text == string.Empty)
            {
                MessageBox.Show("Invalid Quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (textBox1Department.Text == string.Empty)
            {
                MessageBox.Show("Invalid Department", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (textBox4Section.Text == string.Empty)
            {
                MessageBox.Show("Invalid Section", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (textBox1EmpName.Text == string.Empty)
            {
                MessageBox.Show("Invalid Employee Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (textBox5Block.Text == string.Empty)
            {
                MessageBox.Show("Invalid Block", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        void BindData()
        {
            conn.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM TBL_PRODUCTION_INFO", conn);
            SqlDataAdapter sd = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            conn.Close();
            dataGridView1.DataSource = dt;
        }

        void ClearData()
        {
            textBox1Cardno.Clear();
            textBox2Quantity.Clear(); 
            textBox1EmpName.Clear();
            textBox1Department.Clear();
            textBox4Section.Clear();
            textBox5Block.Clear();
            textBox3Designation.Clear();
            comboBox1.Text = "";
            comboBox2.Text = "";
            dateTimePicker1.ResetText();
        }

        public void StyleProcessLoads()
        {
            conn.Open();
            string query = "select * from tbl_style_info";
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                string cName = dr["style"].ToString();
                comboBox1.Items.Add(cName);
                string pName = dr["process"].ToString();
                comboBox2.Items.Add(pName);
            }
            conn.Close();
        }

        private void textBox1Cardno_Leave(object sender, EventArgs e)
        {
            string cardno = textBox1Cardno.Text.ToUpper();
            conn.Open();
            string query5 = "select * from tbl_employee_info where cardno = '"+cardno+"'";
            SqlCommand command5 = new SqlCommand(query5, conn);
            SqlDataReader reader = command5.ExecuteReader();
            if (reader.Read() == true)
            {                
                textBox1EmpName.Text = reader["emp_name"].ToString();
                textBox4Section.Text = reader["section"].ToString();
                textBox5Block.Text = reader["block"].ToString();
                textBox3Designation.Text = reader["designation"].ToString();
                textBox1Department.Text = reader["department"].ToString();             
            } else
            {
                MessageBox.Show("Invalid cardno");                
            }
            conn.Close();
        }

    }
}
