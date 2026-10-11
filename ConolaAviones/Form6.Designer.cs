namespace ConolaAviones
{
    partial class Form6
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
            this.vuelosGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.vuelosGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // vuelosGrid
            // 
            this.vuelosGrid.AllowUserToAddRows = false;
            this.vuelosGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vuelosGrid.Location = new System.Drawing.Point(12, 12);
            this.vuelosGrid.Name = "vuelosGrid";
            this.vuelosGrid.RowHeadersWidth = 51;
            this.vuelosGrid.RowTemplate.Height = 24;
            this.vuelosGrid.Size = new System.Drawing.Size(776, 426);
            this.vuelosGrid.TabIndex = 0;
            this.vuelosGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.vuelosGrid_CellClick);
            // 
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.vuelosGrid);
            this.Name = "Form6";
            this.Text = "Form6";
            this.Load += new System.EventHandler(this.Form6_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vuelosGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView vuelosGrid;
    }
}