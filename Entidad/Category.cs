using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace Entidad
{
    public class Category
    {
        // [Key]
        public int CategoryId { get; set; }
        public String Name { get; set; }
        public IList<Presentation> Presentations { get; set; }
        public IList<Product> Products { get; set; }
    }
}