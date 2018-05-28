using NUnit.Framework;
using Business;

namespace Test
{
    [TestFixture]
    [Category("Integration Test")]
    public class QuoteDocumentIntegrationTests
    {
        [Test]
        public void GenerateQuoteDocument()
        {
            QuoteDocument quoteDocument = new QuoteDocument();
            quoteDocument.GenerateQuoteDocument();
        }
    }
}
