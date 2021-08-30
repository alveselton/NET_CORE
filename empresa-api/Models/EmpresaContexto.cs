using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    public class EmpresaContexto : DbContext
    {
        public EmpresaContexto(DbContextOptions<EmpresaContexto> options) : base(options)
        {

        }

        public DbSet<Empresa> Empresas { get; set; }
    }
}