using Microsoft.Xrm.Sdk;

using System;
using System.Net.Http;

using TestJson.Models;

namespace TestJson
{
    /// <summary>
    /// Plugin development guide: https://docs.microsoft.com/powerapps/developer/common-data-service/plug-ins
    /// Best practices and guidance: https://docs.microsoft.com/powerapps/developer/common-data-service/best-practices/business-logic/
    /// </summary>
    public class HelloWorld : PluginBase
    {
        public HelloWorld(string unsecureConfiguration, string secureConfiguration) : base(typeof(HelloWorld))
        {
            // TODO: Implement your custom configuration handling
            // https://docs.microsoft.com/powerapps/developer/common-data-service/register-plug-in#set-configuration-data
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
            
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetAsync("https://jsonplaceholder.typicode.com/posts/1").Result;  

            localPluginContext.Trace(json);

            throw new InvalidPluginExecutionException(json);

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
