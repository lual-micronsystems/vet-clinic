using vet_clinic.Application.Common.Interfaces;
using vet_clinic.Domain.Common;
using vet_clinic.Domain.Entities;
using vet_clinic.Infrastructure.Identity;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace vet_clinic.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        //private readonly ICurrentUserService _currentUserService;
        private readonly IDateTime _dateTime;
        //private readonly IDomainEventService _domainEventService;

        public ApplicationDbContext() { }

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options,
            // IOptions<OperationalStoreOptions> operationalStoreOptions,
            // ICurrentUserService currentUserService,
            //IDomainEventService domainEventService,
            IDateTime dateTime) : base(options)
        {
            // _currentUserService = currentUserService;
            //_domainEventService = domainEventService;
            _dateTime = dateTime;
        }

        public DbSet<TodoItem> TodoItems { get; set; }

        public DbSet<TodoList> TodoLists { get; set; }

        public DbSet<User> Owners { get; set; }

        public DbSet<Pet> Pets { get; set; }

        public DbSet<Visit> Visits { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<AuditableEntity> entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        //entry.Entity.CreatedBy = _currentUserService.UserId;
                        entry.Entity.Created = _dateTime.Now;
                        break;

                    case EntityState.Modified:
                        //entry.Entity.LastModifiedBy = _currentUserService.UserId;
                        entry.Entity.LastModified = _dateTime.Now;
                        break;
                }
            }

            var result = await base.SaveChangesAsync(cancellationToken);

            //await DispatchEvents();

            return result;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

        //private async Task DispatchEvents()
        //{
        //    while (true)
        //    {
        //        var domainEventEntity = ChangeTracker.Entries<IHasDomainEvent>()
        //            .Select(x => x.Entity.DomainEvents)
        //            .SelectMany(x => x)
        //            .Where(domainEvent => !domainEvent.IsPublished)
        //            .FirstOrDefault();
        //        if (domainEventEntity == null) break;

        //        domainEventEntity.IsPublished = true;
        //        await _domainEventService.Publish(domainEventEntity);
        //    }
        //}
    }
}
