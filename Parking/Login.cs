using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parking
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(UNameTb.Text == "" || PasswordTb.Text == "")
            {
                MessageBox.Show("Wprowadż dane");
            }
            else
            {
                if(UNameTb.Text == "Admin" || PasswordTb.Text == "Qwerty1@3")
                {
                    Cars Obj = new Cars();
                    Obj.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Nieprawidłowe dane użytkownika");
                    UNameTb.Text = "";
                    PasswordTb.Text = "";
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void PasswordTb_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
