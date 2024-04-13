﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Jose_ST10376126_PROG6221_POE
{
    // Creating a class that represents a recipe
    public class Recipe
    {
        //..................................................................................................................
        // Class Contructor
        public Recipe() { }
        //--------------------------------------------------------------//
        //................................. Variables/List/Arrays belonging to Recipe class
        // Indicates the number of ingrients in the recipe
        public int numberOfIngridient { get; set; }
        // Ingridient's name
        public string name { get; set; }
        // Ingridient's quantity
        public int quantity { get; set; }
        // Unit of measurement (tablespoon, cup, etc.) for ingridients
        public string unitOfMeasurement { get; set; }
        // Step's description
        public string description { get; set; }
        // Number of steps the recipe will have
        public int stepsNumber { get; set; }
        
        // Arrey to store ingridients
        public string[][] ingridients { get; set; }
        
        // Arrey to store steps
        public string[][] steps { get; set; }
        // Array to store ingridients
        double factor;
        // List to store original values of quantity
        List<double> ogQuantityValues { get; set; }
        // List to store original values of quantity
        List<string> ogUnitOfMeasurement { get; set; }



        //.......................................................Methods..................................................//

        //.............................................Inputs Methods..................................................//


        // Allows user to enter ingridients
        public void enterIngridients()
        {
            try
            {
                for (int i = 0; i < numberOfIngridient; i++)
                {
                    Console.WriteLine("------------------------");
                    Console.Write("\nIngrident ", numberOfIngridient);

                    Console.Write("\nEnter ingrident name - ");
                    name = Console.ReadLine();

                    Console.Write("\nEnter unit of measuremnt  - ");
                    unitOfMeasurement = Console.ReadLine();
                    ogUnitOfMeasurement.Add(unitOfMeasurement);   

                    Console.Write("\nEnter quantity of ingrident - ");
                    quantity = Convert.ToInt32(Console.ReadLine());
                    ogQuantityValues.Add(quantity);

                    // Name - Quantity - Unit of Measurement
                    ingridients[i] = new string[] { name, Convert.ToString(quantity), unitOfMeasurement };

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
                return;
            }

        }
        
        //----------------------------------------------------------------------------------------------------------------
        //Allows user to enter steps
        public void enterSteps()
        {
            try
            {
                for (int i = 0; i < stepsNumber; i++)
                {
                    Console.WriteLine("------------------------");
                    Console.Write("\n Step ", i);

                    Console.Write("\nEnter description - ");
                    description = Console.ReadLine();

                    steps[i] = new string[] { Convert.ToString(i + 1), description };

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();

            }

        }
        
        //----------------------------------------------------------------------------------------------------------------
        // Create input for user to set ingridients and steps size
        public void setArrayaSize()
        {
            Console.Write("Enter quantity of ingridients - ");
            numberOfIngridient = Convert.ToInt32(Console.ReadLine());

            Console.Write("\nEnter quantity of  steps - ");
            stepsNumber = Convert.ToInt32(Console.ReadLine());

            ingridients = new string[numberOfIngridient][];
            steps = new string[stepsNumber][];
            ogQuantityValues = new List<double> { };
            ogUnitOfMeasurement = new List<string> { };
        }



        //.............................................Printing Methods..................................................//
        //----------------------------------------------------------------------------------------------------------------
        // Print the ingridients
        public void printIngridients()
        {
            Console.WriteLine("Recipe");
            Console.WriteLine("-------------------------------------------\n");
            Console.WriteLine("Ingridients\n");
            // Name - Quantity - Unit of Measurement
            Console.WriteLine("| Name | Quantity | Unit of Measurement |\n");
            foreach (var rows in ingridients)
            {

                foreach (var item in rows)
                {
                    Console.Write("" + item + " | ");
                }
                Console.WriteLine(" ");

            }
        }
        //----------------------------------------------------------------------------------------------------------------
        //Print the steps
        public void printSteps()
        {
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Steps\n");

            // Step number - Descrition
            Console.WriteLine("| Step | Description |\n");
            foreach (var rows in steps)
            {
                var row = rows;
                foreach (var item in row)
                {
                    Console.Write("" + item + " | ");
                }
                Console.WriteLine(" ");

            }
            Console.WriteLine("-------------------------------------------");
        }


        
        //............................................Mixed Methods...................................................//
        //----------------------------------------------------------------------------------------------------------------
        // Create a loop to test all modules
        public void TestRecipe()
        {
            int option = 0;
            setArrayaSize();
            enterIngridients();
            enterSteps();
            while (true)
            {
                Console.WriteLine("-----------------------------------------------");
                Console.Write("Choose the operatio you'd like to do" +
                    "\n1-Print the Recipe" +
                    "\n2-Scale quantity of ingridients" +
                    "\n3-Rest values to original ones" +
                    "\n4-Clear all data\n5-Stop program\n - ");
                option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        printIngridients();
                        printSteps();
                        break;
                    case 2:
                        scale();
                        printIngridients();
                        break;
                    case 3:
                        resetQuantity();
                        break;
                    case 4:
                        clearData();
                        setArrayaSize();
                        enterIngridients();
                        enterSteps();
                        break;
                    case 5:
                        return;
                    default:
                        break;

                }
                Console.ReadLine();
            }

        }
        
        
        
        
        //............................................Operative Methods..................................................//
        //----------------------------------------------------------------------------------------------------------------
        //  Reset the ingridient quantity to their first values
        public void resetQuantity()
        {
            int row = 0, col = 0;
            foreach (var rows in ingridients)
            {

                foreach (var item in rows)
                {
                    if (double.TryParse(item, out double dummy))
                    {
                        ingridients[row][col] = Convert.ToString(ogQuantityValues[row]);
                        ingridients[row][col + 1] = ogUnitOfMeasurement[row];


                    }
                    col++;
                }
                row += 1;
                col = 0;
            }
        }
        //----------------------------------------------------------------------------------------------------------------
        // Clear ingridients and steps array
        public void clearData()
        {
            ingridients = new string[numberOfIngridient][];
            steps = new string[stepsNumber][];
            Console.WriteLine("Data was seccusfully cleared!");
        }
        //----------------------------------------------------------------------------------------------------------------
        // Allow the user to multiply the quantity of ingridients by (0.5, 2, 3) times
        public void scale()
        {
            Console.WriteLine("How would you like to change the ingridients quantity \n1-Half\n2-Double\n3-Triple\n - ");
            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    factor = 0.5;
                    break;
                case 2:
                    factor = 2;
                    break;
                case 3:
                    factor = 3;
                    break;
                default:
                    factor = 1;
                    break;
            }

            int row = 0, col = 0;
            foreach (var rows in ingridients)
            {

                foreach (var item in rows)
                {
                    if (double.TryParse(item, out double itemToNum))
                    {
                        
                        itemToNum = itemToNum * factor;
                        if (itemToNum >= 16)
                        {
                            itemToNum = itemToNum / 16;
                            if (ingridients[row][col+1] == "tablespoon")
                            {
                               ingridients[row][col + 1] = "Cup";
                            }
                        }
                        ingridients[row][col] = Convert.ToString(itemToNum);

                    }
                    col++;
                }
                row += 1;
                col = 0;

            }

        }
    }
}
//---------------------------------------------... END OF THE FILE...----------------------------------------------------//