using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
namespace Работа.Views
{
    /// <summary>
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public Realty_info pw;
        int isAddEdit = 0;
        Entities context = new Entities();
        public Page2(Realty_info realty_Info)
        {
            InitializeComponent();
            pw = realty_Info;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (pw.Check_1.IsChecked == false &&
                pw.Check_3.IsChecked == false && pw.Check_5.IsChecked == false)
            {
                _Search.Visibility = Visibility.Collapsed;
            }
            else
            {
                _Search.Visibility = Visibility.Visible;
            }
            if (pw.Check_1.IsChecked == true)
            {
                TitleSearch.Visibility = Visibility.Visible;
            }
            else
            {
                TitleSearch.Visibility = Visibility.Collapsed;
            }
            if (pw.Check_3.IsChecked == true)
            {
                AddressSearch.Visibility = Visibility.Visible;
            }
            else
            {
                AddressSearch.Visibility = Visibility.Collapsed;
            }
            if (pw.Check_5.IsChecked == true)
            {
                StatusSearch.Visibility = Visibility.Visible;
            }
            else
            {
                StatusSearch.Visibility = Visibility.Collapsed;
            }
            if (pw.Check_6.IsChecked == true)
            {
                SquaeSearch.Visibility = Visibility.Visible;
            }
            else
            {
                SquaeSearch.Visibility = Visibility.Collapsed;
            }
            if (pw.Check2_1.IsChecked == true)
            {
                Gr_Name.Visibility = Visibility.Visible;
            }
            else
            {
                Gr_Name.Visibility = Visibility.Collapsed;
            }
            if (pw.Check2_2.IsChecked == true)
            {
                Gr_Price.Visibility = Visibility.Visible;
            }
            else
            {
                Gr_Price.Visibility = Visibility.Collapsed;
            }
            if (pw.Check2_3.IsChecked == true)
            {
                Gr_Address.Visibility = Visibility.Visible;
            }
            else
            {
                Gr_Address.Visibility = Visibility.Collapsed;
            }
            if (pw.Check2_4.IsChecked == true)
            {
                Gr_Nedv.Visibility = Visibility.Visible;
            }
            else
            {
                Gr_Nedv.Visibility = Visibility.Collapsed;
            }
            if (pw.Check2_5.IsChecked == true)
            {
                Gr_Status.Visibility = Visibility.Visible;
            }
            else
            {
                Gr_Status.Visibility = Visibility.Collapsed;
            }
            if (pw.Check2_6.IsChecked == true)
            {
                Gr_Squar.Visibility = Visibility.Visible;
            }
            else
            {
                Gr_Squar.Visibility = Visibility.Collapsed;
            }
            Documents.ItemsSource = pw.context.Realty.ToList();
            Gr_Nedv.ItemsSource = pw.context.Realty_type.ToList();
        }
        private void ResetSearch(object sende, RoutedEventArgs e)
        {
            TitleSearch1.Text = "";
            AddressSearch1.Text = "";
            StatusSearch1.Text = "";
            SquaeSearch1.Text = "";
            Documents.ItemsSource = pw.context.Realty.Where(i => i.id > 0).ToList();
        }

        private void Search(object sender, RoutedEventArgs e)
        {
            var tabb = pw.context.Realty;
            if (TitleSearch1.Text.Length == 0 && AddressSearch1.Text.Length == 0 && StatusSearch1.Text.Length == 0 && SquaeSearch1.Text.Length == 0)
            {
                Documents.ItemsSource = tabb.ToList();
                return;
            }
            var res = tabb.Where(i => i.Title.Contains(TitleSearch1.Text) &&
                                 i.Address.Contains(AddressSearch1.Text) &&
                                 i.Status.Contains(StatusSearch1.Text) &&
                                 i.Square.Contains(SquaeSearch1.Text)).ToList();
            if (res.Count() != 0)
            {
                Documents.ItemsSource = res;
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
                   
                    var num_id = e.Row.Item as Realty;
                    Realty realty = new Realty();
                    realty.Title = num_id.Title;
                    realty.Price = num_id.Price;
                    realty.Address = num_id.Address;
                    realty.id_Realty_type = num_id.id_Realty_type;
                    realty.Status = num_id.Status;
                    if (num_id.id_Realty_type == 1)
                    {
                        realty.Square = num_id.Square + " га";
                    }
                    else if (num_id.id_Realty_type == 2)
                    {
                        realty.Square = num_id.Square + " га";
                    }
                    else if (num_id.id_Realty_type == 3)
                    {
                        realty.Square = num_id.Square + " м²";
                    }
                    else if (num_id.id_Realty_type == 4)
                    {
                        realty.Square = num_id.Square + " м²";
                    }
                    else if (num_id.id_Realty_type == 5)
                    {
                        realty.Square = num_id.Square + " м²";
                    }
                    pw.context.Realty.Add(realty);
                    //var num_id = e.Row.Item as Realty;
                    //pw.context.Realty.Add(new Realty
                    //{
                    //    Title = num_id.Title,
                    //    Price = num_id.Price,
                    //    Address = num_id.Address,
                    //    id_Realty_type = num_id.id_Realty_type,
                    //    Status = num_id.Status,
                    //    Square = num_id.Square
                    //});

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
            pw.Frame_1.Refresh();

        }
        private void PreviewKey(object sender, KeyEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            if (dg != null)
            {
                DataGridRow dgr = (DataGridRow)(dg.ItemContainerGenerator.ContainerFromIndex(dg.SelectedIndex));
                if (e.Key == Key.Delete && !dgr.IsEditing && !dgr.IsNewItem)
                {
                    var res = Documents.SelectedItem as Realty;
                    var ree = MessageBox.Show("Подтверждение удаления",
                        string.Format("Запись \n{0}\n{1}\n будет удалена.", res.Title, res.Address),
                        MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (!(e.Handled = (ree == MessageBoxResult.No)))
                    {
                        if (pw.context.Realty.Remove(pw.context.Realty.FirstOrDefault(i => i.id == res.id)) != null)
                        {
                            pw.context.SaveChanges();
                            pw.Frame_1.Refresh();
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
