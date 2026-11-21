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
            System.Windows.Forms.DataGridViewCellStyle headerStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle cellStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle alternateStyle = new System.Windows.Forms.DataGridViewCellStyle();
            this.VelocityChangeBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.UpDateBtn = new System.Windows.Forms.Button();
            this.vuelosGrid = new System.Windows.Forms.DataGridView();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelSubtitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.vuelosGrid)).BeginInit();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // VelocityChangeBox
            // 
            this.VelocityChangeBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.VelocityChangeBox.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.VelocityChangeBox.Location = new System.Drawing.Point(20, 348);
            this.VelocityChangeBox.Name = "VelocityChangeBox";
            this.VelocityChangeBox.Size = new System.Drawing.Size(220, 32);
            this.VelocityChangeBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(20, 325);
            this.label1.Name = "label1";
            this.label1.TabIndex = 1;
            this.label1.Text = "New speed (km/h)";
            // 
            // UpDateBtn
            // 
            this.UpDateBtn.BackColor = System.Drawing.Color.RoyalBlue;
            this.UpDateBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UpDateBtn.FlatAppearance.BorderSize = 0;
            this.UpDateBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.UpDateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpDateBtn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.UpDateBtn.ForeColor = System.Drawing.Color.White;
            this.UpDateBtn.Location = new System.Drawing.Point(260, 346);
            this.UpDateBtn.Name = "UpDateBtn";
            this.UpDateBtn.Size = new System.Drawing.Size(200, 36);
            this.UpDateBtn.TabIndex = 4;
            this.UpDateBtn.Text = "Update speed";
            this.UpDateBtn.UseVisualStyleBackColor = false;
            this.UpDateBtn.Click += new System.EventHandler(this.UpDateBtn_Click);
            // 
            // vuelosGrid
            // 
            this.vuelosGrid.AllowUserToAddRows = false;
            this.vuelosGrid.AllowUserToResizeRows = false;
            alternateStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.vuelosGrid.AlternatingRowsDefaultCellStyle = alternateStyle;
            this.vuelosGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.vuelosGrid.BackgroundColor = System.Drawing.Color.White;
            this.vuelosGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.vuelosGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.vuelosGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            headerStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            headerStyle.BackColor = System.Drawing.Color.MidnightBlue;
            headerStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            headerStyle.ForeColor = System.Drawing.Color.White;
            headerStyle.SelectionBackColor = System.Drawing.Color.MidnightBlue;
            headerStyle.SelectionForeColor = System.Drawing.Color.White;
            headerStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.vuelosGrid.ColumnHeadersDefaultCellStyle = headerStyle;
            this.vuelosGrid.ColumnHeadersHeight = 36;
            this.vuelosGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            cellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            cellStyle.BackColor = System.Drawing.Color.White;
            cellStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            cellStyle.ForeColor = System.Drawing.Color.Black;
            cellStyle.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            cellStyle.SelectionForeColor = System.Drawing.Color.MidnightBlue;
            cellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.vuelosGrid.DefaultCellStyle = cellStyle;
            this.vuelosGrid.EnableHeadersVisualStyles = false;
            this.vuelosGrid.GridColor = System.Drawing.Color.Gainsboro;
            this.vuelosGrid.ReadOnly = true;
            this.vuelosGrid.RowHeadersVisible = false;
            this.vuelosGrid.RowHeadersWidth = 51;
            this.vuelosGrid.RowTemplate.Height = 30;
            this.vuelosGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.vuelosGrid.Location = new System.Drawing.Point(20, 110);
            this.vuelosGrid.Name = "vuelosGrid";
            this.vuelosGrid.Size = new System.Drawing.Size(440, 200);
            this.vuelosGrid.TabIndex = 5;
            this.vuelosGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.vuelosGrid_CellClick);
            // 
            // labelTitle
            // 
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(0, 18);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(480, 36);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Change speed";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSubtitle
            // 
            this.labelSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelSubtitle.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.labelSubtitle.Location = new System.Drawing.Point(0, 54);
            this.labelSubtitle.Name = "labelSubtitle";
            this.labelSubtitle.Size = new System.Drawing.Size(480, 24);
            this.labelSubtitle.TabIndex = 1;
            this.labelSubtitle.Text = "Select a flight, type the new speed and press Update";
            this.labelSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.MidnightBlue;
            this.panelHeader.Controls.Add(this.labelTitle);
            this.panelHeader.Controls.Add(this.labelSubtitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(480, 90);
            this.panelHeader.TabIndex = 20;
            // 
            // Velocity
            // 
            this.AcceptButton = this.UpDateBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(480, 405);
            this.Controls.Add(this.vuelosGrid);
            this.Controls.Add(this.UpDateBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.VelocityChangeBox);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Velocity";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AirTrafficSim - Change speed";
            this.Load += new System.EventHandler(this.Velocity_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vuelosGrid)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox VelocityChangeBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button UpDateBtn;
        private System.Windows.Forms.DataGridView vuelosGrid;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelSubtitle;
    }
}