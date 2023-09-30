
namespace Dewy
{
    public interface IOpenWeatherMapController
    {
        public Task<OneCallResponse> GetTemperature(string lat, string lon);
    }
}