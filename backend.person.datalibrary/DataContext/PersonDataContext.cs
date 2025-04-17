using backend.person.modellibrary.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace backend.person.datalibrary.DataContext;

public class PersonDataContext : DbContext, IPersonDataContext
{
    public DbSet<Person> Person { get; set; } = null!;
    public DbSet<Produto> Produto { get; set; }
    
    public DbSet<Marca> Marca { get; set; }
    
    public DbSet<ProdutoCategoria> ProdutoCategoria { get; set; }
    
    
    public DbSet<EstoqueEvento> EstoqueEvento { get; set; }
    
    public DbSet<EstoqueMovimento> EstoqueMovimento { get; set; }
    
    public DbSet<OrdemCompraStatus> OrdemCompraStatus { get; set; }
    
    public DbSet<OrdemCompra> OrdemCompra { get; set; }
    public DbSet<OrdemCompraLog> OrdemCompraLog { get; set; }
    public DbSet<Pedido> Pedido { get; set; }
    
    public DbSet<PedidoStatus> PedidoStatus { get; set; }
    
    public DbSet<PedidoItens> PedidoItens { get; set; }
    
    public DbSet<PedidoLog> PedidoLog { get; set; }
    
    public DbSet<Material> Material { get; set; }
    
    public DbSet<Cliente> Cliente { get; set; }
   
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