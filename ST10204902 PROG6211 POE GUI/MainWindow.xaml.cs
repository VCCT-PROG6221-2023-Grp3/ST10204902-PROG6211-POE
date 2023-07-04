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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ST10204902_PROG6211_POE_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Variable declarations
        public static ObservableCollection<Recipe> recipes = new ObservableCollection<Recipe>();
        
        //default constructor for first launch
        public MainWindow()
        {
            InitializeComponent();
        }
        
        //parameterised constructor that allows for recipes to be passed and added to the list

        public MainWindow(Recipe recipe)
        {
            InitializeComponent();
            recipes.Add(recipe);
        }

        //parameterised constructor that accepts an ObservableCollection to maintain data between windows
        public MainWindow(ObservableCollection<Recipe> inRecipes)
        {
            InitializeComponent();
            recipes = inRecipes;
        }

        //Opens the View All Recipes window and passes all recipes to it
        private void btnViewAllRecipes_Click(object sender, RoutedEventArgs e)
        {
            ViewAllRecipes viewAllRecipes = new ViewAllRecipes(recipes);
            viewAllRecipes.Show();
            this.Close();
        }

        //Opens the Add Recipe window, passing no variables
        private void btnAddRecipe_Click(object sender, RoutedEventArgs e)
        {
            AddRecipe addRecipe = new AddRecipe();
            addRecipe.Show();
            this.Hide();
        }

        //Closes the application after thanking the user for using the application
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Thank you for using my Application");
            Environment.Exit(0);
        }
    }
}
