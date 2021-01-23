namespace TripPlanner.Client.Models.UI
{
    public enum AlertType
    {
        Success,
        Error,
        Info,
        Warning
    }
    public class Alert
    {
        public string Id { get; set; }
        public AlertType Type { get; set; }
        public string Message { get; set; }
        public bool AutoClose { get; set; }
        public bool KeepAfterRouteChange { get; set; }
        public bool Fade { get; set; }
    }
}