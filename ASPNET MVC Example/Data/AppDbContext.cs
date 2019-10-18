using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace forma1Example.Models
{
    public class AppDbContext : DbContext
    {

        public DbSet<Team> Teams { get; set; }

        private static bool _created = false;

        public AppDbContext()
        {
            if (!_created)
            {
                _created = true;
                Database.EnsureDeleted();
                Database.EnsureCreated();
            }

        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                var connectionStringBuilder = new SqliteConnectionStringBuilder
                { DataSource = ":memory:" };
                var connectionString = connectionStringBuilder.ToString();

                var connection = new SqliteConnection(connectionString);

                connection.Open();

                optionsBuilder.UseSqlite(connection);
                
            }
        }
    }
}
