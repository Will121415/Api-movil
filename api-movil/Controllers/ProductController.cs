using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidad;
using DAl;
using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using api_movil.Models;

namespace api_movil.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly ProductService _productService;

        
        public ProductoController( PulpFreshContext _context)
        {
            _productService = new ProductService(_context);
        }


        // Post: api/Producto
        [HttpPost]
        public ActionResult<ProductViewModel> Post(ProductInputModel productoInputModel)
        {
            Product producto = MapearProducto(productoInputModel);
            var response = _productService.guardarProducto(producto);
            Console.WriteLine(response);
            return null;
        }

        private Product MapearProducto(ProductInputModel productoInputModel)
        {
            var product = new Product
            {
                Name = productoInputModel.Name

            };
            
            
            return product;
        }
    }
}