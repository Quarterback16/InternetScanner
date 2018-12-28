using InternetScanner.Bus;
using Shuttle.Core.ServiceHost;
using Shuttle.Esb;
using Shuttle.Core.StructureMap;
using StructureMap;
using System;

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
			IServiceBus bus = StartTheBus();

			var feed = new Feed
			{
				Name = "NFL",
				Url = "http://www.rotoworld.com/tools/rss/fantasy-football.aspx",
			};
			var feedQueryHandler = new FeedReaderQueryHandler();

			var scanner = new InternetRssScanner(
				bus,
				feedQueryHandler,
				gotItQuery: new GotItQuery(),
				logger: new NLogAdaptor());

			scanner.Scan(
				new FeedReaderQuery(feed));

			Console.Write("hit any key to exit");
			Console.ReadLine();
		}

		private static IServiceBus StartTheBus()
		{
			var smRegistry = new Registry();
			var registry = new StructureMapComponentRegistry(
				smRegistry);

			ServiceBus.Register(registry);

			var bus = ServiceBus.Create(
				resolver: new StructureMapComponentResolver(
								new Container(smRegistry)))
				.Start();
			return bus;
		}
	}
}
