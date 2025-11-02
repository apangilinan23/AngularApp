namespace AngularApp.Server
{
    public class Forecast
    {
        public int Id { get; set; }

        public DateOnly Date { get; set; }

        public decimal TemperatureC { get; set; }

        public decimal TemperatureF { get; set; }

        public string? Summary { get; set; }
    }
}
