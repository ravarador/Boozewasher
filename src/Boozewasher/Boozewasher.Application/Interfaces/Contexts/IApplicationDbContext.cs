using Boozewasher.Domain.Entities;
using Boozewasher.Domain.Entities.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Boozewasher.Application.Interfaces.Contexts
{
    public interface IApplicationDbContext
    {
        IDbConnection Connection { get; }
        bool HasChanges { get; }

        EntityEntry Entry(object entity);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        DbSet<Product> Products { get; set; }
        DbSet<Attendance> Attendances { get; set; }
        DbSet<Branch> Branches { get; set; }
        DbSet<Employee> Employees { get; set; }
        DbSet<Item> Items { get; set; }
        DbSet<Service> Services { get; set; }
        DbSet<Transaction> Transactions { get; set; }
        DbSet<Vehicle> Vehicles { get; set; }

    }
}