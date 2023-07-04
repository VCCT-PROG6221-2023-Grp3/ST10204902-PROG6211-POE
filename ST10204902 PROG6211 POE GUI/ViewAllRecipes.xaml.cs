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
        //Variable declarations
        //ObservableCollections of custom classes such as Recipe are used to store all data regarding a recipe
        //ObservableCollections of strings are linked to each custom class ObservableCollection for display in lists
        public static ObservableCollection<Recipe> listRecipes = new ObservableCollection<Recipe>();
        public static ObservableCollection<String> recipeNames = new ObservableCollection<String>();
        public ObservableCollection<String> listIngredientsName = new ObservableCollection<String>();
        public ObservableCollection<String> listStepsName = new ObservableCollection<String>();
        ObservableCollection<Ingredient> listIngredients = new ObservableCollection<Ingredient>();
        ObservableCollection<String> listSteps = new ObservableCollection<String>();
        ObservableCollection<Recipe> filteredRecipe = new ObservableCollection<Recipe>();

        //Default constructor
        public ViewAllRecipes()
        {
            InitializeComponent();
        }

        //Parameterised constructor that accepts an ObservableCollection of Recipes to populate the name ObservableCollections
        public ViewAllRecipes(ObservableCollection<Recipe> recipes)
        {
            InitializeComponent();
            
            recipeNames.Clear();

            listRecipes = recipes;
            checkRecipes();

            foreach(Recipe recipe in listRecipes)
            {
                recipeNames.Add(recipe.Name);
            }

            listViewRecipes.Items.Clear();

            listViewRecipes.ItemsSource = recipeNames;
        }

        //Parameterised constructor designed for the filter to allow users to reset.
        //Accepts an ObservableCollection of Recipes to populate the name ObservableCollections as well as the original list to allow reset
        public ViewAllRecipes(ObservableCollection<Recipe> passFilteredRecipes, ObservableCollection<Recipe> originalRecipes)
        {
            InitializeComponent();
            recipeNames.Clear();

            filteredRecipe = passFilteredRecipes;
            listRecipes = originalRecipes;

            checkRecipes();
            foreach (Recipe recipe in filteredRecipe)
            {
                recipeNames.Add(recipe.Name);
            }

            listViewRecipes.Items.Clear();
            listViewRecipes.ItemsSource = recipeNames;
        }

        //private helper method to check recipe list length
        //If the list is 0 recipes long, display a label with a message
        public void checkRecipes()
        {
            if(listRecipes.Count == 0)
            {
                lblError.Content = "There are no recipes added currently";
                
            }
        }

        //When a user selects a recipe within a list, it grabs the recipe and populates the ingredient and step lists
        private void listViewRecipes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listIngredients.Clear();
            listSteps.Clear();
            listIngredientsName.Clear();
            listStepsName.Clear();
            try
            {
                Recipe r = listRecipes[listViewRecipes.SelectedIndex];

                foreach (var item in r.Ingredients)
                {
                    listIngredients.Add(item);
                    listIngredientsName.Add(item.Name);
                }

                foreach (var item in r.Steps)
                {
                    listSteps.Add(item);
                    listStepsName.Add(item.ToString());
                }

                listViewIngredients.ItemsSource = listIngredientsName;
                listViewSteps.ItemsSource = listStepsName;

                lblRecipeName.Content = r.Name;
                listViewIngredients.SelectedIndex = 0;
            }
            catch(Exception ex)
            {
                //This catch exists to prevent the selectedIndex = -1 error when there are no recipes in the list
                //or when closing the window and reopening it from MainWindow
            }
        }

        //When a user selects an ingredient it populates the labels next to the listViewBox with the selected ingredients info
        private void listViewIngredients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Ingredient ing = listRecipes[listViewRecipes.SelectedIndex].Ingredients[listViewIngredients.SelectedIndex];


                lblIngredientName.Content = ing.Name;
                lblQuantity.Content = ing.Quantity;
                lblUnitOfMeasurement.Content = ing.UnitOfMeasurement;
                lblFoodGroup.Content = ing.FoodGroup;
                lblCalories.Content = ing.Calories;
            }
            catch (Exception ex)
            {
                //This catch exists to prevent the selectedIndex =-1 error when there are no ingredients in the list
            }
        }

        //Returns the user to the previous menu
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(listRecipes);
            mainWindow.Show();
            this.Close();
        }

        //Deletes the recipe at the selected index after confirming with the user
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if(listViewRecipes.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a Recipe to Delete");
            }
            else
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure you want to delete this recipe?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
                if (messageBoxResult == System.Windows.MessageBoxResult.Yes)
                {
                    listRecipes.RemoveAt(listViewRecipes.SelectedIndex);
                    recipeNames.RemoveAt(listViewRecipes.SelectedIndex);
                    
                    checkRecipes();

                    resetLabelsAndViews();
                }
            }
        }

        //private helper method to reset all labels and viewListBoxes between selections and restarting of the window
        private void resetLabelsAndViews()
        {
            lblRecipeName.Content = "";
            lblCalories.Content = "";
            lblFoodGroup.Content = "";
            lblIngredientName.Content = "";
            lblQuantity.Content = "";
            lblUnitOfMeasurement.Content = "";
            listIngredientsName.Clear();
            listStepsName.Clear();
        }

        //private helper to reduce redundant code
        private void RecipeScaling(double factor)
        {
            try
            {
                ScaleRecipe scaleRecipe = new ScaleRecipe(lblRecipeName.Content.ToString(), listIngredients, listSteps, factor);
                scaleRecipe.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnScaleRecipeByHalfMethod(object sender, RoutedEventArgs e)
        {
            RecipeScaling(0.5);
        }

        private void btnScaleRecipeByTwo_Click(object sender, RoutedEventArgs e)
        {
            RecipeScaling(2);
        }

        private void btnScaleRecipeByThree_Click(object sender, RoutedEventArgs e)
        {
            RecipeScaling(3);
        }

        //Opens the filter window and passes the list of recipes
        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            Filter filter = new Filter(listRecipes);
            filter.Show();
            this.Close();
        }

        //returns the recipe list to its previous values before filtering
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            recipeNames.Clear();

            checkRecipes();

            foreach (Recipe recipe in listRecipes)
            {
                recipeNames.Add(recipe.Name);
            }

           

            listViewRecipes.ItemsSource = recipeNames;
        }
    }
}
