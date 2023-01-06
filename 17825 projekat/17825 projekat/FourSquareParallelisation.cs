using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using System.IO;
using System.Text;

namespace _17825_projekat
{
    public class FourSquareParallelisation
    {
        private string FoursquareTopRight;
        private string FoursquareBottomLeft;
        private string line;
        private string modifiedLine;
        private string result;
        StreamReader file;
        private static Semaphore sRead, sWrite, sDo, sDone;
        public FourSquareParallelisation(string fsqtr, string fsqbl, byte[] fileData)
        {
            FoursquareTopRight = fsqtr;
            FoursquareBottomLeft = fsqbl;

            result = "";

            file = new StreamReader(new MemoryStream(fileData), Encoding.ASCII);

            sRead = new Semaphore(1, 1);
            sWrite = new Semaphore(0, 1);
            sDo = new Semaphore(0, 1);
            sDone = new Semaphore(0, 1);
        }

        public void ReadFile()
        {

            while(true)
            {
                sRead.WaitOne();

                line = file.ReadLine();
                
                if(line==null)
                {
                    line = "-1"; //ovo je nemoguce u foursquare, pa cu da ga iskoristim za prekid niti
                    sDo.Release(1);
                    break;
                }

                line = line.Replace('j', 'i');
                line = line.Replace('J', 'i');
                char[] c = (line.ToCharArray()).Where(ch => (ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z')).ToArray();
                line = new string(c);

                sDo.Release(1);
            }
        }

        public void WriteToResult()
        {
            while (true)
            {
                sWrite.WaitOne();

                sRead.Release();

                if (modifiedLine == "-1")
                {
                    sWrite.Release(1);
                    sDone.Release(1);
                    break;
                }

                result += modifiedLine;
            }
        }

        public void EncryptLine()
        {
            while(true)
            {
                sDo.WaitOne();

                if (line == "-1")
                {
                    modifiedLine = "-1";
                    sWrite.Release(1);
                    sDo.Release(1);
                    break;
                }

                modifiedLine = "";

                if (line.Length % 2 == 1) line += 'x';
                line = line.ToLower();

                for (int i = 0; i < line.Length; i += 2)
                {
                    int value = (int)line[i] - (int)'a';
                    if (line[i] >= 'j') value--; //jer se j izbacuje

                    int x1 = value % 5;
                    int y1 = value / 5;

                    value = (int)line[i + 1] - (int)'a';
                    if (line[i + 1] >= 'j') value--; //jer se j izbacuje

                    int x2 = value % 5;
                    int y2 = value / 5;

                    modifiedLine += FoursquareTopRight[y1 * 5 + x2];
                    modifiedLine += FoursquareBottomLeft[y2 * 5 + x1];
                }

                modifiedLine += "\n";//ovo je dodavano da bi dekripcija po linijama imala smisla. Moze i bez ovoga, ali ce kod dekriptovanja onda da bude samo jedna linija

                sWrite.Release(1);
            }
        }

        public void DecryptLine()
        {
            while(true)
            {
                sDo.WaitOne();

                if (line == "-1")
                {
                    modifiedLine = "-1";
                    sWrite.Release(1);
                    sDo.Release(1);
                    break;
                }

                modifiedLine = "";

                for (int i = 0; i < line.Length; i += 2)
                {
                    int index = 0;
                    while (FoursquareTopRight[index] != line[i]) index++;

                    int x2 = index % 5;
                    int y1 = index / 5;

                    index = 0;
                    while (FoursquareBottomLeft[index] != line[i + 1]) index++;

                    int x1 = index % 5;
                    int y2 = index / 5;

                    char resultingChar = (char)('a' + y1 * 5 + x1);
                    if (resultingChar > 'i') resultingChar++;
                    modifiedLine += resultingChar;

                    resultingChar = (char)('a' + y2 * 5 + x2);
                    if (resultingChar > 'i') resultingChar++;
                    modifiedLine += resultingChar;
                }

                modifiedLine += "\n";

                sWrite.Release(1);
            }
        }

        public string Encrypt()
        { 
            sRead = new Semaphore(1, 1);
            sWrite = new Semaphore(0, 1);
            sDo = new Semaphore(0, 1);
            sDone = new Semaphore(0, 1);

            Thread read = new Thread(ReadFile);
            Thread encrypt = new Thread(EncryptLine);
            Thread write = new Thread(WriteToResult);
            Thread current = Thread.CurrentThread;

            read.Start();
            encrypt.Start();
            write.Start();

            sDone.WaitOne();

            read.Join();
            encrypt.Join();
            write.Join();

            sDone.Release(); 

            return result;
        }

        public string Decrypt()
        {
            sRead = new Semaphore(1, 1);
            sWrite = new Semaphore(0, 1);
            sDo = new Semaphore(0, 1);
            sDone = new Semaphore(0, 1);

            Thread read = new Thread(ReadFile);
            Thread decrypt = new Thread(DecryptLine);
            Thread write = new Thread(WriteToResult);
            Thread current = Thread.CurrentThread;

            read.Start();
            decrypt.Start();
            write.Start();

            sDone.WaitOne();

            read.Join();
            decrypt.Join();
            write.Join();

            sDone.Release();

            return result;
        }
    }
}