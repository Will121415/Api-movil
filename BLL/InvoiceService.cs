using System;
using System.Linq;
using DAl;
using Entidad;
using Microsoft.EntityFrameworkCore;

namespace BLL
{
    public class InvoiceService
    {
         private readonly PulpFreshContext _context;
         private readonly ProductService _ProductService;
        public InvoiceService(PulpFreshContext freshContext)
        {
            _context = freshContext;
            _ProductService= new ProductService(_context);
        }
        public Response<Invoice> Save(Invoice invoice)
        {
            try {

                Invoice newInvoice = new Invoice( invoice.Client);
                foreach (InvoiceDetail detail in invoice.InvoiceDetails)
                {
                    if(detail.Product.QuantityStock-detail.QuantityProduct<0)
                        return new Response<Invoice>("No hay suficiente stock");
                    newInvoice.AddInvoiceDetails(detail.Product,detail.QuantityProduct, detail.Discount,detail.UnitValue);
                    detail.Product.discountQuantityStock(detail.QuantityProduct);
                    _context.Products.Update(detail.Product);
                }
                newInvoice.CalculateTotal();
                _context.Invoices.Add(newInvoice);
                _context.SaveChanges();
                return new Response<Invoice>(newInvoice);
            } catch (Exception e) {
                return new Response<Invoice>($"Error del aplicacion: {e.Message}");
            }
        }

        public ResponseAll<Invoice> AllInvoices()
        {
            try {
                var invoices = _context.Invoices.Include(I=>I.Client)
                    .Include(d=>d.InvoiceDetails)
                    .ThenInclude(InvoiceDetails => InvoiceDetails.Product)
                    .ToList();
                return new ResponseAll<Invoice>(invoices);
            } catch (Exception e ) {
                return new ResponseAll<Invoice>($"Error del aplicacion: {e.Message}");
            }
        }

        public Response<int> Count()
        {
            try {
                int count =  _context.Invoices.Count();
                return new Response<int>(count);
            } catch (Exception e) {
                return new Response<int>($"Error del aplicacion: {e.Message}");
            }
        }
    }
}