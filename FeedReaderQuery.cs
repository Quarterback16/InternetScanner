using System.Collections.Generic;
using System.ServiceModel.Syndication;

namespace InternetScanner
{
	public sealed class FeedReaderQuery : FeedReaderQuery<List<SyndicationItem>>
	{
		public Feed Feed { get; set; }

		public FeedReaderQuery(Feed feed)
		{
			Feed = feed;
		}

	}
}
