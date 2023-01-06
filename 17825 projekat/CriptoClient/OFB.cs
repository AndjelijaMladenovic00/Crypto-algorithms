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
    public partial class OFB : Form, IServerCallback
    {
        private bool encrypt;
        private string fileName;
        private ServerClient proxy;

        public OFB(bool e)
        {
            encrypt = e;
            proxy = new ServerClient(new InstanceContext(this));
            InitializeComponent();

            if (e)
                actionButton.Text = "Encrypt";
            else
                actionButton.Text = "Decrypt";
        }

        private byte[] ReadBMP()
        {
            if(fileName==null)
            {
                MessageBox.Show("You need to select a BMP file!");
                return null;
            }

            Bitmap img = new Bitmap(fileName);

            ImageConverter converter = new ImageConverter();
            byte[] data = (byte[])converter.ConvertTo(img, typeof(byte[]));

            img.Dispose();

            return data;
        }

        private void SaveBMP(byte[] data)
        {
            string path = Path.GetDirectoryName(fileName);
            if (encrypt)
                path += "\\encoded.bmp";
            else path += "\\decoded.bmp";

            using (MemoryStream ms = new MemoryStream(data))
            {
                Bitmap img = new Bitmap(ms);
                img.Save(path, System.Drawing.Imaging.ImageFormat.Bmp);
                img.Dispose();
            }
            MessageBox.Show("File saved as " + path);
        }

        private void fileBtn_Click(object sender, EventArgs e)
        {
            fileDialog.ShowDialog();
        }

        private void fileDialog_FileOk(object sender, CancelEventArgs e)
        {
            fileName = fileDialog.FileName;
            fileTbx.Text = fileName;
        }

        private void actionButton_Click(object sender, EventArgs e)
        {
            byte[] data = ReadBMP();

            if (encrypt)
                proxy.OFBEncrypt(data);
            else
                proxy.OFBDecrypt(data);
        }

        public void Message(byte[] msg)
        {
            SaveBMP(msg);
        }
    }
}
