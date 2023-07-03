using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using ST10204902_PROG6211_POE;

namespace ST10204902_PROG6211_POE_GUI
{
    /// <summary>
    /// Interaction logic for AddRecipe.xaml
    /// </summary>
    public partial class AddRecipe : Window
    {
        public ObservableCollection<Ingredient> listIngredients = new ObservableCollection<Ingredient>();
        public ObservableCollection<String> listSteps = new ObservableCollection<String>();
        public AddRecipe()
        {
            InitializeComponent();
            listBoxIngredients.ItemsSource = listIngredients;
            listBoxSteps.ItemsSource = listSteps;
        }

        private void btnAddStep_Click(object sender, RoutedEventArgs e)
        {
            if(txbStep.Text.Length == 0 )
            {
                MessageBox.Show("Please enter text into the step text box before attempting to add a new step");
            }
            else
            {
                string temp = txbStep.Text.ToString();
                listSteps.Add(temp);
                listBoxSteps.ItemsSource = listSteps;
            }

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
