using System.Collections.Generic;
using System.Linq;
using api_movil.Models;
using BLL;
using DAl;
using Entidad;
using Microsoft.AspNetCore.Mvc;

namespace api_movil.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController: ControllerBase
    {
        private readonly InvoiceService _invoiceService;
        public InvoiceController(PulpFreshContext freshContext)
        {
            _invoiceService = new InvoiceService(freshContext);
        }

        [HttpPost]
        public ActionResult<InvoiceViewModel> Post(InvoiceImputModel invoiceImput)
        {
            Invoice invoice =  MapInvoice(invoiceImput);

            var response =  _invoiceService.Save(invoice);
            if (response.Error) {
                return BadRequest(response.Menssage);
            }
            return Ok(response.Object);
        }

        private Invoice MapInvoice(InvoiceImputModel invoiceImput)
        {
            Invoice invoice = new Invoice();

            invoice.IdInvoice = invoiceImput.IdInvoice;
            invoice.Subtotal = invoiceImput.Subtotal;
            invoice.TotalIva = invoiceImput.TotalIva;
            invoice.Total = invoiceImput.Total;
            invoice.SaleDate = invoiceImput.SaleDate;
            invoice.IdClient = invoiceImput.IdClient;

            foreach (InvoiceDetailInputModel detailModel in invoiceImput.InvoiceDetails) {

                InvoiceDetail detail =  new InvoiceDetail();

                detail.IdDetail = detailModel.IdDetail;
                detail.UnitValue =detailModel.UnitValue;
                detail.QuantityProduct = detailModel.QuantityProduct;
                detail.Discount = detailModel.Discount;
                detail.TolalDetail =detailModel.TolalDetail;
                detail.IdProduct = detailModel.IdProduct;

                detail.Product  = new  Product();
                detail.Product = MapProduct(detailModel.Product);
                invoice.InvoiceDetails.Add(detail);
            }

            return invoice;
        }

        private Product MapProduct(ProductInputModel productModel)
        {
            Product product = new Product();
            
            product.ProductId = productModel.IdProduct;
            product.Name = productModel.Name;
            product.State = productModel.State;
            product.Unit_Price = productModel.Unit_Price;
            product.QuantityStock = productModel.QuantityStock;
            product.Iva = productModel.Iva;
            product.Description = productModel.Description;
            return product;
        }

        [HttpGet]
        public ActionResult<IEnumerable<InvoiceViewModel>> Get() 
        {
                var response = _invoiceService.AllInvoices();

                if (response.List == null) return BadRequest(response.Menssage);

                var invoices = response.List.Select(i => new InvoiceViewModel(i));

                return Ok(invoices);
        } 
     

        
    }
}