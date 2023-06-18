using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using LW25.Properties;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace LW25
{
    public partial class MainForm : Form
    {
        Point lastPoint;

        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonAddGame_Click(object sender, EventArgs e)
        {
            this.Hide();
            GameForm gameForm = new GameForm();
            gameForm.Show();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            this.Hide();
            SearchForm searchForm = new SearchForm();
            searchForm.Show();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonAddGame_MouseEnter(object sender, EventArgs e)
        {
            buttonAddGame.BackColor = Color.AliceBlue;
        }

        private void buttonAddGame_MouseLeave(object sender, EventArgs e)
        {
            buttonAddGame.BackColor = Color.LightSteelBlue;
        }

        private void buttonSearch_MouseEnter(object sender, EventArgs e)
        {
            buttonSearch.BackColor = Color.AliceBlue;
        }

        private void buttonSearch_MouseLeave(object sender, EventArgs e)
        {
            buttonSearch.BackColor = Color.LightSteelBlue;
        }

        private void buttonExit_MouseEnter(object sender, EventArgs e)
        {
            buttonExit.BackColor = Color.AliceBlue;
        }

        private void buttonExit_MouseLeave(object sender, EventArgs e)
        {
            buttonExit.BackColor = Color.LightSteelBlue;
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
    }
}
