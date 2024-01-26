using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace apiproject.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string? Title {get; set;}
        public string? Content {get; set;}
        public bool? IsPublished {get; set;}
        
        public int CategoryId {get; set;}

        [JsonIgnore]
        public virtual Category? Category {get; set;}
    }
}