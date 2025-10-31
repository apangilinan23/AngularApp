import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { WeatherForecast } from './weather-forecast';

@Injectable({
  providedIn: 'root'
})
export class WeatherForecastService {
  private readonly url = '/weatherforecast';

  constructor(private http: HttpClient) {}

  getForecasts(): Observable<WeatherForecast[]> {
    return this.http.get<WeatherForecast[]>(this.url);
  }
}
