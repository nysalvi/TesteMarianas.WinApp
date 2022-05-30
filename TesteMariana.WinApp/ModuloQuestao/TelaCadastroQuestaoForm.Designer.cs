namespace TesteMariana.WinApp.ModuloQuestao
{
    partial class TelaCadastroQuestaoForm
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            this.comboBoxDisciplina = new System.Windows.Forms.ComboBox();
            this.txtBoxNumero = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxMateria = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBoxEnunciado = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBoxResposta = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAdicionarResposta = new System.Windows.Forms.Button();
            this.checkBoxAlternativaCorreta = new System.Windows.Forms.CheckBox();
            this.listBoxRespostas = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(283, 335);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(72, 39);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGravar
            // 
            this.btnGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGravar.Location = new System.Drawing.Point(202, 335);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(72, 39);
            this.btnGravar.TabIndex = 8;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // comboBoxDisciplina
            // 
            this.comboBoxDisciplina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDisciplina.FormattingEnabled = true;
            this.comboBoxDisciplina.Location = new System.Drawing.Point(109, 41);
            this.comboBoxDisciplina.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxDisciplina.Name = "comboBoxDisciplina";
            this.comboBoxDisciplina.Size = new System.Drawing.Size(129, 23);
            this.comboBoxDisciplina.TabIndex = 26;
            this.comboBoxDisciplina.SelectedValueChanged += new System.EventHandler(this.comboBoxDisciplina_SelectedValueChanged);
            // 
            // txtBoxNumero
            // 
            this.txtBoxNumero.Enabled = false;
            this.txtBoxNumero.Location = new System.Drawing.Point(109, 19);
            this.txtBoxNumero.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtBoxNumero.Name = "txtBoxNumero";
            this.txtBoxNumero.Size = new System.Drawing.Size(83, 23);
            this.txtBoxNumero.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 45);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 15);
            this.label3.TabIndex = 23;
            this.label3.Text = "Disciplina:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 15);
            this.label1.TabIndex = 21;
            this.label1.Text = "Número:";
            // 
            // comboBoxMateria
            // 
            this.comboBoxMateria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMateria.FormattingEnabled = true;
            this.comboBoxMateria.Location = new System.Drawing.Point(109, 65);
            this.comboBoxMateria.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxMateria.Name = "comboBoxMateria";
            this.comboBoxMateria.Size = new System.Drawing.Size(129, 23);
            this.comboBoxMateria.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 67);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 15);
            this.label2.TabIndex = 27;
            this.label2.Text = "Matéria:";
            // 
            // txtBoxEnunciado
            // 
            this.txtBoxEnunciado.Location = new System.Drawing.Point(109, 89);
            this.txtBoxEnunciado.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtBoxEnunciado.Name = "txtBoxEnunciado";
            this.txtBoxEnunciado.Size = new System.Drawing.Size(247, 23);
            this.txtBoxEnunciado.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 91);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 15);
            this.label4.TabIndex = 29;
            this.label4.Text = "Enunciado:";
            // 
            // txtBoxResposta
            // 
            this.txtBoxResposta.Location = new System.Drawing.Point(92, 151);
            this.txtBoxResposta.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtBoxResposta.Name = "txtBoxResposta";
            this.txtBoxResposta.Size = new System.Drawing.Size(183, 23);
            this.txtBoxResposta.TabIndex = 32;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 152);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 15);
            this.label5.TabIndex = 31;
            this.label5.Text = "Resposta:";
            // 
            // btnAdicionarResposta
            // 
            this.btnAdicionarResposta.Location = new System.Drawing.Point(283, 151);
            this.btnAdicionarResposta.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAdicionarResposta.Name = "btnAdicionarResposta";
            this.btnAdicionarResposta.Size = new System.Drawing.Size(73, 20);
            this.btnAdicionarResposta.TabIndex = 33;
            this.btnAdicionarResposta.Text = "Adicionar";
            this.btnAdicionarResposta.UseVisualStyleBackColor = true;
            this.btnAdicionarResposta.Click += new System.EventHandler(this.btnAdicionarResposta_Click);
            // 
            // checkBoxAlternativaCorreta
            // 
            this.checkBoxAlternativaCorreta.AutoSize = true;
            this.checkBoxAlternativaCorreta.Location = new System.Drawing.Point(92, 180);
            this.checkBoxAlternativaCorreta.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBoxAlternativaCorreta.Name = "checkBoxAlternativaCorreta";
            this.checkBoxAlternativaCorreta.Size = new System.Drawing.Size(125, 19);
            this.checkBoxAlternativaCorreta.TabIndex = 34;
            this.checkBoxAlternativaCorreta.Text = "Alternativa Correta";
            this.checkBoxAlternativaCorreta.UseVisualStyleBackColor = true;
            // 
            // listBoxRespostas
            // 
            this.listBoxRespostas.FormattingEnabled = true;
            this.listBoxRespostas.ItemHeight = 15;
            this.listBoxRespostas.Location = new System.Drawing.Point(36, 203);
            this.listBoxRespostas.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listBoxRespostas.Name = "listBoxRespostas";
            this.listBoxRespostas.Size = new System.Drawing.Size(311, 124);
            this.listBoxRespostas.TabIndex = 35;
            // 
            // TelaCadastroQuestaoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 383);
            this.Controls.Add(this.listBoxRespostas);
            this.Controls.Add(this.checkBoxAlternativaCorreta);
            this.Controls.Add(this.btnAdicionarResposta);
            this.Controls.Add(this.txtBoxResposta);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtBoxEnunciado);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxMateria);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxDisciplina);
            this.Controls.Add(this.txtBoxNumero);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGravar);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "TelaCadastroQuestaoForm";
            this.Text = "Tela Cadastro Questao";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.ComboBox comboBoxDisciplina;
        private System.Windows.Forms.TextBox txtBoxNumero;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxMateria;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBoxEnunciado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBoxResposta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAdicionarResposta;
        private System.Windows.Forms.CheckBox checkBoxAlternativaCorreta;
        private System.Windows.Forms.ListBox listBoxRespostas;
    }
}