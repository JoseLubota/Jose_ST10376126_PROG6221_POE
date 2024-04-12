using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Jose_ST10376126_PROG6221_POE
{
    public class Recipe
    {
        public Recipe(int quantityIngridients, int numOfSteps)
        {
            ingridents = new string[quantityIngridients][];
            this.numberOfIngridient = quantityIngridients;

            steps = new string[numOfSteps][];
            this.stepsNumber = numOfSteps;
        }
        public Recipe() { }
        //--------------------------------------------------------------//
        ////
        public int numberOfIngridient { get; set; }
        public string name { get; set; }
        public int quantity { get; set; }
        public string unitOfMeasurement { get; set; }
        public string description { get; set; }
        public int stepsNumber { get; set; }
        public string[][] ingridents { get; set; }
        public string[][] steps { get; set; }
        double factor;
        List<double> ogQuantityValues { get; set; }

        //--------------------------------------------------------------//

        //-------------------------------
        public void enterIngridients()
        {
            for (int i = 0; i < numberOfIngridient; i++)
            {
                Console.WriteLine("------------------------");
                Console.Write("\nIngrident ", numberOfIngridient);

                Console.Write("\nEnter ingrident name - ");
                name = Console.ReadLine();

                Console.Write("\nEnter unit of measuremnt  - ");
                unitOfMeasurement = Console.ReadLine();

                Console.Write("\nEnter quantity of ingrident - ");
                quantity = Convert.ToInt32(Console.ReadLine());
                ogQuantityValues.Add(quantity);

                // Name - Quantity - Unit of Measurement
                ingridents[i] = new string[] { name, Convert.ToString(quantity), unitOfMeasurement };
                
            }
        }
        //--------------------------------
        public void enterSteps()
        {
            for (int i = 0; i < stepsNumber; i++)
            {
                Console.WriteLine("------------------------");
                Console.Write("\n Step ", i);

                Console.Write("\nEnter description - ");
                description = Console.ReadLine();

                steps[i] = new string[] { Convert.ToString(i+1), description };
               
            }
        }
        //--------------------------------
        public void printIngridients()
        {
            Console.WriteLine("Recipe");
            Console.WriteLine("-------------------------------------------\n");
            Console.WriteLine("Ingridients\n");
            // Name - Quantity - Unit of Measurement
            Console.WriteLine("| Name | Quantity | Unit of Measurement |\n");
            foreach (var rows in ingridents)
            {
                
                foreach (var item in rows)
                {
                    Console.Write("" + item + " | ");
                }
                Console.WriteLine(" ");

            }
        }
        //--------------------------------
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
        //--------------------------------
        public void scale()
        {
            Console.WriteLine("How would you like to change the ingridents quantity \n1-Half\n2-Double\n3-Triple\n - ");
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
            foreach (var rows in ingridents)
            {

                foreach (var item in rows)
                {
                    if (double.TryParse(item, out double itemToNum))
                    {
                        itemToNum = itemToNum * factor;
                        ingridents[row][col] = Convert.ToString(itemToNum);

                    }
                    col++;
                }
                row += 1;
                col = 0;

            }
          
        }
        //--------------------------------
        public void resetQuantity()
        {
            int row = 0, col = 0;  
            foreach (var rows in ingridents)
            {

                foreach (var item in rows)
                {
                    if (double.TryParse(item, out double dummy))
                    {
                        ingridents[row][col] = Convert.ToString(ogQuantityValues[row]);

                    }
                    col++;
                }
                row += 1;
                col = 0;
            }
        }
        //--------------------------------
        public void clearData()
        {
            ingridents = new string[numberOfIngridient][];
            steps = new string[stepsNumber][];
            Console.WriteLine("Data was seccusfully cleared!");
        }
        //--------------------------------
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
                    "\n3-Rest values to original ones"+
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

        //--------------------------------
        public void setArrayaSize()
        {
            Console.Write("Enter quantity of ingridients - ");
            numberOfIngridient = Convert.ToInt32(Console.ReadLine());

            Console.Write("\nEnter quantity of  steps - ");
            stepsNumber = Convert.ToInt32(Console.ReadLine());

            ingridents = new string[numberOfIngridient][];
            steps = new string[stepsNumber][];
            ogQuantityValues = new List<double> { };
           
        }
    }
}
//---------------------... END OF THE FILE...-------------------------------------//