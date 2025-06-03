namespace Sistema_Minhas_Finanças
{
    partial class TelaCadastroConta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaCadastroConta));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtdescbanco = new TextBox();
            txtvalorinicial = new TextBox();
            BoxCadconta = new ComboBox();
            btnAddConta = new Button();
            listBox1 = new ListBox();
            btnTelaInicialcad = new Button();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            label11 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(315, 126);
            label1.Name = "label1";
            label1.Size = new Size(46, 15);
            label1.TabIndex = 0;
            label1.Text = "Banco: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(315, 216);
            label2.Name = "label2";
            label2.Size = new Size(68, 15);
            label2.TabIndex = 1;
            label2.Text = "Tipo Conta:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(599, 216);
            label3.Name = "label3";
            label3.Size = new Size(73, 15);
            label3.TabIndex = 2;
            label3.Text = "Valor Inicial: ";
            // 
            // txtdescbanco
            // 
            txtdescbanco.Location = new Point(331, 144);
            txtdescbanco.Name = "txtdescbanco";
            txtdescbanco.Size = new Size(517, 23);
            txtdescbanco.TabIndex = 3;
            // 
            // txtvalorinicial
            // 
            txtvalorinicial.Location = new Point(619, 234);
            txtvalorinicial.Name = "txtvalorinicial";
            txtvalorinicial.PlaceholderText = "R$ 0.000,00";
            txtvalorinicial.Size = new Size(229, 23);
            txtvalorinicial.TabIndex = 4;
            // 
            // BoxCadconta
            // 
            BoxCadconta.FormattingEnabled = true;
            BoxCadconta.Items.AddRange(new object[] { "poupança", "corrente" });
            BoxCadconta.Location = new Point(331, 234);
            BoxCadconta.Name = "BoxCadconta";
            BoxCadconta.Size = new Size(240, 23);
            BoxCadconta.TabIndex = 5;
            // 
            // btnAddConta
            // 
            btnAddConta.BackColor = Color.Transparent;
            btnAddConta.FlatAppearance.BorderSize = 0;
            btnAddConta.FlatStyle = FlatStyle.Flat;
            btnAddConta.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddConta.ForeColor = Color.Transparent;
            btnAddConta.Location = new Point(1051, 225);
            btnAddConta.Name = "btnAddConta";
            btnAddConta.Size = new Size(287, 44);
            btnAddConta.TabIndex = 20;
            btnAddConta.Text = "Cadastrar Conta";
            btnAddConta.UseVisualStyleBackColor = false;
            btnAddConta.Click += btnAddConta_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(300, 323);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(1042, 394);
            listBox1.TabIndex = 21;
            // 
            // btnTelaInicialcad
            // 
            btnTelaInicialcad.BackColor = Color.Transparent;
            btnTelaInicialcad.FlatAppearance.BorderSize = 0;
            btnTelaInicialcad.FlatStyle = FlatStyle.Flat;
            btnTelaInicialcad.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTelaInicialcad.ForeColor = Color.DarkCyan;
            btnTelaInicialcad.Image = (Image)resources.GetObject("btnTelaInicialcad.Image");
            btnTelaInicialcad.ImageAlign = ContentAlignment.MiddleLeft;
            btnTelaInicialcad.Location = new Point(42, 175);
            btnTelaInicialcad.Name = "btnTelaInicialcad";
            btnTelaInicialcad.Size = new Size(232, 45);
            btnTelaInicialcad.TabIndex = 22;
            btnTelaInicialcad.Text = "Tela inicial";
            btnTelaInicialcad.TextAlign = ContentAlignment.MiddleRight;
            btnTelaInicialcad.UseVisualStyleBackColor = false;
            btnTelaInicialcad.Click += btnTelaInicialcad_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(2, 1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(272, 94);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 23;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(85, 640);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(100, 50);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 24;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Transparent;
            label11.Font = new Font("Segoe UI", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.White;
            label11.Location = new Point(279, 5);
            label11.Name = "label11";
            label11.Size = new Size(530, 86);
            label11.TabIndex = 36;
            label11.Text = "Minhas Finanças";
            // 
            // TelaCadastroConta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1350, 729);
            Controls.Add(label11);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(btnTelaInicialcad);
            Controls.Add(listBox1);
            Controls.Add(btnAddConta);
            Controls.Add(BoxCadconta);
            Controls.Add(txtvalorinicial);
            Controls.Add(txtdescbanco);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "TelaCadastroConta";
            Text = "Minhas Finanças - Cadastro Contas";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtdescbanco;
        private TextBox txtvalorinicial;
        private ComboBox BoxCadconta;
        private Button btnAddConta;
        private ListBox listBox1;
        private Button btnTelaInicialcad;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Label label11;
    }
}