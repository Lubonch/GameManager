namespace GameManagerWebAPI.Domain;

public class WeatherForecast
{
    public virtual DateOnly Date { get; set; }

    public virtual int TemperatureC { get; set; }

    public virtual int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public virtual string Summary { get; set; }
}
