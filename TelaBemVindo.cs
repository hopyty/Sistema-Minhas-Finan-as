using Npgsql;

namespace Sistema_Minhas_Finanças
{
    public partial class TelaBemVindo : Form
    {
        private string connString = "Host=localhost;Username=postgres;Password=asd456;Database=ControleFinancas";
        public TelaBemVindo()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            TelaLogin telalogin = new TelaLogin();
            this.Hide();
            telalogin.Show();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            string email = txtEmail.Text;
            string senha = txtSenha.Text;

            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha))
            {
                MessageBox.Show("Para Cadastrar é necessario informar seu: Nome, Email e Criar uma Nova Senha");
                return;
            }

            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                string insertSql = "INSERT INTO Usuario (nome,email,senha) VALUES(@nome,@email,@senha)";


                using (var cmd = new NpgsqlCommand(insertSql, conn))
                {
                    cmd.Parameters.AddWithValue("nome", nome);
                    cmd.Parameters.AddWithValue("email", email);
                    cmd.Parameters.AddWithValue("senha", senha);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Novo Usuario Cadastrado com Sucesso!");

            txtNome.Clear();
            txtEmail.Clear();
            txtSenha.Clear();
        }
    }
}
