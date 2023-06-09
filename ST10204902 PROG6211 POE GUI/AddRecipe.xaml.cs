﻿using System;
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
    /// Interaction logic for AddRecipe.xaml
    /// </summary>
    public partial class AddRecipe : Window
    {
        public ObservableCollection<Ingredient> listIngredients = new ObservableCollection<Ingredient>();
        public ObservableCollection<String> listSteps = new ObservableCollection<String>();
        public ObservableCollection<String> listIngredientNames = new ObservableCollection<String>();
        public int stepCount = 0;

        //Generic constructor for first time application launch
        public AddRecipe()
        {
            InitializeComponent();
            listBoxIngredients.ItemsSource = listIngredients;
            listBoxSteps.ItemsSource = listSteps;
            stepCount = 0;
        }

        //Parameterised constructor to allow data control between opening and closing of windows
        public AddRecipe(ObservableCollection<Ingredient> listIngredients, ObservableCollection<String> listSteps)
        {
            InitializeComponent();
            this.listIngredients = listIngredients;
            this.listSteps = listSteps;
            updateListOfIngredients();
            stepCount = 0;
            listBoxSteps.ItemsSource = listSteps;
        }

        //Takes the string value from the text box labeled txbStep and adds it to an ObservableCollection<String> to display in the list
        private void btnAddStep_Click(object sender, RoutedEventArgs e)
        {
            if(txbStep.Text.Length == 0 )
            {
                MessageBox.Show("Please enter text into the step text box before attempting to add a new step");
            }
            else
            {
                
                stepCount++;
                string temp = stepCount+") " +txbStep.Text.ToString();
                listSteps.Add(temp);
                listBoxSteps.ItemsSource = listSteps;
            }

        }

        //Returns the user to the previous menu
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }


        //Opens the AddIngredient Window and passes the ObservableCollection of ingredients and steps
        private void btnAddIngredient_Click(object sender, RoutedEventArgs e)
        {
            AddIngredient addIngredient = new AddIngredient(listIngredients, listSteps);
            addIngredient.Show();
            this.Close();
        }

        //Private helped method that updates the ingredients within a list
        private void updateListOfIngredients()
        {
            foreach(Ingredient ingredients in listIngredients)
            {
                listIngredientNames.Add(ingredients.Name);
                
            }
            listBoxIngredients.ItemsSource = listIngredientNames;
        }

        //Checks if a user has input all data then adds the data to a list, the list is then passed to MainWindow
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(txbName.Text.Equals("") || listIngredients.Count == 0 ||listSteps.Count == 0)
                {
                    MessageBox.Show("Please ensure you have the following:\n" +
                                "A name entered for the Recipe\n" +
                                "At least one ingredient added\n" +
                                "At least one step added");
                }
                else
                {
                    Recipe r = new Recipe();
                    r.Name =txbName.Text;
                    r.Ingredients = listIngredients.ToList<Ingredient>();
                    r.Steps = listSteps.ToList<String>();

                    MainWindow mainWindow = new MainWindow(r);
                    mainWindow.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please ensure you have the following:\n" +
                                "A name entered for the Recipe\n" +
                                "At least one ingredient added\n" +
                                "At least one step added");
            }
        }
    }
}
