import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaderResponse, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable } from "rxjs";

@Injectable()
export class HttpMethodService {

  constructor(private httpcall: HttpClient) { }

  request_general_get(api_url) {
    let general_options = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Cache-Control': 'no-cache',
        'Pragma': 'no-cache'
      }),
    };

    return Observable.create(observer => this.httpcall.get(api_url, general_options).subscribe(
      data => {
        observer.next(data);
        observer.complete();
      },
      (err: HttpErrorResponse) => {
        //error logging
        //navigate to proper
      }));
  }

  request_general_post(api_url, body) {
    let general_options = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Cache-Control': 'no-cache',
        'Pragma': 'no-cache'
      }),
    };

    return Observable.create(observer => this.httpcall.post(api_url, body, general_options).subscribe(
      data => {
        observer.next(data);
        observer.complete();
      },
      (err: HttpErrorResponse) => {
        //error logging
        //navigate to proper
      }));
  }

}
