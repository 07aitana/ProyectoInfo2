namespace AirTrafficSimForms
{
    partial class MainForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.AddFlightBtn = new System.Windows.Forms.Button();
            this.SimulationBtn = new System.Windows.Forms.Button();
            this.SettingsBtn = new System.Windows.Forms.Button();
            this.LoadFlightsBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(2, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(835, 38);
            this.label1.TabIndex = 1;
            this.label1.Text = "Air Traffic Simulator";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Location = new System.Drawing.Point(-14, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(835, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Main Menu";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AddFlightBtn
            // 
            this.AddFlightBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddFlightBtn.Location = new System.Drawing.Point(484, 213);
            this.AddFlightBtn.Name = "AddFlightBtn";
            this.AddFlightBtn.Size = new System.Drawing.Size(275, 80);
            this.AddFlightBtn.TabIndex = 4;
            this.AddFlightBtn.Text = "Add Flight";
            this.AddFlightBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.AddFlightBtn.UseVisualStyleBackColor = true;
            this.AddFlightBtn.Click += new System.EventHandler(this.AddFlightBtn_Click);
            // 
            // SimulationBtn
            // 
            this.SimulationBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SimulationBtn.Location = new System.Drawing.Point(484, 330);
            this.SimulationBtn.Name = "SimulationBtn";
            this.SimulationBtn.Size = new System.Drawing.Size(275, 82);
            this.SimulationBtn.TabIndex = 5;
            this.SimulationBtn.Text = "Simulation";
            this.SimulationBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.SimulationBtn.UseVisualStyleBackColor = true;
            this.SimulationBtn.Click += new System.EventHandler(this.SimulationBtn_Click);
            // 
            // SettingsBtn
            // 
            this.SettingsBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SettingsBtn.Location = new System.Drawing.Point(55, 330);
            this.SettingsBtn.Name = "SettingsBtn";
            this.SettingsBtn.Size = new System.Drawing.Size(275, 82);
            this.SettingsBtn.TabIndex = 6;
            this.SettingsBtn.Text = "Settings";
            this.SettingsBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.SettingsBtn.UseVisualStyleBackColor = true;
            this.SettingsBtn.Click += new System.EventHandler(this.SettingsBtn_Click);
            // 
            // LoadFlightsBtn
            // 
            this.LoadFlightsBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadFlightsBtn.Location = new System.Drawing.Point(55, 213);
            this.LoadFlightsBtn.Name = "LoadFlightsBtn";
            this.LoadFlightsBtn.Size = new System.Drawing.Size(275, 80);
            this.LoadFlightsBtn.TabIndex = 7;
            this.LoadFlightsBtn.Tag = "";
            this.LoadFlightsBtn.Text = "Load Flights ";
            this.LoadFlightsBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.LoadFlightsBtn.UseVisualStyleBackColor = true;
            this.LoadFlightsBtn.Click += new System.EventHandler(this.LoadFlightsBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(97, 261);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(187, 23);
            this.label3.TabIndex = 8;
            this.label3.Text = "Import flights form TXT";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(535, 377);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(190, 23);
            this.label4.TabIndex = 9;
            this.label4.Text = "Open deconflicting tool";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(535, 261);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(185, 23);
            this.label5.TabIndex = 10;
            this.label5.Text = "Manual entry or autofil";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(102, 377);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(182, 23);
            this.label6.TabIndex = 11;
            this.label6.Text = "Simulation parameters";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(833, 477);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LoadFlightsBtn);
            this.Controls.Add(this.SettingsBtn);
            this.Controls.Add(this.SimulationBtn);
            this.Controls.Add(this.AddFlightBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Flight Simulator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button AddFlightBtn;
        private System.Windows.Forms.Button SimulationBtn;
        private System.Windows.Forms.Button SettingsBtn;
        private System.Windows.Forms.Button LoadFlightsBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

