using Microsoft.EntityFrameworkCore;

namespace MemoryCards.DataAccess
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            
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
