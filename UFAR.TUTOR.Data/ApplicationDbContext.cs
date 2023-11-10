///<summary>
/// DbContext class representing the application's database context in the UFAR.TUTOR.Data namespace.
/// Inherits from Microsoft.EntityFrameworkCore.DbContext.
/// Contains a DbSet for the AiLog entity, allowing interaction with the AiLogs table in the database.
/// Initialized with DbContextOptions to configure the database connection.
///</summary>

using Microsoft.EntityFrameworkCore;       // Entity Framework Core for database operations

namespace UFAR.TUTOR.Data
{
    // Definition of the ApplicationDbContext class
    public class ApplicationDbContext : DbContext
    {
        // Constructor to initialize the DbContext with options for configuring the database connection
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        // DbSet property for the AiLog entity, representing the AiLogs table in the database
        public DbSet<Entities.AiLog> AiLogs { get; set; }
    }
}
