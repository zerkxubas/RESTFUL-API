using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace apiproject.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Sku { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }

        [Required]
        // A product belongs to category so we have the category id as well.
        public int CategoryId { get; set; }
        
        [JsonIgnore]
        public virtual Category? Category { get; set;}
    }
}