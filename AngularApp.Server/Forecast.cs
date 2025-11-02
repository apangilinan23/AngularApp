namespace AngularApp.Server
{
    public class Forecast
    {
        public int Id { get; set; }

        public DateOnly Date { get; set; }

        public double TemperatureC { get; set; }

        public double TemperatureF { get; set; }

        public string? Summary { get; set; }
    }
}
