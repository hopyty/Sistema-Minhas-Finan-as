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
    public partial class TelaCadastroConta : Form
    {
        private string connString = "Host=localhost;Username=postgres;Password=asd456;Database=ControleFinancas";

        public TelaCadastroConta()
        {
            InitializeComponent();
            carregarcontas();
        }

        private void btnTelaInicialcad_Click(object sender, EventArgs e)
        {
            TelaInicial telainicial = new TelaInicial();
            this.Hide();
            telainicial.Show();
        }

        private void btnAddConta_Click(object sender, EventArgs e)
        {
            string banco = txtdescbanco.Text;
            string tipconta = BoxCadconta.Text;
            double valorinicial = double.Parse(txtvalorinicial.Text);
            int userid = Sessao.IdUsuarioLogado;

            if (string.IsNullOrWhiteSpace(banco) || string.IsNullOrWhiteSpace(tipconta) || valorinicial < 0)
            {
                MessageBox.Show("Informe todos os dados para atribuir uma conta!");
                return;
            }

            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                string insertSql = "INSERT INTO conta (id_usuario, nome_banco, tipo_conta, saldo_inicial) VALUES(@iduser,@banco,@tpconta,@saldo)";


                using (var cmd = new NpgsqlCommand(insertSql, conn))
                {
                    cmd.Parameters.AddWithValue("iduser", userid);
                    cmd.Parameters.AddWithValue("banco", banco);
                    cmd.Parameters.AddWithValue("tpconta", tipconta);
                    cmd.Parameters.AddWithValue("saldo", valorinicial);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Nova conta Cadastrado com Sucesso!");

            txtdescbanco.Clear();
            txtvalorinicial.Clear();

            carregarcontas();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void carregarcontas()
        {
            int iduser = Sessao.IdUsuarioLogado;

            listBox1.Items.Clear();

            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();

                string selectSql = @"
                    SELECT  b.nome_banco,
                            b.tipo_conta,
                            b.saldo_inicial,
                            a.nome,
		                    a.email
                    FROM usuario a
                    INNER JOIN conta b ON a.id_usuario = b.id_usuario
                    WHERE a.id_usuario = @idusuario";

                using (var cmd = new NpgsqlCommand(selectSql, conn))
                {
                    cmd.Parameters.AddWithValue("idusuario", iduser);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string banco = reader.GetString(0);
                            string tipo = reader.GetString(1);
                            double saldo = reader.GetDouble(2);
                            string responsavel = reader.GetString(3);
                            string contato = reader.GetString(4);


                            string linha = $"Banco: {banco} | Tipo: {tipo} | Valor: {saldo.ToString("C", new CultureInfo("pt-BR"))} | Responsavel: {responsavel} | Contato: {contato}";
                            listBox1.Items.Add(linha);
                        }
                    }
                }
            }
        }
    }
}
