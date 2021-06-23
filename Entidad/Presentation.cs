using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace Entidad
{
    public class Presentation
    {
        // [Key]
        public int PresentationId { get; set; }
        public String Measure { get; set; }
        public String Name { get; set; }

        //realcion
        public List<Category> Categories { get; set; }


    }
}