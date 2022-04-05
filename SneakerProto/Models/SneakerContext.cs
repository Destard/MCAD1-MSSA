
using Microsoft.EntityFrameworkCore;

namespace SneakerProto.Models
{
    public class SneakerContext : DbContext
    {
        public DbSet<Sneaker> Sneakers { get; set; }
        public SneakerContext(DbContextOptions options) : base(options)
        {
        }
    }
}
