using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _1301
{
    public partial class EntryForm : Form
    {
        public EntryForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        string conn = "Server=localhost;Port=5432;Database=Practice;User Id=postgres;Password=24601;";

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0)
            {
                using (UserContext db = new UserContext(conn))
                {
                    var infolist = db.user.FromSqlRaw("SELECT * FROM public.user " +
                        "WHERE password='" + textBox1.Text + "' ").ToList();

                    if (infolist.Count() != 0)
                    {
                        Hide();
                        MainForm fmMain = new MainForm();
                        fmMain.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Пользователя с таким паролем не существует");
                    }
                }
            }
            else
            {
                MessageBox.Show("Введите пароль");
            }
        }

        private void SignUpButton_Click(object sender, EventArgs e)
        {
            string passw = textBox1.Text;

            if (passw.Length != 0)
            {
                using (UserContext db = new UserContext(conn))
                {
                    var infolist = db.user.FromSqlRaw("SELECT * FROM public.user " +
                        "WHERE password='" + passw + "' ").ToList();

                    if (infolist.Count() != 0)
                    {
                        MessageBox.Show("Данный пароль занят. Выберите другой");
                    }
                    else
                    {
                        if ((passw.Length == 8) && (((passw.Contains("@") == true) && (passw.Contains("!") == true))
                            && ((passw.Any(char.IsUpper) == true) && (passw.Any(char.IsLower) == true))))
                        {
                            MessageBox.Show("Регистрация прошла успешно!");
                            Hide();
                            MainForm fmMain = new MainForm();
                            fmMain.ShowDialog();

                            try
                            {
                                db.user.Add(new User { Password = passw });
                                db.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString());
                            }
                        }
                        else
                        {
                            MessageBox.Show("Пароль должен состоять из 8 символов, включая буквы верхнего " +
                                "и нижнего регистров, а также символы @,!");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Введите пароль");
            }
        }

        private void EntryForm_Load(object sender, EventArgs e)
        {

        }
    }
}
