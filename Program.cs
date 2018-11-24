


using Autofac;
using InternetScanner.Bus;
using Shuttle.Core.Autofac;
using Shuttle.Core.ServiceHost;
using Shuttle.Esb;

namespace InternetScanner
{
	/// <summary>
	///   Console app that reeds an RSS feed 
	///   and converts RSS items into messages
	/// </summary>
	public class Program
	{
		static void Main(string[] args)
		{
			ServiceHost.Run<Host>();

			var containerBuilder = new ContainerBuilder();
			var resolver = new AutofacComponentResolver(
				containerBuilder.Build());

			var bus = ServiceBus.Create(resolver).Start();

			var feed = new Feed
			{
				Name = "NFL",
				Url = "http://www.rotoworld.com/tools/rss/fantasy-football.aspx",
			};
			var feedQueryHandler = new FeedReaderQueryHandler();

			var scanner = new InternetRssScanner(
				bus,
				feedQueryHandler,
				gotItQuery: null,
				logger: null);

			scanner.Scan(new FeedReaderQuery(feed));
		}


	}
}
