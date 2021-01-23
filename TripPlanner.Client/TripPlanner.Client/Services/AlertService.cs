using System;
using TripPlanner.Client.Models.UI;

namespace TripPlanner.Client.Services
{
    public interface IAlertService
    {
        event Action<Alert> OnAlert;
        void Success(string message, bool keepAfterRouteChange = false, bool autoClose = true);
        void Error(string message, bool keepAfterRouteChange = false, bool autoClose = true);
        void Info(string message, bool keepAfterRouteChange = false, bool autoClose = true);
        void Warn(string message, bool keepAfterRouteChange = false, bool autoClose = true);
        void Alert(Alert alert);
        void Clear(string id = null);
    }
    
    public class AlertService : IAlertService
    {
        private const string DefaultId = "default-alert";
        public event Action<Alert> OnAlert;

        public void Success(string message, bool keepAfterRouteChange = false, bool autoClose = true)
        {
            Alert(new Alert
            {
                Type = AlertType.Success,
                Message = message,
                KeepAfterRouteChange = keepAfterRouteChange,
                AutoClose = autoClose
            });
        }        

        public void Error(string message, bool keepAfterRouteChange = false, bool autoClose = true)
        {
            Alert(new Alert
            {
                Type = AlertType.Error,
                Message = message,
                KeepAfterRouteChange = keepAfterRouteChange,
                AutoClose = autoClose
            });
        }        

        public void Info(string message, bool keepAfterRouteChange = false, bool autoClose = true)
        {
            Alert(new Alert
            {
                Type = AlertType.Info,
                Message = message,
                KeepAfterRouteChange = keepAfterRouteChange,
                AutoClose = autoClose
            });
        }        

        public void Warn(string message, bool keepAfterRouteChange = false, bool autoClose = true)
        {
            Alert(new Alert
            {
                Type = AlertType.Warning,
                Message = message,
                KeepAfterRouteChange = keepAfterRouteChange,
                AutoClose = autoClose
            });
        }        

        public void Alert(Alert alert)
        {
            alert.Id ??= DefaultId;
            OnAlert?.Invoke(alert);
        }

        public void Clear(string id = DefaultId)
        {
            OnAlert?.Invoke(new Alert { Id = id });
        }
    }
}