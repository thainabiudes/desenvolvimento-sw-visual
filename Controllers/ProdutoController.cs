using Microsoft.AspNetCore.Mvc;
using API.Models;
using API.Data;
using System.Collections.Generic;
using System.Linq;

namespace API.Controllers 
{
  [ApiController]
  [Route("api/produto")]

  public class ProdutoController : ControllerBase
  { 
    private readonly DataContext _context;
    public ProdutoController(DataContext context)
    {
      _context = context;
    }
    // POST: api/produto
    [HttpPost]
    [Route("create")]
    public Produto Post(Produto produto)
    {
      _context.Produtos.Add(produto);
      _context.SaveChanges();
      return produto;
    }

    [HttpGet]
    [Route("list")]
    public List<Produto> List()
    {
      return _context.Produtos.ToList();
    }
  }
}