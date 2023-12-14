using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansProjeServer.Core.GeneralReturn
{
    public class GeneralReturnType<T> where T : class
    {
        public bool Success { get; }
        public string Message { get; }
        public T Data { get; }


        public GeneralReturnType(T data, bool success, string message)
        {
            Message = message;
            Data = data;
            Success = success;
        }

    }
}
