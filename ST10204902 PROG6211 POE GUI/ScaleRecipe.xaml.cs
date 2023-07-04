using ST10204902_PROG6211_POE;
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

namespace ST10204902_PROG6211_POE_GUI
{
    /// <summary>
    /// Interaction logic for ScaleRecipe.xaml
    /// </summary>
    public partial class ScaleRecipe : Window
    {
        //Variable declarations
        String name = "";
        ObservableCollection<Ingredient> ingredients = new ObservableCollection<Ingredient>();
        ObservableCollection<String> steps = new ObservableCollection<String>();
        ObservableCollection<String> ingredientNames = new ObservableCollection<String>();
        double factor = 0;

        //Parameterised constructor that accepts all Recipe information and updates the listviewbox with the data
        public ScaleRecipe(String passName, ObservableCollection<Ingredient> passIngredients, ObservableCollection<String> passSteps, double passFactor)
        {
            InitializeComponent();
            name = "";
            ingredients.Clear();
            steps.Clear();

            
            factor = passFactor;

            name = passName;
            steps = passSteps;
            ingredients = passIngredients;

            foreach (Ingredient i in ingredients)
            {
                ingredientNames.Add(i.Name);
            }


            listViewIngredients.ItemsSource = ingredientNames;
            listViewSteps.ItemsSource = steps;
        }

        //Updates the labels in the window with the values at the selected index
        private void listViewIngredients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Ingredient i = ingredients[listViewIngredients.SelectedIndex];

                lblName.Content = i.Name;
                lblCalories.Content = i.Calories*factor;
                lblQuantity.Content = i.Quantity*factor;
                lblUnitOfMeasurement.Content = i.UnitOfMeasurement;
                lblFoodGroup.Content = i.FoodGroup;
            }
            catch(Exception ex)
            {
                //Used to prevent error when selected index=-1 occurs
            }
        }

        //Closes the window
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
