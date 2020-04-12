using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using FaceLock.Forms;
using FaceLock.Model;
using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace FaceLock
{
    public partial class FaceLockAdd : Form
    {
        BusinessRecognition recognition = new BusinessRecognition("D:\\", "Faces", "Faces.xml");
        Classifier_Train train = new Classifier_Train("D:\\", "Faces", "Faces.xml");
        public FaceLockAdd()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            Camera();
        }
        public void Camera()
        {
            var dialogResult = MessageBox.Show("Kabul Ederseniz Kullanım Koşullarını Onaylamış Olursunuz", "Kullanım Koşulları", MessageBoxButtons.OKCancel);
            if (dialogResult == System.Windows.Forms.DialogResult.OK)
            {
                Capture capture = new Capture();
                capture.Start();
                capture.ImageGrabbed += (a, b) =>
                {
                    var image = capture.RetrieveBgrFrame();
                    var grayimage = image.Convert<Gray, byte>();
                    HaarCascade haaryuz = new HaarCascade("haarcascade_frontalface_alt2.xml");
                    MCvAvgComp[][] Yuzler = grayimage.DetectHaarCascade(haaryuz, 1.2, 5, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(15, 15));
                    MCvFont font = new MCvFont(FONT.CV_FONT_HERSHEY_COMPLEX, 0.5, 0.5);
                    foreach (MCvAvgComp yuz in Yuzler[0])
                    {
                        var sadeyuz = grayimage.Copy(yuz.rect).Convert<Gray, byte>().Resize(100, 100, INTER.CV_INTER_CUBIC);
                        pictureBox2.Image = sadeyuz.ToBitmap();
                        if (train != null)
                            if (train.IsTrained)
                            {
                                string name = train.Recognise(sadeyuz);
                                int match_value = (int)train.Get_Eigen_Distance;
                                image.Draw(name + " ", ref font, new Point(yuz.rect.X - 2, yuz.rect.Y - 2), new Bgr(Color.Blue));
                            }
                        image.Draw(yuz.rect, new Bgr(Color.Red), 2);
                    }
                    pictureBox1.Image = image.ToBitmap();
                };
            }
            else
            {
                Environment.Exit(0);
            }
        }

        private async void btnEgit_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < 20; i++)
                {
                    if (!recognition.SaveTrainingData(pictureBox2.Image, txtFaceName.Text)) MessageBox.Show("Hata", "Profil alınırken beklenmeyen bir hata oluştu.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Thread.Sleep(100);
                    lblEgitilenAdet.Text = (i + 1) + " adet profil.";
                }
                recognition = null;
                train = null;
                recognition = new BusinessRecognition("D:\\", "Faces", "yuz.xml");
                train = new Classifier_Train("D:\\", "Faces", "yuz.xml");
            });
            this.Hide();
            MessageBox.Show("Diğer Sayfaya Yönlendiriliyorsunuz 2 saniye sonra");
            Thread.Sleep(2000);
            TestFaces testFaces = new TestFaces();
            testFaces.Show();
        }
    }
}
