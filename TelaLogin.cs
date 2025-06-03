using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using Sistema_Minhas_Finanças;
using static Sistema_Minhas_Finanças.Program;

namespace Sistema_Minhas_Finanças
{
    public partial class TelaLogin : Form
    {
        private string connString = "Host=localhost;Username=postgres;Password=asd456;Database=ControleFinancas";
        public TelaLogin()
        {
            InitializeComponent();
        }

        private void btnEntrarLogin_Click(object sender, EventArgs e)
        {
            string email = txtEntrarEmail.Text;
            string senha = txtEntrarSenha.Text;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha))
            {
                MessageBox.Show("Por favor, informe seu Email e Senha para fazer login.");
                return;
            }

            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                string selectSql = "SELECT id_usuario, nome FROM Usuario WHERE email = @email AND senha = @senha";

                using (var cmd = new NpgsqlCommand(selectSql, conn))
                {
                    cmd.Parameters.AddWithValue("email", email);
                    cmd.Parameters.AddWithValue("senha", senha);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Sessao.IdUsuarioLogado = reader.GetInt32(0);
                            Sessao.NomeUsuarioLogado = reader.GetString(1);

                            TelaInicial telainicial = new TelaInicial();
                            this.Hide();
                            telainicial.Show();
                        }
                        else
                        {
                            MessageBox.Show("Email ou senha incorretos.");
                        }
                    }
                }            
            }
        }
    }
}
