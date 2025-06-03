namespace Sistema_Minhas_Finanças
{
    partial class TelaLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaLogin));
            btnEntrarLogin = new Button();
            pictureBox1 = new PictureBox();
            txtEntrarEmail = new TextBox();
            pictureBox2 = new PictureBox();
            txtEntrarSenha = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // btnEntrarLogin
            // 
            btnEntrarLogin.BackColor = Color.Transparent;
            btnEntrarLogin.FlatAppearance.BorderSize = 0;
            btnEntrarLogin.FlatStyle = FlatStyle.Flat;
            btnEntrarLogin.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEntrarLogin.ForeColor = Color.Transparent;
            btnEntrarLogin.Location = new Point(905, 521);
            btnEntrarLogin.Name = "btnEntrarLogin";
            btnEntrarLogin.Size = new Size(310, 43);
            btnEntrarLogin.TabIndex = 6;
            btnEntrarLogin.Text = "Entrar";
            btnEntrarLogin.UseVisualStyleBackColor = false;
            btnEntrarLogin.Click += btnEntrarLogin_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(799, 311);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(41, 42);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // txtEntrarEmail
            // 
            txtEntrarEmail.BackColor = SystemColors.Control;
            txtEntrarEmail.BorderStyle = BorderStyle.None;
            txtEntrarEmail.Font = new Font("Segoe UI", 18F);
            txtEntrarEmail.Location = new Point(856, 316);
            txtEntrarEmail.Name = "txtEntrarEmail";
            txtEntrarEmail.PlaceholderText = "Email";
            txtEntrarEmail.Size = new Size(461, 32);
            txtEntrarEmail.TabIndex = 9;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(799, 373);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(41, 42);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 12;
            pictureBox2.TabStop = false;
            // 
            // txtEntrarSenha
            // 
            txtEntrarSenha.BackColor = SystemColors.Control;
            txtEntrarSenha.BorderStyle = BorderStyle.None;
            txtEntrarSenha.Font = new Font("Segoe UI", 18F);
            txtEntrarSenha.Location = new Point(856, 378);
            txtEntrarSenha.Name = "txtEntrarSenha";
            txtEntrarSenha.PasswordChar = '*';
            txtEntrarSenha.PlaceholderText = "Senha";
            txtEntrarSenha.Size = new Size(461, 32);
            txtEntrarSenha.TabIndex = 11;
            // 
            // TelaLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1350, 729);
            Controls.Add(pictureBox2);
            Controls.Add(txtEntrarSenha);
            Controls.Add(pictureBox1);
            Controls.Add(txtEntrarEmail);
            Controls.Add(btnEntrarLogin);
            Name = "TelaLogin";
            Text = "Minhas Finanças - Login";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnEntrarLogin;
        private PictureBox pictureBox1;
        private TextBox txtEntrarEmail;
        private PictureBox pictureBox2;
        private TextBox txtEntrarSenha;
    }
}