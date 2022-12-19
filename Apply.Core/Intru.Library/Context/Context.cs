using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Intru.Library
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
            
        }        

        public DbSet<Wallet> Wallet { get; set; }
        public DbSet<Cards> Card { get; set; }
        public DbSet<CategoryCard> CategoryCard { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<UsuarioWallet> UsuarioWallet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var conn = "server=localhost; port=3306; database=fitwallet; user=root; password=Fantasmatico2";
            //"server=sql529.main-hosting.eu; port=3306; database=u922704232_fitwallet; user=u922704232_wesley; password={Programador}2; Persist Security Info=False";            

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=FitWallet;Trusted_Connection=True;");
                /*optionsBuilder.UseMySql(conn,
                        ServerVersion.AutoDetect(conn));*/
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
