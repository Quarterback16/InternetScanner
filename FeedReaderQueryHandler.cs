using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Xml;

namespace InternetScanner
{
	public sealed class FeedReaderQueryHandler
		: IQueryHandler<FeedReaderQuery, List<SyndicationItem>>
	{
		/// <summary>
		///   Queries a feed returning the RSS items in a list
		/// </summary>
		/// <param name="query"></param>
		/// <returns></returns>
		public List<SyndicationItem> Handle(FeedReaderQuery query)
		{
			var result = new List<SyndicationItem>();
			var rssFeed = new SyndicationFeed();
			using (var reader = XmlReader.Create(query.Feed.Url))
			{
				rssFeed = SyndicationFeed.Load(reader);
				foreach (SyndicationItem sItem in rssFeed.Items)
				{
					if ((sItem == null) || (sItem.Title == null))
						continue;
					result.Add(sItem);
				}
			}
			return result;
		}
	}

}
