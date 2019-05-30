namespace IPHW
{
    partial class Form
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this._sourcePictureBox = new System.Windows.Forms.PictureBox();
            this._outputPictureBox = new System.Windows.Forms.PictureBox();
            this._openCameraButton = new System.Windows.Forms.Button();
            this._buttonGray = new System.Windows.Forms.Button();
            this._buttonSobel = new System.Windows.Forms.Button();
            this._buttonBinarization = new System.Windows.Forms.Button();
            this._buttonInvert = new System.Windows.Forms.Button();
            this._buttonOCR = new System.Windows.Forms.Button();
            this._textboxOCR = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this._sourcePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._outputPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // _sourcePictureBox
            // 
            this._sourcePictureBox.Location = new System.Drawing.Point(40, 38);
            this._sourcePictureBox.Margin = new System.Windows.Forms.Padding(4);
            this._sourcePictureBox.Name = "_sourcePictureBox";
            this._sourcePictureBox.Size = new System.Drawing.Size(640, 400);
            this._sourcePictureBox.TabIndex = 0;
            this._sourcePictureBox.TabStop = false;
            // 
            // _outputPictureBox
            // 
            this._outputPictureBox.Location = new System.Drawing.Point(736, 38);
            this._outputPictureBox.Margin = new System.Windows.Forms.Padding(4);
            this._outputPictureBox.Name = "_outputPictureBox";
            this._outputPictureBox.Size = new System.Drawing.Size(640, 400);
            this._outputPictureBox.TabIndex = 1;
            this._outputPictureBox.TabStop = false;
            // 
            // _openCameraButton
            // 
            this._openCameraButton.Location = new System.Drawing.Point(40, 460);
            this._openCameraButton.Margin = new System.Windows.Forms.Padding(4);
            this._openCameraButton.Name = "_openCameraButton";
            this._openCameraButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._openCameraButton.Size = new System.Drawing.Size(130, 40);
            this._openCameraButton.TabIndex = 2;
            this._openCameraButton.Text = "開啟攝影機";
            this._openCameraButton.UseVisualStyleBackColor = true;
            this._openCameraButton.Click += new System.EventHandler(this.ClickOpenCameraButton);
            // 
            // _buttonGray
            // 
            this._buttonGray.Location = new System.Drawing.Point(736, 460);
            this._buttonGray.Name = "_buttonGray";
            this._buttonGray.Size = new System.Drawing.Size(130, 40);
            this._buttonGray.TabIndex = 3;
            this._buttonGray.Text = "灰階";
            this._buttonGray.UseVisualStyleBackColor = true;
            this._buttonGray.Click += new System.EventHandler(this._buttonGray_Click);
            // 
            // _buttonSobel
            // 
            this._buttonSobel.Location = new System.Drawing.Point(1075, 460);
            this._buttonSobel.Name = "_buttonSobel";
            this._buttonSobel.Size = new System.Drawing.Size(130, 40);
            this._buttonSobel.TabIndex = 4;
            this._buttonSobel.Text = "邊緣偵測";
            this._buttonSobel.UseVisualStyleBackColor = true;
            this._buttonSobel.Click += new System.EventHandler(this._buttonSobel_Click);
            // 
            // _buttonBinarization
            // 
            this._buttonBinarization.Location = new System.Drawing.Point(905, 460);
            this._buttonBinarization.Name = "_buttonBinarization";
            this._buttonBinarization.Size = new System.Drawing.Size(130, 40);
            this._buttonBinarization.TabIndex = 3;
            this._buttonBinarization.Text = "二值化";
            this._buttonBinarization.UseVisualStyleBackColor = true;
            this._buttonBinarization.Click += new System.EventHandler(this._buttonBinarization_Click);
            // 
            // _buttonInvert
            // 
            this._buttonInvert.Location = new System.Drawing.Point(1246, 460);
            this._buttonInvert.Name = "_buttonInvert";
            this._buttonInvert.Size = new System.Drawing.Size(130, 40);
            this._buttonInvert.TabIndex = 4;
            this._buttonInvert.Text = "負片";
            this._buttonInvert.UseVisualStyleBackColor = true;
            this._buttonInvert.Click += new System.EventHandler(this._buttonInvert_Click);
            // 
            // _buttonOCR
            // 
            this._buttonOCR.Location = new System.Drawing.Point(1246, 518);
            this._buttonOCR.Name = "_buttonOCR";
            this._buttonOCR.Size = new System.Drawing.Size(130, 40);
            this._buttonOCR.TabIndex = 4;
            this._buttonOCR.Text = "OCR";
            this._buttonOCR.UseVisualStyleBackColor = true;
            this._buttonOCR.Click += new System.EventHandler(this._buttonOCR_Click);
            // 
            // _textboxOCR
            // 
            this._textboxOCR.Location = new System.Drawing.Point(1246, 575);
            this._textboxOCR.Name = "_textboxOCR";
            this._textboxOCR.Size = new System.Drawing.Size(130, 25);
            this._textboxOCR.TabIndex = 5;
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1387, 610);
            this.Controls.Add(this._textboxOCR);
            this.Controls.Add(this._buttonOCR);
            this.Controls.Add(this._buttonInvert);
            this.Controls.Add(this._buttonSobel);
            this.Controls.Add(this._buttonBinarization);
            this.Controls.Add(this._buttonGray);
            this.Controls.Add(this._openCameraButton);
            this.Controls.Add(this._outputPictureBox);
            this.Controls.Add(this._sourcePictureBox);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form";
            this.Text = "HW1";
            ((System.ComponentModel.ISupportInitialize)(this._sourcePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._outputPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox _sourcePictureBox;
        private System.Windows.Forms.PictureBox _outputPictureBox;
        private System.Windows.Forms.Button _openCameraButton;
        private System.Windows.Forms.Button _buttonGray;
        private System.Windows.Forms.Button _buttonSobel;
        private System.Windows.Forms.Button _buttonBinarization;
        private System.Windows.Forms.Button _buttonInvert;
        private System.Windows.Forms.Button _buttonOCR;
        private System.Windows.Forms.TextBox _textboxOCR;
    }
}

