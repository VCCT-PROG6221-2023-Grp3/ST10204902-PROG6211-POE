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
    /// Interaction logic for Filter.xaml
    /// </summary>
    public partial class Filter : Window
    {
        //Variable declarations
        ObservableCollection<Recipe> recipes = new ObservableCollection<Recipe>();
        ObservableCollection<Recipe> filteredRecipes = new ObservableCollection<Recipe>();
        ObservableCollection<String> foodGroups = new ObservableCollection<String>();
        
        //Default constructor
        public Filter()
        {
            InitializeComponent();
        }

        //parameterised constructor that accepts an ObservableCollection of recipes from the View All Recipes Window
        //Updates the combobox with all foodgroup values
        public Filter(ObservableCollection<Recipe> passedRecipes)
        {
            InitializeComponent();
            recipes = passedRecipes;

            foodGroups.Add("1) Starchy foods (Eg: Rice, potatoes)");
            foodGroups.Add("2) Vegetables and Fruits (Eg: Apples, carrots, spinach, broccoli");
            foodGroups.Add("3) Legumes (Eg: Chickpeas, soy beans");
            foodGroups.Add("4) Meat products (Eg: Chicken, beef, eggs");
            foodGroups.Add("5) Dairy products (Eg: Milk, yoghurt, cheese");
            foodGroups.Add("6) Fats (Oil, butter)");
            foodGroups.Add("7) Water");

            cmbFoodGroup.ItemsSource = foodGroups;
        }

        //Filter ingredient button event
        //If the user has entered nothing, prompt them with an error
        //If the user has input a valid ingredient and a result is found, return to View All Recipes
        //If the user has entered a valid input but no recipes are found, display an error
        
        private void btnFilterIngredient_Click(object sender, RoutedEventArgs e)
        {
            if(txbIngredientSearch.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please ensure you have entered an ingredient to search for");
            }
            else
            {
                foreach(Recipe r in recipes)
                {
                    foreach(Ingredient i in r.Ingredients)
                    {
                        if (i.Name.ToLower().Contains(txbIngredientSearch.Text.Trim().ToLower()))
                        {
                            filteredRecipes.Add(r);
                        }
                    }
                }
                errorHandling();
            }

            
        }

        //private helped method that checks a new ObservableCollection that is only populated with valid entries
        //against the users filter request
        //If there are no recipes added to the filteredRecipe list, display an error
        private void errorHandling()
        {
            if (filteredRecipes.Count == 0)
            {
                MessageBox.Show("There are no recipes with specified values");
            }
            else
            {
                ViewAllRecipes viewAllRecipes = new ViewAllRecipes(filteredRecipes, recipes);
                viewAllRecipes.Show();
                this.Close();
            }
        }

        //returns the user to the previous menu with all original recipes
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            ViewAllRecipes viewAllRecipes = new ViewAllRecipes(recipes);
            viewAllRecipes.Show();
            this.Close();
        }

        //Determines which food group has been selected then attempts to filter the recipes list against that value
        //If there are no ingredients with the food group selected, displayt an error
        //If it is successful, add recipes with valid ingredient food groups to new list and open View All Recipes with the filtered list
        private void btnFilterFoodGroup_Click(object sender, RoutedEventArgs e)
        {
            int selection = cmbFoodGroup.SelectedIndex;
            string search = "";
            switch (selection)
            {
                case -1:
                    MessageBox.Show("Please select an item from the list");
                    break;
                case 0:
                    search = "Starchy foods";
                    break;
                case 1:
                    search = "Vegetables and Fruits";
                    break;
                case 2:
                    search = "Legumes";
                    break;
                case 3:
                    search = "Meat products";
                    break;
                case 4:
                    search = "Dairy products";
                    break;
                case 5:
                    search = "Fats";
                    break;
                case 6:
                    search = "Water";
                    break;
            }

            foreach(Recipe r in recipes)
            {
                foreach(Ingredient i in r.Ingredients)
                {
                    if(i.FoodGroup == search)
                    {
                        filteredRecipes.Add(r);
                    }
                }
            }
            errorHandling();
        }

        //Takes the users input and compares all recipe total calories against it
        //If the user enters a value lower than any recipe, no recipes will appear
        //If the user enters an appropriate value the filteredRecipe list will be populated with valid
        //recipes and View All Recipes with the filtered list will be opened
        private void btnFilterCalories_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double maxCalories = int.Parse(txbMaxCalories.Text);
                double testCalories = 0;
                

                foreach (Recipe r in recipes)
                {
                    testCalories = 0;
                    foreach(Ingredient i in r.Ingredients)
                    {
                        testCalories += i.Calories;
                    }
                    
                    if(testCalories <= maxCalories)
                    {
                        filteredRecipes.Add(r);
                    }
                }
                MessageBox.Show("Test Calories: " + testCalories +"\n" +
                    "Max Calories: "+maxCalories);
                
                errorHandling();
            }
            catch 
            {
                MessageBox.Show("Please enter a valid number");
            }
        }
    }
}
