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
    public class CateogryController : ControllerBase
    {
        private readonly CategoryService _categoryService;
        private readonly PresentationService _PresentationService;

        
        public CateogryController( PulpFreshContext _context)
        {
            _categoryService = new CategoryService(_context);
            _PresentationService = new PresentationService (_context);
        }


        // Post: api/Category
        [HttpPost]
        public ActionResult<CategoryViewModel> Post(CategoryInputModel categoryInputModel)
        {
            Category category = MapearCategory(categoryInputModel);
            var response = _categoryService.save(category);
            return (response.Error==false)? Ok(response.Object):  BadRequest(response.Menssage);
        }

        private Category MapearCategory(CategoryInputModel categoryInputModel)
        {
           var category = new Category
           {
            Name = categoryInputModel.Name,
            Presentations = _PresentationService.SelectPresentations(categoryInputModel.PresentationsIds).List
           };
           return category;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CategoryViewModel>> AllCategory()
        {
            var response = _categoryService.AllCategory();

            if (response.List == null) return BadRequest(response.Menssage);

            var categories = response.List.Select(c => new CategoryViewModel(c));

            return Ok(categories);

        }
    }
}

