
namespace DayToDayExpences
{
    partial class Splash
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Splash));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.progress = new Bunifu.UI.WinForms.BunifuProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Precentage = new Bunifu.UI.WinForms.BunifuLabel();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(116, -23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(328, 300);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // progress
            // 
            this.progress.AllowAnimations = false;
            this.progress.Animation = 0;
            this.progress.AnimationSpeed = 220;
            this.progress.AnimationStep = 10;
            this.progress.BackColor = System.Drawing.Color.Transparent;
            this.progress.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("progress.BackgroundImage")));
            this.progress.BorderColor = System.Drawing.Color.Transparent;
            this.progress.BorderRadius = 1;
            this.progress.BorderThickness = 1;
            this.progress.Location = new System.Drawing.Point(-10, 299);
            this.progress.Maximum = 100;
            this.progress.MaximumValue = 100;
            this.progress.Minimum = 0;
            this.progress.MinimumValue = 0;
            this.progress.Name = "progress";
            this.progress.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.progress.ProgressBackColor = System.Drawing.Color.Transparent;
            this.progress.ProgressColorLeft = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(165)))), ((int)(((byte)(137)))));
            this.progress.ProgressColorRight = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.progress.Size = new System.Drawing.Size(580, 22);
            this.progress.TabIndex = 2;
            this.progress.Value = 50;
            this.progress.ValueByTransition = 50;
            this.progress.ProgressChanged += new System.EventHandler<Bunifu.UI.WinForms.BunifuProgressBar.ProgressChangedEventArgs>(this.bunifuProgressBar1_ProgressChanged);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // Precentage
            // 
            this.Precentage.AllowParentOverrides = false;
            this.Precentage.AutoEllipsis = false;
            this.Precentage.Cursor = System.Windows.Forms.Cursors.Default;
            this.Precentage.CursorType = System.Windows.Forms.Cursors.Default;
            this.Precentage.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Precentage.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Precentage.Location = new System.Drawing.Point(255, 252);
            this.Precentage.Name = "Precentage";
            this.Precentage.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Precentage.Size = new System.Drawing.Size(32, 25);
            this.Precentage.TabIndex = 3;
            this.Precentage.Text = "%%";
            this.Precentage.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.Precentage.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(2, 274);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "Loading...\r\n";
            // 
            // Splash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(120)))), ((int)(((byte)(100)))));
            this.ClientSize = new System.Drawing.Size(565, 319);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Precentage);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Splash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Splash";
            this.Load += new System.EventHandler(this.Splash_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.UI.WinForms.BunifuProgressBar progress;
        private System.Windows.Forms.Timer timer1;
        private Bunifu.UI.WinForms.BunifuLabel Precentage;
        private System.Windows.Forms.Label label2;
    }
}