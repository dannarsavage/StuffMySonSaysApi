using StuffMySonSaysApi.Contracts.Interfaces;
using StuffMySonSaysApi.DTOs;

namespace StuffMySonSaysApi.Repositories
{
    /// <inheritdoc />
    public class QuoteRepository : IQuoteRepository
    {
        private readonly IList<IQuote> _quotes;
        /// <summary>
        /// This just news up a list of quotes but in the real world of course this should use real persistence like a database
        /// </summary>
        public QuoteRepository()
        {
            _quotes = new List<IQuote>
            {
                new Quote(1,    2,  "Beeyah!", "[Grabs a handful of spaghetti]"),
                new Quote(2,    3,  "A peloton is my favorite kind of 'ton!"),
                new Quote(3,    3,  "I don't like peas. Peas make me sad. Oh no!", "[At the dinner table]"),
                new Quote(4,    4,   "I wonder how wet THIS water is!", "[Walks out of lake] ... [Walks 20 feet along shore]", "[Walks back into lake]"),
                new Quote(5,    6,  "I like soup"),
                new Quote(6,    7,  "I like soup"),
                new Quote(7,    8,  "I like soup"),
                new Quote(7,    9,  "I like soup"),
                new Quote(7,   10,  "I like soup"),
                new Quote(7,   13,  "I like soup"),
                new Quote(7,   15,  "I like soup")
            };
        }

        /// <inheritdoc />
        public IEnumerable<IQuote> GetAll()
        {
            return _quotes;
        }

        /// <inheritdoc />
        public IQuote GetQuote(int quoteId) => _quotes.FirstOrDefault(q => q.Id == quoteId);


        /// <inheritdoc />
        public IQuote GetRandomQuote()
        {
            var random = new Random();
            return _quotes[random.Next(_quotes.Count)];
        }
    }
}
