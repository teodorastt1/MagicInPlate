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
            
            foreach (string name in recipeNames)
            {
                listBox1.Items.Add(name);
                

            }

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

            List<string> recipeInstructions = formView.GetRecipeInstructions();
            List<int> recipeId = formView.GetRecipeId();
            List<string> recipeDescription = formView.GetRecipeDescription();
            List<int> recipePrepTime = formView.GetRecipePrepTime();
            List<string> recipeDifficulty = formView.GetRecipeDifficulty();
            List<string> recipeCategory = formView.GetRecipeCategory();

            ClearAfterAChangeInFirstTab();

            int selectedIndex = listBox1.SelectedIndex;

            string selectedRecipeInstructions = recipeInstructions[selectedIndex];
            string extraInfo = recipeDescription[selectedIndex] + 
                "\n" + recipePrepTime[selectedIndex] + 
                " minutes\n" + recipeDifficulty[selectedIndex] + 
                "\n" + recipeCategory[selectedIndex];
            int selectedRecipeId = recipeId[selectedIndex];

            richTextBox5.Text = selectedRecipeInstructions;
            richTextBox6.Text = extraInfo;

            List<string> ingredients = formView.GetIngredientsForRecipe(selectedRecipeId);
            List<string> quantities = formView.GetIngredientQuantityForRecipe(selectedRecipeId);

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

        private void ClearAfterAChangeInFirstTab()
        {
            richTextBox5.Clear();
            listBox2.Items.Clear();
            richTextBox6.Clear();
        }
    }
}
