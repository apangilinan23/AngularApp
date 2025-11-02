import { Component, OnInit } from '@angular/core';
import { WeatherForecast } from './weather-forecast';
import { WeatherForecastService } from './weather-forecast-service';

@Component({
  selector: 'app-weather',
  templateUrl: './weather.component.html',
  styleUrls: ['./weather.component.css'],
  standalone: false,
})
export class WeatherComponent implements OnInit {
  public forecasts: WeatherForecast[] = [];

  constructor(private forecastService: WeatherForecastService) {}

  ngOnInit() {
    this.getForecasts();
  }

  getForecasts() {
    this.forecastService.getForecasts().subscribe(
      (result) => {
        this.forecasts = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }
}
