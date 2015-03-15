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
using Dijkstra;

namespace ShortestPaathFinder.Controllers
{
    public class RouteController : Controller
    {
        // GET: Route
        public ActionResult Index(string data)
        {

            List<Marker> markerList;
            if (data != null)
            {
                markerList = JsonConvert.DeserializeObject<List<Marker>>(data);
            
                // Create Graph
                Graph graph = new Graph();

                
                // Add nodes
                foreach(Marker m in markerList)
                {
                    graph.AddNode(m.Mid);
                }

                // TODO calc all distances between markers & add to graph
                for (int i = 0; i < markerList.Count; i++)
                {
                    for (int j = i+1; j < markerList.Count; j++)
                    {
                        graph.AddConnection(markerList[i].Mid, markerList[j].Mid, Path.CalcDistance(markerList[i],markerList[j]), true);
                    }
                }

                // calc shortest route between ALL nodes/markers/points/Geocodes
                DistanceCalculator calculator = new DistanceCalculator();
                var t= calculator.CalculateNodePaths1(graph, markerList.First().Mid);
                
                // TODO make sorted marker List
                List<Marker> returnMarkerList = new List<Marker>();
                returnMarkerList.Add(markerList.First());
                foreach (var nodePath in t)
                {
                    returnMarkerList.Add(markerList.Find(x=> x.Mid.Equals(nodePath.Name)));
                }

                // TODO return sorted list of markers as Json page/string
                string jsonReturn = JsonConvert.SerializeObject(returnMarkerList);
                ViewBag.JsonReturn = jsonReturn;
                return View();

            }
            else
            {
                //TODO return error message: blank data
                ViewBag.JsonReturn = "data is blank!";
                return View();
            }

            
            
        }
    }
}