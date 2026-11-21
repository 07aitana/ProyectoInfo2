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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(760, 45);
            this.label1.TabIndex = 1;
            this.label1.Text = "Air Traffic Simulator";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.label2.Location = new System.Drawing.Point(0, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(760, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Main menu - choose an option";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AddFlightBtn
            // 
            this.AddFlightBtn.BackColor = System.Drawing.Color.White;
            this.AddFlightBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddFlightBtn.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.AddFlightBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.AddFlightBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddFlightBtn.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.AddFlightBtn.ForeColor = System.Drawing.Color.MidnightBlue;
            this.AddFlightBtn.Location = new System.Drawing.Point(400, 160);
            this.AddFlightBtn.Name = "AddFlightBtn";
            this.AddFlightBtn.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.AddFlightBtn.Size = new System.Drawing.Size(320, 90);
            this.AddFlightBtn.TabIndex = 4;
            this.AddFlightBtn.Text = "Add Flight";
            this.AddFlightBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.AddFlightBtn.UseVisualStyleBackColor = false;
            this.AddFlightBtn.Click += new System.EventHandler(this.AddFlightBtn_Click);
            // 
            // SimulationBtn
            // 
            this.SimulationBtn.BackColor = System.Drawing.Color.RoyalBlue;
            this.SimulationBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SimulationBtn.FlatAppearance.BorderSize = 0;
            this.SimulationBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.SimulationBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SimulationBtn.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.SimulationBtn.ForeColor = System.Drawing.Color.White;
            this.SimulationBtn.Location = new System.Drawing.Point(400, 280);
            this.SimulationBtn.Name = "SimulationBtn";
            this.SimulationBtn.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.SimulationBtn.Size = new System.Drawing.Size(320, 90);
            this.SimulationBtn.TabIndex = 5;
            this.SimulationBtn.Text = "Simulation";
            this.SimulationBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.SimulationBtn.UseVisualStyleBackColor = false;
            this.SimulationBtn.Click += new System.EventHandler(this.SimulationBtn_Click);
            // 
            // SettingsBtn
            // 
            this.SettingsBtn.BackColor = System.Drawing.Color.White;
            this.SettingsBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SettingsBtn.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.SettingsBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.SettingsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SettingsBtn.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.SettingsBtn.ForeColor = System.Drawing.Color.MidnightBlue;
            this.SettingsBtn.Location = new System.Drawing.Point(40, 280);
            this.SettingsBtn.Name = "SettingsBtn";
            this.SettingsBtn.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.SettingsBtn.Size = new System.Drawing.Size(320, 90);
            this.SettingsBtn.TabIndex = 6;
            this.SettingsBtn.Text = "Settings";
            this.SettingsBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.SettingsBtn.UseVisualStyleBackColor = false;
            this.SettingsBtn.Click += new System.EventHandler(this.SettingsBtn_Click);
            // 
            // LoadFlightsBtn
            // 
            this.LoadFlightsBtn.BackColor = System.Drawing.Color.White;
            this.LoadFlightsBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LoadFlightsBtn.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.LoadFlightsBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.LoadFlightsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoadFlightsBtn.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.LoadFlightsBtn.ForeColor = System.Drawing.Color.MidnightBlue;
            this.LoadFlightsBtn.Location = new System.Drawing.Point(40, 160);
            this.LoadFlightsBtn.Name = "LoadFlightsBtn";
            this.LoadFlightsBtn.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.LoadFlightsBtn.Size = new System.Drawing.Size(320, 90);
            this.LoadFlightsBtn.TabIndex = 7;
            this.LoadFlightsBtn.Text = "Load Flights";
            this.LoadFlightsBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.LoadFlightsBtn.UseVisualStyleBackColor = false;
            this.LoadFlightsBtn.Click += new System.EventHandler(this.LoadFlightsBtn_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(42, 212);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(316, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "Import flights from TXT";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.Click += new System.EventHandler(this.LoadFlightsBtn_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.RoyalBlue;
            this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label4.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.label4.Location = new System.Drawing.Point(402, 332);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(316, 25);
            this.label4.TabIndex = 9;
            this.label4.Text = "Open deconflicting tool";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.Click += new System.EventHandler(this.SimulationBtn_Click);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(402, 212);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(316, 25);
            this.label5.TabIndex = 10;
            this.label5.Text = "Manual entry or autofill";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label5.Click += new System.EventHandler(this.AddFlightBtn_Click);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(42, 332);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(316, 25);
            this.label6.TabIndex = 11;
            this.label6.Text = "Simulation parameters";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label6.Click += new System.EventHandler(this.SettingsBtn_Click);
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.MidnightBlue;
            this.panelHeader.Controls.Add(this.label1);
            this.panelHeader.Controls.Add(this.label2);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(760, 120);
            this.panelHeader.TabIndex = 12;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(760, 420);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LoadFlightsBtn);
            this.Controls.Add(this.SettingsBtn);
            this.Controls.Add(this.SimulationBtn);
            this.Controls.Add(this.AddFlightBtn);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AirTrafficSim - Main menu";
            this.panelHeader.ResumeLayout(false);
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Panel panelHeader;
    }
}

