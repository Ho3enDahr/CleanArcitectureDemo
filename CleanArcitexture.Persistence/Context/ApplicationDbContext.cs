using CleanArcitexture.Domain.Common;
using CleanArcitexture.Domain.Common.Interfaces;
using CleanArcitexture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CleanArcitexture.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IDomainEventDispatcher _dispatcher;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDomainEventDispatcher dispatcher) : base(options)
        {
            _dispatcher = dispatcher;
        }
        public DbSet<Club> Clubs =>Set<Club>();
        public DbSet<Player> Players => Set<Player>();
        public DbSet<Country> Countries => Set<Country>();
        public DbSet<Stadium> Stadiums => Set<Stadium>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            if (_dispatcher == null) return result;

            var entitiesWithEvents = ChangeTracker.Entries<BaseEntity>()
                .Select(e => e.Entity)
                .Where(e => e.DomainEvents.Any())
                .ToArray();

            await _dispatcher.DispatchAndClearEvents(entitiesWithEvents);

            return result;
        }
    }
}
