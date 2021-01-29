using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TripPlanner.API.Models;

namespace TripPlanner.RouteOptimization
{
    public class Feedback
    {
        public List<Point> path { get; set; }
        public double CurrentCost { get; set; }

        public Feedback(double val, Point p)
        {
            this.CurrentCost = val;
            this.path = new List<Point>();
            this.path.Add(p);
        }
    }
    public class TSPRecursion
    {
        public static async Task<List<Point>> GetOptRoute(List<Point> points)
        {
            var tmp = new List<Point>(points);
            var first = points.First();
            tmp.Remove(first);
            Feedback feed = await Recursion(first,first,tmp);
            return feed.path;
        }

        public static async Task<Feedback> Recursion(Point first, Point parent, List<Point> subset)
        {
            if(subset.Count == 0)
            {
                var feed = new Feedback(GetDistance(parent,first),first);
                feed.path.Add(parent);
                return feed;
            }
            else{
                List<Feedback> feeds = new List<Feedback>();
                foreach(var value in subset)
                {
                    List<Point> tmp = new List<Point>(subset);
                    tmp.Remove(value);
                    Feedback f = await Recursion(first,value,tmp);
                    f.CurrentCost = GetDistance(parent,value)+f.CurrentCost;
                    feeds.Add(f);
                }
                double lowest_cost = Double.MaxValue;
                Feedback lowest_f = null;
                foreach(var f in feeds)
                {
                    if(f.CurrentCost <= lowest_cost)
                    {
                        lowest_cost = f.CurrentCost;
                        lowest_f = f;
                    }
                }
                lowest_f.path.Add(parent);
                return lowest_f;
            }
        }

        //X = Longitude, Y = Latitude
        public static double GetDistance(Point p1, Point p2)
        {
            double x = Math.Abs(p2.Lng - p1.Lng);
            double y = Math.Abs(p2.Lat - p1.Lat);
            return Math.Sqrt(Math.Pow(x,2)+Math.Pow(y,2));
        }


    }   
}