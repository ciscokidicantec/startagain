using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;


namespace startagain
{
    interface IScrapeitems
    {
        string GetImages();
        string LocateItem();
        string GetPrice();
        string GetBullettPoints();

    }

    public class ScrapeItems
    {

        public string GetImages()
        {
            string wholeurl = "https://www.zoopla.co.uk/for-sale/houses/sn/?beds_min=3&price_max=2000000&property_type=houses&price_min=10000&page_size=25&q=sn&results_sort=lowest_price&search_source=refine&radius=0&pn=14";
            WebClient mywebClient;
            string Htmlpage;


            mywebClient = new WebClient();
            Htmlpage = mywebClient.DownloadString(wholeurl);

            mywebClient.Dispose();

            return Htmlpage;
        }

        public string LocateItem()
        {

            return "";
        }

        public string GetPrice()
        {

            return "";
        }

        public string GetBullettPoints()
        {

            return "";
        }



    }

}
