using System;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

//AppDataContext é a classe que representa o DB na aplicação
//1 - Criar a erença da classe DbContext
//2 - Criar os atributos que vão representar as tabelas do Banco de Dados
//3 - Configurar as informações do seu Banco de Dados

//Entity Framework : Code First
//1 - Implementou a herança da classe DbContext.
//2 - Criou as propriedades que vão informar quais as classes vão virar tabela no banco.
//3 - Configurar qual o banco utilizado e a string de conexão.
public class AppDataContext : DbContext
{
    public DbSet<Produto> Produtos { get; set; }
    
    public DbSet<Categoria> Categorias { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Ecommerce.db");
    }
}
