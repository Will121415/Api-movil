using System;
using DAl;
using Entidad;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class Response<g>
    {

        public g Object { get; set; }
        public String Menssage { get; set; }
        public bool Error { get; set; }

        public Response(g _object)
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

    public class ResponseAll<g>
    {

        public List<g> List { get; set; }
        public String Menssage { get; set; }
        public bool Error { get; set; }

        public ResponseAll(List<g> _object)
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