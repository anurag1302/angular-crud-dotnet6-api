import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiResponseCollection } from 'src/models/person';

@Injectable({
  providedIn: 'root',
})
export class PersonService {
  BASE_URL = 'https://localhost:7016/api/Persons/GetAllPersons';
  constructor(private http: HttpClient) {}

  getEmployees(): Observable<ApiResponseCollection> {
    return this.http.get<ApiResponseCollection>(this.BASE_URL);
  }
}
