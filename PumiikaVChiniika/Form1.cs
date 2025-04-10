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
            richTextBox5.Clear();
            listBox2.Items.Clear();
            
            int selectedIndex = listBox1.SelectedIndex;
            var selectedRecipeInstructions = recipeInstructions[selectedIndex];
            int selectedRecipeIngredients = recipeId[selectedIndex];
            richTextBox5.Text = selectedRecipeInstructions;


            List<string> ingredients = formView.GetIngredientsForRecipe(selectedRecipeIngredients);
            foreach (var ingredient in ingredients)
            {
                listBox2.Items.Add(ingredient);
            }



        }
    }
}
