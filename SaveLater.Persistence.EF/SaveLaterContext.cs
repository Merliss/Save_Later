using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SaveLater.Domain.Common;
using SaveLater.Domain.Entities;
using SaveLater.Persistence.EF.DummyData;

namespace SaveLater.Persistence.EF
{
    public class SaveLaterContext : DbContext
    {
        public SaveLaterContext(DbContextOptions<SaveLaterContext> options) : base(options)
        { }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Event> Events { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.UtcNow;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SaveLaterContext).Assembly);

            foreach (var item in DummyCategories.Get())
            {
                modelBuilder.Entity<Category>().HasData(item);
            }
            foreach (var item in DummyEvents.Get())
            {
                modelBuilder.Entity<Event>().HasData(item);
            }
            foreach (var item in DummyPosts.Get()) 
            {
                modelBuilder.Entity<Post>().HasData(item);

                //modelBuilder.Entity<Post>(b =>
                //{
                //    b.HasData(item);
                //});
            }
        }

    }
}
