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
    [ServiceContract(CallbackContract = typeof(ICallback), SessionMode=SessionMode.Required)]
    public interface IServer
    {

        [OperationContract(IsOneWay = true)]
        void OTPEncrypt(byte[] data);

        [OperationContract(IsOneWay = true)]
        void OTPDecrypt(byte[] data);

        [OperationContract(IsOneWay = true)]
        void FourSquareEncrypt(string text);

        [OperationContract(IsOneWay = true)]
        void FourSquareDecrypt(string text);

        [OperationContract(IsOneWay = true)]
        void OFBEncrypt(byte[] data);

        [OperationContract(IsOneWay = true)]
        void OFBDecrypt(byte[] data);

        [OperationContract(IsOneWay = true)]
        void SHA_1(byte[] data);

        [OperationContract(IsOneWay = true)]
        void XXTEAEncrypt(byte[] data);

        [OperationContract(IsOneWay = true)]
        void XXTEADecrypt(byte[] data);

        [OperationContract(IsOneWay = true)]
        void FourSquareParallelEncrypt(byte[] file);


        [OperationContract(IsOneWay = true)]
        void FourSquareParallelDecrypt(byte[] file);
    }


  /*  [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }*/
}
