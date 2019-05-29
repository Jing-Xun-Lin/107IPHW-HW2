using System;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;


namespace IPHW
{
    public partial class Form : System.Windows.Forms.Form
    {

        VideoCapture _capture;

        private Image<Bgr, Byte> _camImage = null;

        enum State
        {
            none, 
            gray,
            binarization,
            sobel,
            invert
        };

        State state;

        public Form()
        {
            InitializeComponent();
            state = State.none;
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
                case State.gray:
                    _outputPictureBox.Image = new Image<Gray, byte>(_camImage.Bitmap).ToBitmap();
                    break;
                case State.binarization:
                    Gray thresholdValue = new Gray(130);
                    //將影像轉灰階
                    Image<Gray, byte> grayImage = new Image<Gray, byte>((Bitmap)(_sourcePictureBox.Image));
                    //二值化處理
                    Image<Gray, byte> thresholdImage = grayImage.ThresholdBinary(thresholdValue, new Gray(255));
                    _outputPictureBox.Image = thresholdImage.ToBitmap();
                    break;
                case State.sobel:
                    Image<Gray, byte> gray = new Image<Gray, byte>((Bitmap)(_sourcePictureBox.Image));
                    Image<Gray, float> sobel = gray.Sobel(0, 1, 3).Add(gray.Sobel(1, 0, 3)).AbsDiff(new Gray(0.0));
                    _outputPictureBox.Image = sobel.ToBitmap();
                    break;
                case State.invert:
                    _outputPictureBox.Image = new Image<Bgr, byte>((Bitmap)(_sourcePictureBox.Image)).Not().ToBitmap();
                    break;
                default:
                    break;
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
