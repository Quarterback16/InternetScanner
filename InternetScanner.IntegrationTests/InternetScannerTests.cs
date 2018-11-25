using Microsoft.VisualStudio.TestTools.UnitTesting;
using InternetScanner.IntegrationTests.Fakes;

namespace InternetScanner.IntegrationTests
{
	[TestClass]
    public class InternetScannerTests
    {
		[TestMethod]
		public void ScannerReadsFeeds()
		{
			//ServiceHost.Run<Host>();

			//var containerBuilder = new ContainerBuilder();
			//var resolver = new AutofacComponentResolver(
			//	containerBuilder.Build());

			//var bus = ServiceBus.Create(resolver).Start();

			var feed = new Feed
			{
				Name = "NFL",
				Url = "http://www.rotoworld.com/tools/rss/fantasy-football.aspx",
			};
			var feedQueryHandler = new FeedReaderQueryHandler();

			var scanner = new InternetRssScanner(
				bus: null,
				feedQueryHandler: feedQueryHandler,
				gotItQuery: new FakeGotItQuery(),
				logger: new FakeLogger());

			//  scan this feed
			var query = new FeedReaderQuery(feed);
			scanner.Scan(query);
		}
    }
}
