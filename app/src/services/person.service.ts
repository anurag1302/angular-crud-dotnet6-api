import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ApiResponse, ApiResponseCollection, Person } from 'src/models/person';

@Injectable({
  providedIn: 'root',
})
export class PersonService {
  BASE_URL = environment.BASE_API_URL;
  constructor(private http: HttpClient) {}

  getPersons(): Observable<ApiResponseCollection> {
    let url = `${this.BASE_URL}GetAllPersons`;
    return this.http.get<ApiResponseCollection>(url);
  }

  getPersonById(id: string): Observable<ApiResponse> {
    let url = `${this.BASE_URL}GetPersonById/${id}`;
    return this.http.get<ApiResponse>(url);
  }

  addAPerson(addPersonRequest: Person): Observable<ApiResponse> {
    let url = `${this.BASE_URL}CreatePerson`;
    return this.http.post<ApiResponse>(url, addPersonRequest);
  }
}
