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

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public List<Person> people = new List<Person>();

        private string name = null;

        public MainWindow()
        {
            InitializeComponent();

            people.Add(new Person { FirstName = "Sean", LastName = "Kells" });
            people.Add(new Person { FirstName = "Toffee", LastName = "TheCat" });
            people.Add(new Person { FirstName = "Libby", LastName = "FV" });

            myComboBox.ItemsSource = people;
        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            name = firstNameText.Text;
            if(name != string.Empty)
            {
                MessageBox.Show($"Hello {firstNameText.Text}");
                Console.WriteLine("Name of: " + name);
            }
            else
            {
                Console.WriteLine("Name not defined");
            }
        }
    }
}
