namespace Teste
{
    using System.Data.Entity;

    public class DataContext : DbContext
    {
        public DataContext()
            : base("name=DataContext")
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
    }
}