using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace Работа
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Info pw;
        int isAddEdit = 0;
        public Page1(Info info)
        {
            InitializeComponent();
            pw = info;
        }
        private void PageLoad(object sender, RoutedEventArgs e)
        {
            if (pw.Check_1.IsChecked == false && pw.Check_2.IsChecked == false &&
                pw.Check_3.IsChecked == false && pw.Check_4.IsChecked == false && pw.Check_5.IsChecked == false)
            {
                GR_BOX.Visibility = Visibility.Collapsed;
            }
            else
            {
                GR_BOX.Visibility = Visibility.Visible;
            }
            if (pw.Check_1.IsChecked == true)
            {
                FamSearch.Visibility = Visibility.Visible;
            }
            else
            {
                FamSearch.Visibility = Visibility.Collapsed;
            }
            if (pw.Check_2.IsChecked == true)
            {
                ImySearch.Visibility = Visibility.Visible;
            }
            else
            {
                ImySearch.Visibility = Visibility.Collapsed;
            }
            if (pw.Check_3.IsChecked == true)
            {
                OtchSearch.Visibility = Visibility.Visible;
            }
            else
            {
                OtchSearch.Visibility = Visibility.Collapsed;
            }
            if (pw.Check_4.IsChecked == true)
            {
                MobSearch.Visibility = Visibility.Visible;
            }
            else
            {
                MobSearch.Visibility = Visibility.Collapsed;
            }
            if (pw.Check_5.IsChecked == true)
            {
                EmailSearch.Visibility = Visibility.Visible;
            }
            else
            {
                EmailSearch.Visibility = Visibility.Collapsed;
            }
            if (pw.Check2_1.IsChecked == true)
            {
                Gr_Fam.Visibility = Visibility.Visible;
            }
            else
            {
                Gr_Fam.Visibility = Visibility.Collapsed;
            }
            if (pw.Check2_2.IsChecked == true)
            {
                Gr_Im.Visibility = Visibility.Visible;
            }
            else
            {
                Gr_Im.Visibility = Visibility.Collapsed;
            }
            if (pw.Check2_3.IsChecked == true)
            {
                Gr_Ot.Visibility = Visibility.Visible;
            }
            else
            {
                Gr_Ot.Visibility = Visibility.Collapsed;
            }
            if (pw.Check2_4.IsChecked == true)
            {
                Gender.Visibility = Visibility.Visible;
            }
            else
            {
                Gender.Visibility = Visibility.Collapsed;
            }
            if (pw.Check2_5.IsChecked == true)
            {
                Gr_Dat.Visibility = Visibility.Visible;
            }
            else
            {
                Gr_Dat.Visibility = Visibility.Collapsed;
            }
            if (pw.Check2_6.IsChecked == true)
            {
                Gr_Mob.Visibility = Visibility.Visible;
            }
            else
            {
                Gr_Mob.Visibility = Visibility.Collapsed;
            }

            if (pw.Check2_7.IsChecked == true)
            {
                Gr_Ned.Visibility = Visibility.Visible;
            }
            else
            {
                Gr_Ned.Visibility = Visibility.Collapsed;
            }
            if (pw.Check2_8.IsChecked == true)
            {
                Gr_Em.Visibility = Visibility.Visible;
            }
            else
            {
                Gr_Em.Visibility = Visibility.Collapsed;
            }
            if (pw.Check2_9.IsChecked == true)
            {
                Gr_Adr.Visibility = Visibility.Visible;
            }
            else
            {
                Gr_Adr.Visibility = Visibility.Collapsed;
            }
            if (pw.Check2_10.IsChecked == true)
            {
                Gr_Coin.Visibility = Visibility.Visible;
            }
            else
            {
                Gr_Coin.Visibility = Visibility.Collapsed;
            }
            FriendsGrid.ItemsSource = pw.context.Customers.ToList();
            Gender.ItemsSource = pw.context.Gender.ToList();
            Gr_Ned.ItemsSource = pw.context.Realty_type.ToList();
        }

        private void ResetSearch(object sende, RoutedEventArgs e)
        {
            FamSearch1.Text = "";
            ImySearch1.Text = "";
            MobSearch1.Text = "";
            EmailSearch1.Text = "";
            OtchSearch1.Text = "";
            FriendsGrid.ItemsSource = pw.context.Customers.Where(i => i.id > 0).ToList();
        }

        private void Search(object sender, RoutedEventArgs e)
        {
            var tabb = pw.context.Customers;
            if (FamSearch1.Text.Length == 0 && ImySearch1.Text.Length == 0 &&
                MobSearch1.Text.Length == 0 && EmailSearch1.Text.Length == 0 && OtchSearch1.Text.Length == 0)
            {
                FriendsGrid.ItemsSource = tabb.ToList();
                return;
            }
            var res = tabb.Where(i => i.Surname.Contains(FamSearch1.Text) &&
                                 i.Name.Contains(ImySearch1.Text) &&
                                 i.Patronymic.Contains(OtchSearch1.Text) &&
                                 i.Phone.Contains(MobSearch1.Text) &&
                                 i.Email.Contains(EmailSearch1.Text)).ToList();
            if (res.Count() != 0)
            {
                FriendsGrid.ItemsSource = res;
            }
            else
            {
                MessageBox.Show("Внимание!", " Не найдено!",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }


        private void SaveFriend(object sender, DataGridRowEditEndingEventArgs e)
        {
            var dg = sender as DataGrid;
            if (dg != null)
            {
                var dgr = (DataGridRow)(dg.ItemContainerGenerator.ContainerFromIndex(dg.SelectedIndex));
                if (isAddEdit == 0)
                {
                    if (pw.context.SaveChanges() == 0)
                    {
                        MessageBox.Show("Ошибка", "Ошибка записи", MessageBoxButton.OK,
                            MessageBoxImage.Error);
                        return;
                    }
                }
                else
                {
                    var num_id = e.Row.Item as Customers;
                    pw.context.Customers.Add(new Customers
                    {
                        Surname = num_id.Surname,
                        Name = num_id.Name,
                        Patronymic = num_id.Patronymic,
                        Phone = num_id.Phone,
                        Email = num_id.Email,
                        Address = num_id.Address

                    });
                    if (pw.context.SaveChanges() == 0)
                    {
                        MessageBox.Show("Ошибка", "Ошибка записи", MessageBoxButton.OK,
                            MessageBoxImage.Error);
                        isAddEdit = 0;
                        return;
                    }
                    isAddEdit = 0;

                }
            }
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            pw.context.SaveChanges();
            pw.FrameMainDemo.Refresh();

        }
        private void PreviewKey(object sender, KeyEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            if (dg != null)
            {
                DataGridRow dgr = (DataGridRow)(dg.ItemContainerGenerator.ContainerFromIndex(dg.SelectedIndex));
                if (e.Key == Key.Delete && !dgr.IsEditing && !dgr.IsNewItem)
                {
                    var res = FriendsGrid.SelectedItem as Customers;
                    var ree = MessageBox.Show("Подтверждение удаления",
                        string.Format("Запись \n{0}\n{1}\n будет удалена.", res.Surname, res.Name),
                        MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (!(e.Handled = (ree == MessageBoxResult.No)))
                    {
                        if (pw.context.Customers.Remove(pw.context.Customers.FirstOrDefault(i => i.id == res.id)) != null)
                        {
                            pw.context.SaveChanges();
                            pw.FrameMainDemo.Refresh();
                        }
                        else
                        {
                            MessageBox.Show("Ошибка", "Ошибка удаления!", MessageBoxButton.OK,
                                MessageBoxImage.Error);
                        }
                    }
                }
            }
        }

        private void IsAddEdit(object sender, AddingNewItemEventArgs e)
        {
            isAddEdit = 1;
        }
    }
}
