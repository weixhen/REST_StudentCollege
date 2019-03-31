using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.IO;

namespace REST_StudentCollege.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        [HttpPost("sendemail")]
        public IActionResult SendEmail([FromQuery]string toEmail, [FromQuery]string body, [FromQuery]string subject)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("weixhen@gmail.com");
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.EnableSsl = true;
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential()
            {
                UserName = "XXXXX",
                Password = "XXXXX"
            };
            mail.To.Add(new MailAddress(toEmail));
            mail.Subject = subject;
            mail.Body = body;
            try
            {
                smtp.Send(mail);
                return Ok();
            }
            catch (Exception e)
            {
                FileLogger.WriteLog(e.Message);
                return BadRequest(e);
            }
        }
    }
}