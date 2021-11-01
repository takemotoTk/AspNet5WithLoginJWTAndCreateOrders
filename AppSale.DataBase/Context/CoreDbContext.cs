using AppSale.Domain.Adapters;
using AppSale.Domain.Adapters.Base;
using AppSale.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AppSale.DataBase.Context
{
    public class CoreDbContext : DbContext, IUnitOfWorkRepository
    {
        public CoreDbContext(DbContextOptions<CoreDbContext> options) : base(options)
        {
        }

        //DBSets
        public DbSet<Order> Order { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<TeamDelivery> TeamDelivery { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Customer> Customer { get; set; }

        public async Task<int> Commit(CancellationToken cancellationToken = new CancellationToken())
        {
            var result = await base.SaveChangesAsync(cancellationToken);
            return result;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CoreDbContext).Assembly);
            var entities = modelBuilder.Model.GetEntityTypes();
            var foreignKeys = entities
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in foreignKeys)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            base.OnModelCreating(modelBuilder);
        }
    }
}
