using PumiikaVChiniika.Models;
using PumiikaVChiniika.Services;
using System.Windows.Forms;

namespace PumiikaVChiniika
{
    /// <summary>
    /// Основната форма на приложението, която управлява рецептите и свързаните с тях действия.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Конструктор. Инициализира формата и зарежда данните в контролите.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            RecipeServices formView = new RecipeServices();
            List<string> recipeNames = formView.GetRecipeNames();
            LoadDifficultiesIntoCheckBoxesForAddingAndChange();
            LoadCategoriesIntoCheckBOxesForAddingAndChange();
            RecievingRecipeNamesInAllListBoxes(recipeNames);
            LoadIngredientsIntoListBox5(formView);
            LoadIngredientsIntoListBox6(formView);
            LoadIngredientsIntoListBox8(formView);
        }

        /// <summary>
        /// Зарежда категориите в комбобоксите за добавяне и редакция на рецепти.
        /// </summary>
        private void LoadCategoriesIntoCheckBOxesForAddingAndChange()
        {
            comboBox2.Items.Add("Предястие");
            comboBox2.Items.Add("Основно");
            comboBox2.Items.Add("Десерт");
            comboBox3.Items.Add("Предястие");
            comboBox3.Items.Add("Основно");
            comboBox3.Items.Add("Десерт");
        }

        /// <summary>
        /// Зарежда нивата на трудност в комбобоксите за добавяне и редакция на рецепти.
        /// </summary>
        private void LoadDifficultiesIntoCheckBoxesForAddingAndChange()
        {
            comboBox1.Items.Add("Лесно");
            comboBox1.Items.Add("Средно");
            comboBox1.Items.Add("Трудно");
            comboBox4.Items.Add("Лесно");
            comboBox4.Items.Add("Средно");
            comboBox4.Items.Add("Трудно");
        }

        private void tabPage1_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }

        /// <summary>
        /// Събитие при избор на рецепта в listBox1 (първи таб).
        /// Зарежда информацията за избраната рецепта.
        /// </summary>
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RecipeServices formView = new RecipeServices();
            List<string> ingredients, quantities;
            string selectedRecipeInstructions, extraInfo;
            GettingInfoAboutRecipesForPageOne(formView, out ingredients, out quantities, out selectedRecipeInstructions, out extraInfo);

            ClearAfterAChangeInFirstTab();
            WritingInstructionsAndExtraInfoInFirstTab(selectedRecipeInstructions, extraInfo);
            DisplayingIngredientsAndQuantitiesTogether(ingredients, quantities);
        }

        /// <summary>
        /// Показва съставките и количествата за избрана рецепта в listBox2.
        /// </summary>
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

        /// <summary>
        /// Показва инструкциите и допълнителната информация за рецепта.
        /// </summary>
        private void WritingInstructionsAndExtraInfoInFirstTab(string selectedRecipeInstructions, string extraInfo)
        {
            richTextBox5.Text = selectedRecipeInstructions;
            richTextBox6.Text = extraInfo;
        }

        private void WritingInfoInForthTab() { }

        /// <summary>
        /// Взема данните за избраната рецепта за първия таб (съставки, количества, инструкции и др.).
        /// </summary>
        private void GettingInfoAboutRecipesForPageOne(RecipeServices formView, out List<string> ingredients, out List<string> quantities, out string selectedRecipeInstructions, out string extraInfo)
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

        /// <summary>
        /// Взема пълните данни за избраната рецепта за четвъртия таб.
        /// </summary>
        private void GettingInfoAboutRecipesForPageFourChange(RecipeServices formView, out List<string> ingredients, out List<string> quantities, out string selectedRecipeInstructions, out string description, out int recipeCookingTime, out string recipeDifficulty, out string recipeCategory)
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
            description = recipeDescriptions[selectedIndex];
            recipeCookingTime = recipePrepTime[selectedIndex];
            recipeDifficulty = recipeDifficulties[selectedIndex];
            recipeCategory = recipeCategories[selectedIndex];
        }

        /// <summary>
        /// Зарежда имената на рецептите в съответните списъци (listBox1, listBox3, listBox4).
        /// </summary>
        private void RecievingRecipeNamesInAllListBoxes(List<string> recipeNames)
        {
            foreach (string name in recipeNames)
            {
                listBox1.Items.Add(name);
                listBox4.Items.Add(name);
                listBox3.Items.Add(name);
            }
        }

        /// <summary>
        /// Изчиства съдържанието на контроли при смяна на избраната рецепта в първия таб.
        /// </summary>
        private void ClearAfterAChangeInFirstTab()
        {
            richTextBox5.Clear();
            listBox2.Items.Clear();
            richTextBox6.Clear();
        }

        /// <summary>
        /// Изчиства съдържанието на контролите в четвъртия таб.
        /// </summary>
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

        /// <summary>
        /// Събитие при натискане на бутон за изтриване на рецепта.
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            RecipeServices formView = new RecipeServices();
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

        /// <summary>
        /// Актуализира интерфейса, след като е направена промяна в рецептите.
        /// </summary>
        private void UIRefresh(RecipeServices formView)
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

        /// <summary>
        /// Събитие при избор на рецепта в listBox4 (четвърти таб).
        /// Зарежда информацията за рецептата и продуктите.
        /// </summary>
        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox4.SelectedIndex < 0) return;

            RecipeServices formView = new RecipeServices();
            List<string> ingredients;
            List<string> quantities;
            string selectedRecipeInstructions;
            string description;
            int recipeCookingTime;
            string recipeDifficulty;
            string recipeCategory;

            GettingInfoAboutRecipesForPageFourChange(formView, out ingredients, out quantities, out selectedRecipeInstructions, out description, out recipeCookingTime, out recipeDifficulty, out recipeCategory);

            ClearAfterAChangeInForthTab();

            textBox5.Text = listBox4.SelectedItem.ToString();
            textBox4.Text = description;
            textBox6.Text = recipeCookingTime.ToString();
            comboBox4.SelectedItem = recipeDifficulty;
            comboBox3.SelectedItem = recipeCategory;
            richTextBox4.Text = selectedRecipeInstructions;

            foreach (var ingredient in ingredients)
            {
                listBox9.Items.Add(ingredient);
            }

            richTextBox3.Text = string.Join(Environment.NewLine, quantities);

            List<string> allIngredients = formView.GetAllIngredients();
            listBox8.Items.Clear();
            foreach (var ingredient in allIngredients)
            {
                listBox8.Items.Add(ingredient);
            }
        }

        /// <summary>
        /// Зарежда всички продукти в listBox5.
        /// </summary>
        private void LoadIngredientsIntoListBox5(RecipeServices formView)
        {
            listBox5.Items.Clear();
            List<string> ingredients = formView.GetAllIngredients();
            foreach (var ingredient in ingredients)
            {
                listBox5.Items.Add(ingredient);
            }
        }

        /// <summary>
        /// Зарежда всички продукти в listBox6.
        /// </summary>
        private void LoadIngredientsIntoListBox6(RecipeServices formView)
        {
            listBox6.Items.Clear();
            List<string> ingredients = formView.GetAllIngredients();
            foreach (var ingredient in ingredients)
            {
                listBox6.Items.Add(ingredient);
            }
        }

        /// <summary>
        /// Зарежда всички продукти в listBox8.
        /// </summary>
        private void LoadIngredientsIntoListBox8(RecipeServices formView)
        {
            listBox8.Items.Clear();
            List<string> ingredients = formView.GetAllIngredients();
            foreach (var ingredient in ingredients)
            {
                listBox8.Items.Add(ingredient);
            }
        }

        /// <summary>
        /// Събитие при натискане на бутон за обновяване на избрана рецепта.
        /// </summary>
        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox4.SelectedIndex >= 0)
            {
                int selectedIndex = listBox4.SelectedIndex;
                RecipeServices formView = new RecipeServices();
                List<int> recipeIds = formView.GetRecipeId();
                int selectedRecipeId = recipeIds[selectedIndex];

                string updatedName = textBox5.Text;
                string updatedDescription = textBox4.Text;
                int updatedTime = int.TryParse(textBox6.Text, out int timeVal) ? timeVal : 0;
                string updatedDifficulty = comboBox4.Text;
                string updatedCategory = comboBox3.Text;
                string updatedInstructions = richTextBox4.Text;

                List<string> updatedIngredients = listBox9.Items.Cast<string>().ToList();
                List<string> updatedQuantities = richTextBox3.Lines.ToList();

                if (updatedIngredients.Count != updatedQuantities.Count)
                {
                    MessageBox.Show("Броят на продуктите и количествата не съвпадат.");
                    return;
                }

                formView.UpdateRecipe(selectedRecipeId, updatedName, updatedDescription, updatedTime,
                    updatedDifficulty, updatedInstructions, updatedCategory, updatedIngredients, updatedQuantities);

                UIRefresh(formView);
                listBox4.SelectedIndex = selectedIndex;
                MessageBox.Show("Рецептата е обновена успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Моля, изберете рецепта за редактиране.");
            }
        }

        /// <summary>
        /// Събитие при натискане на бутон за добавяне на нов продукт.
        /// </summary>
        private void button4_Click(object sender, EventArgs e)
        {
            RecipeServices formView = new RecipeServices();
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

        /// <summary>
        /// Събитие при избор на продукти в listBox6 (при добавяне на рецепта).
        /// Избраните продукти се копират в listBox7.
        /// </summary>
        private void listBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedProducts = listBox6.SelectedItems;
            listBox7.Items.Clear();
            foreach (var product in selectedProducts)
            {
                listBox7.Items.Add(product);
            }
        }

        /// <summary>
        /// Събитие при натискане на бутон за добавяне на нова рецепта.
        /// </summary>
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

            RecipeServices formView = new RecipeServices();
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

        /// <summary>
        /// Събитие при избор на продукти в listBox8 (в раздела за редактиране).
        /// Избраните продукти се копират в listBox9.
        /// </summary>
        private void listBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedProducts = listBox8.SelectedItems;
            listBox9.Items.Clear();
            foreach (var product in selectedProducts)
            {
                listBox9.Items.Add(product);
            }
        }

        /// <summary>
        /// Събитие при промяна на избора в listBox9 (в момента не е реализирано).
        /// </summary>
        private void listBox9_SelectedIndexChanged(object sender, EventArgs e) { }

        /// <summary>
        /// Вътрешен клас, представляващ рецепта с основните й свойства.
        /// </summary>
        public class Recipe
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string CookingTime { get; set; }
            public string Difficulty { get; set; }
            public string Category { get; set; }

            public override string ToString()
            {
                return Name;
            }
        }

        private void richTextBox4_TextChanged(object sender, EventArgs e) { }
        private void richTextBox3_TextChanged(object sender, EventArgs e) { }
    }
}
