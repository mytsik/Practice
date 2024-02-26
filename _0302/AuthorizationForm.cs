using Npgsql;

namespace _0302
{
    public partial class AuthorizationForm : Form
    {
        public AuthorizationForm()
        {
            InitializeComponent();
        }
        string conn = "Server=localhost;Port=5432;Database=Practice;User Id=postgres;Password=24601;";

        int attempts = 3;

        private async void buttonEntry_Click(object sender, EventArgs e)
        {
            textBoxLogin.Text = "";
            textBoxPassword.Text = "";

            await using var dataSource = NpgsqlDataSource.Create(conn);

            List<string> userList = [];
            try
            {
                await using (var cmd = dataSource.CreateCommand("SELECT login FROM public.user2 WHERE " +
                "login='" + textBoxLogin.Text + "' AND passw='" + textBoxPassword.Text + "' "))
                await using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        userList.Add(reader.GetString(0));
                    }
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
                MessageBox.Show($"Логин и/или пароль введены не верно! Осталось попыток: {attempts}");                
                if (attempts == 0)
                {
                    System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                    timer.Interval = 20000;
                    timer.Tick += timer_Tick;
                    timer.Start();

                    textBoxLogin.Enabled = false;
                    textBoxPassword.Enabled = false;
                    buttonEntry.Enabled = false;

                    attempts = 3;
                }
                
            }
        }

        private async void timer_Tick(object sender, EventArgs e)
        {
            textBoxLogin.Enabled = true;
            textBoxPassword.Enabled = true;
            buttonEntry.Enabled = true;
        }
    }
}
