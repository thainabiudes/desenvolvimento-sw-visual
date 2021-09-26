using Microsoft.AspNetCore.Mvc;
using API.Models;
using API.Data;
using System.Collections.Generic;
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
    public  ProdutoController(DataContext context)
    {
      _context = context;
    }
    // POST: api/produto
    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateAsync([FromBody] Produto produto)
    {
      await _context.Produtos.AddAsync(produto);
      await _context.SaveChangesAsync(); //após o que o método objetiva fazer, se tiver várias ações dentro, só salva na última ação
      return Created("", produto);
    }

    [HttpGet]
    [Route("list")]
    public async Task<IActionResult> ListAsync()
    {
      return Ok(await _context.Produtos.ToListAsync());
    }

    //GET: getById
    [HttpGet]
    [Route("getById/{id}")]
    // para tratar quando não acha IActionResult
    // quando for usar async, convençõ pede para colocar no nome do método
    public async Task<IActionResult> GetByIdAsync([FromRoute] int id) //([FromRoute] int id, [FromBody] para o que tem body) ex put
    {
      // Console.WriteLine($"Id: { id }");
      Produto produto = await _context.Produtos.FindAsync(id); //_context = banco de dados, Produtos = nossa tabela, .oQueQueremosFazer
      if (produto != null) return Ok(produto);
      return NotFound();
    }

    [HttpDelete]
    [Route("delete/{name}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] string name)
    {
      //firstdefault retorna o primeiro elemento com base na expressão lambda
      Produto produto = await _context.Produtos.FirstOrDefaultAsync(produto => produto.Nome == name);
      _context.Produtos.Remove(produto);
      await _context.SaveChangesAsync();
      return Ok(produto);
    }

    [HttpPut]
    [Route("update")]
    public async Task<IActionResult> UpdateAsync([FromBody] Produto produto)
    {
      Produto prod = await _context.Produtos.FirstOrDefaultAsync(prod => prod.Id == produto.Id);
      prod.Nome = produto.Nome;
      prod.Descricao = produto.Descricao;
      prod.Preco = produto.Preco;
      prod.Quantidade = produto.Quantidade;
      _context.Produtos.Update(prod);
      await _context.SaveChangesAsync();
      return Ok(prod);
    }
  }
}