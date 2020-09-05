using System.Threading;
using System.Threading.Tasks;
using Lemoras.DataProvider.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Lemoras.DataProvider
{
    public class Context : DbContext
    {
        private readonly string _schema;

        public Context(DbContextOptions options, string schema)
            : base(options)
        {
            this._schema = schema;
        }

        public void Add(object obj)
        {
            base.Add(obj);
        }

        public void Remove(object obj)
        {
            base.Remove(obj);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (_schema != null)
            {
                modelBuilder.HasDefaultSchema(_schema);
            }
            modelBuilder.ConvertAllToSnakeCase();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            //if (Database.IsInMemory())
            //{
            //    cancellationToken.ThrowIfCancellationRequested();
            //}

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
