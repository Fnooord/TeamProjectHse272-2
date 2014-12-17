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
        public Cart cart;
        public CartWindow()
        {
            cart = new Cart();

            InitializeComponent();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Stream CartStream = File.OpenWrite("Cart");
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(CartStream, cart);
            CartStream.Close();
        }
    }
}
