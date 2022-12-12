using System;
using System.Collections.Generic;

namespace EnvironmentVariables
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }
    //public class Root
    //{
    //    public int userId { get; set; }
    //    public int id { get; set; }
    //    public string title { get; set; }
    //    public bool completed { get; set; }
    //}
    //public class RootList
    //{
    //    public List<Root> Root { get; set; }
    //}
}
