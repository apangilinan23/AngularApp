import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { map } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { User } from './user';

@Injectable({ providedIn: 'root' })
export class LoginService {
  constructor(private http: HttpClient) {}

  // Real login API call
  login(username: string, pword: string): Observable<boolean> {
    const url = `/user?username=${encodeURIComponent(username)}`;
    let responseResult = false;
    let loginParam: User = {userName: username, password: pword, result: false};
    this.http.post<any>(url, loginParam)
      .subscribe({
        next: (response) => {
          responseResult = response;
          if(responseResult){
            alert('Login successful!');
          }
          else{
            alert('Login failed!');
          }
        },
        error: (error) => {
          console.error('There was an error during the POST request!', error);
          return of(false);
        }
      });

      return of(responseResult);
  }
}


