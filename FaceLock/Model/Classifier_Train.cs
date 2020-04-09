using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace FaceLock.Model
{
    public class Classifier_Train
    {
        string Directory;
        string FileName;
        string XmlDataFile;
        public Classifier_Train(string Dizin, string KlasorAdi)
        {
            this.Directory = Dizin + KlasorAdi;
            termCrit = new MCvTermCriteria(ContTrain, 0.001);
            _IsTrained = LoadTrainingData(this.Directory);
        }
        public Classifier_Train(string Dizin, string KlasorAdi, string XmlVeriDosyasi)
        {
            this.Directory = Dizin + KlasorAdi;
            this.XmlDataFile = XmlVeriDosyasi;
            termCrit = new MCvTermCriteria(ContTrain, 0.001);
            _IsTrained = LoadTrainingData(this.Directory);
        }
        MCvTermCriteria termCrit;
        EigenObjectRecognizer recognizer;
        List<Image<Gray, byte>> trainingImages = new List<Image<Gray, byte>>();
        List<string> Names_List = new List<string>();
        int ContTrain, NumLabels;
        float Eigen_Distance = 0;
        string Eigen_label;
        int Eigen_threshold = 0;
        string Error;
        bool _IsTrained = false;
        public Classifier_Train()
        {
            FileName = "TrainedFaces";
            Directory = Application.StartupPath + "\\" + FileName;
            XmlDataFile = "TrainedLabels.xml";

            termCrit = new MCvTermCriteria(ContTrain, 0.001);
            _IsTrained = LoadTrainingData(Directory);
        }
        public Classifier_Train(string Training_Folder)
        {
            termCrit = new MCvTermCriteria(ContTrain, 0.001);
            _IsTrained = LoadTrainingData(Training_Folder);
        }
        public bool IsTrained
        {
            get { return _IsTrained; }
        }
        public string Recognise(Image<Gray, byte> Input_image, int Eigen_Thresh = -1)
        {
            if (_IsTrained)
            {
                EigenObjectRecognizer.RecognitionResult ER = recognizer.Recognize(Input_image);
                if (ER == null)
                {
                    Eigen_label = "Tanımsız";
                    Eigen_Distance = 0;
                    return Eigen_label;
                }
                else
                {
                    Eigen_label = ER.Label;
                    Eigen_Distance = ER.Distance;
                    if (Eigen_Thresh > -1) Eigen_threshold = Eigen_Thresh;
                    if (Eigen_Distance > Eigen_threshold) return Eigen_label;
                    else return "Tanımsız";
                }
            }
            else return "";
        }
        public int Set_Eigen_Threshold
        {
            set {  Eigen_threshold = value; }
        }
        public string Get_Eigen_Label
        {
            get { return Eigen_label; }
        }
        public float Get_Eigen_Distance
        {
            get {return Eigen_Distance;}
        }
        public string Get_Error
        {
            get { return Error; }
        }
        public void Save_Eigen_Recogniser(string filename)
        {
            StringBuilder sb = new StringBuilder();
            (new XmlSerializer(typeof(EigenObjectRecognizer))).Serialize(new StringWriter(sb), recognizer);
            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(sb.ToString());
            xDoc.Save(filename);
        }
        public void Load_Eigen_Recogniser(string filename)
        {
            FileStream EigenFS = File.OpenRead(filename);
            long Eflength = EigenFS.Length;
            byte[] xmlEBs = new byte[Eflength];
            EigenFS.Read(xmlEBs, 0, (int)Eflength);
            EigenFS.Close();
            MemoryStream xStream = new MemoryStream(xmlEBs);
            recognizer = (EigenObjectRecognizer)(new XmlSerializer(typeof(EigenObjectRecognizer))).Deserialize(xStream);
            _IsTrained = true;
        }
        public void Dispose()
        {
            recognizer = null;
            trainingImages = null;
            Names_List = null;
            Error = null;
            GC.Collect();
        }
        private bool LoadTrainingData(string Folder_location)
        {
            if (File.Exists(Folder_location + "\\" + XmlDataFile))
            {
                try
                {
                    Names_List.Clear();
                    trainingImages.Clear();
                    FileStream filestream = File.OpenRead(Folder_location + "\\" + XmlDataFile);
                    long filelength = filestream.Length;
                    byte[] xmlBytes = new byte[filelength];
                    filestream.Read(xmlBytes, 0, (int)filelength);
                    filestream.Close();
                    MemoryStream xmlStream = new MemoryStream(xmlBytes);
                    using (XmlReader xmlreader = XmlTextReader.Create(xmlStream))
                    {
                        while (xmlreader.Read())
                        {
                            if (xmlreader.IsStartElement())
                            {
                                switch (xmlreader.Name)
                                {
                                    case "NAME":
                                        if (xmlreader.Read())
                                        {
                                            Names_List.Add(xmlreader.Value.Trim());
                                            NumLabels += 1;
                                        }
                                        break;
                                    case "FILE":
                                        if (xmlreader.Read())
                                        {
                                            //PROBLEM HERE IF TRAININGG MOVED
                                            trainingImages.Add(new Image<Gray, byte>(Directory + "\\" + xmlreader.Value.Trim()));
                                        }
                                        break;
                                }
                            }
                        }
                    }
                    ContTrain = NumLabels;

                    if (trainingImages.ToArray().Length != 0)
                    {
                        recognizer = new EigenObjectRecognizer(trainingImages.ToArray(),
                        Names_List.ToArray(), 5000, ref termCrit); //5000 default
                        return true;
                    }
                    else return false;
                }
                catch (Exception ex)
                {
                    Error = ex.ToString();
                    return false;
                }
            }
            else return false;
        }
    }
}
