using MAIOCEAN.Models;
using Microsoft.EntityFrameworkCore;

namespace MAIOCEAN.Persistencia
{
    public class MAIOCEANDbContext : DbContext
    {
        public DbSet<Especie> Especie { get; set; }
        public DbSet<Imagem> Imagem { get; set; }
        public DbSet<Regiao> Regiao { get; set; }
        public DbSet<Robo> Robo { get; set; }
        public DbSet<Temperatura> Temperatura { get; set;}

        public MAIOCEANDbContext(DbContextOptions<MAIOCEANDbContext> options) : base(options) 
        { 
        
        }
    }
}
