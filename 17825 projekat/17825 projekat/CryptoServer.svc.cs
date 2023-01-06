using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace _17825_projekat
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class CryptoServer : IServer
    {
        private ICallback callback;

        private uint OTPKey;

        private string FoursquareTopRight;
        private string FoursquareBottomLeft;

        private ulong OFBInitVector;
        private ulong OFBKey;

        private uint delta = 0x9e3779b9;
        private uint[] XXTEAkey = { 0x4a9b1c13, 0x78acd01f, 0x123abc9d, 0x1f5d9a86 };
        public CryptoServer()
        {
            callback = OperationContext.Current.GetCallbackChannel<ICallback>();
            OTPKey = 0x42AF70CD;

            FoursquareTopRight = "ZGPTFOIHMUWDRCNYKEQAXVSBL";
            FoursquareBottomLeft = "MFNBDCRHSAXYOGVITUEWLQZKP";

            OFBInitVector = 0x6A9F18CDE703AD6F;
            OFBKey = 0x5A1D8C0E3AC8F12D;
        }

        public void FourSquareDecrypt(string text)
        {
            string txt = text;

            string result = "";

            for (int i = 0; i < txt.Length; i += 2)
            {
                int index = 0;
                while (FoursquareTopRight[index] != txt[i]) index++;

                int x2 = index % 5;
                int y1 = index / 5;

                index = 0;
                while (FoursquareBottomLeft[index] != txt[i + 1]) index++;

                int x1 = index % 5;
                int y2 = index / 5;

                char resultingChar = (char)('a' + y1 * 5 + x1);
                if (resultingChar > 'i') resultingChar++;
                result += resultingChar;

                resultingChar = (char)('a' + y2 * 5 + x2);
                if (resultingChar > 'i') resultingChar++;
                result += resultingChar;
            }

            callback.Message(Encoding.Unicode.GetBytes(result));
        }

        public void FourSquareEncrypt(string text)
        {
            string txt = text.ToLower();
            if (txt.Length % 2 == 1) txt += 'x';

            string result = "";


            for (int i = 0; i < txt.Length; i += 2)
            {
                int value = (int)txt[i] - (int)'a';
                if (txt[i] >= 'j') value--; //jer se j izbacuje

                int x1 = value % 5;
                int y1 = value / 5;

                value = (int)txt[i + 1] - (int)'a';
                if (txt[i + 1] >= 'j') value--; //jer se j izbacuje

                int x2 = value % 5;
                int y2 = value / 5;

                result += FoursquareTopRight[y1 * 5 + x2];
                result += FoursquareBottomLeft[y2 * 5 + x1];
            }

            callback.Message(Encoding.Unicode.GetBytes(result));
        }

        public void OTPDecrypt(byte[] data)
        {
            OTPEncrypt(data);
        }

        public void OTPEncrypt(byte[] data)
        {
            uint OTPKeyCopy = OTPKey;
            BitArray dataArray = new BitArray(data);
            BitArray resultArray = new BitArray(dataArray.Length);
            bool bit;

            for (int i = 0; i < dataArray.Length; i++)
            {
                if (OTPKeyCopy >> 31 == 1)
                    bit = true;
                else bit = false;
                resultArray[i] = dataArray[i] ^ bit;

                OTPKeyCopy = (OTPKeyCopy << 1) | (((OTPKeyCopy >> 20) ^ (OTPKeyCopy >> 17) ^ (OTPKeyCopy >> 15)) & 1);
            }

            byte[] resultData = new byte[dataArray.Length / 8];
            resultArray.CopyTo(resultData, 0);

            callback.Message(resultData);
        }

        public void OFBEncrypt(byte[] data)
        {
            int encLength = data.Length - 54; //54B je header BMP fajla
            byte[] encryptionData;

            if ((data.Length - 54) % 8 != 0)//prosiruju se podaci da odgovaraju blokovima od 64b
            {
                int added = 8 - (data.Length - 54) % 8;
                encLength += added;

                encryptionData = new byte[encLength];
                Array.Copy(data, 54, encryptionData, 0, data.Length - 54);

                for (int i = 0; i < added; i++)
                {
                    encryptionData[data.Length - 54 + i] = 0;
                }
            }
            else
            {
                encryptionData = new byte[encLength];
                Array.Copy(data, 54, encryptionData, 0, data.Length - 54);
            }

            byte[] result = new byte[encLength + 54];
            Array.Copy(data, 0, result, 0, 54); //kopiranje header-a

            ulong InitV = OFBInitVector;

            ulong[] ptxtData = new ulong[encLength / 8];
            Buffer.BlockCopy(encryptionData, 0, ptxtData, 0, encLength);

            for (int i = 0; i < ptxtData.Length; i ++)
            {
                ulong plainTxt = ptxtData[i];

                ulong c = InitV ^ OFBKey;
                c = (c << 3) | (c >> 61); //cirkularna rotacija vektora da ne bi svaki drugi bajt kodirala cistim inicijalizacionim vektorom
                InitV = c;
                c ^= plainTxt;

                byte[] cBytes = BitConverter.GetBytes(c);
                Array.Copy(cBytes, 0, result, 54 + i*8, 8);
            }

            byte[] finalResult = new byte[data.Length];
            Array.Copy(result, 0, finalResult, 0, data.Length);

            callback.Message(finalResult);
        }

        public void OFBDecrypt(byte[] data)
        {
            OFBEncrypt(data);
        }

        public void SHA_1(byte[] data)
        {
            uint h0 = 0x67452301;
            uint h1 = 0xEFCDAB89;
            uint h2 = 0x98BADCFE;
            uint h3 = 0x10325476;
            uint h4 = 0xC3D2E1F0;

            int diff = (data.Length * 8 + 1) % 512;
            if (diff <= 448) diff = 448 - diff;
            else diff = 896 - diff; //podaci su u bajtovima, i posto je ostatak deljenja 448b, to je 56B, prvi ima 1 na najvisoj poziciji, ostali su 0
            int addedB = (diff + 1) / 8;

            byte[] pData = new byte[data.Length + addedB + 8]; //8 je za duzinu poruke koja je 64b
            Array.Copy(data, 0, pData, 0, data.Length);

            pData[data.Length] = 0x80;

            for (int i = 1; i < addedB; i++)
                pData[data.Length + i] = 0x00;

            ulong length = Convert.ToUInt64(data.Length) ;
            byte[] lengthData = BitConverter.GetBytes(length);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(lengthData);

            Array.Copy(lengthData, 0, pData, pData.Length - 8, 8);

            uint[] w = new uint[80];

            int blockNum = pData.Length / 64; //512 je 2^9 (to je 64B), a 8 je 2^3, sa 8 se mnozi da se dobiju bitovi, a sa 512 se deli da se dobiju blokovi

            uint[] prepData = new uint[blockNum* 16];
            Buffer.BlockCopy(pData, 0, prepData, 0, pData.Length);

            for (int i = 0; i < blockNum; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    w[j] = prepData[i * 16 + j];
                }

                for (int j = 16; j < 80; j++)
                {
                    w[j] = (w[j - 3] ^ w[j - 8] ^ w[j - 14] ^ w[j - 16]) << 1;
                }

                uint a = h0;
                uint b = h1;
                uint c = h2;
                uint d = h3;
                uint e = h4;

                uint f, k, temp;

                for (int j = 0; j < 80; j++)
                {
                    if (j < 20)
                    {
                        f = (b & c) | ((~b) & d);
                        k = 0x5A827999;

                    }
                    else if (j < 40)
                    {
                        f = b ^ c ^ d;
                        k = 0x6ED9EBA1;
                    }
                    else if (j < 60)
                    {
                        f = (b & c) | (b & d) | (c & d);
                        k = 0x8F1BBCDC;
                    }
                    else
                    {
                        f = b ^ c ^ d;
                        k = 0xCA62C1D6;
                    }

                    temp = (a << 5) + f + e + k + w[j];
                    e = d;
                    d = c;
                    c = b << 30;
                    b = a;
                    a = temp;
                }

                h0 += a;
                h1 += b;
                h2 += c;
                h3 += d;
                h4 += e;
            }

            string result = Convert.ToString(h0, 16);
            result += Convert.ToString(h1, 16);
            result += Convert.ToString(h2, 16);
            result += Convert.ToString(h3, 16);
            result += Convert.ToString(h4, 16);

            callback.Message(Encoding.ASCII.GetBytes(result));
        }

        public void XXTEAEncrypt(byte[] data)
        {
            int wordNum = data.Length / 4;
            if (data.Length % 4 != 0) wordNum++;
            if (wordNum % 2 != 0) wordNum++;


            uint[] encData = new uint[wordNum];
            encData[wordNum - 1] = 0;
            encData[wordNum - 2] = 0;

            Buffer.BlockCopy(data, 0, encData, 0, data.Length);
            
            byte[] result = new byte[wordNum * 4];

            uint y, z, sum, e, MX;
            int p, rounds, n = 2;
            int blockNum = wordNum / 2;


            for(int i=0;i<blockNum;i++)
            {
                uint[] block = new uint[2];
                block[0] = encData[i * 2];
                block[1] = encData[i * 2 + 1];

                rounds = 6 + 52 / n;
                sum = 0;
                z = block[n - 1];

                do
                {
                    sum += delta;
                    e = (sum >> 2) & 3;

                    for(p=0;p<n-1;p++)
                    {
                        y = block[p + 1];
                        MX = ((z >> 5 ^ y << 2) + (y >> 3 ^ z << 4)) ^ ((sum ^ y) + (XXTEAkey[(p & 3) ^ e] ^ z));
                        z = block[p] += MX;
                    }

                    y = block[0];
                    MX = ((z >> 5 ^ y << 2) + (y >> 3 ^ z << 4)) ^ ((sum ^ y) + (XXTEAkey[(p & 3) ^ e] ^ z));
                    z = block[n-1] += MX;
                }
                while (--rounds != 0);

                byte[] b0 = BitConverter.GetBytes(block[0]);
                Array.Copy(b0, 0, result, i * 8, 4);

                byte[] b1 = BitConverter.GetBytes(block[1]);
                Array.Copy(b1, 0, result, i * 8 + 4, 4);
            }

            callback.Message(result);
        }

        public void XXTEADecrypt(byte[] data)
        {
            int wordNum = data.Length / 4;
            if (data.Length % 4 != 0) wordNum++;
            if (wordNum % 2 != 0) wordNum++;

            uint[] decData = new uint[wordNum];
            decData[wordNum - 1] = 0;
            decData[wordNum - 2] = 0;

            Buffer.BlockCopy(data, 0, decData, 0, data.Length);

            int p, rounds, n = 2, blockNum = wordNum / 2;
            uint y, z, sum, MX, e;

            byte[] result = new byte[wordNum*4];

            for(int i=0;i<blockNum;i++)
            {
                uint[] block = new uint[2];
                block[0] = decData[i * 2];
                block[1] = decData[i * 2 + 1];

                rounds = 6 + 52 / n;
                sum = ((uint)rounds) * delta;
                y = block[0];

                do
                {
                    e = (sum >> 2) & 3;

                    for(p = n-1; p>0; p--)
                    {
                        z = block[p - 1];
                        MX = ((z >> 5 ^ y << 2) + (y >> 3 ^ z << 4)) ^ ((sum ^ y) + (XXTEAkey[(p & 3) ^ e] ^ z));
                        y = block[p] -= MX;
                    }

                    z = block[n - 1];
                    MX = ((z >> 5 ^ y << 2) + (y >> 3 ^ z << 4)) ^ ((sum ^ y) + (XXTEAkey[(p & 3) ^ e] ^ z));
                    y = block[0] -= MX;
                    sum -= delta;
                }
                while (--rounds != 0);

                byte[] b0 = BitConverter.GetBytes(block[0]);
                Array.Copy(b0, 0, result, i * 8, 4);

                byte[] b1 = BitConverter.GetBytes(block[1]);
                Array.Copy(b1, 0, result, i * 8 + 4, 4);
            }

            callback.Message(result);
        }

        public void FourSquareParallelEncrypt(byte[] file)
        {
            FourSquareParallelisation fsq = new FourSquareParallelisation(FoursquareTopRight, FoursquareBottomLeft, file);

            callback.Message(Encoding.ASCII.GetBytes(fsq.Encrypt()));
        }

        public void FourSquareParallelDecrypt(byte[] file)
        {
            FourSquareParallelisation fsq = new FourSquareParallelisation(FoursquareTopRight, FoursquareBottomLeft, file);

            callback.Message(Encoding.ASCII.GetBytes(fsq.Decrypt()));
        }
    }
}
