using System;
using System.Net.Http;

using Microsoft.Xrm.Sdk;

using TestJson.Models;

namespace TestJson
{
    public class WhatsMyIP : PluginBase
    {
        public WhatsMyIP(string unsecureConfiguration, string secureConfiguration) : base(typeof(WhatsMyIP))
        {
            {

            }
        }

        // Entry point for custom business logic execution
        protected override void ExecuteDataversePlugin(ILocalPluginContext localPluginContext)
        {
            if (localPluginContext == null)
            {
                throw new ArgumentNullException(nameof(localPluginContext));
            }

            var context = localPluginContext.PluginExecutionContext;

            var weatherForecast = new WeatherForecast() { Date = DateTimeOffset.UtcNow, Summary = "Sunny with clear skies", TemperatureC = 28 };
            var json = System.Text.Json.JsonSerializer.Serialize(weatherForecast);

            var httpClient = new HttpClient();
            var response = httpClient.GetAsync("https://ifconfig.me").Result;
            var ip = response.Content.ReadAsStringAsync().Result;

            localPluginContext.Trace(ip);

            throw new InvalidPluginExecutionException(ip);

            // TODO: Implement your custom business logic

            // Check for the entity on which the plugin would be registered
            //if (context.InputParameters.Contains("Target") && context.InputParameters["Target"] is Entity)
            //{
            //    var entity = (Entity)context.InputParameters["Target"];

            //    // Check for entity name on which this plugin would be registered
            //    if (entity.LogicalName == "account")
            //    {

            //    }
            //}
        }
    }
}