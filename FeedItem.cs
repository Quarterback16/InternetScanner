using System;
using System.Linq;
using System.ServiceModel.Syndication;

namespace InternetScanner
{
	public class FeedItem
	{
		public string FeedType { get; set; }

		public Feed ParentFeed { get; set; }

		public override string ToString()
		{
			return GetTitle();
		}

		private readonly SyndicationItem _item;

		public FeedItem(SyndicationItem item, Feed parentFeed)
		{
			_item = item;
			FeedType = parentFeed.Name;
			ParentFeed = parentFeed;
#if DEBUG
			DumpItem();
#endif
		}

		public string GetTitle()
		{
			return _item.Title.Text.Trim();
		}

		public string GetSummary()
		{
			return _item.Summary.Text.Trim().Replace("&quot;", @"""");
		}

		public string GetDatePublished()
		{
			return $"{_item.PublishDate.DateTime:u}".Substring(0, 16);
		}

		public DateTime DatePublished()
		{
			return _item.PublishDate.DateTime;
		}

		public void DumpItem()
		{
			Console.WriteLine("Title: {0}", GetTitle());
			//Console.WriteLine("Cats: {0}", GetCategories());
			Console.WriteLine("Summary: {0}", GetSummary());
			Console.WriteLine("Published: {0}", GetDatePublished());
			//Console.WriteLine("Links: {0}", GetLinks());
			//Console.WriteLine("Torrent: {0}", GetTfile());
			Console.WriteLine(string.Empty);
		}

		public string GetCategories()
		{
			var arr = _item.Categories.ToArray();
			return arr.Aggregate(string.Empty, (current, cat) => current + cat.Name);
		}

		public string GetLinks()
		{
			var arr = _item.Links.ToArray();
			var myLinks = string.Empty;
			foreach (var link in arr)
			{
				myLinks += link.Uri + ", ";
			}
			return myLinks;
		}

		public Uri GetTfile()
		{
			var arr = _item.Links.ToArray();
			var tfile = new Uri("http://www.codeodor.com/images/Empty_set.png");
			foreach (var link in arr)
			{
				tfile = link.Uri;
			}
			return tfile;
		}

		public string GetFileName()
		{
			var fileName = System.IO.Path.GetFileName(GetTfile().LocalPath);
			return fileName;
		}
	}
}
