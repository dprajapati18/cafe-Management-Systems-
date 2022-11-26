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
namespace Cafe_Management_System
{
    public partial class UsersForm : Form
    {
        public UsersForm()
        {
            InitializeComponent();
        }
        SqlConnection con=new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\DHEERAJ PRAJAPATI\Dropbox\PC\Documents\Cafedb.mdf';Integrated Security=True");
        void populate()
        {
            con.Open();
            string query = "select from UserTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            UsersGV.DataSource = ds.Tables[0];
            con.Close();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "insert into UsersTbl values('" + UnameTb.Text + "','" + UphoneTb.Text + "','" + UpasswordTb.Text + "')";
            SqlCommand cmd = new SqlCommand(query,con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("user Successfully Created");
            con.Close();
            populate();
        }
        private void UsersForm_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(UphoneTb.Text =="")
            {
                MessageBox.Show("Select The Users to be Deleted");
            }
            else
            {
                con.Open();
                string query = "delete from the UsersTbl where Uphone ='" + UphoneTb.Text + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Users Successfull Deleted");
                con.Close();
                populate(); 
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (UphoneTb.Text ==""|| UpasswordTb.Text==""|| UnameTb.Text=="")
            {
                MessageBox.Show("Fill all The Fields");

            }
            else
            {
                con.Open();
                string query = "update UsersTbl set Uname='"+UnameTb.Text+"',Upassword='"+UpasswordTb.Text+"'where Uphone='"+UphoneTb+"'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("users Successfully Updated");
                con.Close();
                populate();
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ItemsForm item = new ItemsForm();
            item.Show();
            this.Hide();
        }

        private void UsersGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            UnameTb.Text = UsersGV.SelectedRows[0].Cells[0].Value.ToString();
            UphoneTb.Text= UsersGV.SelectedRows[0].Cells[1].Value.ToString();
            UpasswordTb.Text= UsersGV.SelectedRows[0].Cells[2].Value.ToString();
        }
    }
}
