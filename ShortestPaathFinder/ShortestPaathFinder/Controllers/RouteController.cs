using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using Newtonsoft.Json;
using System.Collections;

namespace ShortestPaathFinder.Controllers
{
    public class RouteController : Controller
    {
        // GET: Route
        public ActionResult Index(string data)
        {
            var nodeList = (ArrayList)JsonConvert.DeserializeObject(data);
            // TODO return shortest route between ALL nodes/markers/points/Geocodes
            return View();
        }
    }
}