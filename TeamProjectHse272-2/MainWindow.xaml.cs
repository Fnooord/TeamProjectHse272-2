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
        private IContextFactory contextFactory = new ContextFactory();
        private IContext db;

        public MainWindow()
        {
            InitializeComponent();

            db = contextFactory.Create();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var newProduct = new Product { };
            var addwindow = new AddEditWindow
            {
                DataContext = new ProductEditViewModel
                {
                    Product = newProduct,
                    Categories = db.Categories.Local,
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
                    Categories = db.Categories.Local,
                    Title = "Save"
                }
            };
            
            editwindow.ShowDialog();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var selectedProduct = dataGridMain.SelectedItem as Product;
            if (selectedProduct == null)
            {
                return;
            }
            db.Products.Remove(selectedProduct);
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
            this.dataGridMain.Items.Refresh();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Progress.IsIndeterminate = true;
            Task.Factory.StartNew(LoadDatabase)
                .ContinueWith((task) => DisplayData(), TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void LoadDatabase()
        {
            db.Products.Load();
            db.Categories.Load();
        }

        private void DisplayData()
        {
            DataContext =
                new StoreViewModel
                {
                    Products = db.Products.Local
                };
            Progress.IsIndeterminate = false;
        }

        private void Cart_Click(object sender, RoutedEventArgs e)
        {
            CartWindow cart = new CartWindow();
            cart.Show();
        }
    }
}
