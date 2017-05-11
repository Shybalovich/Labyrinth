namespace Labyrinth
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.butt_begin = new System.Windows.Forms.Button();
            this.butt_end = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.butt_end);
            this.panel1.Controls.Add(this.butt_begin);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(657, 53);
            this.panel1.TabIndex = 0;
            // 
            // butt_begin
            // 
            this.butt_begin.AutoSize = true;
            this.butt_begin.Location = new System.Drawing.Point(23, 12);
            this.butt_begin.Name = "butt_begin";
            this.butt_begin.Size = new System.Drawing.Size(80, 31);
            this.butt_begin.TabIndex = 0;
            this.butt_begin.Text = "Начать игру";
            this.butt_begin.UseVisualStyleBackColor = true;
            this.butt_begin.Click += new System.EventHandler(this.butt_begin_Click);
            // 
            // butt_end
            // 
            this.butt_end.AutoSize = true;
            this.butt_end.Location = new System.Drawing.Point(128, 12);
            this.butt_end.Name = "butt_end";
            this.butt_end.Size = new System.Drawing.Size(98, 31);
            this.butt_end.TabIndex = 1;
            this.butt_end.Text = "Завершить игру";
            this.butt_end.UseVisualStyleBackColor = true;
            this.butt_end.Click += new System.EventHandler(this.butt_end_Click);
            // 
            // button3
            // 
            this.button3.AutoSize = true;
            this.button3.Location = new System.Drawing.Point(253, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(89, 31);
            this.button3.TabIndex = 2;
            this.button3.Text = "Правила игры";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(657, 405);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Лабиринт";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button butt_begin;
        private System.Windows.Forms.Button butt_end;
        private System.Windows.Forms.Button button3;

    }
}

