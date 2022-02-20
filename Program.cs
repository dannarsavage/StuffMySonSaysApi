using Microsoft.AspNetCore.Http.Json;
using StuffMySonSaysApi.Contracts.Interfaces;
using StuffMySonSaysApi.Repositories;
using StuffMySonSaysApi.Utilities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new()
    {
        Title = builder.Environment.ApplicationName,
        Version = "v1"
    });
});

builder.Services
    .AddEndpointsApiExplorer()
    .AddSingleton<IQuoteRepository, QuoteRepository>();

builder.Services.Configure <JsonOptions> (options =>
         options.SerializerOptions.Converters.Add(new DateOnlyConverter()));

var app = builder.Build();

app.UseSwagger();

//app.MapGet("/", () => "Hello World!");

app.MapGet("/quotes", (IQuoteRepository quoteRepository) => GetAllQuotes(quoteRepository));

app.MapGet("/quotes/{id}", (int id, IQuoteRepository quoteRepository) => GetQuote(id, quoteRepository));

/// <summary>
/// Get all quotes from the repository and return a result containing that list
/// </summary>
IResult GetAllQuotes(IQuoteRepository quoteRepository)
{
    return Results.Ok(quoteRepository.GetAll());
}

/// <summary>
/// Get one quote from the repository based on an ID and return a reasonable result
/// </summary>
IResult GetQuote(int id, IQuoteRepository quoteRepository)
{
    var quote = quoteRepository.GetQuote(id);

    return (quote != null) 
        ? Results.Ok(quote)
        : Results.NotFound("Quote not found");
}

app.UseSwaggerUI(); 

app.Run();