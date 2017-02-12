namespace WindowsFormsApplication1
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbLoadImage = new System.Windows.Forms.GroupBox();
            this.pbResult = new System.Windows.Forms.PictureBox();
            this.pbLoad = new System.Windows.Forms.PictureBox();
            this.gbRGB = new System.Windows.Forms.GroupBox();
            this.pbRGB_B = new System.Windows.Forms.PictureBox();
            this.pbRGB_G = new System.Windows.Forms.PictureBox();
            this.pbRGB_R = new System.Windows.Forms.PictureBox();
            this.gbYCbCr = new System.Windows.Forms.GroupBox();
            this.pbYCbCr_3 = new System.Windows.Forms.PictureBox();
            this.pbYCbCr_2 = new System.Windows.Forms.PictureBox();
            this.pbYCbCr_1 = new System.Windows.Forms.PictureBox();
            this.gbWavelet = new System.Windows.Forms.GroupBox();
            this.pbWavelet_3 = new System.Windows.Forms.PictureBox();
            this.pbWavelet_2 = new System.Windows.Forms.PictureBox();
            this.pbWavelet_1 = new System.Windows.Forms.PictureBox();
            this.buttonLoadImage = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonRGBconv = new System.Windows.Forms.Button();
            this.buttonRGBrecov = new System.Windows.Forms.Button();
            this.buttonYCbCr_conv = new System.Windows.Forms.Button();
            this.buttonYCbCr_recov = new System.Windows.Forms.Button();
            this.buttonWaveletCompress = new System.Windows.Forms.Button();
            this.buttonWaveletDecompress = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbImagePath = new System.Windows.Forms.TextBox();
            this.gbLoadImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoad)).BeginInit();
            this.gbRGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbRGB_B)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRGB_G)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRGB_R)).BeginInit();
            this.gbYCbCr.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbYCbCr_3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbYCbCr_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbYCbCr_1)).BeginInit();
            this.gbWavelet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbWavelet_3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWavelet_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWavelet_1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbLoadImage
            // 
            this.gbLoadImage.Controls.Add(this.pbResult);
            this.gbLoadImage.Controls.Add(this.pbLoad);
            this.gbLoadImage.Location = new System.Drawing.Point(12, 12);
            this.gbLoadImage.Name = "gbLoadImage";
            this.gbLoadImage.Size = new System.Drawing.Size(162, 344);
            this.gbLoadImage.TabIndex = 0;
            this.gbLoadImage.TabStop = false;
            this.gbLoadImage.Text = "Исх/Восст. изображение";
            // 
            // pbResult
            // 
            this.pbResult.Location = new System.Drawing.Point(6, 175);
            this.pbResult.Name = "pbResult";
            this.pbResult.Size = new System.Drawing.Size(150, 150);
            this.pbResult.TabIndex = 1;
            this.pbResult.TabStop = false;
            // 
            // pbLoad
            // 
            this.pbLoad.Location = new System.Drawing.Point(6, 19);
            this.pbLoad.Name = "pbLoad";
            this.pbLoad.Size = new System.Drawing.Size(150, 150);
            this.pbLoad.TabIndex = 0;
            this.pbLoad.TabStop = false;
            // 
            // gbRGB
            // 
            this.gbRGB.Controls.Add(this.pbRGB_B);
            this.gbRGB.Controls.Add(this.pbRGB_G);
            this.gbRGB.Controls.Add(this.pbRGB_R);
            this.gbRGB.Location = new System.Drawing.Point(218, 12);
            this.gbRGB.Name = "gbRGB";
            this.gbRGB.Size = new System.Drawing.Size(165, 500);
            this.gbRGB.TabIndex = 1;
            this.gbRGB.TabStop = false;
            this.gbRGB.Text = "Разложение RGB";
            // 
            // pbRGB_B
            // 
            this.pbRGB_B.Location = new System.Drawing.Point(6, 331);
            this.pbRGB_B.Name = "pbRGB_B";
            this.pbRGB_B.Size = new System.Drawing.Size(150, 150);
            this.pbRGB_B.TabIndex = 3;
            this.pbRGB_B.TabStop = false;
            // 
            // pbRGB_G
            // 
            this.pbRGB_G.Location = new System.Drawing.Point(6, 175);
            this.pbRGB_G.Name = "pbRGB_G";
            this.pbRGB_G.Size = new System.Drawing.Size(150, 150);
            this.pbRGB_G.TabIndex = 2;
            this.pbRGB_G.TabStop = false;
            // 
            // pbRGB_R
            // 
            this.pbRGB_R.Location = new System.Drawing.Point(6, 19);
            this.pbRGB_R.Name = "pbRGB_R";
            this.pbRGB_R.Size = new System.Drawing.Size(150, 150);
            this.pbRGB_R.TabIndex = 1;
            this.pbRGB_R.TabStop = false;
            // 
            // gbYCbCr
            // 
            this.gbYCbCr.Controls.Add(this.pbYCbCr_3);
            this.gbYCbCr.Controls.Add(this.pbYCbCr_2);
            this.gbYCbCr.Controls.Add(this.pbYCbCr_1);
            this.gbYCbCr.Location = new System.Drawing.Point(389, 12);
            this.gbYCbCr.Name = "gbYCbCr";
            this.gbYCbCr.Size = new System.Drawing.Size(163, 500);
            this.gbYCbCr.TabIndex = 2;
            this.gbYCbCr.TabStop = false;
            this.gbYCbCr.Text = "Разложение YCbCr";
            // 
            // pbYCbCr_3
            // 
            this.pbYCbCr_3.Location = new System.Drawing.Point(6, 331);
            this.pbYCbCr_3.Name = "pbYCbCr_3";
            this.pbYCbCr_3.Size = new System.Drawing.Size(150, 150);
            this.pbYCbCr_3.TabIndex = 3;
            this.pbYCbCr_3.TabStop = false;
            // 
            // pbYCbCr_2
            // 
            this.pbYCbCr_2.Location = new System.Drawing.Point(6, 175);
            this.pbYCbCr_2.Name = "pbYCbCr_2";
            this.pbYCbCr_2.Size = new System.Drawing.Size(150, 150);
            this.pbYCbCr_2.TabIndex = 2;
            this.pbYCbCr_2.TabStop = false;
            // 
            // pbYCbCr_1
            // 
            this.pbYCbCr_1.Location = new System.Drawing.Point(6, 19);
            this.pbYCbCr_1.Name = "pbYCbCr_1";
            this.pbYCbCr_1.Size = new System.Drawing.Size(150, 150);
            this.pbYCbCr_1.TabIndex = 1;
            this.pbYCbCr_1.TabStop = false;
            // 
            // gbWavelet
            // 
            this.gbWavelet.Controls.Add(this.pbWavelet_3);
            this.gbWavelet.Controls.Add(this.pbWavelet_2);
            this.gbWavelet.Controls.Add(this.pbWavelet_1);
            this.gbWavelet.Location = new System.Drawing.Point(558, 12);
            this.gbWavelet.Name = "gbWavelet";
            this.gbWavelet.Size = new System.Drawing.Size(164, 500);
            this.gbWavelet.TabIndex = 3;
            this.gbWavelet.TabStop = false;
            this.gbWavelet.Text = "Вейвлет преобразование";
            // 
            // pbWavelet_3
            // 
            this.pbWavelet_3.Location = new System.Drawing.Point(6, 331);
            this.pbWavelet_3.Name = "pbWavelet_3";
            this.pbWavelet_3.Size = new System.Drawing.Size(150, 150);
            this.pbWavelet_3.TabIndex = 3;
            this.pbWavelet_3.TabStop = false;
            // 
            // pbWavelet_2
            // 
            this.pbWavelet_2.Location = new System.Drawing.Point(6, 175);
            this.pbWavelet_2.Name = "pbWavelet_2";
            this.pbWavelet_2.Size = new System.Drawing.Size(150, 150);
            this.pbWavelet_2.TabIndex = 2;
            this.pbWavelet_2.TabStop = false;
            // 
            // pbWavelet_1
            // 
            this.pbWavelet_1.Location = new System.Drawing.Point(6, 19);
            this.pbWavelet_1.Name = "pbWavelet_1";
            this.pbWavelet_1.Size = new System.Drawing.Size(150, 150);
            this.pbWavelet_1.TabIndex = 1;
            this.pbWavelet_1.TabStop = false;
            // 
            // buttonLoadImage
            // 
            this.buttonLoadImage.Location = new System.Drawing.Point(18, 362);
            this.buttonLoadImage.Name = "buttonLoadImage";
            this.buttonLoadImage.Size = new System.Drawing.Size(150, 30);
            this.buttonLoadImage.TabIndex = 4;
            this.buttonLoadImage.Text = "Загрузить изображение\r\n";
            this.buttonLoadImage.UseVisualStyleBackColor = true;
            this.buttonLoadImage.Click += new System.EventHandler(this.buttonLoadImage_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(12, 518);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(162, 52);
            this.buttonExit.TabIndex = 5;
            this.buttonExit.Text = "Выход";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonRGBconv
            // 
            this.buttonRGBconv.Location = new System.Drawing.Point(218, 518);
            this.buttonRGBconv.Name = "buttonRGBconv";
            this.buttonRGBconv.Size = new System.Drawing.Size(165, 23);
            this.buttonRGBconv.TabIndex = 6;
            this.buttonRGBconv.Text = ">>> Конвертировать в RGB";
            this.buttonRGBconv.UseVisualStyleBackColor = true;
            this.buttonRGBconv.Click += new System.EventHandler(this.buttonRGBconv_Click);
            // 
            // buttonRGBrecov
            // 
            this.buttonRGBrecov.Location = new System.Drawing.Point(218, 547);
            this.buttonRGBrecov.Name = "buttonRGBrecov";
            this.buttonRGBrecov.Size = new System.Drawing.Size(165, 23);
            this.buttonRGBrecov.TabIndex = 7;
            this.buttonRGBrecov.Text = "<<< Восстановить из RGB";
            this.buttonRGBrecov.UseVisualStyleBackColor = true;
            this.buttonRGBrecov.Click += new System.EventHandler(this.buttonRGBrecov_Click);
            // 
            // buttonYCbCr_conv
            // 
            this.buttonYCbCr_conv.Location = new System.Drawing.Point(388, 518);
            this.buttonYCbCr_conv.Name = "buttonYCbCr_conv";
            this.buttonYCbCr_conv.Size = new System.Drawing.Size(164, 23);
            this.buttonYCbCr_conv.TabIndex = 8;
            this.buttonYCbCr_conv.Text = ">>> Конвертировать в YCbCr";
            this.buttonYCbCr_conv.UseVisualStyleBackColor = true;
            this.buttonYCbCr_conv.Click += new System.EventHandler(this.buttonYCbCr_conv_Click);
            // 
            // buttonYCbCr_recov
            // 
            this.buttonYCbCr_recov.Location = new System.Drawing.Point(389, 547);
            this.buttonYCbCr_recov.Name = "buttonYCbCr_recov";
            this.buttonYCbCr_recov.Size = new System.Drawing.Size(163, 23);
            this.buttonYCbCr_recov.TabIndex = 9;
            this.buttonYCbCr_recov.Text = "<<< Восстановить из YCbCr";
            this.buttonYCbCr_recov.UseVisualStyleBackColor = true;
            this.buttonYCbCr_recov.Click += new System.EventHandler(this.buttonYCbCr_recov_Click);
            // 
            // buttonWaveletCompress
            // 
            this.buttonWaveletCompress.Location = new System.Drawing.Point(558, 518);
            this.buttonWaveletCompress.Name = "buttonWaveletCompress";
            this.buttonWaveletCompress.Size = new System.Drawing.Size(164, 23);
            this.buttonWaveletCompress.TabIndex = 10;
            this.buttonWaveletCompress.Text = ">>> Сжатие";
            this.buttonWaveletCompress.UseVisualStyleBackColor = true;
            this.buttonWaveletCompress.Click += new System.EventHandler(this.buttonWaveletCompress_Click);
            // 
            // buttonWaveletDecompress
            // 
            this.buttonWaveletDecompress.Location = new System.Drawing.Point(558, 547);
            this.buttonWaveletDecompress.Name = "buttonWaveletDecompress";
            this.buttonWaveletDecompress.Size = new System.Drawing.Size(164, 23);
            this.buttonWaveletDecompress.TabIndex = 11;
            this.buttonWaveletDecompress.Text = "<<< Декомпрессия";
            this.buttonWaveletDecompress.UseVisualStyleBackColor = true;
            this.buttonWaveletDecompress.Click += new System.EventHandler(this.buttonWaveletDecompress_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 609);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(734, 22);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ProgressBar1
            // 
            this.ProgressBar1.Name = "ProgressBar1";
            this.ProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 421);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Сжато раз:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(18, 437);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(150, 21);
            this.textBox1.TabIndex = 14;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(180, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = ">";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(180, 263);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "<";
            // 
            // tbImagePath
            // 
            this.tbImagePath.Location = new System.Drawing.Point(18, 398);
            this.tbImagePath.Name = "tbImagePath";
            this.tbImagePath.Size = new System.Drawing.Size(150, 20);
            this.tbImagePath.TabIndex = 17;
            // 
            // MainForm
            // 
            this.AcceptButton = this.buttonLoadImage;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 631);
            this.Controls.Add(this.tbImagePath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.buttonWaveletDecompress);
            this.Controls.Add(this.buttonWaveletCompress);
            this.Controls.Add(this.buttonYCbCr_recov);
            this.Controls.Add(this.buttonYCbCr_conv);
            this.Controls.Add(this.buttonRGBrecov);
            this.Controls.Add(this.buttonRGBconv);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonLoadImage);
            this.Controls.Add(this.gbWavelet);
            this.Controls.Add(this.gbYCbCr);
            this.Controls.Add(this.gbRGB);
            this.Controls.Add(this.gbLoadImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Image Compressor ver. 0.555 by Alexander Ten";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbLoadImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoad)).EndInit();
            this.gbRGB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbRGB_B)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRGB_G)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRGB_R)).EndInit();
            this.gbYCbCr.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbYCbCr_3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbYCbCr_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbYCbCr_1)).EndInit();
            this.gbWavelet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbWavelet_3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWavelet_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWavelet_1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbLoadImage;
        private System.Windows.Forms.GroupBox gbRGB;
        private System.Windows.Forms.GroupBox gbYCbCr;
        private System.Windows.Forms.GroupBox gbWavelet;
        private System.Windows.Forms.Button buttonLoadImage;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonRGBconv;
        private System.Windows.Forms.Button buttonRGBrecov;
        private System.Windows.Forms.Button buttonYCbCr_conv;
        private System.Windows.Forms.Button buttonYCbCr_recov;
        private System.Windows.Forms.Button buttonWaveletCompress;
        private System.Windows.Forms.Button buttonWaveletDecompress;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar ProgressBar1;
        private System.Windows.Forms.PictureBox pbResult;
        private System.Windows.Forms.PictureBox pbLoad;
        private System.Windows.Forms.PictureBox pbRGB_B;
        private System.Windows.Forms.PictureBox pbRGB_G;
        private System.Windows.Forms.PictureBox pbRGB_R;
        private System.Windows.Forms.PictureBox pbYCbCr_3;
        private System.Windows.Forms.PictureBox pbYCbCr_2;
        private System.Windows.Forms.PictureBox pbYCbCr_1;
        private System.Windows.Forms.PictureBox pbWavelet_3;
        private System.Windows.Forms.PictureBox pbWavelet_2;
        private System.Windows.Forms.PictureBox pbWavelet_1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbImagePath;
    }
}

