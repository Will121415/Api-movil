using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidad
{
    public class InvoiceDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDetail { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitValue { get; set; }
        public int QuantityProduct { get; set; }
        public float Discount { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TolalDetail { get; set; }

        public  Product Product { get; set; }
        
        
        
        public InvoiceDetail()
        {
            
        }

        public InvoiceDetail(Product _product, int quantity, float discount, decimal price)
        {
            Product = _product;
            UnitValue = price;
            QuantityProduct = quantity;
            Discount = discount;
            CalculateTotalDetail();
        }

       
        public void CalculateTotalDetail()
        {
            
            TolalDetail = Decimal.Round((((decimal)QuantityProduct) * Product.Unit_Price) * (1 - ((decimal)Discount/100)), 1);
        }


        public decimal CalculateIva()
        {
            return TolalDetail * ((decimal)Product.Iva  / (decimal)100);
        }
    }
}