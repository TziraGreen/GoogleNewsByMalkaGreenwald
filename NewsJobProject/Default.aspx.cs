using NewsJobProject.DAL;
using NewsJobProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewsJobProject
{
    public partial class _Default : Page
    {
        static RSSFeedNews  rssFeedNews = new RSSFeedNews();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
           
        }
        protected void LoadData()
        {
            List<string> newsItems = new List<string>();
            newsItems = rssFeedNews.GetDataItemsFromCache().Select(x => x.Title).ToList();
            Repeater.DataSource = newsItems;
            Repeater.DataBind();

        }
        [WebMethod]
  
        public static  NewsItem GetNewsByIndex(int index)
        {
            return rssFeedNews.GetDataItemsFromCache()[index - 1];
        }
    }
}