using System.Collections.Generic;

namespace BFF.SPA.Responses
{
    public class Response
    {
        public bool Success { get; set; }
        public List<string> Notifications { get; set; }
        public object Data { get; set; }
        public Response()
        {
            Success = true;
            Notifications = new List<string>();
        }
    }
}
