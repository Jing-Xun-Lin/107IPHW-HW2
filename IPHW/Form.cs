using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.OCR;
using Emgu.CV.Structure;


namespace IPHW
{
    public partial class Form : System.Windows.Forms.Form
    {

        VideoCapture _capture;

        private Image<Bgr, Byte> _camImage = null;

        private bool _isPressed;
        private int _startX, _startY, _endX, _endY;
        private System.Drawing.Rectangle _rect;
        private Tesseract _ocr;

        enum State
        {
            none, 
            gray,
            binarization,
            sobel,
            invert, 
            OCR
        };

        State state;

        public Form()
        {
            InitializeComponent();
            state = State.none;
            _isPressed = false;
            _startX = _startY = _endX = _endY = 0;
            _rect = new Rectangle(0, 0, 0, 0);
            string path = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()))) + "\\tessdata.traineddata";
            _ocr = new Tesseract(path, "eng", OcrEngineMode.TesseractLstmCombined);

            _sourcePictureBox.MouseDown += HandlePictureBoxPress;
            _sourcePictureBox.MouseMove += HandlePictureBoxMove;
            _sourcePictureBox.MouseUp += HandlePictureBoxRelease;
            _sourcePictureBox.Paint += HandlePictureBoxPaint;
        }

        private void ClickOpenCameraButton(object sender, EventArgs e)
        {
            if (_capture == null)
            {
                _capture = new VideoCapture(1);

            }

            if (_capture != null)
            {
                Application.Idle += ProcessFrame;
            }

        }

        //將Webcam上的畫面顯示在pictureBox上
        private void ProcessFrame(object sender, EventArgs e)
        {
            if (_capture != null && _capture.Ptr != IntPtr.Zero)
            {
                _camImage = _capture.QueryFrame().ToImage<Bgr, Byte>();
                _sourcePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                _sourcePictureBox.Image = _camImage.Bitmap;

                _outputPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                HandleOutputPictureBox();
            }
        }

        private void HandleOutputPictureBox()
        {
            switch (state)
            {
                    //灰階
                case State.gray:
                    _outputPictureBox.Image = new Image<Gray, byte>(_camImage.Bitmap).ToBitmap();
                    break;
                    //二值化
                case State.binarization:
                    Gray thresholdValue = new Gray(130);
                    //將影像轉灰階
                    Image<Gray, byte> grayImage = new Image<Gray, byte>((Bitmap)(_sourcePictureBox.Image));
                    //二值化處理
                    Image<Gray, byte> thresholdImage = grayImage.ThresholdBinary(thresholdValue, new Gray(255));
                    _outputPictureBox.Image = thresholdImage.ToBitmap();
                    break;
                    //邊緣偵測
                case State.sobel:
                    Image<Gray, byte> gray = new Image<Gray, byte>((Bitmap)(_sourcePictureBox.Image));
                    Image<Gray, float> sobel = gray.Sobel(0, 1, 3).Add(gray.Sobel(1, 0, 3)).AbsDiff(new Gray(0.0));
                    _outputPictureBox.Image = sobel.ToBitmap();
                    break;
                    //負片
                case State.invert:
                    _outputPictureBox.Image = new Image<Bgr, byte>((Bitmap)(_sourcePictureBox.Image)).Not().ToBitmap();
                    break;
                    //數字偵測 OCR
                case State.OCR:
                    if (_startX != _endX && _startY != _endY)
                    {
                        _outputPictureBox.SizeMode = PictureBoxSizeMode.Normal;
                        //二值化
                        Image<Gray, byte> image = new Image<Gray, byte>((Bitmap)(_sourcePictureBox.Image)).GetSubRect(_rect);
                        Image<Gray, byte> threshold = image.ThresholdBinary(new Gray(130), new Gray(255));
                        //輸出
                        _outputPictureBox.Image = threshold.ToBitmap();
                    }
                    break;
                default:
                    break;
            }
        }

        //Mouse press event
        private void HandlePictureBoxPress(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (_capture != null)
            {
                _isPressed = true;
                _startX = _endX = e.X;
                _startY = _endY = e.Y;
                SetRectangleData();
            }
        }

        //Mouse move event
        private void HandlePictureBoxMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (_isPressed)
            {
                _endX = e.X;
                _endY = e.Y;
                SetRectangleData();
                state = State.OCR;
            }
        }

        //Mouse release event
        private void HandlePictureBoxRelease(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (_isPressed)
            {
                _endX = e.X;
                _endY = e.Y;
                SetRectangleData();
                _isPressed = false;
            }
        }

        //picturebox paint
        private void HandlePictureBoxPaint(object sender, PaintEventArgs e)
        {
            if (state == State.OCR)
                e.Graphics.DrawRectangle(new Pen(Color.CornflowerBlue, 3), _rect);
        }

        //get rectangle data
        private void SetRectangleData()
        {
            _rect.X = Math.Min(_startX, _endX);
            _rect.Y = Math.Min(_startY, _endY);
            _rect.Width = Math.Max(_startX, _endX) - _rect.X;
            _rect.Height = Math.Max(_startY, _endY) - _rect.Y;
        }

        //做OCR
        private void _buttonOCR_Click(object sender, EventArgs e)
        {
            if (state == State.OCR)
            {                
                _ocr.SetImage(new Image<Gray, byte>((Bitmap)(_outputPictureBox.Image)));
                _ocr.SetVariable("tessedit_char_whitelist", "0123456789");
                _ocr.Recognize();
                _textboxOCR.Text = _ocr.GetUTF8Text();
            }
        }

        //灰階
        private void _buttonGray_Click(object sender, EventArgs e)
        {
            state = State.gray;
        }

        //二值化
        private void _buttonBinarization_Click(object sender, EventArgs e)
        {
            state = State.binarization;
        }

        //邊緣偵測
        private void _buttonSobel_Click(object sender, EventArgs e)
        {
            state = State.sobel;
        }

        //負片
        private void _buttonInvert_Click(object sender, EventArgs e)
        {
            state = State.invert;
        }
    }
}
