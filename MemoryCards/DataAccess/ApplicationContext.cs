using MemoryCards.Models;
using Microsoft.EntityFrameworkCore;

namespace MemoryCards.DataAccess
{
    public class ApplicationContext:DbContext
    {
        public DbSet<GameCommonSettings> GameCommonSettings { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()        // подключение lazy loading
                .UseSqlite("Data Source=app.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<EntityCommon>())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.Entity.LastChangedTime = DateTime.Now;
                        break;
                    case EntityState.Added:
                        entry.Entity.CreatedTime = DateTime.Now;
                        break;
                }
            }
            return await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
