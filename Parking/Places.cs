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
    public partial class Places : Form
    {
        public Places()
        {
            InitializeComponent();
            Con = new Functions();
            ShowPlaces();

            PlaceDGV.SelectionChanged += PlaceDGV_SelectionChanged;
        }
        Functions Con;
        private void ShowPlaces()
        {
            string Query = "select * from PlaceTb1";
            PlaceDGV.DataSource = Con.GetData(Query);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        int Key = 0;
        private void PlaceDGV_SelectionChanged(object sender, EventArgs e)
        {
            if (PlaceDGV.SelectedRows.Count > 0)
            {
                PositionTb.Text = PlaceDGV.SelectedRows[0].Cells[1].Value.ToString();
                Status.Text = PlaceDGV.SelectedRows[0].Cells[2].Value.ToString();

                Key = Convert.ToInt32(PlaceDGV.SelectedRows[0].Cells[0].Value); // Assign Key correctly
            }
            else
            {
                Key = 0; // Reset Key if no row is selected
            }
        }

        private void AddPlace_Click(object sender, EventArgs e)
        {
            if (PositionTb.Text == "" || Status.SelectedIndex == -1)
            {
                MessageBox.Show("Brak danych");
            }
            else
            {
                try
                {
                    string Position = PositionTb.Text;
                    string Stat = Status.SelectedItem.ToString();
                    string Query = "Insert into PlaceTb1 values ('{0}','{1}')";
                    Query = string.Format(Query, Position, Stat);
                    Con.SetData(Query);
                    MessageBox.Show("Miejsce parkingowe dodano pomyślnie");
                    ShowPlaces();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void DeletePlace_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Zaznacz miejsce");
            }
            else
            {
                try
                {
                    String Position = PositionTb.Text;
                    String Stat = Status.SelectedItem.ToString();
                    string Query = "delete from PlaceTb1 where PINum = {0}";
                    Query = string.Format(Query, Key);
                    Con.SetData(Query);
                    MessageBox.Show("Miejsce parkingowe usunięte");
                    ShowPlaces();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void PositionTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Form1 Obj = new Form1();
            Obj.Show();
            this.Hide();
        }

        private void PlaceDGV_SelectionChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Cars Obj = new Cars();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Places Obj = new Places();
            Obj.Show();
            this.Hide();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            Form1 Obj = new Form1();
            Obj.Show();
            this.Hide();
        }

        private void Login_Click_1(object sender, EventArgs e)
        {
            Form1 Obj = new Form1();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_Click_2(object sender, EventArgs e)
        {
            Form1 Obj = new Form1();
            Obj.Show();
            this.Hide();
        }
    }
}
