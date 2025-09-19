using System;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

//AppDataContext é a classe que representa o DB na aplicação
//1 - Criar a erença da classe DbContext
//2 - Criar os atributos que vão representar as tabelas do Banco de Dados
//3 - Configurar as informações do seu Banco de Dados
public class AppDataContext : DbContext
{
    public DbSet<Produto> Produtos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Ecommerce.db");
    }
}
