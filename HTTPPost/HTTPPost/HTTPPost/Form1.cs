using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using ComWord = Microsoft.Office.Interop.Word;
using Spire.Pdf;
using Spire.Pdf.Graphics;

namespace HTTPPost
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //create a pdf document
            string pdfFile = @"E:\HTTPPost\Example.pdf";
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(pdfFile);

            //add a new page
            PdfPageBase page = doc.Pages[0];

            //create a layer named "red line"
            PdfPageLayer layer = page.PageLayers.Add();
            layer.Graphics.DrawLine(new PdfPen(PdfBrushes.Red, 1), new PointF(50, 50), new PointF(100, 100));
            PdfImage image = new PdfBitmap(@"E:\HTTPPost\name.bmp");
            layer.Graphics.DrawImage(image, new RectangleF(100, 100, 40, 20));

            //save pdf document
            string output = @"E:\HTTPPost\AddLayers.pdf";
            doc.SaveToFile(output);

            System.Diagnostics.Process.Start(output);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var data = new Dictionary<string, string>();
            data.Add("ProposalID", "11111");
            data.Add("CustomerName", "");
            data.Add("ProgramID", "-1");
            data.Add("ProposalStatusID", "-1");
            data.Add("ApprovedBy", "");
            data.Add("OperationsCenterID", "-1");
            data.Add("PricingCountry", "");
            data.Add("SystemModifiedUserName", "");
            data.Add("LCAlias", "");
            data.Add("BCAlias", "");
            data.Add("StartDate", "");
            data.Add("EndDate", "");
            data.Add("SystemCreatedUserName", "");
            data.Add("AssignedApproverAlias", "");
            data.Add("hdnIsNewSer", "");

            string url = "https://awsui.partners.extranet.microsoft.com/MOPET/Approval/ProposalSearchResults";
            //string url = "https://awsui.partners.extranet.microsoft.com/MOPET";
            //string url = "https://fund.chinaamc.com/wodejijin/zhcx/index.shtml";

            var result = PostResponse(url, data, Encoding.Default);
            System.IO.File.WriteAllText("d:\\Result.html", result, Encoding.Default);
        }

        /// <summary>
        /// 发起httpPost 请求，可以上传文件
        /// </summary>
        /// <param name="url">请求的地址</param>
        /// <param name="input">表单数据</param>
        /// <param name="endoding">编码</param>
        /// <returns></returns>
        public static string PostResponse(string url, Dictionary<string, string> input, Encoding endoding)
        {

            string boundary = "----------------------------" + DateTime.Now.Ticks.ToString("x");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.PreAuthenticate = true;
            request.ContentType = "multipart/form-data; boundary=" + boundary;
            request.Method = "POST";
            request.KeepAlive = true;
            // Create a New 'NetworkCredential' object.
            NetworkCredential networkCredential = new NetworkCredential("v-ywhu", "hyouw3PL4ks@@", "fareast");
            // Associate the 'NetworkCredential' object with the 'WebRequest' object.
            request.Credentials = networkCredential;
            request.Expect = "";

            MemoryStream stream = new MemoryStream();

            //提交文本字段
            if (input != null)
            {
                string format = "--" + boundary + "\r\nContent-Disposition:form-data;name=\"{0}\"\r\n\r\n{1}\r\n";    //自带项目分隔符
                foreach (string key in input.Keys)
                {
                    string s = string.Format(format, key, input[key]);
                    byte[] data = Encoding.UTF8.GetBytes(s);
                    stream.Write(data, 0, data.Length);
                }

            }

            byte[] foot_data = Encoding.UTF8.GetBytes("--" + boundary + "--\r\n");      //项目最后的分隔符字符串需要带上--  
            stream.Write(foot_data, 0, foot_data.Length);

            request.ContentLength = stream.Length;
            Stream requestStream = request.GetRequestStream(); //写入请求数据
            stream.Position = 0L;
            stream.CopyTo(requestStream); //
            stream.Close();

            requestStream.Close();
            
            try
            {
                HttpWebResponse response;
                try
                {
                    response = (HttpWebResponse)request.GetResponse();

                    try
                    {
                        using (var responseStream = response.GetResponseStream())
                        using (var mstream = new MemoryStream())
                        {
                            responseStream.CopyTo(mstream);
                            string message = endoding.GetString(mstream.ToArray());
                            return message;
                        }                        
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                catch (WebException ex)
                {
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ComWord.Application app = new ComWord.Application();
            app.Visible = false;
            var document = app.Documents.Open(@"e:\(Y74) - Copy.docx");

            object obj = System.Reflection.Missing.Value;
            Object fmt = (object)ComWord.WdSaveFormat.wdFormatText;
            document.SaveAs(@"e:\(Y74) - Copy.txt", ref fmt, ref obj, ref obj, ref obj, ref obj, ref obj, ref obj, ref obj, ref obj, ref obj, ref obj, ref obj, ref obj, ref obj, ref obj);
            document.Close(ref obj, ref obj, ref obj);
            app.Quit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            srcPicture.ShowDialog();
            pictureBox1.ImageLocation = srcPicture.FileName;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            destPicture.ShowDialog();
            pictureBox2.ImageLocation = destPicture.FileName;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SimilarPhoto src = new SimilarPhoto(pictureBox1.ImageLocation);
            SimilarPhoto dest = new SimilarPhoto(pictureBox2.ImageLocation);
            string srcHash = src.GetHash();
            string destHash = dest.GetHash();
            int diff = SimilarPhoto.CalcSimilarDegree(srcHash, destHash);

            lab_Result.Text = diff.ToString();
        }
    }
}
