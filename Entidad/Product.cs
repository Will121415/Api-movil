using System;
using System.ComponentModel.DataAnnotations;


namespace Entidad
{
    public class Product
    {
        // [Key]
        public int ProductId { get; set; }
        public String Name { get; set; }
    }
}