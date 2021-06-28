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
        private readonly ProductService _productService;
        private readonly ClientService _clientService;
        public InvoiceController(PulpFreshContext freshContext)
        {
            _invoiceService = new InvoiceService(freshContext);
            _productService = new ProductService (freshContext);
            _clientService = new ClientService(freshContext);
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
            Client client = _clientService.SearchById(invoiceImput.IdClient).Object;
            invoice.SaleDate = invoiceImput.SaleDate;
            invoice.Client =  client;

            foreach (InvoiceDetailInputModel detailModel in invoiceImput.InvoiceDetails) {

                InvoiceDetail detail =  new InvoiceDetail();
                var _product = _productService.FindById(detailModel.IdProduct).Object; 
                detail.QuantityProduct = detailModel.QuantityProduct;
                detail.Discount = detailModel.Discount;
                detail.Product = _product;
                invoice.InvoiceDetails.Add(detail);
            }

            return invoice;
        }

        private Product MapProduct(ProductInputModel productModel)
        {
            Product product = new Product();
            
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