using PhascoalottoDesafio.Dominio.Aggregates.ConfigurationAgg;
using PhascoalottoDesafio.Dominio.Aggregates.DebtAgg;
using PhascoalottoDesafio.Dominio.Aggregates.DebtInstallmentAgg;
using PhascoalottoDesafio.Infraestrutura.Base;
using PhascoalottoDesafio.Infraestrutura.UnitOfWork.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore.Storage;

namespace PhascoalottoDesafio.Infraestrutura.UnitOfWork
{
    public class DbUnitOfWork : DbContext, IQueryableUnitOfWork
    {
        public IConfigurationRoot ConfigurationRoot { get; }
        private string _connectionString;
        private IDbContextTransaction _transaction = null;

        public DbSet<Configuration> Configuration { get; set; }
        public DbSet<Debt> Debt { get; set; }
        public DbSet<DebtInstallment> DebtInstallment { get; set; }

        public DbUnitOfWork()
        {
            string jsonFile = "appsettings-infra.json";

            ConfigurationRoot = new ConfigurationBuilder()
                .AddJsonFile(jsonFile, optional: false)
                .Build();

            _connectionString = ConfigurationRoot.GetConnectionString("PhascoalottoDesafio");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(_connectionString);
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<TEntity> CreateSet<TEntity>()
            where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public new void Attach<TEntity>(TEntity item)
            where TEntity : class
        {
            base.Entry(item).State = EntityState.Unchanged;
        }

        public void SetModified<TEntity>(TEntity item)
            where TEntity : class
        {
            base.Entry(item).State = EntityState.Modified;
        }

        public void DeleteObject<TEntity>(TEntity item)
            where TEntity : class
        {
            base.Entry(item).State = EntityState.Deleted;
        }

        public void ApplyCurrentValues<TEntity>(TEntity original, TEntity current)
            where TEntity : class
        {
            base.Entry(original).CurrentValues.SetValues(current);
        }

        public void Commit()
        {
            base.SaveChanges();
        }

        public void CommitAndRefreshChanges()
        {
            bool saveFailed = false;

            do
            {
                try
                {
                    base.SaveChanges();

                    saveFailed = false;

                }
                catch (DbUpdateConcurrencyException ex)
                {
                    saveFailed = true;

                    ex.Entries.ToList()
                              .ForEach(entry =>
                              {
                                  entry.OriginalValues.SetValues(entry.GetDatabaseValues());
                              });

                }
            } while (saveFailed);

        }

        public void RollbackChanges()
        {
            base.ChangeTracker.Entries()
                              .ToList()
                              .ForEach(entry => entry.State = EntityState.Unchanged);
        }

        public virtual void BeginTransaction()
        {
            _transaction?.Dispose();
            _transaction = base.Database.BeginTransaction();
        }

        public virtual void CommitTransaction()
        {
            _transaction?.Commit();
            _transaction?.Dispose();
            _transaction = null;
        }

        public virtual void RollbackTransaction()
        {
            _transaction?.Rollback();
        }

        public void ChangeDatabase(string connectionString)
        {
            _connectionString = connectionString;
            Database.GetDbConnection().ConnectionString = connectionString;
        }

        public string GetDatabase()
        {
            return Database.GetDbConnection().Database;
        }

        public string GetConnectionString()
        {
            return Database.GetDbConnection().ConnectionString;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.AddConfiguration(new ConfigurationEntityConfiguration());
        }
    }
}