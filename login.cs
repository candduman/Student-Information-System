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

namespace kayit_programi
{
    public partial class login : Form
    {
        string username = ""; 
        string usertpye;
        public bool adminaut { get;  set; }
        public SqlConnection conn = new SqlConnection(@"Data Source=CAN\SQLEXPRESS;Initial Catalog=University_OBS;Integrated Security=True");
        Form1 f1 = new Form1();
        public login()
        {
            InitializeComponent();            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand("SELECT * FROM login where usr='"+textBox1.Text+"' AND password='"+textBox2.Text+"'",conn);
            
            dr = cmd.ExecuteReader();
                if (dr.Read())
                {   
                    username = dr["usr"].ToString();
                    usertpye = dr["usertype"].ToString();
                    if (usertpye == "admin")
                    {
                    f1.button30.Visible = true;

                    }
                    else
                    {
                    f1.button30.Visible = false;
                    }
                f1.Show();
                    this.Hide();

                }
                else
                {
                    textBox1.Clear();
                    textBox2.Clear();
                    MessageBox.Show("Wrong password or username!");
                    textBox1.Focus();


                }
            conn.Close();
            f1.label44.Text = "Logged as = '" + username.ToString() + "'";


        }

        private void login_Load(object sender, EventArgs e)
        {
            
        }
    }
}
