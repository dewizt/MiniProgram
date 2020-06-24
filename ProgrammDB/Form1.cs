using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ProgrammDB
{
    public partial class Form1 : Form
    {
        Thread[] thread = new Thread[5];
        public Form1()
        {
            InitializeComponent();
        }

        void label2_Click(object sender, EventArgs e)
        {

        }

        void label3_Click(object sender, EventArgs e)
        {

        }

        void button1_Click(object sender, EventArgs e) // Демонстрирует данные
        {
            Added();
        }

        void label4_Click(object sender, EventArgs e)
        {
            
        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        void button2_Click(object sender, EventArgs e)
        {
            Reverse();
        }

        void Reverse()
        {
            thread[1] = new Thread(() =>
            {
                listBox3.Items.Clear();
                string connectionStr = "server=localhost;port=3306;user=root;password=root;database=dewizt_db;";

                MySqlConnection conn = new MySqlConnection(connectionStr);

                conn.Open();

                string sql = "SELECT * FROM users";

                MySqlCommand command = new MySqlCommand(sql, conn);

                //string id = command.ExecuteScalar().ToString();

                MySqlDataReader read = command.ExecuteReader();

                while (read.Read())
                {
                    string status = read[2].ToString();
                    if (status == "1")
                    {
                        listBox3.Items.Add("0");
                    }
                    if (status == "0")
                    {
                        listBox3.Items.Add("1");
                    }
                }
                read.Close();
                conn.Close();
            });
            thread[1].Start();
        }
        void Added()
        {
            thread[0] = new Thread(() =>
            {
                string connectionStr = "server=localhost;port=3306;user=root;password=root;database=dewizt_db;";

                MySqlConnection conn = new MySqlConnection(connectionStr);

                conn.Open();

                string sql = "SELECT * FROM users";

                MySqlCommand command = new MySqlCommand(sql, conn);

                //string id = command.ExecuteScalar().ToString();

                MySqlDataReader read = command.ExecuteReader();

                while (read.Read())
                {
                    listBox1.Items.Add(read[0].ToString());
                    listBox2.Items.Add(read[1].ToString());
                    listBox3.Items.Add(read[2].ToString());
                }
                read.Close();
                conn.Close();
            });
            thread[0].Start();
        }

        void button3_Click(object sender, EventArgs e)
        {
            thread[2] = new Thread(() =>
            {
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                listBox3.Items.Clear();
                listBox4.Items.Clear();
            });
            thread[2].Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            thread[3] = new Thread(() =>
            {
                string connectionStr = "server=localhost;port=3306;user=root;password=root;database=dewizt_db;";

                MySqlConnection conn = new MySqlConnection(connectionStr);

                conn.Open();

                string sql = "SELECT * FROM users";

                MySqlCommand command = new MySqlCommand(sql, conn);

                //string id = command.ExecuteScalar().ToString();

                MySqlDataReader read = command.ExecuteReader();

                while (read.Read())
                {
                    string status = read[2].ToString();
                    string name = read[1].ToString();
                    if (status == "0")
                    {
                        status = "1";
                        listBox4.Items.Add("Статус " + name + "Изменился на " + status);
                    }
                    if (status == "1")
                    {
                        status = "0";
                        listBox4.Items.Add("Статус " + name + "Изменился на " + status);
                    }

                }
                read.Close();
                conn.Close();
            });
            thread[3].Start();
        }
    }
}
