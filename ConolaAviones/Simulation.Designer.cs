namespace AirTrafficSimForms
{
    partial class SimulationForm
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
            this.components = new System.ComponentModel.Container();
            this.panelAirspace = new System.Windows.Forms.Panel();
            this.btnmove = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnData = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCheck = new System.Windows.Forms.Button();
            this.ChangeVelocityBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelAirspace
            // 
            this.panelAirspace.BackColor = System.Drawing.Color.White;
            this.panelAirspace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelAirspace.Location = new System.Drawing.Point(20, 20);
            this.panelAirspace.Name = "panelAirspace";
            this.panelAirspace.Size = new System.Drawing.Size(520, 480);
            this.panelAirspace.TabIndex = 0;
            this.panelAirspace.Paint += new System.Windows.Forms.PaintEventHandler(this.panelAirspace_Paint);
            this.panelAirspace.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelAirspace_MouseClick);
            // 
            // btnmove
            // 
            this.btnmove.Location = new System.Drawing.Point(15, 110);
            this.btnmove.Name = "btnmove";
            this.btnmove.Size = new System.Drawing.Size(150, 30);
            this.btnmove.TabIndex = 1;
            this.btnmove.Text = "Move one cycle";
            this.btnmove.UseVisualStyleBackColor = true;
            this.btnmove.Click += new System.EventHandler(this.btnmove_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(15, 30);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(150, 30);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(15, 70);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(150, 30);
            this.btnStop.TabIndex = 0;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnData
            // 
            this.btnData.Location = new System.Drawing.Point(15, 30);
            this.btnData.Name = "btnData";
            this.btnData.Size = new System.Drawing.Size(150, 30);
            this.btnData.TabIndex = 3;
            this.btnData.Text = "Flight data";
            this.btnData.UseVisualStyleBackColor = true;
            this.btnData.Click += new System.EventHandler(this.btnData_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ChangeVelocityBtn);
            this.groupBox1.Controls.Add(this.btnStart);
            this.groupBox1.Controls.Add(this.btnStop);
            this.groupBox1.Controls.Add(this.btnmove);
            this.groupBox1.Location = new System.Drawing.Point(560, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(180, 196);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Simulation";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCheck);
            this.groupBox2.Controls.Add(this.btnData);
            this.groupBox2.Location = new System.Drawing.Point(560, 236);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(180, 115);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Information";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(15, 66);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(150, 30);
            this.btnCheck.TabIndex = 4;
            this.btnCheck.Text = "Check conflict";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // ChangeVelocityBtn
            // 
            this.ChangeVelocityBtn.Location = new System.Drawing.Point(15, 157);
            this.ChangeVelocityBtn.Name = "ChangeVelocityBtn";
            this.ChangeVelocityBtn.Size = new System.Drawing.Size(150, 26);
            this.ChangeVelocityBtn.TabIndex = 3;
            this.ChangeVelocityBtn.Text = "Change Velocity";
            this.ChangeVelocityBtn.UseVisualStyleBackColor = true;
            this.ChangeVelocityBtn.Click += new System.EventHandler(this.ChangeVelocityBtn_Click);
            // 
            // SimulationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(764, 514);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panelAirspace);
            this.Name = "SimulationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simulation";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelAirspace;
        private System.Windows.Forms.Button btnmove;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnData;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button ChangeVelocityBtn;
    }
}