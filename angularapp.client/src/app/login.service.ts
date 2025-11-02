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
    let loginParam: User = {userName: username, password: pword, result: false};
    return this.http.post<boolean>(url, loginParam);
  }
}


