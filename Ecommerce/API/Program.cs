using API.Models;
using Microsoft.AspNetCore.Mvc;

Console.Clear();
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Lista com Produtos fixos
List<Produto> produtos = new List<Produto>();
// {
//     new Produto { Nome = "Notebook", Quantidade = 10, Preco = 3500.00 },
//     new Produto { Nome = "Mouse", Quantidade = 50, Preco = 45.90 },
//     new Produto { Nome = "Teclado", Quantidade = 30, Preco = 79.99 },
//     new Produto { Nome = "Monitor", Quantidade = 15, Preco = 899.00 },
//     new Produto { Nome = "Headset", Quantidade = 20, Preco = 120.50 }
// };
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
app.MapGet("/api/produto/listar", () =>
{
    //Validar se existe alguma coisa dentro da lista
    if(produtos.Count > 0)
    {  
    return Results.Ok(produtos);
    }
    return Results.BadRequest("Lista vazia.");
});

// Cadastrar Produto
app.MapPost("/api/produto/cadastrar", ([FromBody] Produto produto) =>
{
    foreach (Produto produtoCadastrado in produtos)
    {
        if(produtoCadastrado.Nome == produto.Nome)
        {
            return Results.Conflict("Produto já cadastrado!");
        }
    }
    produtos.Add(produto);
    return Results.Created("", produto);
});

// Buscar Produto
app.MapGet("/api/produto/buscar/{nome}" , ([FromRoute] string nome) =>
    {
        // foreach (Produto produtoCadastrado in produtos){
        //     if(produtoCadastrado.Nome == nome){
        //         return Results.Ok(produtoCadastrado);
        //     }
        // }
        // return Results.NotFoud("Produto não cadastrado");

        //Expressão lambda
        // Produto produto = produtos.FirstOrDefault(x => x.Contains (nome));
        Produto? resultado = produtos.FirstOrDefault(x => x.Nome == nome);
        if(resultado == null){
            return Results.NotFound("Produto não encontrado");
        }
        return Results.Ok(resultado);

    });

// Remover produto pelo id
app.MapDelete("/api/produto/remover/{id}", ([FromRoute] string id) =>
    {
       
        Produto? resultado = produtos.FirstOrDefault(x => x.Id == id);
        if(resultado == null){
            return Results.NotFound("Produto não encontrado");
        }
        produtos.Remove(resultado);
        return Results.Ok(resultado);

    });

// Alterar produto pelo nome
app.MapPatch("/api/produto/alterar/{id}", ([FromRoute] string id,
[FromBody] Produto produtoAlterado) =>
    {
       
        Produto? resultado = produtos.FirstOrDefault(x => x.Id == id);
        if(resultado == null){
            return Results.NotFound("Produto não encontrado");
        }
        resultado.Nome = produtoAlterado.Nome;
        resultado.Quantidade = produtoAlterado.Quantidade;
        resultado.Preco = produtoAlterado.Preco;
        return Results.Ok(resultado);

    });



app.Run();







