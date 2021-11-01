using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSale.DataBase.Security
{
    public class ContextFactorySecurity : IDesignTimeDbContextFactory<SecurityDbContext>
    {
        public SecurityDbContext CreateDbContext(string[] args)
        {
            var parentDirectory = Directory.GetParent(Directory.GetCurrentDirectory());
            var directories = parentDirectory.GetDirectories("AppSale");
            string apiDirectory = directories[0].FullName;

            var builderConfiguration = new ConfigurationBuilder()
                .SetBasePath(apiDirectory)
                .AddJsonFile("appsettings.json");
            var configuration = builderConfiguration.Build();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var builder = new DbContextOptionsBuilder<SecurityDbContext>();
            builder.UseSqlServer(connectionString);

            return new SecurityDbContext(builder.Options);
        }
    }
}
