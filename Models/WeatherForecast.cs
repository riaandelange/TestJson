using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TestJson.Models
{
    public class WeatherForecast
    {
        public DateTimeOffset Date { get; set; }
        public int TemperatureC { get; set; }
        public string Summary { get; set; }
    }
}
