using System;
using DAl;
using Entidad;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class ProductService{

        private readonly PulpFreshContext _context;
        public ProductService(PulpFreshContext context){
            _context = context;
        }


        public String guardarProducto(Product product){

            try
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return "Todo bien";
            }
            catch (System.Exception error)
            {
                
                return "error men:"+error;
            }
            
        }
    }
}