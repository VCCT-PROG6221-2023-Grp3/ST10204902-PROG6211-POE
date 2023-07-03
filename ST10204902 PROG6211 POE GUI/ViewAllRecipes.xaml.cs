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
        public ObservableCollection<String> listIngredientsName = new ObservableCollection<String>();
        public ObservableCollection<String> listStepsName = new ObservableCollection<String>();
        ObservableCollection<Ingredient> listIngredients = new ObservableCollection<Ingredient>();
        ObservableCollection<String> listSteps = new ObservableCollection<String>();

        public ViewAllRecipes()
        {
            InitializeComponent();
        }

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

        public void checkRecipes()
        {
            if(listRecipes.Count == 0)
            {
                lblError.Content = "There are no recipes added currently";
                
            }
        }

        private void listViewRecipes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
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

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(listRecipes);
            mainWindow.Show();
            this.Close();
        }

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
    }
}
