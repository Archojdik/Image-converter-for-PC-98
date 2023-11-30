namespace ImageReductor3
{
    partial class FullImageForm
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
            fullImage = new InterpolPictureBox();
            ((System.ComponentModel.ISupportInitialize)fullImage).BeginInit();
            SuspendLayout();
            // 
            // fullImage
            // 
            fullImage.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            fullImage.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
            fullImage.Location = new Point(12, 12);
            fullImage.Name = "fullImage";
            fullImage.Size = new Size(832, 484);
            fullImage.SizeMode = PictureBoxSizeMode.Zoom;
            fullImage.TabIndex = 0;
            fullImage.TabStop = false;
            // 
            // FullImageForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(856, 508);
            Controls.Add(fullImage);
            Name = "FullImageForm";
            Text = "Image Reductor (Fullscreen Image)";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)fullImage).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private InterpolPictureBox fullImage;
    }
}