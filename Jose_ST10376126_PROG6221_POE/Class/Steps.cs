using System;
using System.Collections.Generic;
using System.Linq;  
using System.Text;
using System.Threading.Tasks;

namespace Jose_ST10376126_PROG6221_POE.Class
{
    public class Steps
    {
        // Step's description
        public string description { get; set; }
        // Number of steps the recipe will have
        public int stepNumber { get; set; }
        // Number of steps the recipe will have
        public string recipeName { get; set; }
        public Steps(string recipeName, string description, int stepNumber)
        {
            this.recipeName = recipeName;
            this.description = description;
            this.stepNumber = stepNumber;
        } 
    }
    
}
