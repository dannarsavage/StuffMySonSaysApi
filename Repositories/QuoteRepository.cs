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
                new Quote(1,    new DateOnly(2016, 12, 3),  "Beeyah!  (Attempt at 'Spaghetti!')"),
                new Quote(3,    new DateOnly(2017, 7, 13),  "A peloton is my favorite kind of 'ton!"),
                new Quote(2,    new DateOnly(2017, 12, 3),  "I don't like peas. Peas make me sad. Oh no!"),
                new Quote(4,    new DateOnly(2018, 6, 8),   "I wonder how wet THIS water is!"),
                new Quote(5,    new DateOnly(2020, 12, 3),  "I like soup"),
                new Quote(6,    new DateOnly(2021, 12, 3),  "I like soup"),
                new Quote(7,    new DateOnly(2022, 12, 3),  "I like soup")
            };
        }

        /// <inheritdoc />
        public IEnumerable<IQuote> GetAll()
        {
            return _quotes;
        }

        /// <inheritdoc />
        public IQuote GetQuote(int quoteId) => _quotes.FirstOrDefault(q => q.Id == quoteId);
    }
}
