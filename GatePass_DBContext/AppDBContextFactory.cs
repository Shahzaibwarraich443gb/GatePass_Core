using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GatePass_DBContext
{
    public class AppDBContextFactory: IDesignTimeDbContextFactory<AppDBContext>
    {

        public AppDBContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();
            var optionsBuilder = new DbContextOptionsBuilder<AppDBContext>();
            //optionsBuilder.UseSqlServer("Data Source=DESKTOP-MLF45SC\\SQLEXPRESS; Initial Catalog=GatePassDB; Integrated Security=SSPI; User Id=Test; Password=Test@123;Trust Server Certificate=true");
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("GatePassDBConnection"), x => x.MigrationsAssembly("GatePass_Migrations"));
            return new AppDBContext(optionsBuilder.Options);
        }
    }
}
