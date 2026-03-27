namespace MonitorProdutividade
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
            this.lblJanelaAtiva = new System.Windows.Forms.Label();
            this.registros = new System.Windows.Forms.ListBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblJanelaAtiva
            // 
            this.lblJanelaAtiva.AutoSize = true;
            this.lblJanelaAtiva.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJanelaAtiva.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblJanelaAtiva.Location = new System.Drawing.Point(49, 20);
            this.lblJanelaAtiva.Name = "lblJanelaAtiva";
            this.lblJanelaAtiva.Size = new System.Drawing.Size(135, 25);
            this.lblJanelaAtiva.TabIndex = 0;
            this.lblJanelaAtiva.Text = "Aguardando...";
            // 
            // registros
            // 
            this.registros.BackColor = System.Drawing.Color.MistyRose;
            this.registros.FormattingEnabled = true;
            this.registros.ItemHeight = 16;
            this.registros.Location = new System.Drawing.Point(361, 20);
            this.registros.Name = "registros";
            this.registros.Size = new System.Drawing.Size(427, 404);
            this.registros.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.MistyRose;
            this.button1.Location = new System.Drawing.Point(54, 209);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(173, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Enviar relatório";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCoral;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.registros);
            this.Controls.Add(this.lblJanelaAtiva);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblJanelaAtiva;
        private System.Windows.Forms.ListBox registros;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
    }
}

