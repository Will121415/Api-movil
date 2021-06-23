using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidad
{
    public class Product
    {
        // [Key]
        public int ProductId { get; set; }
        public String Name { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Unit_Price { get; set; }
        public Category Category { get; set; }
        public int QuantityStock  { get; set; }
        public String State { get; set; }
        public int Iva { get; set; }
        public string Description { get; set; }
        
        
        
        

         //Relacion
         public int CategoryId { get; set; }



//         +IdProdut:int
//         +Name:String
//         +Unit_price:Decimal
//         +Category:Category
//         +QuantityStock:int
//         +State:String
    }
}