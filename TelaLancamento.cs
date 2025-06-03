using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using Npgsql;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static Sistema_Minhas_Finanças.Program;

namespace Sistema_Minhas_Finanças
{
    public partial class TelaLancamento : Form
    {
        private string connString = "Host=localhost;Username=postgres;Password=asd456;Database=ControleFinancas";
        public TelaLancamento()
        {
            InitializeComponent();
            CarregarTransacoes();
        }
        private void btnTelaInicial_Click(object sender, EventArgs e)
        {
            TelaInicial telainicial = new TelaInicial();
            this.Hide();
            telainicial.Show();
        }
        private void RbtDespesa_CheckedChanged_1(object sender, EventArgs e)
        {
            if (RbtDespesa.Checked)
            {
                CarregarCategoriasDespesa();
                categoria.tipocategoria = "despesa";

            }
        }
        private void RbtReceita_CheckedChanged_1(object sender, EventArgs e)
        {
            if (RbtReceita.Checked)
            {
                CarregarCategoriasReceita();
                categoria.tipocategoria = "receita";

            }
        }
        private void CarregarCategoriasReceita()
        {
            BoxCategoria.DataSource = null;

            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                string selectSql = "SELECT id_categoria, nome FROM categoria WHERE tipo = 'receita'";

                using (var cmd = new NpgsqlCommand(selectSql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    var lista = new List<KeyValuePair<int, string>>();

                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string nome = reader.GetString(1);

                        lista.Add(new KeyValuePair<int, string>(id, nome));
                    }

                    BoxCategoria.DataSource = lista;
                    BoxCategoria.DisplayMember = "Value"; 
                    BoxCategoria.ValueMember = "Key"; 
                }
                conn.Close();
                CarregarContas();
            }
        }
        private void CarregarCategoriasDespesa()
        {
            BoxCategoria.DataSource = null;

            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                string selectSql = "SELECT id_categoria, nome FROM categoria WHERE tipo = 'despesa'";

                using (var cmd = new NpgsqlCommand(selectSql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    var lista = new List<KeyValuePair<int, string>>();

                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string nome = reader.GetString(1);

                        lista.Add(new KeyValuePair<int, string>(id, nome));
                    }

                    BoxCategoria.DataSource = lista;
                    BoxCategoria.DisplayMember = "Value"; 
                    BoxCategoria.ValueMember = "Key"; 
                }
                conn.Close();
                CarregarContas();
            }
        }
        private void CarregarContas()
        {
            BoxConta.DataSource = null; 
            int iduser = Sessao.IdUsuarioLogado;

            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                string selectSql = "SELECT id_conta, nome_banco FROM conta WHERE id_usuario = @idusuario";

                using (var cmd = new NpgsqlCommand(selectSql, conn))
                {
                    cmd.Parameters.AddWithValue("idusuario", iduser);

                    using (var reader = cmd.ExecuteReader())
                    {
                        var listaconta = new List<KeyValuePair<int, string>>();

                        while (reader.Read())
                        {
                            int idconta = reader.GetInt32(0);
                            string nomebanco = reader.GetString(1);

                            listaconta.Add(new KeyValuePair<int, string>(idconta, nomebanco));
                        }

                        BoxConta.DisplayMember = "Value";
                        BoxConta.ValueMember = "Key";   
                        BoxConta.DataSource = listaconta;
                    }
                }
            }
        }
        private void BoxCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (BoxCategoria.SelectedItem is KeyValuePair<int, string> selectedItem)
            {
                categoria.categorialancamento = selectedItem.Key;
            }
        }
        private void BoxConta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (BoxConta.SelectedItem is KeyValuePair<int, string> selectedItem)
            {
                Sessao.idcontalancamento = selectedItem.Key;
            }
        }
        private void btnLancamento_Click(object sender, EventArgs e)
        {
            int idconta = Sessao.idcontalancamento;
            int categoriaselecionada = categoria.categorialancamento;
            string descriçao = TextBoxdesc.Text;
            string tipo = categoria.tipocategoria;
            double valor = double.Parse(TxtValor.Text, NumberStyles.Currency, new CultureInfo("pt-BR"));

            if (string.IsNullOrWhiteSpace(tipo) || valor <= 0)
            {
                MessageBox.Show("Favor Informar O Valor e Categoria Para o Lançamento!");
                return;
            }

            if (tipo.Equals("despesa", StringComparison.OrdinalIgnoreCase) && valor > 0)
            {
                valor *= -1;
            }

            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                string insertSql = "INSERT INTO transacao (id_conta, id_categoria, data, valor, descricao, tipo) VALUES(@icont,@catgoria,@data,@valor,@descricao,@tipo)";

                using (var cmd = new NpgsqlCommand(insertSql, conn))
                {
                    cmd.Parameters.AddWithValue("icont", idconta);
                    cmd.Parameters.AddWithValue("catgoria", categoriaselecionada);
                    cmd.Parameters.AddWithValue("data", DateTime.Now);
                    cmd.Parameters.AddWithValue("valor", valor);
                    cmd.Parameters.AddWithValue("descricao", descriçao);
                    cmd.Parameters.AddWithValue("tipo", tipo);
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Novo Usuario Cadastrado com Sucesso!");
            CarregarTransacoes();
        }
        private void CarregarTransacoes()
        {
            int iduser = Sessao.IdUsuarioLogado;

            listBox1.Items.Clear(); 

            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();

                string selectSql = @"
                    SELECT  c.Id_transacao,
                            b.nome_banco,
                            d.nome AS nome_categoria,
                            c.data,
                            c.valor,
                            c.descricao,
                            c.tipo
                    FROM usuario a
                    INNER JOIN conta b ON a.id_usuario = b.id_usuario
                    INNER JOIN transacao c ON b.id_conta = c.id_conta
                    INNER JOIN categoria d ON c.id_categoria = d.id_categoria
                    WHERE a.id_usuario = @idusuario
                    ORDER BY c.data DESC";

                using (var cmd = new NpgsqlCommand(selectSql, conn))
                {
                    cmd.Parameters.AddWithValue("idusuario", iduser);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int documento = reader.GetInt32(0);
                            string conta = reader.GetString(1);
                            string categoria = reader.GetString(2);
                            DateTime data = reader.GetDateTime(3);
                            double valor = reader.GetDouble(4);
                            string descricao = reader.GetString(5);
                            string tipo = reader.GetString(6);

                            string linha = $"Documento: {documento} | Conta: {conta} | Categoria: {categoria} | Data: {data.ToShortDateString()} | Valor: {valor.ToString("C", new CultureInfo("pt-BR"))} | Descrição: {descricao} | Tipo: {tipo}";
                            listBox1.Items.Add(linha);
                        }
                    }
                }
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Selecione uma transação para excluir.");
                return;
            }

            string linhaSelecionada = listBox1.SelectedItem.ToString();
            Match match = Regex.Match(linhaSelecionada, @"Documento:\s*(\d+)");

            if (!match.Success)
            {
                MessageBox.Show("Não foi possível identificar o ID da transação.");
                return;
            }

            int idTransacao = int.Parse(match.Groups[1].Value);


            DialogResult confirm = MessageBox.Show("Deseja realmente excluir esta transação?", "Confirmação", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes)
                return;


            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();

                string deleteSql = "DELETE FROM transacao WHERE id_transacao = @id";

                using (var cmd = new NpgsqlCommand(deleteSql, conn))
                {
                    cmd.Parameters.AddWithValue("id", idTransacao);

                    int linhasAfetadas = cmd.ExecuteNonQuery();

                    if (linhasAfetadas > 0)
                    {
                        MessageBox.Show("Transação excluída com sucesso.");
                        CarregarTransacoes();
                    }
                    else
                    {
                        MessageBox.Show("Erro ao excluir transação. Verifique se o ID é válido.");
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TelaPoupanca telapupar = new TelaPoupanca();
            this.Hide();
            telapupar.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TelaLancamento telalancamento = new TelaLancamento();
            this.Hide();
            telalancamento.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Telanotificacoes telanotifica = new Telanotificacoes();
            this.Hide();
            telanotifica.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TelaExtrato telarel = new TelaExtrato();
            this.Hide();
            telarel.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

