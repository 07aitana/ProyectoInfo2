namespace ConolaAviones
{
    partial class Form5
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
            this.label1 = new System.Windows.Forms.Label();
            this.labelId = new System.Windows.Forms.Label();
            this.labelCurrentPosition = new System.Windows.Forms.Label();
            this.labelFinalPosition = new System.Windows.Forms.Label();
            this.labelSpeed = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(327, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Aircraft information";
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(85, 106);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(23, 16);
            this.labelId.TabIndex = 1;
            this.labelId.Text = "ID:";
            // 
            // labelCurrentPosition
            // 
            this.labelCurrentPosition.AutoSize = true;
            this.labelCurrentPosition.Location = new System.Drawing.Point(85, 147);
            this.labelCurrentPosition.Name = "labelCurrentPosition";
            this.labelCurrentPosition.Size = new System.Drawing.Size(102, 16);
            this.labelCurrentPosition.TabIndex = 2;
            this.labelCurrentPosition.Text = "Current position:";
            // 
            // labelFinalPosition
            // 
            this.labelFinalPosition.AutoSize = true;
            this.labelFinalPosition.Location = new System.Drawing.Point(85, 196);
            this.labelFinalPosition.Name = "labelFinalPosition";
            this.labelFinalPosition.Size = new System.Drawing.Size(86, 16);
            this.labelFinalPosition.TabIndex = 3;
            this.labelFinalPosition.Text = "Final position";
            // 
            // labelSpeed
            // 
            this.labelSpeed.AutoSize = true;
            this.labelSpeed.Location = new System.Drawing.Point(85, 237);
            this.labelSpeed.Name = "labelSpeed";
            this.labelSpeed.Size = new System.Drawing.Size(51, 16);
            this.labelSpeed.TabIndex = 4;
            this.labelSpeed.Text = "Speed:";
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelSpeed);
            this.Controls.Add(this.labelFinalPosition);
            this.Controls.Add(this.labelCurrentPosition);
            this.Controls.Add(this.labelId);
            this.Controls.Add(this.label1);
            this.Name = "Form5";
            this.Text = "Form5";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.Label labelCurrentPosition;
        private System.Windows.Forms.Label labelFinalPosition;
        private System.Windows.Forms.Label labelSpeed;
    }
}