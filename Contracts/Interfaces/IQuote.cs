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
        /// Age when my son said it
        /// </summary>
        int AgeWhenUttered { get; }

        /// <summary>
        /// Thing that happened before my son said it
        /// </summary>
        string BeforeAction { get; }

        /// <summary>
        /// Thing that happened after my son said it
        /// </summary>
        string AfterAction { get; }
    }
}
