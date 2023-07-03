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
    /// Interaction logic for ViewAllRecipes.xaml
    /// </summary>
    /// 
    
    public partial class ViewAllRecipes : Window
    {
        public static ObservableCollection<Recipe> listRecipes = new ObservableCollection<Recipe>();
        public static ObservableCollection<String> recipeNames = new ObservableCollection<String>();
        public ViewAllRecipes()
        {
            InitializeComponent();
        }

        public ViewAllRecipes(ObservableCollection<Recipe> recipes)
        {
            InitializeComponent();
            
            listRecipes = recipes;
            checkRecipes();
            foreach(Recipe recipe in listRecipes)
            {
                recipeNames.Add(recipe.Name);
            }
            listViewRecipes.Items.Clear();

            listViewRecipes.ItemsSource = recipeNames;
        }

        public void checkRecipes()
        {
            if(listRecipes.Count == 0)
            {
                lblError.Content = "There are no recipes added currently";
                
            }
        }

        private void listViewRecipes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ObservableCollection<Ingredient> listIngredients = new ObservableCollection<Ingredient>();
            ObservableCollection<String> listSteps = new ObservableCollection<String>();
            ObservableCollection<String> listIngredientsName = new ObservableCollection<String>();
            ObservableCollection<String> listStepsName = new ObservableCollection<String>();
            

            Recipe r = listRecipes[listViewRecipes.SelectedIndex];

            foreach(var item in r.Ingredients)
            {
                listIngredients.Add(item);
                listIngredientsName.Add(item.Name);
            }

            foreach(var item in r.Steps)
            {
                listSteps.Add(item);
                listStepsName.Add(item.ToString());
            }

            listViewIngredients.ItemsSource = listIngredientsName;
            listViewSteps.ItemsSource = listStepsName;

            lblRecipeName.Content = r.Name;
            listViewIngredients.SelectedIndex = 0;
        }

        private void listViewIngredients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Ingredient ing = listRecipes[listViewRecipes.SelectedIndex].Ingredients[listViewIngredients.SelectedIndex];


            lblIngredientName.Content = ing.Name;
            lblQuantity.Content = ing.Quantity;
            lblUnitOfMeasurement.Content = ing.UnitOfMeasurement;
            lblFoodGroup.Content = ing.FoodGroup;
            lblCalories.Content = ing.Calories;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(listRecipes);
            mainWindow.Show();
            this.Close();
        }
    }
}
