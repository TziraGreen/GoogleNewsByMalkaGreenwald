using NewsJobProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml;

namespace NewsJobProject.DAL
{
    public class  RSSFeedNews
    {
        private const string Url = "http://www.93fm.co.il/feed/?pz=1&cf=all&ned=en_il&hl=en&output=rss";
        private const string keyCache = "RSSFeedNews";

        public  List<NewsItem> GetDataItemsFromCache()
        {
            List<NewsItem> items = new List<NewsItem>();

            if (HttpContext.Current.Cache.Get(keyCache) == null)
            {
                items = GetDataItemsFromURL();
                HttpContext.Current.Cache.Insert(keyCache, items,null,DateTime.Now.AddMinutes(30),TimeSpan.Zero);
            }
            else
            {
                items = (List<NewsItem>)HttpContext.Current.Cache.Get(keyCache);
            }

            return items;
        }

        public  List<NewsItem> GetDataItemsFromURL()
        {
            List<NewsItem> newsItems = new List<NewsItem>();
            NewsItem itemNews = null;

            XmlDocument xmlNewsDoc = new XmlDocument();
            xmlNewsDoc.Load(Url);

            XmlNodeList xnList = xmlNewsDoc.SelectNodes("/rss/channel/item");

            foreach (XmlNode item in xnList)
            {
                itemNews = new NewsItem() {
                
                   Title = item.SelectSingleNode("title")?.InnerText,
                   Link = item.SelectSingleNode("link")?.InnerText,
                   Description = item.SelectSingleNode("description")?.InnerText,
                };

                newsItems.Add(itemNews);
            }

            return newsItems;
        }    
    }  
}