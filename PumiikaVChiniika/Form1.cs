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
    }
}
