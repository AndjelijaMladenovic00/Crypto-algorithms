using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace _17825_projekat
{
    
    public interface ICallback
    {
        [OperationContract(IsOneWay = true)]
        void Message(byte[] msg);
    }
}