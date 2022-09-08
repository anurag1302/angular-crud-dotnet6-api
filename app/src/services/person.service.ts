import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ApiResponseCollection } from 'src/models/person';

@Injectable({
  providedIn: 'root',
})
export class PersonService {
  BASE_URL = environment.BASE_API_URL;
  constructor(private http: HttpClient) {}

  getEmployees(): Observable<ApiResponseCollection> {
    let url = `${this.BASE_URL}GetAllPersons`;
    return this.http.get<ApiResponseCollection>(url);
  }
}
