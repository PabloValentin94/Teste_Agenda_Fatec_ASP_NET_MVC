using Microsoft.EntityFrameworkCore;

using Teste_Agenda_Fatec.Models;

namespace Teste_Agenda_Fatec.Data
{

    public class ApplicationDBContext : DbContext
    {

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) {  }

        public DbSet<Models.Agendamento> Agendamentos { get; set; }

        public DbSet<Models.Bloco> Blocos { get; set; }

        public DbSet<Models.Cargo> Cargos { get; set; }

        public DbSet<Models.Equipamento> Equipamentos { get; set; }

        public DbSet<Models.Item> Itens { get; set; }

        public DbSet<Models.Sala> Salas { get; set; }

        public DbSet<Models.Usuario> Usuarios { get; set; }

    }

}