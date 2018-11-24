using System.Collections.Generic;
using System.ServiceModel.Syndication;

namespace InternetScanner
{
	public class GotItQuery : IGotItQuery
	{
		public List<SyndicationItem> GetNewItems(
			List<SyndicationItem> items)
		{
			return items;
		}
	}
}
