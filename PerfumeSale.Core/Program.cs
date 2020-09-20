using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using PerfumeSale.Core.Concrete.EntityFrameworkCore.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace PerfumeSale.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<PsDatabaseContext>
    {
        public PsDatabaseContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<PsDatabaseContext>();
            var connectionString = "Server=(localdb)\\mssqllocaldb;Database=PsDB;Trusted_Connection=True;MultipleActiveResultSets=true;";
            builder.UseSqlServer(connectionString);
            return new PsDatabaseContext(builder.Options);
        }
    }
}
