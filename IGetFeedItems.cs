using System.Collections.Generic;
using System.ServiceModel.Syndication;

namespace InternetScanner
{
	public interface IGetFeedItems
	{
		List<SyndicationItem> GetFeed(Feed feed);
		List<SyndicationItem> GetFeed();
	}
}
