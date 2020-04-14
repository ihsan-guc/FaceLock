namespace FaceLock
{
    partial class FaceAdd
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
            this.metroStyleExtender1 = new MetroFramework.Components.MetroStyleExtender(this.components);
            this.Facepicturebox = new System.Windows.Forms.PictureBox();
            this.FaceTestBtn = new MetroFramework.Controls.MetroButton();
            this.Downloadbar = new MetroFramework.Controls.MetroProgressBar();
            this.lbltestName = new MetroFramework.Controls.MetroLabel();
            this.FaceNametxt = new MetroFramework.Controls.MetroTextBox();
            this.SmallFacepctbox = new System.Windows.Forms.PictureBox();
            this.lblkişiismi = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.Facepicturebox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SmallFacepctbox)).BeginInit();
            this.SuspendLayout();
            // 
            // Facepicturebox
            // 
            this.Facepicturebox.Location = new System.Drawing.Point(23, 63);
            this.Facepicturebox.Name = "Facepicturebox";
            this.Facepicturebox.Size = new System.Drawing.Size(567, 364);
            this.Facepicturebox.TabIndex = 0;
            this.Facepicturebox.TabStop = false;
            // 
            // FaceTestBtn
            // 
            this.FaceTestBtn.Location = new System.Drawing.Point(596, 331);
            this.FaceTestBtn.Name = "FaceTestBtn";
            this.FaceTestBtn.Size = new System.Drawing.Size(181, 44);
            this.FaceTestBtn.TabIndex = 1;
            this.FaceTestBtn.Text = "Yüz Eğit\n( 50 Adet Fotoğraf )";
            this.FaceTestBtn.UseSelectable = true;
            this.FaceTestBtn.Click += new System.EventHandler(this.FaceTestBtn_Click);
            // 
            // Downloadbar
            // 
            this.Downloadbar.Location = new System.Drawing.Point(596, 302);
            this.Downloadbar.Name = "Downloadbar";
            this.Downloadbar.Size = new System.Drawing.Size(181, 23);
            this.Downloadbar.TabIndex = 2;
            // 
            // lbltestName
            // 
            this.lbltestName.AutoSize = true;
            this.lbltestName.Location = new System.Drawing.Point(705, 280);
            this.lbltestName.Name = "lbltestName";
            this.lbltestName.Size = new System.Drawing.Size(72, 19);
            this.lbltestName.TabIndex = 3;
            this.lbltestName.Text = "Adet Sayısı";
            // 
            // FaceNametxt
            // 
            // 
            // 
            // 
            this.FaceNametxt.CustomButton.Image = null;
            this.FaceNametxt.CustomButton.Location = new System.Drawing.Point(159, 1);
            this.FaceNametxt.CustomButton.Name = "";
            this.FaceNametxt.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.FaceNametxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.FaceNametxt.CustomButton.TabIndex = 1;
            this.FaceNametxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.FaceNametxt.CustomButton.UseSelectable = true;
            this.FaceNametxt.CustomButton.Visible = false;
            this.FaceNametxt.Lines = new string[0];
            this.FaceNametxt.Location = new System.Drawing.Point(596, 238);
            this.FaceNametxt.MaxLength = 32767;
            this.FaceNametxt.Name = "FaceNametxt";
            this.FaceNametxt.PasswordChar = '\0';
            this.FaceNametxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.FaceNametxt.SelectedText = "";
            this.FaceNametxt.SelectionLength = 0;
            this.FaceNametxt.SelectionStart = 0;
            this.FaceNametxt.ShortcutsEnabled = true;
            this.FaceNametxt.Size = new System.Drawing.Size(181, 23);
            this.FaceNametxt.TabIndex = 4;
            this.FaceNametxt.UseSelectable = true;
            this.FaceNametxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.FaceNametxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // SmallFacepctbox
            // 
            this.SmallFacepctbox.Location = new System.Drawing.Point(611, 63);
            this.SmallFacepctbox.Name = "SmallFacepctbox";
            this.SmallFacepctbox.Size = new System.Drawing.Size(150, 150);
            this.SmallFacepctbox.TabIndex = 5;
            this.SmallFacepctbox.TabStop = false;
            // 
            // lblkişiismi
            // 
            this.lblkişiismi.AutoSize = true;
            this.lblkişiismi.Location = new System.Drawing.Point(705, 216);
            this.lblkişiismi.Name = "lblkişiismi";
            this.lblkişiismi.Size = new System.Drawing.Size(54, 19);
            this.lblkişiismi.TabIndex = 6;
            this.lblkişiismi.Text = "Kişi İsmi";
            // 
            // FaceAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblkişiismi);
            this.Controls.Add(this.SmallFacepctbox);
            this.Controls.Add(this.FaceNametxt);
            this.Controls.Add(this.lbltestName);
            this.Controls.Add(this.Downloadbar);
            this.Controls.Add(this.FaceTestBtn);
            this.Controls.Add(this.Facepicturebox);
            this.Name = "FaceAdd";
            this.Text = "FaceAdd";
            ((System.ComponentModel.ISupportInitialize)(this.Facepicturebox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SmallFacepctbox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Components.MetroStyleExtender metroStyleExtender1;
        private System.Windows.Forms.PictureBox Facepicturebox;
        private MetroFramework.Controls.MetroButton FaceTestBtn;
        private MetroFramework.Controls.MetroProgressBar Downloadbar;
        private MetroFramework.Controls.MetroLabel lbltestName;
        private MetroFramework.Controls.MetroTextBox FaceNametxt;
        private System.Windows.Forms.PictureBox SmallFacepctbox;
        private MetroFramework.Controls.MetroLabel lblkişiismi;
    }
}