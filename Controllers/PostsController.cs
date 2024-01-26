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
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly ArticleContext _context;
        public PostsController(ArticleContext context){
            _context = context;
            _context.Database.EnsureCreated();
        }

        [HttpGet]
        public async Task<ActionResult> GetAllPosts(){
            return Ok(await _context.Posts.ToArrayAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetPost( int id ){
            var post = await _context.Posts.FindAsync(id);
            if(post == null){
                return NotFound();
            }
            return Ok(post);
        }
    }
}