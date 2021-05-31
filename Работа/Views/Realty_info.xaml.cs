using System;
using System.Linq;
using System.Windows;

namespace Работа.Views
{
    /// <summary>
    /// Логика взаимодействия для Realty_info.xaml
    /// </summary>
    public partial class Realty_info : Window
    {
        Entities context = new Entities();
        public Realty_info()
        {
            InitializeComponent();
            Documents.ItemsSource = context.Realty.ToList();
            Gr_Nedv.ItemsSource = context.Realty_type.ToList();
        }

        private void _back_Click(object sender, RoutedEventArgs e)
        {
            Info info = new Info();
            this.Hide();
            info.Show();
        }

        private void _close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
