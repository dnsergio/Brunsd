
namespace ProyectoFinal
{
    partial class Add
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Add));
            this.namePro = new System.Windows.Forms.TextBox();
            this.stockPro = new System.Windows.Forms.TextBox();
            this.PricePro = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cb_category = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.desc_tx = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ImgCli = new System.Windows.Forms.PictureBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImgCli)).BeginInit();
            this.SuspendLayout();
            // 
            // namePro
            // 
            this.namePro.Location = new System.Drawing.Point(173, 21);
            this.namePro.Name = "namePro";
            this.namePro.Size = new System.Drawing.Size(213, 21);
            this.namePro.TabIndex = 0;
            this.namePro.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // stockPro
            // 
            this.stockPro.Location = new System.Drawing.Point(173, 65);
            this.stockPro.Name = "stockPro";
            this.stockPro.Size = new System.Drawing.Size(213, 21);
            this.stockPro.TabIndex = 1;
            // 
            // PricePro
            // 
            this.PricePro.Location = new System.Drawing.Point(173, 112);
            this.PricePro.Name = "PricePro";
            this.PricePro.Size = new System.Drawing.Size(213, 21);
            this.PricePro.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Stock";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Precio";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(225, 306);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 38);
            this.button1.TabIndex = 6;
            this.button1.Text = "Subir producto";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(29, 260);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(109, 84);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // cb_category
            // 
            this.cb_category.FormattingEnabled = true;
            this.cb_category.Location = new System.Drawing.Point(173, 151);
            this.cb_category.Name = "cb_category";
            this.cb_category.Size = new System.Drawing.Size(213, 21);
            this.cb_category.TabIndex = 8;
            this.cb_category.Text = "Elige una";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Categoría";
            // 
            // desc_tx
            // 
            this.desc_tx.Location = new System.Drawing.Point(173, 193);
            this.desc_tx.Multiline = true;
            this.desc_tx.Name = "desc_tx";
            this.desc_tx.Size = new System.Drawing.Size(213, 73);
            this.desc_tx.TabIndex = 10;
            this.desc_tx.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 222);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Descripción";
            // 
            // ImgCli
            // 
            this.ImgCli.Location = new System.Drawing.Point(445, 39);
            this.ImgCli.Name = "ImgCli";
            this.ImgCli.Size = new System.Drawing.Size(205, 163);
            this.ImgCli.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImgCli.TabIndex = 14;
            this.ImgCli.TabStop = false;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(482, 228);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(117, 38);
            this.button4.TabIndex = 15;
            this.button4.Text = "Foto";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(460, 314);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(139, 30);
            this.button5.TabIndex = 16;
            this.button5.Text = "Volver al lobby";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Add
            // 
            this.Appearance.BackColor = System.Drawing.Color.DarkCyan;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 392);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.ImgCli);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.desc_tx);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cb_category);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PricePro);
            this.Controls.Add(this.stockPro);
            this.Controls.Add(this.namePro);
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("Add.IconOptions.Image")));
            this.Name = "Add";
            this.Text = "Añadir objetos";
            this.Load += new System.EventHandler(this.Add_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImgCli)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox namePro;
        private System.Windows.Forms.TextBox stockPro;
        private System.Windows.Forms.TextBox PricePro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cb_category;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox desc_tx;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox ImgCli;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}