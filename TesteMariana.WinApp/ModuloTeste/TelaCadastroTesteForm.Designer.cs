namespace TesteMariana.WinApp.ModuloTeste
{
    partial class TelaCadastroTesteForm
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
            this.txtBoxNumero = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxTitulo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxMateria = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxDisciplina = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBoxProvaRecuperacao = new System.Windows.Forms.CheckBox();
            this.textBoxQuantidadeQuestoes = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.listBoxQuestoes = new System.Windows.Forms.ListBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            this.bntSortearQuestao = new System.Windows.Forms.Button();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // txtBoxNumero
            // 
            this.txtBoxNumero.Enabled = false;
            this.txtBoxNumero.Location = new System.Drawing.Point(97, 13);
            this.txtBoxNumero.Name = "txtBoxNumero";
            this.txtBoxNumero.Size = new System.Drawing.Size(117, 31);
            this.txtBoxNumero.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 25);
            this.label1.TabIndex = 25;
            this.label1.Text = "Número:";
            // 
            // txtBoxTitulo
            // 
            this.txtBoxTitulo.Location = new System.Drawing.Point(97, 52);
            this.txtBoxTitulo.Name = "txtBoxTitulo";
            this.txtBoxTitulo.Size = new System.Drawing.Size(193, 31);
            this.txtBoxTitulo.TabIndex = 32;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 25);
            this.label4.TabIndex = 31;
            this.label4.Text = "Título:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(306, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 25);
            this.label2.TabIndex = 33;
            this.label2.Text = "Data:";
            // 
            // comboBoxMateria
            // 
            this.comboBoxMateria.FormattingEnabled = true;
            this.comboBoxMateria.Location = new System.Drawing.Point(97, 127);
            this.comboBoxMateria.Name = "comboBoxMateria";
            this.comboBoxMateria.Size = new System.Drawing.Size(183, 33);
            this.comboBoxMateria.TabIndex = 38;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 25);
            this.label3.TabIndex = 37;
            this.label3.Text = "Matéria:";
            // 
            // comboBoxDisciplina
            // 
            this.comboBoxDisciplina.FormattingEnabled = true;
            this.comboBoxDisciplina.Location = new System.Drawing.Point(97, 88);
            this.comboBoxDisciplina.Name = "comboBoxDisciplina";
            this.comboBoxDisciplina.Size = new System.Drawing.Size(183, 33);
            this.comboBoxDisciplina.TabIndex = 36;
            this.comboBoxDisciplina.SelectedValueChanged += new System.EventHandler(this.comboBoxDisciplina_SelectedValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(0, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 25);
            this.label5.TabIndex = 35;
            this.label5.Text = "Disciplina:";
            // 
            // checkBoxProvaRecuperacao
            // 
            this.checkBoxProvaRecuperacao.AutoSize = true;
            this.checkBoxProvaRecuperacao.Location = new System.Drawing.Point(330, 93);
            this.checkBoxProvaRecuperacao.Name = "checkBoxProvaRecuperacao";
            this.checkBoxProvaRecuperacao.Size = new System.Drawing.Size(218, 29);
            this.checkBoxProvaRecuperacao.TabIndex = 39;
            this.checkBoxProvaRecuperacao.Text = "Prova de Recuperação ";
            this.checkBoxProvaRecuperacao.UseVisualStyleBackColor = true;
            // 
            // textBoxQuantidadeQuestoes
            // 
            this.textBoxQuantidadeQuestoes.Location = new System.Drawing.Point(236, 177);
            this.textBoxQuantidadeQuestoes.Name = "textBoxQuantidadeQuestoes";
            this.textBoxQuantidadeQuestoes.Size = new System.Drawing.Size(118, 31);
            this.textBoxQuantidadeQuestoes.TabIndex = 41;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 180);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(214, 25);
            this.label6.TabIndex = 40;
            this.label6.Text = "Quantidade de Questões:";
            // 
            // listBoxQuestoes
            // 
            this.listBoxQuestoes.FormattingEnabled = true;
            this.listBoxQuestoes.ItemHeight = 25;
            this.listBoxQuestoes.Location = new System.Drawing.Point(31, 257);
            this.listBoxQuestoes.Name = "listBoxQuestoes";
            this.listBoxQuestoes.Size = new System.Drawing.Size(505, 279);
            this.listBoxQuestoes.TabIndex = 44;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(434, 568);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(103, 65);
            this.btnCancelar.TabIndex = 43;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            this.btnGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGravar.Location = new System.Drawing.Point(319, 568);
            this.btnGravar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(103, 65);
            this.btnGravar.TabIndex = 42;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // bntSortearQuestao
            // 
            this.bntSortearQuestao.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bntSortearQuestao.Location = new System.Drawing.Point(69, 568);
            this.bntSortearQuestao.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bntSortearQuestao.Name = "bntSortearQuestao";
            this.bntSortearQuestao.Size = new System.Drawing.Size(221, 65);
            this.bntSortearQuestao.TabIndex = 45;
            this.bntSortearQuestao.Text = "Sortear Questões";
            this.bntSortearQuestao.UseVisualStyleBackColor = true;
            this.bntSortearQuestao.Click += new System.EventHandler(this.bntSortearQuestao_Click);
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(365, 50);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(179, 31);
            this.dateTimePicker.TabIndex = 46;
            // 
            // TelaCadastroTesteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 647);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.bntSortearQuestao);
            this.Controls.Add(this.listBoxQuestoes);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.textBoxQuantidadeQuestoes);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.checkBoxProvaRecuperacao);
            this.Controls.Add(this.comboBoxMateria);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxDisciplina);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBoxTitulo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBoxNumero);
            this.Controls.Add(this.label1);
            this.Name = "TelaCadastroTesteForm";
            this.Text = "Tela Cadastro Teste";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxNumero;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoxTitulo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxMateria;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxDisciplina;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBoxProvaRecuperacao;
        private System.Windows.Forms.TextBox textBoxQuantidadeQuestoes;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox listBoxQuestoes;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Button bntSortearQuestao;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
    }
}