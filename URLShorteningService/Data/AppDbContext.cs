using Microsoft.EntityFrameworkCore;
using URLShorteningService.Models;

namespace URLShorteningService.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Url> Urls { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}
