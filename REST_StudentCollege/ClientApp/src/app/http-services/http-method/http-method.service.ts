import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaderResponse, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable } from "rxjs";

@Injectable()
export class HttpMethodService {

  constructor(private httpcall: HttpClient) { }

  http_request_get(api_url) {
    let general_option = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    let data = Observable.create(observer => this.httpcall.get(api_url, general_option).subscribe(
      data => {
        observer.next(data);
        observer.complete();
      },
      (err: HttpErrorResponse) => {
        //error logging
      }
    )
    )
  }

  http_request_post(api_url, body) {
    let general_option = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    return this.httpcall.post(api_url, body, general_option)
  }

  validate_gpa_service(gpa) {
    let gpa_api_url = 'http://localhost:49867/api/StudentCollege/checkgpa?gpa' + gpa;
    this.http_request_get(gpa_api_url)

  }
}
