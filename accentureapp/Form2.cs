using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace accentureapp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string myconnection = "datasource=localhost;port=3306;username=root;password=vitcse";
                MySqlConnection myconn = new MySqlConnection(myconnection);
                MySqlCommand SelectCommand = new MySqlCommand("select * from acc.login where name='" + this.textBox1.Text + "' and password='" + this.textBox2.Text + "';", myconn);
                MySqlDataReader myreader;
                myconn.Open();
                myreader = SelectCommand.ExecuteReader();
                int count = 0;
                while (myreader.Read())
                {
                    count = count + 1;
                }
                if (count == 1)
                {

                    this.Hide();
                    Form3 f2 = new Form3();
                    f2.ShowDialog();
                }
                else if (count > 1)
                {

                    MessageBox.Show("Access denied");
                }
                else
                    MessageBox.Show("Incorrect");
                myconn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       
    }
}
