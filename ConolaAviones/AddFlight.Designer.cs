namespace AirTrafficSimForms
{
    partial class AddFlightForm
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
            this.IDBox = new System.Windows.Forms.TextBox();
            this.CompanyBox = new System.Windows.Forms.TextBox();
            this.X1Box = new System.Windows.Forms.TextBox();
            this.Y1Box = new System.Windows.Forms.TextBox();
            this.X2Box = new System.Windows.Forms.TextBox();
            this.Y2Box = new System.Windows.Forms.TextBox();
            this.SpeedBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.AddFlightBtn = new System.Windows.Forms.Button();
            this.AutoFilBtn = new System.Windows.Forms.Button();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // IDBox
            // 
            this.IDBox.Location = new System.Drawing.Point(44, 106);
            this.IDBox.Name = "IDBox";
            this.IDBox.Size = new System.Drawing.Size(304, 22);
            this.IDBox.TabIndex = 0;
            // 
            // CompanyBox
            // 
            this.CompanyBox.Location = new System.Drawing.Point(416, 106);
            this.CompanyBox.Name = "CompanyBox";
            this.CompanyBox.Size = new System.Drawing.Size(305, 22);
            this.CompanyBox.TabIndex = 1;
            // 
            // X1Box
            // 
            this.X1Box.Location = new System.Drawing.Point(44, 238);
            this.X1Box.Name = "X1Box";
            this.X1Box.Size = new System.Drawing.Size(303, 22);
            this.X1Box.TabIndex = 2;
            // 
            // Y1Box
            // 
            this.Y1Box.Location = new System.Drawing.Point(416, 238);
            this.Y1Box.Name = "Y1Box";
            this.Y1Box.Size = new System.Drawing.Size(304, 22);
            this.Y1Box.TabIndex = 3;
            // 
            // X2Box
            // 
            this.X2Box.Location = new System.Drawing.Point(44, 332);
            this.X2Box.Name = "X2Box";
            this.X2Box.Size = new System.Drawing.Size(303, 22);
            this.X2Box.TabIndex = 4;
            // 
            // Y2Box
            // 
            this.Y2Box.Location = new System.Drawing.Point(416, 332);
            this.Y2Box.Name = "Y2Box";
            this.Y2Box.Size = new System.Drawing.Size(304, 22);
            this.Y2Box.TabIndex = 5;
            // 
            // SpeedBox
            // 
            this.SpeedBox.Location = new System.Drawing.Point(44, 432);
            this.SpeedBox.Name = "SpeedBox";
            this.SpeedBox.Size = new System.Drawing.Size(303, 22);
            this.SpeedBox.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Flight ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(416, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Airline";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 205);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Initial X";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(416, 205);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Final X";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 299);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Initial Y";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(416, 299);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "Final Y";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(44, 399);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 16);
            this.label7.TabIndex = 13;
            this.label7.Text = "Speed (km/h)";
            // 
            // AddFlightBtn
            // 
            this.AddFlightBtn.Location = new System.Drawing.Point(47, 531);
            this.AddFlightBtn.Name = "AddFlightBtn";
            this.AddFlightBtn.Size = new System.Drawing.Size(193, 44);
            this.AddFlightBtn.TabIndex = 14;
            this.AddFlightBtn.Text = "Add Flight";
            this.AddFlightBtn.UseVisualStyleBackColor = true;
            this.AddFlightBtn.Click += new System.EventHandler(this.AddFlightBtn_Click);
            // 
            // AutoFilBtn
            // 
            this.AutoFilBtn.Location = new System.Drawing.Point(284, 532);
            this.AutoFilBtn.Name = "AutoFilBtn";
            this.AutoFilBtn.Size = new System.Drawing.Size(191, 42);
            this.AutoFilBtn.TabIndex = 15;
            this.AutoFilBtn.Text = "Autofill";
            this.AutoFilBtn.UseVisualStyleBackColor = true;
            this.AutoFilBtn.Click += new System.EventHandler(this.AutoFilBtn_Click);
            // 
            // CloseBtn
            // 
            this.CloseBtn.Location = new System.Drawing.Point(524, 532);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(195, 42);
            this.CloseBtn.TabIndex = 16;
            this.CloseBtn.Text = "Close";
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // AddFlightForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(804, 604);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.AutoFilBtn);
            this.Controls.Add(this.AddFlightBtn);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SpeedBox);
            this.Controls.Add(this.Y2Box);
            this.Controls.Add(this.X2Box);
            this.Controls.Add(this.Y1Box);
            this.Controls.Add(this.X1Box);
            this.Controls.Add(this.CompanyBox);
            this.Controls.Add(this.IDBox);
            this.Name = "AddFlightForm";
            this.Text = "AddFlightForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox IDBox;
        private System.Windows.Forms.TextBox CompanyBox;
        private System.Windows.Forms.TextBox X1Box;
        private System.Windows.Forms.TextBox Y1Box;
        private System.Windows.Forms.TextBox X2Box;
        private System.Windows.Forms.TextBox Y2Box;
        private System.Windows.Forms.TextBox SpeedBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button AddFlightBtn;
        private System.Windows.Forms.Button AutoFilBtn;
        private System.Windows.Forms.Button CloseBtn;
    }
}