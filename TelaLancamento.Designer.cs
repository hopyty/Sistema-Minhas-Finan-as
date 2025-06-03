namespace Sistema_Minhas_Finanças
{
    partial class TelaLancamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaLancamento));
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            btnTelaInicial = new Button();
            RbtDespesa = new RadioButton();
            RbtReceita = new RadioButton();
            listBox1 = new ListBox();
            BoxCategoria = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            TxtValor = new TextBox();
            label3 = new Label();
            TextBoxdesc = new RichTextBox();
            btnLancamento = new Button();
            button5 = new Button();
            label4 = new Label();
            BoxConta = new ComboBox();
            label5 = new Label();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            label11 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // button4
            // 
            button4.BackColor = Color.Transparent;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold);
            button4.ForeColor = Color.DarkCyan;
            button4.Image = (Image)resources.GetObject("button4.Image");
            button4.ImageAlign = ContentAlignment.MiddleLeft;
            button4.Location = new Point(41, 576);
            button4.Name = "button4";
            button4.Size = new Size(232, 45);
            button4.TabIndex = 9;
            button4.Text = "Extratos";
            button4.TextAlign = ContentAlignment.MiddleRight;
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.Transparent;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold);
            button3.ForeColor = Color.DarkCyan;
            button3.Image = (Image)resources.GetObject("button3.Image");
            button3.ImageAlign = ContentAlignment.MiddleLeft;
            button3.Location = new Point(41, 475);
            button3.Name = "button3";
            button3.Size = new Size(232, 45);
            button3.TabIndex = 8;
            button3.Text = "Notificaçoes";
            button3.TextAlign = ContentAlignment.MiddleRight;
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Transparent;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold);
            button2.ForeColor = Color.DarkCyan;
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.Location = new Point(41, 375);
            button2.Name = "button2";
            button2.Size = new Size(232, 45);
            button2.TabIndex = 7;
            button2.Text = "Poupança";
            button2.TextAlign = ContentAlignment.MiddleRight;
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.DarkCyan;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(41, 274);
            button1.Name = "button1";
            button1.Size = new Size(232, 45);
            button1.TabIndex = 6;
            button1.Text = "Lançamentos";
            button1.TextAlign = ContentAlignment.MiddleRight;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // btnTelaInicial
            // 
            btnTelaInicial.BackColor = Color.Transparent;
            btnTelaInicial.FlatAppearance.BorderSize = 0;
            btnTelaInicial.FlatStyle = FlatStyle.Flat;
            btnTelaInicial.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTelaInicial.ForeColor = Color.DarkCyan;
            btnTelaInicial.Image = (Image)resources.GetObject("btnTelaInicial.Image");
            btnTelaInicial.ImageAlign = ContentAlignment.MiddleLeft;
            btnTelaInicial.Location = new Point(41, 174);
            btnTelaInicial.Name = "btnTelaInicial";
            btnTelaInicial.Size = new Size(232, 45);
            btnTelaInicial.TabIndex = 5;
            btnTelaInicial.Text = "Tela inicial";
            btnTelaInicial.TextAlign = ContentAlignment.MiddleRight;
            btnTelaInicial.UseVisualStyleBackColor = false;
            btnTelaInicial.Click += btnTelaInicial_Click;
            // 
            // RbtDespesa
            // 
            RbtDespesa.AutoSize = true;
            RbtDespesa.Location = new Point(301, 124);
            RbtDespesa.Name = "RbtDespesa";
            RbtDespesa.Size = new Size(73, 19);
            RbtDespesa.TabIndex = 10;
            RbtDespesa.TabStop = true;
            RbtDespesa.Text = "Despesas";
            RbtDespesa.UseVisualStyleBackColor = true;
            RbtDespesa.CheckedChanged += RbtDespesa_CheckedChanged_1;
            // 
            // RbtReceita
            // 
            RbtReceita.AutoSize = true;
            RbtReceita.Location = new Point(401, 124);
            RbtReceita.Name = "RbtReceita";
            RbtReceita.Size = new Size(68, 19);
            RbtReceita.TabIndex = 11;
            RbtReceita.TabStop = true;
            RbtReceita.Text = "Receitas";
            RbtReceita.UseVisualStyleBackColor = true;
            RbtReceita.CheckedChanged += RbtReceita_CheckedChanged_1;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(301, 356);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(1037, 289);
            listBox1.TabIndex = 12;
            // 
            // BoxCategoria
            // 
            BoxCategoria.FormattingEnabled = true;
            BoxCategoria.Location = new Point(301, 174);
            BoxCategoria.Name = "BoxCategoria";
            BoxCategoria.Size = new Size(258, 23);
            BoxCategoria.TabIndex = 13;
            BoxCategoria.SelectedIndexChanged += BoxCategoria_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(301, 156);
            label1.Name = "label1";
            label1.Size = new Size(64, 15);
            label1.TabIndex = 14;
            label1.Text = "Categoria: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(837, 156);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 15;
            label2.Text = "Valor: ";
            // 
            // TxtValor
            // 
            TxtValor.Location = new Point(837, 174);
            TxtValor.Name = "TxtValor";
            TxtValor.PlaceholderText = "R$ 0.000,00";
            TxtValor.Size = new Size(121, 23);
            TxtValor.TabIndex = 16;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(301, 204);
            label3.Name = "label3";
            label3.Size = new Size(64, 15);
            label3.TabIndex = 17;
            label3.Text = "Descriçao: ";
            // 
            // TextBoxdesc
            // 
            TextBoxdesc.Location = new Point(301, 231);
            TextBoxdesc.Name = "TextBoxdesc";
            TextBoxdesc.Size = new Size(657, 59);
            TextBoxdesc.TabIndex = 18;
            TextBoxdesc.Text = "";
            // 
            // btnLancamento
            // 
            btnLancamento.BackColor = Color.Transparent;
            btnLancamento.FlatAppearance.BorderSize = 0;
            btnLancamento.FlatStyle = FlatStyle.Flat;
            btnLancamento.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLancamento.ForeColor = Color.Transparent;
            btnLancamento.Location = new Point(1051, 225);
            btnLancamento.Name = "btnLancamento";
            btnLancamento.Size = new Size(287, 44);
            btnLancamento.TabIndex = 19;
            btnLancamento.Text = "Registrar Valor";
            btnLancamento.UseVisualStyleBackColor = false;
            btnLancamento.Click += btnLancamento_Click;
            // 
            // button5
            // 
            button5.BackColor = Color.Transparent;
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button5.ForeColor = Color.Transparent;
            button5.Location = new Point(1052, 666);
            button5.Name = "button5";
            button5.Size = new Size(287, 44);
            button5.TabIndex = 20;
            button5.Text = "Excluir Registro";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(590, 156);
            label4.Name = "label4";
            label4.Size = new Size(81, 15);
            label4.TabIndex = 22;
            label4.Text = "Conta Banco: ";
            // 
            // BoxConta
            // 
            BoxConta.FormattingEnabled = true;
            BoxConta.Location = new Point(590, 174);
            BoxConta.Name = "BoxConta";
            BoxConta.Size = new Size(216, 23);
            BoxConta.TabIndex = 21;
            BoxConta.SelectedIndexChanged += BoxConta_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(301, 326);
            label5.Name = "label5";
            label5.Size = new Size(170, 15);
            label5.TabIndex = 23;
            label5.Text = "Relatorio de Movimentaçaoes :";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(1, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(272, 94);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 24;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(95, 642);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(100, 50);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 25;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Transparent;
            label11.Font = new Font("Segoe UI", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.White;
            label11.Location = new Point(278, 5);
            label11.Name = "label11";
            label11.Size = new Size(530, 86);
            label11.TabIndex = 36;
            label11.Text = "Minhas Finanças";
            // 
            // TelaLancamento
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1350, 729);
            Controls.Add(label11);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(BoxConta);
            Controls.Add(button5);
            Controls.Add(btnLancamento);
            Controls.Add(TextBoxdesc);
            Controls.Add(label3);
            Controls.Add(TxtValor);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(BoxCategoria);
            Controls.Add(listBox1);
            Controls.Add(RbtReceita);
            Controls.Add(RbtDespesa);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(btnTelaInicial);
            Name = "TelaLancamento";
            Text = "Minhas Finanças - Lançar Movimentaçoes";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button4;
        private Button button3;
        private Button button2;
        private Button button1;
        private Button btnTelaInicial;
        private RadioButton RbtDespesa;
        private RadioButton RbtReceita;
        private ListBox listBox1;
        private ComboBox BoxCategoria;
        private Label label1;
        private Label label2;
        private TextBox TxtValor;
        private Label label3;
        private RichTextBox TextBoxdesc;
        private Button btnLancamento;
        private Button button5;
        private Label label4;
        private ComboBox BoxConta;
        private Label label5;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Label label11;
    }
}