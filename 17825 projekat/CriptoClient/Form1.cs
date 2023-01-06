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
    public partial class Form1 : Form
    {
        private bool encrypt;
        private string algorithm;
        public Form1()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (actionBox.SelectedIndex ==-1 || algorithm == null)
            {
                MessageBox.Show("Select what you want to do!");
                return;
            }

            switch(algorithm)
            {
                case "One-time-pad":
                    OTP otpform = new OTP(encrypt);
                    otpform.Show();
                    break;

                case "Four-Square Cipher":
                    Foursquare fsqform = new Foursquare(encrypt);
                    fsqform.Show();
                    break;

                case "OFB":
                    OFB ofbform = new OFB(encrypt);
                    ofbform.Show();
                    break;

                case "XXTEA":
                    XXTEA xxteaform = new XXTEA(encrypt);
                    xxteaform.Show();
                    break;

                case "Four-Square Cipher - parallel":
                    FoursquareParallel fpform = new FoursquareParallel(encrypt);
                    fpform.Show();
                    break;
            }
        }

        private void actionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (actionBox.SelectedIndex == 0)
                encrypt = true;
            else encrypt = false;
        }

        private void algorithmBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            algorithm = algorithmBox.Items[algorithmBox.SelectedIndex].ToString();
        }

        private void sha1Button_Click(object sender, EventArgs e)
        {
            SHA_1 shaform = new SHA_1();
            shaform.Show();
        }
    }
}
