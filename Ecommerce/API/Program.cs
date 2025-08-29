Console.Clear();
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//Funcionalidades
//Requisições
// - Endereço/URL
// - Método HTTP
app.MapGet("/", () => "Se você mudar a maneira como olha para as coisas, as coisas para as quais você olha mudam!");

app.MapGet("/funcionalidade", () => "If you change the way you look at things, the things you look at change!");

app.MapPost("/funcionalidade", () => "Webner Dear");

app.Run();
