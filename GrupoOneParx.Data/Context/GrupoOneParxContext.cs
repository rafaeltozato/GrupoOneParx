using GrupoOneParx.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace GrupoOneParx.Data.Data
{
   public class GrupoOneParxContext : DbContext
    {
        public GrupoOneParxContext(DbContextOptions<GrupoOneParxContext> options)
            : base(options)
        {
        }

        public DbSet<Empresa> Empresa { get; set; }
    }
}
