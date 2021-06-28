using System;
using System.Collections.Generic;
using Entidad;

namespace api_movil.Models
{

    public class InvoiceImputModel
    {

        public DateTime SaleDate { get; set; }
        public string  IdClient { get; set; }
        public  IList<InvoiceDetailInputModel> InvoiceDetails { get; set; } 

        public InvoiceImputModel()
        {
            this.InvoiceDetails = new List<InvoiceDetailInputModel>();
        }
    }

    public class InvoiceViewModel: InvoiceImputModel
    {
        public int InvoiceId { get; set; }
        public decimal Subtotal { get; set; }
        public decimal TotalIva { get; set; }
        public decimal Total { get; set; }
        public Client Client { get; set; }
        public InvoiceViewModel()
        {
            
        }

        public InvoiceViewModel(Invoice invoice)
        {
            InvoiceId = invoice.InvoiceId;
            Subtotal = invoice.Subtotal;
            TotalIva = invoice.TotalIva;
            Total = invoice.Total;
            Client = invoice.Client;
            SaleDate = invoice.SaleDate;
            foreach (InvoiceDetail detail in invoice.InvoiceDetails) {
                InvoiceDetails.Add(new InvoiceDetailViewModel(detail));
            }

        }
    }
}