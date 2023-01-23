using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Admin_panel
{
    public partial class Form1 : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;Initial Catalog='smarthome';username=root;password=");

        MySqlDataAdapter adapter;

        DataTable table = new DataTable();
        public Form1()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            DialogResult dialogClose = MessageBox.Show("Voulez vous vraiment fermer l'application ?", "Quitter le programme", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogClose == DialogResult.OK)
            {
                Application.Exit();
            }
            else if (dialogClose == DialogResult.Cancel)
            {
                //do something else
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            adapter = new MySqlDataAdapter("SELECT `login`, `mdp` FROM `admin` WHERE `login` = '" + textBox1.Text + "' AND `mdp` = '" + textBox2.Text + "'", connection);
            adapter.Fill(table);

            if (table.Rows.Count <= 0)
            {
                MessageBox.Show("Username Or Password Are Invalid");
                textBox1.Clear();
                textBox2.Clear();
            }
            else
            {
                table.Clear();
                dashboard a = new dashboard();
                this.Hide();
                a.Show();



            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
