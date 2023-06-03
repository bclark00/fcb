import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  private baseUrl = '/api/data'; // Assuming the server route is '/api/data'

  constructor(private http: HttpClient) { }

  submitData(firstName: string, lastName: string, zipCode: string): Observable<string> {
    const data = {
      firstName: firstName,
      lastName: lastName,
      zipCode: zipCode
    };

    return this.http.post<string>(this.baseUrl, data);
  }
}
