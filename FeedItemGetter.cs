using System.Collections.Generic;
using System.ServiceModel.Syndication;

namespace InternetScanner
{
	public class FeedItemGetter : IGetFeedItems
	{
		private readonly Feed feed;

		public FeedItemGetter()
		{

		}

		public FeedItemGetter( Feed feed)
		{
			this.feed = feed;
		}

		public List<SyndicationItem> GetFeed(Feed feed)
		{
			return new List<SyndicationItem>();
		}

		public List<SyndicationItem> GetFeed()
		{
			return new List<SyndicationItem>();
		}
	}
}
