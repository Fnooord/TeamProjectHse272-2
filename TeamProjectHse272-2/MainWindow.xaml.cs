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
using System.Data.Entity;
using TeamProjectHse272_2.Data;

namespace TeamProjectHse272_2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Context db = new Context();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var newProduct = new Product { };
            var addwindow = new AddEditWindow
            {
                DataContext = new ProductEditViewModel
                {
                    Product = newProduct,
                    Categories = new List<Category>(),
                    Title = "Add"
                }
            };
            addwindow.SaveClick += (s, args) =>
            {
                db.Products.Add(newProduct);
            };
            addwindow.ShowDialog();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            var selectedProduct = dataGridMain.SelectedItem as Product;
            if (selectedProduct == null)
            {
                return;
            }
            var editwindow = new AddEditWindow
            {
                DataContext = new ProductEditViewModel
                {
                    Product = selectedProduct,
                    Categories = new List<Category>(),
                    Title = "Save"
                }
            };
            
            editwindow.ShowDialog();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            foreach (Product p in db.Products)
            {
                if (p.Id == dataGridMain.SelectedIndex)
                    db.Products.Remove(p);
            }            
            //[dataGridMain.SelectedIndex]
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            foreach (var category in db.Categories.Local.ToList())
            {
                if (category == null)
                {
                    db.Categories.Remove(category);
                }
            }
            db.SaveChanges();
            this.dataGridMain.Items.Refresh();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Загрузите данные, установив свойство CollectionViewSource.Source:
            // productViewSource.Source = [универсальный источник данных]
            db.Products.Load();
            DataContext =
                new StoreViewModel
                {
                    Products = db.Products.Local
                };
        }
    }
}
