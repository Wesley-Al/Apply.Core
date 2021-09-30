using Microsoft.EntityFrameworkCore;

namespace Intru.Library
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<Wallet> Wallet { get; set; }
        public DbSet<Cards> Card { get; set; }        
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<UsuarioWallet> UsuarioWallet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var conn = "server=sql529.main-hosting.eu; port=3306; database=u922704232_apply; user=u922704232_wesley; password={Programador}2; Persist Security Info=False";
            //optionsBuilder.UseSqlServer("Password={Programador};Persist Security Info=True;User ID=Wesley;Initial Catalog=Intru;Data Source=DESKTOP-C3Q3K9Q");

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(conn,
                        ServerVersion.AutoDetect(conn));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
