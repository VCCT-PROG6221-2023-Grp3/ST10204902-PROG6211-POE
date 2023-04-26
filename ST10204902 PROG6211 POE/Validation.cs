using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10204902_PROG6211_POE
{
    //Delegate methods to run validation
    
    internal class Validation
    {
        

        //Validation methods

        //Accepts a string and returns a double if the value is of the correct type
        public static double validateDouble(string input)
        {
            double value=0;
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
            while(string.IsNullOrEmpty(input)==true)
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
            int value=0;
            try
            {
                while (int.TryParse(input, out value) == false)
                {
                    /*Console.WriteLine("\nPlease ensure your input is of the correct type.");
                    Console.WriteLine("Also ensure the number is not negative or 0");
                    Console.WriteLine("Enter a number");*/

                    Console.WriteLine("Error occurred, number is too large or too small");
                    Console.WriteLine("Please ensure the value is between " + Int32.MinValue + " and " + Int32.MaxValue);
                    Console.WriteLine("Enter a number:");
                    input = Console.ReadLine();
                }
                
            }
            catch (OverflowException e)//ensure number is between correct values
            {
                
                validateInt(input);
            }
        
            if(value<=0)
            {
                validateInt(input);
            }

            return value;
        }

        //accepts a string and only exits once yes or no has been typed
        //returns a yes or no string only
        public static string returnYesNo (string input)
        {
            if (input.Equals("yes") == false && input.Equals("no") == false)
            {
                Console.WriteLine("\nInvalid option entered, please enter yes or no");
                
            }
            return input;
        }

        public static int validateOption(string input)
        {
            int test = Validation.validateInt(input);

            while(test<=1 && test>=4)
            {
                Console.WriteLine("\nInvalid option entered, please try again");
                test = Validation.validateInt(Console.ReadLine());
                
            }

            return test;
            
        }
    }
}
