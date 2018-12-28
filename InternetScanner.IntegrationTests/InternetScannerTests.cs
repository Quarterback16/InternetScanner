using Microsoft.VisualStudio.TestTools.UnitTesting;
using InternetScanner.IntegrationTests.Fakes;
using Shuttle.Core.StructureMap;
using Shuttle.Esb;
using StructureMap;

namespace InternetScanner.IntegrationTests
{
	[TestClass]
    public class InternetScannerTests
    {
		[TestMethod]
		public void Scanner_ReadsFeedsAndSendsMessagesToTheBus()
		{
			var smRegistry = new Registry();
			var registry = new StructureMapComponentRegistry(
				smRegistry);

			ServiceBus.Register(registry);

			var bus = ServiceBus.Create(
				resolver: new StructureMapComponentResolver(
								new Container(smRegistry)))
				.Start();

			var feed = new Feed
			{
				Name = "NFL",
				Url = "http://www.rotoworld.com/tools/rss/fantasy-football.aspx",
			};
			var feedQueryHandler = new FeedReaderQueryHandler();

			var scanner = new InternetRssScanner(
				bus: bus,
				feedQueryHandler: feedQueryHandler,
				gotItQuery: new FakeGotItQuery(),
				logger: new FakeLogger());

			//  scan this feed
			var query = new FeedReaderQuery(feed);
			scanner.Scan(query);
		}
    }
}
