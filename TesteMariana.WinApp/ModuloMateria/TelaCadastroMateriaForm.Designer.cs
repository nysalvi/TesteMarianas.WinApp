namespace TesteMariana.WinApp.ModuloMateria
{
    partial class TelaCadastroMateriaForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBoxNumero = new System.Windows.Forms.TextBox();
            this.textBoxNome = new System.Windows.Forms.TextBox();
            this.radioButtonSerieUm = new System.Windows.Forms.RadioButton();
            this.radioButtonSerieDois = new System.Windows.Forms.RadioButton();
            this.comboBoxDisciplina = new System.Windows.Forms.ComboBox();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(283, 372);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(103, 65);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            this.btnGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGravar.Location = new System.Drawing.Point(167, 372);
            this.btnGravar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(103, 65);
            this.btnGravar.TabIndex = 10;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 25);
            this.label1.TabIndex = 12;
            this.label1.Text = "Número:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 25);
            this.label2.TabIndex = 13;
            this.label2.Text = "Nome:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 25);
            this.label3.TabIndex = 14;
            this.label3.Text = "Disciplina:";
            // 
            // txtBoxNumero
            // 
            this.txtBoxNumero.Enabled = false;
            this.txtBoxNumero.Location = new System.Drawing.Point(144, 37);
            this.txtBoxNumero.Name = "txtBoxNumero";
            this.txtBoxNumero.Size = new System.Drawing.Size(117, 31);
            this.txtBoxNumero.TabIndex = 16;
            // 
            // textBoxNome
            // 
            this.textBoxNome.Location = new System.Drawing.Point(144, 73);
            this.textBoxNome.Name = "textBoxNome";
            this.textBoxNome.Size = new System.Drawing.Size(283, 31);
            this.textBoxNome.TabIndex = 17;
            // 
            // radioButtonSerieUm
            // 
            this.radioButtonSerieUm.AutoSize = true;
            this.radioButtonSerieUm.Location = new System.Drawing.Point(6, 30);
            this.radioButtonSerieUm.Name = "radioButtonSerieUm";
            this.radioButtonSerieUm.Size = new System.Drawing.Size(90, 29);
            this.radioButtonSerieUm.TabIndex = 18;
            this.radioButtonSerieUm.TabStop = true;
            this.radioButtonSerieUm.Text = "1 Série";
            this.radioButtonSerieUm.UseVisualStyleBackColor = true;
            // 
            // radioButtonSerieDois
            // 
            this.radioButtonSerieDois.AutoSize = true;
            this.radioButtonSerieDois.Location = new System.Drawing.Point(121, 30);
            this.radioButtonSerieDois.Name = "radioButtonSerieDois";
            this.radioButtonSerieDois.Size = new System.Drawing.Size(90, 29);
            this.radioButtonSerieDois.TabIndex = 19;
            this.radioButtonSerieDois.TabStop = true;
            this.radioButtonSerieDois.Text = "2 Série";
            this.radioButtonSerieDois.UseVisualStyleBackColor = true;
            // 
            // comboBoxDisciplina
            // 
            this.comboBoxDisciplina.FormattingEnabled = true;
            this.comboBoxDisciplina.Location = new System.Drawing.Point(144, 112);
            this.comboBoxDisciplina.Name = "comboBoxDisciplina";
            this.comboBoxDisciplina.Size = new System.Drawing.Size(183, 33);
            this.comboBoxDisciplina.TabIndex = 20;
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.radioButtonSerieDois);
            this.groupBox.Controls.Add(this.radioButtonSerieUm);
            this.groupBox.Location = new System.Drawing.Point(94, 163);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(300, 68);
            this.groupBox.TabIndex = 21;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Série:";
            // 
            // TelaCadastroMateriaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 485);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.comboBoxDisciplina);
            this.Controls.Add(this.textBoxNome);
            this.Controls.Add(this.txtBoxNumero);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGravar);
            this.Name = "TelaCadastroMateriaForm";
            this.Text = "Tela Cadastro Matéria";
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBoxNumero;
        private System.Windows.Forms.TextBox textBoxNome;
        private System.Windows.Forms.RadioButton radioButtonSerieUm;
        private System.Windows.Forms.RadioButton radioButtonSerieDois;
        private System.Windows.Forms.ComboBox comboBoxDisciplina;
        private System.Windows.Forms.GroupBox groupBox;
    }
}