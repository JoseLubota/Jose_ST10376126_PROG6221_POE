using System;
using System.Collections.Generic;
using System.Linq;  
using System.Text;
using System.Threading.Tasks;

namespace Jose_ST10376126_PROG6221_POE.Class
{
//....................................................................................................................
    //Class Step
    public class Steps : Recipe
    {
//.........................................................................................................................
        //Class Constructor
        public Steps(string recipeName, string description, double stepNumber)
        {
            this.recipeName = recipeName;
            this.stepDescription = description;
            this.stepNumber = stepNumber;
        } 
    }
    
}
//...........................................END OF FILE..................................................................................
