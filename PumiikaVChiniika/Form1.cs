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
            LoadIngredientsIntoListBox6(formView);



        }

        private void LoadCategoriesIntoCheckBOxesForAddingAndChange()
        {
            comboBox2.Items.Add("���������");
            comboBox2.Items.Add("�������");
            comboBox2.Items.Add("������");
            comboBox3.Items.Add("���������");
            comboBox3.Items.Add("�������");
            comboBox3.Items.Add("������");
        }

        private void LoadDifficultiesIntoCheckBoxesForAddingAndChange()
        {
            comboBox1.Items.Add("�����");
            comboBox1.Items.Add("������");
            comboBox1.Items.Add("������");
            comboBox4.Items.Add("�����");
            comboBox4.Items.Add("������");
            comboBox4.Items.Add("������");
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
        private void WritingInfoInForthTab()///
        {

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
                " ������\n" + recipeDifficulty[selectedIndex] +
                "\n" + recipeCategory[selectedIndex];
        }
        private void GettingInfoAboutRecipesForPageFourChange(FormView formView, out List<string> ingredients, out List<string> quantities, out string selectedRecipeInstructions, out string description,out int recipeCookingTime,out string recipeDifficulty,out string recipeCategory)
        {
            List<string> recipeInstructions = formView.GetRecipeInstructions();
            List<int> recipeId = formView.GetRecipeId();
            List<string> recipeDescriptions = formView.GetRecipeDescription();
            List<int> recipePrepTime = formView.GetRecipePrepTime();
            List<string> recipeDifficulties = formView.GetRecipeDifficulty();
            List<string> recipeCategories = formView.GetRecipeCategoryName();
            int selectedIndex = listBox4.SelectedIndex;
            int selectedRecipeId = recipeId[selectedIndex];
            ingredients = formView.GetIngredientsForRecipe(selectedRecipeId);
            quantities = formView.GetIngredientQuantityForRecipe(selectedRecipeId);
            selectedRecipeInstructions = recipeInstructions[selectedIndex];
            description=recipeDescriptions[selectedIndex];
            recipeCookingTime=recipePrepTime[selectedIndex];
            recipeDifficulty=recipeDifficulties[selectedIndex];
            recipeCategory = recipeCategories[selectedIndex];

            
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
        private void ClearAfterAChangeInForthTab()
        {
            richTextBox4.Clear();
            listBox8.Items.Clear();
            listBox9.Items.Clear();
            richTextBox3.Clear();
            textBox5.Clear();
            textBox4.Clear();
            textBox6.Clear();
            
        }

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

            FormView formView = new FormView();
            List<string> ingredients, quantities;
            string selectedRecipeInstructions, description, recipeDifficulty, recipeCategory;
            int recipeCookingTime;

            GettingInfoAboutRecipesForPageFourChange(formView, out ingredients, out quantities, out selectedRecipeInstructions, out description, out recipeCookingTime, out recipeDifficulty, out recipeCategory);

            ClearAfterAChangeInForthTab();








            /*                               
            ////////////////                 
            //izpisvane here                 
            FormView formView = new FormView();
            string name = textBox5.Text;
            string description = textBox4.Text;
            int prepTime = int.Parse(textBox6.Text);
            string difficulty = comboBox4.SelectedItem.ToString();
            string category = comboBox3.SelectedItem.ToString();
            string instructions = richTextBox4.Text;

            List<string> selectedIngredients = listBox9.Items.Cast<string>().ToList();
            List<string> quantities = richTextBox3.Lines.ToList();

            if (selectedIngredients.Count != quantities.Count)
            {
                MessageBox.Show("The number of ingredients and quantities do not match!");
                return;
            }

            ///delete here
            formView.AddRecipe(name, description, prepTime, difficulty, instructions, category, selectedIngredients, quantities);

            MessageBox.Show("Recipe changed successfully!");

            //trqbva da se smeni
            UIRefresh(formView);
            LoadIngredientsIntoListBox6(formView);
            listBox7.Items.Clear();
            richTextBox1.Clear();
            richTextBox2.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            LoadCategoriesIntoCheckBOxesForAddingAndChange();
            LoadDifficultiesIntoCheckBoxesForAddingAndChange();
            */
        }
        private void LoadIngredientsIntoListBox5(FormView formView)
        {
            listBox5.Items.Clear();
            List<string> ingredients = formView.GetAllIngredients();
            foreach (var ingredient in ingredients)
            {
                listBox5.Items.Add(ingredient);
            }
        }
        private void LoadIngredientsIntoListBox6(FormView formView)
        {
            listBox6.Items.Clear();
            List<string> ingredients = formView.GetAllIngredients();
            foreach (var ingredient in ingredients)
            {
                listBox6.Items.Add(ingredient);
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
                MessageBox.Show("�� ��� ������ ��� �� ��������!");
            }
        }



        private void listBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedProducts = listBox6.SelectedItems;
            listBox7.Items.Clear();
            foreach (var product in selectedProducts)
            {
                listBox7.Items.Add(product);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string description = textBox2.Text;
            int prepTime = int.Parse(textBox3.Text);
            string difficulty = comboBox1.SelectedItem.ToString();
            string category = comboBox2.SelectedItem.ToString();
            string instructions = richTextBox2.Text;

            List<string> selectedIngredients = listBox7.Items.Cast<string>().ToList();
            List<string> quantities = richTextBox1.Lines.ToList();

            if (selectedIngredients.Count != quantities.Count)
            {
                MessageBox.Show("The number of ingredients and quantities do not match!");
                return;
            }

            FormView formView = new FormView();
            formView.AddRecipe(name, description, prepTime, difficulty, instructions, category, selectedIngredients, quantities);

            MessageBox.Show("Recipe added successfully!");

            UIRefresh(formView);
            LoadIngredientsIntoListBox6(formView);
            listBox7.Items.Clear();
            richTextBox1.Clear();
            richTextBox2.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            LoadCategoriesIntoCheckBOxesForAddingAndChange();
            LoadDifficultiesIntoCheckBoxesForAddingAndChange();



        }

        private void listBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void listBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
