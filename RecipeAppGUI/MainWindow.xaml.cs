/* Jose Lubota
 * Student Number: ST10376126
 * Group: 2
 * References:
 *          https://www.w3schools.blog/c-sharp-list
 *          https://www.w3schools.com/cs/cs_arrays_loop.php
 *          https://web-p-ebscohost-com.ezproxy.iielearn.ac.za/ehost/ebookviewer/ebook/bmxlYmtfXzI5MTc3MDFfX0FO0?sid=f5055d80-d4b0-4010-9877-c1a2d34945af@redis&vid=0&format=EB&lpid=lp_xlv&rid=0     

 */
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using Jose_ST10376126_PROG6221_POE.Class;
using System.Windows.Documents;
using System.IO;
using Microsoft.Win32;

namespace RecipeAppGUI
{
    public partial class MainWindow : Window
    {
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        // Create List Recipes that will contain all recipes
        //Note the recipe class is in Jose_ST10376126_PROG6221_POE.Class
        List<Recipe> recipes = new List<Recipe>();
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        //It makes the Interface run with all its elements
        public MainWindow()
        {
            InitializeComponent();
        }

        //......................................................... METHODS TO INSERT VALUES...............................................................................................//


        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        // Get the data from a form and create a new recipe ingridient list
        private void AddIngredientButton_Click(object sender, RoutedEventArgs e)
        {
            string recipeName = RecipeNameInput.Text;
            string ingridientName = IngridientInput.Text;
            string unitOfMeasurement = UnitofMeasurementInput.Text;
            double quantity = Convert.ToDouble(QuantityInput.Text);
            ComboBoxItem selectedItem = (ComboBoxItem)FoodGroupList.SelectedItem;
            string foodGroup = selectedItem != null ? selectedItem.Content.ToString() : string.Empty;
            double calories = Convert.ToDouble(CaloriesInput.Text);
            Ingridient ingridient = new Ingridient(recipeName, ingridientName, quantity, unitOfMeasurement, foodGroup, calories);

            Recipe recipe = recipes.FirstOrDefault(r => r.recipeName == recipeName);
            if (recipe == null)
            {
                recipe = new Recipe { recipeName = recipeName };
                recipes.Add(recipe);
            }
            recipe.recipeIngridient.Add(ingridient);

            string ingridientDetails = $"Recipe Name: {recipeName}, Ingridient: {ingridientName}, Unit of Measurement: {unitOfMeasurement}, Quantity: {quantity}";
            addRecipeNameToComboBox(recipeName);
            MessageBox.Show(ingridientDetails, "ingridientDetails");

        }
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        // Get the data from a form and create a new recipe step list
        private void AddStepButton_Click(object sender, RoutedEventArgs e)
        {
            string recipeName = RecipeNameInput.Text;
            double stepnumber = Convert.ToDouble(StepNumberInput.Text);
            string description = DescriptionInput.Text;
            Steps step = new Steps(recipeName, description, stepnumber);
            Recipe recipe = recipes.FirstOrDefault(r => r.recipeName == recipeName);
            if (recipe == null)
            {
                recipe = new Recipe { recipeName = recipeName };
                recipes.Add(recipe);
            }
            recipe.recipeSteps.Add(step);
            string descriptionDetails = $"Recipe Name: {recipeName}, Step Number {stepnumber}, Description {description}";
            addRecipeNameToComboBox(recipeName);
            MessageBox.Show(descriptionDetails, "Description Details");
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        //Add the recipe name and quantity of steps to a combo box item
        private void addRecipeNameToComboBox(string name)
        {
            List<double> listQuantityOfStepNumeber = new List<double>();
            int quantityOfStepNumeber = 0;
            foreach (var recipe in recipes)
            {
                foreach (var step in recipe.recipeSteps)
                {
                    if (step.recipeName != null && step.recipeName.Equals(name))
                    {
                        listQuantityOfStepNumeber.Add(step.stepNumber);
                        quantityOfStepNumeber = listQuantityOfStepNumeber.Count;

                    }
                }

            }
            string newItem = $"Recipe Name: {name} Quantity of Steps: {quantityOfStepNumeber}";
            bool itemUpdated = false;
            List<string> items = new List<string>();
            for (int i = 0; i < RecipeSearchComboBox.Items.Count; i++)
            {
                string currentItem = RecipeSearchComboBox.Items[i].ToString();
                if (currentItem.StartsWith($"Recipe Name: {name}"))
                {
                    items.Add(newItem);
                    itemUpdated = true;

                }
                else
                {
                    items.Add(currentItem);
                }
            }
            if (!itemUpdated)
            {
                items.Add(newItem);
            }
            items.Sort();
            RecipeSearchComboBox.Items.Clear();
            foreach (var item in items)
            {
                RecipeSearchComboBox.Items.Add(item);
            }

        }

        //................................................................ METHODS TO SEARCH AND DISPLAY....................................................................................//


        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        //Get a field input filter and return a recipe 
        private void SearchRecipe_IngredientName_Button_Click(object sender, RoutedEventArgs e)
        {
            string ingridientName = RecipeNameSearch.Text;
            foreach (var recipe in recipes)
            {
                foreach (var ingridient in recipe.recipeIngridient)
                {
                    if (ingridient.name.Equals(ingridientName))
                    {
                        string message = $"Recipe Name: {ingridient.recipeName}, " +
                            $"\nIngridient: {ingridient.name}, " +
                            $"\nUnit of Measurement: {ingridient.unitOfMeasurement}, " +
                            $"\nQuantity: {ingridient.quantity}" +
                            $"\nCalories: {ingridient.calories}";
                        MessageBox.Show(message, "Ingridients");
                    }
                }


            }
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        // Get a field input filter and return a recipe 
        private void SearchRecipe_Calories_Button_Click(object sender, RoutedEventArgs e)
        {
            double calories = Convert.ToDouble(CaloriesSearch.Text);
            foreach (var recipe in recipes)
            {
                foreach (var ingridient in recipe.recipeIngridient)
                {
                    if (ingridient.calories <= calories)
                    {
                        string message = $"Recipe Name: {ingridient.recipeName}, " +
                            $"\nIngridient: {ingridient.name}, " +
                            $"\nUnit of Measurement: {ingridient.unitOfMeasurement}, " +
                            $"\nQuantity: {ingridient.quantity}" +
                            $"\nCalories: {ingridient.calories}";
                        MessageBox.Show(message, "Ingridients");
                    }

                }

            }
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        //Get a field input filter and return a recipe 
        private void SearchRecipe_FoodGroup_Button_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)FoodGroupSearch.SelectedItem;
            if (selectedItem != null)
            {
                string foodGroup = selectedItem.Content.ToString();
                foreach (var recipe in recipes)
                {
                    foreach (var ingridient in recipe.recipeIngridient)
                    {
                        if (ingridient.foodGroup != null && ingridient.foodGroup.Equals(foodGroup))
                        {
                            string message = $"Recipe Name: {ingridient.recipeName}, " +
                            $"\nIngridient: {ingridient.name}, " +
                            $"\nUnit of Measurement: {ingridient.unitOfMeasurement}, " +
                            $"\nQuantity: {ingridient.quantity}," +
                            $"\nFood Group: {ingridient.foodGroup}" +
                            $"\nCalories: {ingridient.calories}";
                            MessageBox.Show(message, "Ingridients");
                        }

                    }
                }

            }
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        // Based on item selected on combo box display recipe ingredients
        private void DisplayIngridients(Recipe recipe)
        {
            IngridientsPanel.Children.Clear();
            foreach (var ingridient in recipe.recipeIngridient)
            {
                TextBlock ingridientText = new TextBlock
                {
                    Text = $"  Recipe Name: {ingridient.recipeName} " +
                        $"\n  Ingridient: {ingridient.name} " +
                        $"\n  Unit of Measurement: {ingridient.unitOfMeasurement}, " +
                        $"\n  Quantity: {ingridient.quantity}" +
                        $"\n  Food Group: {ingridient.foodGroup}         " +
                        $"\n  Calories: {ingridient.calories} \n\n",
                    FontSize = 15
                };
                IngridientsPanel.Children.Add(ingridientText);
            }
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        //Based on item selected on combo box display recipe steps
        private void DisplaySteps(Recipe recipe)
        {
            StepsPanel.Children.Clear();
            if (recipe == null) return;
            foreach (var step in recipe.recipeSteps)
            {
                StackPanel stepPanel = new StackPanel { Orientation = Orientation.Horizontal };
                CheckBox stepCheckBox = new CheckBox
                {
                    Margin = new Thickness(5, 0, 5, 0)
                };
                TextBlock stepText = new TextBlock
                {
                    Text = $"Step {step.stepNumber}",
                    Width = 100
                };
                Button showDescriptionButton = new Button
                {
                    Content = "Show Description",
                    Tag = step.stepDescription,
                    Width = 120,
                    Margin = new Thickness(5, 0, 0, 0),

                };
                showDescriptionButton.Click += showDescriptionButton_Click;
                stepPanel.Children.Add(stepCheckBox);
                stepPanel.Children.Add(stepText);
                stepPanel.Children.Add(showDescriptionButton);
                StepsPanel.Children.Add(stepPanel);
            }
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        // Display a recipe step description
        private void showDescriptionButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string description = button.Tag as string;
            MessageBox.Show(description, "Step Description");


        }

        //.................................. Operations OR Methods that made other methods work.........................................................................................//

        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        //Extract recipe name from combo box item
        private string ExtractRecipeName(string comboBoxItem)
        {
            string[] parts = comboBoxItem.Split(new[] { "Recipe Name: ", "Quantity of Steps: " }, StringSplitOptions.None);
            return parts.Length > 1 ? parts[1].Trim() : string.Empty;
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        // Check combo box item and return the selected recipe to some methods
        private void RecipeSearchComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (RecipeSearchComboBox.SelectedItem == null) return;
            string selectedItem = RecipeSearchComboBox.SelectedItem.ToString();
            string recipeName = ExtractRecipeName(selectedItem);
            Recipe selectedRecipe = recipes.FirstOrDefault(r => r.recipeName == recipeName);
            if (selectedRecipe != null)
            {
                DisplayIngridients(selectedRecipe);
                DisplaySteps(selectedRecipe);
            }
            else
            {
                MessageBox.Show("Recipe not found", "Selected Recipe");
            }
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        // Allows user to download a user manual
        private void HyperLink_Click(object sender, RoutedEventArgs e)
        {
            string documentPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "resources", "user-guide.pdf");            
            if (File.Exists(documentPath))
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    FileName = "user-guide.pdf",
                    Filter="PDF files (*.pdf)| *.pdf| All files (*.*)|*.*"
                };
                if (saveFileDialog.ShowDialog() == true)
                {
                    File.Copy(documentPath, saveFileDialog.FileName, true);
                    MessageBox.Show("Download complete.", "Download", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Document not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
             

        }

        //...................................... Checkers - Methods that verify the something meets a criteria.................................................................................//


        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        // Check if Quantity field meets criteria
        private void Quantity_CheckDoubleInput(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(QuantityInput.Text))
            {
                if (double.TryParse(QuantityInput.Text, out double quantity))
                {
                    if (quantity <= 0)
                    {
                        MessageBox.Show($"Please enter a positive number", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                        QuantityInput.Focus();
                        QuantityInput.Text = "1";

                    }
                }
                else
                {
                    MessageBox.Show("Please enter a number and not characters.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                    QuantityInput.Text = "1";
                    QuantityInput.Focus();
                }
            }

        }
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        //Check if Quantity field meets criteria
        private void StepNumber_CheckDoubleInput(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(StepNumberInput.Text))
            {
                if (double.TryParse(StepNumberInput.Text, out double stepNumber))
                {
                    if (stepNumber <= 0)
                    {
                        MessageBox.Show($"Please enter a positive number", "Invalid Input - Step Number Field", MessageBoxButton.OK, MessageBoxImage.Warning);
                        StepNumberInput.Focus();
                        StepNumberInput.Text = "1";

                    }

                }
                else
                {
                    MessageBox.Show("Please enter a number and not characters.", "Invalid Input - Step Number Field", MessageBoxButton.OK, MessageBoxImage.Warning);
                    StepNumberInput.Text = "1";
                    StepNumberInput.Focus();
                }

            }

        }
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        //Check if Quantity field meets criteria
        private void Calories_CheckDoubleInput(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(CaloriesInput.Text))
            {
                if (double.TryParse(CaloriesInput.Text, out double calories))
                {
                    if (calories < 0)
                    {
                        MessageBox.Show($"Please enter 0 or a positive number", "Invalid Input - Calories Field", MessageBoxButton.OK, MessageBoxImage.Warning);
                        CaloriesInput.Focus();
                        CaloriesInput.Text = "0";

                    }

                }
                else
                {
                    MessageBox.Show("Please enter a number and not characters.", "Invalid Input - Calories Field", MessageBoxButton.OK, MessageBoxImage.Warning);
                    CaloriesInput.Focus();
                    CaloriesInput.Text = "0";

                }

            }

        }
    }
}
//..............................................END OF THE FILE....................................................................................................................................................//