namespace Atualizacao_HotList
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.tbFTP = new System.Windows.Forms.TextBox();
            this.btAtualizar = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btSair = new System.Windows.Forms.Button();
            this.ckAutomatico = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbHora = new System.Windows.Forms.MaskedTextBox();
            this.lstServidores = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lstAssociados = new System.Windows.Forms.ListBox();
            this.btIncluirTodos = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tbIncluir = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btIncluirServidor = new System.Windows.Forms.Button();
            this.tmAutomatico = new System.Windows.Forms.Timer(this.components);
            this.btExcluir = new System.Windows.Forms.Button();
            this.tbemail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(39, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Endereço FTP Riocard";
            // 
            // tbFTP
            // 
            this.tbFTP.Enabled = false;
            this.tbFTP.Location = new System.Drawing.Point(161, 37);
            this.tbFTP.Name = "tbFTP";
            this.tbFTP.Size = new System.Drawing.Size(250, 20);
            this.tbFTP.TabIndex = 1;
            this.tbFTP.Text = "ftp.riocardti.com.br";
            // 
            // btAtualizar
            // 
            this.btAtualizar.Location = new System.Drawing.Point(233, 389);
            this.btAtualizar.Name = "btAtualizar";
            this.btAtualizar.Size = new System.Drawing.Size(127, 42);
            this.btAtualizar.TabIndex = 6;
            this.btAtualizar.Text = "Atualizar";
            this.btAtualizar.UseVisualStyleBackColor = true;
            this.btAtualizar.Click += new System.EventHandler(this.btAtualizar_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Atualizacao_HotList.Properties.Resources.SuperVia_svg;
            this.pictureBox2.Location = new System.Drawing.Point(574, 449);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(138, 42);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Atualizacao_HotList.Properties.Resources.radix_logo_white2;
            this.pictureBox1.Location = new System.Drawing.Point(28, 449);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(125, 42);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // btSair
            // 
            this.btSair.Location = new System.Drawing.Point(376, 389);
            this.btSair.Name = "btSair";
            this.btSair.Size = new System.Drawing.Size(127, 42);
            this.btSair.TabIndex = 9;
            this.btSair.Text = "Sair";
            this.btSair.UseVisualStyleBackColor = true;
            this.btSair.Click += new System.EventHandler(this.btSair_Click);
            // 
            // ckAutomatico
            // 
            this.ckAutomatico.AutoSize = true;
            this.ckAutomatico.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ckAutomatico.Location = new System.Drawing.Point(541, 39);
            this.ckAutomatico.Name = "ckAutomatico";
            this.ckAutomatico.Size = new System.Drawing.Size(15, 14);
            this.ckAutomatico.TabIndex = 10;
            this.ckAutomatico.UseVisualStyleBackColor = true;
            this.ckAutomatico.CheckedChanged += new System.EventHandler(this.ckAutomatico_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(432, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Atualizar Automático";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(571, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Hora";
            // 
            // tbHora
            // 
            this.tbHora.Location = new System.Drawing.Point(607, 37);
            this.tbHora.Mask = "00:00";
            this.tbHora.Name = "tbHora";
            this.tbHora.Size = new System.Drawing.Size(35, 20);
            this.tbHora.TabIndex = 14;
            this.tbHora.Text = "0900";
            this.tbHora.ValidatingType = typeof(System.DateTime);
            // 
            // lstServidores
            // 
            this.lstServidores.FormattingEnabled = true;
            this.lstServidores.Location = new System.Drawing.Point(42, 202);
            this.lstServidores.Name = "lstServidores";
            this.lstServidores.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstServidores.Size = new System.Drawing.Size(286, 160);
            this.lstServidores.TabIndex = 15;
            this.lstServidores.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DeleteList);
            this.lstServidores.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstServidores_MouseDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(40, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Servidores";
            // 
            // lstAssociados
            // 
            this.lstAssociados.FormattingEnabled = true;
            this.lstAssociados.Location = new System.Drawing.Point(407, 202);
            this.lstAssociados.Name = "lstAssociados";
            this.lstAssociados.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstAssociados.Size = new System.Drawing.Size(286, 160);
            this.lstAssociados.TabIndex = 17;
            this.lstAssociados.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstAssociados_MouseDown);
            // 
            // btIncluirTodos
            // 
            this.btIncluirTodos.Location = new System.Drawing.Point(345, 245);
            this.btIncluirTodos.Name = "btIncluirTodos";
            this.btIncluirTodos.Size = new System.Drawing.Size(43, 32);
            this.btIncluirTodos.TabIndex = 18;
            this.btIncluirTodos.Text = ">>";
            this.btIncluirTodos.UseVisualStyleBackColor = true;
            this.btIncluirTodos.Click += new System.EventHandler(this.btIncluirTodos_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(345, 283);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(43, 32);
            this.button2.TabIndex = 21;
            this.button2.Text = "<<";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(404, 186);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(163, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Servidores que serão atualizados";
            // 
            // tbIncluir
            // 
            this.tbIncluir.Location = new System.Drawing.Point(42, 145);
            this.tbIncluir.Name = "tbIncluir";
            this.tbIncluir.Size = new System.Drawing.Size(229, 20);
            this.tbIncluir.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label7.Location = new System.Drawing.Point(42, 129);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Incluir Servidor na lista";
            // 
            // btIncluirServidor
            // 
            this.btIncluirServidor.Location = new System.Drawing.Point(277, 145);
            this.btIncluirServidor.Name = "btIncluirServidor";
            this.btIncluirServidor.Size = new System.Drawing.Size(66, 20);
            this.btIncluirServidor.TabIndex = 25;
            this.btIncluirServidor.Text = "Incluir";
            this.btIncluirServidor.UseVisualStyleBackColor = true;
            this.btIncluirServidor.Click += new System.EventHandler(this.btIncluirServidor_Click);
            // 
            // tmAutomatico
            // 
            this.tmAutomatico.Enabled = true;
            this.tmAutomatico.Interval = 60000;
            this.tmAutomatico.Tick += new System.EventHandler(this.tmAutomatico_Tick);
            // 
            // btExcluir
            // 
            this.btExcluir.Location = new System.Drawing.Point(345, 145);
            this.btExcluir.Name = "btExcluir";
            this.btExcluir.Size = new System.Drawing.Size(66, 20);
            this.btExcluir.TabIndex = 26;
            this.btExcluir.Text = "Excluir";
            this.btExcluir.UseVisualStyleBackColor = true;
            this.btExcluir.Click += new System.EventHandler(this.btExcluir_Click);
            // 
            // tbemail
            // 
            this.tbemail.Location = new System.Drawing.Point(42, 87);
            this.tbemail.Name = "tbemail";
            this.tbemail.Size = new System.Drawing.Size(369, 20);
            this.tbemail.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(39, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Email";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label8.Location = new System.Drawing.Point(417, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(211, 13);
            this.label8.TabIndex = 29;
            this.label8.Text = "* Configure mais de um email separando \";\"";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.ClientSize = new System.Drawing.Size(740, 503);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbemail);
            this.Controls.Add(this.btExcluir);
            this.Controls.Add(this.btIncluirServidor);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbIncluir);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btIncluirTodos);
            this.Controls.Add(this.lstAssociados);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lstServidores);
            this.Controls.Add(this.tbHora);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ckAutomatico);
            this.Controls.Add(this.btSair);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btAtualizar);
            this.Controls.Add(this.tbFTP);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Atualização de Arquivos da Riocard (HotList)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFTP;
        private System.Windows.Forms.Button btAtualizar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btSair;
        private System.Windows.Forms.CheckBox ckAutomatico;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox tbHora;
        private System.Windows.Forms.ListBox lstServidores;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lstAssociados;
        private System.Windows.Forms.Button btIncluirTodos;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbIncluir;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btIncluirServidor;
        private System.Windows.Forms.Timer tmAutomatico;
        private System.Windows.Forms.Button btExcluir;
        private System.Windows.Forms.TextBox tbemail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
    }
}

