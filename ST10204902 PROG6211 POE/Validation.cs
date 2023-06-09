﻿using System;

namespace ST10204902_PROG6211_POE
{
    //Delegate methods to run validation

    internal class Validation
    {
        //Validation methods
        //Accepts a string and returns a double if the value is of the correct type
        public static double validateDouble(string input)
        {
            double value = 0;
            try
            {
                while (double.TryParse(input, out value) == false)
                {
                    Console.WriteLine("\nPlease ensure your input is of the correct type.");
                    Console.WriteLine("Enter a number: ");
                    input = Console.ReadLine();
                }
            }
            catch (OverflowException e) //ensure number is between correct values
            {
                Console.WriteLine("Error occurred, number is too large or too small");
                Console.WriteLine("Please ensure the value is between " + Double.MinValue + " and " + Double.MaxValue);
                Console.WriteLine("Enter a number:");
                validateDouble(input);
            }
            return value;
        }

        //Accepts a string and returns a string if there is a value and it is not empty
        public static string validateString(string input)
        {
            while (string.IsNullOrEmpty(input) == true)
            {
                Console.WriteLine("\nPlease ensure your input is of the correct type.");
                Console.WriteLine("Please enter a string:");
                input = Console.ReadLine();
            }

            return input;
        }

        //Accepts a string and returns an integer if the value is of the correct type
        public static int validateInt(string input)
        {
            int value = 0;
            try
            {
                while (int.TryParse(input, out value) == false)
                {
                    Console.WriteLine("Error occurred, number is too large or too small");
                    Console.WriteLine("Please ensure the value is between " + Int32.MinValue + " and " + Int32.MaxValue);
                    Console.WriteLine("Enter a number:");
                    input = Console.ReadLine();
                }
            }
            catch (OverflowException e)//Ensure number is between correct values
            {
                validateInt(input);
            }

            if (value < 0)
            {
                validateInt(input);
            }

            return value;
        }

        //accepts an integer and returns an integer for a food type that is converted to a string in NewMain
        public static int validateFoodGroup (string  value)
        {
            int temp = Validation.validateInt(value);
            while (temp < 1 || temp > 7)
            {
                Console.WriteLine("\n Invalid option entered for food group, please enter a value between 1 and 7");
                temp = Validation.validateInt(Console.ReadLine());
            }
            return temp;
        }

        //Accepts a string and only exits once yes or no has been typed
        //Returns a yes or no string only
        public static string returnYesNo(string input)
        {

            while (input.Equals("yes") == false && input.Equals("no") == false)
            {
                Console.WriteLine("\nInvalid option entered, please enter yes or no");
                input = Console.ReadLine();
            }
            return input;
        }

        //Accepts a string input, converts it to an integer, if the integer is out of the 1-4 range, reprompt the user
        //If the input is valid, return an integer
        public static int validateOption(string input)
        {
            int test = Validation.validateInt(input);

            while (test < 1 || test > 4)
            {
                Console.WriteLine("\nInvalid option entered for menu selection, please try again");
                test = Validation.validateInt(Console.ReadLine());
            }

            return test;

        }


    }
}
