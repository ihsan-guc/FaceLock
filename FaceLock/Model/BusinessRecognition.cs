using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace FaceLock.Model
{
    public class BusinessRecognition
    {
        string Directory;
        string FileName;
        string XmlDataFile;
        public BusinessRecognition()
        {
            FileName = "TrainedFaces";
            XmlDataFile = "TrainedLabels.xml";
            Directory = Application.StartupPath + "/" + FileName + "/";
        }
        public BusinessRecognition(string Dizin, string KlasorAdi)
        {
            this.Directory = Dizin + "/" + KlasorAdi + "/";
            Eigen_Recog = new Classifier_Train(Dizin, KlasorAdi);
        }
        public BusinessRecognition(string Dizin, string KlasorAdi, string XmlVeriDosyasi)
        {
            this.Directory = Dizin + "/" + KlasorAdi + "/";
            this.XmlDataFile = XmlVeriDosyasi;
            Eigen_Recog = new Classifier_Train(Dizin, KlasorAdi, XmlVeriDosyasi);
        }
        List<Image<Gray, byte>> resultImages = new List<Image<Gray, byte>>();
        Classifier_Train Eigen_Recog;
        XmlDocument docu = new XmlDocument();
        public bool SaveTrainingData(Image face_data, string FaceName)
        {
            try
            {
                string NAME_PERSON = FaceName;
                Random rand = new Random();
                bool file_create = true;
                string facename = "face_" + NAME_PERSON + "_" + rand.Next().ToString() + ".jpg";
                while (file_create)
                {
                    if (!File.Exists(Directory + facename))
                        file_create = false;
                    else
                        facename = "face_" + NAME_PERSON + "_" + rand.Next().ToString() + ".jpg";
                }
                if (System.IO.Directory.Exists(Directory))
                    face_data.Save(Directory + facename, ImageFormat.Jpeg);
                else
                {
                    System.IO.Directory.CreateDirectory(Directory);
                    face_data.Save(Directory + facename, ImageFormat.Jpeg);
                }
                if (File.Exists(Directory + XmlDataFile))
                {
                    bool loading = true;
                    while (loading)
                    {
                        try
                        {
                            docu.Load(Directory + XmlDataFile);
                            loading = false;
                        }
                        catch
                        {
                            docu = null;
                            docu = new XmlDocument();
                            Thread.Sleep(10);
                        }
                    }
                    XmlElement root = docu.DocumentElement;
                    XmlElement face_D = docu.CreateElement("FACE");
                    XmlElement name_D = docu.CreateElement("NAME");
                    XmlElement file_D = docu.CreateElement("FILE");
                    name_D.InnerText = NAME_PERSON;
                    file_D.InnerText = facename;
                    face_D.AppendChild(name_D);
                    face_D.AppendChild(file_D);
                    root.AppendChild(face_D);
                    docu.Save(Directory + XmlDataFile);
                }
                else
                {
                    FileStream FS_Face = File.OpenWrite(Directory + XmlDataFile);
                    using (XmlWriter writer = XmlWriter.Create(FS_Face))
                    {
                        writer.WriteStartDocument();
                        writer.WriteStartElement("Faces_For_Training");
                        writer.WriteStartElement("FACE");
                        writer.WriteElementString("NAME", NAME_PERSON);
                        writer.WriteElementString("FILE", facename);
                        writer.WriteEndElement();
                        writer.WriteEndElement();
                        writer.WriteEndDocument();
                    }
                    FS_Face.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public void DeleteTrains()
        {
            if (System.IO.Directory.Exists(Directory))
                System.IO.Directory.Delete(Directory, true);
            System.IO.Directory.CreateDirectory(Directory);
        }
    }
}
