using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Entidad
{
    public class Client
    {
        [Key]
        [Column(TypeName= "nvarchar(11)")]
        public string ClientId { get; set; }
        [Column(TypeName= "nvarchar(130)")]
        public string Name { get; set; }
        [Column(TypeName= "nvarchar(30)")]
        public string LastName { get; set; }
        [Column(TypeName= "nvarchar(11)")]
        public string Phone { get; set; }
        [Column(TypeName= "nvarchar(50)")]
        public string Address { get; set; }
        [Column(TypeName= "nvarchar(30)")]
        public string Neighborhood { get; set; }
        [Column(TypeName= "nvarchar(20)")]
        public string City { get; set; }
        [Column(TypeName= "nvarchar(20)")]
        public string Department { get; set; }
        [Column(TypeName= "nvarchar(30)")]
        public virtual User User { get; set; } 
        public IList<Invoice> Invoice  { get; set; }
    }
}