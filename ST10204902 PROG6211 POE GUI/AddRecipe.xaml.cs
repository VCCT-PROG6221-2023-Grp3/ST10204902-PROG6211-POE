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
using ST10204902_PROG6211_POE;

namespace ST10204902_PROG6211_POE_GUI
{
    /// <summary>
    /// Interaction logic for AddRecipe.xaml
    /// </summary>
    public partial class AddRecipe : Window
    {
        public List<Ingredient> listIngredients = new List<Ingredient>();
        public List<String> listSteps = new List<String>();
        public AddRecipe()
        {
            InitializeComponent();
            listViewIngredients.ItemsSource = listIngredients;
            listViewSteps.ItemsSource = listSteps;
        }

        private void btnAddStep_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
