namespace OpenNosClientLauncher
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.button_nosconf = new System.Windows.Forms.Button();
            this.radioButton_X = new System.Windows.Forms.RadioButton();
            this.radioButton_ogl = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox_savepw = new System.Windows.Forms.CheckBox();
            this.checkBox_savemail = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBox_upd_nost = new System.Windows.Forms.CheckBox();
            this.checkBox_upd_nosyx = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label_copyright = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.checkBox_autoGameLogon = new System.Windows.Forms.CheckBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox_GS_GUI = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_nosconf
            // 
            this.button_nosconf.Location = new System.Drawing.Point(12, 12);
            this.button_nosconf.Name = "button_nosconf";
            this.button_nosconf.Size = new System.Drawing.Size(166, 23);
            this.button_nosconf.TabIndex = 0;
            this.button_nosconf.Text = "Nostale Einstellungen";
            this.button_nosconf.UseVisualStyleBackColor = true;
            this.button_nosconf.Click += new System.EventHandler(this.button1_Click);
            // 
            // radioButton_X
            // 
            this.radioButton_X.AutoSize = true;
            this.radioButton_X.Checked = true;
            this.radioButton_X.Location = new System.Drawing.Point(6, 21);
            this.radioButton_X.Name = "radioButton_X";
            this.radioButton_X.Size = new System.Drawing.Size(123, 18);
            this.radioButton_X.TabIndex = 1;
            this.radioButton_X.TabStop = true;
            this.radioButton_X.Text = "DirectX (Standard)";
            this.radioButton_X.UseVisualStyleBackColor = true;
            this.radioButton_X.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton_ogl
            // 
            this.radioButton_ogl.AutoSize = true;
            this.radioButton_ogl.Location = new System.Drawing.Point(6, 46);
            this.radioButton_ogl.Name = "radioButton_ogl";
            this.radioButton_ogl.Size = new System.Drawing.Size(67, 18);
            this.radioButton_ogl.TabIndex = 2;
            this.radioButton_ogl.Text = "OpenGL";
            this.radioButton_ogl.UseVisualStyleBackColor = true;
            this.radioButton_ogl.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton_X);
            this.groupBox1.Controls.Add(this.radioButton_ogl);
            this.groupBox1.Location = new System.Drawing.Point(12, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(166, 68);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Graphic Mode";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox_savepw);
            this.groupBox2.Controls.Add(this.checkBox_savemail);
            this.groupBox2.Location = new System.Drawing.Point(194, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(166, 67);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Felder Speichern";
            // 
            // checkBox_savepw
            // 
            this.checkBox_savepw.AutoSize = true;
            this.checkBox_savepw.Enabled = false;
            this.checkBox_savepw.Location = new System.Drawing.Point(6, 45);
            this.checkBox_savepw.Name = "checkBox_savepw";
            this.checkBox_savepw.Size = new System.Drawing.Size(75, 18);
            this.checkBox_savepw.TabIndex = 1;
            this.checkBox_savepw.Text = "Passwort";
            this.checkBox_savepw.UseVisualStyleBackColor = true;
            this.checkBox_savepw.CheckedChanged += new System.EventHandler(this.checkBox_savepw_CheckedChanged);
            // 
            // checkBox_savemail
            // 
            this.checkBox_savemail.AutoSize = true;
            this.checkBox_savemail.Location = new System.Drawing.Point(6, 21);
            this.checkBox_savemail.Name = "checkBox_savemail";
            this.checkBox_savemail.Size = new System.Drawing.Size(105, 18);
            this.checkBox_savemail.TabIndex = 0;
            this.checkBox_savemail.Text = "Benutzername";
            this.checkBox_savemail.UseVisualStyleBackColor = true;
            this.checkBox_savemail.CheckedChanged += new System.EventHandler(this.checkBox_savemail_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.checkBox_upd_nost);
            this.groupBox3.Controls.Add(this.checkBox_upd_nosyx);
            this.groupBox3.Location = new System.Drawing.Point(376, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(166, 68);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Nach Updates suchen";
            // 
            // checkBox_upd_nost
            // 
            this.checkBox_upd_nost.AutoSize = true;
            this.checkBox_upd_nost.Location = new System.Drawing.Point(6, 45);
            this.checkBox_upd_nost.Name = "checkBox_upd_nost";
            this.checkBox_upd_nost.Size = new System.Drawing.Size(124, 18);
            this.checkBox_upd_nost.TabIndex = 1;
            this.checkBox_upd_nost.Text = "Off. Nostale Client";
            this.checkBox_upd_nost.UseVisualStyleBackColor = true;
            this.checkBox_upd_nost.CheckedChanged += new System.EventHandler(this.checkBox_upd_nost_CheckedChanged);
            // 
            // checkBox_upd_nosyx
            // 
            this.checkBox_upd_nosyx.AutoSize = true;
            this.checkBox_upd_nosyx.Location = new System.Drawing.Point(6, 21);
            this.checkBox_upd_nosyx.Name = "checkBox_upd_nosyx";
            this.checkBox_upd_nosyx.Size = new System.Drawing.Size(91, 18);
            this.checkBox_upd_nosyx.TabIndex = 0;
            this.checkBox_upd_nosyx.Text = "nosyx Client";
            this.checkBox_upd_nosyx.UseVisualStyleBackColor = true;
            this.checkBox_upd_nosyx.CheckedChanged += new System.EventHandler(this.checkBox_upd_nosyx_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.label_copyright);
            this.groupBox4.Location = new System.Drawing.Point(376, 115);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(166, 67);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Über";
            // 
            // label_copyright
            // 
            this.label_copyright.AutoSize = true;
            this.label_copyright.Location = new System.Drawing.Point(6, 18);
            this.label_copyright.Name = "label_copyright";
            this.label_copyright.Size = new System.Drawing.Size(124, 42);
            this.label_copyright.TabIndex = 0;
            this.label_copyright.Text = "nosyx Client Launcher\r\n     Version {v}\r\n(c) 2016 genyx.eu";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.linkLabel1);
            this.groupBox5.Controls.Add(this.checkBox_autoGameLogon);
            this.groupBox5.Controls.Add(this.numericUpDown1);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.checkBox_GS_GUI);
            this.groupBox5.Location = new System.Drawing.Point(194, 85);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(166, 97);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "AutoGameLogon";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(146, 22);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(13, 14);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "?";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // checkBox_autoGameLogon
            // 
            this.checkBox_autoGameLogon.AutoSize = true;
            this.checkBox_autoGameLogon.Location = new System.Drawing.Point(6, 21);
            this.checkBox_autoGameLogon.Name = "checkBox_autoGameLogon";
            this.checkBox_autoGameLogon.Size = new System.Drawing.Size(80, 18);
            this.checkBox_autoGameLogon.TabIndex = 0;
            this.checkBox_autoGameLogon.Text = "Aktivieren";
            this.checkBox_autoGameLogon.UseVisualStyleBackColor = true;
            this.checkBox_autoGameLogon.CheckedChanged += new System.EventHandler(this.checkBox_autoGameLogon_CheckedChanged);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDown1.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown1.Increment = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.numericUpDown1.Location = new System.Drawing.Point(83, 70);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            750,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(76, 21);
            this.numericUpDown1.TabIndex = 2;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown1.ThousandsSeparator = true;
            this.numericUpDown1.Value = new decimal(new int[] {
            1250,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "Verzög. (ms):";
            // 
            // checkBox_GS_GUI
            // 
            this.checkBox_GS_GUI.AutoSize = true;
            this.checkBox_GS_GUI.Location = new System.Drawing.Point(6, 45);
            this.checkBox_GS_GUI.Name = "checkBox_GS_GUI";
            this.checkBox_GS_GUI.Size = new System.Drawing.Size(132, 18);
            this.checkBox_GS_GUI.TabIndex = 1;
            this.checkBox_GS_GUI.Text = "Zeige Konsolen-Log";
            this.checkBox_GS_GUI.UseVisualStyleBackColor = true;
            this.checkBox_GS_GUI.CheckedChanged += new System.EventHandler(this.checkBox_GS_GUI_CheckedChanged);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 194);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_nosconf);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Einstellungen";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_nosconf;
        private System.Windows.Forms.RadioButton radioButton_X;
        private System.Windows.Forms.RadioButton radioButton_ogl;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBox_savepw;
        private System.Windows.Forms.CheckBox checkBox_savemail;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkBox_upd_nost;
        private System.Windows.Forms.CheckBox checkBox_upd_nosyx;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label_copyright;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox checkBox_GS_GUI;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox_autoGameLogon;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}