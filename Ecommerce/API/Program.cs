using API.Models;
using Microsoft.AspNetCore.Mvc;

//Console.Clear();
var builder = WebApplication.CreateBuilder(args);
//Adicionar um serviço de banco de dados na aplicação
builder.Services.AddDbContext<AppDataContext>();

builder.Services.AddCors(options =>
    options.AddPolicy("Acesso Total",
    configs => configs
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod()
));

var app = builder.Build();

// Lista com Produtos fixos
List<Produto> produtos = new List<Produto>
{
    new Produto { Nome = "Notebook", Quantidade = 10, Preco = 3500.00 },
    new Produto { Nome = "Mouse", Quantidade = 50, Preco = 45.90 },
    new Produto { Nome = "Teclado", Quantidade = 30, Preco = 79.99 },
    new Produto { Nome = "Monitor", Quantidade = 15, Preco = 899.00 },
    new Produto { Nome = "Headset", Quantidade = 20, Preco = 120.50 }
};
//Funcionalidades
//Requisições
// - Endereço/URL
// - Método HTTP
// - Dados:rota (URL) e corpo (opcional)

//Respostas

//Métodos HTTP
//GET – Recupera dados do servidor (sem alterar o estado).
//POST – Envia dados ao servidor para criar um novo recurso.
//PUT – Atualiza completamente um recurso existente no servidor.
//PATCH – Atualiza parcialmente um recurso existente.
//DELETE – Remove um recurso do servidor.

app.MapGet("/", () => "API de Produtos");

// Listar Produtos
app.MapGet("/api/produto/listar", ([FromServices] AppDataContext ctx) =>
{
    //Validar se existe alguma coisa dentro da lista
    if (ctx.Produtos.Any())
    {
        return Results.Ok(ctx.Produtos.ToList());
    }
    return Results.BadRequest("Lista vazia.");
});

// Cadastrar Produto
app.MapPost("/api/produto/cadastrar", ([FromBody] Produto produto,
[FromServices] AppDataContext ctx) =>
    {
        Produto? resultado = ctx.Produtos.FirstOrDefault(x => x.Nome == produto.Nome);
        if(resultado is not null)
        {
            return Results.Conflict("Produto já existente");
        }
        ctx.Produtos.Add(produto);
        ctx.SaveChanges();
        return Results.Created("", produto);
    });

// Buscar Produto pelo id
app.MapGet("/api/produto/buscar/{id}" , ([FromRoute] string id,
[FromServices] AppDataContext ctx) =>
    {
        // Produto produto = produtos.FirstOrDefault(x => x.Contains (nome));
        Produto? resultado = ctx.Produtos.Find(id);
        if(resultado == null){
            return Results.NotFound("Produto não encontrado");
        }
        return Results.Ok(resultado);

    });

// Remover produto pelo id
app.MapDelete("/api/produto/remover/{id}", ([FromRoute] string id,
[FromServices] AppDataContext ctx) =>
    {
       
        Produto? resultado = ctx.Produtos.Find(id);
        if(resultado is null){
            return Results.NotFound("Produto não encontrado");
        }
        ctx.Produtos.Remove(resultado);
        ctx.SaveChanges();
        return Results.Ok(resultado);

    });

// Alterar produto pelo nome
app.MapPatch("/api/produto/alterar/{id}", ([FromRoute] string id,
[FromBody] Produto produtoAlterado,
[FromServices] AppDataContext ctx) =>
    {
       
        Produto? resultado = ctx.Produtos.Find(id);
        if(resultado is null){
            return Results.NotFound("Produto não encontrado");
        }
        resultado.Nome = produtoAlterado.Nome;
        resultado.Quantidade = produtoAlterado.Quantidade;
        resultado.Preco = produtoAlterado.Preco;
        ctx.Produtos.Update(resultado);
        ctx.SaveChanges();
        return Results.Ok(resultado);

    });

app.UseCors("Acesso Total");
app.Run();

AppDataContext ctx = new AppDataContext();








