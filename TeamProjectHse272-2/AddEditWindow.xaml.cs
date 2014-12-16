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

namespace TeamProjectHse272_2
{
    /// <summary>
    /// Interaction logic for AddEditWindow.xaml
    /// </summary>
    public partial class AddEditWindow : Window
    {
        public AddEditWindow()
        {
            InitializeComponent();
        }

        public AddEditWindow (string model, string producer, double price, int quantity, TeamProjectHse272_2.Data.Category category)
        {
            ModelBox.Text = model;
            ProducerBox.Text = producer;
            PriceBox.Text = price.ToString();
            QuantityBox.Text = quantity.ToString();
            ComboItem.Text = category.Name;
        }

        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            TeamProjectHse272_2.Data.Product product = new TeamProjectHse272_2.Data.Product { Producer = ProducerBox.Text, Model = ModelBox.Text, Price = decimal.Parse(PriceBox.Text), Quantity = int.Parse(QuantityBox.Text) };
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
