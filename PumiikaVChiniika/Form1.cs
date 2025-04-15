using PumiikaVChiniika.Models;

namespace PumiikaVChiniika
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FormView formView = new FormView();
            List<string> recipeNames = formView.GetRecipeNames();
            LoadDifficultiesIntoCheckBoxesForAddingAndChange();
            LoadCategoriesIntoCheckBOxesForAddingAndChange();
            RecievingRecipeNamesInAllListBoxes(recipeNames);
            LoadIngredientsIntoListBox5(formView);



        }

        private void LoadCategoriesIntoCheckBOxesForAddingAndChange()
        {
            comboBox2.Items.Add("Предястие");
            comboBox2.Items.Add("Основно");
            comboBox2.Items.Add("Десерт");
            comboBox3.Items.Add("Предястие");
            comboBox3.Items.Add("Основно");
            comboBox3.Items.Add("Десерт");
        }

        private void LoadDifficultiesIntoCheckBoxesForAddingAndChange()
        {
            comboBox1.Items.Add("Лесно");
            comboBox1.Items.Add("Средно");
            comboBox1.Items.Add("Трудно");
            comboBox4.Items.Add("Лесно");
            comboBox4.Items.Add("Средно");
            comboBox4.Items.Add("Трудно");
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FormView formView = new FormView();
            List<string> ingredients, quantities;
            string selectedRecipeInstructions, extraInfo;
            GettingInfoAboutRecipesForPageOne(formView, out ingredients, out quantities, out selectedRecipeInstructions, out extraInfo);

            ClearAfterAChangeInFirstTab();
            WritingInstructionsAndExtraInfoInFirstTab(selectedRecipeInstructions, extraInfo);
            DisplayingIngredientsAndQuantitiesTogether(ingredients, quantities);
        }

        private void DisplayingIngredientsAndQuantitiesTogether(List<string> ingredients, List<string> quantities)
        {
            int i = 0;
            foreach (var ingredient in ingredients)
            {
                if (i < quantities.Count)
                {
                    listBox2.Items.Add(ingredient + " - " + quantities[i]);

                }
                i++;
            }
        }
        private void WritingInstructionsAndExtraInfoInFirstTab(string selectedRecipeInstructions, string extraInfo)
        {
            richTextBox5.Text = selectedRecipeInstructions;
            richTextBox6.Text = extraInfo;
        }
        private void WritingInstructionsAndInfoInThirdTab(string selectedRecipeInstructions, string recipeDescription, string name)
        {
            richTextBox4.Text = selectedRecipeInstructions;
            textBox4.Text = recipeDescription;
            textBox5.Text = name;

        }

        private void GettingInfoAboutRecipesForPageOne(FormView formView, out List<string> ingredients, out List<string> quantities, out string selectedRecipeInstructions, out string extraInfo)
        {
            List<string> recipeInstructions = formView.GetRecipeInstructions();
            List<int> recipeId = formView.GetRecipeId();
            List<string> recipeDescription = formView.GetRecipeDescription();
            List<int> recipePrepTime = formView.GetRecipePrepTime();
            List<string> recipeDifficulty = formView.GetRecipeDifficulty();
            List<string> recipeCategory = formView.GetRecipeCategoryName();
            int selectedIndex = listBox1.SelectedIndex;
            int selectedRecipeId = recipeId[selectedIndex];
            ingredients = formView.GetIngredientsForRecipe(selectedRecipeId);
            quantities = formView.GetIngredientQuantityForRecipe(selectedRecipeId);
            selectedRecipeInstructions = recipeInstructions[selectedIndex];
            extraInfo = recipeDescription[selectedIndex] +
                "\n" + recipePrepTime[selectedIndex] +
                " Минути\n" + recipeDifficulty[selectedIndex] +
                "\n" + recipeCategory[selectedIndex];
        }
        private void GettingInfoAboutRecipesForPageThree(FormView formView, List<string> ingredients, List<string> quantities, out string selectedRecipeInstructions, string description, string cookingTimr, string difficulty, string category, string name)
        {
            List<string> recipeInstructions = formView.GetRecipeInstructions();
            List<int> recipeId = formView.GetRecipeId();
            List<string> recipeDescription = formView.GetRecipeDescription();
            List<int> recipePrepTime = formView.GetRecipePrepTime();
            List<string> recipeDifficulty = formView.GetRecipeDifficulty();
            List<string> recipeCategory = formView.GetRecipeCategoryName();
            int selectedIndex = listBox4.SelectedIndex;
            int id = recipeId[selectedIndex];
            List<string> recipeName = formView.GetRecipeNameByIndex(id);
            int selectedRecipeId = recipeId[selectedIndex];
            ingredients = formView.GetIngredientsForRecipe(selectedRecipeId);
            quantities = formView.GetIngredientQuantityForRecipe(selectedRecipeId);
            selectedRecipeInstructions = recipeInstructions[selectedIndex];
            description = recipeDescription[selectedIndex];
            cookingTimr = recipePrepTime[selectedIndex] + " Минути";
            difficulty = recipeDifficulty[selectedIndex];
            category = recipeCategory[selectedIndex];
            name = recipeName[selectedIndex];
            /* extraInfo = recipeDescription[selectedIndex] +
                "\n" + recipePrepTime[selectedIndex] +
                " minutes\n" + recipeDifficulty[selectedIndex] +
                "\n" + recipeCategory[selectedIndex];*/
        }
        private void RecievingRecipeNamesInAllListBoxes(List<string> recipeNames)
        {
            foreach (string name in recipeNames)
            {
                listBox1.Items.Add(name);
                listBox4.Items.Add(name);
                listBox3.Items.Add(name);
            }
        }
        private void ClearAfterAChangeInFirstTab()
        {
            richTextBox5.Clear();
            listBox2.Items.Clear();
            richTextBox6.Clear();
        }
        /* private void ClearAfterAChangeInThirdTab()
         {
             richTextBox4.Clear();
             textBox5.Clear();
             textBox4.Clear();
             textBox6.Clear();
             richTextBox3.Clear();
             comboBox4.Items.Clear();
             comboBox3.Items.Clear();
         }*/

        private void button2_Click(object sender, EventArgs e)
        {
            FormView formView = new FormView();

            int selectedIndex = listBox3.SelectedIndex;

            if (selectedIndex >= 0)
            {
                List<int> recipeIds = formView.GetRecipeId();
                int selectedRecipeId = recipeIds[selectedIndex];


                var confirmResult = MessageBox.Show("Are you sure you want to delete this recipe?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    formView.DeleteRecipeById(selectedRecipeId);
                    UIRefresh(formView);
                }
            }
            else
            {
                MessageBox.Show("Please select a recipe to delete.");
            }
        }

        private void UIRefresh(FormView formView)
        {
            listBox1.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            List<string> updatedNames = formView.GetRecipeNames();
            foreach (var name in updatedNames)
            {
                listBox1.Items.Add(name);
                listBox3.Items.Add(name);
                listBox4.Items.Add(name);
            }

            richTextBox5.Clear();
            listBox2.Items.Clear();
        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            /* FormView formView = new FormView();
             List<string> ingredients, quantities;
             string selectedRecipeInstructions, extraInfo;
             GettingInfoAboutRecipesForPageThree(formView)///////////

             ClearAfterAChangeInThirdTab();
             WritingInstructionsAndExtraInfoInFirstTab(selectedRecipeInstructions, extraInfo);
             DisplayingIngredientsAndQuantitiesTogether(ingredients, quantities);*/
        }
        private void LoadIngredientsIntoListBox5(FormView formView)
        {
            listBoxProducts.Items.Clear();
            List<string> ingredients = formView.GetAllIngredients();
            foreach (var ingredient in ingredients)
            {
                listBoxProducts.Items.Add(ingredient);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormView formView = new FormView();
            string newIngredientName = textBox7.Text.Trim();

            if (!string.IsNullOrEmpty(newIngredientName))
            {
                formView.AddIngredient(newIngredientName);
                LoadIngredientsIntoListBox5(formView);
                textBox7.Clear();
            }
            else
            {
                MessageBox.Show("Не сте въвели име на продукта!");
            }
        }

        private void label26_Click(object sender, EventArgs e)
        {

        }
    }
}
