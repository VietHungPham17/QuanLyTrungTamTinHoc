namespace DALayer.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DALayer.DBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DALayer.DBContext context)
        {
            //This method will be called after migrating to the latest version.

            //You can use the DbSet<T>.AddOrUpdate() helper extension method
            //to avoid creating duplicate seed data.E.g.

            //context.Employees.AddOrUpdate(
            //  new DTLayer.Employee
            //  {
            //      EmployeeID = "Admin",
            //      EmployeeName = "Administrator",
            //      BirthDay = DateTime.Now,
            //      MajorID = "MJO00000"
            //  }
            //);

            //context.Accounts.AddOrUpdate(
            //    new DTLayer.Account
            //    {
            //        Username = "Admin",
            //        Password = "Admin"
            //    }
            //  );

            //context.Centers.AddOrUpdate(
            //   new DTLayer.Center
            //   {
            //       CenterID = "CTR00001",
            //       CenterName = "HC Software Corporation"
            //   }
            // );

            //context.Majors.AddOrUpdate(
            //   new DTLayer.Major
            //   {
            //       MajorID = "MJO00000",
            //       MajorName = "Quản Trị"
            //   }
            // );
        }
    }
}
