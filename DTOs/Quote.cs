using StuffMySonSaysApi.Contracts.Interfaces;

namespace StuffMySonSaysApi.DTOs
{
    /// <inheritdoc />
    public class Quote : IQuote
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ageWhenUttered">Populates <see cref="Quote.AgeWhenUttered"/></param>
        /// <param name="quote">Populates <see cref="Quote.QuoteText"/></param>
        /// <param name="beforeAction">Populates <see cref="Quote.BeforeAction"/></param>
        /// <param name="afterAction">Populates <see cref="Quote.AfterAction"/></param>
        public Quote(int id, int ageWhenUttered, string quoteText, string beforeAction = "", string afterAction = "")
        {
            Id = id;
            AgeWhenUttered = ageWhenUttered;
            QuoteText = quoteText;
            BeforeAction = beforeAction;
            AfterAction = afterAction;
        }

        /// <inheritdoc />
        public int Id { get; }

        /// <inheritdoc />
        public string QuoteText { get; }

        /// <inheritdoc />
        public int AgeWhenUttered { get; }

        /// <inheritdoc />
        public string BeforeAction { get; }

        /// <inheritdoc />
        public string AfterAction { get; }
    }
}
