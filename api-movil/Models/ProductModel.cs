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
        public decimal Unit_Price { get; set; }
        public int QuantityStock  { get; set; }
        public String State { get; set; }
        public int Iva { get; set; }
        public string Description { get; set; }
        public String CategoryId { get; set; }
        public IList<String> PresentationsIds { get; set; }
    }

    public class ProductViewModel : ProductInputModel {

        public Category Category { get; set; }
        public int ProductId { get; set; }
        public IList<Presentation> Presentations { get; set; }
        public ProductViewModel  (){}
        public ProductViewModel (Product product){
            
            ProductId = product.ProductId;
            Name = product.Name;
            Unit_Price = product.Unit_Price;
            Category = product.Category;
            QuantityStock = product.QuantityStock;
            State = product.State;
            Presentations = product.Presentations;
            
        }
    }
}