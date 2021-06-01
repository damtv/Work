using System;
using System.Linq;
using System.Windows;
using Работа.Classes;

namespace Работа.Views
{
    /// <summary>
    /// Логика взаимодействия для Realty_info.xaml
    /// </summary>
    public partial class Realty_info : Window
    {
        private Config_2 configDemoWpf;
        public Entities context = new Entities();
        public Realty_info()
        {
            InitializeComponent();
            configDemoWpf = new Config_2(this);
            OpenPageDemo(pageDemo.demoPge);
        }
        public enum pageDemo
        {
            demoPge,
        }
        public void OpenPageDemo(pageDemo page)
        {
            switch (page)
            {
                case pageDemo.demoPge:
                    Frame_1.Navigate(new Page2(this));
                    break;
            }
        }

        private void _back_Click(object sender, RoutedEventArgs e)
        {
            Info info = new Info();
            this.Hide();
            info.Show();
        }

        private void _close_Click(object sender, RoutedEventArgs e)
        {
            configDemoWpf.SavConfig();
            this.Close();
        }
        private void Click_Check1(object sender, RoutedEventArgs e)
        {
                Frame_1.Refresh();
        }
    }
}
