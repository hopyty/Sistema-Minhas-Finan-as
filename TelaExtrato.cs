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
    public partial class TelaExtrato : Form
    {
        private string connString = "Host=localhost;Username=postgres;Password=asd456;Database=ControleFinancas";
        public TelaExtrato()
        {
            InitializeComponent();
        }

        private void btnpTelaInicialpoupanca_Click(object sender, EventArgs e)
        {
            TelaPoupanca telapupar = new TelaPoupanca();
            this.Hide();
            telapupar.Show();
        }

        private void btnTelaInicial_Click(object sender, EventArgs e)
        {
            TelaInicial telainicial = new TelaInicial();
            this.Hide();
            telainicial.Show();
        }

        private void btnInicialLancamento_Click(object sender, EventArgs e)
        {
            TelaLancamento telalancamento = new TelaLancamento();
            this.Hide();
            telalancamento.Show();
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void carregarmovimentos()
        {
            int iduser = Sessao.IdUsuarioLogado;
            DateTime dataSelecionada = dateTimePicker1.Value.Date; 

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
                    WHERE a.id_usuario = @idusuario
                      AND c.data::date = @data";
                using (var cmd = new NpgsqlCommand(selectSql, conn))
                {
                    cmd.Parameters.AddWithValue("idusuario", iduser);
                    cmd.Parameters.AddWithValue("data", dataSelecionada);

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

                            string linha = $"Banco: {banco} | Tipo de Conta: {tipoconta} | Data Movimento: {data.ToShortDateString()} | Valor: {valor.ToString("C", new CultureInfo("pt-BR"))} | Descrição: {descricao} | Tipo Movimento: {tipo} | Categoria: {categoria}";
                            listBox1.Items.Add(linha);
                        }
                    }
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            carregarmovimentos();
        }
    }
}
