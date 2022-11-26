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
    public partial class userOrder : Form
    {
        public userOrder()
        {
            InitializeComponent();
        }
        SqlConnection Con= new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C: \Users\DHEERAJ PRAJAPATI\Dropbox\PC\Documents\Cafedb.mdf';Integrated Security=True");
        void populate()
        {
            Con.Open();
            string query = "select from ItemTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ItemGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.Show();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            ItemsForm Item = new ItemsForm();
            Item.Show();
              
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            UsersForm user = new UsersForm();
            user.Show();
        }
        int num = 0;
        int price, qty, total;
        String item, cat;

        private void button1_Click(object sender, EventArgs e)
        {
            if(QtyTb.Text == "")
            {
                MessageBox.Show("What is The Quantity of items?");
            }
            else if(flag==0)
            {
                MessageBox.Show("Select The Product to be Ordered");
            }
            else
            {
                num = num + 1;
                total = price * Convert.ToInt32(QtyTb.Text);
                table.Rows.Add(num, Item, cat, price, total);
                OrdersGV.DataSource = table;
                flag = 0;

            }
            sum = sum + total;
            labelAmnt.Text = "RS" + sum;
        }
        DataTable table = new DataTable();
        int flag = 0;

        private void label2_Click(object sender, EventArgs e)
        {

        }

        int sum = 0;

        private void userOrder_Load(object sender, EventArgs e)
        {
            populate();
            table.Columns.Add("Num", typeof(int));
            table.Columns.Add("Item", typeof(string));
            table.Columns.Add("Category", typeof(string));
            table.Columns.Add("UnitPrice", typeof(int));
            table.Columns.Add("Total", typeof(int));
            OrdersGV.DataSource = table;
        }

        private void ItemGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Name = ItemGV.SelectedRows[0].Cells[1].Value.ToString();  
            cat= ItemGV.SelectedRows[0].Cells[2].Value.ToString();
            price=Convert.ToInt32 (ItemGV.SelectedRows[0].Cells[3].Value.ToString());
            flag = 1;
        }
    }
}
