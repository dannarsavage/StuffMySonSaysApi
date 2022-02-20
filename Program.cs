using Microsoft.AspNetCore.Http.Json;
using StuffMySonSaysApi.Contracts.Interfaces;
using StuffMySonSaysApi.Repositories;
using StuffMySonSaysApi.Utilities;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddEndpointsApiExplorer()
    .AddSingleton<IQuoteRepository, QuoteRepository>();

builder.Services.Configure <JsonOptions> (options =>
         options.SerializerOptions.Converters.Add(new DateOnlyConverter()));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/quotes", (IQuoteRepository quoteRepository) => GetAllQuotes(quoteRepository));

app.MapGet("/quotes/{id}", (int id, IQuoteRepository quoteRepository) => GetQuote(id, quoteRepository));

IResult GetAllQuotes(IQuoteRepository quoteRepository)
{
    return Results.Ok(quoteRepository.GetAll());
}

IResult GetQuote(int id, IQuoteRepository quoteRepository)
{
    var quote = quoteRepository.GetQuote(id);

    return (quote != null) 
        ? Results.Ok(quote)
        : Results.NotFound(null);
}

app.Run();


