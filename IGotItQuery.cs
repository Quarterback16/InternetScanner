using System.Collections.Generic;
using System.ServiceModel.Syndication;

namespace InternetScanner
{
	public interface IGotItQuery
	{
		List<SyndicationItem> GetNewItems(List<SyndicationItem> items);
	}
}
