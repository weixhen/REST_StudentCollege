import { Component, OnInit } from '@angular/core';
import { HttpMethodService } from '../http-services/http-method/http-method.service'

@Component({
  selector: 'app-student-registration',
  templateUrl: './student-registration.component.html',
  providers: [HttpMethodService],
  styleUrls: ['./student-registration.component.css']
})
export class StudentRegistrationComponent implements OnInit {
  validation: number;
  gpa_api_url: string;
  constructor(private http_call: HttpMethodService) { }
  txtname; ddlstate; txtemail; txtscore;
  selectedFiles: FileList;
  fileName: string;
  subject = "Registration Status";
  emailbody: string;
  email_api_body = "";
  registrationId;
  

  ngOnInit() {
  }

  detectFiles(event) {
    this.selectedFiles = event.target.files;
    this.fileName = this.selectedFiles[0].name;
  }

  //testtxt() {
  //  alert(this.fileName);
  //}

  register_student() {
    let api_url = "http://localhost:52220/api/StudentCollege/registerstudent?name=" + this.txtname + "&state=" + this.ddlstate + "&score=" + this.txtscore;
    let email_api_url = "http://localhost:52220/api/Email/sendemail?toemail=" + this.txtemail + "&body=" + this.emailbody + "&subject=" + this.subject;
    let attachment_api_url = "http://localhost:52220/api/Attachment/uploadattachment?registrationid=" + this.registrationId;
    let body = "";
    const formData = new FormData();
    //let body =
    //{
    //  "name": name,
    //  "state": state,
    //  "score": score
    //};
    if (this.selectedFiles) {
      formData.append(this.fileName, this.selectedFiles[0]);
    }

    this.http_call.request_general_post(api_url, body).subscribe(data => {
      if (data > 0) {
        //alert("registration complete. you are qualified");
        this.registrationId = data;
        this.http_call.request_general_post(attachment_api_url, formData).subscribe(data => {
        });

        this.emailbody = "registration complete. you are qualified";
        this.http_call.request_general_post(email_api_url, this.email_api_body).subscribe(data => {
        });
      }
      else if (data == -1) {
        //alert("registration complete. you are not qualified");
        this.registrationId = data;
        this.http_call.request_general_post(attachment_api_url, formData).subscribe(data => {
        });

        this.emailbody = "registration complete. you are not qualified";
        this.http_call.request_general_post(email_api_url, this.email_api_body).subscribe(data => {
        });
      }
      else {
        alert("error");
        //error logging
      }
    });
  }
}
