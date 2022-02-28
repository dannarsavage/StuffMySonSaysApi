using Moq;
using Xunit;
using StuffMySonSaysApi.Repositories;
using System.Collections.Generic;
using StuffMySonSaysApi.Contracts.Interfaces;

namespace StuffMySonSaysApi.Tests.Repositories
{
    /// <summary>
    /// Unit tests for <see cref="QuoteRepository"/>
    /// </summary>
    public class QuoteRepositoryTests
    {
        /// <summary>
        /// Utility for quickly mocking a <see cref="IQuote"/>
        /// </summary>
        /// <param name="quoteId"><see cref="IQuote.Id"/> to be returned</param>
        /// <param name="ageWhenUttered"><see cref="IQuote.AgeWhenUttered"/> to be returned</param>
        /// <param name="quoteText"><see cref="IQuote.QuoteText"/> to be returned</param>
        /// <param name="beforeAction"><see cref="IQuote.BeforeAction"/> to be returned</param>
        /// <param name="afterAction"><see cref="IQuote.AfterAction"/> to be returned</param>
        /// <returns>A simple mocked <see cref="IQuote"/></returns>
        private Mock<IQuote> SetupMockQuote(
            int? quoteId = null,
            int? ageWhenUttered = null,
            string? quoteText = null,
            string? beforeAction = null,
            string? afterAction = null)
        {
            var mockQuote = new Mock<IQuote>();
            if (quoteId != null) mockQuote.Setup(q => q.Id).Returns(quoteId.Value);
            if (ageWhenUttered != null) mockQuote.Setup(q => q.AgeWhenUttered).Returns(ageWhenUttered.Value);
            if (quoteText != null) mockQuote.Setup(q => q.QuoteText).Returns(quoteText);
            if (beforeAction != null) mockQuote.Setup(q => q.BeforeAction).Returns(beforeAction);
            if (afterAction != null) mockQuote.Setup(q => q.AfterAction).Returns(afterAction);
            return mockQuote;
        }

        /// <summary>
        /// <see cref="QuoteRepository.GetRandomQuote()"/> should always return a quote
        /// </summary>
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

        /// <summary>
        /// <see cref="QuoteRepository.GetQuote(int)"/> should return null when given an ID that doesn't exist in the repository
        /// </summary>
        [Fact]
        public void GetQuoteWithBadIdReturnsNull()
        {
            var injectedQuotes = new List<IQuote>
            {
                SetupMockQuote(1).Object,
                SetupMockQuote(2).Object,
                SetupMockQuote(3).Object,
                SetupMockQuote(4).Object,
                SetupMockQuote(5).Object,
                SetupMockQuote(6).Object,
                SetupMockQuote(7).Object
            };
            var sut = new QuoteRepository(injectedQuotes);

            var result = sut.GetQuote(9);

            Assert.Null(result);
        }

        /// <summary>
        /// <see cref="QuoteRepository.GetQuote(int)"/> should return the correct quote
        /// </summary>
        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(7)]
        public void GetQuoteReturnsCorrectQuote(int quoteId)
        {
            var injectedQuotes = new List<IQuote>
            {
                SetupMockQuote(1).Object,
                SetupMockQuote(2).Object,
                SetupMockQuote(3).Object,
                SetupMockQuote(4).Object,
                SetupMockQuote(5).Object,
                SetupMockQuote(6).Object,
                SetupMockQuote(7).Object
            };
            var sut = new QuoteRepository(injectedQuotes);

            var result = sut.GetQuote(quoteId);

            Assert.Equal(quoteId, result.Id);
        }
    }
}