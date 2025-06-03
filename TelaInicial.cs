using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using static Sistema_Minhas_Finanças.Program;

namespace Sistema_Minhas_Finanças
{
    public partial class TelaInicial : Form
    {
        private string connString = "Host=localhost;Username=postgres;Password=asd456;Database=ControleFinancas";
        public TelaInicial()
        {
            InitializeComponent();
            carregarmovimentos();
            valortotal();
            valorReceitas();
            valorDespesas();
        }
        private void TelaInicial_Load(object sender, EventArgs e)
        {
            label1.Text = $"Bem-vindo, {Sessao.NomeUsuarioLogado}!";
        }
        private void btnInicialLancamento_Click_1(object sender, EventArgs e)
        {
            TelaLancamento telalancamento = new TelaLancamento();
            this.Hide();
            telalancamento.Show();
        }
        private void BtnConta_Click(object sender, EventArgs e)
        {
            TelaCadastroConta telaconta = new TelaCadastroConta();
            this.Hide();
            telaconta.Show();
        }

        private void btnpTelaInicialpoupanca_Click(object sender, EventArgs e)
        {
            TelaPoupanca telapupar = new TelaPoupanca();
            this.Hide();
            telapupar.Show();
        }

        private void btnpTelaInicialnotificacoes_Click(object sender, EventArgs e)
        {
            Telanotificacoes telanotifica = new Telanotificacoes();
            this.Hide();
            telanotifica.Show();
        }

        private void btnpTelaextrato_Click(object sender, EventArgs e)
        {
            TelaExtrato telarel = new TelaExtrato();
            this.Hide();
            telarel.Show();
        }

        private void btnTelaInicial_Click(object sender, EventArgs e)
        {
            TelaInicial telainicial = new TelaInicial();
            this.Hide();
            telainicial.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void carregarmovimentos()
        {
            int iduser = Sessao.IdUsuarioLogado;

            listBox1.Items.Clear();

            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();

                string selectSql = @"
                    SELECT	b.nome_banco,
		                    b.tipo_conta,
		                    c.data,
		                    c.valor,
		                    c.descricao,
		                    c.tipo,
		                    d.nome
                    FROM usuario a
                    INNER JOIN conta b ON a.id_usuario = b.id_usuario
                    INNER JOIN transacao c ON b.id_conta = c.id_conta
                    INNER JOIN categoria d ON c.id_categoria = d.id_categoria
                    WHERE a.id_usuario = @idusuario";

                using (var cmd = new NpgsqlCommand(selectSql, conn))
                {
                    cmd.Parameters.AddWithValue("idusuario", iduser);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string banco = reader.GetString(0);
                            string tipoconta = reader.GetString(1);
                            DateTime data = reader.GetDateTime(2);
                            double valor = reader.GetDouble(3);
                            string descricao = reader.GetString(4);
                            string tipo = reader.GetString(5);
                            string categoria = reader.GetString(6);


                            string linha = $"Banco: {banco} | Tipo de Conta: {tipoconta} | Data Movimento: {data.ToShortDateString()} | Valor: {valor.ToString("C", new CultureInfo("pt-BR"))} | Descriçao: {descricao} | Tipo Movimento: {tipo} | Categoria: {categoria}";
                            listBox1.Items.Add(linha);
                        }
                    }
                }
            }
        }
        private void valortotal()
        {
            int iduser = Sessao.IdUsuarioLogado;

            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();

                string selectSql = @"
                    SELECT 
                        SUM(b.saldo_inicial + 
                            CASE 
                                WHEN c.tipo = 'receita' THEN c.valor
                                WHEN c.tipo = 'despesa' THEN -c.valor
                                ELSE 0
                            END
                        ) AS total
                    FROM usuario a
                    INNER JOIN conta b ON a.id_usuario = b.id_usuario
                    INNER JOIN transacao c ON b.id_conta = c.id_conta
                    INNER JOIN categoria d ON c.id_categoria = d.id_categoria
                    WHERE a.id_usuario = @idusuario";

                using (var cmd = new NpgsqlCommand(selectSql, conn))
                {
                    cmd.Parameters.AddWithValue("idusuario", iduser);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read() && !reader.IsDBNull(0))
                        {
                            double total = reader.GetDouble(0);
                            label4.Text = total.ToString("C", new CultureInfo("pt-BR"));
                        }
                        else
                        {
                            label4.Text = "R$ 0,00";
                        }
                    }
                }
            }
        }
        private void valorReceitas()
        {
            int iduser = Sessao.IdUsuarioLogado;

            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();

                string selectSql = @"
                    SELECT 
                        SUM(b.saldo_inicial + 
                            CASE 
                                WHEN c.tipo = 'receita' THEN c.valor
                                WHEN c.tipo = 'despesa' THEN -c.valor
                                ELSE 0
                            END
                        ) AS total
                    FROM usuario a
                    INNER JOIN conta b ON a.id_usuario = b.id_usuario
                    INNER JOIN transacao c ON b.id_conta = c.id_conta
                    INNER JOIN categoria d ON c.id_categoria = d.id_categoria
                    WHERE a.id_usuario = @idusuario
                        AND c.tipo='receita'";

                using (var cmd = new NpgsqlCommand(selectSql, conn))
                {
                    cmd.Parameters.AddWithValue("idusuario", iduser);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read() && !reader.IsDBNull(0))
                        {
                            double total = reader.GetDouble(0);
                            label3.Text = total.ToString("C", new CultureInfo("pt-BR"));
                        }
                        else
                        {
                            label3.Text = "R$ 0,00";
                        }
                    }
                }
            }
        }
        private void valorDespesas()
        {
            int iduser = Sessao.IdUsuarioLogado;

            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();

                string selectSql = @"
                    SELECT 
                        SUM(b.saldo_inicial + 
                            CASE 
                                WHEN c.tipo = 'receita' THEN c.valor
                                WHEN c.tipo = 'despesa' THEN -c.valor
                                ELSE 0
                            END
                        ) AS total
                    FROM usuario a
                    INNER JOIN conta b ON a.id_usuario = b.id_usuario
                    INNER JOIN transacao c ON b.id_conta = c.id_conta
                    INNER JOIN categoria d ON c.id_categoria = d.id_categoria
                    WHERE a.id_usuario = @idusuario
                        AND c.tipo='despesa'";

                using (var cmd = new NpgsqlCommand(selectSql, conn))
                {
                    cmd.Parameters.AddWithValue("idusuario", iduser);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read() && !reader.IsDBNull(0))
                        {
                            double total = reader.GetDouble(0);
                            label2.Text = total.ToString("C", new CultureInfo("pt-BR"));
                        }
                        else
                        {
                            label2.Text = "R$ 0,00";
                        }
                    }
                }
            }
        }
    }
}
