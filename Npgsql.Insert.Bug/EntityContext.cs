using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Npgsql.Insert.Bug
{
    public class EntityContext : DbContext
    {
        private readonly string _connectionString;

        public DbSet<DocumentWrapper<SomeSpecificDocument>> SomeSpecificDocumentss { get; set; }

        public EntityContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
        }
    }

    public sealed class SomeSpecificDocumentsAccessor
    {
        private readonly string _connectionString;

        public SomeSpecificDocumentsAccessor(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(IEnumerable<SomeSpecificDocument> entities)
        {
            using (var context = new EntityContext(_connectionString))
            {
                context.SomeSpecificDocumentss.AddRange(entities.Select(e => e.Wrap()));
                context.SaveChanges();
            }
        }
    }
}
