using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static Sistema_Minhas_Finanças.Program;

namespace Sistema_Minhas_Finanças
{
    public partial class Telanotificacoes : Form
    {
        private string connString = "Host=localhost;Username=postgres;Password=asd456;Database=ControleFinancas";
        public Telanotificacoes()
        {
            InitializeComponent();
            carregarnotificacoes();
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string titulo = textBox1.Text;
            string tpfrequencia = comboBox1.Text;
            string descricao = richTextBox1.Text;
            DateTime dataSelecionada = dateTimePicker1.Value.Date;
            int userid = Sessao.IdUsuarioLogado;

            if (string.IsNullOrWhiteSpace(titulo) || string.IsNullOrWhiteSpace(tpfrequencia))
            {
                MessageBox.Show("Informe o título e a frequência!");
                return;
            }

            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                string insertSql = "INSERT INTO lembrete_financeiro (id_usuario, titulo, descricao, data_lembrete, frequencia) VALUES(@iduser, @tit, @desc, @dta, @frq)";

                using (var cmd = new NpgsqlCommand(insertSql, conn))
                {
                    cmd.Parameters.AddWithValue("iduser", userid);
                    cmd.Parameters.AddWithValue("tit", titulo);
                    cmd.Parameters.AddWithValue("desc", descricao);
                    cmd.Parameters.AddWithValue("dta", dataSelecionada);
                    cmd.Parameters.AddWithValue("frq", tpfrequencia);
                    cmd.ExecuteNonQuery();
                }
                carregarnotificacoes();
            }

            MessageBox.Show("Novo lembrete cadastrado com sucesso!");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string titulo = textBox2.Text;
            string tpfrequencia = comboBox2.Text;
            string descricao = richTextBox2.Text;
            DateTime dataSelecionada = dateTimePicker2.Value.Date;
            int userid = Sessao.IdUsuarioLogado;

            if (!int.TryParse(textBox3.Text, out int idref))
            {
                MessageBox.Show("ID de referência inválido.");
                return;
            }

            if (string.IsNullOrWhiteSpace(titulo) || string.IsNullOrWhiteSpace(tpfrequencia))
            {
                MessageBox.Show("Informe o título e a frequência!");
                return;
            }

            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();

                string updateSql = @"
            UPDATE lembrete_financeiro
            SET titulo = @tit,
                descricao = @desc,
                data_lembrete = @dta,
                frequencia = @frq
            WHERE id_usuario = @iduser
              AND id_lembrete = @idref";

                using (var cmd = new NpgsqlCommand(updateSql, conn))
                {
                    cmd.Parameters.AddWithValue("tit", titulo);
                    cmd.Parameters.AddWithValue("desc", descricao);
                    cmd.Parameters.AddWithValue("dta", dataSelecionada);
                    cmd.Parameters.AddWithValue("frq", tpfrequencia);
                    cmd.Parameters.AddWithValue("iduser", userid);
                    cmd.Parameters.AddWithValue("idref", idref);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Lembrete atualizado com sucesso!");
                    }
                    else
                    {
                        MessageBox.Show("Nenhum lembrete foi atualizado. Verifique o ID.");
                    }
                }
                carregarnotificacoes();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            int iduser = Sessao.IdUsuarioLogado;

            if (!int.TryParse(textBox3.Text, out int refid))
            {
                MessageBox.Show("ID inválido.");
                return;
            }

            listBox1.Items.Clear();

            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();

                string selectSql = @"
                    SELECT titulo,
                           descricao,
                           data_lembrete,
                           frequencia
                    FROM lembrete_financeiro
                    WHERE id_usuario = @idusuario
                      AND id_lembrete = @idlemb";

                using (var cmd = new NpgsqlCommand(selectSql, conn))
                {
                    cmd.Parameters.AddWithValue("idusuario", iduser);
                    cmd.Parameters.AddWithValue("idlemb", refid);

                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            textBox2.Text = reader.GetString(0);
                            richTextBox2.Text = reader.GetString(1);
                            dateTimePicker2.Value = reader.GetDateTime(2);
                            comboBox2.Text = reader.GetString(3);
                        }
                        else
                        {
                            MessageBox.Show("Lembrete não encontrado.");
                        }
                    }
                }
            }
        }
        private void carregarnotificacoes()
        {
            int iduser = Sessao.IdUsuarioLogado;
           
            listBox1.Items.Clear(); 

            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();

                string selectSql = @"
                    SELECT	id_lembrete,
                            titulo,
		                    descricao,
		                    data_lembrete,
		                    frequencia
                    FROM public.lembrete_financeiro
                    WHERE id_usuario =@idusuario";
                using (var cmd = new NpgsqlCommand(selectSql, conn))
                {
                    cmd.Parameters.AddWithValue("idusuario", iduser);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int idlembrete = reader.GetInt32(0);
                            string titi = reader.GetString(1);
                            string descc = reader.GetString(2);
                            DateTime dataa = reader.GetDateTime(3);
                            string freqc = reader.GetString(4);

                            string linha = $"Titulo: {idlembrete} | Titulo: {titi} | Descriçao: {descc} | Data Lembrete: {dataa.ToShortDateString()} | Frequencia: {freqc}";
                            listBox1.Items.Add(linha);
                        }
                    }
                }
            }
        }
    }
}