using System;
using System.Linq;
using System.Threading;
using System.Windows;


namespace Работа
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Entities context = new Entities();
        public MainWindow()
        {
            Thread.Sleep(3000);
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string logintext = _login.Text.ToString();
            string passwordText = _password.Password.ToString();

            string loginBD = context.Users.Where(i => i.Login == logintext).Select(h => h.Login).FirstOrDefault();
            if (loginBD != null)
            {
                string passwoedBD = context.Users.Where(i => i.Login == logintext).Select(h => h.Password).FirstOrDefault();
                if (passwoedBD == passwordText)
                {
                    int idROLE = (int)context.Users.Where(i => i.Login == logintext).Select(j => j.id_Role).FirstOrDefault();
                    if (idROLE == 1)
                    {
                        Info info = new Info();
                        info.Show();
                        this.Close();
                    }
                    if (idROLE == 2)
                    {
                        Director_info director_Info = new Director_info();
                        director_Info.Show();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Неверный пароль!");
                }
            }
            else
            {
                MessageBox.Show("Пользователь не найден!");
            }
        }
    }
}
