using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Npgsql;
using System.Drawing.Text;
using System.Collections;

namespace _0802
{
    public partial class AuthorizationForm : Form
    {
        public AuthorizationForm()
        {
            InitializeComponent();
        }

        string connStr = "Server=localhost;Port=5432;Database=Practice;User Id=postgres;Password=24601;";
        int attempts = 3;

        private void buttonEntry_Click(object sender, EventArgs e)
        {           
            List<string> userList = [];

            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connStr))
                {
                    connection.Open();

                    NpgsqlCommand command = new NpgsqlCommand("SELECT login FROM public.user2 WHERE " +
                    "login='" + textBoxLogin.Text + "' AND passw='" + textBoxPassword.Text + "' ", connection);
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            userList.Add(reader.GetString(0));
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


            if (userList.Count != 0)
            {
                Hide();
                MainForm fmMain = new MainForm();
                fmMain.ShowDialog();
            }
            else
            {
                attempts -= 1;
                MessageBox.Show($"����� �/��� ������ ������� �� �����! �������� �������: {attempts}");

                if (attempts == 0)
                {
                    CaptchaForm fmCaptcha = new CaptchaForm();
                    fmCaptcha.ShowDialog();
                }
            }

            textBoxLogin.Text = "";
            textBoxPassword.Text = "";

        }
                
    }
}
