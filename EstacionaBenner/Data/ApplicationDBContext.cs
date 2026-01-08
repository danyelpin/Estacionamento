using EstacionaBenner.Models;
using Microsoft.EntityFrameworkCore;

namespace EstacionaBenner.Data;

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
    { }
    
    public DbSet<TabelaPreco> TabelaPreco { get; set; }
    public DbSet<RegistroEstacionamento> RegistrosEstacionamento { get; set; }
}