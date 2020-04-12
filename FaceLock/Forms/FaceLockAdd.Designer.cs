namespace FaceLock
{
    partial class FaceLockAdd
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
            this.lblEgitilenAdet = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtFaceName = new System.Windows.Forms.TextBox();
            this.btnEgit = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblEgitilenAdet
            // 
            this.lblEgitilenAdet.AutoSize = true;
            this.lblEgitilenAdet.Location = new System.Drawing.Point(639, 138);
            this.lblEgitilenAdet.Name = "lblEgitilenAdet";
            this.lblEgitilenAdet.Size = new System.Drawing.Size(29, 13);
            this.lblEgitilenAdet.TabIndex = 12;
            this.lblEgitilenAdet.Text = "Adet";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(642, 165);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(146, 99);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // txtFaceName
            // 
            this.txtFaceName.Location = new System.Drawing.Point(642, 103);
            this.txtFaceName.Name = "txtFaceName";
            this.txtFaceName.Size = new System.Drawing.Size(146, 20);
            this.txtFaceName.TabIndex = 10;
            // 
            // btnEgit
            // 
            this.btnEgit.Location = new System.Drawing.Point(642, 45);
            this.btnEgit.Name = "btnEgit";
            this.btnEgit.Size = new System.Drawing.Size(146, 52);
            this.btnEgit.TabIndex = 9;
            this.btnEgit.Text = "Yüz Eğit\n(20 Adet Fotograf)";
            this.btnEgit.UseVisualStyleBackColor = true;
            this.btnEgit.Click += new System.EventHandler(this.btnEgit_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(21, 45);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(615, 361);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // FaceLockAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblEgitilenAdet);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.txtFaceName);
            this.Controls.Add(this.btnEgit);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FaceLockAdd";
            this.Text = "FaceLockAdd";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEgitilenAdet;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txtFaceName;
        private System.Windows.Forms.Button btnEgit;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}