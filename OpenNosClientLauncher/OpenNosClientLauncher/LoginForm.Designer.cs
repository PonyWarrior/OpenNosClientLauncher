namespace OpenNosClientLauncher
{
    partial class LoginForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.groupBox_username = new System.Windows.Forms.GroupBox();
            this.textBox_username = new System.Windows.Forms.TextBox();
            this.groupBox_password = new System.Windows.Forms.GroupBox();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.button_quit = new System.Windows.Forms.Button();
            this.panel_mainframe = new System.Windows.Forms.Panel();
            this.panel_autologin = new System.Windows.Forms.Panel();
            this.button_autologin_back = new System.Windows.Forms.Button();
            this.button_autologin_save = new System.Windows.Forms.Button();
            this.label_autologininfo_encrypted = new System.Windows.Forms.Label();
            this.label_autologininfo = new System.Windows.Forms.Label();
            this.groupBox_delay = new System.Windows.Forms.GroupBox();
            this.numericUpDown_delay = new System.Windows.Forms.NumericUpDown();
            this.panel_settings = new System.Windows.Forms.Panel();
            this.panel_mainmenu = new System.Windows.Forms.Panel();
            this.linkLabel_settings = new System.Windows.Forms.LinkLabel();
            this.linkLabel_changeautologin = new System.Windows.Forms.LinkLabel();
            this.groupBox_server = new System.Windows.Forms.GroupBox();
            this.textBox_server = new System.Windows.Forms.TextBox();
            this.panel_langselect = new System.Windows.Forms.Panel();
            this.label_loginas = new System.Windows.Forms.Label();
            this.pictureBox_tr = new System.Windows.Forms.PictureBox();
            this.pictureBox_de = new System.Windows.Forms.PictureBox();
            this.pictureBox_ru = new System.Windows.Forms.PictureBox();
            this.pictureBox_cz = new System.Windows.Forms.PictureBox();
            this.pictureBox_it = new System.Windows.Forms.PictureBox();
            this.pictureBox_es = new System.Windows.Forms.PictureBox();
            this.button_gamestart = new System.Windows.Forms.Button();
            this.pictureBox_pl = new System.Windows.Forms.PictureBox();
            this.pictureBox_en = new System.Windows.Forms.PictureBox();
            this.pictureBox_fr = new System.Windows.Forms.PictureBox();
            this.panel_topbar = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label_xmenu_x = new System.Windows.Forms.Label();
            this.pictureBox_logo = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.groupBox_username.SuspendLayout();
            this.groupBox_password.SuspendLayout();
            this.panel_mainframe.SuspendLayout();
            this.panel_autologin.SuspendLayout();
            this.groupBox_delay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_delay)).BeginInit();
            this.panel_mainmenu.SuspendLayout();
            this.groupBox_server.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_tr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_de)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ru)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_cz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_it)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_es)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_pl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_en)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_fr)).BeginInit();
            this.panel_topbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox_username
            // 
            this.groupBox_username.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox_username.Controls.Add(this.textBox_username);
            this.groupBox_username.ForeColor = System.Drawing.Color.DimGray;
            this.groupBox_username.Location = new System.Drawing.Point(56, 75);
            this.groupBox_username.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_username.Name = "groupBox_username";
            this.groupBox_username.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_username.Size = new System.Drawing.Size(146, 47);
            this.groupBox_username.TabIndex = 1;
            this.groupBox_username.TabStop = false;
            this.groupBox_username.Text = "{USERNAME}";
            // 
            // textBox_username
            // 
            this.textBox_username.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_username.ForeColor = System.Drawing.Color.Black;
            this.textBox_username.Location = new System.Drawing.Point(6, 19);
            this.textBox_username.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_username.Name = "textBox_username";
            this.textBox_username.Size = new System.Drawing.Size(134, 22);
            this.textBox_username.TabIndex = 0;
            this.textBox_username.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_username_KeyDown);
            // 
            // groupBox_password
            // 
            this.groupBox_password.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox_password.Controls.Add(this.textBox_password);
            this.groupBox_password.ForeColor = System.Drawing.Color.DimGray;
            this.groupBox_password.Location = new System.Drawing.Point(56, 129);
            this.groupBox_password.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_password.Name = "groupBox_password";
            this.groupBox_password.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_password.Size = new System.Drawing.Size(146, 47);
            this.groupBox_password.TabIndex = 2;
            this.groupBox_password.TabStop = false;
            this.groupBox_password.Text = "{PASSWORD}";
            // 
            // textBox_password
            // 
            this.textBox_password.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_password.ForeColor = System.Drawing.Color.Black;
            this.textBox_password.Location = new System.Drawing.Point(6, 19);
            this.textBox_password.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.PasswordChar = '*';
            this.textBox_password.Size = new System.Drawing.Size(134, 22);
            this.textBox_password.TabIndex = 0;
            this.textBox_password.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_password_KeyDown);
            // 
            // button_quit
            // 
            this.button_quit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button_quit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.button_quit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_quit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_quit.ForeColor = System.Drawing.Color.Black;
            this.button_quit.Location = new System.Drawing.Point(41, 318);
            this.button_quit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_quit.Name = "button_quit";
            this.button_quit.Size = new System.Drawing.Size(93, 37);
            this.button_quit.TabIndex = 2;
            this.button_quit.Text = "{QUIT}";
            this.button_quit.UseVisualStyleBackColor = false;
            this.button_quit.Click += new System.EventHandler(this.button_quit_Click);
            // 
            // panel_mainframe
            // 
            this.panel_mainframe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_mainframe.Controls.Add(this.panel_autologin);
            this.panel_mainframe.Controls.Add(this.panel_settings);
            this.panel_mainframe.Controls.Add(this.panel_mainmenu);
            this.panel_mainframe.Controls.Add(this.panel_topbar);
            this.panel_mainframe.Controls.Add(this.pictureBox7);
            this.panel_mainframe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_mainframe.Location = new System.Drawing.Point(0, 0);
            this.panel_mainframe.Name = "panel_mainframe";
            this.panel_mainframe.Size = new System.Drawing.Size(698, 535);
            this.panel_mainframe.TabIndex = 4;
            // 
            // panel_autologin
            // 
            this.panel_autologin.Controls.Add(this.button_autologin_back);
            this.panel_autologin.Controls.Add(this.button_autologin_save);
            this.panel_autologin.Controls.Add(this.label_autologininfo_encrypted);
            this.panel_autologin.Controls.Add(this.label_autologininfo);
            this.panel_autologin.Controls.Add(this.groupBox_username);
            this.panel_autologin.Controls.Add(this.groupBox_delay);
            this.panel_autologin.Controls.Add(this.groupBox_password);
            this.panel_autologin.Location = new System.Drawing.Point(435, 166);
            this.panel_autologin.Name = "panel_autologin";
            this.panel_autologin.Size = new System.Drawing.Size(258, 363);
            this.panel_autologin.TabIndex = 6;
            // 
            // button_autologin_back
            // 
            this.button_autologin_back.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button_autologin_back.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.button_autologin_back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_autologin_back.Location = new System.Drawing.Point(83, 325);
            this.button_autologin_back.Name = "button_autologin_back";
            this.button_autologin_back.Size = new System.Drawing.Size(93, 30);
            this.button_autologin_back.TabIndex = 6;
            this.button_autologin_back.Text = "{BACK}";
            this.button_autologin_back.UseVisualStyleBackColor = false;
            this.button_autologin_back.Click += new System.EventHandler(this.button_autologin_back_Click);
            // 
            // button_autologin_save
            // 
            this.button_autologin_save.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button_autologin_save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.button_autologin_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_autologin_save.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_autologin_save.Location = new System.Drawing.Point(83, 274);
            this.button_autologin_save.Name = "button_autologin_save";
            this.button_autologin_save.Size = new System.Drawing.Size(93, 38);
            this.button_autologin_save.TabIndex = 5;
            this.button_autologin_save.Text = "{SAVE}";
            this.button_autologin_save.UseVisualStyleBackColor = false;
            this.button_autologin_save.Click += new System.EventHandler(this.button_autologin_save_Click);
            // 
            // label_autologininfo_encrypted
            // 
            this.label_autologininfo_encrypted.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_autologininfo_encrypted.Font = new System.Drawing.Font("Calibri Light", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_autologininfo_encrypted.Location = new System.Drawing.Point(23, 181);
            this.label_autologininfo_encrypted.Name = "label_autologininfo_encrypted";
            this.label_autologininfo_encrypted.Size = new System.Drawing.Size(211, 20);
            this.label_autologininfo_encrypted.TabIndex = 4;
            this.label_autologininfo_encrypted.Text = "{AUTOLOGINENCRYPTED}";
            this.label_autologininfo_encrypted.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_autologininfo
            // 
            this.label_autologininfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_autologininfo.Location = new System.Drawing.Point(50, 8);
            this.label_autologininfo.Name = "label_autologininfo";
            this.label_autologininfo.Size = new System.Drawing.Size(157, 56);
            this.label_autologininfo.TabIndex = 3;
            this.label_autologininfo.Text = "{AUTOLOGININFO}";
            this.label_autologininfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox_delay
            // 
            this.groupBox_delay.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox_delay.Controls.Add(this.numericUpDown_delay);
            this.groupBox_delay.ForeColor = System.Drawing.Color.DimGray;
            this.groupBox_delay.Location = new System.Drawing.Point(56, 208);
            this.groupBox_delay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_delay.Name = "groupBox_delay";
            this.groupBox_delay.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_delay.Size = new System.Drawing.Size(146, 47);
            this.groupBox_delay.TabIndex = 3;
            this.groupBox_delay.TabStop = false;
            this.groupBox_delay.Text = "{DELAY}";
            // 
            // numericUpDown_delay
            // 
            this.numericUpDown_delay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown_delay.Increment = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.numericUpDown_delay.Location = new System.Drawing.Point(6, 19);
            this.numericUpDown_delay.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown_delay.Minimum = new decimal(new int[] {
            750,
            0,
            0,
            0});
            this.numericUpDown_delay.Name = "numericUpDown_delay";
            this.numericUpDown_delay.Size = new System.Drawing.Size(134, 22);
            this.numericUpDown_delay.TabIndex = 1;
            this.numericUpDown_delay.Value = new decimal(new int[] {
            1250,
            0,
            0,
            0});
            // 
            // panel_settings
            // 
            this.panel_settings.Location = new System.Drawing.Point(180, 161);
            this.panel_settings.Name = "panel_settings";
            this.panel_settings.Size = new System.Drawing.Size(213, 360);
            this.panel_settings.TabIndex = 7;
            // 
            // panel_mainmenu
            // 
            this.panel_mainmenu.Controls.Add(this.linkLabel_settings);
            this.panel_mainmenu.Controls.Add(this.linkLabel_changeautologin);
            this.panel_mainmenu.Controls.Add(this.groupBox_server);
            this.panel_mainmenu.Controls.Add(this.panel_langselect);
            this.panel_mainmenu.Controls.Add(this.label_loginas);
            this.panel_mainmenu.Controls.Add(this.pictureBox_tr);
            this.panel_mainmenu.Controls.Add(this.pictureBox_de);
            this.panel_mainmenu.Controls.Add(this.button_quit);
            this.panel_mainmenu.Controls.Add(this.pictureBox_ru);
            this.panel_mainmenu.Controls.Add(this.pictureBox_cz);
            this.panel_mainmenu.Controls.Add(this.pictureBox_it);
            this.panel_mainmenu.Controls.Add(this.pictureBox_es);
            this.panel_mainmenu.Controls.Add(this.button_gamestart);
            this.panel_mainmenu.Controls.Add(this.pictureBox_pl);
            this.panel_mainmenu.Controls.Add(this.pictureBox_en);
            this.panel_mainmenu.Controls.Add(this.pictureBox_fr);
            this.panel_mainmenu.Location = new System.Drawing.Point(0, 166);
            this.panel_mainmenu.Name = "panel_mainmenu";
            this.panel_mainmenu.Size = new System.Drawing.Size(174, 363);
            this.panel_mainmenu.TabIndex = 1;
            // 
            // linkLabel_settings
            // 
            this.linkLabel_settings.ActiveLinkColor = System.Drawing.Color.Red;
            this.linkLabel_settings.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.linkLabel_settings.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.linkLabel_settings.Location = new System.Drawing.Point(-7, 188);
            this.linkLabel_settings.Name = "linkLabel_settings";
            this.linkLabel_settings.Size = new System.Drawing.Size(189, 19);
            this.linkLabel_settings.TabIndex = 6;
            this.linkLabel_settings.TabStop = true;
            this.linkLabel_settings.Text = "{SETTINGS}";
            this.linkLabel_settings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLabel_settings.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.linkLabel_settings.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_settings_LinkClicked);
            // 
            // linkLabel_changeautologin
            // 
            this.linkLabel_changeautologin.ActiveLinkColor = System.Drawing.Color.Red;
            this.linkLabel_changeautologin.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.linkLabel_changeautologin.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.linkLabel_changeautologin.Location = new System.Drawing.Point(-12, 147);
            this.linkLabel_changeautologin.Name = "linkLabel_changeautologin";
            this.linkLabel_changeautologin.Size = new System.Drawing.Size(198, 19);
            this.linkLabel_changeautologin.TabIndex = 6;
            this.linkLabel_changeautologin.TabStop = true;
            this.linkLabel_changeautologin.Text = "{CHANGEAUTOLOGIN}";
            this.linkLabel_changeautologin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLabel_changeautologin.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.linkLabel_changeautologin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_changeautologin_LinkClicked);
            // 
            // groupBox_server
            // 
            this.groupBox_server.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox_server.Controls.Add(this.textBox_server);
            this.groupBox_server.ForeColor = System.Drawing.Color.DimGray;
            this.groupBox_server.Location = new System.Drawing.Point(14, 63);
            this.groupBox_server.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_server.Name = "groupBox_server";
            this.groupBox_server.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_server.Size = new System.Drawing.Size(146, 47);
            this.groupBox_server.TabIndex = 1;
            this.groupBox_server.TabStop = false;
            this.groupBox_server.Text = "{SERVER}";
            // 
            // textBox_server
            // 
            this.textBox_server.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_server.ForeColor = System.Drawing.Color.Black;
            this.textBox_server.Location = new System.Drawing.Point(6, 19);
            this.textBox_server.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_server.Name = "textBox_server";
            this.textBox_server.Size = new System.Drawing.Size(134, 22);
            this.textBox_server.TabIndex = 0;
            this.textBox_server.Text = "localhost";
            this.textBox_server.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_username_KeyDown);
            // 
            // panel_langselect
            // 
            this.panel_langselect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.panel_langselect.Location = new System.Drawing.Point(198, 5);
            this.panel_langselect.Name = "panel_langselect";
            this.panel_langselect.Size = new System.Drawing.Size(37, 5);
            this.panel_langselect.TabIndex = 5;
            // 
            // label_loginas
            // 
            this.label_loginas.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label_loginas.Location = new System.Drawing.Point(-23, 125);
            this.label_loginas.Name = "label_loginas";
            this.label_loginas.Size = new System.Drawing.Size(218, 22);
            this.label_loginas.TabIndex = 1;
            this.label_loginas.Text = "{LOGINAS}: {0}";
            this.label_loginas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox_tr
            // 
            this.pictureBox_tr.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox_tr.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_tr.Image = global::OpenNosClientLauncher.Properties.Resources.TR;
            this.pictureBox_tr.Location = new System.Drawing.Point(238, 10);
            this.pictureBox_tr.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox_tr.Name = "pictureBox_tr";
            this.pictureBox_tr.Size = new System.Drawing.Size(43, 36);
            this.pictureBox_tr.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_tr.TabIndex = 4;
            this.pictureBox_tr.TabStop = false;
            this.pictureBox_tr.Click += new System.EventHandler(this.LangChange);
            // 
            // pictureBox_de
            // 
            this.pictureBox_de.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox_de.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_de.Image = global::OpenNosClientLauncher.Properties.Resources.DE;
            this.pictureBox_de.Location = new System.Drawing.Point(-63, 10);
            this.pictureBox_de.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox_de.Name = "pictureBox_de";
            this.pictureBox_de.Size = new System.Drawing.Size(43, 36);
            this.pictureBox_de.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_de.TabIndex = 3;
            this.pictureBox_de.TabStop = false;
            this.pictureBox_de.Click += new System.EventHandler(this.LangChange);
            // 
            // pictureBox_ru
            // 
            this.pictureBox_ru.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox_ru.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_ru.Image = global::OpenNosClientLauncher.Properties.Resources.RU;
            this.pictureBox_ru.Location = new System.Drawing.Point(195, 10);
            this.pictureBox_ru.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox_ru.Name = "pictureBox_ru";
            this.pictureBox_ru.Size = new System.Drawing.Size(43, 36);
            this.pictureBox_ru.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_ru.TabIndex = 4;
            this.pictureBox_ru.TabStop = false;
            this.pictureBox_ru.Click += new System.EventHandler(this.LangChange);
            // 
            // pictureBox_cz
            // 
            this.pictureBox_cz.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox_cz.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_cz.Image = global::OpenNosClientLauncher.Properties.Resources.CZ;
            this.pictureBox_cz.Location = new System.Drawing.Point(152, 10);
            this.pictureBox_cz.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox_cz.Name = "pictureBox_cz";
            this.pictureBox_cz.Size = new System.Drawing.Size(43, 36);
            this.pictureBox_cz.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_cz.TabIndex = 4;
            this.pictureBox_cz.TabStop = false;
            this.pictureBox_cz.Click += new System.EventHandler(this.LangChange);
            // 
            // pictureBox_it
            // 
            this.pictureBox_it.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox_it.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_it.Image = global::OpenNosClientLauncher.Properties.Resources.IT;
            this.pictureBox_it.Location = new System.Drawing.Point(23, 10);
            this.pictureBox_it.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox_it.Name = "pictureBox_it";
            this.pictureBox_it.Size = new System.Drawing.Size(43, 36);
            this.pictureBox_it.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_it.TabIndex = 4;
            this.pictureBox_it.TabStop = false;
            this.pictureBox_it.Click += new System.EventHandler(this.LangChange);
            // 
            // pictureBox_es
            // 
            this.pictureBox_es.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox_es.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_es.Image = global::OpenNosClientLauncher.Properties.Resources.ES;
            this.pictureBox_es.Location = new System.Drawing.Point(109, 10);
            this.pictureBox_es.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox_es.Name = "pictureBox_es";
            this.pictureBox_es.Size = new System.Drawing.Size(43, 36);
            this.pictureBox_es.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_es.TabIndex = 4;
            this.pictureBox_es.TabStop = false;
            this.pictureBox_es.Click += new System.EventHandler(this.LangChange);
            // 
            // button_gamestart
            // 
            this.button_gamestart.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button_gamestart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.button_gamestart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_gamestart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_gamestart.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_gamestart.Location = new System.Drawing.Point(41, 256);
            this.button_gamestart.Name = "button_gamestart";
            this.button_gamestart.Size = new System.Drawing.Size(93, 46);
            this.button_gamestart.TabIndex = 0;
            this.button_gamestart.Text = "{STARTGAME}";
            this.button_gamestart.UseVisualStyleBackColor = false;
            this.button_gamestart.Click += new System.EventHandler(this.button_gamestart_Click);
            // 
            // pictureBox_pl
            // 
            this.pictureBox_pl.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox_pl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_pl.Image = global::OpenNosClientLauncher.Properties.Resources.PL;
            this.pictureBox_pl.Location = new System.Drawing.Point(66, 10);
            this.pictureBox_pl.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox_pl.Name = "pictureBox_pl";
            this.pictureBox_pl.Size = new System.Drawing.Size(43, 36);
            this.pictureBox_pl.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_pl.TabIndex = 4;
            this.pictureBox_pl.TabStop = false;
            this.pictureBox_pl.Click += new System.EventHandler(this.LangChange);
            // 
            // pictureBox_en
            // 
            this.pictureBox_en.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox_en.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_en.Image = global::OpenNosClientLauncher.Properties.Resources.GB;
            this.pictureBox_en.Location = new System.Drawing.Point(-106, 10);
            this.pictureBox_en.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox_en.Name = "pictureBox_en";
            this.pictureBox_en.Size = new System.Drawing.Size(43, 36);
            this.pictureBox_en.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_en.TabIndex = 4;
            this.pictureBox_en.TabStop = false;
            this.pictureBox_en.Click += new System.EventHandler(this.LangChange);
            // 
            // pictureBox_fr
            // 
            this.pictureBox_fr.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox_fr.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_fr.Image = global::OpenNosClientLauncher.Properties.Resources.FR;
            this.pictureBox_fr.Location = new System.Drawing.Point(-20, 10);
            this.pictureBox_fr.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox_fr.Name = "pictureBox_fr";
            this.pictureBox_fr.Size = new System.Drawing.Size(43, 36);
            this.pictureBox_fr.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_fr.TabIndex = 4;
            this.pictureBox_fr.TabStop = false;
            this.pictureBox_fr.Click += new System.EventHandler(this.LangChange);
            // 
            // panel_topbar
            // 
            this.panel_topbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.panel_topbar.Controls.Add(this.label1);
            this.panel_topbar.Controls.Add(this.label_xmenu_x);
            this.panel_topbar.Controls.Add(this.pictureBox_logo);
            this.panel_topbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_topbar.Location = new System.Drawing.Point(0, 0);
            this.panel_topbar.Name = "panel_topbar";
            this.panel_topbar.Size = new System.Drawing.Size(696, 160);
            this.panel_topbar.TabIndex = 5;
            this.panel_topbar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MovementlogopbMDown);
            this.panel_topbar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MovementlogopbMMove);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(643, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "_";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label_xmenu_x
            // 
            this.label_xmenu_x.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_xmenu_x.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_xmenu_x.ForeColor = System.Drawing.Color.White;
            this.label_xmenu_x.Location = new System.Drawing.Point(670, 0);
            this.label_xmenu_x.Name = "label_xmenu_x";
            this.label_xmenu_x.Size = new System.Drawing.Size(25, 20);
            this.label_xmenu_x.TabIndex = 1;
            this.label_xmenu_x.Text = "X";
            this.label_xmenu_x.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_xmenu_x.Click += new System.EventHandler(this.label_xmenu_x_Click);
            // 
            // pictureBox_logo
            // 
            this.pictureBox_logo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.pictureBox_logo.Image = global::OpenNosClientLauncher.Properties.Resources.on_logo_128;
            this.pictureBox_logo.Location = new System.Drawing.Point(268, 2);
            this.pictureBox_logo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox_logo.Name = "pictureBox_logo";
            this.pictureBox_logo.Size = new System.Drawing.Size(161, 153);
            this.pictureBox_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox_logo.TabIndex = 0;
            this.pictureBox_logo.TabStop = false;
            this.pictureBox_logo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MovementlogopbMDown);
            this.pictureBox_logo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MovementlogopbMMove);
            // 
            // pictureBox7
            // 
            this.pictureBox7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox7.Image = global::OpenNosClientLauncher.Properties.Resources.GB;
            this.pictureBox7.Location = new System.Drawing.Point(573, -89);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(36, 20);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox7.TabIndex = 4;
            this.pictureBox7.TabStop = false;
            this.pictureBox7.Click += new System.EventHandler(this.LangChange);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(698, 535);
            this.Controls.Add(this.panel_mainframe);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(435, 535);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "nosyx Launcher";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.groupBox_username.ResumeLayout(false);
            this.groupBox_username.PerformLayout();
            this.groupBox_password.ResumeLayout(false);
            this.groupBox_password.PerformLayout();
            this.panel_mainframe.ResumeLayout(false);
            this.panel_autologin.ResumeLayout(false);
            this.groupBox_delay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_delay)).EndInit();
            this.panel_mainmenu.ResumeLayout(false);
            this.groupBox_server.ResumeLayout(false);
            this.groupBox_server.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_tr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_de)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ru)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_cz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_it)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_es)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_pl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_en)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_fr)).EndInit();
            this.panel_topbar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_logo;
        private System.Windows.Forms.GroupBox groupBox_username;
        private System.Windows.Forms.TextBox textBox_username;
        private System.Windows.Forms.GroupBox groupBox_password;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.Button button_quit;
        private System.Windows.Forms.Panel panel_mainframe;
        private System.Windows.Forms.Button button_gamestart;
        private System.Windows.Forms.Label label_loginas;
        private System.Windows.Forms.Panel panel_mainmenu;
        private System.Windows.Forms.PictureBox pictureBox_fr;
        private System.Windows.Forms.PictureBox pictureBox_de;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox_tr;
        private System.Windows.Forms.PictureBox pictureBox_en;
        private System.Windows.Forms.PictureBox pictureBox_cz;
        private System.Windows.Forms.PictureBox pictureBox_pl;
        private System.Windows.Forms.PictureBox pictureBox_ru;
        private System.Windows.Forms.PictureBox pictureBox_es;
        private System.Windows.Forms.PictureBox pictureBox_it;
        private System.Windows.Forms.Panel panel_topbar;
        private System.Windows.Forms.Panel panel_langselect;
        private System.Windows.Forms.GroupBox groupBox_server;
        private System.Windows.Forms.TextBox textBox_server;
        private System.Windows.Forms.Panel panel_autologin;
        private System.Windows.Forms.Button button_autologin_save;
        private System.Windows.Forms.Label label_autologininfo_encrypted;
        private System.Windows.Forms.Label label_autologininfo;
        private System.Windows.Forms.Button button_autologin_back;
        private System.Windows.Forms.LinkLabel linkLabel_changeautologin;
        private System.Windows.Forms.LinkLabel linkLabel_settings;
        private System.Windows.Forms.Panel panel_settings;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_xmenu_x;
        private System.Windows.Forms.GroupBox groupBox_delay;
        private System.Windows.Forms.NumericUpDown numericUpDown_delay;
    }
}

