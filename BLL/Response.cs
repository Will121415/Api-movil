using System;
using DAl;
using Entidad;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class Response<T>
    {

        public T Object { get; set; }
        public String Menssage { get; set; }
        public bool Error { get; set; }

        public Response(T _object)
        {
            Object = _object;
            Error = false;
        }
        public Response(String _menssage)
        {
            Menssage = _menssage;
            Error = true;
        }
    }

    public class ResponseAll<T>
    {

        public IList<T> List { get; set; }
        public String Menssage { get; set; }
        public bool Error { get; set; }

        public ResponseAll(IList<T> _object)
        {
            List = _object;
            Error = false;
        }
        public ResponseAll(String _menssage)
        {
            Menssage = _menssage;
            Error = true;
        }
    }
}