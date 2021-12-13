using Microsoft.Extensions.Hosting;

namespace LightingServer
{
    public interface ILightingService : IHostedService
    {
        string CurrentDemo { get; set; }
    }
}