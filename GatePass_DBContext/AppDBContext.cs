using GatePass_DBContext.SeedData;
using GatePass_Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GatePass_DBContext
{
    public class AppDBContext: IdentityDbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        public DbSet<Company> company { get; set; }
        public DbSet<UserCompanyModel> userCompany { get; set; }
        public DbSet<UserNamingModel> userFullName { get; set; }
        public DbSet<ItemsModel> items { get; set; }
        public DbSet<dispatchItems> dispatchItems { get; set; }

        public DbSet<VehicleTypeModel> vehicleTypes { get; set; }
        public DbSet<InwardGatePassModel> inwardGatePass { get; set; }
        public DbSet<UOMModel> UOM { get; set; }
        public DbSet<OutwardGatePassModel> outwardGatePass { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
           builder.Seed();
        }
    }
}
