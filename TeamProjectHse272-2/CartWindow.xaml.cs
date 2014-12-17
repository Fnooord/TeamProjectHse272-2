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
using System.Windows.Shapes;
using TeamProjectHse272_2.Data;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace TeamProjectHse272_2
{
    /// <summary>
    /// Interaction logic for Cart.xaml
    /// </summary>
    public partial class CartWindow : Window
    {
        public CartWindow()
        {
            InitializeComponent();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {            
            var cart = DataContext as Cart;
            if (cart == null)
            {
                return;
            }
            cart.Items.Clear();
            Refresh();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = cartGrid.SelectedItem as CartItem;
            if (selectedItem == null)
            {
                return;
            }
            var cart = DataContext as Cart;
            if (cart == null)
            {
                return;
            }
            cart.Items.Remove(selectedItem);
            Refresh();
        }

        private void Refresh()
        {
            cartGrid.Items.Refresh();
            BindingOperations.GetBindingExpressionBase(
                total, Label.ContentProperty).UpdateTarget();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (NameOfTheCart.Text != "")
            {
                using (Stream cartStream = File.OpenWrite(NameOfTheCart.Text))
            {
                BinaryFormatter serializer = new BinaryFormatter();
                serializer.Serialize(cartStream, DataContext);
            }
            }
            else
            {
                MessageBox.Show("Enter the name!", "Error!");
            }
            
        }
    }
}
