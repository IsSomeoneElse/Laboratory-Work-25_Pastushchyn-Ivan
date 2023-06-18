using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.Remoting.Contexts;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LW25
{
    public partial class SearchForm : Form
    {
        Point lastPoint;

        public SearchForm()
        {
            InitializeComponent();
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm StartForm = new MainForm();
            StartForm.Show();
        }

        private void buttonSearchGame_MouseEnter(object sender, EventArgs e)
        {
            buttonSearchGame.BackColor = Color.AliceBlue;
        }

        private void buttonSearchGame_MouseLeave(object sender, EventArgs e)
        {
            buttonSearchGame.BackColor = Color.LightSteelBlue;
        }

        private void titleLabel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void titleLabel_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void buttonSearchGame_Click(object sender, EventArgs e)
        {
            reportRichTextBox.Clear();
            DataBase DB = new DataBase();
            string inputPlatform = gameSearchComboBox.Text;
            MySqlCommand command = new MySqlCommand("SELECT * FROM `games` WHERE `platform` = @iPf", DB.GetConnection());
            command.Parameters.Add("@iPf", MySqlDbType.VarChar).Value = inputPlatform;

            DB.openConnection();
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string row = "";
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    row += reader.GetValue(i).ToString() + "   ";
                }
                reportRichTextBox.AppendText(row + "\n");
            }
            reader.Close();
            DB.closeConnection();
        }
    }
}
