using backend.person.modellibrary.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace backend.person.datalibrary.DataContext;

public interface IPersonDataContext
{
    public DbSet<Person> Person { get; set; }
    public DbSet<Produto> Produto { get; set; }
    
    public DbSet<Marca> Marca { get; set; }
    
    public DbSet<ProdutoCategoria> ProdutoCategoria { get; set; }
    
    public DbSet<Cor> Cor { get; set; }
    
   public DbSet<ProdutoCor> ProdutoCor { get; set; }
   public DbSet<EstoqueEvento> EstoqueEvento { get; set; }
   public DbSet<EstoqueMovimento> EstoqueMovimento { get; set; }
   
   public DbSet<OrdemCompraStatus> OrdemCompraStatus { get; set; }
   
   public DbSet<OrdemCompra> OrdemCompra { get; set; }
   public DbSet<OrdemCompraLog> OrdemCompraLog { get; set; }
   
   public DbSet<Pedido> Pedido { get; set; }
   
   public DbSet<PedidoStatus> PedidoStatus { get; set; }
   
   public DbSet<PedidoItens> PedidoItens { get; set; }
   
   
    
    IDbContextTransaction? CurrentTransaction();
    IDbContextTransaction? BeginTransaction();
    bool IsInMemory();
    void Commit(IDbContextTransaction transaction);
    void RollBack(IDbContextTransaction transaction);
    void Migrate();
    void LockTable(string tableName);
    int SaveChanges();
}