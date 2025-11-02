import { Component, OnInit } from '@angular/core';
import { WeatherForecast } from './weather-forecast';
import { WeatherForecastService } from './weather-forecast-service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-weather',
  templateUrl: './weather.component.html',
  styleUrls: ['./weather.component.css'],
  standalone: false,
})
export class WeatherComponent implements OnInit {
  public forecasts: WeatherForecast[] = [];
  editingItem: WeatherForecast | null = null;
  editingIndex: number | null = null;

  constructor(private forecastService: WeatherForecastService, private router: Router) {}

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

  onEdit(item: WeatherForecast, index: number) {
    this.editingItem = { ...item };
    this.editingIndex = index;
  }

  onSaveEdit(updated: WeatherForecast) {
    if (this.editingIndex !== null) {
      this.forecasts[this.editingIndex] = updated;
    }
    this.editingItem = null;
    this.editingIndex = null;
  }

  onCancelEdit() {
    this.editingItem = null;
    this.editingIndex = null;
  }

  onLogout() {
    // Optionally clear any session/auth state here
    sessionStorage.clear();
    localStorage.clear();
    this.router.navigate(['']);
  }
}
