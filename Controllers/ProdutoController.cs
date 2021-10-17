using Microsoft.AspNetCore.Mvc;
using API.Models;
using API.Data;
using System.Linq;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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

    // POST: api/produto/create
    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateAsync([FromBody] Produto produto)
    {
      produto.Categoria = _context.Categorias.Find(produto.CategoriaId);
      _context.Produtos.Add(produto);
      await _context.SaveChangesAsync(); //após o que o método objetiva fazer, se tiver várias ações dentro, só salva na última ação
      return Created("", produto);
    }

    // GET: api/produto/list
    [HttpGet]
    [Route("list")]
    public async Task<IActionResult> ListAsync() =>
      Ok(await _context.Produtos.Include(p => p.Categoria).ToListAsync());
  
    // GET: api/produto/getbyid/5
    [HttpGet]
    [Route("getById/{id}")]
    // para tratar quando não acha IActionResult
    // quando for usar async, convençõ pede para colocar no nome do método
    public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
    {
      Produto produto = await _context.Produtos.FindAsync(id);
      if (produto != null)
      {
        return Ok(produto);
      }
      return NotFound();
    }

    [HttpDelete]
    [Route("delete/{name}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] string name)
    {
      //firstdefault retorna o primeiro elemento com base na expressão lambda
      Produto produto = _context.Produtos.FirstOrDefault
      (
        produto => produto.Nome == name
      );
      _context.Produtos.Remove(produto);
      await _context.SaveChangesAsync();
      return Ok();
    }

    [HttpPut]
    [Route("update")]
    public async Task<IActionResult> UpdateAsync([FromBody] Produto produto)
    {
      _context.Produtos.Update(produto);
      await _context.SaveChangesAsync();
      return Ok(produto);
    }
  }
}