using Microsoft.EntityFrameworkCore;
using Examen.Models;


namespace Examen.Context
{
    public class AplicacionContext: DbContext
    {
        public AplicacionContext(DbContextOptions<AplicacionContext> options)
       : base(options) { }
        public DbSet<Albanil> Albanil { get; set; }
        public DbSet<Empresa> Empresa { get; set; }


    }
}
