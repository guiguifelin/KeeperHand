namespace WindowsFormsApplication1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button_finish = new System.Windows.Forms.Button();
            this.text_updating = new System.Windows.Forms.Label();
            this.button_update = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_finish
            // 
            this.button_finish.Location = new System.Drawing.Point(188, 33);
            this.button_finish.Name = "button_finish";
            this.button_finish.Size = new System.Drawing.Size(75, 23);
            this.button_finish.TabIndex = 0;
            this.button_finish.Text = "Finish";
            this.button_finish.UseVisualStyleBackColor = true;
            this.button_finish.Click += new System.EventHandler(this.button_finish_Click);
            // 
            // text_updating
            // 
            this.text_updating.AutoSize = true;
            this.text_updating.Location = new System.Drawing.Point(12, 9);
            this.text_updating.Name = "text_updating";
            this.text_updating.Size = new System.Drawing.Size(0, 13);
            this.text_updating.TabIndex = 1;
            // 
            // button_update
            // 
            this.button_update.Location = new System.Drawing.Point(77, 33);
            this.button_update.Name = "button_update";
            this.button_update.Size = new System.Drawing.Size(75, 23);
            this.button_update.TabIndex = 2;
            this.button_update.Text = "Update";
            this.button_update.UseVisualStyleBackColor = true;
            this.button_update.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 68);
            this.Controls.Add(this.button_update);
            this.Controls.Add(this.text_updating);
            this.Controls.Add(this.button_finish);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(360, 97);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(360, 97);
            this.Name = "Form1";
            this.Text = "Keeper Hand : Update";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_finish;
        private System.Windows.Forms.Label text_updating;
        private System.Windows.Forms.Button button_update;
    }
}

