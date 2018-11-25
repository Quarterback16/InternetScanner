using System.Collections.Generic;
using System.ServiceModel.Syndication;

namespace InternetScanner
{
	/// <summary>
	///   Responsibile for working out which items are new
	/// </summary>
	public interface IGotItQuery
	{
		List<SyndicationItem> GetNewItems(
			List<SyndicationItem> items);
	}
}
