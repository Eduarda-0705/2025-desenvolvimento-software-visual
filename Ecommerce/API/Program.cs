using API.Models;

Console.Clear();
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Lista com Produtos fakes
List<Produto> produtos = new List<Produto>
{
    new Produto { Nome = "Notebook", Quantidade = 10, Preco = 3500.00 },
    new Produto { Nome = "Mouse", Quantidade = 50, Preco = 45.90 },
    new Produto { Nome = "Teclado", Quantidade = 30, Preco = 79.99 },
    new Produto { Nome = "Monitor", Quantidade = 15, Preco = 899.00 },
    new Produto { Nome = "Headset", Quantidade = 20, Preco = 120.50 }
};

//Métodos HTTP
//GET – Recupera dados do servidor (sem alterar o estado).
//POST – Envia dados ao servidor para criar um novo recurso.
//PUT – Atualiza completamente um recurso existente no servidor.
//PATCH – Atualiza parcialmente um recurso existente.
//DELETE – Remove um recurso do servidor.

//Funcionalidades
//Requisições
// - Endereço/URL
// - Método HTTP
app.MapGet("/", () => "API de Produtos");

app.MapGet("/api/produto/listar", () =>
{
    return produtos;
});

app.MapPost("/api/produto/cadastrar", (Produto produto) =>
{
   
    produtos.Add(produto);
});


app.Run();







