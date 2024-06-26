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
        //List<Ingridient> ingridients = new List<Ingridient>();
        //List<Steps> steps = new List<Steps>();
        //-------------------------------------------------
        public MainWindow()
        {
            InitializeComponent();
        }

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
            
            Recipe recipe = recipes.FirstOrDefault(r =>)

            //ingridients.Add(ingridient);
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
            //steps.Add(step);
            recipes.recipeSteps.Add(step);
            string descriptionDetails = $"Recipe Name: {recipeName}, Step Number {stepnumber}, Description {description}";
            addRecipeNameToComboBox(recipeName);
            MessageBox.Show(descriptionDetails, "Description Details");
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        //--- Neeed update
        private void SearchRecipe_RecipeName_Button_Click(object sender, RoutedEventArgs e)
        {
            string recipeName = RecipeNameSearch.Text;
                foreach(var lists in recipes.recipeIngridient)
                {
                    if (lists.Equals(recipeName))
                    {
                        string message = $"Recipe Name: {lists.recipeName}, " +
                            $"\nIngridient: {lists.name}, " +
                            $"\nUnit of Measurement: {lists.unitOfMeasurement}, " +
                            $"\nQuantity: {lists.quantity}";
                        MessageBox.Show(message, "Ingridients");
                    }
                }

        }
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        //-------------------------------------------------
        private void SearchRecipe_Calories_Button_Click(object sender, RoutedEventArgs e)
        {
            double calories = Convert.ToDouble(CaloriesSearch.Text);
                foreach (var lists in recipes.recipeIngridient)
                {
                    if (lists.calories.Equals(calories))
                    {
                        string message = $"Recipe Name: {lists.recipeName}, " +
                            $"\nIngridient: {lists.name}, " +
                            $"\nUnit of Measurement: {lists.unitOfMeasurement}, " +
                            $"\nQuantity: {lists.quantity}";
                        MessageBox.Show(message, "Ingridients");
                    }
                }
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        //-------------------------------------------------
        private void SearchRecipe_FoodGroup_Button_Clic(object sender, RoutedEventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)FoodGroupSearch.SelectedItem;
            string foodGroup = selectedItem != null ? selectedItem.Content.ToString() : string.Empty;
                foreach (var lists in recipes.recipeIngridient)
                {
                    if (lists.foodGroup.Equals(foodGroup))
                    {
                    string message = $"Recipe Name: {lists.recipeName}, " +
                        $"\nIngridient: {lists.name}, " +
                        $"\nUnit of Measurement: {lists.unitOfMeasurement}, " +
                        $"\nQuantity: {lists.quantity}," +
                        $"\nFood Group: {lists.foodGroup}" +
                        $"\nCalories: {lists.calories}";
                        MessageBox.Show(message, "Ingridients");
                    }
                }   
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        //-------------------------------------------------
        private void addRecipeNameToComboBox(string name)
        {
            List<double> listQuantityOfStepNumeber = new List<double>();
            int quantityOfStepNumeber = 0;
            foreach (var lists  in recipes.recipeIngridient)
            {
                if(lists.recipeName != null)
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
            for(int i = 0; i < RecipeSearchComboBox.Items.Count; i++)
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
            foreach(var item in items)
            {
                RecipeSearchComboBox.Items.Add(item);
            }
           
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        //-------------------------------------------------
        private string ExtractRecipeName(string comboBoxItem)
        {
            string[] parts = comboBoxItem.Split(new[] { "Recipe Name: ", "Quantity of Steps: " }, StringSplitOptions.None);
            return parts.Length > 1 ? parts[1].Trim() : string.Empty;        
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        //-------------------------------------------------
        private void CheckDoubleInput(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(QuantityInput.Text))
            {
                if (double.TryParse(QuantityInput.Text, out double quantity))
                    if (quantity <= 0)
                    {
                        MessageBox.Show($"Please enter a positive number {e.Source.ToString()}", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                        QuantityInput.Focus();
                        QuantityInput.Text = string.Empty;
                        
                    }
                }
            /*
                else
                {
                    MessageBox.Show("Please enter a valid number.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                    QuantityInput.Focus();
                    QuantityInput.Text = string.Empty;

                } */
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        //-------------------------------------------------
        private void RecipeSearchComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string selectedItem = RecipeSearchComboBox.SelectedItem.ToString();
                string recipeName = ExtractRecipeName(selectedItem);
                Recipe selectedRecipe = recipes.recipeIngridient.FirstOrDefault(r => r.name == recipeName);
                MessageBox.Show($"Works Normally, data type {selectedRecipe.name}", " RecipeSearchComboBox_SelectionChanged 1");

                if (selectedRecipe != null)
                {
                    MessageBox.Show("Works Normally", " RecipeSearchComboBox_SelectionChanged 2");
                    foreach(var item in selectedRecipe.recipeIngridient)
                    {
                        MessageBox.Show(Convert.ToString(item), "Selected Recipe");
                    }
                    DisplayIngridients(selectedRecipe);
                    DisplaySteps(selectedRecipe);
                }
                else
                {
                    MessageBox.Show("Null recipes", "Selected Recipe");
                }

            }catch(Exception ex)
            {
                throw ex;
            }
          
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        //-------------------------------------------------
        private void DisplayIngridients(Recipe ingridients)
        {
            IngridientsPanel.Children.Clear();
            try
            {
                foreach (var ingridient in ingridients.recipeIngridient)
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

            }catch(Exception ex)
            {
                throw ex;
            }
           

        }
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        //-------------------------------------------------
        private void DisplaySteps(Recipe steps)
        {
            StepsPanel.Children.Clear();
            if (steps == null) return;
            foreach (var step in steps.recipeSteps)
            {
                StackPanel stepPanel = new StackPanel { Orientation = Orientation.Horizontal };
                TextBlock stepText = new TextBlock
                {
                    Text = $"Step {step.stepNumber}",
                    Width=100
                };
                Button showDescriptionButton = new Button
                {
                    Content = "Show Description",
                    Tag = step.stepDescription,
                    Width=120,
                    Margin = new Thickness(5,0,0,0)
                };
                showDescriptionButton.Click += showDescriptionButton_Click;
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
    }
    

}