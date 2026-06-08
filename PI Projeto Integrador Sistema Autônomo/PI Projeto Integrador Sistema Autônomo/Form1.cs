using Draft;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PI_Projeto_Integrador_Sistema_Autônomo
{
    public partial class Form1 : Form
    {
        // Guarda o ID do jogador que entrou na partida
        string idJogadorSalvo = "";

        // Guarda a senha do jogador
        string senhaJogadorSalvo = "";

        // Guarda o ID da partida atual
        int idPartidaSalvo = 0;

        // Guarda o último turno conhecido pela aplicação
        string ultimoTurno = "";

        // Guarda o ID do jogador que está com o dado no turno atual
        string ultimoJogador = "";

        // Guarda a face do dado sorteada no turno atual
        string ultimoDado = "";

        // Indica se a partida já foi iniciada
        bool partidaIniciada = false;

        // Controla se a IA já jogou no turno atual, evitando jogadas duplicadas
        bool jaJogueiNesseTurno = false;

        public Form1()
        {
            InitializeComponent();

            tmrVerificarPartidas.Enabled = true;

            lblVersao.Text = Jogo.versao;

            txtGrupo.ReadOnly = true; // Impede que o usuário digite manualmente no campo do grupo/partida
            txtGrupo.TabStop = false; // Faz com que o usuário possa mover pelos campos usando tab
        }

        void CarregarListaPartidas()
        {
            string retorno = Jogo.ListarPartidas("T"); 

            retorno = retorno.Replace("\r", ""); // Remove caracteres de quebra de linha 
            string[] partidas = retorno.Split('\n'); // Divide o retorno em várias linhas

            lstListadePartidas.Items.Clear(); 

            foreach (string p in partidas) // Percorre cada partida e coloca na lista
            {
                if (p.Trim() != "")
                    lstListadePartidas.Items.Add(p); // Adiciona a partida na ListBox
            }
        }

        Dictionary<string, List<string>> LerTabuleiro() // Lê o tabuleiro atual do jogador e organiza em um dicionário
        {
            // Cria um dicionário onde cada cercado possui uma lista de dinossauros
            var tabuleiro = new Dictionary<string, List<string>>()
            {
                { "CD", new List<string>() }, 
                { "FI", new List<string>() }, 
                { "IS", new List<string>() }, 
                { "MT", new List<string>() }, 
                { "RS", new List<string>() }, 
                { "PA", new List<string>() }, 
                { "RI", new List<string>() }  
            };

            // Se ainda não existe jogador/senha salvo, retorna tabuleiro vazio para evitar erro
            if (idJogadorSalvo == "" || senhaJogadorSalvo == "")
                return tabuleiro;

            int idJogador = Convert.ToInt32(idJogadorSalvo); 

            string retorno = Jogo.ExibirTabuleiro(idJogador, senhaJogadorSalvo);

            retorno = retorno.Replace("\r", ""); // Remove caracteres extras de quebra de linha

            foreach (string linha in retorno.Split('\n')) // Percorre cada linha retornada pelo tabuleiro
            {
                if (string.IsNullOrWhiteSpace(linha)) continue; 

                string[] partes = linha.Split(','); // Divide a linha no formato cercado,dino,quantidade

                if (partes.Length < 3) continue; 

                string cercado = partes[0].Trim();
                string dino = partes[1].Trim(); 

                int qtd = 1; // Quantidade padrão caso a conversão falhe
                int.TryParse(partes[2].Trim(), out qtd); // Converte a quantidade de dinos daquela espécie

                if (tabuleiro.ContainsKey(cercado)) // Verifica se o cercado existe no dicionário
                {
                    for (int i = 0; i < qtd; i++) // Repete conforme a quantidade retornada pela DLL
                    {
                        tabuleiro[cercado].Add(dino); // Adiciona o dino no cercado correspondente
                    }
                }
            }

            return tabuleiro; // Retorna o tabuleiro organizado
        }

        bool PossoJogarNoCercado(
            string especie, 
            string cercado, 
            Dictionary<string, List<string>> tabuleiro, // Estado atual do tabuleiro
            string[] maoAtual) 
            {
            if (string.IsNullOrWhiteSpace(especie)) 
                return false;

            especie = especie.Trim(); // Remove espaços extras

            if (especie.Length < 2) // Um código de dino precisa ter pelo menos 2 caracteres
                return false;

            if (!tabuleiro.ContainsKey(cercado)) // Se o cercado não existe, a jogada é inválida
                return false;

            List<string> lista = tabuleiro[cercado]; // Pega os dinossauros já presentes naquele cercado

            bool fuiEuQueRolei = ultimoJogador == idJogadorSalvo; // Verifica se este jogador foi quem rolou o dado

            if (!fuiEuQueRolei) // Se outro jogador rolou o dado, preciso respeitar a restrição do dado
            {
                if (!CercadoPermitidoPeloDado(
                    ultimoDado,
                    cercado,
                    lista,
                    especie,
                    tabuleiro))
                    return false; // Se o dado não permite esse cercado, bloqueia a jogada
            }

            if (!JogadaValida(cercado, lista, especie)) // Verifica as regras específicas do cercado
                return false;

            return true; // Se passou por todas as validações, a jogada é possível
        }

        bool EspecieExisteNoZoo(
            string especie, 
            Dictionary<string, List<string>> tabuleiro) // Tabuleiro atual do jogador
        {
            foreach (var cercado in tabuleiro.Values) // Percorre as listas de todos os cercados
            {
                if (cercado.Any(x => x.StartsWith(especie))) // Verifica se a espécie já aparece no zoológico
                    return true;
            }

            return false; // Se não encontrou, a espécie ainda não existe no zoo
        }

        void JogadaAutomatica() 
        {
            if (!partidaIniciada) // Se a partida não começou, a IA não joga
                return;

            int turnoAtual; 

            if (!int.TryParse(ultimoTurno, out turnoAtual)) // Tenta converter o turno atual para inteiro que era string
                turnoAtual = 0; // Se falhar, assume 0 para evitar exceção

            bool finalDoJogo = turnoAtual >= 8; // Considera IS e RS apenas mais para o final da partida

            int idJogador = Convert.ToInt32(idJogadorSalvo); // Converte o ID do jogador para inteiro que era string

            string retornoMao = Jogo.ExibirMao(idJogador, senhaJogadorSalvo); 

            if (string.IsNullOrWhiteSpace(retornoMao)) 
                return;

            retornoMao = retornoMao.Replace("\r", ""); // Remove caracteres extras

            // A primeira linha do ExibirMao é o turno; por isso filtramos apenas linhas que possuem vírgula
            string[] linhasMao = retornoMao
                .Split('\n')
                .Where(x => x.Contains(","))
                .ToArray();

            List<string> dinos = new List<string>(); // Lista que guardará somente os códigos dos dinossauros

            foreach (string linha in linhasMao) // Percorre as linhas da mão
            {
                string[] partes = linha.Split(','); // Divide no formato Dino,Quantidade

                if (partes.Length < 2) // Garante que há pelo menos código e quantidade
                    continue;

                string codigo = partes[0].Trim(); // Pega apenas o código do dinossauro

                if (codigo.Length >= 2) // Garante que o código parece válido
                    dinos.Add(codigo); // Adiciona o dinossauro à lista usada pela IA
            }

            if (dinos.Count == 0) // Se não há dinossauros válidos na mão, a IA não joga
                return;

            var tabuleiro = LerTabuleiro(); 

            //--------------------------------------------------
            // 1) FI - prioridade máxima
            //--------------------------------------------------

            foreach (string especie in dinos) // Testa cada dino da mão no FI
            {
                List<string> fi = tabuleiro["FI"]; // Pega os dinos já colocados na Floresta da Igualdade

                // FI pode estar vazio ou conter somente a mesma espécie
                if (fi.Count == 0 || fi.All(x => x.StartsWith(especie)))
                {
                    if (PossoJogarNoCercado(especie, "FI", tabuleiro, linhasMao)) // Confirma dado e regra do cercado
                    {
                        if (ExecutarJogada(especie, "FI")) // Tenta executar a jogada na DLL
                            return; // Se deu certo, termina o turno da IA
                    }
                }
            }

            //--------------------------------------------------
            // 2) CD - segunda prioridade
            //--------------------------------------------------

            foreach (string especie in dinos) // Testa cada dino da mão no CD
            {
                List<string> cd = tabuleiro["CD"]; // Pega os dinos já colocados na Campina da Diferença

                bool especieJaExisteNoCD =
                    cd.Any(x => x.StartsWith(especie)); // CD não permite repetir espécie

                if (!especieJaExisteNoCD) // Só tenta se essa espécie ainda não está no CD
                {
                    if (PossoJogarNoCercado(especie, "CD", tabuleiro, linhasMao))
                    {
                        if (ExecutarJogada(especie, "CD"))
                            return;
                    }
                }
            }

            //--------------------------------------------------
            // 3) MT - terceira prioridade
            //--------------------------------------------------

            if (tabuleiro["MT"].Count == 2) // Se MT já tem 2 dinos, completar o terceiro garante a pontuação
            {
                foreach (string especie in dinos)
                {
                    if (PossoJogarNoCercado(especie, "MT", tabuleiro, linhasMao))
                    {
                        if (ExecutarJogada(especie, "MT"))
                            return;
                    }
                }
            }

            foreach (string especie in dinos) // Se não conseguiu fechar MT, tenta usar MT normalmente
            {
                if (PossoJogarNoCercado(especie, "MT", tabuleiro, linhasMao))
                {
                    if (ExecutarJogada(especie, "MT"))
                        return;
                }
            }

            //--------------------------------------------------
            // 4) PA - quarta prioridade
            //--------------------------------------------------

            foreach (string especie in dinos) // Primeiro tenta continuar uma espécie já iniciada no PA
            {
                List<string> pa = tabuleiro["PA"]; // Pega os dinos da Pradaria do Amor

                if (pa.Count > 0 && pa.All(x => x.StartsWith(especie))) // Evita misturar espécies no PA
                {
                    if (PossoJogarNoCercado(especie, "PA", tabuleiro, linhasMao))
                    {
                        if (ExecutarJogada(especie, "PA"))
                            return;
                    }
                }
            }

            foreach (string especie in dinos) // Se PA estiver vazio, pode iniciar um futuro casal
            {
                List<string> pa = tabuleiro["PA"];

                if (pa.Count == 0)
                {
                    if (PossoJogarNoCercado(especie, "PA", tabuleiro, linhasMao))
                    {
                        if (ExecutarJogada(especie, "PA"))
                            return;
                    }
                }
            }

            //--------------------------------------------------
            // 5) IS - usada mais no final do jogo
            //--------------------------------------------------

            if (finalDoJogo) // Só considera IS nos turnos finais
            {
                foreach (string especie in dinos)
                {
                    if (!EspecieExisteNoZoo(especie, tabuleiro)) // IS só vale a pena se for uma espécie nova que ainda não existe no zoológico
                    {
                        if (PossoJogarNoCercado(especie, "IS", tabuleiro, linhasMao))
                        {
                            if (ExecutarJogada(especie, "IS"))
                                return;
                        }
                    }
                }
            }

            //--------------------------------------------------
            // 6) RS - usada mais no final do jogo
            //--------------------------------------------------

            if (finalDoJogo) // Só considera RS nos turnos finais
            {
                foreach (string especie in dinos)
                {
                    int maxOponente = ContarEspecieOponentes(especie, idJogador); // Maior quantidade dessa espécie entre adversários

                    int minhas = tabuleiro.Values
                        .SelectMany(x => x)
                        .Count(x => x.StartsWith(especie)); // Quantidade dessa espécie no meu zoo

                    if (minhas + 1 >= maxOponente) // +1 considera o dino que será colocado no RS
                    {
                        if (PossoJogarNoCercado(especie, "RS", tabuleiro, linhasMao))
                        {
                            if (ExecutarJogada(especie, "RS"))
                                return;
                        }
                    }
                }
            }

            //--------------------------------------------------
            // 7) RI - último recurso
            //--------------------------------------------------

            foreach (string especie in dinos) // Se nada funcionou, usa o Rio como descarte
            {
                if (PossoJogarNoCercado(especie, "RI", tabuleiro, linhasMao))
                {
                    if (ExecutarJogada(especie, "RI"))
                        return;
                }
            }
        }

        bool ExecutarJogada(string especie, string cercado) // Envia a jogada escolhida para a DLL
        {
            int idJogador = Convert.ToInt32(idJogadorSalvo); // Converte ID do jogador que antes era string

            string retorno = Jogo.Jogar(idJogador, senhaJogadorSalvo, especie, cercado); 

            if (retorno.StartsWith("ERRO")) // Se a DLL retornou erro, a jogada não foi aceita
            {
                lstHistorico.Items.Add(
                    "❌ Erro: " + especie + " → " + cercado + " | " + retorno); // Mostra erro no histórico

                return false; 
            }

            jaJogueiNesseTurno = true; 

            lstHistorico.Items.Add(
                "🤖 Jogou: " + especie + " → " + cercado); // Mostra a jogada no histórico

            AtualizarMaoListBox(); 

            return true; 
        }

        bool CercadoPermitidoPeloDado(
            string dado, 
            string cercado, 
            List<string> listaCercado, // Lista de dinos no cercado
            string codigoDino, 
            Dictionary<string, List<string>> tabuleiro) // Tabuleiro atual
        {
            if (string.IsNullOrWhiteSpace(dado)) // Se não há dado informado, libera
                return true;

            if (cercado == "RI") // Rio é descarte e pode ser usado sempre
                return true;

            switch (dado) // Aplica as regras de cada face do dado
            {
                case "AL": // Alimentação: FI, MT, PA
                    return cercado == "FI"
                        || cercado == "MT"
                        || cercado == "PA";

                case "FL": // Floresta: FI, MT, RS
                    return cercado == "FI"
                        || cercado == "MT"
                        || cercado == "RS";

                case "PR": // Pradaria: PA, CD, IS
                    return cercado == "PA"
                        || cercado == "CD"
                        || cercado == "IS";

                case "WC": // Banheiros: RS, CD, IS
                    return cercado == "RS"
                        || cercado == "CD"
                        || cercado == "IS";

                case "VZ": // Cercado vazio
                    return listaCercado.Count == 0;

                case "TI": // Cercado sem T-Rex
                    return !listaCercado.Any(x => x.StartsWith("Ti"));

                default: // Qualquer valor inesperado é liberado para evitar travamento
                    return true;
            }
        }

        bool JogadaValida(string cercado, List<string> lista, string codigoDino) // Valida as regras internas de cada cercado
        {
            if (string.IsNullOrWhiteSpace(codigoDino)) // Bloqueia código vazio
                return false;

            codigoDino = codigoDino.Trim(); // Remove espaços extras

            if (codigoDino.Length < 2) // Código de dino deve ter 2 caracteres
                return false;

            string especie = codigoDino.Substring(0, 2); // Usa os 2 primeiros caracteres como espécie

            if (cercado == "IS") // Ilha Solitária
            {
                return lista.Count == 0; // Só aceita um único dinossauro 
            }

            if (cercado == "RS") // Rei da Selva
            {
                return lista.Count == 0; // Também só aceita um dinossauro
            }

            if (cercado == "MT") // Mata Tripla
            {
                return lista.Count < 3; // Aceita no máximo 3 dinossauros iguais ou diferentes
            }

            if (cercado == "CD") // Campina da Diferença
            {
                return !lista.Any(x => x.StartsWith(especie)); // Não permite repetir espécie
            }

            if (cercado == "FI") // Floresta da Igualdade
            {
                if (lista.Count == 0)
                    return true; // FI vazio aceita qualquer espécie para começar

                return lista.All(x => x.StartsWith(especie)); // Depois só aceita a mesma espécie
            }

            if (cercado == "PA") // Pradaria do Amor
            {
                if (lista.Count == 0)
                    return true; // PA vazio pode iniciar uma espécie

                return lista.All(x => x.StartsWith(especie)); // Evita misturar espécies no PA
            }

            if (cercado == "RI") // Rio
            {
                return true; // Rio sempre aceita qualquer dinossauro
            }

            return false; // Qualquer cercado desconhecido é bloqueado
        }

        int ContarEspecieOponentes(string especie, int meuId) 
        {
            int maiorQuantidade = 0; // Guarda o maior número encontrado entre os oponentes

            string retorno = Jogo.ListarJogadores(idPartidaSalvo); 
            retorno = retorno.Replace("\r", ""); // Remove quebras extras

            string[] jogadores = retorno.Split('\n'); // Separa jogadores por linha

            foreach (string jogador in jogadores) // Percorre cada jogador
            {
                if (string.IsNullOrWhiteSpace(jogador)) 
                    continue;

                string[] partes = jogador.Split(','); // Divide os dados do jogador

                int idOutro; // Guarda o ID do outro jogador

                if (!int.TryParse(partes[0], out idOutro)) // Tenta converter o ID
                    continue;

                if (idOutro == meuId) 
                    continue;

                string tabuleiroOutro = Jogo.ExibirTabuleiro(idOutro); 

                if (string.IsNullOrWhiteSpace(tabuleiroOutro)) // Se não há retorno, ignora
                    continue;

                int quantidade = 0; // Quantidade dessa espécie no adversário atual

                foreach (string linha in tabuleiroOutro.Replace("\r", "").Split('\n')) // Percorre o tabuleiro adversário
                {
                    if (string.IsNullOrWhiteSpace(linha))
                        continue;

                    string[] dados = linha.Split(','); // Esperado: cercado,dino,quantidade

                    if (dados.Length < 3)
                        continue;

                    string dino = dados[1]; 

                    int qtd = Convert.ToInt32(dados[2]); // Quantidade daquela espécie naquele cercado

                    if (dino.StartsWith(especie)) // Se for a espécie procurada
                        quantidade += qtd; // Soma a quantidade
                }

                if (quantidade > maiorQuantidade) // Atualiza o maior valor encontrado
                    maiorQuantidade = quantidade;
            }

            return maiorQuantidade; 
        }

        private void AtualizarListaJogadores() 
        {
            if (lstListadePartidas.SelectedItem == null) // Se nenhuma partida foi selecionada, não faz nada
                return;

            string partida = lstListadePartidas.SelectedItem.ToString(); // Pega a partida selecionada
            string[] dadosPartida = partida.Split(','); // Divide os dados da partida

            int idPartida = Convert.ToInt32(dadosPartida[0]); // Pega o ID da partida

            string retorno = Jogo.ListarJogadores(idPartida); // Busca os jogadores da partida

            retorno = retorno.Replace("\r", ""); // Remove caracteres extras
            string[] jogadores = retorno.Split('\n'); // Separa os jogadores em linhas

            lstDadosPartida.Items.Clear(); 

            for (int i = 0; i < jogadores.Length - 1; i++) // Percorre os jogadores retornados
            {
                if (jogadores[i].Trim() != "") // Ignora linhas vazias
                    lstDadosPartida.Items.Add(jogadores[i]); 
            }
        }

        private void btnListarPartidas_Click(object sender, EventArgs e) 
        {
            CarregarListaPartidas(); 
        }

        private void lstDadosPartida_SelectedIndexChanged(object sender, EventArgs e) 
        {
            if (lstListadePartidas.SelectedItem == null) // Se não há partida selecionada, sai
                return;

            string partida = lstListadePartidas.SelectedItem.ToString(); // Pega a partida selecionada
            string[] dadosPartida = partida.Split(','); // Divide os dados da partida

            int idPartida = Convert.ToInt32(dadosPartida[0]); 
            string nomePartida = dadosPartida[1]; 
            string data = dadosPartida[2]; 

            lblID.Text = idPartida.ToString(); 
            lblNomeDaPartida.Text = nomePartida; 
            lblDataDaPartida.Text = data; 

            txtGrupo.Text = idPartida.ToString(); 

            AtualizarListaJogadores(); 
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

            if (grupo == "") // Segurança caso o grupo esteja vazio
                grupo = "0";

            string retorno = Jogo.CriarPartida(nome, senha, grupo); 

            if (retorno.StartsWith("ERRO")) // Verifica se a DLL retornou erro
            {
                MessageBox.Show("Erro:\n" + retorno.Substring(5)); // Mostra mensagem sem o prefixo ERRO
                return;
            }

            MessageBox.Show("Partida criada com sucesso!");

            CarregarListaPartidas(); 

            txtNome.Clear(); 
            txtSenha.Clear(); 
            txtGrupo.Clear(); 
        }

        private void btnEntrarNaPartida_Click(object sender, EventArgs e)
        {
            string nomeJogador = txtNomeJogador.Text.Trim(); 
            string senhaJogador = txtSenhaJogador.Text.Trim(); 
            string idTexto = txtEntrarNaSala.Text.Trim(); 

            if (nomeJogador == "" || senhaJogador == "" || idTexto == "") // Valida campos obrigatórios
            {
                MessageBox.Show("Preencha Nome, Senha e ID da Partida!");
                return;
            }

            int idPartida; // Guarda ID convertido

            if (!int.TryParse(idTexto, out idPartida)) // Tenta converter ID da partida
            {
                MessageBox.Show("ID inválido!");
                return;
            }

            idPartidaSalvo = idPartida; // Salva ID da partida para uso posterior

            string retorno = Jogo.Entrar(idPartida, nomeJogador, senhaJogador); 

            if (retorno.StartsWith("ERRO")) // Trata erro da DLL
            {
                MessageBox.Show("Erro:\n" + retorno.Substring(5));
                return;
            }

            string[] partes = retorno.Split(','); // Retorno esperado

            if (partes.Length < 2) // Verifica formato inesperado
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
            if (idJogadorSalvo == "" || senhaJogadorSalvo == "") // Garante que o jogador entrou antes
            {
                MessageBox.Show("Entre na partida primeiro");
                return;
            }

            int idJogador = Convert.ToInt32(idJogadorSalvo); // Converte ID do jogador

            string retorno = Jogo.Iniciar(idJogador, senhaJogadorSalvo); 

            if (retorno.StartsWith("ERRO")) // Trata erro
            {
                MessageBox.Show(retorno);
                return;
            }

            MessageBox.Show("Partida iniciada"); 

            partidaIniciada = true; 

            AtualizarTurno(); 
        }

        void AtualizarMaoListBox() 
        {
            if (idJogadorSalvo == "" || senhaJogadorSalvo == "") // Se não entrou na partida, não faz nada
                return;

            int idJogador = Convert.ToInt32(idJogadorSalvo); // Converte ID do jogador

            string retorno = Jogo.ExibirMao(idJogador, senhaJogadorSalvo); 

            if (string.IsNullOrEmpty(retorno)) return; 

            retorno = retorno.Replace("\r", ""); // Remove caracteres extras
            string[] dinos = retorno.Split('\n'); // Divide em linhas

            lstMaoJogador.Items.Clear(); 

            foreach (string d in dinos) // Percorre cada linha da mão
            {
                if (string.IsNullOrWhiteSpace(d)) continue; 

                string[] partes = d.Split(','); // Esperado: dino,quantidade

                if (partes.Length >= 2) 
                {
                    string codigo = partes[0]; 
                    string nome = partes[1]; 

                    lstMaoJogador.Items.Add(nome + " (" + codigo + ")"); 
                }
            }
        }

        void AtualizarTurno() 
        {
            string retorno = Jogo.VerificarPartida(idPartidaSalvo); 
            if (string.IsNullOrEmpty(retorno)) return; 

            string[] dados = retorno.Split(','); // Retorno esperado: statusPartida,turno,statusTurno,jogador,dado
            if (dados.Length < 5) return; // Se formato inválido, sai

            string statusPartida = dados[0].Trim(); // J ou E
            string turno = dados[1].Trim(); 
            string statusTurno = dados[2].Trim(); // A ou F
            string jogador = dados[3].Trim(); 
            string dado = dados[4].Trim(); 

            if (statusPartida == "E") 
            {
                MessageBox.Show("🏁 FIM DO JOGO!");
                partidaIniciada = false;
                return;
            }

            if (statusPartida == "J") 
            {
                partidaIniciada = true; 
            }

            if (statusTurno != "A") return; // Só joga quando o turno está em andamento

            bool turnoMudou = turno != ultimoTurno; 

            ultimoJogador = jogador; 
            ultimoDado = dado; 

            if (turnoMudou) 
            {
                jaJogueiNesseTurno = false; 
                ultimoTurno = turno; 

                lstHistorico.Items.Add(
                    "Turno " + turno + " - Jogador " + jogador + " (" + dado + ")");

                AtualizarMaoListBox(); 
            }

            lblTurno.Text = "Turno: " + turno;
            lblJogadorDaVez.Text = "Jogador: " + jogador;
            lblDado.Text = "Dado: " + dado;

            if (!jaJogueiNesseTurno) 
            {
                JogadaAutomatica();
            }
        }

        private void lstListadePartidas_SelectedIndexChanged(object sender, EventArgs e) 
        {
            if (lstListadePartidas.SelectedItem == null) // Se nada foi selecionado, sai
                return;

            string partida = lstListadePartidas.SelectedItem.ToString(); 
            string[] dadosPartida = partida.Split(','); // Divide dados da partida

            int idPartida = Convert.ToInt32(dadosPartida[0]); 
            string nomePartida = dadosPartida[1]; 
            string data = dadosPartida[2]; 

            lblID.Text = idPartida.ToString(); 
            lblNomeDaPartida.Text = nomePartida; 
            lblDataDaPartida.Text = data; 

            txtGrupo.Text = idPartida.ToString(); 

            AtualizarListaJogadores(); 
        }

        private void tmrVerificarPartidas_Tick(object sender, EventArgs e) 
        {
            tmrVerificarPartidas.Enabled = false; // Desliga temporariamente para evitar execução duplicada

            try // Tenta executar atualização sem travar a tela
            {
                AtualizarListaJogadores(); 

                if (idPartidaSalvo != 0 && idJogadorSalvo != "") // Só atualiza turno se já estiver em partida
                {
                    AtualizarTurno(); 
                }
            }
            catch (Exception ex) // Captura erros inesperados do timer
            {
                Console.WriteLine("Erro no timer: " + ex.Message); 
            }

            tmrVerificarPartidas.Enabled = true; 
        }
    }
}