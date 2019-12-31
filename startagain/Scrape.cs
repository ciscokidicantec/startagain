using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;


namespace startagain
{
    public class Scrape
    {
        WebClient mywebClient;
        readonly string wholeurl = "https://www.zoopla.co.uk/for-sale/houses/sn/?beds_min=3&price_max=2000000&property_type=houses&price_min=10000&page_size=25&q=sn&results_sort=lowest_price&search_source=refine&radius=0&pn=14";
 

        public void Getimages()
        {
            string Htmlpage;


            mywebClient = new WebClient();
            Htmlpage = mywebClient.DownloadString(wholeurl);

            mywebClient.Dispose();

        }


    }
}