using System;

namespace API.Models
{
  public class Produto 
  {
    public Produto() 
    {
      CriadoEm = DateTime.Now;
    }

    public int Id { get; set; }
    public string Nome { get; set; }
    public double Preco { get; set; }
    public string Descricao { get; set; }
    public int Quantidade { get; set; } 
    public DateTime CriadoEm { get; set; }

    public override string ToString()
    { //base é o super do java
      return $"Nome: {Nome} | Preço: {Preco.ToString("C2")}";
    }
  }
}