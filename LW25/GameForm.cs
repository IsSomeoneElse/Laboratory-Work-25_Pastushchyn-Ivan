using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LW25
{
    public partial class GameForm : Form
    {
        Point lastPoint;

        public GameForm()
        {
            InitializeComponent();
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm StartForm = new MainForm();
            StartForm.Show();

        }

        private void buttonAddGame_MouseEnter(object sender, EventArgs e)
        {
            buttonAddGame.BackColor = Color.AliceBlue;
        }

        private void buttonAddGame_MouseLeave(object sender, EventArgs e)
        {
            buttonAddGame.BackColor = Color.LightSteelBlue;
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

        private void buttonAddGame_Click(object sender, EventArgs e)
        {
            if (gameIDTextBox.Text == "")
            {
                MessageBox.Show("Enter ID");
                return;
            }

            if (gameNameTextBox.Text == "")
            {
                MessageBox.Show("Enter game name");
                return;
            }

            if (gameDeveloperTextBox.Text == "")
            {
                MessageBox.Show("Enter game developer");
                return;
            }

            if (gameGenreTextBox.Text == "")
            {
                MessageBox.Show("Enter game genre");
                return;
            }

            if (gamePlatformComboBox.Text == "")
            {
                MessageBox.Show("Choose the platform");
                return;
            }

            if (checkGame() == true)
            {
                return;
            }


            DataBase DB = new DataBase();
            MySqlCommand command = new MySqlCommand("INSERT INTO `games` (`id`, `name`, `developer`, `genre`, `platform`) " +
                "VALUES (@gID, @gN, @gD, @gG, @gP)", DB.GetConnection());

            command.Parameters.Add("@gID", MySqlDbType.Int32).Value = gameIDTextBox.Text;
            command.Parameters.Add("@gN", MySqlDbType.VarChar).Value = gameNameTextBox.Text;
            command.Parameters.Add("@gD", MySqlDbType.VarChar).Value = gameDeveloperTextBox.Text;
            command.Parameters.Add("@gG", MySqlDbType.VarChar).Value = gameGenreTextBox.Text;
            command.Parameters.Add("@gP", MySqlDbType.VarChar).Value = gamePlatformComboBox.Text;

            DB.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Game added");
            }
            else
            {
                MessageBox.Show("Error");
            }
            DB.closeConnection();
        }

        public Boolean checkGame()
        {
            DataBase DB = new DataBase();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `games` WHERE `name` = @gName AND `developer` = @gDev AND " +
                "`genre` = @gGenre AND `platform` = @gPlatform",DB.GetConnection());

            command.Parameters.Add("@gName", MySqlDbType.VarChar).Value = gameNameTextBox.Text;
            command.Parameters.Add("@gDev", MySqlDbType.VarChar).Value = gameDeveloperTextBox.Text;
            command.Parameters.Add("@gGenre", MySqlDbType.VarChar).Value = gameGenreTextBox.Text;
            command.Parameters.Add("@gPlatform", MySqlDbType.VarChar).Value = gamePlatformComboBox.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("This game is already in database");
                return true;
            }
            
            else
            {
                return false;
            }

        }
    }
}
