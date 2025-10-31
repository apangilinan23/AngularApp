namespace AngularApp.Server
{
    public class Forecast
    {
        public DateOnly Date { get; set; }

        public string TemperatureC { get; set; }

        public string TemperatureF { get; set; }

        public string? Summary { get; set; }
    }
}
