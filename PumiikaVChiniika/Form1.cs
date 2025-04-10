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
            List<string> recipeInstructions = formView.GetRecipeInstructions();
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
            richTextBox5.Clear();
            int selectedIndex = listBox1.SelectedIndex;
            var selectedRecipe = recipeInstructions[selectedIndex];
            richTextBox5.Clear();
            richTextBox5.Text = selectedRecipe;

        }
    }
}
