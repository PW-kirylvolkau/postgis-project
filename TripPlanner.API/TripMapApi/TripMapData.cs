using System;


namespace TripMapApi
{
    public class MapData
    {
        public string Name { get; set; }
        public string WikiLink { get; set; }
        public string ImageLink { get; set; }

        public MapData(string name, string wikilink, string imagelink)
        {
            this.Name = name;
            this.WikiLink = wikilink;
            this.ImageLink = imagelink;
        }

        public override string ToString()
        {
            return "Name: "+this.Name+"\nWikipedia Link: "+this.WikiLink+"\nImage Link: "+ImageLink;
        }
    }
}