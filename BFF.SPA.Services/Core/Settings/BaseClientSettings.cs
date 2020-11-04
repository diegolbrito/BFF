namespace BFF.SPA.Services.Core.Settings
{
    public abstract class BaseClientSettings
    {
        public string BaseAddress { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
