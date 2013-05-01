using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.ML;
using Emgu.CV.ML.Structure;
using Emgu.Util;

namespace SSSS {
    public partial class KNNForm : Form {

        string[][] vectorTable;

        public KNNForm() {
            InitializeComponent();
        }

        public KNNForm(string[][] tempVectorTable) : this() {
            this.vectorTable = tempVectorTable;
        }

        private void TestEmgu(){
            int K = 10;
            //int trainSampleCount = 100;
            int trainSampleCount = this.vectorTable[0].Length-1;
            int trainSampleColumns = this.vectorTable.Length - 2; //subtract two columns for the post id and IsImage
            int scalingRatio = 10;

            #region Generate the traning data and classes

            Matrix<float> trainData = new Matrix<float>(trainSampleColumns, trainSampleCount);
            Matrix<float> trainClasses = new Matrix<float>(trainSampleColumns, 1);

            Image<Bgr, Byte> img = new Image<Bgr, byte>(trainSampleCount, trainSampleCount);

            Matrix<float> sample = new Matrix<float>(1, trainSampleCount);

            for (int y = 1; y < this.vectorTable[0].Length - 1; y++) {
                for (int x = 2; x < this.vectorTable.Length - 1; x++) {
                    trainData.Data.SetValue(Int32.Parse(this.vectorTable[x][y])*scalingRatio,x-2,y-1);
                }
            }

            Matrix<float> trainData1 = trainData.GetRows(0, trainSampleColumns >> 1, 1);
            //trainData1.SetRandNormal(new MCvScalar(200), new MCvScalar(50));
            Matrix<float> trainData2 = trainData.GetRows(trainSampleColumns >> 1, trainSampleColumns, 1);
            //trainData2.SetRandNormal(new MCvScalar(300), new MCvScalar(50));

            Matrix<float> trainClasses1 = trainClasses.GetRows(0, trainSampleCount >> 1, 1);
            trainClasses1.SetValue(1);
            Matrix<float> trainClasses2 = trainClasses.GetRows(trainSampleCount >> 1, trainSampleCount, 1);
            trainClasses2.SetValue(2);
            #endregion

            Matrix<float> results, neighborResponses;
            results = new Matrix<float>(sample.Rows, 1);
            neighborResponses = new Matrix<float>(sample.Rows, K);
            //dist = new Matrix<float>(sample.Rows, K);

            KNearest knn = new KNearest(trainData, trainClasses, null, false, K);
            for (int i = 0; i < img.Height; i++) {
                for (int j = 0; j < img.Width; j++) {
                    sample.Data[0, 0] = j;
                    sample.Data[0, 1] = i;

                    //Matrix<float> nearestNeighbors = new Matrix<float>(K* sample.Rows, sample.Cols);
                    // estimates the response and get the neighbors' labels
                    float response = knn.FindNearest(sample, K, results, null, neighborResponses, null);

                    int accuracy = 0;
                    // compute the number of neighbors representing the majority
                    for (int k = 0; k < K; k++) {
                        if (neighborResponses.Data[0, k] == response)
                            accuracy++;
                    }
                    // highlight the pixel depending on the accuracy (or confidence)
                    img[i, j] =
                    response == 1 ?
                        (accuracy > 5 ? new Bgr(90, 0, 0) : new Bgr(90, 60, 0)) :
                        (accuracy > 5 ? new Bgr(0, 90, 0) : new Bgr(60, 90, 0));
                }
            }
            

            // display the original training samples
            for (int i = 0; i < (trainSampleCount >> 1); i++) {
                PointF p1 = new PointF(trainData1[i, 0], trainData1[i, 1]);
                img.Draw(new CircleF(p1, 2.0f), new Bgr(255, 100, 100), -1);
                PointF p2 = new PointF(trainData2[i, 0], trainData2[i, 1]);
                img.Draw(new CircleF(p2, 2.0f), new Bgr(100, 255, 100), -1);
            }

            //Emgu.CV.UI.ImageViewer.Show(img);
            Emgu.CV.UI.ImageViewer imgviewer = new Emgu.CV.UI.ImageViewer(img);
            imgviewer.Show();
        }

        private void button1_Click(object sender, EventArgs e) {
            TestEmgu();
        }

    }
}
