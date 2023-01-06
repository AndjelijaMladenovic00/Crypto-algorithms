using CriptoClient.CryptoService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CriptoClient
{
    public partial class FoursquareParallel : Form, IServerCallback
    {
        private bool encrypt;
        private ServerClient proxy;
        string fileName;

        public FoursquareParallel(bool enc)
        {
            encrypt = enc;
            InitializeComponent();
            proxy = new ServerClient(new InstanceContext(this));
            if (enc) actionButton.Text = "Encrypt";
            else actionButton.Text = "Decrypt";
        }

        public void Message(byte[] msg)
        {
            string txt = Encoding.ASCII.GetString(msg);

            string path = Path.GetDirectoryName(fileName);
            if (encrypt)
                path += "\\encoded.txt";
            else path += "\\decoded.txt";

            File.WriteAllText(path, txt);

            MessageBox.Show("File has been saved as " + path);
        }

        private void FileDialog_FileOk(object sender, CancelEventArgs e)
        {
            fileName = FileDialog.FileName;
            fileTbx.Text = fileName;
        }

        private void fileButton_Click_1(object sender, EventArgs e)
        {
            FileDialog.ShowDialog();
        }

        private void actionButton_Click_1(object sender, EventArgs e)
        {
            if (fileName == null)
            {
                MessageBox.Show("You need to select a file!");
            }
            else
            {
                byte[] data = File.ReadAllBytes(fileName);
                if (encrypt)
                    proxy.FourSquareParallelEncrypt(data);
                else
                    proxy.FourSquareParallelDecrypt(data);
            }
        }
    }
}
