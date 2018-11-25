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
			// query
			var items = _feedQueryHandler.Handle(feedQuery);
			// filter
			var newItems = _gotItQuery.GetNewItems(items);
			if (newItems.Count > 0)
			{
				//  convert to feedItem is this necessary?
				var newFeedItems = ConvertToFeedItems(newItems);
				// add to the command bus
				Send(newFeedItems);
			}
			else
				Logger.Info("No new items found");
		}

		private List<FeedItem> ConvertToFeedItems(
			List<SyndicationItem> newItems)
		{
			var result = new List<FeedItem>();
			foreach (var item in newItems)
			{
				var feedItem = new FeedItem(item,new Feed());
				result.Add(feedItem);
			}
			return result;
		}

		private void Send(List<FeedItem> items)
		{
			if ( _bus == null )
			{
				Logger.Warning("There is no bus for the messages");
				return;
			}
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
					Logger.Info($"{item.GetDatePublished()} : {item.GetSummary()}");
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
