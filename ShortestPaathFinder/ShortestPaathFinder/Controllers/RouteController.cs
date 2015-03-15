using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using ShortestPaathFinder.Models;
using System.Collections;

namespace ShortestPaathFinder.Controllers
{
    public class RouteController : Controller
    {
        // GET: Route
        public ActionResult Index(string data)
        {

            List<Geocode> nodelist;
            if (data != null)
            {
                nodelist = JsonConvert.DeserializeObject<List<Geocode>>(data);
            }
            
            // TODO Make a list of Geocodes from location list
            List<Geocode> geocodeList = new List<Geocode>();
            


            // TODO find distances between all Geocodes, save as Paths
            // TODO return shortest route between ALL nodes/markers/points/Geocodes
            return View();
            
        }
    }
}