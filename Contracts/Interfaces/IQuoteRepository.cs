namespace StuffMySonSaysApi.Contracts.Interfaces
{
    /// <summary>
    /// Repository of goofy things my son has said
    /// </summary>
    public interface IQuoteRepository
    {
        /// <summary>
        /// Get a single <see cref="IQuote"/> by its ID
        /// </summary>
        /// <param name="quoteId">ID of the <see cref="IQuote"/> to retrieve</param>
        /// <returns><see cref="IQuote"/> with the given quoteId or null if no quote has that ID</returns>
        IQuote GetQuote(int quoteId);

        /// <summary>
        /// Get all quotes in the repository
        /// </summary>
        /// <returns>All quotes in the repository</returns>
        IEnumerable<IQuote> GetAll();
    }
}
