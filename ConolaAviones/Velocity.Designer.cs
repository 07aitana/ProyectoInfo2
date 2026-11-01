namespace AirTrafficSimForms
{
    partial class Velocity
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
            this.VelocityChangeBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.UpDateBtn = new System.Windows.Forms.Button();
            this.vuelosGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.vuelosGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // VelocityChangeBox
            // 
            this.VelocityChangeBox.Location = new System.Drawing.Point(136, 57);
            this.VelocityChangeBox.Name = "VelocityChangeBox";
            this.VelocityChangeBox.Size = new System.Drawing.Size(100, 22);
            this.VelocityChangeBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Velocity";
            // 
            // UpDateBtn
            // 
            this.UpDateBtn.Location = new System.Drawing.Point(289, 57);
            this.UpDateBtn.Name = "UpDateBtn";
            this.UpDateBtn.Size = new System.Drawing.Size(75, 23);
            this.UpDateBtn.TabIndex = 4;
            this.UpDateBtn.Text = "UpDate";
            this.UpDateBtn.UseVisualStyleBackColor = true;
            this.UpDateBtn.Click += new System.EventHandler(this.UpDateBtn_Click);
            // 
            // vuelosGrid
            // 
            this.vuelosGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vuelosGrid.Location = new System.Drawing.Point(49, 115);
            this.vuelosGrid.Name = "vuelosGrid";
            this.vuelosGrid.RowHeadersWidth = 51;
            this.vuelosGrid.RowTemplate.Height = 24;
            this.vuelosGrid.Size = new System.Drawing.Size(349, 150);
            this.vuelosGrid.TabIndex = 5;
            this.vuelosGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.vuelosGrid_CellClick);
            // 
            // Velocity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(447, 300);
            this.Controls.Add(this.vuelosGrid);
            this.Controls.Add(this.UpDateBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.VelocityChangeBox);
            this.Name = "Velocity";
            this.Text = "Velocity";
            this.Load += new System.EventHandler(this.Velocity_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vuelosGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox VelocityChangeBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button UpDateBtn;
        private System.Windows.Forms.DataGridView vuelosGrid;
    }
}