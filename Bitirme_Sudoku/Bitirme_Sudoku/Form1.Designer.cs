namespace Bitirme_Sudoku
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
            this.jenerasyon = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.mutate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.generation = new System.Windows.Forms.Label();
            this.textbox_population = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fitness = new System.Windows.Forms.Label();
            this.Onayla = new System.Windows.Forms.Button();
            this.durum2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // jenerasyon
            // 
            this.jenerasyon.Location = new System.Drawing.Point(682, 104);
            this.jenerasyon.Name = "jenerasyon";
            this.jenerasyon.Size = new System.Drawing.Size(72, 20);
            this.jenerasyon.TabIndex = 25;
            this.jenerasyon.Text = "50";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(679, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Max Jenerasyon Sayısı:";
            // 
            // mutate
            // 
            this.mutate.Location = new System.Drawing.Point(682, 65);
            this.mutate.Name = "mutate";
            this.mutate.Size = new System.Drawing.Size(72, 20);
            this.mutate.TabIndex = 23;
            this.mutate.Text = "33";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(679, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Mutasyon Oranı (%)";
            // 
            // generation
            // 
            this.generation.AutoSize = true;
            this.generation.Location = new System.Drawing.Point(679, 154);
            this.generation.Name = "generation";
            this.generation.Size = new System.Drawing.Size(62, 13);
            this.generation.TabIndex = 21;
            this.generation.Text = "Generation:";
            // 
            // textbox_population
            // 
            this.textbox_population.Location = new System.Drawing.Point(682, 26);
            this.textbox_population.Name = "textbox_population";
            this.textbox_population.Size = new System.Drawing.Size(72, 20);
            this.textbox_population.TabIndex = 20;
            this.textbox_population.Text = "5";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(679, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Baslangıç popülasyonu :";
            // 
            // fitness
            // 
            this.fitness.AutoSize = true;
            this.fitness.Location = new System.Drawing.Point(679, 176);
            this.fitness.Name = "fitness";
            this.fitness.Size = new System.Drawing.Size(43, 13);
            this.fitness.TabIndex = 18;
            this.fitness.Text = "Fitness:";
            // 
            // Onayla
            // 
            this.Onayla.BackColor = System.Drawing.SystemColors.Highlight;
            this.Onayla.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Onayla.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Onayla.Location = new System.Drawing.Point(51, 355);
            this.Onayla.Name = "Onayla";
            this.Onayla.Size = new System.Drawing.Size(228, 42);
            this.Onayla.TabIndex = 17;
            this.Onayla.Text = "Çöz";
            this.Onayla.UseVisualStyleBackColor = false;
            this.Onayla.Click += new System.EventHandler(this.Onayla_Click);
            // 
            // durum2
            // 
            this.durum2.AutoSize = true;
            this.durum2.Location = new System.Drawing.Point(679, 200);
            this.durum2.Name = "durum2";
            this.durum2.Size = new System.Drawing.Size(41, 13);
            this.durum2.TabIndex = 26;
            this.durum2.Text = "Durum:";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button3.ForeColor = System.Drawing.Color.Red;
            this.button3.Location = new System.Drawing.Point(655, 387);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(122, 39);
            this.button3.TabIndex = 27;
            this.button3.Text = "GERİ";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.durum2);
            this.Controls.Add(this.jenerasyon);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.mutate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.generation);
            this.Controls.Add(this.textbox_population);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fitness);
            this.Controls.Add(this.Onayla);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sudoku Bitirme Projesi - Muhammed Zeki Beyazpolat";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox jenerasyon;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox mutate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label generation;
        private System.Windows.Forms.TextBox textbox_population;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label fitness;
        private System.Windows.Forms.Button Onayla;
        private System.Windows.Forms.Label durum2;
        private System.Windows.Forms.Button button3;
    }
}

