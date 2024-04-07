import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

@Component({
  selector: 'app-fecth-data',
  templateUrl: './fecth-data.component.html',
  styleUrls: ['./fecth-data.component.scss']
})
export class FecthDataComponent implements OnInit {

  public forecasts: WeatherForecast [] = [];

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.http.get<WeatherForecast[]>(environment.baseUrl + 'api/weatherforecast').subscribe(result => {
      this.forecasts = result;
    }, (error) => {
      console.log(error);
    })
  }

}
