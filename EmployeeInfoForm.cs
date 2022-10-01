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
    public partial class EmployeeInfoForm : Form
    {
        public EmployeeInfoForm()
        {
            InitializeComponent();
            LoadDept();
            Loadsec();
            LoadBlock();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void textBox22_TextChanged(object sender, EventArgs e)
        {
            
        }

        //SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-D829SPB\SQLEXPRESS;Initial Catalog=bestwooldb;Integrated Security=True");
        SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-NUPR82VN;Initial Catalog=bestwooldb;Integrated Security=True");
        //SqlConnection conn = new SqlConnection(@"Data Source=192.168.1.101,1433;Initial Catalog=bestwooldb;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e) // insert button
        {
            string active = "Active";
            if (textBox1Cardno.Text != string.Empty && comboBox1Department.Text != string.Empty && comboBox2section.Text != string.Empty && comboBox4Block.Text != string.Empty && comboBox5Shift.Text != string.Empty && comboHoliday.Text != string.Empty && textBox7EmpName.Text != string.Empty && textBox8FatherName.Text != string.Empty && textBox9MotherName.Text != string.Empty && textBox10Spouse.Text != string.Empty && textBox11Present.Text != string.Empty && textBox12Permanent.Text != string.Empty && textBox13NID.Text != string.Empty && textBox16Birth.Text != string.Empty && comboBox1Gender.Text != string.Empty && comboBox2Marital.Text != string.Empty && comboBox3Religion.Text != string.Empty && textBox21Mobile.Text != string.Empty && textBox1Cardno.Text != string.Empty && textBox24Gross.Text != string.Empty && designationTextBox.Text != string.Empty)
            {
                conn.Open();
                string query = "INSERT INTO [dbo].[TBL_EMPLOYEE_INFO] ([CARDNO],[ACTIVE_STATUS],[DEPARTMENT],[SECTION],[BLOCK] ,[SHIFT],[HOLIDAY],[EMP_NAME],[FATHER_NAME],[MOTHER_NAME],[SPOUSE_NAME],[PRESENT_ADDRESS],[PERMANENT_ADDRESS],[NID],[BIRTH_CERTIFICATE],[JOINING_DATE],[BIRTH_DATE],[GENDER],[MARITAL_STATUS],[RELIGION],[MOBILE],[BANK_NAME],[BANK_AC],[GROSS_SALARY],[CREATED_DATE],[DESIGNATION]) " +
                    "VALUES ('" + textBox1Cardno.Text.ToUpper() + "','" + active + "','" + comboBox1Department.Text + "','" + comboBox2section.Text + "','" + comboBox4Block.Text + "','" + comboBox5Shift.Text + "','" + comboHoliday.Text + "','" + textBox7EmpName.Text + "','" + textBox8FatherName.Text + "','" + textBox9MotherName.Text + "','" + textBox10Spouse.Text + "','" + textBox11Present.Text + "','" + textBox12Permanent.Text + "','" + textBox13NID.Text + "','" + textBox16Birth.Text + "','" + dateTimePicker1.Text + "','" + dateTimePicker2.Text + "','" + comboBox1Gender.Text + "','" + comboBox2Marital.Text + "','" + comboBox3Religion.Text + "','" + textBox21Mobile.Text + "','" + textBox22BankName.Text + "','" + textBox23BankAC.Text + "','" + int.Parse(textBox24Gross.Text) + "','" + DateTime.Now + "','"+designationTextBox.Text+"')";
                SqlCommand command = new SqlCommand(query, conn);
                command.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Employee Information Saved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1Cardno.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e) // edit button
        {
            string cardno = textBox1Cardno.Text.ToUpper();
            if(cardno == string.Empty)
            {
                MessageBox.Show("Empty Cardno.", "Information needed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                conn.Open();
                string query1 = "select * from tbl_employee_info where cardno = '" + cardno + "'";
                SqlCommand command2 = new SqlCommand(query1, conn);
                SqlDataReader reader = command2.ExecuteReader();               
                if (reader.Read())
                {
                    textBox15Active.Text = reader["active_status"].ToString();
                    comboBox1Department.Text = reader["department"].ToString();
                    comboBox2section.Text = reader["section"].ToString();
                    comboBox4Block.Text = reader["block"].ToString();
                    comboBox5Shift.Text = reader["shift"].ToString();
                    comboHoliday.Text = reader["holiday"].ToString();
                    textBox7EmpName.Text = reader["emp_name"].ToString();
                    textBox8FatherName.Text = reader["father_name"].ToString();
                    textBox9MotherName.Text = reader["mother_name"].ToString();
                    textBox10Spouse.Text = reader["spouse_name"].ToString();
                    textBox11Present.Text = reader["present_address"].ToString();
                    textBox12Permanent.Text = reader["permanent_address"].ToString();
                    textBox13NID.Text = reader["NID"].ToString();
                    textBox16Birth.Text = reader["birth_certificate"].ToString();
                    dateTimePicker1.Text = reader["joining_date"].ToString();
                    dateTimePicker2.Text = reader["birth_date"].ToString();
                    comboBox1Gender.Text = reader["gender"].ToString();
                    comboBox2Marital.Text = reader["marital_status"].ToString();
                    comboBox3Religion.Text = reader["religion"].ToString();
                    textBox21Mobile.Text = reader["mobile"].ToString();
                    textBox22BankName.Text = reader["bank_name"].ToString();
                    textBox23BankAC.Text = reader["bank_ac"].ToString();
                    textBox24Gross.Text = reader["gross_salary"].ToString();
                    designationTextBox.Text = reader["designation"].ToString();
                }
                conn.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e) // delete button
        {
            string cardno = textBox1Cardno.Text.ToUpper();
            if (cardno == string.Empty)
            {
                MessageBox.Show("Empty Cardno.", "Information needed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                conn.Open();
                string query2 = "delete from tbl_employee_info where cardno = '" + cardno + "'";
                SqlCommand command3 = new SqlCommand(query2, conn);
                command3.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Employee Information Successfully Deleted.", "Employee Deleted", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1Cardno.Focus();
            }
        }

        private void EmployeeInfoForm_Load(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }       

        private void textBox24Gross_Leave(object sender, EventArgs e)
        {
            double gross = int.Parse(textBox24Gross.Text);
            if (gross == 0)
            {
                MessageBox.Show("Salary must be greater than 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                double basic = ((gross - 1850) / 1.5);
                int conv = 1850;
                double houseRent = (basic * 50 / 100);
                textBox25Basic.Text = basic.ToString();
                textBox26HouseRent.Text = houseRent.ToString();
                textBox27Conv.Text = conv.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e) // udpate BUTTON
        {
            
            if (textBox1Cardno.Text != string.Empty)
            {
                conn.Open();
                string query3 = "UPDATE [dbo].[TBL_EMPLOYEE_INFO] SET[CARDNO] = '" + textBox1Cardno.Text.ToUpper() + "', [DEPARTMENT] = '" + comboBox1Department.Text + "',[SECTION] = '" + comboBox2section.Text + "',[BLOCK] = '" + comboBox4Block.Text + "' ,[SHIFT] = '" + comboBox5Shift.Text + "',[HOLIDAY] = '" + comboHoliday.Text + "' ,[EMP_NAME] = '" + textBox7EmpName.Text + "',[FATHER_NAME] = '" + textBox8FatherName.Text + "',[MOTHER_NAME] = '" + textBox9MotherName.Text + "',[SPOUSE_NAME] = '" + textBox10Spouse.Text + "',[PRESENT_ADDRESS] = '" + textBox11Present.Text + "',[PERMANENT_ADDRESS] = '" + textBox12Permanent.Text + "',[NID] = '" + textBox13NID.Text + "',[BIRTH_CERTIFICATE] = '" + textBox16Birth.Text + "',[JOINING_DATE] = '" + dateTimePicker1.Text + "',[BIRTH_DATE] = '" + dateTimePicker2.Text + "',[GENDER] = '" + comboBox1Gender.Text + "'     ,[MARITAL_STATUS] = '" + comboBox2Marital.Text + "' ,[RELIGION] = '" + comboBox3Religion.Text + "',[MOBILE] = '" + textBox21Mobile.Text + "'     ,[BANK_NAME] = '" + textBox22BankName.Text + "' ,[BANK_AC] = '" + textBox23BankAC.Text + "',[GROSS_SALARY] = '" + int.Parse(textBox24Gross.Text) + "',[CREATED_DATE] = '" + DateTime.Now + "' WHERE cardno = '" + textBox1Cardno.Text.ToUpper() + "'";
                SqlCommand command4 = new SqlCommand(query3, conn);
                command4.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Information Update Successful", "Update Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1Cardno.Focus();
            } else
            {
                MessageBox.Show("All information needed", "Information Blanks", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }


        public void LoadDept()
        {
            conn.Open();
            string query = "select * from tbl_department";
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox1Department.Items.Add(reader["department"].ToString());
            }            
            conn.Close();            
        }
        public void Loadsec()
        {
            conn.Open();
            string query2 = "select * from tbl_section";
            SqlCommand command2 = new SqlCommand(query2, conn);
            SqlDataReader reader2 = command2.ExecuteReader();
            while (reader2.Read())
            {
                comboBox2section.Items.Add(reader2["section"].ToString());
            }
            conn.Close();            
        }
        public void LoadBlock()
        {
            conn.Open();
            string query3 = "select * from tbl_block";
            SqlCommand command3 = new SqlCommand(query3, conn);
            SqlDataReader reader3 = command3.ExecuteReader();
            while (reader3.Read())
            {
                comboBox4Block.Items.Add(reader3["block"].ToString());
            }
            conn.Close();
        }
        public void ClearData()
        {
            textBox1Cardno.Clear();
            textBox15Active.Clear();
            comboBox1Department.Text = "";
            comboBox2section.Text = "";
            comboBox4Block.Text = "";
            comboBox5Shift.Text = "";
            comboHoliday.Text = "";
            textBox7EmpName.Clear();
            textBox8FatherName.Clear();
            textBox9MotherName.Clear();
            textBox10Spouse.Clear();
            textBox11Present.Clear();
            textBox12Permanent.Clear();
            textBox13NID.Clear();
            textBox16Birth.Clear();
            comboBox1Gender.Text = "";
            comboBox2Marital.Text = "";
            comboBox3Religion.Text = "";
            textBox21Mobile.Clear();
            textBox22BankName.Clear();
            textBox23BankAC.Clear();
            textBox24Gross.Clear();
        }

        private void button5_Click(object sender, EventArgs e) //clear data
        {
            ClearData();
        }
    }
}
