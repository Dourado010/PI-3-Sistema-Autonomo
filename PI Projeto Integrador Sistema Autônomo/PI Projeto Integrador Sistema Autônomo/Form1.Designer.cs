namespace PI_Projeto_Integrador_Sistema_Autônomo
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnListarPartidas = new System.Windows.Forms.Button();
            this.lstDadosPartida = new System.Windows.Forms.ListBox();
            this.lblID = new System.Windows.Forms.Label();
            this.lblNomeDaPartida = new System.Windows.Forms.Label();
            this.lblDataDaPartida = new System.Windows.Forms.Label();
            this.txtGrupo = new System.Windows.Forms.TextBox();
            this.lstListadePartidas = new System.Windows.Forms.ListBox();
            this.btnCriarPartida = new System.Windows.Forms.Button();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.btnEntrarNaPartida = new System.Windows.Forms.Button();
            this.txtNomeJogador = new System.Windows.Forms.TextBox();
            this.txtSenhaJogador = new System.Windows.Forms.TextBox();
            this.txtEntrarNaSala = new System.Windows.Forms.TextBox();
            this.lblIdJogador = new System.Windows.Forms.Label();
            this.lblSenhaJogador = new System.Windows.Forms.Label();
            this.btnIniciarPartida = new System.Windows.Forms.Button();
            this.lblVersao = new System.Windows.Forms.Label();
            this.lstMaoJogador = new System.Windows.Forms.ListBox();
            this.lblNossoGrupo = new System.Windows.Forms.Label();
            this.lblTurno = new System.Windows.Forms.Label();
            this.lblJogadorDaVez = new System.Windows.Forms.Label();
            this.lblDado = new System.Windows.Forms.Label();
            this.lblSenhaPartida = new System.Windows.Forms.Label();
            this.IDPartida = new System.Windows.Forms.Label();
            this.lblNomeJogador = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblIDJogadorAtual = new System.Windows.Forms.Label();
            this.lblSenhaDoJogadorAtual = new System.Windows.Forms.Label();
            this.lstHistorico = new System.Windows.Forms.ListBox();
            this.lblHistorico = new System.Windows.Forms.Label();
            this.picTabuleiro = new System.Windows.Forms.PictureBox();
            this.tmrVerificarPartidas = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picTabuleiro)).BeginInit();
            this.SuspendLayout();
            // 
            // btnListarPartidas
            // 
            this.btnListarPartidas.Location = new System.Drawing.Point(887, 50);
            this.btnListarPartidas.Name = "btnListarPartidas";
            this.btnListarPartidas.Size = new System.Drawing.Size(111, 44);
            this.btnListarPartidas.TabIndex = 0;
            this.btnListarPartidas.Text = "Consultar Partidas";
            this.btnListarPartidas.UseVisualStyleBackColor = true;
            this.btnListarPartidas.Click += new System.EventHandler(this.btnListarPartidas_Click);
            // 
            // lstDadosPartida
            // 
            this.lstDadosPartida.FormattingEnabled = true;
            this.lstDadosPartida.Location = new System.Drawing.Point(1040, 50);
            this.lstDadosPartida.Name = "lstDadosPartida";
            this.lstDadosPartida.Size = new System.Drawing.Size(129, 147);
            this.lstDadosPartida.TabIndex = 1;
            this.lstDadosPartida.SelectedIndexChanged += new System.EventHandler(this.lstDadosPartida_SelectedIndexChanged);
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(910, 150);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(68, 13);
            this.lblID.TabIndex = 2;
            this.lblID.Text = "ID da partida";
            // 
            // lblNomeDaPartida
            // 
            this.lblNomeDaPartida.AutoSize = true;
            this.lblNomeDaPartida.Location = new System.Drawing.Point(12, 34);
            this.lblNomeDaPartida.Name = "lblNomeDaPartida";
            this.lblNomeDaPartida.Size = new System.Drawing.Size(89, 13);
            this.lblNomeDaPartida.TabIndex = 3;
            this.lblNomeDaPartida.Text = "Nome da Partida:";
            // 
            // lblDataDaPartida
            // 
            this.lblDataDaPartida.AutoSize = true;
            this.lblDataDaPartida.Location = new System.Drawing.Point(902, 116);
            this.lblDataDaPartida.Name = "lblDataDaPartida";
            this.lblDataDaPartida.Size = new System.Drawing.Size(80, 13);
            this.lblDataDaPartida.TabIndex = 4;
            this.lblDataDaPartida.Text = "Data da partida";
            // 
            // txtGrupo
            // 
            this.txtGrupo.Location = new System.Drawing.Point(107, 117);
            this.txtGrupo.Name = "txtGrupo";
            this.txtGrupo.Size = new System.Drawing.Size(100, 20);
            this.txtGrupo.TabIndex = 5;
            // 
            // lstListadePartidas
            // 
            this.lstListadePartidas.FormattingEnabled = true;
            this.lstListadePartidas.Location = new System.Drawing.Point(717, 50);
            this.lstListadePartidas.Name = "lstListadePartidas";
            this.lstListadePartidas.Size = new System.Drawing.Size(120, 147);
            this.lstListadePartidas.TabIndex = 6;
            this.lstListadePartidas.SelectedIndexChanged += new System.EventHandler(this.lstListadePartidas_SelectedIndexChanged);
            // 
            // btnCriarPartida
            // 
            this.btnCriarPartida.Location = new System.Drawing.Point(15, 171);
            this.btnCriarPartida.Name = "btnCriarPartida";
            this.btnCriarPartida.Size = new System.Drawing.Size(113, 54);
            this.btnCriarPartida.TabIndex = 7;
            this.btnCriarPartida.Text = "Criar Partida";
            this.btnCriarPartida.UseVisualStyleBackColor = true;
            this.btnCriarPartida.Click += new System.EventHandler(this.btnCriarPartida_Click);
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(107, 31);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(100, 20);
            this.txtNome.TabIndex = 8;
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(107, 74);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.Size = new System.Drawing.Size(100, 20);
            this.txtSenha.TabIndex = 9;
            // 
            // btnEntrarNaPartida
            // 
            this.btnEntrarNaPartida.Location = new System.Drawing.Point(88, 362);
            this.btnEntrarNaPartida.Name = "btnEntrarNaPartida";
            this.btnEntrarNaPartida.Size = new System.Drawing.Size(134, 60);
            this.btnEntrarNaPartida.TabIndex = 11;
            this.btnEntrarNaPartida.Text = "Entrar na Partida";
            this.btnEntrarNaPartida.UseVisualStyleBackColor = true;
            this.btnEntrarNaPartida.Click += new System.EventHandler(this.btnEntrarNaPartida_Click);
            // 
            // txtNomeJogador
            // 
            this.txtNomeJogador.Location = new System.Drawing.Point(107, 252);
            this.txtNomeJogador.Name = "txtNomeJogador";
            this.txtNomeJogador.Size = new System.Drawing.Size(100, 20);
            this.txtNomeJogador.TabIndex = 12;
            // 
            // txtSenhaJogador
            // 
            this.txtSenhaJogador.Location = new System.Drawing.Point(107, 288);
            this.txtSenhaJogador.Name = "txtSenhaJogador";
            this.txtSenhaJogador.Size = new System.Drawing.Size(100, 20);
            this.txtSenhaJogador.TabIndex = 13;
            // 
            // txtEntrarNaSala
            // 
            this.txtEntrarNaSala.Location = new System.Drawing.Point(107, 327);
            this.txtEntrarNaSala.Name = "txtEntrarNaSala";
            this.txtEntrarNaSala.Size = new System.Drawing.Size(100, 20);
            this.txtEntrarNaSala.TabIndex = 14;
            // 
            // lblIdJogador
            // 
            this.lblIdJogador.AutoSize = true;
            this.lblIdJogador.Location = new System.Drawing.Point(281, 252);
            this.lblIdJogador.Name = "lblIdJogador";
            this.lblIdJogador.Size = new System.Drawing.Size(74, 13);
            this.lblIdJogador.TabIndex = 15;
            this.lblIdJogador.Text = "ID do Jogador";
            // 
            // lblSenhaJogador
            // 
            this.lblSenhaJogador.AutoSize = true;
            this.lblSenhaJogador.Location = new System.Drawing.Point(316, 281);
            this.lblSenhaJogador.Name = "lblSenhaJogador";
            this.lblSenhaJogador.Size = new System.Drawing.Size(94, 13);
            this.lblSenhaJogador.TabIndex = 16;
            this.lblSenhaJogador.Text = "Senha do Jogador";
            // 
            // btnIniciarPartida
            // 
            this.btnIniciarPartida.Location = new System.Drawing.Point(165, 171);
            this.btnIniciarPartida.Name = "btnIniciarPartida";
            this.btnIniciarPartida.Size = new System.Drawing.Size(110, 54);
            this.btnIniciarPartida.TabIndex = 17;
            this.btnIniciarPartida.Text = "Iniciar Partida";
            this.btnIniciarPartida.UseVisualStyleBackColor = true;
            this.btnIniciarPartida.Click += new System.EventHandler(this.btnIniciarPartida_Click);
            // 
            // lblVersao
            // 
            this.lblVersao.AutoSize = true;
            this.lblVersao.Location = new System.Drawing.Point(1132, 663);
            this.lblVersao.Name = "lblVersao";
            this.lblVersao.Size = new System.Drawing.Size(40, 13);
            this.lblVersao.TabIndex = 18;
            this.lblVersao.Text = "Versão";
            // 
            // lstMaoJogador
            // 
            this.lstMaoJogador.FormattingEnabled = true;
            this.lstMaoJogador.Location = new System.Drawing.Point(312, 315);
            this.lstMaoJogador.Name = "lstMaoJogador";
            this.lstMaoJogador.Size = new System.Drawing.Size(120, 95);
            this.lstMaoJogador.TabIndex = 19;
            // 
            // lblNossoGrupo
            // 
            this.lblNossoGrupo.AutoSize = true;
            this.lblNossoGrupo.Location = new System.Drawing.Point(417, 9);
            this.lblNossoGrupo.Name = "lblNossoGrupo";
            this.lblNossoGrupo.Size = new System.Drawing.Size(320, 13);
            this.lblNossoGrupo.TabIndex = 20;
            this.lblNossoGrupo.Text = "Paleontólogos: Gabriel de Lima Dourado e Álvaro Cereja de Souza";
            // 
            // lblTurno
            // 
            this.lblTurno.AutoSize = true;
            this.lblTurno.Location = new System.Drawing.Point(464, 409);
            this.lblTurno.Name = "lblTurno";
            this.lblTurno.Size = new System.Drawing.Size(62, 13);
            this.lblTurno.TabIndex = 21;
            this.lblTurno.Text = "Turno Atual";
            // 
            // lblJogadorDaVez
            // 
            this.lblJogadorDaVez.AutoSize = true;
            this.lblJogadorDaVez.Location = new System.Drawing.Point(545, 409);
            this.lblJogadorDaVez.Name = "lblJogadorDaVez";
            this.lblJogadorDaVez.Size = new System.Drawing.Size(128, 13);
            this.lblJogadorDaVez.TabIndex = 22;
            this.lblJogadorDaVez.Text = "Jogador que rolou o dado";
            // 
            // lblDado
            // 
            this.lblDado.AutoSize = true;
            this.lblDado.Location = new System.Drawing.Point(549, 442);
            this.lblDado.Name = "lblDado";
            this.lblDado.Size = new System.Drawing.Size(119, 13);
            this.lblDado.TabIndex = 23;
            this.lblDado.Text = "Valor do Dado sorteado";
            // 
            // lblSenhaPartida
            // 
            this.lblSenhaPartida.AutoSize = true;
            this.lblSenhaPartida.Location = new System.Drawing.Point(12, 77);
            this.lblSenhaPartida.Name = "lblSenhaPartida";
            this.lblSenhaPartida.Size = new System.Drawing.Size(92, 13);
            this.lblSenhaPartida.TabIndex = 36;
            this.lblSenhaPartida.Text = "Senha da Partida:";
            // 
            // IDPartida
            // 
            this.IDPartida.AutoSize = true;
            this.IDPartida.Location = new System.Drawing.Point(29, 120);
            this.IDPartida.Name = "IDPartida";
            this.IDPartida.Size = new System.Drawing.Size(72, 13);
            this.IDPartida.TabIndex = 37;
            this.IDPartida.Text = "ID da Partida:";
            // 
            // lblNomeJogador
            // 
            this.lblNomeJogador.AutoSize = true;
            this.lblNomeJogador.Location = new System.Drawing.Point(7, 255);
            this.lblNomeJogador.Name = "lblNomeJogador";
            this.lblNomeJogador.Size = new System.Drawing.Size(94, 13);
            this.lblNomeJogador.TabIndex = 38;
            this.lblNomeJogador.Text = "Nome do Jogador:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 291);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "Senha da Partida:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 330);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 40;
            this.label2.Text = "ID da Partida:";
            // 
            // lblIDJogadorAtual
            // 
            this.lblIDJogadorAtual.AutoSize = true;
            this.lblIDJogadorAtual.Location = new System.Drawing.Point(213, 252);
            this.lblIDJogadorAtual.Name = "lblIDJogadorAtual";
            this.lblIDJogadorAtual.Size = new System.Drawing.Size(62, 13);
            this.lblIDJogadorAtual.TabIndex = 41;
            this.lblIDJogadorAtual.Text = "ID Jogador:";
            // 
            // lblSenhaDoJogadorAtual
            // 
            this.lblSenhaDoJogadorAtual.AutoSize = true;
            this.lblSenhaDoJogadorAtual.Location = new System.Drawing.Point(213, 281);
            this.lblSenhaDoJogadorAtual.Name = "lblSenhaDoJogadorAtual";
            this.lblSenhaDoJogadorAtual.Size = new System.Drawing.Size(97, 13);
            this.lblSenhaDoJogadorAtual.TabIndex = 42;
            this.lblSenhaDoJogadorAtual.Text = "Senha do Jogador:";
            // 
            // lstHistorico
            // 
            this.lstHistorico.FormattingEnabled = true;
            this.lstHistorico.Location = new System.Drawing.Point(314, 442);
            this.lstHistorico.Name = "lstHistorico";
            this.lstHistorico.Size = new System.Drawing.Size(181, 173);
            this.lstHistorico.TabIndex = 43;
            // 
            // lblHistorico
            // 
            this.lblHistorico.AutoSize = true;
            this.lblHistorico.Location = new System.Drawing.Point(213, 442);
            this.lblHistorico.Name = "lblHistorico";
            this.lblHistorico.Size = new System.Drawing.Size(95, 13);
            this.lblHistorico.TabIndex = 45;
            this.lblHistorico.Text = "Histórico do Jogo: ";
            // 
            // picTabuleiro
            // 
            this.picTabuleiro.Image = global::PI_Projeto_Integrador_Sistema_Autônomo.Properties.Resources.Tabuleiro;
            this.picTabuleiro.Location = new System.Drawing.Point(704, 222);
            this.picTabuleiro.Name = "picTabuleiro";
            this.picTabuleiro.Size = new System.Drawing.Size(474, 431);
            this.picTabuleiro.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picTabuleiro.TabIndex = 28;
            this.picTabuleiro.TabStop = false;
            // 
            // tmrVerificarPartidas
            // 
            this.tmrVerificarPartidas.Interval = 5000;
            this.tmrVerificarPartidas.Tick += new System.EventHandler(this.tmrVerificarPartidas_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(215, 315);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 52;
            this.label3.Text = "Mao Do Jogador: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1205, 692);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblHistorico);
            this.Controls.Add(this.lstHistorico);
            this.Controls.Add(this.lblSenhaDoJogadorAtual);
            this.Controls.Add(this.lblIDJogadorAtual);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblNomeJogador);
            this.Controls.Add(this.IDPartida);
            this.Controls.Add(this.lblSenhaPartida);
            this.Controls.Add(this.picTabuleiro);
            this.Controls.Add(this.lblDado);
            this.Controls.Add(this.lblJogadorDaVez);
            this.Controls.Add(this.lblTurno);
            this.Controls.Add(this.lblNossoGrupo);
            this.Controls.Add(this.lstMaoJogador);
            this.Controls.Add(this.lblVersao);
            this.Controls.Add(this.btnIniciarPartida);
            this.Controls.Add(this.lblSenhaJogador);
            this.Controls.Add(this.lblIdJogador);
            this.Controls.Add(this.txtEntrarNaSala);
            this.Controls.Add(this.txtSenhaJogador);
            this.Controls.Add(this.txtNomeJogador);
            this.Controls.Add(this.btnEntrarNaPartida);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.btnCriarPartida);
            this.Controls.Add(this.lstListadePartidas);
            this.Controls.Add(this.txtGrupo);
            this.Controls.Add(this.lblDataDaPartida);
            this.Controls.Add(this.lblNomeDaPartida);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.lstDadosPartida);
            this.Controls.Add(this.btnListarPartidas);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picTabuleiro)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnListarPartidas;
        private System.Windows.Forms.ListBox lstDadosPartida;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblNomeDaPartida;
        private System.Windows.Forms.Label lblDataDaPartida;
        private System.Windows.Forms.TextBox txtGrupo;
        private System.Windows.Forms.ListBox lstListadePartidas;
        private System.Windows.Forms.Button btnCriarPartida;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Button btnEntrarNaPartida;
        private System.Windows.Forms.TextBox txtNomeJogador;
        private System.Windows.Forms.TextBox txtSenhaJogador;
        private System.Windows.Forms.TextBox txtEntrarNaSala;
        private System.Windows.Forms.Label lblIdJogador;
        private System.Windows.Forms.Label lblSenhaJogador;
        private System.Windows.Forms.Button btnIniciarPartida;
        private System.Windows.Forms.Label lblVersao;
        private System.Windows.Forms.ListBox lstMaoJogador;
        private System.Windows.Forms.Label lblNossoGrupo;
        private System.Windows.Forms.Label lblTurno;
        private System.Windows.Forms.Label lblJogadorDaVez;
        private System.Windows.Forms.Label lblDado;
        private System.Windows.Forms.PictureBox picTabuleiro;
        private System.Windows.Forms.Label lblSenhaPartida;
        private System.Windows.Forms.Label IDPartida;
        private System.Windows.Forms.Label lblNomeJogador;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblIDJogadorAtual;
        private System.Windows.Forms.Label lblSenhaDoJogadorAtual;
        private System.Windows.Forms.ListBox lstHistorico;
        private System.Windows.Forms.Label lblHistorico;
        private System.Windows.Forms.Timer tmrVerificarPartidas;
        private System.Windows.Forms.Label label3;
    }
}

