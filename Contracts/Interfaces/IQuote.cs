namespace StuffMySonSaysApi.Contracts.Interfaces
{
    /// <summary>
    /// DTO representing something goofy my son said
    /// </summary>
    public interface IQuote
    {
        /// <summary>
        /// Identifier of this quote
        /// </summary>
        int Id { get; }

        /// <summary>
        /// The thing my son said
        /// </summary>
        string QuoteText { get; }

        /// <summary>
        /// When my son said it
        /// </summary>
        DateOnly DateUttered { get; }
    }
}
