using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using FaceLock.Forms;
using FaceLock.Model;
using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaceLock
{
    public partial class FaceAdd : MetroFramework.Forms.MetroForm
    {
        BusinessRecognition recognition = new BusinessRecognition("D:\\", "Faces", "Faces.xml");
        Classifier_Train train = new Classifier_Train("D:\\", "Faces", "Faces.xml");
        public FaceAdd()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            Camera();
        }

        private async void FaceTestBtn_Click(object sender, System.EventArgs e)
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < 50; i++)
                {
                    if (!recognition.SaveTrainingData(SmallFacepctbox.Image, FaceNametxt.Text)) MessageBox.Show("Hata", "Profil alınırken beklenmeyen bir hata oluştu.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Thread.Sleep(100);
                    lbltestName.Text = (i + 1) + " adet profil.";
                    Downloadbar.Value = (i + 1) * 2;
                    if (i == 25)
                        MessageBox.Show("Yüzünüzü Çevirin","Ok",MessageBoxButtons.OK);
                }
                recognition = null;
                train = null;
                recognition = new BusinessRecognition("D:\\", "Faces", "yuz.xml");
                train = new Classifier_Train("D:\\", "Faces", "yuz.xml");
            });
            MessageBox.Show("Diğer Sayfaya Yönlendiriliyorsunuz 2 saniye sonra");
            Downloadbar.Value = 0;
            Thread.Sleep(2000);
            this.Hide();
            FacesTest testFaces = new FacesTest();
            testFaces.Show();
            
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
                    MCvFont font = new MCvFont(FONT.CV_FONT_HERSHEY_COMPLEX, 1, 1);
                    foreach (MCvAvgComp yuz in Yuzler[0])
                    {
                        var sadeyuz = grayimage.Copy(yuz.rect).Convert<Gray, byte>().Resize(150, 150, INTER.CV_INTER_CUBIC);
                        SmallFacepctbox.Image = sadeyuz.ToBitmap();
                        if (train != null)
                            if (train.IsTrained)
                            {
                                string name = train.Recognise(sadeyuz);
                                int match_value = (int)train.Get_Eigen_Distance;
                                image.Draw(name + " ", ref font, new Point(yuz.rect.X - 2, yuz.rect.Y - 2), new Bgr(Color.Blue));
                            }
                        image.Draw(yuz.rect, new Bgr(Color.Red), 2);
                    }
                    Facepicturebox.Image = image.ToBitmap();
                };
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}
