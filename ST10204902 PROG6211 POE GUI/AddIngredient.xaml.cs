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
    /// Interaction logic for AddIngredient.xaml
    /// </summary>
    public partial class AddIngredient : Window
    {
        //Variable declarations
        ObservableCollection<String> foodGroups = new ObservableCollection<String>();
        public ObservableCollection<Ingredient> listIngredients = new ObservableCollection<Ingredient>();
        public ObservableCollection<String> listSteps = new ObservableCollection<String>();
        public static Ingredient ingredient = new Ingredient();

        //Parameterised constructor that accepts two ObservableCollections
        //Then fills the ComboBox with all Food Group options
        public AddIngredient(ObservableCollection<Ingredient> listIngredients, ObservableCollection<String> steps)
        {
            InitializeComponent();
            foodGroups.Add("1) Starchy foods (Eg: Rice, potatoes)");
            foodGroups.Add("2) Vegetables and Fruits (Eg: Apples, carrots, spinach, broccoli");
            foodGroups.Add("3) Legumes (Eg: Chickpeas, soy beans");
            foodGroups.Add("4) Meat products (Eg: Chicken, beef, eggs");
            foodGroups.Add("5) Dairy products (Eg: Milk, yoghurt, cheese");
            foodGroups.Add("6) Fats (Oil, butter)");
            foodGroups.Add("7) Water");
            cmbFoodGroup.ItemsSource = foodGroups;
            cmbFoodGroup.SelectedIndex = 0;

            this.listIngredients = listIngredients;
            this.listSteps = steps;
        }

        //Submit button event
        //Tries to validate all inputs as strings or doubles to then populate an ingredient
        //The ingredient is then passed to the AddRecipe constructor
        //Throw an error if data is invalid or strings empty
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ingredient = new Ingredient();
                ingredient.Name = txbName.Text;
                ingredient.Quantity = double.Parse(txbQuantity.Text);
                ingredient.UnitOfMeasurement = txbUnitOfMeasurement.Text;
                ingredient.Calories = double.Parse(txbCalories.Text);

                switch(cmbFoodGroup.SelectedIndex)
                {
                    case 0:
                        ingredient.FoodGroup = "Starchy foods";
                        break;
                    case 1:
                        ingredient.FoodGroup = "Vegetables and Fruits";
                        break;
                    case 2:
                        ingredient.FoodGroup = "Legumes";
                        break;
                    case 3:
                        ingredient.FoodGroup = "Meat products";
                        break;
                    case 4:
                        ingredient.FoodGroup = "Dairy products";
                        break;
                    case 5:
                        ingredient.FoodGroup = "Fats";
                        break;
                    case 6:
                        ingredient.FoodGroup = "Water";
                        break;
                }

                if(ingredient.Name.Equals("") || ingredient.UnitOfMeasurement.Equals(""))
                {
                    MessageBox.Show("Error: Please fill in all details\n" +
                        "Name must be present\n" +
                        "Quantity must be a number\n" +
                        "Unit of measurement must be present\n" +
                        "Calories must be a number");
                }
                else
                {
                    foreach(var item in listIngredients)
                    {
                        Console.WriteLine(item.Name);
                    }

                    listIngredients.Add(ingredient);
                    AddRecipe addRecipe = new AddRecipe(listIngredients, listSteps);
                    addRecipe.Show();
                    this.Close();
                }
            }
            catch(Exception ex) 
            {
                MessageBox.Show("Error: Please fill in all details\n" +
                        "Name must be present\n" +
                        "Quantity must be a number\n" +
                        "Unit of measurement must be present\n" +
                        "Calories must be a number");
            }

            
        }
    }
}
