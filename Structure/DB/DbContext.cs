using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using minimal_api.Domains.Entities;
using Microsoft.EntityFrameworkCore;

namespace minimal_api.Structure.DB
{
    public class DbContexto : DbContext
    {
        private readonly IConfiguration _configuracaoAppSettings;
        public DbContexto(IConfiguration configuracaoAppSettings)
        {
            _configuracaoAppSettings = configuracaoAppSettings;
        }
        public DbSet<Administrator> Admins {get; set;} = default!;
        public DbSet<Veiculo> Veiculos {get; set;} = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrator>().HasData(
                new Administrator {
                    Id = 1,
                    Email = "Admin@test.com",
                    Password = "123456",
                    Perfil = "Admin",
                }
            );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured){
                var stringConexao = _configuracaoAppSettings.GetConnectionString("mysql")?.ToString();
                if(!string.IsNullOrEmpty(stringConexao))
                {
                    optionsBuilder.UseMySql(stringConexao,
                    ServerVersion.AutoDetect(stringConexao)
                    );
                }
            }
            
        }
    }
}