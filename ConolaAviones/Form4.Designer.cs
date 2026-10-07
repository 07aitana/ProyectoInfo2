namespace ConolaAviones
{
    partial class Form4
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
            this.panelAirspace = new System.Windows.Forms.Panel();
            this.btnmove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panelAirspace
            // 
            this.panelAirspace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelAirspace.Location = new System.Drawing.Point(186, 84);
            this.panelAirspace.Name = "panelAirspace";
            this.panelAirspace.Size = new System.Drawing.Size(398, 260);
            this.panelAirspace.TabIndex = 0;
            this.panelAirspace.Paint += new System.Windows.Forms.PaintEventHandler(this.panelAirspace_Paint);
            // 
            // btnmove
            // 
            this.btnmove.Location = new System.Drawing.Point(650, 193);
            this.btnmove.Name = "btnmove";
            this.btnmove.Size = new System.Drawing.Size(75, 23);
            this.btnmove.TabIndex = 1;
            this.btnmove.Text = "move";
            this.btnmove.UseVisualStyleBackColor = true;
            this.btnmove.Click += new System.EventHandler(this.btnmove_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnmove);
            this.Controls.Add(this.panelAirspace);
            this.Name = "Form4";
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelAirspace;
        private System.Windows.Forms.Button btnmove;
    }
}