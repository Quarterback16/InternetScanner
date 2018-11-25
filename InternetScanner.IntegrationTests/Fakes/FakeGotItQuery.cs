using System.Collections.Generic;
using System.ServiceModel.Syndication;

namespace InternetScanner.IntegrationTests.Fakes
{
	/// <summary>
	///   For testing say that ALL items are new
	/// </summary>
	public class FakeGotItQuery : IGotItQuery
	{
		public List<SyndicationItem> GetNewItems(
			List<SyndicationItem> items)
		{
			return items;
		}
	}
}
