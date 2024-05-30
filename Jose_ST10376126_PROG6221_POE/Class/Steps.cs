/* Jose Lubota
 * Student Number: ST10376126
 * Group: 2
 * References:
 *       https://www.w3schools.blog/c-sharp-list
 *       https://web-p-ebscohost-com.ezproxy.iielearn.ac.za/ehost/ebookviewer/ebook/bmxlYmtfXzI5MTc3MDFfX0FO0?sid=f5055d80-d4b0-4010-9877-c1a2d34945af@redis&vid=0&format=EB&lpid=lp_xlv&rid=0     
 */

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
