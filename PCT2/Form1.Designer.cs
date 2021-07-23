namespace PCT2
{
    partial class MainForm
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
            this.btSubmitImage = new System.Windows.Forms.Button();
            this.cbThreadsNumber = new System.Windows.Forms.ComboBox();
            this.lbThreadsNumber = new System.Windows.Forms.Label();
            this.cbMaskSize = new System.Windows.Forms.ComboBox();
            this.lbMaskSize = new System.Windows.Forms.Label();
            this.pbImage1 = new System.Windows.Forms.PictureBox();
            this.pbImage2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage2)).BeginInit();
            this.SuspendLayout();
            // 
            // btSubmitImage
            // 
            this.btSubmitImage.Location = new System.Drawing.Point(315, 31);
            this.btSubmitImage.Name = "btSubmitImage";
            this.btSubmitImage.Size = new System.Drawing.Size(106, 21);
            this.btSubmitImage.TabIndex = 0;
            this.btSubmitImage.Text = "Submeter imagem";
            this.btSubmitImage.UseVisualStyleBackColor = true;
            this.btSubmitImage.Click += new System.EventHandler(this.btSubmitImage_Click);
            // 
            // cbThreadsNumber
            // 
            this.cbThreadsNumber.FormattingEnabled = true;
            this.cbThreadsNumber.Location = new System.Drawing.Point(12, 31);
            this.cbThreadsNumber.Name = "cbThreadsNumber";
            this.cbThreadsNumber.Size = new System.Drawing.Size(122, 21);
            this.cbThreadsNumber.TabIndex = 1;
            // 
            // lbThreadsNumber
            // 
            this.lbThreadsNumber.AutoSize = true;
            this.lbThreadsNumber.Location = new System.Drawing.Point(12, 15);
            this.lbThreadsNumber.Name = "lbThreadsNumber";
            this.lbThreadsNumber.Size = new System.Drawing.Size(122, 13);
            this.lbThreadsNumber.TabIndex = 2;
            this.lbThreadsNumber.Text = "Quantidade de Threads:";
            // 
            // cbMaskSize
            // 
            this.cbMaskSize.FormattingEnabled = true;
            this.cbMaskSize.Location = new System.Drawing.Point(154, 31);
            this.cbMaskSize.Name = "cbMaskSize";
            this.cbMaskSize.Size = new System.Drawing.Size(144, 21);
            this.cbMaskSize.TabIndex = 3;
            // 
            // lbMaskSize
            // 
            this.lbMaskSize.AutoSize = true;
            this.lbMaskSize.Location = new System.Drawing.Point(151, 15);
            this.lbMaskSize.Name = "lbMaskSize";
            this.lbMaskSize.Size = new System.Drawing.Size(113, 13);
            this.lbMaskSize.TabIndex = 4;
            this.lbMaskSize.Text = "Tamanho da máscara:";
            // 
            // pbImage1
            // 
            this.pbImage1.Location = new System.Drawing.Point(12, 58);
            this.pbImage1.Name = "pbImage1";
            this.pbImage1.Size = new System.Drawing.Size(409, 274);
            this.pbImage1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImage1.TabIndex = 5;
            this.pbImage1.TabStop = false;
            // 
            // pbImage2
            // 
            this.pbImage2.Location = new System.Drawing.Point(427, 58);
            this.pbImage2.Name = "pbImage2";
            this.pbImage2.Size = new System.Drawing.Size(409, 274);
            this.pbImage2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImage2.TabIndex = 6;
            this.pbImage2.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 345);
            this.Controls.Add(this.pbImage2);
            this.Controls.Add(this.pbImage1);
            this.Controls.Add(this.lbMaskSize);
            this.Controls.Add(this.cbMaskSize);
            this.Controls.Add(this.lbThreadsNumber);
            this.Controls.Add(this.cbThreadsNumber);
            this.Controls.Add(this.btSubmitImage);
            this.Name = "MainForm";
            this.Text = "Programação Concorrente";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbImage1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btSubmitImage;
        private System.Windows.Forms.ComboBox cbThreadsNumber;
        private System.Windows.Forms.Label lbThreadsNumber;
        private System.Windows.Forms.ComboBox cbMaskSize;
        private System.Windows.Forms.Label lbMaskSize;
        private System.Windows.Forms.PictureBox pbImage1;
        private System.Windows.Forms.PictureBox pbImage2;
    }
}

