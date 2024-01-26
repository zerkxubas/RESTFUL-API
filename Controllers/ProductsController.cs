using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiproject.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apiproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ShopContext _context;
        public ProductsController(ShopContext context){
            _context = context;
            _context.Database.EnsureCreated();
        }

        // Normal approach to get all products.
        /**
            [HttpGet]
            public IEnumerable<Product> GetAllProducts(){
                return _context.Products.ToArray();
            }
        */

        // Second Approach to get all products.
        [HttpGet]
        public async Task<ActionResult> GetAllProducts(){
            return Ok(await _context.Products.ToArrayAsync());       
        }

        [HttpGet("{id}")]
        public ActionResult GetProduct(int id){
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
