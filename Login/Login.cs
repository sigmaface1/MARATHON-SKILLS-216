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
using System.IO;
using Practica_new.Properties;
using Practica_new.ConnectionDb;


namespace Practica_new
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Main Main = new Main();
            Main.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Main Main = new Main();
            Main.Show();
            this.Hide();
        }

        private void time_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan time1;
            DateTime initial_time = Convert.ToDateTime("21.10.2017 6:00");
            DateTime current_time = DateTime.Now;
            time1 = initial_time - current_time;
            time.Text = time1.Days.ToString() + " дней " + time1.Hours.ToString() + " часов и " + time1.Minutes.ToString() + " минут до старта марафона!";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int login = 0;
            //  string role = "";

            ConnectionDB connection = new ConnectionDB();
            string sql = $"SELECT * FROM [User] WHERE Email='{textBox1.Text}'AND Password = '{textBox2.Text}'";
            DataTable dataTable = null;
            connection.SqlSelecct(sql, out dataTable);
            int role = 0;

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                string id = Convert.ToString(dataTable.Rows[i][0]);
                role = Convert.ToInt32(dataTable.Rows[i][4]);
            }
            switch (role)
            {
                case 1:
                    Admin Admin = new Admin();
                    Admin.Show();
                    this.Hide();
                    break;
                case 2:
                    Runner Runner = new Runner();
                    Runner.Show();
                    this.Hide();
                    break;
                case 3:
                    Coordinator Coordinator = new Coordinator();
                    Coordinator.Show();
                    this.Hide();
                    break;

                default:
                    MessageBox.Show("Пользователь не найден");
                    break;
            }
           
        }
    }
}
