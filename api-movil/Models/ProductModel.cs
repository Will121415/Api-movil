using System.Net.Http.Headers;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_movil.Models
{
      public class  ProductInputModel
    {


        public String Name { get; set; }

         
    }

    public class ProductViewModel : ProductInputModel {

        public int ProductId { get; set; }
        public ProductViewModel  (){}
        public ProductViewModel (Product product){
            
            ProductId = product.ProductId;
            Name = product.Name;
            
        }
    }
}