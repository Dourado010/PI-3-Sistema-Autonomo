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
        string dinoSelecionado = "";
        string ultimoTurno = "";
        string ultimoJogador = "";
        string ultimoDado = "";

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

            if (retorno.StartsWith("ERRO"))
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

            AtualizarTurno();
            MostrarMao();
            MostrarCercados();

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

        void SelecionarDino(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;

            dinoSelecionado = pb.Tag.ToString();

            MessageBox.Show("Dino selecionado: " + dinoSelecionado);
        }

        void MostrarMao()
        {
            flowMao.Controls.Clear();

            int idJogador = Convert.ToInt32(idJogadorSalvo);

            string retorno = Jogo.ExibirMao(idJogador, senhaJogadorSalvo);

            retorno = retorno.Replace("\r", "");
            string[] dinos = retorno.Split('\n');

            foreach (string d in dinos)
            {
                if (d.Trim() != "")
                {
                    PictureBox pb = new PictureBox();
                    pb.Width = 50;
                    pb.Height = 50;
                    pb.SizeMode = PictureBoxSizeMode.StretchImage;

                    pb.Image = PegarImagemDino(d);
                    pb.Tag = d;
                    pb.Click += SelecionarDino;

                    flowMao.Controls.Add(pb);
                }
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

            string[] dados = retorno.Split(',');

            if (dados.Length < 3)
            {
                MessageBox.Show("Retorno inesperado: " + retorno);
                return;
            }

            string turno = dados[0];
            string idJogadorDaVez = dados[1];
            string dado = dados[2];

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

            if (turno != ultimoTurno || idJogadorDaVez != ultimoJogador || dado != ultimoDado)
            {
                MessageBox.Show("Novo turno!\nJogador: " + nomeJogador + "\nDado: " + dado);

                lstHistorico.Items.Add("Turno " + turno + " - " + nomeJogador + " (" + dado + ")");

                MostrarMao();
                MostrarCercados();
            }

            lblTurno.Text = "Turno: " + turno;
            lblJogadorDaVez.Text = "Jogador: " + nomeJogador;
            lblDado.Text = "Dado: " + dado;

            ultimoTurno = turno;
            ultimoJogador = idJogadorDaVez;
            ultimoDado = dado;
        }

        void AdicionarDino(FlowLayoutPanel panel, string dino)
        {
            PictureBox pb = new PictureBox();
            pb.Width = 40;
            pb.Height = 40;
            pb.SizeMode = PictureBoxSizeMode.StretchImage;

            pb.Image = PegarImagemDino(dino);

            panel.Controls.Add(pb);
        }

        void MostrarCercados()
        {
            flowCampinaDiferenca.Controls.Clear();
            flowFlorestaIgualdade.Controls.Clear();
            flowIlhaSolitaria.Controls.Clear();
            flowMataTripla.Controls.Clear();
            flowReiSelva.Controls.Clear();
            flowPradariaAmor.Controls.Clear();

            int idJogador = Convert.ToInt32(idJogadorSalvo);

            string retorno = Jogo.ListarCercados();

            retorno = retorno.Replace("\r", "");
            string[] linhas = retorno.Split('\n');

            foreach (string l in linhas)
            {
                if (l.Trim() == "") continue;

                string[] partes = l.Split(',');

                if (partes.Length < 2) continue;

                string cercado = partes[0];
                string dino = partes[1];

                if (cercado == "CD")
                    AdicionarDino(flowCampinaDiferenca, dino);
                else if (cercado == "FI")
                    AdicionarDino(flowFlorestaIgualdade, dino);
                else if (cercado == "IS")
                    AdicionarDino(flowIlhaSolitaria, dino);
                else if (cercado == "MT")
                    AdicionarDino(flowMataTripla, dino);
                else if (cercado == "RS")
                    AdicionarDino(flowReiSelva, dino);
                else if (cercado == "PA")
                    AdicionarDino(flowPradariaAmor, dino);
            }
        }

        private void btnJogar_Click(object sender, EventArgs e)
        {
            if (dinoSelecionado == "")
            {
                MessageBox.Show("Selecione um dinossauro!");
                return;
            }

            string dinoId = dinoSelecionado.Split(',')[0];
            string dinoNome = dinoSelecionado.Split(',')[1];

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

            System.Threading.Thread.Sleep(500);

            dinoSelecionado = "";
            txtCercado.Clear();

            AtualizarTurno();
            MostrarMao();
            MostrarCercados();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            AtualizarTurno();
            MostrarMao();
            MostrarCercados();
        }

        Image PegarImagemDino(string codigo)
        {
            if (codigo.StartsWith("Br"))
                return Image.FromFile("Images/braquiossauro.png");

            if (codigo.StartsWith("Tr"))
                return Image.FromFile("Images/triceratops.png");

            if (codigo.StartsWith("Ti"))
                return Image.FromFile("Images/tiranossauro.png");

            if (codigo.StartsWith("Et"))
                return Image.FromFile("Images/estegossauro.png");

            if (codigo.StartsWith("Pa"))
                return Image.FromFile("Images/parasaurolofo.png");

            if (codigo.StartsWith("Ep"))
                return Image.FromFile("Images/espinossauro.png");

            return null;
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