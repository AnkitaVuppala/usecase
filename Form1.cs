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


namespace Banktransaction
{
    public partial class Form1 : Form
    {
        string minbal;
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=ANKITA;Initial Catalog=bank;Integrated Security=True");
            con.Open();
            SqlCommand cmd1 = new SqlCommand("SELECT Balance FROM    Data_details WHERE  Balance= (SELECT MIN(Balance)  FROM Data_details); ", con);
            minbal = (string)cmd1.ExecuteScalar();
            int bal = int.Parse(minbal);
            bal = bal - int.Parse(textBox3.Text);
            string sql = "insert into Data_details(Acc_id,Acc_name,Amount,Balance) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + bal + "')";
            SqlCommand cmd = new SqlCommand(sql, con);
            int i = cmd.ExecuteNonQuery();
            if (i != 0)
            {
                MessageBox.Show("Transferred Successfully....Avl bal: " + bal);
            }
            else
            {
                MessageBox.Show("Error");
            }
            cmd.Dispose();
            con.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 s = new Form2();
            s.Show();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
