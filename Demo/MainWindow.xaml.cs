using Demo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Demo
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DemoEntities _dbcontext = new DemoEntities();


        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            TovarsDataGid.ItemsSource = _dbcontext.Tovars.ToList();
        }

        
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var newItem = new Tovars
            {
                Name = "Новый товар",
                Discription = "Описание",
                Price = 0
            };

            _dbcontext.Tovars.Add(newItem);
            _dbcontext.SaveChanges();
            LoadData();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (TovarsDataGid.SelectedItem is Tovars selected)
            {
                selected.Name += " ";
                _dbcontext.SaveChanges();
                TovarsDataGid.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Выберите товар");
            }
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            _dbcontext.Dispose();
            _dbcontext = new DemoEntities();
            LoadData();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (TovarsDataGid.SelectedItem is Tovars selected)
            {
                _dbcontext.Tovars.Remove(selected);
                _dbcontext.SaveChanges();
                LoadData();
            }
            else
            {
                MessageBox.Show("Выберите товар");
            }
        }
    }
}



