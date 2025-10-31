import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { map } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { User } from './user';

@Injectable({ providedIn: 'root' })
export class LoginService {
  constructor(private http: HttpClient) {}

  // Real login API call
  login(username: string): Observable<boolean> {
    const url = `/user?username=${encodeURIComponent(username)}`;
    let responseResult = false;
    this.http.post<any>(url, null)
      .subscribe({
        next: (response) => {
          responseResult = response.result;
          if(response.result){
            console.log('POST successful:', response);
            alert('Login successful!');
          }
          else{
            alert('Login failed!');
          }
        },
        error: (error) => {
          console.error('There was an error during the POST request!', error);
          return false;
        }
      });

      return of(responseResult);
  }
}
    // return this.http.post<User>('/user',  username )
    //   .pipe(map(res => res.result));


