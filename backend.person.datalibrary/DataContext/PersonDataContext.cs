using backend.person.modellibrary.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace backend.person.datalibrary.DataContext;

public class PersonDataContext : DbContext, IPersonDataContext
{
    public DbSet<Person> Person { get; set; } = null!;
    public DbSet<Produto> Produto { get; set; }
    public PersonDataContext(DbContextOptions options) : base(options)
    {

    }

    public IDbContextTransaction? CurrentTransaction()
    {
        return Database.CurrentTransaction;
    }

    public IDbContextTransaction? BeginTransaction()
    {
        if (Database.IsInMemory()) return null;

        if (Database.CurrentTransaction != null) return Database.CurrentTransaction;

        return Database.BeginTransaction();
    }

    public bool IsInMemory()
    {
        return Database.IsInMemory();
    }

    public void Commit(IDbContextTransaction transaction)
    {
        transaction.Commit();
    }

    public void RollBack(IDbContextTransaction transaction)
    {
        transaction.Rollback();
    }

    public void Migrate()
    {
        Database.Migrate();
    }

    public void LockTable(string tableName)
    {
        Database.ExecuteSql($"SELECT TOP 1 1 FROM {tableName} WITH (TABLOCKX, HOLDLOCK)");
    }
}