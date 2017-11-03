using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Csp2dotnet
{
    public partial class MainForm : Form
    {
        public Int32 ComCheck { get; set; }
        public int ReadBarcodes { get; set; } = 0;
        public bool DataSend { get; set; }
        private string TxtReader { get; set; }
        private bool ClearData { get; set; }
        private int NumApiTries { get; set; }
        private bool ApiSuccessful { get; set; }
        public string AccountNumber { get; set; }
        private bool ActNumSet { get; set; }

        public delegate void Action();

        ParamInfo[] Description = {
                        new ParamInfo( "Code 39", 0x1f ),
                        new ParamInfo( "UPC", 0x09 ),
                        new ParamInfo( "Code128",  0x08),
                        new ParamInfo( "Code 39 Full ASCII", 0x36 ),
                        new ParamInfo( "UPC Supps", 0x35 ),
                        new ParamInfo( "Convert  UPC E to A", 0x29 ),
                        new ParamInfo( "Convert EAN8 to EAN13",     0x2a ),
                        new ParamInfo( "Convert EAN8 to EAN13 Type", 0x37 ),
                        new ParamInfo( "Send UPC A Check Digit",    0x2b ),
                        new ParamInfo( "Send UPC E Check Digit", 0x2c ),
                        new ParamInfo( "Code 39 Check Digit", 0x2e ),
                        new ParamInfo( "Xmit Code 39 Check Digit", 0x2d ),
                        new ParamInfo( "UPCE_ Preamble", 0x25 ),
                        new ParamInfo( "UPCA_ Preamble", 0x24 ),
                        new ParamInfo( "EAN 128", 0x34 ),
                        new ParamInfo( "Coupon Code", 0x38),
                        new ParamInfo( "I 2of5", 0x3A ),
                        new ParamInfo( "I 2of5 Check Digit", 0x41 ),
                        new ParamInfo( "Xmit I 2of5 Check Digit", 0x40 ),
                        new ParamInfo( "Convert ITF14 to EAN 13", 0x3F ),
                        new ParamInfo( "I 2of5 Length 1",0x3B ),
                        new ParamInfo( "I 2of5 Length 2",0x3C ),
                        new ParamInfo( "D 2of5", 0x39 ),
                        new ParamInfo( "D 2of5  Length 1" ,0x3D ),
                        new ParamInfo( "D 2of5  Length 2", 0x3E ),
                        new ParamInfo( "Upcean Security Level", 0x2f ),
                        new ParamInfo( "UPC/EAN Supplemental Redundancy", 0x30 ),
                        new ParamInfo( "Scanner On-Time",0x11 ),
                        new ParamInfo( "Comm Awake Time", 0x20 ),
                        new ParamInfo( "Baud Rate ",0x0d ),
                        new ParamInfo( "Baud Switch Delay", 0x1d),
                        new ParamInfo( "Reset Baud Rates", 0x1c ),
                        new ParamInfo( "Reject Redundant Barcode", 0x04 ),
                        new ParamInfo( "Host Connect Beep ", 0x0a ),
                        new ParamInfo( "Host Complete Beep", 0x0b ),
                        new ParamInfo( "Low-Battery Indication", 0x07),
                        new ParamInfo( "Auto_Clear", 0x0f),
                        new ParamInfo( "Delete_Enable",0x21),
                        new ParamInfo( "Data Protection", 0x31 ),
                        new ParamInfo( "Memory Full Indication", 0x32 ),
                        new ParamInfo( "Memory Low Indication", 0x33 ),
                        new ParamInfo( "Max Barcode Len", 0x22 ),
                        new ParamInfo( "Good Decode LED On Time", 0x1e ),
                        new ParamInfo( "Store_RTC ", 0x23 ),
                        new ParamInfo( "ASCII mode", 0x4f ),
                        new ParamInfo( "Buzzer Volume",0x02 ),
                        new ParamInfo( "Buzzer On",0x57 ),
                        new ParamInfo( "Buzzer Toggle", 0x55 ),
                        new ParamInfo( "Buzzer Auto On", 0x56 ),
                        new ParamInfo( "RSS", 0x14 ),
        };

        List<Int32> Ports = new List<Int32>();

        private void CallbackFunction(Int32 nComport)
        {
                int iRet = -1;
                ComCheck = nComport;

                if (Opticon.csp2.DataAvailable(nComport) > 0)
                {
                
                    iRet = Opticon.csp2.ReadData(nComport);
                }
                else if (Opticon.csp2.GetDSR(nComport) > 0)
                {
                    iRet = Opticon.csp2.Interrogate(nComport);
                }
                if (iRet >= 0)
                {
                    if (Ports.Contains(nComport) == false)
                        Ports.Add(nComport);
                }
                else
                {
                    if (Ports.Contains(nComport) == true)
                        Ports.Remove(nComport);
                }

                //Change Connection Status Label
                BeginInvoke((Action)delegate ()
                {
                    if (Ports.Count > 0)
                    {
                        labelConnected.Text = "Connected on COM " + nComport;
                    }
                    else
                    {
                        labelConnected.Text = "Not Connected";
                    }
                });

                if (iRet >= 0L)
                {
                    Trace.WriteLine("\nOPN-2001 Connected at " + nComport);
                    Trace.WriteLine(ReadBarcodes);
                    Int32 iCount = iRet;   
                    Trace.WriteLine(String.Format("Number of barcodes = {0}", iCount));

                    ReadBarcodes = iCount;

                    //Change Quantity Scanned Label
                    BeginInvoke((Action)delegate ()
                    {
                        labelNumBarcodes.Text = ReadBarcodes.ToString();
                    });

                    if (DataSend == true)
                    {
                        if (AccountNumber != null)
                        {
                            ActNumSet = true;
                           
                            using (System.IO.StreamWriter file =
                               new System.IO.StreamWriter(@"../../Csp2.net.Test/Data.txt"))
                            {
                                Trace.WriteLine("\nCreating file...");                          

                                string time = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
                                file.WriteLine("<DT>" + "\t" + time);
                                Trace.WriteLine("<DT>" + "\t" + time );

                                file.WriteLine("<ACT>" + "\t" + AccountNumber);
                                Trace.WriteLine("<ACT>" + "\t" + AccountNumber);

                                string szDeviceId;
                                iRet = Opticon.csp2.GetDeviceId(out szDeviceId, nComport);
                                file.WriteLine("<ID>" + "\t" + szDeviceId);
                                Trace.WriteLine("<ID>" + "\t" + szDeviceId);

                                StringBuilder szSoftwareVersion = new StringBuilder(256);
                                Opticon.csp2.GetSwVersion(szSoftwareVersion, 256, nComport);
                                file.WriteLine("<SwV>" + "\t" + szSoftwareVersion);
                                Trace.WriteLine("<SwV>" +"\t" + szSoftwareVersion);

                                StringBuilder sbBarcodes = new StringBuilder(1000);
                                for (Int32 i = 0; i < ReadBarcodes; i++)
                                {
                                    Opticon.csp2.BarCodeDataPacket aPacket;
                                    iRet = Opticon.csp2.GetPacket(out aPacket, i, nComport);
                                    if (aPacket.strBarData != null)
                                    {
                                        sbBarcodes.AppendLine(String.Format("<Item>" + "\t" + aPacket.strBarData));
                                    }
                                };

                                file.WriteLine(sbBarcodes);
                                Trace.WriteLine(sbBarcodes);


                            using (System.IO.StreamWriter writer =
                               new System.IO.StreamWriter(@"C:\Users\Taylo\Desktop\WorkStuff\KeychainSynchBackup\KeychainSynch3\Csp2.net.Test\ScannerData\" + time))
                            {
                                writer.Write("<Date Created> " + time);
                                writer.Write("\r\n<Account Number> " + AccountNumber);                            
                                writer.Write("\r\n<Scanner Id> " + szDeviceId);
                                writer.Write("\r\n<Software Version> " + szSoftwareVersion);
                                writer.Write("\r\n" + sbBarcodes);

                                writer.Close();
                            }                                                  
                            }
                        }                   
                        else
                        {
                            ActNumSet = false;
                        }
                    DataSend = false;
                }

                    if (ClearData == true)
                    {
                        if (Opticon.csp2.ClearData(nComport) != 0)
                        {
                            Trace.WriteLine("Erasing Failed!");
                        }
                        ReadBarcodes = 0;
                        ClearData = false;
                    }
                }
                else
                {
                    Trace.WriteLine("OPN-2001 Disconnected from " + nComport);
                }
            Thread.Sleep(2000);
        }

        public MainForm()
        {           
            InitializeComponent();

            try{ AccountNumber = File.ReadLines(@"C:\Users\Taylo\Desktop\WorkStuff\KeychainSynchBackup\KeychainSynch3\Csp2.net.Test\TextDocs\Account_Number.txt").Skip(0).Take(1).First(); } catch{}
            if (AccountNumber != null)
            {              
                AccountTextBox.Text = ("Set to: " + AccountNumber);
            }

            Start();

            var pos = labelContact.Location;
            pos = backdrop.PointToClient(pos);
            labelContact.Parent = backdrop;
            labelContact.Location = pos;
            labelContact.BackColor = Color.Transparent;

            var pos1 = LLContact.Location;
            pos = backdrop.PointToClient(pos1);
            LLContact.Parent = backdrop;
            LLContact.Location = pos1;
            LLContact.BackColor = Color.Transparent;

            var pos2 = labelContactNum.Location;
            pos2 = backdrop.PointToClient(pos2);
            labelContactNum.Parent = backdrop;
            labelContactNum.Location = pos2;
            labelContactNum.BackColor = Color.Transparent;

            var pos3 = LLViewCart.Location;
            pos3 = logoTab2.PointToClient(pos3);
            LLViewCart.Parent = logoTab2;
            LLViewCart.Location = pos3;
            LLViewCart.BackColor = Color.Transparent;         

            var pos5 = labelBarcodes.Location;
            pos5 = logoTab1.PointToClient(pos5);
            labelBarcodes.Parent = logoTab1;
            labelBarcodes.Location = pos5;
            labelBarcodes.BackColor = Color.Transparent;

            var pos6 = labelNumBarcodes.Location;
            pos6 = logoTab1.PointToClient(pos6);
            labelNumBarcodes.Parent = logoTab1;
            labelNumBarcodes.Location = pos6;
            labelNumBarcodes.BackColor = Color.White;

            var pos7 = labelConnected.Location;
            pos7 = logoTab1.PointToClient(pos7);
            labelConnected.Parent = logoTab1;
            labelConnected.Location = pos7;
            labelConnected.BackColor = Color.White;

            var pos8 = labelStatusHead.Location;
            pos8 = logoTab1.PointToClient(pos8);
            labelStatusHead.Parent = logoTab1;
            labelStatusHead.Location = pos8;
            labelStatusHead.BackColor = Color.Transparent;

            var pos9 = sendData.Location;
            pos9 = logoTab1.PointToClient(pos9);
            sendData.Parent = logoTab1;
            sendData.Location = pos9;
            sendData.BackColor = Color.White;

            var pos10 = sendData.Location;
            pos10 = AccountLabel.PointToClient(pos10);
            AccountLabel.Parent = logoTab2;
            AccountLabel.Location = pos10;
            AccountLabel.BackColor = Color.Transparent;

            CleanDirectory();
        }

        public void CleanDirectory()
        {
            string[] files = Directory.GetFiles(@"C:\Users\Taylo\Desktop\csp2.net.Test\ScannerData");
            foreach (string file in files)
            {
                if (File.Exists(file))
                {
                    if (File.GetCreationTime(file) < DateTime.Now.AddDays(-30))
                    {
                        File.Delete(file);
                    }
                }
            }
        }

        bool Started = false;

        Opticon.csp2.csp2CallBackFunctionAll Csp2Callback = null;   // Make global to avoid garbage collector from disgarding the call-back

       
        public void Start()
        {
            if (!Started)
            {
                Int32 iRet;

                Trace.WriteLine("csp2.SetDebugMode(...)");
                iRet = Opticon.csp2.SetDebugMode(1);
                if (iRet != 0)
                {
                    Trace.WriteLine(" Fail!");
                }

                Int32[] ports = new Int32[100];

                int Count = Opticon.csp2.GetOpnCompatiblePorts(ports);

                Trace.WriteLine("csp2.StartPollingAll()");

                if (Csp2Callback == null)
                    Csp2Callback = new Opticon.csp2.csp2CallBackFunctionAll(CallbackFunction);

                iRet = Opticon.csp2.StartPollingAll(Csp2Callback);

                if (iRet != 0)
                {
                    Trace.WriteLine(String.Format(" Fail! {0} ", iRet));
                    return;
                }
              
                Started = true;
            }
            else
            {
                Opticon.csp2.EnablePolling();
            }
        }
        
        public void Stop()
        {
            Opticon.csp2.DisablePolling();
        }        

        private void SendData_Click(object sender, EventArgs e)
        {
            sendData.Enabled = false;
            //Create file w/ scanner data
            DataSend = true;
            CallbackFunction(ComCheck);
            if (ActNumSet != false)
            {
                //Stop main thread from blocking api
                Stop();
                //Make an attempt to send data via api and give appropriate response message           
                RunApi();
                CheckAPI();
            }
            else
            {
                var anef = new ActNumErrorForm();
                if (Application.OpenForms.OfType<ActNumErrorForm>().Count() == 1)
                    Application.OpenForms.OfType<ActNumErrorForm>().First().Close();
                anef.ShowDialog();
            }
            
            //Jumpstart main thread to life again
            Start();
            CallbackFunction(ComCheck);;
            sendData.Enabled = true;
        }

        public void RunApi()
        {
            //LOCAL QA API URL https://ws2-qa.wisvis.com/aws/scanner/test3.rb
            
            byte[] byteArray = System.IO.File.ReadAllBytes(@"../../Csp2.net.Test/Data.txt");                      
            WebRequest request = WebRequest.Create("https://ws2.wisvis.com/aws/test/order.php");
            request.Method = "POST";
            request.ContentType = "text";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            WebResponse response = request.GetResponse();
            
            Trace.WriteLine(((HttpWebResponse)response).StatusDescription);

            if ((((HttpWebResponse)response).StatusDescription) == "OK")
            {
                ApiSuccessful = true;
                ClearData = true;

                //Test Error Form
                //MessageForm.Response = "There was an error downloading \nscanner. Be sure you are connected \nto the internet. If the problem persists, \nplease call WVA Scanner Support. ";
                //MessageForm message = new MessageForm();
                //message.ShowDialog();
            }
            else
            {
                ApiSuccessful = false;
                MessageForm.Response = "There was an error downloading \nscanner. Be sure you are connected \nto the internet. If the problem persists, \nplease call WVA Scanner Support. ";
                MessageForm message = new MessageForm();
                message.ShowDialog();
            }
                           
            // Get the stream containing content returned by the server.
             dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Display the content.
            Trace.WriteLine(responseFromServer);
            // Clean up the streams.
            reader.Close();
            dataStream.Close();
            response.Close();

            NumApiTries++;
        }

        private void CheckAPI()
        {
            if (ApiSuccessful == true)
            {
                ParseDataFromApi();
            }
            else
            {
                if (NumApiTries == 1)
                    RunApi();
               else
                    RunErrorResponseForm();
            }                
        }

        private void ParseDataFromApi()
        {
            //Parse response data
            //Open api message form
            NumApiTries = 0;
        }

        private void RunErrorResponseForm()
        {
            //pull text from error log
            //open default error message form
            NumApiTries = 0;
        }

        public void ResponseForm()
        {           
                var msgForm = new MessageForm();
                if (Application.OpenForms.OfType<MessageForm>().Count() == 1)
                    Application.OpenForms.OfType<MessageForm>().First().Close();
                msgForm.ShowDialog();     
        }

        private void SetParameters()
        {
            Stop();
            PrefPB.Value = 0;
            int counter = 0;
            Int32 nParam = 0;
            byte[] szString = new byte[100];
            Int32 nMaxLength = 1;
            try
            {
                foreach (ParamInfo p in Description)
                {
                        ComCheck = Opticon.csp2.Init(ComCheck);
                        int line = Convert.ToInt32(File.ReadLines(@"../../Csp2.net.Test/TextDocs/" + TxtReader).Skip(counter).Take(1).First());
                        szString[0] = (byte)line;
                        nParam = p.ParamNumber;
                        ComCheck = Opticon.csp2.SetParam(nParam, szString, nMaxLength);
                        counter++;
                        PrefPB.Value++;                    
                }
                if (counter == 50)
                {
                    var prefComp = new PrefCompleted();
                    if (Application.OpenForms.OfType<MessageForm>().Count() == 1)
                        Application.OpenForms.OfType<MessageForm>().First().Close();
                    prefComp.ShowDialog();
                }
            }
            catch
            {
                var errorMessageForm = new ErrorMessage();
                if (Application.OpenForms.OfType<MessageForm>().Count() == 1)
                    Application.OpenForms.OfType<MessageForm>().First().Close();
                errorMessageForm.Show();
            }
            PrefPB.Value = 0;
            Start();         
        }

        // Scan UPC only button (tab2)
        private void button2_Click(object sender, EventArgs e)
        {
            TxtReader = "ReadUPC_Only.txt";
            SetParameters();
        }

        // Scan OPC only button (tab2)
        private void button3_Click(object sender, EventArgs e)
        {
            TxtReader = "ReadStockOnly.txt";
            SetParameters();
        }

        // Scan both UPC and OPC button (tab2)
        private void button4_Click(object sender, EventArgs e)
        {
            TxtReader = "ReadStock+UPC.txt";
            SetParameters();
        }

        private void LLContact_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://www.wisvis.com");
            }
            catch
            {
                Trace.WriteLine(e);
            }
        }

        private void LLViewCart_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://www.wisvis.com");
            }
            catch
            {
                Trace.WriteLine(e);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
         {                         
            AccountNumber = AccountTextBox.Text;        
            using (System.IO.StreamWriter file =
              new System.IO.StreamWriter(@"C:\Users\Taylo\Desktop\WorkStuff\KeychainSynchBackup\KeychainSynch3\Csp2.net.Test\TextDocs\Account_Number.txt"))
            {
                file.WriteLine(AccountNumber);
            }
            AccountTextBox.Text = ("Set to: " + AccountNumber);
        }

    }

    public class ParamInfo
    {
        public ParamInfo(String Par, int Num)
        {
            _Parameter = Par;
            _ParamNumber = Num;
            _ParamValue = -1;
        }
        private String _Parameter;
        public String Parameter
        {
            get { return _Parameter; }
            set { _Parameter = value; }
        }

        private int _ParamNumber;
        public int ParamNumber
        {
            get { return _ParamNumber; }
            set { _ParamNumber = value; }
        }

        private int _ParamValue;
        public int ParamValue
        {
            get { return _ParamValue; }
            set { _ParamValue = value; }
        }
    }
}