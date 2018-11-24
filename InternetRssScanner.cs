using InternetScanner.Messages;
using Shuttle.Esb;
using System;
using System.Collections.Generic;
using System.ServiceModel.Syndication;

namespace InternetScanner
{
	public class InternetRssScanner
	{
		private readonly IServiceBus _bus;
		private readonly IQueryHandler<FeedReaderQuery, List<SyndicationItem>>
			_feedQueryHandler;
		private readonly IGotItQuery _gotItQuery;
		public ILog Logger { get; }

		public InternetRssScanner(
			IServiceBus bus,
			IQueryHandler<FeedReaderQuery, List<SyndicationItem>> feedQueryHandler,
			IGotItQuery gotItQuery,
			ILog logger)
		{
			_bus = bus;
			_feedQueryHandler = feedQueryHandler;
			_gotItQuery = gotItQuery;
			Logger = logger;
		}

		public void Scan(FeedReaderQuery feedQuery)
		{
			// read
			var items = _feedQueryHandler.Handle(feedQuery);
			// filter
			var newItems = _gotItQuery.GetNewItems(items);
			//  convert to feedItem is this necessary?
			var newFeedItems = ConvertToFeedItems(newItems);
			// add to the command bus
			Send(newFeedItems);
		}

		private List<FeedItem> ConvertToFeedItems(
			List<SyndicationItem> newItems)
		{
			throw new NotImplementedException();
		}

		private void Send(List<FeedItem> items)
		{
			foreach (var item in items)
			{
				try
				{
					_bus.Send(
						new NewsArticleCommand
						{
							ArticleDate = item.GetDatePublished(),
							ArticleText = item.GetSummary()
						});
				}
				catch (Exception ex)
				{
					Logger.Error(
						$"InternetScanner.SendMessage: {ex.Message}");
					throw;
				}

			}
		}
	}
}
