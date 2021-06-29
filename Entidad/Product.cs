using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Entidad
{
    public class Product
    {
        // [Key]
        public int ProductId { get; set; }
        public String Name { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Unit_Price { get; set; }
        public int QuantityStock  { get; set; }
        public String Image { get; set; }
        public String State { get; set; }
        public int Iva { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public IList<Presentation> Presentations { get; set; }
         //Relacion
         public int CategoryId { get; set; }

        public void discountQuantityStock(int _QuantityProduct ){
            QuantityStock=QuantityStock-_QuantityProduct;
            if(QuantityStock==0)State="Agotado";
        } 
    }
}