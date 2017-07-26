namespace BackEnd.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using BackEnd.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<BackEnd.Models.BackEndContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

       
        protected override void Seed(BackEnd.Models.BackEndContext context)
        {
            context.Customers.AddOrUpdate(x => x.ID,
                new Customer() { ID = 1, Name = "Customer 1" },
                new Customer() { ID = 2, Name = "Customer 2" },
                new Customer() { ID = 3, Name = "Customer 3" }
                );

            context.CustomerContacts.AddOrUpdate(x => x.ID,
                new CustomerContact()
                {
                    ID = 1,
                    Name = "CC 1",
                    Email = "cc1@gmail.com",
                    ContactNumber = "0121230001",

                    CustomerID = 1
                },
                new CustomerContact()
                {
                    ID = 2,
                    Name = "CC 2",
                    Email = "cc2@gmail.com",
                    ContactNumber = "0121230002",

                    CustomerID = 1
                },
                new CustomerContact()
                {
                    ID = 3,
                    Name = "CC 3",
                    Email = "cc3@gmail.com",
                    ContactNumber = "0121230003",

                    CustomerID = 2
                },
                new CustomerContact()
                {
                    ID = 4,
                    Name = "CC 4",
                    Email = "cc4@gmail.com",
                    ContactNumber = "0121230004",

                    CustomerID = 3
                }
                );
        }
    }
}
