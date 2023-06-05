import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  private baseUrl = 'home/SubmitData'; 

  constructor(private http: HttpClient) { }

  submitData(firstName: string, lastName: string, zipCode: string): Observable<string> {
    const data = {
      FirstName: firstName,
      LastName: lastName,
      ZipCode: zipCode
    };

    return this.http.post<string>(this.baseUrl, data);
  }
}
