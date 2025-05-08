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

        // Definindo os valores padrões para alguns campos das tabelas do banco de dados MySQL.

        protected override void OnModelCreating(ModelBuilder model_builder)
        {

            // Booleanos.

            model_builder.Entity<Bloco>().Property(bloco => bloco.Ativo).HasDefaultValue(true);

            model_builder.Entity<Cargo>().Property(cargo => cargo.Ativo).HasDefaultValue(true);

            model_builder.Entity<Equipamento>().Property(equipamento => equipamento.Ativo).HasDefaultValue(true);

            model_builder.Entity<Sala>().Property(sala => sala.Ativo).HasDefaultValue(true);

            model_builder.Entity<Usuario>()
                         .Property(usuario => usuario.Administrador).HasDefaultValue(false);

            model_builder.Entity<Usuario>()
                         .Property(usuario => usuario.Ativo).HasDefaultValue(true);

            // Textos.

            model_builder.Entity<Agendamento>().Property(agendamento => agendamento.Situacao).HasDefaultValue("Pendente");

            model_builder.Entity<Bloco>().Property(bloco => bloco.Descricao).HasDefaultValue("Nenhuma descrição.");

            model_builder.Entity<Equipamento>().Property(equipamento => equipamento.Descricao).HasDefaultValue("Nenhuma descrição.");

            model_builder.Entity<Sala>().Property(sala => sala.Descricao).HasDefaultValue("Nenhuma descrição.");

            model_builder.Entity<Sala>().Property(sala => sala.Status_Atual).HasDefaultValue("Disponível");

        }

    }

}