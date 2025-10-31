import { Component, OnInit, signal } from '@angular/core';
import { WeatherForecast } from './weather-forecast';
import { WeatherForecastService } from './weather-forecast-service';

@Component({
  selector: 'app-root',
  templateUrl: './app.html',
  standalone: false,
  styleUrl: './app.css'
})
export class App implements OnInit {
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

  protected readonly title = signal('angularapp.client');
}
