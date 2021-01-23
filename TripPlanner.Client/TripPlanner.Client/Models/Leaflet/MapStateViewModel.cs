using Darnton.Blazor.Leaflet.LeafletMap;

namespace TripPlanner.Client.Models.Leaflet
{
    public class MapStateViewModel
    {
        public double MapCentreLatitude { get; set; }
        public double MapCentreLongitude { get; set; }
        public int Zoom { get; set; }
        public Darnton.Blazor.Leaflet.LeafletMap.Point MapContainerSize { get; set; }
        public Bounds MapViewPixelBounds { get; set; }
        public Darnton.Blazor.Leaflet.LeafletMap.Point MapLayerPixelOrigin { get; set; }
    }
}