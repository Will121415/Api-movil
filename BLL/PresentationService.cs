using System;
using DAl;
using Entidad;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class PresentationService{

        private readonly PulpFreshContext _context;
        public PresentationService(PulpFreshContext context){
            _context = context;
        }


        public Response<Presentation> save(Presentation presentation){

            try
            {

                _context.Presentations.Add(presentation);
                _context.SaveChanges();
                return new Response<Presentation>(presentation);
            }
            catch (System.Exception error)
            {
                
                return new Response<Presentation>("Error:"+error);
            }
            
        }
        public Response<Presentation> Find(int presentationId){

            try
            {
                var _presentation = _context.Presentations.Find(presentationId);
                if(_presentation == null)return new Response<Presentation>("No se encontro ninguna presentacion");
                return new Response<Presentation>(_presentation);
            }
            catch (System.Exception error)
            {
                
                return new Response<Presentation>("Error:"+error);
            }
            
        }

        public ResponseAll<Presentation> AllProducts(){

            try
            {
                List<Presentation> presentations = _context.Presentations.ToList();
                return new ResponseAll<Presentation>(presentations);
            }
            catch (System.Exception error)
            {
                
                return new ResponseAll<Presentation>("Error:"+error);
            }
            
        }

        public ResponseAll<Presentation> SelectPresentations(IList<string> Presentations_id){
            var response = AllProducts();
            if(response.List != null){
                var Select = new List<Presentation>();
                foreach (var item in response.List)
                {
                    foreach (var id in Presentations_id)
                    {
                        if(item.PresentationId == int.Parse(id)) Select.Add(item);
                    }
                }
                return new ResponseAll<Presentation>(Select);
            }
            return null;
        }
    }
}