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
        int idPartidaSalvo = 0;
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
            string grupo = "Paleontólogos";

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

            idPartidaSalvo = idPartida;

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
            string senhaGerada = partes[1];

            idJogadorSalvo = idJogador;
            senhaJogadorSalvo = senhaGerada;

            lblIdJogador.Text = idJogadorSalvo;
            lblSenhaJogador.Text = senhaJogadorSalvo;

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

            AtualizarTurno();
            MostrarMao();
            MostrarCercados();
        }

        void MostrarMao()
        {
            if (idJogadorSalvo == "" || senhaJogadorSalvo == "")
            {
                MessageBox.Show("Entre na partida primeiro!");
                return;
            }

            int idJogador = Convert.ToInt32(idJogadorSalvo);

            string retorno = Jogo.ExibirMao(idJogador, senhaJogadorSalvo);

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

        void AtualizarTurno()
        {
            int idJogador = Convert.ToInt32(idJogadorSalvo);

            string retorno = Jogo.VerificarTurno(idPartidaSalvo);

            if (retorno.StartsWith("ERRO"))
            {
                MessageBox.Show(retorno);
                return;
            }

            // esperado: turno,nomeJogador,dado

            string[] dados = retorno.Split(',');

            if (dados.Length < 3)
            {
                MessageBox.Show("Retorno inesperado: " + retorno);
                return;
            }

            string turno = dados[0];
            string idJogadorDaVez = dados[1];
            string dado = dados[2];

            // 🔥 AGORA PEGAR NOME DO JOGADOR
            string lista = Jogo.ListarJogadores(idPartidaSalvo);

            lista = lista.Replace("\r", "");
            string[] jogadores = lista.Split('\n');

            string nomeJogador = "Desconhecido";

            foreach (string j in jogadores)
            {
                if (j.Trim() != "")
                {
                    string[] info = j.Split(',');

                    if (info[0] == idJogadorDaVez)
                    {
                        nomeJogador = info[1];
                        break;
                    }
                }
            }

            lblTurno.Text = "Turno: " + turno;
            lblJogadorDaVez.Text = "Jogador: " + nomeJogador;
            lblDado.Text = "Dado: " + dado;
        }

        void MostrarCercados()
        {
            int idJogador = Convert.ToInt32(idJogadorSalvo);

            string retorno = Jogo.ListarCercados();

            if (retorno.StartsWith("ERRO"))
            {
                MessageBox.Show(retorno);
                return;
            }

            retorno = retorno.Replace("\r", "");

            string[] linhas = retorno.Split('\n');

            lstCercados.Items.Clear();

            foreach (string l in linhas)
            {
                if (l.Trim() != "")
                    lstCercados.Items.Add(l);
            }
        }



        private void lstMaoJogador_SelectedIndexChanged(object sender, EventArgs e) { }

        private void btnJogar_Click(object sender, EventArgs e)
        {
            if (lstMaoJogador.SelectedItem == null)
            {
                MessageBox.Show("Selecione um dinossauro!");
                return;
            }

            string item = lstMaoJogador.SelectedItem.ToString();
            string dinoId = item.Split(',')[0];
            string dinoNome = item.Split(',')[1];

            if (lblDado.Text.Contains("Carn") && !dinoNome.Contains("Carn"))
            {
                MessageBox.Show("Jogada inválida para esse dado!");
                return;
            }

            int idJogador = Convert.ToInt32(idJogadorSalvo);
            string cercado = txtCercado.Text;

            string retorno = Jogo.Jogar(idJogador, senhaJogadorSalvo, dinoId, cercado);

            if (retorno.StartsWith("ERRO"))
            {
                MessageBox.Show(retorno);
                return;
            }

            MessageBox.Show("Jogada realizada!");

            MostrarMao();
            AtualizarTurno();
            MostrarCercados();
        }

        private void lstListadePartidas_SelectedIndexChanged(object sender, EventArgs e)
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
    }
}
