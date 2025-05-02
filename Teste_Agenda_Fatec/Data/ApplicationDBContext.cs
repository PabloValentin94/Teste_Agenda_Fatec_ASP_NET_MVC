using Microsoft.EntityFrameworkCore;

namespace Teste_Agenda_Fatec.Data
{

    public class ApplicationDBContext : DbContext
    {

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) {  }
    
    }

}