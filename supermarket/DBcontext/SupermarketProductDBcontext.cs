global using supermarket.EntityModel;
global using Microsoft.EntityFrameworkCore;
global using supermarket.EntityModel;


namespace supermarket.DBcontext
{
    public class SupermarketProductDBcontext: Microsoft.EntityFrameworkCore.DbContext
    {
        public SupermarketProductDBcontext(DbContextOptions<SupermarketProductDBcontext> context) : base(context)
        {

        }
        public DbSet<Supermarket> supermarkets { get; set; }
        public DbSet<Product> products { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasKey(x => x.ProductId);

            modelBuilder.Entity<Product>()
                .Property(x => x.ProductId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Supermarket>()
               .HasKey(x => x.Id);

            modelBuilder.Entity<Supermarket>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Supermarket>()
                .HasMany(x => x.Porductebi)
                .WithOne(x => x.Supermarketi)
                .HasForeignKey(x => x.SupermarketId)
                .IsRequired(false);
        }

        
    }
    
}
