using CriptoClient.CryptoService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CriptoClient
{
    public partial class Foursquare : Form, IServerCallback
    {
        private ServerClient proxy;
        private bool encrypt;
        public Foursquare(bool enc)
        {
            encrypt = enc;
            proxy = new ServerClient(new InstanceContext(this));
            InitializeComponent();
            if (enc) actionButton.Text = "Encrypt";
            else actionButton.Text = "Decrypt";
        }

        public void Message(byte[] msg)
        {
            string text = System.Text.Encoding.Unicode.GetString(msg);

            ResultBox.Text = text;
        }

        private void actionButton_Click(object sender, EventArgs e)
        {
            string text = InputBox.Text;

            if (text == "")
            {
                MessageBox.Show("You need to enter some text!");
                return;
            }
            else
            {
                text = text.Replace('j', 'i');
                text = text.Replace(" ", string.Empty);
                text = text.Replace("\n", string.Empty);
                text = text.Replace("\t", string.Empty);

                if (encrypt)
                    proxy.FourSquareEncrypt(text);
                else
                    proxy.FourSquareDecrypt(text);
            }
        }
    }
}
