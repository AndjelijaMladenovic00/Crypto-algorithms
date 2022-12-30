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
    public partial class XXTEA : Form, IServerCallback
    {
        private bool encrypt;
        private ServerClient proxy;
        public XXTEA(bool enc)
        {
            encrypt = enc;
            InitializeComponent();
            if (enc)
            {
                actionButton.Text = "Encrypt";
            }
            else
            {
                actionButton.Text = "Decrypt";
            }
            proxy = new ServerClient(new InstanceContext(this));
        }

        public void Message(byte[] msg)
        {
            string txt = Encoding.Unicode.GetString(msg);
            resultTbx.Text = txt;
        }

        private void actionButton_Click(object sender, EventArgs e)
        {
            if(inputTbx.Text=="")
            {
                MessageBox.Show("You need to insert some text!");
                return;
            }

            byte[] data = Encoding.Unicode.GetBytes(inputTbx.Text.Trim());
            if(encrypt)
            {
                proxy.XXTEAEncrypt(data);
            }
            else
            {
                proxy.XXTEADecrypt(data);
            }

        }
    }
}
