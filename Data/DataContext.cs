using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Data
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }
    // lista de propriedades que serão transformadas em tabela no banco de dados
    public DbSet<Produto> Produtos { get; set; }
  }
}