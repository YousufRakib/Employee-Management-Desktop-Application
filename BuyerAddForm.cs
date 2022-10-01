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
    public partial class BuyerAddForm : Form
    {
        public BuyerAddForm()
        {
            InitializeComponent();
        }

        private void BuyerAddForm_Load(object sender, EventArgs e)
        {
            BindData();
        }

        
        //SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-D829SPB\SQLEXPRESS;Initial Catalog=bestwooldb;Integrated Security=True");
        SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-NUPR82VN;Initial Catalog=bestwooldb;Integrated Security=True");
        //SqlConnection conn = new SqlConnection(@"Data Source=192.168.1.101,1433;Initial Catalog=bestwooldb;Integrated Security=True");
        void BindData()
        {
            SqlCommand command = new SqlCommand("select buyer,country,phone,email,address from tbl_buyer_info",conn);
            SqlDataAdapter sd = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
            
        }
        void BoxClear()
        {
            textBox1Buyer.Clear();
            textBox2Country.Clear();
            textBox3Phone.Clear();
            textBox4Email.Clear();
            textBox5Address.Clear();
        }
        private void button1_Click(object sender, EventArgs e) // insert button
        {
            string buyerName = textBox1Buyer.Text;
            string country = textBox2Country.Text;
            string phone = textBox3Phone.Text;
            string email = textBox4Email.Text;
            string address = textBox5Address.Text;
            if(buyerName == string.Empty)
            {
                MessageBox.Show("Invalid buyer name");
            } else
            {
                if (country == string.Empty)
                {
                    MessageBox.Show("Invalid country name");
                } else
                {
                    if (phone == string.Empty)
                    {
                        MessageBox.Show("Invalid phone number");
                    } else
                    {
                        if (email == string.Empty)
                        {
                            MessageBox.Show("Invalid email");
                        } else
                        {
                            if (address == string.Empty)
                            {
                                MessageBox.Show("Invalid address");
                            } else
                            {
                                conn.Open();
                                string InsertQuery = "INSERT INTO[dbo].[tbl_buyer_info]([buyer],[country],[phone],[email],[address]) VALUES('" + buyerName + "', '" + country + "', '" + phone + "', '" + email + "', '" + address + "')";
                                SqlCommand command = new SqlCommand(InsertQuery, conn);
                                command.ExecuteNonQuery();
                                conn.Close();
                                MessageBox.Show("Saved","",MessageBoxButtons.YesNo);
                                BoxClear();
                                BindData();
                            }
                        }
                    }
                }
            }           
        }

        private void button2_Click(object sender, EventArgs e) // edit button
        {
            string buyer = textBox1Buyer.Text;
            if (buyer == "")
            {
                MessageBox.Show("Ëmpty buyer name");
            }
            else
            {
                conn.Open();
                string query = "SELECT * FROM TBL_BUYER_INFO WHERE buyer = '" + buyer + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();                
                if (reader.Read())
                {
                    textBox2Country.Text = reader["country"].ToString();
                    textBox3Phone.Text = reader["phone"].ToString();
                    textBox4Email.Text = reader["email"].ToString();
                    textBox5Address.Text = reader["address"].ToString();
                }
                conn.Close();
            }
        }

        private void button4Update_Click(object sender, EventArgs e) // update button
        {
            string buyerName = textBox1Buyer.Text;
            string country = textBox2Country.Text;
            string phone = textBox3Phone.Text;
            string email = textBox4Email.Text;
            string address = textBox5Address.Text;

            conn.Open();
            string query2 = "UPDATE [dbo].[tbl_buyer_info] SET buyer='" + buyerName + "', country='" + country + "',phone='" + phone + "',email='" + email + "',address='" + address + "' WHERE BUYER = '"+buyerName+"'";
            SqlCommand command2 = new SqlCommand(query2, conn);
            command2.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Inforamtion updated success.");
            BindData();
            BoxClear();            
        }
    }
}
