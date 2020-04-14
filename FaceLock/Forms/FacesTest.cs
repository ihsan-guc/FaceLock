using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using FaceLock.Model;
using System.Drawing;
namespace FaceLock.Forms
{
    public partial class FacesTest : MetroFramework.Forms.MetroForm
    {
        public FacesTest()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            Camera();
            pictureBox2.ImageLocation = "C:\\Users\\EysanGuc\\source\\repos\\FaceLock\\FaceLock\\Images\\indir.png";
        }
        Classifier_Train train = new Classifier_Train("D:\\", "Faces", "Faces.xml");
        public void Camera()
        {
            Capture capture = new Capture();
            capture.Start();
            var step = "";
            capture.ImageGrabbed += (a, b) =>
            {
                var image = capture.RetrieveBgrFrame();
                var grayimage = image.Convert<Gray, byte>();
                HaarCascade haaryuz = new HaarCascade("haarcascade_frontalface_alt2.xml");
                MCvAvgComp[][] Yuzler = grayimage.DetectHaarCascade(haaryuz, 1.2, 5, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(15, 15));
                MCvFont font = new MCvFont(FONT.CV_FONT_HERSHEY_COMPLEX, 0.5, 0.5);
                foreach (MCvAvgComp yuz in Yuzler[0])
                {
                    var sadeyuz = grayimage.Copy(yuz.rect).Convert<Gray, byte>().Resize(150, 150, INTER.CV_INTER_CUBIC);
                    if (train != null)
                        if (train.IsTrained)
                        {
                            string name = train.Recognise(sadeyuz);
                            int match_value = (int)train.Get_Eigen_Distance;
                            image.Draw(name + " ", ref font, new Point(yuz.rect.X - 2, yuz.rect.Y - 2), new Bgr(Color.Blue));
                            if (name.ToString() != "Tanimsiz")
                            {
                                pictureBox2.LoadAsync("C:\\Users\\EysanGuc\\source\\repos\\FaceLock\\FaceLock\\Images\\indir.png");
                            }
                            step = name.ToString();
                        }
                    image.Draw(yuz.rect, new Bgr(Color.Red), 2);
                }
                if (step == "Tanimsiz")
                {
                    pictureBox2.LoadAsync("C:\\Users\\EysanGuc\\source\\repos\\FaceLock\\FaceLock\\Images\\scanning.png");
                }
                pictureBox1.Image = image.ToBitmap();
                step = "";
            };
        }
    }
}
