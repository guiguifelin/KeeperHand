namespace KeeperHand_Auberge
{
    partial class Form_Tchat
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Tchat));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.serveurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connexionAutoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.richTextBox_Tchat = new System.Windows.Forms.RichTextBox();
            this.textBox_Tchat = new System.Windows.Forms.TextBox();
            this.button_send = new System.Windows.Forms.Button();
            this.textBox_IPAddress = new System.Windows.Forms.TextBox();
            this.textBox_Port = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_Server = new System.Windows.Forms.Button();
            this.button_Client = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_Username = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.richTextBox_keywords = new System.Windows.Forms.RichTextBox();
            this.button_disconnect = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serveurToolStripMenuItem,
            this.informationsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(792, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // serveurToolStripMenuItem
            // 
            this.serveurToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connexionAutoToolStripMenuItem});
            this.serveurToolStripMenuItem.Name = "serveurToolStripMenuItem";
            this.serveurToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.serveurToolStripMenuItem.Text = "Server";
            // 
            // connexionAutoToolStripMenuItem
            // 
            this.connexionAutoToolStripMenuItem.Name = "connexionAutoToolStripMenuItem";
            this.connexionAutoToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.connexionAutoToolStripMenuItem.Text = "Connexion Auto.";
            this.connexionAutoToolStripMenuItem.Click += new System.EventHandler(this.connexionAutoToolStripMenuItem_Click);
            // 
            // informationsToolStripMenuItem
            // 
            this.informationsToolStripMenuItem.Name = "informationsToolStripMenuItem";
            this.informationsToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.informationsToolStripMenuItem.Text = "Informations";
            // 
            // richTextBox_Tchat
            // 
            this.richTextBox_Tchat.Enabled = false;
            this.richTextBox_Tchat.Location = new System.Drawing.Point(13, 28);
            this.richTextBox_Tchat.Name = "richTextBox_Tchat";
            this.richTextBox_Tchat.ReadOnly = true;
            this.richTextBox_Tchat.Size = new System.Drawing.Size(531, 492);
            this.richTextBox_Tchat.TabIndex = 1;
            this.richTextBox_Tchat.Text = "";
            // 
            // textBox_Tchat
            // 
            this.textBox_Tchat.Location = new System.Drawing.Point(13, 526);
            this.textBox_Tchat.Name = "textBox_Tchat";
            this.textBox_Tchat.Size = new System.Drawing.Size(531, 20);
            this.textBox_Tchat.TabIndex = 2;
            // 
            // button_send
            // 
            this.button_send.Location = new System.Drawing.Point(550, 524);
            this.button_send.Name = "button_send";
            this.button_send.Size = new System.Drawing.Size(122, 23);
            this.button_send.TabIndex = 3;
            this.button_send.Text = "Send";
            this.button_send.UseVisualStyleBackColor = true;
            this.button_send.Click += new System.EventHandler(this.button_send_Click);
            // 
            // textBox_IPAddress
            // 
            this.textBox_IPAddress.Location = new System.Drawing.Point(550, 51);
            this.textBox_IPAddress.Name = "textBox_IPAddress";
            this.textBox_IPAddress.Size = new System.Drawing.Size(161, 20);
            this.textBox_IPAddress.TabIndex = 4;
            // 
            // textBox_Port
            // 
            this.textBox_Port.Location = new System.Drawing.Point(717, 51);
            this.textBox_Port.Name = "textBox_Port";
            this.textBox_Port.Size = new System.Drawing.Size(63, 20);
            this.textBox_Port.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(551, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Enter IP Address :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(730, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Port :";
            // 
            // button_Server
            // 
            this.button_Server.Location = new System.Drawing.Point(550, 77);
            this.button_Server.Name = "button_Server";
            this.button_Server.Size = new System.Drawing.Size(108, 23);
            this.button_Server.TabIndex = 8;
            this.button_Server.Text = "Create";
            this.button_Server.UseVisualStyleBackColor = true;
            this.button_Server.Click += new System.EventHandler(this.button_Server_Click);
            // 
            // button_Client
            // 
            this.button_Client.Location = new System.Drawing.Point(664, 77);
            this.button_Client.Name = "button_Client";
            this.button_Client.Size = new System.Drawing.Size(116, 23);
            this.button_Client.TabIndex = 9;
            this.button_Client.Text = "Join";
            this.button_Client.UseVisualStyleBackColor = true;
            this.button_Client.Click += new System.EventHandler(this.button_Client_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(550, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Server\'s keywords :";
            // 
            // textBox_Username
            // 
            this.textBox_Username.Location = new System.Drawing.Point(617, 106);
            this.textBox_Username.Name = "textBox_Username";
            this.textBox_Username.Size = new System.Drawing.Size(163, 20);
            this.textBox_Username.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(550, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Username :";
            // 
            // richTextBox_keywords
            // 
            this.richTextBox_keywords.Enabled = false;
            this.richTextBox_keywords.Location = new System.Drawing.Point(550, 167);
            this.richTextBox_keywords.Name = "richTextBox_keywords";
            this.richTextBox_keywords.ReadOnly = true;
            this.richTextBox_keywords.Size = new System.Drawing.Size(230, 351);
            this.richTextBox_keywords.TabIndex = 13;
            this.richTextBox_keywords.Text = "- \"/talk <votre texte>\" pour discuter (ou bien \"entrée\").\n- \"/time\" pour obtenir " +
    "l\'heure du serveur.";
            // 
            // button_disconnect
            // 
            this.button_disconnect.Location = new System.Drawing.Point(678, 524);
            this.button_disconnect.Name = "button_disconnect";
            this.button_disconnect.Size = new System.Drawing.Size(102, 23);
            this.button_disconnect.TabIndex = 14;
            this.button_disconnect.Text = "Disconnect";
            this.button_disconnect.UseVisualStyleBackColor = true;
            this.button_disconnect.Click += new System.EventHandler(this.button_disconnect_Click);
            // 
            // Form_Tchat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 571);
            this.Controls.Add(this.button_disconnect);
            this.Controls.Add(this.richTextBox_keywords);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_Username);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_Client);
            this.Controls.Add(this.button_Server);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_Port);
            this.Controls.Add(this.textBox_IPAddress);
            this.Controls.Add(this.button_send);
            this.Controls.Add(this.textBox_Tchat);
            this.Controls.Add(this.richTextBox_Tchat);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Form_Tchat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inn - Keeper Hand";
            this.Load += new System.EventHandler(this.Form_Tchat_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem serveurToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connexionAutoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informationsToolStripMenuItem;
        private System.Windows.Forms.RichTextBox richTextBox_Tchat;
        private System.Windows.Forms.TextBox textBox_Tchat;
        private System.Windows.Forms.Button button_send;
        private System.Windows.Forms.TextBox textBox_IPAddress;
        private System.Windows.Forms.TextBox textBox_Port;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_Server;
        private System.Windows.Forms.Button button_Client;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_Username;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox richTextBox_keywords;
        private System.Windows.Forms.Button button_disconnect;
    }
}

