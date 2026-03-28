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
            this.button1 = new System.Windows.Forms.Button();
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
            this.lbl4 = new System.Windows.Forms.Label();
            this.lstMaoJogador = new System.Windows.Forms.ListBox();
            this.lblNossoGrupo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(520, 50);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 44);
            this.button1.TabIndex = 0;
            this.button1.Text = "Consultar Partidas";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lstDadosPartida
            // 
            this.lstDadosPartida.FormattingEnabled = true;
            this.lstDadosPartida.Location = new System.Drawing.Point(637, 50);
            this.lstDadosPartida.Name = "lstDadosPartida";
            this.lstDadosPartida.Size = new System.Drawing.Size(129, 147);
            this.lstDadosPartida.TabIndex = 1;
            this.lstDadosPartida.SelectedIndexChanged += new System.EventHandler(this.lstDadosPartida_SelectedIndexChanged);
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(554, 162);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(35, 13);
            this.lblID.TabIndex = 2;
            this.lblID.Text = "label1";
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
            this.lblDataDaPartida.Location = new System.Drawing.Point(554, 117);
            this.lblDataDaPartida.Name = "lblDataDaPartida";
            this.lblDataDaPartida.Size = new System.Drawing.Size(35, 13);
            this.lblDataDaPartida.TabIndex = 4;
            this.lblDataDaPartida.Text = "label1";
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
            this.lstListadePartidas.Location = new System.Drawing.Point(394, 50);
            this.lstListadePartidas.Name = "lstListadePartidas";
            this.lstListadePartidas.Size = new System.Drawing.Size(120, 147);
            this.lstListadePartidas.TabIndex = 6;
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
            this.btnEntrarNaPartida.Location = new System.Drawing.Point(73, 362);
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
            this.lblSenhaJogador.Location = new System.Drawing.Point(281, 281);
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
            // lbl4
            // 
            this.lbl4.AutoSize = true;
            this.lbl4.Location = new System.Drawing.Point(712, 386);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(40, 13);
            this.lbl4.TabIndex = 18;
            this.lbl4.Text = "Versão";
            // 
            // lstMaoJogador
            // 
            this.lstMaoJogador.FormattingEnabled = true;
            this.lstMaoJogador.Location = new System.Drawing.Point(284, 315);
            this.lstMaoJogador.Name = "lstMaoJogador";
            this.lstMaoJogador.Size = new System.Drawing.Size(120, 95);
            this.lstMaoJogador.TabIndex = 19;
            // 
            // lblNossoGrupo
            // 
            this.lblNossoGrupo.AutoSize = true;
            this.lblNossoGrupo.Location = new System.Drawing.Point(242, 9);
            this.lblNossoGrupo.Name = "lblNossoGrupo";
            this.lblNossoGrupo.Size = new System.Drawing.Size(320, 13);
            this.lblNossoGrupo.TabIndex = 20;
            this.lblNossoGrupo.Text = "Paleontólogos: Gabriel de Lima Dourado e Álvaro Cereja de Souza";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblNossoGrupo);
            this.Controls.Add(this.lstMaoJogador);
            this.Controls.Add(this.lbl4);
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
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
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
        private System.Windows.Forms.Label lbl4;
        private System.Windows.Forms.ListBox lstMaoJogador;
        private System.Windows.Forms.Label lblNossoGrupo;
    }
}

