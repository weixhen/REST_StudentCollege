import { Component, OnInit } from '@angular/core';
import { HttpMethodService } from '../http-services/http-method/http-method.service'

@Component({
  selector: 'app-student-registration',
  templateUrl: './student-registration.component.html',
  providers: [HttpMethodService],
  styleUrls: ['./student-registration.component.css']
})
export class StudentRegistrationComponent implements OnInit {

  constructor(private http_call: HttpMethodService) { }

  ngOnInit() {
  }

  validate_gpa(gpa) {
    let data = this.http_call.validate_gpa_service(gpa)
    alert(data);
  }

}
