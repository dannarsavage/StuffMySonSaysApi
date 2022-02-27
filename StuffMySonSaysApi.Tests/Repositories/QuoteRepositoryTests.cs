using Moq;
using Xunit;
using StuffMySonSaysApi.Repositories;
using System.Collections.Generic;
using StuffMySonSaysApi.Contracts.Interfaces;

namespace StuffMySonSaysApi.Tests.Repositories
{
    public class QuoteRepositoryTests
    {
        //private Mock<IQuote> SetupMockQuote(
        //    int? quoteId = null, 
        //    int? ageWhenUttered = null,
        //    string? quoteText = null,
        //    string? beforeAction = null,
        //    string? afterAction = null)
        //{
        //    var mockQuote = new Mock<IQuote>();
        //    if (quoteId != null) mockQuote.Setup(q => q.Id).Returns(quoteId.Value);
        //    if (ageWhenUttered != null) mockQuote.Setup(q => q.AgeWhenUttered).Returns(ageWhenUttered.Value);
        //    if (quoteText != null) mockQuote.Setup(q => q.QuoteText).Returns(quoteText);
        //    if (beforeAction != null) mockQuote.Setup(q => q.BeforeAction).Returns(beforeAction);
        //    if (afterAction != null) mockQuote.Setup(q => q.AfterAction).Returns(afterAction);
        //    return mockQuote;
        //}

        [Fact]
        public void GetRandomQuoteReturnsQuote()
        {
            var injectedQuotes = new List<IQuote>
            {
                new Mock<IQuote>().Object,
                new Mock<IQuote>().Object,
                new Mock<IQuote>().Object,
                new Mock<IQuote>().Object,
                new Mock<IQuote>().Object,
                new Mock<IQuote>().Object,
                new Mock<IQuote>().Object
            };
            var sut = new QuoteRepository(injectedQuotes);

            var result = sut.GetRandomQuote();

            Assert.NotNull(result);
        }
    }
}