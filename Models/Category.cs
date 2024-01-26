using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiproject.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public virtual List<Product>? Products { get; set; }
        public virtual List<Post>? Posts { get; set; }
    }
}