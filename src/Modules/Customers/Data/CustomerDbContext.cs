using BuildingBlocks.EFCore;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Customers.Data;

public class CustomerDbContext : AppDbContextBase
{
    public CustomerDbContext(DbContextOptions<CustomerDbContext> options, IHttpContextAccessor httpContextAccessor) : base(
    options, httpContextAccessor)
    {
    }

    public DbSet<Customers.Models.Customer> Customers => Set<Customers.Models.Customer>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
}
