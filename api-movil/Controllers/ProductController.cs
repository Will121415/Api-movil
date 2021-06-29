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
        private readonly CategoryService _CategoryService;
        private readonly PresentationService _PresentationService;

        
        public ProductoController( PulpFreshContext _context)
        {
            _productService = new ProductService(_context);
            _CategoryService = new CategoryService(_context);
            _PresentationService = new PresentationService (_context);
        }


        // Post: api/Producto
        [HttpPost]
        public ActionResult<ProductViewModel> Post(ProductInputModel productoInputModel)
        {
            Product producto = MapearProducto(productoInputModel);
            var response = _productService.save(producto);
            if(response.Error==false)return Ok(response.Object);
            else return BadRequest(response.Menssage);

        }

        private Product MapearProducto(ProductInputModel productoInputModel)
        {
            var product = new Product
            {
            
                Name = productoInputModel.Name,
                Unit_Price = productoInputModel.Unit_Price,
                Category = _CategoryService.Find(int.Parse(productoInputModel.CategoryId)).Object,
                QuantityStock = productoInputModel.QuantityStock,
                Image = productoInputModel.Image,
                State = productoInputModel.State,
                Description = productoInputModel.Description,
                Presentations = _PresentationService.SelectPresentations(productoInputModel.PresentationsIds).List

            };
            
            
            return product;
        }
        [HttpGet]
        public ActionResult<ProductViewModel> AllProduct()
        {
            var response = _productService.AllProducts();
            if (response.List == null) return BadRequest(response.Menssage);


            return Ok(response.List);
        }

        [HttpPut("change-status/{productId}")]
        public ActionResult<ClientViewModel> ChangeStatus(int productId)
        {
            var response =  _productService.ChangeStatus(productId);

            if (response.Object == null) return BadRequest(response.Menssage);

            return Ok(response.Object);
        }
    }
}