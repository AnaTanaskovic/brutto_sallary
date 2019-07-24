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

namespace Neto_Payment
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Decimal BruttoSallary = 0;
            Decimal BruttoSub = 1.530M;
            Decimal divisor = 0.701M;
            SqlConnection con= new SqlConnection("Data Source=DESKTOP-93M9EQQ\\SQLEXPRESS; Initial Catalog=bruto_db; Integrated Security=true");
            con.Open();

            BruttoSallary = Decimal.Subtract(System.Convert.ToDecimal(txtNeto.Text), BruttoSub);
            BruttoSallary = Decimal.Divide(BruttoSallary, divisor);
            BruttoSallary = Math.Round(BruttoSallary, 2);
            SqlCommand cmd = new SqlCommand("insert into Payments(FirstName, LastName, Address, NetSallary, BruttoSallary) values ('" + txtName.Text + "' , '" + txtLastName.Text + "', '" + txtAddress.Text + "', '" + txtNeto.Text + "' , '" + BruttoSallary + "') ", con);
       
            int i = cmd.ExecuteNonQuery();
            if (i!=0) {
                
            MessageBox.Show(""+BruttoSallary+"");
            } else
            {
                MessageBox.Show("error");
            }


            con.Close();

        }
    }
}

        
    
