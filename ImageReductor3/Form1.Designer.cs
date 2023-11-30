namespace ImageReductor3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            sourceImage = new InterpolPictureBox();
            outputImage = new InterpolPictureBox();
            splitContainer1 = new SplitContainer();
            openFileDialog1 = new OpenFileDialog();
            openImageBtn = new Button();
            sourceImageSizeTextBox = new TextBox();
            imageWidthField = new NumericUpDown();
            imageHeightField = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            graphicModeRadio = new RadioButton();
            textModeRadio = new RadioButton();
            label4 = new Label();
            label5 = new Label();
            convertImageBtn = new Button();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            resizeMethodBox = new ComboBox();
            quantizationMethodBox = new ComboBox();
            ditheringMethodBox = new ComboBox();
            keepAspectRatioCheckBox = new CheckBox();
            label9 = new Label();
            comboBox1 = new ComboBox();
            saveBtn = new Button();
            saveFileDialog1 = new SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)sourceImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)outputImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)imageWidthField).BeginInit();
            ((System.ComponentModel.ISupportInitialize)imageHeightField).BeginInit();
            SuspendLayout();
            // 
            // sourceImage
            // 
            sourceImage.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            sourceImage.BackColor = SystemColors.ControlLight;
            sourceImage.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
            sourceImage.Location = new Point(4, 2);
            sourceImage.Margin = new Padding(4, 2, 4, 2);
            sourceImage.Name = "sourceImage";
            sourceImage.Size = new Size(503, 302);
            sourceImage.SizeMode = PictureBoxSizeMode.Zoom;
            sourceImage.TabIndex = 0;
            sourceImage.TabStop = false;
            sourceImage.Click += sourceImage_Click;
            // 
            // outputImage
            // 
            outputImage.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            outputImage.BackColor = SystemColors.ControlLight;
            outputImage.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            outputImage.Location = new Point(4, 4);
            outputImage.Margin = new Padding(4, 2, 4, 2);
            outputImage.Name = "outputImage";
            outputImage.Size = new Size(503, 308);
            outputImage.SizeMode = PictureBoxSizeMode.Zoom;
            outputImage.TabIndex = 0;
            outputImage.TabStop = false;
            outputImage.Click += outputImage_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.ImeMode = ImeMode.Off;
            splitContainer1.IsSplitterFixed = true;
            splitContainer1.Location = new Point(11, 13);
            splitContainer1.Margin = new Padding(4, 2, 4, 2);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(sourceImage);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(outputImage);
            splitContainer1.Size = new Size(511, 629);
            splitContainer1.SplitterDistance = 313;
            splitContainer1.TabIndex = 1;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // openImageBtn
            // 
            openImageBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            openImageBtn.Location = new Point(527, 13);
            openImageBtn.Margin = new Padding(4, 2, 4, 2);
            openImageBtn.Name = "openImageBtn";
            openImageBtn.Size = new Size(477, 47);
            openImageBtn.TabIndex = 2;
            openImageBtn.Text = "Открыть изображение";
            openImageBtn.UseVisualStyleBackColor = true;
            openImageBtn.Click += button1_Click;
            // 
            // sourceImageSizeTextBox
            // 
            sourceImageSizeTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sourceImageSizeTextBox.Location = new Point(771, 65);
            sourceImageSizeTextBox.Name = "sourceImageSizeTextBox";
            sourceImageSizeTextBox.ReadOnly = true;
            sourceImageSizeTextBox.Size = new Size(235, 39);
            sourceImageSizeTextBox.TabIndex = 4;
            // 
            // imageWidthField
            // 
            imageWidthField.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            imageWidthField.Location = new Point(771, 110);
            imageWidthField.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            imageWidthField.Name = "imageWidthField";
            imageWidthField.RightToLeft = RightToLeft.No;
            imageWidthField.Size = new Size(235, 39);
            imageWidthField.TabIndex = 5;
            imageWidthField.Value = new decimal(new int[] { 640, 0, 0, 0 });
            // 
            // imageHeightField
            // 
            imageHeightField.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            imageHeightField.Location = new Point(771, 155);
            imageHeightField.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            imageHeightField.Name = "imageHeightField";
            imageHeightField.Size = new Size(235, 39);
            imageHeightField.TabIndex = 6;
            imageHeightField.Value = new decimal(new int[] { 400, 0, 0, 0 });
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(529, 65);
            label1.Name = "label1";
            label1.Size = new Size(239, 32);
            label1.TabIndex = 7;
            label1.Text = "Размеры оригинала:";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(644, 110);
            label2.Name = "label2";
            label2.Size = new Size(121, 32);
            label2.TabIndex = 8;
            label2.Text = "Ширина=";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(657, 155);
            label3.Name = "label3";
            label3.Size = new Size(108, 32);
            label3.TabIndex = 9;
            label3.Text = "Высота=";
            // 
            // graphicModeRadio
            // 
            graphicModeRadio.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            graphicModeRadio.AutoSize = true;
            graphicModeRadio.Checked = true;
            graphicModeRadio.Location = new Point(724, 281);
            graphicModeRadio.Name = "graphicModeRadio";
            graphicModeRadio.Size = new Size(280, 36);
            graphicModeRadio.TabIndex = 11;
            graphicModeRadio.TabStop = true;
            graphicModeRadio.Text = "PC-98 (12bit 16colors)";
            graphicModeRadio.UseVisualStyleBackColor = true;
            // 
            // textModeRadio
            // 
            textModeRadio.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textModeRadio.AutoSize = true;
            textModeRadio.Location = new Point(634, 323);
            textModeRadio.Name = "textModeRadio";
            textModeRadio.Size = new Size(370, 36);
            textModeRadio.TabIndex = 12;
            textModeRadio.Text = "PC-98 text mode (3bit 8colors)";
            textModeRadio.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(724, 246);
            label4.Name = "label4";
            label4.Size = new Size(106, 32);
            label4.TabIndex = 13;
            label4.Text = "Палитра";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Location = new Point(655, 362);
            label5.Name = "label5";
            label5.Size = new Size(213, 32);
            label5.TabIndex = 14;
            label5.Text = "Точная настройка";
            // 
            // convertImageBtn
            // 
            convertImageBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            convertImageBtn.Location = new Point(529, 595);
            convertImageBtn.Name = "convertImageBtn";
            convertImageBtn.Size = new Size(239, 46);
            convertImageBtn.TabIndex = 15;
            convertImageBtn.Text = "Преобразовать";
            convertImageBtn.UseVisualStyleBackColor = true;
            convertImageBtn.Click += convertImageBtn_Click;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Location = new Point(527, 397);
            label6.Name = "label6";
            label6.Size = new Size(250, 32);
            label6.TabIndex = 16;
            label6.Text = "Метод деформации=";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Location = new Point(527, 443);
            label7.Name = "label7";
            label7.Size = new Size(249, 32);
            label7.TabIndex = 17;
            label7.Text = "Метод квантизации=";
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Location = new Point(527, 489);
            label8.Name = "label8";
            label8.Size = new Size(223, 32);
            label8.TabIndex = 18;
            label8.Text = "Метод дизеринга=";
            // 
            // resizeMethodBox
            // 
            resizeMethodBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            resizeMethodBox.FormattingEnabled = true;
            resizeMethodBox.Location = new Point(782, 397);
            resizeMethodBox.Name = "resizeMethodBox";
            resizeMethodBox.Size = new Size(220, 40);
            resizeMethodBox.TabIndex = 19;
            // 
            // quantizationMethodBox
            // 
            quantizationMethodBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            quantizationMethodBox.FormattingEnabled = true;
            quantizationMethodBox.Location = new Point(782, 443);
            quantizationMethodBox.Name = "quantizationMethodBox";
            quantizationMethodBox.Size = new Size(220, 40);
            quantizationMethodBox.TabIndex = 19;
            // 
            // ditheringMethodBox
            // 
            ditheringMethodBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ditheringMethodBox.FormattingEnabled = true;
            ditheringMethodBox.Location = new Point(782, 489);
            ditheringMethodBox.Name = "ditheringMethodBox";
            ditheringMethodBox.Size = new Size(220, 40);
            ditheringMethodBox.TabIndex = 19;
            // 
            // keepAspectRatioCheckBox
            // 
            keepAspectRatioCheckBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            keepAspectRatioCheckBox.AutoSize = true;
            keepAspectRatioCheckBox.Checked = true;
            keepAspectRatioCheckBox.CheckState = CheckState.Checked;
            keepAspectRatioCheckBox.Location = new Point(596, 200);
            keepAspectRatioCheckBox.Name = "keepAspectRatioCheckBox";
            keepAspectRatioCheckBox.Size = new Size(410, 36);
            keepAspectRatioCheckBox.TabIndex = 20;
            keepAspectRatioCheckBox.Text = "Соблюдать соотношение сторон";
            keepAspectRatioCheckBox.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label9.AutoSize = true;
            label9.Location = new Point(529, 535);
            label9.Name = "label9";
            label9.Size = new Size(260, 32);
            label9.TabIndex = 18;
            label9.Text = "Параметр дизеринга=";
            // 
            // comboBox1
            // 
            comboBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(782, 535);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(220, 40);
            comboBox1.TabIndex = 19;
            // 
            // saveBtn
            // 
            saveBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            saveBtn.Location = new Point(782, 595);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(224, 46);
            saveBtn.TabIndex = 21;
            saveBtn.Text = "Сохранить";
            saveBtn.UseVisualStyleBackColor = true;
            saveBtn.Click += saveBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1018, 653);
            Controls.Add(saveBtn);
            Controls.Add(keepAspectRatioCheckBox);
            Controls.Add(comboBox1);
            Controls.Add(ditheringMethodBox);
            Controls.Add(quantizationMethodBox);
            Controls.Add(resizeMethodBox);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(convertImageBtn);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(textModeRadio);
            Controls.Add(graphicModeRadio);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(imageHeightField);
            Controls.Add(imageWidthField);
            Controls.Add(sourceImageSizeTextBox);
            Controls.Add(openImageBtn);
            Controls.Add(splitContainer1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 2, 4, 2);
            Name = "Form1";
            Text = "Image Reductor";
            ((System.ComponentModel.ISupportInitialize)sourceImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)outputImage).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)imageWidthField).EndInit();
            ((System.ComponentModel.ISupportInitialize)imageHeightField).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private InterpolPictureBox sourceImage;
        private InterpolPictureBox outputImage;
        private SplitContainer splitContainer1;
        private OpenFileDialog openFileDialog1;
        private Button openImageBtn;
        private TextBox sourceImageSizeTextBox;
        private NumericUpDown imageWidthField;
        private NumericUpDown imageHeightField;
        private Label label1;
        private Label label2;
        private Label label3;
        private RadioButton graphicModeRadio;
        private RadioButton textModeRadio;
        private Label label4;
        private Label label5;
        private Button convertImageBtn;
        private Label label6;
        private Label label7;
        private Label label8;
        private ComboBox resizeMethodBox;
        private ComboBox quantizationMethodBox;
        private ComboBox ditheringMethodBox;
        private CheckBox keepAspectRatioCheckBox;
        private Label label9;
        private ComboBox comboBox1;
        private Button saveBtn;
        private SaveFileDialog saveFileDialog1;
    }
}