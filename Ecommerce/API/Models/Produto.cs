using System;
using System.Data;

namespace API.Models;
   //Características|Atributos|Propriedades
    //id, nome, preco, quantidade

    // private string id;
    //private string nome;
    // private double preco;
    // private int quantidade;

    // public string getNome()
    // {
    //  return nome;
    //}

    //public void setNome(string nome)
    //{
    //     this.nome = nome;
    //}

    //C#
    //? Eu sei que pode dar problema/mas não estamos resoveldo o problema.

public class Produto
{
 
    public Produto()
    {
        Id = Guid.NewGuid().ToString();
        CriadoEm = DateTime.Now;
    }

    public string Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public int Quantidade { get; set; }
    public double Preco { get; set; }
    public DateTime CriadoEm { get; set; }


}
