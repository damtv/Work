using System;
using System.Windows;
using System.Windows.Controls;
using Работа.Views;

namespace Работа
{
    /// <summary>
    /// Логика взаимодействия для Info.xaml
    /// </summary>
    public partial class Info : Window
    {
        public Entities context = new Entities();
        private Config configDemoWpf;

        internal Config ConfigDemoWpf { get => configDemoWpf; set => configDemoWpf = value; }

        public Info()
        {
            InitializeComponent();
            configDemoWpf = new Config(this);
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
                    FrameMainDemo.Navigate(new Page1(this));
                    break;
            }
        }
        private void radiButton(object sender, RoutedEventArgs e)
        {
            RadioButton li = (sender as RadioButton);
            if (li.Name == "R1_1")
            {
                Grup.Visibility = Visibility.Visible;
                Grup1.Visibility = Visibility.Visible;
            }
            else
            {
                Grup.Visibility = Visibility.Collapsed;
                Grup1.Visibility = Visibility.Collapsed;
            }
            switch (li.Name)
            {
                case "R1_1":
                    OpenPageDemo(pageDemo.demoPge);
                    break;
            }
        }
        private void Click_Check1(object sender, RoutedEventArgs e)
        {
            FrameMainDemo.Refresh();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Realty_info realty = new Realty_info();
            this.Hide();
            realty.Show();
        }
        public void ProfileClick(object sender, RoutedEventArgs e)
        {
            MainWindow winLogin = new MainWindow();
            this.Hide();
            winLogin.Show();
        }
        private void closed(object sender, EventArgs e)
        {
            ConfigDemoWpf.SavConfig();
        }

        private void _close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
