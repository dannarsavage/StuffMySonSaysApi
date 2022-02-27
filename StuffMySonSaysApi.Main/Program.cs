using StuffMySonSaysApi.Contracts.Interfaces;
using StuffMySonSaysApi.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
    {
        options.AddDefaultPolicy(builder =>
            {
                builder.WithOrigins("https://localhost",
                    "http://localhost",
                    "https://localhost:3000",
                    "http://localhost:3000")
                ;
            });
    })
    .AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new()
        {
            Title = builder.Environment.ApplicationName,
            Version = "v1"
        });
    })
    .AddEndpointsApiExplorer()
    .AddSingleton<IQuoteRepository, QuoteRepository>();

var app = builder.Build();
app.UseCors();
app.UseSwagger();

//app.MapGet("/", () => "Hello World!");

app.MapGet("/quotes", (IQuoteRepository quoteRepository) => GetAllQuotes(quoteRepository));

app.MapGet("/quotes/{id}", (int id, IQuoteRepository quoteRepository) => GetQuote(id, quoteRepository));

app.MapGet("/quotes/random", (IQuoteRepository quoteRepository) => GetRandomQuote(quoteRepository));

/// <summary>
/// Get all quotes from the repository and return a result containing that list
/// </summary>
IResult GetAllQuotes(IQuoteRepository quoteRepository)
{
    return Results.Ok(quoteRepository.GetAll());
}

/// <summary>
/// Get a random quote from the repository and return a result containing that quote
/// </summary>
IResult GetRandomQuote(IQuoteRepository quoteRepository)
{
    return Results.Ok(quoteRepository.GetRandomQuote());
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