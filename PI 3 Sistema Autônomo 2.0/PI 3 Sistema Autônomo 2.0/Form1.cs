using Draft;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PI_3_Sistema_Autônomo_2._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            lbl4.Text = Jogo.versao;
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
                {
                    lstListadePartidas.Items.Add(p);
                }
            }
        }

        private void lstDadosPartida_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string partida = lstListadePartidas.SelectedItem.ToString();
            string[] dadosPartida = partida.Split(',');

            int idPartida = Convert.ToInt32(dadosPartida[0]);
            string nomePartida = dadosPartida[1];
            string data = dadosPartida[2];

            lblID.Text = idPartida.ToString();
            lblNomeDaPartida.Text = nomePartida;
            lblDataDaPartida.Text = data;

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

            if (nome == "" || senha == "" || grupo == "")
            {
                MessageBox.Show("Erro: Todos os campos são obrigatórios!",
                "Meu PI 3", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (string item in lstListadePartidas.Items)
            {
                if (item.Contains("," + nome + ","))
                {
                    MessageBox.Show("Erro: Já existe uma partida com esse nome!",
                    "Meu PI 3", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (item.Contains("," + senha + ","))
                {
                    MessageBox.Show("Erro: Já existe uma partida com essa senha!",
                    "Meu PI 3", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            string retorno = Jogo.CriarPartida(nome, senha, grupo);

            if (retorno.Substring(0, 4) == "ERRO")
            {
                MessageBox.Show("Erro:\n" + retorno.Substring(5),
                "Meu PI 3", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Partida criada com sucesso!",
            "Meu PI 3", MessageBoxButtons.OK, MessageBoxIcon.Information);


            string retornoLista = Jogo.ListarPartidas("T");

            retornoLista = retornoLista.Replace("\r", "");
            retornoLista = retornoLista.Substring(0, retornoLista.Length - 1);
            string[] partidas = retornoLista.Split('\n');

            lstListadePartidas.Items.Clear();

            button1_Click(null, null);

            txtNome.Clear();
            txtSenha.Clear();
            txtGrupo.Clear();
        }
    }
}
