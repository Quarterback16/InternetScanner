using System.Collections.Generic;
using System.Xml;

namespace InternetScanner
{
	public class Feed
	{
		public string Name { get; set; }

		public string Url { get; set; }

		public List<string> Hits { get; set; }

		public List<string> StopWords { get; set; }

		public string MatchXmlFile { get; set; }

		public string StopWordXmlFile { get; set; }

		public int Range { get; set; }

		public void LoadFromXml()
		{
			//  reload every time so we can just fiddle the XML at any time
			Hits = new List<string>();

			var r = new XmlTextReader(MatchXmlFile);
			while (r.Read())
			{
				if (r.NodeType != XmlNodeType.Element || r.Name != "match") continue;
				var item = r.ReadElementContentAsString();
				Hits.Add(item);
			}
			r.Close();

			if (!string.IsNullOrEmpty(StopWordXmlFile))
			{
				StopWords = new List<string>();

				var sw = new XmlTextReader(StopWordXmlFile);
				while (sw.Read())
				{
					if (sw.NodeType != XmlNodeType.Element || sw.Name != "stop") continue;
					var item = sw.ReadElementContentAsString();
					StopWords.Add(item);
				}
				sw.Close();
			}
		}
	}
}
