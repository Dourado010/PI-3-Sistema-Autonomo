using Draft;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PI_Projeto_Integrador_Sistema_Autônomo
{
    public partial class Form1 : Form
    {
        string idJogadorSalvo = "";
        string senhaJogadorSalvo = "";
        public Form1()
        {
            InitializeComponent();
            lbl4.Text = Jogo.versao;

            txtGrupo.ReadOnly = true;
            txtGrupo.TabStop = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string retorno = Jogo.ListarPartidas("T");

            retorno = retorno.Replace("\r", "");
            string[] partidas = retorno.Split('\n');

            lstListadePartidas.Items.Clear();

            foreach (string p in partidas)
            {
                if (p.Trim() != "")
                    lstListadePartidas.Items.Add(p);
            }
        }

        private void lstDadosPartida_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstListadePartidas.SelectedItem == null)
                return;

            string partida = lstListadePartidas.SelectedItem.ToString();
            string[] dadosPartida = partida.Split(',');

            int idPartida = Convert.ToInt32(dadosPartida[0]);
            string nomePartida = dadosPartida[1];
            string data = dadosPartida[2];

            lblID.Text = idPartida.ToString();
            lblNomeDaPartida.Text = nomePartida;
            lblDataDaPartida.Text = data;

            txtGrupo.Text = idPartida.ToString();

            string retorno = Jogo.ListarJogadores(idPartida);

            retorno = retorno.Replace("\r", "");
            string[] jogadores = retorno.Split('\n');

            lstDadosPartida.Items.Clear();

            for (int i = 0; i < jogadores.Length - 1; i++)
            {
                lstDadosPartida.Items.Add(jogadores[i]);
            }


        }

        private void btnCriarPartida_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            string senha = txtSenha.Text;
            string grupo = txtGrupo.Text;

            if (nome == "" || senha == "")
            {
                MessageBox.Show("Erro: Nome e senha são obrigatórios!");
                return;
            }

            if (grupo == "")
                grupo = "0";

            string retorno = Jogo.CriarPartida(nome, senha, grupo);



            if (retorno.Substring(0, 4) == "ERRO")
            {
                MessageBox.Show("Erro:\n" + retorno.Substring(5));
                return;
            }

            MessageBox.Show("Partida criada com sucesso!");
            button1_Click(null, null);

            txtNome.Clear();
            txtSenha.Clear();
            txtGrupo.Clear();
        }

        private void btnEntrarNaPartida_Click(object sender, EventArgs e)
        {
            string nomeJogador = txtNomeJogador.Text.Trim();
            string senhaJogador = txtSenhaJogador.Text.Trim();
            string idTexto = txtEntrarNaSala.Text.Trim();

            if (nomeJogador == "" || senhaJogador == "" || idTexto == "")
            {
                MessageBox.Show("Preencha Nome, Senha e ID da Partida!");
                return;
            }

            int idPartida;

            if (!int.TryParse(idTexto, out idPartida))
            {
                MessageBox.Show("ID inválido!");
                return;
            }

            string retorno = Jogo.Entrar(idPartida, nomeJogador, senhaJogador);

            if (retorno.StartsWith("ERRO"))
            {
                MessageBox.Show("Erro:\n" + retorno.Substring(5));
                return;
            }

            string[] partes = retorno.Split(',');

            if (partes.Length < 2)
            {
                MessageBox.Show("Formato inesperado:\n" + retorno);
                return;
            }

            string idJogador = partes[0];

            lblIdJogador.Text = idJogador;
            lblSenhaJogador.Text = senhaJogador;

            MessageBox.Show("Jogador entrou na partida!");
        }

        private void btnIniciarPartida_Click(object sender, EventArgs e)
        {
            if (idJogadorSalvo == "" || senhaJogadorSalvo == "")
            {
                MessageBox.Show("Entre na partida primeiro");
                return;
            }

            int idJogador = Convert.ToInt32(idJogadorSalvo);

            string retorno = Jogo.Iniciar(idJogador, senhaJogadorSalvo);

            if (retorno.StartsWith("ERRO"))
            {
                MessageBox.Show(retorno);
                return;
            }

            MessageBox.Show("Partida iniciada");

            MostrarMao();
        }

        void MostrarMao()
        {
            int idJogador = Convert.ToInt32(idJogadorSalvo);

            string retorno = Jogo.ListarDinossauros(false);

            if (retorno.StartsWith("ERRO"))
            {
                MessageBox.Show(retorno);
                return;
            }

            retorno = retorno.Replace("\r", "");

            string[] dinos = retorno.Split('\n');

            lstMaoJogador.Items.Clear();

            foreach (string d in dinos)
            {
                if (d.Trim() != "")
                    lstMaoJogador.Items.Add(d);
            }
        }

        private void lstMaoJogador_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}
