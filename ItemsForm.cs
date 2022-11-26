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
    public partial class ItemsForm : Form
    {
        public ItemsForm()
        {
            InitializeComponent();
        }
        //String constr = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename="C: \Users\DHEERAJ PRAJAPATI\Dropbox\PC\Documents\Cafedb.mdf";Integrated Security = True;
        //SqlConnection con = new SqlConnection(constr);
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C: \Users\DHEERAJ PRAJAPATI\Dropbox\PC\Documents\Cafedb.mdf';Integrated Security=True");
        void populate()
        {
            con.Open();
            string query = "select from ItemTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ItemGV.DataSource = ds.Tables[0];
            con.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            userOrder order = new userOrder();
            order.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ItemsNametb.Text == "" || ItemNumTb.Text == "" || PriceCb.Text == "")
            {
                MessageBox.Show("Fill all the data");
            }
            else
            {


                con.Open();
                string query = "insert ItemTbl set ItemName ='" + ItemNumTb.Text + "',Item'" + ItemsNametb.Text + "',Itemcat='" + CatCb.SelectedItem.ToString() + "'where Itemprice='" + PriceCb.Text + ")";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Item Successfully Created");
                con.Close();
                populate();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void ItemsForm_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void ItemGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ItemNumTb.Text = ItemGV.SelectedRows[0].Cells[0].Value.ToString();
            ItemsNametb.Text = ItemGV.SelectedRows[0].Cells[1].Value.ToString();
            CatCb.SelectedItem = ItemGV.SelectedRows[0].Cells[2].Value.ToString();
            PriceCb.Text = ItemGV.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (ItemNumTb.Text == "")
            {
                MessageBox.Show("Fill all The Fields");

            }
            else
            {
                con.Open();
                string query = "delete from ItemTbl where ItemNum ='" + ItemNumTb.Text + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Items Successfully deleted");
                con.Close();
                populate();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (ItemNumTb.Text == "" || ItemsNametb.Text == "" || PriceCb.Text == "")
            {
                MessageBox.Show("Fill all The Fields");

            }
            else
            {
                con.Open();
                string query = "update ItemTbl set ItemName='" + ItemsNametb.Text + "',Itemcat='" + CatCb.SelectedItem.ToString() + "'where ItemPrice='" + PriceCb.Text + "";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Item Successfully Updated");
                con.Close();
                populate();
            }
        }
    }
}
    