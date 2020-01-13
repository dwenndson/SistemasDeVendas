using CMGBapp.Enum;
using CMGBapp.Models;
using Microsoft.EntityFrameworkCore;


namespace CMGBapp.DataContexto
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-EKS88IT; Initial Catalog=TestAPI;Integrated Security=True");
        }*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Categoria>();
        }

        public DbSet<Pedidos> Pedidos { get; set; }
        public DbSet<Produtos> Produtos { get; set; }
        public DbSet<ItensDoPedido> ItensDoPedidos { get; set; }
    }
}
