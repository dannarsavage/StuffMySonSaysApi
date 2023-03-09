using StuffMySonSaysApi.Contracts.Interfaces;
using StuffMySonSaysApi.DTOs;

namespace StuffMySonSaysApi.Repositories
{
    /// <inheritdoc />
    public class QuoteRepository : IQuoteRepository
    {
        /// <summary>
        /// Trivial collection to represent a database table 
        /// </summary>
        /// <remarks>In a production setting this should use real persistence</remarks>
        private readonly IList<IQuote> _quotes = new List<IQuote>
            {
                new Quote(1,    2,  "Beeyah!", "[Grabs a handful of spaghetti]"),
                new Quote(2,    3,  "A peloton is my favorite kind of 'ton!"),
                new Quote(3,    3,  "I don't like peas. Peas make me sad. Oh no!", "[At the dinner table]"),
                new Quote(4,    4,   "I wonder how wet THIS water is!", "[Walks out of lake] ... [Walks 20 feet along shore]", "[Walks back into lake]"),
                new Quote(5,    6,  "I like soup"),
                new Quote(6,    7,  "I like soup"),
                new Quote(7,    8,  "I like soup"),
                new Quote(8,    9,  "I like soup"),
                new Quote(9,   10,  "I like soup"),
                new Quote(10,   13,  "I like soup"),
                new Quote(11,   15,  "I like soup")
            };

        /// <summary>
        /// This just news up a list of quotes like a database
        /// </summary>
        /// <param name="quotes">Injectable collection of quotes for unit testing</param>
        public QuoteRepository(IEnumerable<IQuote>? quotes = null)
        {
            if (quotes != null && quotes.Any()) _quotes = quotes.ToList();
        }

        /// <inheritdoc />
        public IEnumerable<IQuote> GetAll()
        {
            return _quotes;
        }

        /// <inheritdoc />
        public IQuote GetQuote(int quoteId)
        {
            var matchingQuote = _quotes.FirstOrDefault(q => q.Id == quoteId);
            if (matchingQuote != null) return matchingQuote;
            throw new KeyNotFoundException($"Expected record for key {quoteId} not found.");
        }


        /// <inheritdoc />
        public IQuote GetRandomQuote()
        {
            var random = new Random();
            var randomIndex = random.Next(_quotes.Count);
            return _quotes[randomIndex];
        }
    }
}
