using System;
using DAl;
using Entidad;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BLL
{
    public class ProductService{

        private readonly PulpFreshContext _context;
        public ProductService(PulpFreshContext context){
            _context = context;
        }


       public Response<Product> save(Product product){

            try
            {
                
                _context.Products.Add(product);
                _context.SaveChanges();
                return new Response<Product>(product);
            }
            catch (System.Exception error)
            {
                
                return new Response<Product>("Error:"+error);
            }
            
        }
        public ResponseAll<Product> AllProducts( ){

            try
            {
                List<Product> procts = _context.Products.Include(P=>P.Presentations).Include( c => c.Category).ToList();
                return new ResponseAll<Product>(procts);
            }
            catch (System.Exception error)
            {
                
                return new ResponseAll<Product>("Error:"+error);
            }
            
        }

        public Response<Product> FindById(int _productId){
            try
            {
                Product procts = _context.Products.Where(P=>P.ProductId==_productId).FirstOrDefault();
                return new Response<Product>(procts);
            }
            catch (System.Exception error)
            {
                
                return new Response<Product>("Error:"+error);
            }
        }

        public Response<Product> ChangeStatus(int productId)
        {
            try{

                Product oldProduct = _context.Products.Where(P=>P.ProductId==productId).FirstOrDefault();

                if(oldProduct != null)
                {
                    oldProduct.State = (oldProduct.State == "Active") ? "Inactive": "Active";
                    _context.Products.Update(oldProduct);
                    _context.SaveChanges();
                }
                return new Response<Product>(oldProduct);
            }
            catch (Exception e)
            {
                return new Response<Product>($"Error de la Aplicación: {e.Message}");
            }
        }


    }
}