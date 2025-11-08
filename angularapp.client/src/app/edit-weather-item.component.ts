import { Component, Input, Output, EventEmitter } from '@angular/core';
import { WeatherForecast } from './weather-forecast';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { WeatherForecastService } from './weather-forecast-service';

@Component({
  selector: 'app-edit-weather-item',
  templateUrl: './edit-weather-item.component.html',
  styleUrls: ['./edit-weather-item.component.css'],
  standalone: false,
})
export class EditWeatherItemComponent {
  @Input() weatherItem!: WeatherForecast;
  @Output() save = new EventEmitter<WeatherForecast>();
  @Output() cancel = new EventEmitter<void>();

  editForm: FormGroup;

  constructor(private fb: FormBuilder, private router: Router, private forecastService: WeatherForecastService) {
    this.editForm = this.fb.group({
      date: [''],
      temperatureC: [''],
      temperatureF: [''],
      summary: ['']
    });
  }

  ngOnChanges() {
    if (localStorage.getItem('authToken') === null) {
      this.router.navigate(['']);
    }
    if (this.weatherItem) {
      this.editForm.patchValue(this.weatherItem);
      window.scrollTo(0, document.body.scrollHeight);
    }
  }

  onSave() {
    if (this.editForm.valid) {
      this.forecastService.saveForecast({ ...this.weatherItem, ...this.editForm.value }).subscribe({
        next: (savedForecast) => {
          this.save.emit(savedForecast);
          // this.save.emit({ ...this.weatherItem, ...this.editForm.value });
        }
      });
    }
  }

  onCancel() {
    this.cancel.emit();
  }
}
