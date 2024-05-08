using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Parking
{
    public partial class Cars : Form
    {
        Functions Con;
        public Cars()
        {
            InitializeComponent();
            Con = new Functions();
            ShowCars();

            CarsDGV.SelectionChanged += CarsDGV_SelectionChanged;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Places Obj = new Places();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Cars Obj = new Cars();
            Obj.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void ShowCars()
        {
            string Query = "select * from CarsTb1";
            CarsDGV.DataSource = Con.GetData(Query);
        }

        /*private void EditBtn_Click(object sender, EventArgs e)
        {
            if (PNumberTb.Text == "" || DriverTb.Text == "" || CarType.Text == "" || ColorTb.Text == "")
            {
                MessageBox.Show("Brak danych");
            }
            else
            {
                try
                {
                    string PNumber = PNumberTb.Text;
                    string Driver = DriverTb.Text;
                    string Gen = GenCb.SelectedItem.ToString();
                    string Ctype = CarType.Text;
                    string Color = ColorTb.Text;

                    // Debug output to check the value of Key
                    MessageBox.Show("Key: " + Key.ToString());

                    // Use UPDATE statement to modify existing record
                    string Query = "UPDATE CarsTb1 SET PNumber = '{0}', Driver = '{1}', Gender = '{2}', CarType = '{3}', CarColor = '{4}' WHERE CNum = {5}";
                    Query = string.Format(Query, PNumber, Driver, Gen, Ctype, Color, Key);
                    Con.SetData(Query);

                    MessageBox.Show("Zaktualizowano samochód");
                    ShowCars();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }*/



        private void AddBtn_Click(object sender, EventArgs e)
        {
            if(PNumberTb.Text == "" || DriverTb.Text == "" || CarType.Text == "" || ColorTb.Text == "")
            {
                MessageBox.Show("Brak danych");
            }
            else
            {
                try
                {
                    string PNumber = PNumberTb.Text;
                    string Driver = DriverTb.Text;
                    string Gen = GenCb.SelectedItem.ToString();
                    string Ctype = CarType.Text;
                    string Color = ColorTb.Text;
                    string Query = "Insert into CarsTb1 values ('{0}','{1}','{2}', '{3}','{4}')";
                    Query = string.Format(Query, PNumber, Driver, Gen, Ctype, Color);
                    Con.SetData(Query);
                    MessageBox.Show("Samochód dodano pomyślnie");
                    ShowCars();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        int Key = 0;

        private void CarsDGV_SelectionChanged(object sender, EventArgs e)
        {
            if (CarsDGV.SelectedRows.Count > 0)
            {
                PNumberTb.Text = CarsDGV.SelectedRows[0].Cells[1].Value.ToString();
                DriverTb.Text = CarsDGV.SelectedRows[0].Cells[2].Value.ToString();
                GenCb.SelectedItem = CarsDGV.SelectedRows[0].Cells[3].Value.ToString();
                CarType.Text = CarsDGV.SelectedRows[0].Cells[4].Value.ToString();
                ColorTb.Text = CarsDGV.SelectedRows[0].Cells[5].Value.ToString();

                Key = Convert.ToInt32(CarsDGV.SelectedRows[0].Cells[0].Value);
            }
            else
            {
                Key = 0;
            }
        }


        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Zaznacz samochód");
            }
            else
            {
                try
                {
                    string Query = "delete from CarsTb1 where CNum = {0}";
                    Query = string.Format(Query, Key);
                    Con.SetData(Query);
                    MessageBox.Show("Samochód usunięty");
                    ShowCars();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 Obj = new Form1();
            Obj.Show();
            this.Hide();
        }

        private void CarsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
