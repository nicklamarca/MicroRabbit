using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroRabbit.Banking.Data.Context
{
    public class BankingDbContextFactory : IDesignTimeDbContextFactory<BankingDbContext>
    {
        public BankingDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BankingDbContext>();

            // Specify the connection string used for design-time operations.
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BankingDB;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new BankingDbContext(optionsBuilder.Options);
        }
    }
}
