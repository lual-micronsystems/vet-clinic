using vet_clinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace vet_clinic.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<TodoList> TodoLists { get; set; }

        DbSet<TodoItem> TodoItems { get; set; }

        DbSet<User> Owners { get; set; }
        DbSet<Pet> Pets { get; set; }
        DbSet<Visit> Visits { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
