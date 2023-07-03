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
        public static ObservableCollection<Recipe> recipes = new ObservableCollection<Recipe>();
        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(Recipe recipe)
        {
            InitializeComponent();
            recipes.Add(recipe);
        }

        public MainWindow(ObservableCollection<Recipe> inRecipes)
        {
            InitializeComponent();
            recipes = inRecipes;
        }

        private void btnViewAllRecipes_Click(object sender, RoutedEventArgs e)
        {
            ViewAllRecipes viewAllRecipes = new ViewAllRecipes(recipes);
            viewAllRecipes.Show();
            this.Close();
        }

        private void btnAddRecipe_Click(object sender, RoutedEventArgs e)
        {
            AddRecipe addRecipe = new AddRecipe();
            addRecipe.Show();
            this.Hide();
        }
    }
}
