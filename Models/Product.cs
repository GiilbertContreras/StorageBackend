using System;
using System.ComponentModel.DataAnnotations;

namespace StorageBackend.Models
{
    public class Product
    {
        public int id_product { get; set; }
        [Required]
        public string name_product { get; set; }
        [Required]
        public string status_product { get; set; }
        
        public string defective_product { get; set; }

    }
}
