namespace PumiikaVChiniika
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TabPage tabPageAddIngredient;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label24 = new Label();
            listBox5 = new ListBox();
            textBox7 = new TextBox();
            buttonForAdding = new Button();
            labelForNewitem = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            richTextBox6 = new RichTextBox();
            label22 = new Label();
            richTextBox5 = new RichTextBox();
            label21 = new Label();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            listBox2 = new ListBox();
            listBox1 = new ListBox();
            label2 = new Label();
            label1 = new Label();
            tabPage2 = new TabPage();
            richTextBox1 = new RichTextBox();
            listBox7 = new ListBox();
            label26 = new Label();
            label25 = new Label();
            listBox6 = new ListBox();
            label10 = new Label();
            label8 = new Label();
            button1 = new Button();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label9 = new Label();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            richTextBox2 = new RichTextBox();
            comboBox2 = new ComboBox();
            comboBox1 = new ComboBox();
            label4 = new Label();
            tabPage3 = new TabPage();
            label27 = new Label();
            label23 = new Label();
            richTextBox3 = new RichTextBox();
            listBox9 = new ListBox();
            listBox8 = new ListBox();
            button3 = new Button();
            richTextBox4 = new RichTextBox();
            label20 = new Label();
            label19 = new Label();
            textBox6 = new TextBox();
            listBox4 = new ListBox();
            label18 = new Label();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            label16 = new Label();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            comboBox3 = new ComboBox();
            comboBox4 = new ComboBox();
            label17 = new Label();
            tabPage4 = new TabPage();
            label12 = new Label();
            button2 = new Button();
            listBox3 = new ListBox();
            label11 = new Label();
            tabPageAddIngredient = new TabPage();
            tabPageAddIngredient.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            tabPage4.SuspendLayout();
            SuspendLayout();
            // 
            // tabPageAddIngredient
            // 
            tabPageAddIngredient.BackgroundImage = Properties.Resources.GOTVIM1;
            tabPageAddIngredient.Controls.Add(label24);
            tabPageAddIngredient.Controls.Add(listBox5);
            tabPageAddIngredient.Controls.Add(textBox7);
            tabPageAddIngredient.Controls.Add(buttonForAdding);
            tabPageAddIngredient.Controls.Add(labelForNewitem);
            tabPageAddIngredient.Location = new Point(4, 93);
            tabPageAddIngredient.Name = "tabPageAddIngredient";
            tabPageAddIngredient.Padding = new Padding(3);
            tabPageAddIngredient.Size = new Size(1214, 675);
            tabPageAddIngredient.TabIndex = 4;
            tabPageAddIngredient.Text = "Добавяне на продукт";
            tabPageAddIngredient.UseVisualStyleBackColor = true;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.BackColor = SystemColors.ActiveCaption;
            label24.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label24.ForeColor = Color.Peru;
            label24.Location = new Point(51, 87);
            label24.Name = "label24";
            label24.Size = new Size(246, 35);
            label24.TabIndex = 4;
            label24.Text = "Налични продукти";
            // 
            // listBox5
            // 
            listBox5.FormattingEnabled = true;
            listBox5.ItemHeight = 35;
            listBox5.Location = new Point(51, 176);
            listBox5.Name = "listBox5";
            listBox5.SelectionMode = SelectionMode.None;
            listBox5.Size = new Size(317, 459);
            listBox5.TabIndex = 3;
            // 
            // textBox7
            // 
            textBox7.Location = new Point(828, 176);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(352, 41);
            textBox7.TabIndex = 2;
            // 
            // buttonForAdding
            // 
            buttonForAdding.BackColor = SystemColors.ActiveCaption;
            buttonForAdding.ForeColor = Color.Maroon;
            buttonForAdding.Location = new Point(956, 581);
            buttonForAdding.Name = "buttonForAdding";
            buttonForAdding.Size = new Size(224, 54);
            buttonForAdding.TabIndex = 1;
            buttonForAdding.Text = "Добавяне";
            buttonForAdding.UseVisualStyleBackColor = false;
            buttonForAdding.Click += button4_Click;
            // 
            // labelForNewitem
            // 
            labelForNewitem.AutoSize = true;
            labelForNewitem.BackColor = SystemColors.ActiveCaption;
            labelForNewitem.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            labelForNewitem.ForeColor = Color.Peru;
            labelForNewitem.Location = new Point(1011, 117);
            labelForNewitem.Name = "labelForNewitem";
            labelForNewitem.Size = new Size(169, 35);
            labelForNewitem.TabIndex = 0;
            labelForNewitem.Text = "Нов продукт";
            // 
            // tabControl1
            // 
            tabControl1.Appearance = TabAppearance.Buttons;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPageAddIngredient);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Font = new Font("Segoe UI", 15F);
            tabControl1.HotTrack = true;
            tabControl1.Location = new Point(1, 0);
            tabControl1.Multiline = true;
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1222, 772);
            tabControl1.SizeMode = TabSizeMode.FillToRight;
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.SkyBlue;
            tabPage1.BackgroundImage = Properties.Resources.NachalnaStranica;
            tabPage1.Controls.Add(richTextBox6);
            tabPage1.Controls.Add(label22);
            tabPage1.Controls.Add(richTextBox5);
            tabPage1.Controls.Add(label21);
            tabPage1.Controls.Add(pictureBox1);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(listBox2);
            tabPage1.Controls.Add(listBox1);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(label1);
            tabPage1.Cursor = Cursors.IBeam;
            tabPage1.Font = new Font("Segoe UI", 15F);
            tabPage1.ForeColor = Color.MidnightBlue;
            tabPage1.Location = new Point(4, 93);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1214, 675);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Преглед на рецепти";
            tabPage1.Click += tabPage1_Click;
            // 
            // richTextBox6
            // 
            richTextBox6.Location = new Point(928, 216);
            richTextBox6.Margin = new Padding(3, 4, 3, 4);
            richTextBox6.Name = "richTextBox6";
            richTextBox6.Size = new Size(278, 425);
            richTextBox6.TabIndex = 9;
            richTextBox6.Text = "";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label22.ForeColor = Color.LightSeaGreen;
            label22.Location = new Point(928, 137);
            label22.Name = "label22";
            label22.Size = new Size(280, 35);
            label22.TabIndex = 8;
            label22.Text = "Допълнително Инфо:";
            // 
            // richTextBox5
            // 
            richTextBox5.Location = new Point(608, 215);
            richTextBox5.Margin = new Padding(3, 4, 3, 4);
            richTextBox5.Name = "richTextBox5";
            richTextBox5.Size = new Size(270, 425);
            richTextBox5.TabIndex = 7;
            richTextBox5.Text = "";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label21.ForeColor = Color.LightSeaGreen;
            label21.Location = new Point(608, 137);
            label21.Name = "label21";
            label21.Size = new Size(171, 35);
            label21.TabIndex = 6;
            label21.Text = "Инструкции:";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources._6039758_resized__1_;
            pictureBox1.Location = new Point(1076, 17);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(102, 106);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.SkyBlue;
            label3.Font = new Font("Ravie", 23.2F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.LightSeaGreen;
            label3.ImageAlign = ContentAlignment.TopLeft;
            label3.Location = new Point(27, 17);
            label3.Name = "label3";
            label3.Size = new Size(818, 53);
            label3.TabIndex = 4;
            label3.Text = "Добре дошли в \"Magic In Plate\"";
            label3.UseMnemonic = false;
            label3.Click += label3_Click;
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 35;
            listBox2.Location = new Point(310, 215);
            listBox2.Name = "listBox2";
            listBox2.SelectionMode = SelectionMode.None;
            listBox2.Size = new Size(247, 424);
            listBox2.TabIndex = 3;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 35;
            listBox1.Location = new Point(27, 215);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(233, 424);
            listBox1.TabIndex = 2;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label2.ForeColor = Color.LightSeaGreen;
            label2.Location = new Point(310, 137);
            label2.Name = "label2";
            label2.Size = new Size(134, 35);
            label2.TabIndex = 1;
            label2.Text = "Съставки:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label1.ForeColor = Color.LightSeaGreen;
            label1.Location = new Point(27, 137);
            label1.Name = "label1";
            label1.Size = new Size(122, 35);
            label1.TabIndex = 0;
            label1.Text = "Рецепти:";
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.Transparent;
            tabPage2.BackgroundImage = Properties.Resources.feeding_large_groups2;
            tabPage2.Controls.Add(richTextBox1);
            tabPage2.Controls.Add(listBox7);
            tabPage2.Controls.Add(label26);
            tabPage2.Controls.Add(label25);
            tabPage2.Controls.Add(listBox6);
            tabPage2.Controls.Add(label10);
            tabPage2.Controls.Add(label8);
            tabPage2.Controls.Add(button1);
            tabPage2.Controls.Add(label7);
            tabPage2.Controls.Add(label6);
            tabPage2.Controls.Add(label5);
            tabPage2.Controls.Add(label9);
            tabPage2.Controls.Add(textBox3);
            tabPage2.Controls.Add(textBox2);
            tabPage2.Controls.Add(textBox1);
            tabPage2.Controls.Add(richTextBox2);
            tabPage2.Controls.Add(comboBox2);
            tabPage2.Controls.Add(comboBox1);
            tabPage2.Controls.Add(label4);
            tabPage2.Location = new Point(4, 93);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1214, 675);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Добавяне на рецепта";
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(981, 88);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(154, 249);
            richTextBox1.TabIndex = 23;
            richTextBox1.Text = "";
            // 
            // listBox7
            // 
            listBox7.FormattingEnabled = true;
            listBox7.ItemHeight = 35;
            listBox7.Location = new Point(705, 88);
            listBox7.Name = "listBox7";
            listBox7.SelectionMode = SelectionMode.None;
            listBox7.Size = new Size(179, 249);
            listBox7.TabIndex = 22;
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.BackColor = Color.Gold;
            label26.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label26.ForeColor = Color.DarkGreen;
            label26.Location = new Point(705, 38);
            label26.Name = "label26";
            label26.Size = new Size(251, 35);
            label26.TabIndex = 21;
            label26.Text = "Избрани продукти:";
            label26.UseWaitCursor = true;
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.BackColor = Color.Gold;
            label25.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label25.ForeColor = Color.DarkGreen;
            label25.Location = new Point(980, 38);
            label25.Name = "label25";
            label25.Size = new Size(165, 35);
            label25.TabIndex = 20;
            label25.Text = "Количество:";
            // 
            // listBox6
            // 
            listBox6.FormattingEnabled = true;
            listBox6.ItemHeight = 35;
            listBox6.Location = new Point(457, 88);
            listBox6.Name = "listBox6";
            listBox6.SelectionMode = SelectionMode.MultiSimple;
            listBox6.Size = new Size(171, 249);
            listBox6.TabIndex = 19;
            listBox6.SelectedIndexChanged += listBox6_SelectedIndexChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Gold;
            label10.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label10.ForeColor = Color.DarkGreen;
            label10.Location = new Point(457, 375);
            label10.Name = "label10";
            label10.Size = new Size(171, 35);
            label10.TabIndex = 18;
            label10.Text = "Инструкции:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Gold;
            label8.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label8.ForeColor = Color.DarkGreen;
            label8.Location = new Point(433, 38);
            label8.Name = "label8";
            label8.Size = new Size(253, 35);
            label8.TabIndex = 17;
            label8.Text = "Налични продукти:";
            // 
            // button1
            // 
            button1.BackColor = Color.Gold;
            button1.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            button1.ForeColor = Color.Teal;
            button1.Location = new Point(17, 616);
            button1.Name = "button1";
            button1.Size = new Size(160, 51);
            button1.TabIndex = 16;
            button1.Text = "Добави";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Gold;
            label7.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label7.ForeColor = Color.DarkGreen;
            label7.Location = new Point(17, 464);
            label7.Name = "label7";
            label7.Size = new Size(147, 35);
            label7.TabIndex = 15;
            label7.Text = "Категория:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Gold;
            label6.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label6.ForeColor = Color.DarkGreen;
            label6.Location = new Point(17, 344);
            label6.Name = "label6";
            label6.Size = new Size(142, 35);
            label6.TabIndex = 14;
            label6.Text = "Сложност:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Gold;
            label5.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label5.ForeColor = Color.DarkGreen;
            label5.Location = new Point(17, 235);
            label5.Name = "label5";
            label5.Size = new Size(233, 35);
            label5.TabIndex = 13;
            label5.Text = "Време за готвене:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Gold;
            label9.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label9.ForeColor = Color.DarkGreen;
            label9.Location = new Point(17, 144);
            label9.Name = "label9";
            label9.Size = new Size(142, 35);
            label9.TabIndex = 12;
            label9.Text = "Описание:";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(267, 232);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(90, 41);
            textBox3.TabIndex = 11;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(181, 139);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(175, 41);
            textBox2.TabIndex = 10;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(113, 47);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(244, 41);
            textBox1.TabIndex = 9;
            // 
            // richTextBox2
            // 
            richTextBox2.Location = new Point(457, 418);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(678, 246);
            richTextBox2.TabIndex = 8;
            richTextBox2.Text = "";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(181, 456);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(175, 43);
            comboBox2.TabIndex = 6;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(181, 344);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(175, 43);
            comboBox1.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Gold;
            label4.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label4.ForeColor = Color.DarkGreen;
            label4.Location = new Point(17, 47);
            label4.Name = "label4";
            label4.Size = new Size(75, 35);
            label4.TabIndex = 0;
            label4.Text = "Име:";
            // 
            // tabPage3
            // 
            tabPage3.BackgroundImage = Properties.Resources._360_F_332753934_tBacXEgxnVplFBRyKbCif49jh0Wz89ns1;
            tabPage3.BackgroundImageLayout = ImageLayout.Stretch;
            tabPage3.Controls.Add(label27);
            tabPage3.Controls.Add(label23);
            tabPage3.Controls.Add(richTextBox3);
            tabPage3.Controls.Add(listBox9);
            tabPage3.Controls.Add(listBox8);
            tabPage3.Controls.Add(button3);
            tabPage3.Controls.Add(richTextBox4);
            tabPage3.Controls.Add(label20);
            tabPage3.Controls.Add(label19);
            tabPage3.Controls.Add(textBox6);
            tabPage3.Controls.Add(listBox4);
            tabPage3.Controls.Add(label18);
            tabPage3.Controls.Add(label13);
            tabPage3.Controls.Add(label14);
            tabPage3.Controls.Add(label15);
            tabPage3.Controls.Add(label16);
            tabPage3.Controls.Add(textBox4);
            tabPage3.Controls.Add(textBox5);
            tabPage3.Controls.Add(comboBox3);
            tabPage3.Controls.Add(comboBox4);
            tabPage3.Controls.Add(label17);
            tabPage3.Location = new Point(4, 93);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1214, 675);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Промяна на рецепта";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.BackColor = Color.SteelBlue;
            label27.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label27.ForeColor = Color.Orange;
            label27.Location = new Point(585, 336);
            label27.Name = "label27";
            label27.Size = new Size(165, 35);
            label27.TabIndex = 37;
            label27.Text = "Количество:";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.BackColor = Color.SteelBlue;
            label23.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label23.ForeColor = Color.Orange;
            label23.Location = new Point(25, 336);
            label23.Name = "label23";
            label23.Size = new Size(233, 35);
            label23.TabIndex = 36;
            label23.Text = "Всички продукти:";
            // 
            // richTextBox3
            // 
            richTextBox3.Location = new Point(585, 384);
            richTextBox3.Name = "richTextBox3";
            richTextBox3.Size = new Size(174, 249);
            richTextBox3.TabIndex = 35;
            richTextBox3.Text = "";
            richTextBox3.TextChanged += richTextBox3_TextChanged;
            // 
            // listBox9
            // 
            listBox9.FormattingEnabled = true;
            listBox9.ItemHeight = 35;
            listBox9.Location = new Point(297, 384);
            listBox9.Name = "listBox9";
            listBox9.Size = new Size(219, 249);
            listBox9.TabIndex = 34;
            listBox9.SelectedIndexChanged += listBox9_SelectedIndexChanged;
            // 
            // listBox8
            // 
            listBox8.FormattingEnabled = true;
            listBox8.ItemHeight = 35;
            listBox8.Location = new Point(25, 384);
            listBox8.Name = "listBox8";
            listBox8.SelectionMode = SelectionMode.MultiSimple;
            listBox8.Size = new Size(200, 249);
            listBox8.TabIndex = 33;
            listBox8.SelectedIndexChanged += listBox8_SelectedIndexChanged;
            // 
            // button3
            // 
            button3.BackColor = Color.SteelBlue;
            button3.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            button3.ForeColor = Color.Orange;
            button3.Location = new Point(1007, 560);
            button3.Name = "button3";
            button3.Size = new Size(175, 59);
            button3.TabIndex = 32;
            button3.Text = "Промени";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // richTextBox4
            // 
            richTextBox4.Location = new Point(346, 87);
            richTextBox4.Name = "richTextBox4";
            richTextBox4.Size = new Size(308, 214);
            richTextBox4.TabIndex = 31;
            richTextBox4.Text = "";
            richTextBox4.TextChanged += richTextBox4_TextChanged;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.BackColor = Color.SteelBlue;
            label20.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label20.ForeColor = Color.Orange;
            label20.Location = new Point(297, 336);
            label20.Name = "label20";
            label20.Size = new Size(264, 35);
            label20.TabIndex = 29;
            label20.Text = "Въведени продукти:";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.BackColor = Color.SteelBlue;
            label19.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label19.ForeColor = Color.Orange;
            label19.Location = new Point(346, 27);
            label19.Name = "label19";
            label19.Size = new Size(320, 35);
            label19.TabIndex = 28;
            label19.Text = "Промяна на инструкции:";
            // 
            // textBox6
            // 
            textBox6.Location = new Point(1103, 211);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(79, 41);
            textBox6.TabIndex = 27;
            // 
            // listBox4
            // 
            listBox4.FormattingEnabled = true;
            listBox4.ItemHeight = 35;
            listBox4.Location = new Point(25, 87);
            listBox4.Name = "listBox4";
            listBox4.Size = new Size(283, 214);
            listBox4.TabIndex = 26;
            listBox4.SelectedIndexChanged += listBox4_SelectedIndexChanged;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.BackColor = Color.SteelBlue;
            label18.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label18.ForeColor = Color.Orange;
            label18.Location = new Point(25, 27);
            label18.Name = "label18";
            label18.Size = new Size(239, 35);
            label18.TabIndex = 25;
            label18.Text = "Списък с рецепти:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.SteelBlue;
            label13.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label13.ForeColor = Color.Orange;
            label13.Location = new Point(801, 406);
            label13.Name = "label13";
            label13.Size = new Size(147, 35);
            label13.TabIndex = 24;
            label13.Text = "Категория:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.BackColor = Color.SteelBlue;
            label14.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label14.ForeColor = Color.Orange;
            label14.Location = new Point(806, 314);
            label14.Name = "label14";
            label14.Size = new Size(142, 35);
            label14.TabIndex = 23;
            label14.Text = "Сложност:";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.BackColor = Color.SteelBlue;
            label15.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label15.ForeColor = Color.Orange;
            label15.Location = new Point(806, 211);
            label15.Name = "label15";
            label15.Size = new Size(233, 35);
            label15.TabIndex = 22;
            label15.Text = "Време за готвене:";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.BackColor = Color.SteelBlue;
            label16.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label16.ForeColor = Color.Orange;
            label16.Location = new Point(806, 113);
            label16.Name = "label16";
            label16.Size = new Size(142, 35);
            label16.TabIndex = 21;
            label16.Text = "Описание:";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(1007, 113);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(175, 41);
            textBox4.TabIndex = 20;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(938, 33);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(244, 41);
            textBox5.TabIndex = 19;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(1007, 398);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(175, 43);
            comboBox3.TabIndex = 18;
            // 
            // comboBox4
            // 
            comboBox4.FormattingEnabled = true;
            comboBox4.Location = new Point(1007, 311);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(175, 43);
            comboBox4.TabIndex = 17;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.BackColor = Color.SteelBlue;
            label17.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label17.ForeColor = Color.Orange;
            label17.Location = new Point(806, 36);
            label17.Name = "label17";
            label17.Size = new Size(75, 35);
            label17.TabIndex = 16;
            label17.Text = "Име:";
            // 
            // tabPage4
            // 
            tabPage4.BackColor = Color.OldLace;
            tabPage4.BackgroundImage = Properties.Resources._54088694_healthy_food_background_studio_photo_of_different_fruits_and_vegetables_on_white_wooden_table_high;
            tabPage4.Controls.Add(label12);
            tabPage4.Controls.Add(button2);
            tabPage4.Controls.Add(listBox3);
            tabPage4.Controls.Add(label11);
            tabPage4.Location = new Point(4, 93);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(1214, 675);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Изтриване на рецепта";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.White;
            label12.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            label12.ForeColor = Color.Firebrick;
            label12.Location = new Point(182, 499);
            label12.Name = "label12";
            label12.Size = new Size(795, 114);
            label12.TabIndex = 3;
            label12.Text = "С тъга виждам, че избра да изтриеш \r\nтворенията си в приложението.";
            // 
            // button2
            // 
            button2.BackColor = Color.White;
            button2.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            button2.ForeColor = Color.Firebrick;
            button2.Location = new Point(1050, 499);
            button2.Name = "button2";
            button2.Size = new Size(134, 114);
            button2.TabIndex = 2;
            button2.Text = "Изтрий";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // listBox3
            // 
            listBox3.BackColor = Color.Firebrick;
            listBox3.FormattingEnabled = true;
            listBox3.ItemHeight = 35;
            listBox3.Location = new Point(715, 106);
            listBox3.Name = "listBox3";
            listBox3.Size = new Size(409, 319);
            listBox3.TabIndex = 1;
            listBox3.SelectedIndexChanged += listBox3_SelectedIndexChanged;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Firebrick;
            label11.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label11.ForeColor = Color.White;
            label11.Location = new Point(421, 106);
            label11.Name = "label11";
            label11.Size = new Size(244, 35);
            label11.TabIndex = 0;
            label11.Text = "Изберете рецепта:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Linen;
            ClientSize = new Size(1219, 769);
            Controls.Add(tabControl1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Magic In Plate";
            tabPageAddIngredient.ResumeLayout(false);
            tabPageAddIngredient.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            tabPage4.ResumeLayout(false);
            tabPage4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private ListBox listBox2;
        private ListBox listBox1;
        private Label label2;
        private Label label1;
        private Label label3;
        private PictureBox pictureBox1;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private RichTextBox richTextBox2;
        private ComboBox comboBox2;
        private ComboBox comboBox1;
        private Label label4;
        private Label label8;
        private Button button1;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Button button2;
        private ListBox listBox3;
        private TextBox textBox6;
        private ListBox listBox4;
        private Label label18;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private TextBox textBox4;
        private TextBox textBox5;
        private ComboBox comboBox3;
        private ComboBox comboBox4;
        private Label label17;
        private RichTextBox richTextBox4;
        private Label label20;
        private Label label19;
        private Button button3;
        private RichTextBox richTextBox5;
        private Label label21;
        private RichTextBox richTextBox6;
        private Label label22;
        private TabPage tabPageAddIngredient;
        private Label label24;
        private ListBox listBox5;
        private TextBox textBox7;
        private Button buttonForAdding;
        private Label labelForNewitem;
        private ListBox listBox6;
        private Label label25;
        private ListBox listBox7;
        private Label label26;
        private RichTextBox richTextBox1;
        private Label label27;
        private Label label23;
        private RichTextBox richTextBox3;
        private ListBox listBox9;
        private ListBox listBox8;
    }
}
