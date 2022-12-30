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
    public partial class SHA_1 : Form, IServerCallback
    {
        private string fileName;
        private ServerClient proxy;
        public SHA_1()
        {
            proxy = new ServerClient(new InstanceContext(this));
            InitializeComponent();
        }

        public void Message(byte[] msg)
        {
            string text = System.Text.Encoding.ASCII.GetString(msg);

            hashTbx.Text = text;
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            SHAFileDialog.ShowDialog();
        }

        private void SHAFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            fileName = SHAFileDialog.FileName;
            fileTbx.Text = fileName;
        }

        private void hashButton_Click(object sender, EventArgs e)
        {
            if(fileName ==  null)
            {
                MessageBox.Show("You need to select a file!");
                return;
            }

            byte[] data = File.ReadAllBytes(fileName);

            proxy.SHA_1(data);
        }
    }
}
