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
    /// Interaction logic for ViewAllRecipes.xaml
    /// </summary>
    /// 
    
    public partial class ViewAllRecipes : Window
    {
        public static List<Recipe> Recipes = new List<Recipe>();
        public ViewAllRecipes()
        {
            InitializeComponent();
            checkRecipes();
            listViewRecipes.ItemsSource = Recipes;
        }

        public void checkRecipes()
        {
            if(Recipes.Count == 0)
            {
                lblError.Content = "There are no recipes added currently";
                
            }
        }
    }
}
