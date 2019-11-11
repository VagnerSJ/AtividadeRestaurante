using Atividade_PeDeFava.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Atividade_PeDeFava.Context
{
    public class RestauranteContext : DbContext
    {
        private readonly ILoggerFactory _loggerFactory;
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<ConsumoCliente> ConsumoCliente { get; set; }
        public DbSet<Refeicao> Refeicao { get; set; }
        public DbSet<R_Refeicao_ConsumoCliente> R_Refeicao_ConsumoCliente { get; set; }

        public RestauranteContext() { }

        public RestauranteContext(DbContextOptions<RestauranteContext> options, ILoggerFactory loggerFactory) : base(options)
        {
            _loggerFactory = loggerFactory;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(_loggerFactory);
        }
    }
}
