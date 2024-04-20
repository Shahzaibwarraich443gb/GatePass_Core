using GatePass_Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GatePass_DBContext.SeedData
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleTypeModel>().HasData(
                new VehicleTypeModel
                {
                    vehicleTypeId = 1,
                    vehicleTypeName = "Car"
                },
                new VehicleTypeModel
                {
                    vehicleTypeId = 2,
                    vehicleTypeName = "Truck"
                },
                new VehicleTypeModel
                {
                    vehicleTypeId = 3,
                    vehicleTypeName = "Cargo Van"
                },
                new VehicleTypeModel
                {
                    vehicleTypeId = 4,
                    vehicleTypeName = "Bus"
                },
                new VehicleTypeModel
                {
                    vehicleTypeId = 5,
                    vehicleTypeName = "Motorcycle"
                }
            );


            modelBuilder.Entity<UOMModel>().HasData(
               new UOMModel
               {
                   unitId = 1,
                   unitName = "No's"
               },
               new UOMModel
               {
                   unitId = 2,
                   unitName = "kg"
               },
               new UOMModel
               {
                   unitId = 3,
                   unitName = "mm"
               },
               new UOMModel
               {
                   unitId = 4,
                   unitName = "cm"
               },
               new UOMModel
               {
                   unitId = 5,
                   unitName = "sqft"
               }
           );

            modelBuilder.Entity<Company>().HasData(
                new Company
                {
                    CompanyId = 1,
                    CompanyName = "Barakha Flour Mills",
                    CompanyKey = "468C8C57A591B"
                }
           );
        }
    }
}
