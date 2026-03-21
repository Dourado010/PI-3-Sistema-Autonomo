namespace PI_3_Sistema_Autônomo_2._0
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
            this.btnConsulta = new System.Windows.Forms.Button();
            this.lbl4 = new System.Windows.Forms.Label();
            this.lstListadePartidas = new System.Windows.Forms.ListBox();
            this.btnCriarPartida = new System.Windows.Forms.Button();
            this.lstDadosPartida = new System.Windows.Forms.ListBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.txtGrupo = new System.Windows.Forms.TextBox();
            this.lblNomeDaPartida = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.lblDataDaPartida = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNome = new System.Windows.Forms.Label();
            this.lblSenha = new System.Windows.Forms.Label();
            this.lblGrupo = new System.Windows.Forms.Label();
            this.btnIniciarPartida = new System.Windows.Forms.Button();
            this.lblIdJogador = new System.Windows.Forms.Label();
            this.lblSenhaJogador = new System.Windows.Forms.Label();
            this.lblNomeJogador = new System.Windows.Forms.Label();
            this.txtNomeJogador = new System.Windows.Forms.TextBox();
            this.lblDigitaSenhaJogador = new System.Windows.Forms.Label();
            this.txtSenhaJogador = new System.Windows.Forms.TextBox();
            this.txtEntrarID = new System.Windows.Forms.Label();
            this.txtEntrarNaSala = new System.Windows.Forms.TextBox();
            this.btnEntrarNaPartida = new System.Windows.Forms.Button();
            this.lstMaoJogador = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnConsulta
            // 
            this.btnConsulta.Location = new System.Drawing.Point(438, 47);
            this.btnConsulta.Name = "btnConsulta";
            this.btnConsulta.Size = new System.Drawing.Size(129, 54);
            this.btnConsulta.TabIndex = 0;
            this.btnConsulta.Text = "Consultar Partidas";
            this.btnConsulta.UseVisualStyleBackColor = true;
            this.btnConsulta.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbl4
            // 
            this.lbl4.AutoSize = true;
            this.lbl4.Location = new System.Drawing.Point(738, 31);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(40, 13);
            this.lbl4.TabIndex = 1;
            this.lbl4.Text = "Versão";
            // 
            // lstListadePartidas
            // 
            this.lstListadePartidas.FormattingEnabled = true;
            this.lstListadePartidas.Location = new System.Drawing.Point(214, 47);
            this.lstListadePartidas.Name = "lstListadePartidas";
            this.lstListadePartidas.Size = new System.Drawing.Size(218, 173);
            this.lstListadePartidas.TabIndex = 2;
            this.lstListadePartidas.SelectedIndexChanged += new System.EventHandler(this.lstDadosPartida_SelectedIndexChanged_1);
            // 
            // btnCriarPartida
            // 
            this.btnCriarPartida.Location = new System.Drawing.Point(12, 193);
            this.btnCriarPartida.Name = "btnCriarPartida";
            this.btnCriarPartida.Size = new System.Drawing.Size(87, 57);
            this.btnCriarPartida.TabIndex = 4;
            this.btnCriarPartida.Text = "Criar";
            this.btnCriarPartida.UseVisualStyleBackColor = true;
            this.btnCriarPartida.Click += new System.EventHandler(this.btnCriarPartida_Click);
            // 
            // lstDadosPartida
            // 
            this.lstDadosPartida.FormattingEnabled = true;
            this.lstDadosPartida.Location = new System.Drawing.Point(573, 47);
            this.lstDadosPartida.Name = "lstDadosPartida";
            this.lstDadosPartida.Size = new System.Drawing.Size(205, 173);
            this.lstDadosPartida.TabIndex = 8;
            this.lstDadosPartida.SelectedIndexChanged += new System.EventHandler(this.lstDadosPartida_SelectedIndexChanged_1);
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(73, 46);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(100, 20);
            this.txtNome.TabIndex = 9;
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(73, 97);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.Size = new System.Drawing.Size(100, 20);
            this.txtSenha.TabIndex = 10;
            // 
            // txtGrupo
            // 
            this.txtGrupo.Location = new System.Drawing.Point(73, 145);
            this.txtGrupo.Name = "txtGrupo";
            this.txtGrupo.Size = new System.Drawing.Size(100, 20);
            this.txtGrupo.TabIndex = 11;
            // 
            // lblNomeDaPartida
            // 
            this.lblNomeDaPartida.AutoSize = true;
            this.lblNomeDaPartida.Location = new System.Drawing.Point(455, 145);
            this.lblNomeDaPartida.Name = "lblNomeDaPartida";
            this.lblNomeDaPartida.Size = new System.Drawing.Size(86, 13);
            this.lblNomeDaPartida.TabIndex = 6;
            this.lblNomeDaPartida.Text = "Nome da Partida";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(460, 120);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(69, 13);
            this.lblID.TabIndex = 5;
            this.lblID.Text = "ID da Partida";
            // 
            // lblDataDaPartida
            // 
            this.lblDataDaPartida.AutoSize = true;
            this.lblDataDaPartida.Location = new System.Drawing.Point(460, 173);
            this.lblDataDaPartida.Name = "lblDataDaPartida";
            this.lblDataDaPartida.Size = new System.Drawing.Size(81, 13);
            this.lblDataDaPartida.TabIndex = 7;
            this.lblDataDaPartida.Text = "Data da Partida";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(259, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(320, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Paleontólogos: Gabriel de Lima Dourado e Álvaro Cereja de Souza";
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(22, 49);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(38, 13);
            this.lblNome.TabIndex = 13;
            this.lblNome.Text = "Nome:";
            // 
            // lblSenha
            // 
            this.lblSenha.AutoSize = true;
            this.lblSenha.Location = new System.Drawing.Point(22, 100);
            this.lblSenha.Name = "lblSenha";
            this.lblSenha.Size = new System.Drawing.Size(41, 13);
            this.lblSenha.TabIndex = 14;
            this.lblSenha.Text = "Senha:";
            // 
            // lblGrupo
            // 
            this.lblGrupo.AutoSize = true;
            this.lblGrupo.Location = new System.Drawing.Point(22, 148);
            this.lblGrupo.Name = "lblGrupo";
            this.lblGrupo.Size = new System.Drawing.Size(21, 13);
            this.lblGrupo.TabIndex = 15;
            this.lblGrupo.Text = "ID:";
            // 
            // btnIniciarPartida
            // 
            this.btnIniciarPartida.Location = new System.Drawing.Point(114, 193);
            this.btnIniciarPartida.Name = "btnIniciarPartida";
            this.btnIniciarPartida.Size = new System.Drawing.Size(80, 57);
            this.btnIniciarPartida.TabIndex = 16;
            this.btnIniciarPartida.Text = "Iniciar Partida";
            this.btnIniciarPartida.UseVisualStyleBackColor = true;
            this.btnIniciarPartida.Click += new System.EventHandler(this.btnIniciarPartida_Click);
            // 
            // lblIdJogador
            // 
            this.lblIdJogador.AutoSize = true;
            this.lblIdJogador.Location = new System.Drawing.Point(236, 262);
            this.lblIdJogador.Name = "lblIdJogador";
            this.lblIdJogador.Size = new System.Drawing.Size(74, 13);
            this.lblIdJogador.TabIndex = 17;
            this.lblIdJogador.Text = "ID do Jogador";
            // 
            // lblSenhaJogador
            // 
            this.lblSenhaJogador.AutoSize = true;
            this.lblSenhaJogador.Location = new System.Drawing.Point(236, 290);
            this.lblSenhaJogador.Name = "lblSenhaJogador";
            this.lblSenhaJogador.Size = new System.Drawing.Size(88, 13);
            this.lblSenhaJogador.TabIndex = 18;
            this.lblSenhaJogador.Text = "Senha da partida";
            // 
            // lblNomeJogador
            // 
            this.lblNomeJogador.AutoSize = true;
            this.lblNomeJogador.Location = new System.Drawing.Point(13, 286);
            this.lblNomeJogador.Name = "lblNomeJogador";
            this.lblNomeJogador.Size = new System.Drawing.Size(94, 13);
            this.lblNomeJogador.TabIndex = 20;
            this.lblNomeJogador.Text = "Nome do Jogador:";
            // 
            // txtNomeJogador
            // 
            this.txtNomeJogador.Location = new System.Drawing.Point(113, 283);
            this.txtNomeJogador.Name = "txtNomeJogador";
            this.txtNomeJogador.Size = new System.Drawing.Size(100, 20);
            this.txtNomeJogador.TabIndex = 19;
            // 
            // lblDigitaSenhaJogador
            // 
            this.lblDigitaSenhaJogador.AutoSize = true;
            this.lblDigitaSenhaJogador.Location = new System.Drawing.Point(14, 319);
            this.lblDigitaSenhaJogador.Name = "lblDigitaSenhaJogador";
            this.lblDigitaSenhaJogador.Size = new System.Drawing.Size(91, 13);
            this.lblDigitaSenhaJogador.TabIndex = 22;
            this.lblDigitaSenhaJogador.Text = "Senha da partida:";
            // 
            // txtSenhaJogador
            // 
            this.txtSenhaJogador.Location = new System.Drawing.Point(114, 316);
            this.txtSenhaJogador.Name = "txtSenhaJogador";
            this.txtSenhaJogador.Size = new System.Drawing.Size(100, 20);
            this.txtSenhaJogador.TabIndex = 21;
            // 
            // txtEntrarID
            // 
            this.txtEntrarID.AutoSize = true;
            this.txtEntrarID.Location = new System.Drawing.Point(14, 354);
            this.txtEntrarID.Name = "txtEntrarID";
            this.txtEntrarID.Size = new System.Drawing.Size(60, 13);
            this.txtEntrarID.TabIndex = 24;
            this.txtEntrarID.Text = "ID da Sala:";
            // 
            // txtEntrarNaSala
            // 
            this.txtEntrarNaSala.Location = new System.Drawing.Point(114, 351);
            this.txtEntrarNaSala.Name = "txtEntrarNaSala";
            this.txtEntrarNaSala.Size = new System.Drawing.Size(100, 20);
            this.txtEntrarNaSala.TabIndex = 23;
            // 
            // btnEntrarNaPartida
            // 
            this.btnEntrarNaPartida.Location = new System.Drawing.Point(16, 381);
            this.btnEntrarNaPartida.Name = "btnEntrarNaPartida";
            this.btnEntrarNaPartida.Size = new System.Drawing.Size(198, 57);
            this.btnEntrarNaPartida.TabIndex = 25;
            this.btnEntrarNaPartida.Text = "Entrar na partida";
            this.btnEntrarNaPartida.UseVisualStyleBackColor = true;
            this.btnEntrarNaPartida.Click += new System.EventHandler(this.btnEntrarNaPartida_Click);
            // 
            // lstMaoJogador
            // 
            this.lstMaoJogador.FormattingEnabled = true;
            this.lstMaoJogador.Location = new System.Drawing.Point(239, 319);
            this.lstMaoJogador.Name = "lstMaoJogador";
            this.lstMaoJogador.Size = new System.Drawing.Size(158, 121);
            this.lstMaoJogador.TabIndex = 26;
            this.lstMaoJogador.SelectedIndexChanged += new System.EventHandler(this.lstMaoJogador_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lstMaoJogador);
            this.Controls.Add(this.btnEntrarNaPartida);
            this.Controls.Add(this.txtEntrarID);
            this.Controls.Add(this.txtEntrarNaSala);
            this.Controls.Add(this.lblDigitaSenhaJogador);
            this.Controls.Add(this.txtSenhaJogador);
            this.Controls.Add(this.lblNomeJogador);
            this.Controls.Add(this.txtNomeJogador);
            this.Controls.Add(this.lblSenhaJogador);
            this.Controls.Add(this.lblIdJogador);
            this.Controls.Add(this.btnIniciarPartida);
            this.Controls.Add(this.lblGrupo);
            this.Controls.Add(this.lblSenha);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblNomeDaPartida);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.lblDataDaPartida);
            this.Controls.Add(this.txtGrupo);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lstDadosPartida);
            this.Controls.Add(this.btnCriarPartida);
            this.Controls.Add(this.lstListadePartidas);
            this.Controls.Add(this.lbl4);
            this.Controls.Add(this.btnConsulta);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConsulta;
        private System.Windows.Forms.Label lbl4;
        private System.Windows.Forms.ListBox lstListadePartidas;
        private System.Windows.Forms.Button btnCriarPartida;
        private System.Windows.Forms.ListBox lstDadosPartida;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.TextBox txtGrupo;
        private System.Windows.Forms.Label lblNomeDaPartida;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblDataDaPartida;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblSenha;
        private System.Windows.Forms.Label lblGrupo;
        private System.Windows.Forms.Button btnIniciarPartida;
        private System.Windows.Forms.Label lblIdJogador;
        private System.Windows.Forms.Label lblSenhaJogador;
        private System.Windows.Forms.Label lblNomeJogador;
        private System.Windows.Forms.TextBox txtNomeJogador;
        private System.Windows.Forms.Label lblDigitaSenhaJogador;
        private System.Windows.Forms.TextBox txtSenhaJogador;
        private System.Windows.Forms.Label txtEntrarID;
        private System.Windows.Forms.TextBox txtEntrarNaSala;
        private System.Windows.Forms.Button btnEntrarNaPartida;
        private System.Windows.Forms.ListBox lstMaoJogador;
    }
}

