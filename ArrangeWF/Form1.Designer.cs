namespace ArrangeWF
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
            this.b_start = new System.Windows.Forms.Button();
            this.nud_city = new System.Windows.Forms.NumericUpDown();
            this.lb_city = new System.Windows.Forms.Label();
            this.lb_count = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nud_city)).BeginInit();
            this.SuspendLayout();
            // 
            // b_start
            // 
            this.b_start.Location = new System.Drawing.Point(53, 92);
            this.b_start.Name = "b_start";
            this.b_start.Size = new System.Drawing.Size(144, 101);
            this.b_start.TabIndex = 0;
            this.b_start.Text = "Start";
            this.b_start.UseVisualStyleBackColor = true;
            this.b_start.Click += new System.EventHandler(this.b_start_Click);
            // 
            // nud_city
            // 
            this.nud_city.Location = new System.Drawing.Point(91, 58);
            this.nud_city.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nud_city.Name = "nud_city";
            this.nud_city.Size = new System.Drawing.Size(65, 20);
            this.nud_city.TabIndex = 1;
            // 
            // lb_city
            // 
            this.lb_city.AutoSize = true;
            this.lb_city.Location = new System.Drawing.Point(12, 9);
            this.lb_city.Name = "lb_city";
            this.lb_city.Size = new System.Drawing.Size(218, 13);
            this.lb_city.TabIndex = 2;
            this.lb_city.Text = "Случайная генерация карточек и городов";
            // 
            // lb_count
            // 
            this.lb_count.AutoSize = true;
            this.lb_count.Location = new System.Drawing.Point(68, 32);
            this.lb_count.Name = "lb_count";
            this.lb_count.Size = new System.Drawing.Size(110, 13);
            this.lb_count.TabIndex = 3;
            this.lb_count.Text = "Количество городов";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 205);
            this.Controls.Add(this.lb_count);
            this.Controls.Add(this.lb_city);
            this.Controls.Add(this.nud_city);
            this.Controls.Add(this.b_start);
            this.Name = "Form1";
            this.Text = "Путешествие";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nud_city)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button b_start;
        private System.Windows.Forms.NumericUpDown nud_city;
        private System.Windows.Forms.Label lb_city;
        private System.Windows.Forms.Label lb_count;
    }
}

