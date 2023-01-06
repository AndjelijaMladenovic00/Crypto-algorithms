using CriptoClient.CryptoService;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;

namespace CriptoClient
{
    public partial class OTP : Form, IServerCallback
    {
        private bool encrypt;
        private ServerClient proxy;
        string fileName;
        byte[] fileData;
        byte[] receivedData;
        public OTP(bool enc)
        {
            encrypt = enc;
            InitializeComponent();
            proxy = new ServerClient(new InstanceContext(this));
            if (enc) actionButton.Text = "Encrypt";
            else actionButton.Text = "Decrypt";
        }

        public void Message(byte[] msg)
        {
            this.receivedData = msg;
            SaveTxtFile();
        }

        private void fileButton_Click(object sender, EventArgs e)
        {
            OTPFileDialog.ShowDialog();
        }

        private void OTPFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            fileName = OTPFileDialog.FileName;
            fileTbx.Text = fileName;
        }

        private void ReadTxtFile()
        {
            string txt = File.ReadAllText(fileName);

            txt = txt.Replace(" ", string.Empty);
            txt = txt.Replace("\n", string.Empty);
            txt = txt.Replace("\t", string.Empty);
            txt = txt.Replace("\r", string.Empty);

            fileData = System.Text.Encoding.Unicode.GetBytes(txt);
        }

        private void SaveTxtFile()
        {
            if(receivedData==null)
            {
                MessageBox.Show("An error occured!");
                return;
            }

            string txt = System.Text.Encoding.Unicode.GetString(receivedData);

            string path = Path.GetDirectoryName(fileName);
            if (encrypt)
                path += "\\encoded.txt";
            else path += "\\decoded.txt";

            File.WriteAllText(path, txt);

            MessageBox.Show("File has been saved as " + path);
        }

        private void actionButton_Click(object sender, EventArgs e)
        {
            if(fileName==null)
            {
                MessageBox.Show("You need to select a file!");
            }
            else
            {
                ReadTxtFile();

                if (encrypt)
                    proxy.OTPEncrypt(fileData);
                else
                    proxy.OTPDecrypt(fileData);
            }
        }

    }
}
