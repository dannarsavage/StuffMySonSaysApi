using StuffMySonSaysApi.Contracts.Interfaces;

namespace StuffMySonSaysApi.DTOs
{
    /// <inheritdoc />
    public class Quote : IQuote
    {
        private readonly int _id;
        private readonly string _quoteText;
        private readonly DateOnly _dateUttered;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="utteredDate">Populates <see cref="Quote.DateUttered"/></param>
        /// <param name="quote">Populates <see cref="Quote.QuoteText"/></param>
        public Quote(int id, DateOnly utteredDate, string quoteText)
        {
            _id = id;
            _dateUttered = utteredDate;
            _quoteText = quoteText;
        }

        /// <inheritdoc />
        public int Id => _id;

        /// <inheritdoc />
        public DateOnly DateUttered => _dateUttered;

        /// <inheritdoc />
        public string QuoteText => _quoteText;
    }
}
