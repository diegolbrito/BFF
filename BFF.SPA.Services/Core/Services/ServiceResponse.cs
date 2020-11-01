using System.Collections.Generic;
using System.Linq;

namespace BFF.SPA.Services.Core.Services
{
    public class ServiceResponse<T>
    {
        public List<string> Notifications { get; set; }
        public T Data { get; set; }
        public ServiceResponse() => Notifications = new List<string>();
        public void AddNotification(params string[] notification) => Notifications.AddRange(notification?.Where(p => !string.IsNullOrWhiteSpace(p)));
    }
}
