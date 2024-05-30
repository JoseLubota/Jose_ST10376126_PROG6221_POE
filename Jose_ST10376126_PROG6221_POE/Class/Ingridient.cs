/* Jose Lubota
 * Student Number: ST10376126
 * Group: 2
 * References:
 *          https://www.w3schools.blog/c-sharp-list
 *          https://www.w3schools.com/cs/cs_arrays_loop.php
 *          https://web-p-ebscohost-com.ezproxy.iielearn.ac.za/ehost/ebookviewer/ebook/bmxlYmtfXzI5MTc3MDFfX0FO0?sid=f5055d80-d4b0-4010-9877-c1a2d34945af@redis&vid=0&format=EB&lpid=lp_xlv&rid=0     
 *          https://sweetlife.org.za/how-much-to-eat-to-lose-weight/
 *          https://learn.microsoft.com/en-us/dotnet/api/system.eventhandler?view=net-8.0
 *          https://www.c-sharpcorner.com/article/event-handling-in-net-using-C-Sharp/
 */
using System;
namespace Jose_ST10376126_PROG6221_POE.Class
{
    //.............................................................................................................................................................................................................................    
    // Delegate for handling caliries exceeded event
    public delegate void CaloriesEventHandler(object sender, EventArgs e);

    // Ingridient class
    public class Ingridient : Recipe
    {
//..................................................................................................................................................................................................................................................................................    
        //................................. Variables/List/Arrays belonging to Recipe class....................................................................................................................................................................................

        // Ingridient calories
        private double _calories {  get; set; } 

        // Checking calories to trigger the delegate if a condition is met
        public double calories
        {
            get => _calories;
            set
            {
                if(value > 300)
                {
                    _calories = value;
                    OnCaloriesExceeded(EventArgs.Empty);
                    provideCaloriesMeaning();
                }
                else
                {
                    _calories = value;
                }
            }
        }
        
        // Event to handle calories exceeded
        public static event CaloriesEventHandler CaloriesExceeded;

//...................................................................................................................................................    
        
        //Class Contructor
        public Ingridient(string recipeName, string name, double quantity, string measurement, string foodGroup, double calories)
        {
            this.recipeName = recipeName;
            this.name = name;
            this.quantity = quantity;
            unitOfMeasurement = measurement;
            this.foodGroup = foodGroup;
            this.calories = calories;
        }
        public Ingridient() { }
//....................................................................................................................................................................................    
//.......................................................Methods......................................................................................................................................................//

        // Method to trigger the CaloriesExceeded event
        protected virtual void OnCaloriesExceeded(EventArgs e)
        {
            CaloriesExceeded?.Invoke(this, e);
        }
        // Event  handler for cCaloriesExceeded event
        public static void Ingridient_CaloriesExceeded(object sender, EventArgs e)
        {
           Console.ForegroundColor = ConsoleColor.Red;
           Console.WriteLine("**********************************************");
           Console.WriteLine(" Warning: Total calories have exceeded 300! ");
           Console.WriteLine("**********************************************");
           
           Console.ForegroundColor = ConsoleColor.White;
        }
        // Check current calories value and print a meaning
        public void provideCaloriesMeaning() 
        {
            Console.WriteLine("Meaning of the calories quantity\n");
            if (calories >= 5000)
            {
                Console.WriteLine("Current calories: " + calories + "\nUnsustainable for most people but sometimes associated with bodybuilders");
            }
            else if (calories >= 4000)
            {
                Console.WriteLine("Current calories: " + calories + "\nUnsustainable for most people but sometimes associated competite eating or bulking");
            }
            else if (calories >= 3000)
            {
                Console.WriteLine("Current calories: " + calories + "\nWhat atletes or people with calories expenditures consume");
            }
            else if (calories >= 2000)
            {
                Console.WriteLine("Current calories: " + calories + "\nNormally what an average adult consumes daily");
            }else if(calories >= 1000)
            {
                Console.WriteLine("Current calories: " + calories + "\nNormally a very large meal");
            }
            else if(calories >= 500)
            {
                Console.WriteLine("Current calories: " + calories + "\nNormally the principal meal of the day or fast food with some extras");
            }else if(calories >= 400)
            {
                Console.WriteLine("Current calories: " + calories + "\nNormally a meduim port meal, like a sandwich with beef and vegetables");
            }
            else if(calories >= 300)
            {
                Console.WriteLine("Current calories: " + calories + "\nA light breakfast");
            }
            else if (calories >= 200)
            {
                Console.WriteLine("Current calories: " + calories + "\n Foods like a sandwich or a small serving of yougurt");
            }
            else if (calories >= 100)
            {
                Console.WriteLine("Current calories: " + calories + "\nSmall snacks like an apple, orange,etc.");
            }
        }    
        
    }
}
//...........................................END OF FILE..................................................................................
