namespace TesteMariana.WinApp
{
    partial class TelaPrincipalForm
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
            this.menu = new System.Windows.Forms.MenuStrip();
            this.cadastrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disciplinaMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.materiaMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.questoesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.labelRodape = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolbox1 = new System.Windows.Forms.ToolStrip();
            this.toolStripBtnInserir = new System.Windows.Forms.ToolStripButton();
            this.toolStripBntEditar = new System.Windows.Forms.ToolStripButton();
            this.toolStripBntExcluir = new System.Windows.Forms.ToolStripButton();
            this.toolStripBntPdf = new System.Windows.Forms.ToolStripButton();
            this.labelTipoCadastro = new System.Windows.Forms.ToolStripLabel();
            this.panelRegistros = new System.Windows.Forms.Panel();
            this.menu.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolbox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrosToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(959, 24);
            this.menu.TabIndex = 1;
            this.menu.Text = "menuStrip1";
            // 
            // cadastrosToolStripMenuItem
            // 
            this.cadastrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testeMenuItem,
            this.disciplinaMenuItem,
            this.materiaMenuItem,
            this.questoesMenuItem});
            this.cadastrosToolStripMenuItem.Name = "cadastrosToolStripMenuItem";
            this.cadastrosToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.cadastrosToolStripMenuItem.Text = "MENU";
            // 
            // testeMenuItem
            // 
            this.testeMenuItem.Name = "testeMenuItem";
            this.testeMenuItem.Size = new System.Drawing.Size(125, 22);
            this.testeMenuItem.Text = "Teste";
            this.testeMenuItem.Click += new System.EventHandler(this.testeMenuItem_Click);
            // 
            // disciplinaMenuItem
            // 
            this.disciplinaMenuItem.Name = "disciplinaMenuItem";
            this.disciplinaMenuItem.Size = new System.Drawing.Size(125, 22);
            this.disciplinaMenuItem.Text = "Disciplina";
            this.disciplinaMenuItem.Click += new System.EventHandler(this.disciplinaMenuItem_Click);
            // 
            // materiaMenuItem
            // 
            this.materiaMenuItem.Name = "materiaMenuItem";
            this.materiaMenuItem.Size = new System.Drawing.Size(125, 22);
            this.materiaMenuItem.Text = "Materia";
            this.materiaMenuItem.Click += new System.EventHandler(this.materiaMenuItem_Click);
            // 
            // questoesMenuItem
            // 
            this.questoesMenuItem.Name = "questoesMenuItem";
            this.questoesMenuItem.Size = new System.Drawing.Size(125, 22);
            this.questoesMenuItem.Text = "Questões";
            this.questoesMenuItem.Click += new System.EventHandler(this.questoesMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelRodape});
            this.statusStrip1.Location = new System.Drawing.Point(0, 427);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(959, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // labelRodape
            // 
            this.labelRodape.Name = "labelRodape";
            this.labelRodape.Size = new System.Drawing.Size(52, 17);
            this.labelRodape.Text = "[rodapé]";
            // 
            // toolbox1
            // 
            this.toolbox1.Enabled = false;
            this.toolbox1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolbox1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBtnInserir,
            this.toolStripBntEditar,
            this.toolStripBntExcluir,
            this.toolStripBntPdf,
            this.labelTipoCadastro});
            this.toolbox1.Location = new System.Drawing.Point(0, 24);
            this.toolbox1.Name = "toolbox1";
            this.toolbox1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolbox1.Size = new System.Drawing.Size(959, 25);
            this.toolbox1.TabIndex = 6;
            this.toolbox1.Text = "toolStrip1";
            // 
            // toolStripBtnInserir
            // 
            this.toolStripBtnInserir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripBtnInserir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnInserir.Name = "toolStripBtnInserir";
            this.toolStripBtnInserir.Size = new System.Drawing.Size(52, 22);
            this.toolStripBtnInserir.Text = "INSERIR";
            this.toolStripBtnInserir.Click += new System.EventHandler(this.toolStripBtnInserir_Click);
            // 
            // toolStripBntEditar
            // 
            this.toolStripBntEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripBntEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBntEditar.Name = "toolStripBntEditar";
            this.toolStripBntEditar.Size = new System.Drawing.Size(48, 22);
            this.toolStripBntEditar.Text = "EDITAR";
            this.toolStripBntEditar.Click += new System.EventHandler(this.toolStripBntEditar_Click);
            // 
            // toolStripBntExcluir
            // 
            this.toolStripBntExcluir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripBntExcluir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBntExcluir.Name = "toolStripBntExcluir";
            this.toolStripBntExcluir.Size = new System.Drawing.Size(48, 22);
            this.toolStripBntExcluir.Text = "EXLUIR";
            this.toolStripBntExcluir.Click += new System.EventHandler(this.toolStripBntExcluir_Click);
            // 
            // toolStripBntPdf
            // 
            this.toolStripBntPdf.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripBntPdf.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBntPdf.Name = "toolStripBntPdf";
            this.toolStripBntPdf.Size = new System.Drawing.Size(32, 22);
            this.toolStripBntPdf.Text = "PDF";
            this.toolStripBntPdf.Click += new System.EventHandler(this.toolStripBntPdf_Click);
            // 
            // labelTipoCadastro
            // 
            this.labelTipoCadastro.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.labelTipoCadastro.Name = "labelTipoCadastro";
            this.labelTipoCadastro.Size = new System.Drawing.Size(90, 22);
            this.labelTipoCadastro.Text = "[tipoCadastro]";
            // 
            // panelRegistros
            // 
            this.panelRegistros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRegistros.Location = new System.Drawing.Point(0, 49);
            this.panelRegistros.Name = "panelRegistros";
            this.panelRegistros.Size = new System.Drawing.Size(959, 378);
            this.panelRegistros.TabIndex = 7;
            // 
            // TelaPrincipalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 449);
            this.Controls.Add(this.panelRegistros);
            this.Controls.Add(this.toolbox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menu);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "TelaPrincipalForm";
            this.Text = "Tela Principal";
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolbox1.ResumeLayout(false);
            this.toolbox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem cadastrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disciplinaMenuItem;
        private System.Windows.Forms.ToolStripMenuItem materiaMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel labelRodape;
        private System.Windows.Forms.ToolStrip toolbox1;
        private System.Windows.Forms.ToolStripButton toolStripBtnInserir;
        private System.Windows.Forms.Panel panelRegistros;
        private System.Windows.Forms.ToolStripLabel labelTipoCadastro;
        private System.Windows.Forms.ToolStripMenuItem questoesMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripBntEditar;
        private System.Windows.Forms.ToolStripButton toolStripBntPdf;
        private System.Windows.Forms.ToolStripButton toolStripBntExcluir;
        private System.Windows.Forms.ToolStrip toolbox;
    }
}