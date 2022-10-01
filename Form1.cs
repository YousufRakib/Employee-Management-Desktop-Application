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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        //SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-D829SPB\SQLEXPRESS;Initial Catalog=bestwooldb;Integrated Security=True");
        SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-NUPR82VN;Integrated Security=True;Initial Catalog=bestwooldb;");
        //SqlConnection conn = new SqlConnection(@"Data Source=192.168.1.101,1433;Initial Catalog=bestwooldb;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string pass = textBox2.Text;
            if(name == "" && pass == "")
            {
                MessageBox.Show("Empty Username");
            } else
            {
                conn.Open();
                string query = "select * from tbl_users where username = '" + name + "' and password = '" + pass + "'";
                SqlCommand command = new SqlCommand(query, conn);
                SqlDataReader reader = command.ExecuteReader();                  
                if (reader.Read())
                {
                    if(reader["role"].ToString() == "Admin")
                    {
                        this.Hide();
                        HomeScreen1 hs = new HomeScreen1();
                        hs.Show();
                    } else if(reader["role"].ToString() == "Operator")
                    {
                        this.Hide();
                        HomeScreen2Op hs2 = new HomeScreen2Op();
                        hs2.Show();
                    } else
                    {
                        MessageBox.Show("Invalid Information Provided","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                    
                }
                else
                {
                    MessageBox.Show("No Data Found in Reader");
                }
                conn.Close();
                //conn.Open();
                //string query = "select * from tbl_users where username = '" + name + "' and password = '" + pass + "'";
                //SqlCommand command = new SqlCommand(query, conn);
                //SqlDataAdapter sd = new SqlDataAdapter(command);
                //DataTable dt = new DataTable();
                //sd.Fill(dt);
                //conn.Close();
                //if(dt.Rows.Count > 0)
                //{
                //    this.Hide();
                //    HomeScreen1 hs = new HomeScreen1();
                //    hs.Show();
                //}
                //else
                //{
                //    MessageBox.Show("Invalid Login details.");
                //}
            }
            
        }

        private void Form1_Enter(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
