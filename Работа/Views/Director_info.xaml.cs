using System;
using System.Linq;
using System.Windows;


namespace Работа
{
    /// <summary>
    /// Логика взаимодействия для Director_info.xaml
    /// </summary>
    public partial class Director_info : Window
    {
        Entities context = new Entities();
        public Director_info()
        {
            InitializeComponent();
        }
        private void Search(object sender, RoutedEventArgs e)
        {
            string fam = FamSearch1.Text.ToString();
            if (FamSearch1.Text.Length == 0)
            {
                Sotr.ItemsSource = context.Staff.ToList();
                return;
            }
            var res = context.Staff.Where(i => i.Surname.Contains(FamSearch1.Text));
            if (res.Count() != 0)
            {
                Sotr.ItemsSource = res.ToList();
            }
            else
            {
                MessageBox.Show("Внимание!", " Не найдено!",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void ResetSearch(object sende, RoutedEventArgs e)
        {
            FamSearch1.Text = "";
            Sotr.ItemsSource = context.Staff.Where(i => i.id > 0).ToList();
        }

        private void _close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Sotr.ItemsSource = context.Staff.ToList();
            
        }
    }
}
