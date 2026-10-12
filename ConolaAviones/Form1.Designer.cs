namespace ConolaAviones
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menúToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.planesDeVueloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.distanciaYTiempoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.airspaceAndInitialLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LightBlue;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menúToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(900, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menúToolStripMenuItem
            // 
            this.menúToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.planesDeVueloToolStripMenuItem,
            this.distanciaYTiempoToolStripMenuItem,
            this.airspaceAndInitialLocationToolStripMenuItem});
            this.menúToolStripMenuItem.Name = "menúToolStripMenuItem";
            this.menúToolStripMenuItem.Size = new System.Drawing.Size(60, 24);
            this.menúToolStripMenuItem.Text = "Menu";
            // 
            // planesDeVueloToolStripMenuItem
            // 
            this.planesDeVueloToolStripMenuItem.Name = "planesDeVueloToolStripMenuItem";
            this.planesDeVueloToolStripMenuItem.Size = new System.Drawing.Size(199, 26);
            this.planesDeVueloToolStripMenuItem.Text = "Enter flight data";
            this.planesDeVueloToolStripMenuItem.Click += new System.EventHandler(this.planesDeVueloToolStripMenuItem_Click);
            // 
            // distanciaYTiempoToolStripMenuItem
            // 
            this.distanciaYTiempoToolStripMenuItem.Name = "distanciaYTiempoToolStripMenuItem";
            this.distanciaYTiempoToolStripMenuItem.Size = new System.Drawing.Size(199, 26);
            this.distanciaYTiempoToolStripMenuItem.Text = "Settings";
            this.distanciaYTiempoToolStripMenuItem.Click += new System.EventHandler(this.distanciaYTiempoToolStripMenuItem_Click);
            // 
            // airspaceAndInitialLocationToolStripMenuItem
            // 
            this.airspaceAndInitialLocationToolStripMenuItem.Name = "airspaceAndInitialLocationToolStripMenuItem";
            this.airspaceAndInitialLocationToolStripMenuItem.Size = new System.Drawing.Size(199, 26);
            this.airspaceAndInitialLocationToolStripMenuItem.Text = "Start simulation";
            this.airspaceAndInitialLocationToolStripMenuItem.Click += new System.EventHandler(this.airspaceAndInitialLocationToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("HP Simplified", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(0, 253);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(902, 38);
            this.label1.TabIndex = 1;
            this.label1.Text = "Air Traffic Simulator";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Location = new System.Drawing.Point(0, 312);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(902, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "1. Enter flight data · 2. Configure settings · 3. Start simulation";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::ConolaAviones.Properties.Resources.Gemini_Generated_Image_j6teu1j6teu1j6te_removebg_preview;
            this.pictureBox1.Location = new System.Drawing.Point(0, 350);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(902, 125);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(900, 647);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Flight Simulator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menúToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem planesDeVueloToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem distanciaYTiempoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem airspaceAndInitialLocationToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

