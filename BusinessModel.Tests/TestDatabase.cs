using BusinessModel.Data;
using Microsoft.EntityFrameworkCore;

namespace BusinessModel.Tests
{
    internal class TestDatabase
    {
        private const string ConnectionString = @"Data Source=(localdb)\aspnetcorekurs;Initial Catalog=UnitTests;Integrated Security=True;Trusted_Connection=True";
        private static readonly object _lock = new();
        private static bool _dbInitialized = false;

        private DeliveryDbContext _context;

        public DeliveryDbContext Context => _context ??= CreateContext();

        public TestDatabase()
        {
            lock (_lock)
            {
                if (!_dbInitialized)
                {
                    _context = CreateContext();

                    // Sicherstellen, dass Testausgangszustand immer identisch ist
                    _context.Database.EnsureDeleted();

                    // Datenbank erstellen
                    //_context.Database.EnsureCreated();

                    // Datenbank erstellen und migrieren
                    _context.Database.Migrate();

                    _dbInitialized = true;
                }
            }
        }

        private DeliveryDbContext CreateContext()
        {
            var builder = new DbContextOptionsBuilder<DeliveryDbContext>()
                .UseSqlServer(ConnectionString);

            return new DeliveryDbContext(builder.Options);
        }
    }
}
