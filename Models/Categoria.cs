using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace API.Models
{
  public class Categoria
  {
    public Categoria() => CriadoEm = DateTime.Now;
    public int Id { get; set; }
    public string Nome { get; set; }

    [JsonIgnore]
    public List<Produto> Produtos { get; set; }
    public DateTime CriadoEm { get; set; }
  }
}