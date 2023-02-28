using Microsoft.EntityFrameworkCore;
using WebApiCarniceria.Entidades;

namespace WebApiCarniceria

{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Producto> Producto { get; set; }
    }
    
}
