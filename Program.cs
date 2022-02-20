using StuffMySonSaysApi.Contracts.Interfaces;
using StuffMySonSaysApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton<IQuoteRepository, QuoteRepository>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/quotes", (IQuoteRepository quoteRepository) => quoteRepository.GetAll);

app.MapGet("/quotes/{id}", (int id, IQuoteRepository quoteRepository) => quoteRepository.GetQuote(id));

app.Run();
