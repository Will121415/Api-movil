using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Entidad
{
    public class Invoice
    {
        [Key]
        public int InvoiceId{ get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Subtotal { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalIva { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }
        [DataType(DataType.Date)]  
        [DisplayFormat(DataFormatString="{0:yyyy-MM-dd}", ApplyFormatInEditMode=true)] 
        public DateTime SaleDate { get; set; }
        
        public  Client Client { get; set; }

        [Column(TypeName= "nvarchar(4)")]
        [ForeignKey("IdInvoice")]
        public  IList<InvoiceDetail> InvoiceDetails { get; set; } 

        public Invoice() {
            InvoiceDetails = new List<InvoiceDetail>();
        }

        public Invoice( Client _Client)
        {
            Client = _Client;
            SaleDate = DateTime.Now; 
            InvoiceDetails = new List<InvoiceDetail>();
        }

        public void AddInvoiceDetails(Product product, int quantity, float discount, decimal price)
        {
            InvoiceDetail invoiceDetail = new InvoiceDetail(product, quantity, discount, price);
            InvoiceDetails.Add(invoiceDetail);
        }

        public void CalculateSubtotal()
        {
            Subtotal = InvoiceDetails.Sum(d => d.TolalDetail);
        }

        public void CalcularTotalIva()
        {
            TotalIva = 0.0m;
            foreach (var item in this.InvoiceDetails)
            {
                this.TotalIva +=  item.CalculateIva();
            }
        }

        public void CalculateTotal()
        {
            this.CalculateSubtotal();
            this.CalcularTotalIva();
           
            Total = Subtotal + TotalIva ;
        }
    }
}