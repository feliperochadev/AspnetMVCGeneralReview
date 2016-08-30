using System.Data.Entity;
using AspnetReviewGeral.Domain;

namespace AspnetReviewGeral.Infraestruture.EFConfig
{
    public class NatterEFContext : DbContext
    {

        public NatterEFContext() : base("name=NatterLocalDBConnectionString")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Nat> Nats { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Nat Config
            var natEntityTypeConfig = modelBuilder.Entity<Nat>();
            natEntityTypeConfig.HasKey(nat => nat.Id);
            natEntityTypeConfig.Property(nat => nat.NatText)
                .IsRequired().HasMaxLength(140);
            natEntityTypeConfig.Property(nat => nat.DateCreated)
                .IsRequired();

            //User Config
            var userEntityTypeConfig = modelBuilder.Entity<User>();
            userEntityTypeConfig.HasKey(user => user.Id);
            userEntityTypeConfig.Property(user => user.ScreenName)
                .IsRequired();
            userEntityTypeConfig.Property(user => user.EmailAddress);

            modelBuilder.Configurations.Add(natEntityTypeConfig);
            modelBuilder.Configurations.Add(userEntityTypeConfig);

            base.OnModelCreating(modelBuilder);

        }
    }
}
