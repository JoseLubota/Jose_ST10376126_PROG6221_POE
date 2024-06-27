using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using Jose_ST10376126_PROG6221_POE.Class;

namespace RecipeAppGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        //-------------------------------------------------
        List<Recipe> recipes = new List<Recipe>();  
        //-------------------------------------------------
        public MainWindow()
        {
            InitializeComponent();
        }
        
        //......................................................... METHODS TO INSERT VALUES...............................................................................................//

        
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        //-------------------------------------------------
        private void AddIngridientButton_Click(object sender, RoutedEventArgs e)
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
        //-------------------------------------------------
        private void AddStepButton_Click(object sender, RoutedEventArgs e)
        {
            string recipeName = RecipeNameInput.Text;
            double stepnumber = Convert.ToDouble(StepNumberInput.Text);
            string description = DescriptionInput.Text;
            Steps step = new Steps(recipeName, description, stepnumber);
            Recipe recipe = recipes.FirstOrDefault(r => r.recipeName == recipeName);
            if(recipe == null)
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
        //-------------------------------------------------
        private void addRecipeNameToComboBox(string name)
        {
            List<double> listQuantityOfStepNumeber = new List<double>();
            int quantityOfStepNumeber = 0;
            foreach (var lists in recipes)
            {
                if (lists.recipeName != null)
                {
                    if (lists.recipeName.Equals(name))
                    {
                        listQuantityOfStepNumeber.Add(lists.stepNumber);
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
        //--- Neeed update
        private void SearchRecipe_IngridientName_Button_Click(object sender, RoutedEventArgs e)
        {
            string ingridientName = RecipeNameSearch.Text;
            foreach(var recipe in recipes)
            {
                foreach (var ingridient in recipe.recipeIngridient)
                {
                    if (ingridient.name.Equals(ingridientName))
                    {
                        string message = $"Recipe Name: {ingridient.recipeName}, " +
                            $"\nIngridient: {ingridient.name}, " +
                            $"\nUnit of Measurement: {ingridient.unitOfMeasurement}, " +
                            $"\nQuantity: {ingridient.quantity}"+
                            $"\nCalories: {ingridient.calories}";
                        MessageBox.Show(message, "Ingridients");
                    }
                }
                

            }    
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        //------ Need update
        private void SearchRecipe_Calories_Button_Click(object sender, RoutedEventArgs e)
        {
            double calories = Convert.ToDouble(CaloriesSearch.Text);
            foreach (var recipe in recipes)
            {
                foreach(var ingridient in recipe.recipeIngridient)
                {
                    if (ingridient.calories <= calories)
                    {
                        string message = $"Recipe Name: {ingridient.recipeName}, " +
                            $"\nIngridient: {ingridient.name}, " +
                            $"\nUnit of Measurement: {ingridient.unitOfMeasurement}, " +
                            $"\nQuantity: {ingridient.quantity}"+
                            $"\nCalories: {ingridient.calories}";
                        MessageBox.Show(message, "Ingridients");
                    }

                }
                    
            }
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        //
        private void SearchRecipe_FoodGroup_Button_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)FoodGroupSearch.SelectedItem;
            if (selectedItem != null) 
            {
                string foodGroup = selectedItem.Content.ToString();
                foreach(var recipe in recipes)
                {
                    foreach(var ingridient in recipe.recipeIngridient)
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
        //-------------------------------------------------
        private void DisplayIngridients(Recipe recipe)
        {
            IngridientsPanel.Children.Clear();
            foreach (var ingridient in recipe.recipeIngridient)
            {
                TextBlock ingridientText = new TextBlock
                {
                    Text = $"Recipe Name: {ingridient.recipeName}, " +
                        $"\nIngridient: {ingridient.name}, " +
                        $"\nUnit of Measurement: {ingridient.unitOfMeasurement}, " +
                        $"\nQuantity: {ingridient.quantity}," +
                        $"\nFood Group: {ingridient.foodGroup}" +
                        $"\nCalories: {ingridient.calories}"
                };
                IngridientsPanel.Children.Add(ingridientText);
            }
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        //-------------------------------------------------
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
        //-------------------------------------------------
        private void showDescriptionButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string description = button.Tag as string;
            MessageBox.Show(description, "Step Description");


        }

        //.................................. Operations/ Methods that made other methods work.........................................................................................//

        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        //-------------------------------------------------
        private string ExtractRecipeName(string comboBoxItem)
        {
            string[] parts = comboBoxItem.Split(new[] { "Recipe Name: ", "Quantity of Steps: " }, StringSplitOptions.None);
            return parts.Length > 1 ? parts[1].Trim() : string.Empty;        
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        //-------------------------------------------------
        private void RecipeSearchComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (RecipeSearchComboBox.SelectedItem == null) return;
            string selectedItem = RecipeSearchComboBox.SelectedItem.ToString();
            string recipeName = ExtractRecipeName(selectedItem);
            Recipe selectedRecipe = recipes.FirstOrDefault(r => r.recipeName == recipeName);
            foreach (var item in selectedRecipe.recipeName)
            {
                MessageBox.Show(Convert.ToString(item), "Selected Recipe");
            }
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

        //...................................... Checkers - Methods that verify the something meets a criteria.................................................................................//
        
        
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        //-------------------------------------------------
        private void Quantity_CheckDoubleInput(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(QuantityInput.Text))
            {
                if (double.TryParse(QuantityInput.Text, out double quantity))
                    if (quantity <= 0)
                    {
                        MessageBox.Show($"Please enter a positive number {e.Source.ToString()}", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                        QuantityInput.Focus();
                        QuantityInput.Text = "1";

                    }
            }
            else
            {
                MessageBox.Show("Please enter a valid number.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                QuantityInput.Text = "1";
                QuantityInput.Focus();
            }
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        //-------------------------------------------------
        private void StepNumber_CheckDoubleInput(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(StepNumberInput.Text))
            {
                if (double.TryParse(StepNumberInput.Text, out double stepNumber))
                    if (stepNumber <= 0)
                    {
                        MessageBox.Show($"Please enter a positive number {e.Source.ToString()}", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                        StepNumberInput.Focus();
                        StepNumberInput.Text = "1";

                    }
            }
            else
            {
                MessageBox.Show("Please enter a valid number.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                StepNumberInput.Text = "1";
                StepNumberInput.Focus();
            }
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        //-------------------------------------------------
        private void Calories_CheckDoubleInput(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(CaloriesInput.Text))
            {
                if (double.TryParse(CaloriesInput.Text, out double calories))
                    if (calories < 0)
                    {
                        MessageBox.Show($"Please enter 0 or a positive number {e.Source.ToString()}", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                        CaloriesInput.Focus();
                        CaloriesInput.Text = "0";

                    }
            }
            else
            {
                MessageBox.Show("Please enter a valid number.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                CaloriesInput.Focus();
                CaloriesInput.Text = "0";
               
            }
        }
    }
}
//..............................................END OF THE FILE....................................................................................................................................................//