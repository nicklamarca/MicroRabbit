using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using MicroRabbit.Transfer.Data.Context;

namespace MicroRabbit.Transfer.Data.Context
{
    public class TransferDbContextFactory : IDesignTimeDbContextFactory<TransferDbContext>
    {
        public TransferDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TransferDbContext>();

            // Specify the connection string used for design-time operations.
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TransferDB;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new TransferDbContext(optionsBuilder.Options);
        }
    }
}
