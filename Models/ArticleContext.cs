using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace apiproject.Models
{
    public class ArticleContext : DbContext
    {
        public ArticleContext(DbContextOptions<ArticleContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Posts)
                .WithOne(a => a.Category)
                .HasForeignKey(a => a.CategoryId);
            modelBuilder.ArticleSeed();
        }
        
        public DbSet<Post> Posts { get; set; }
    }
}