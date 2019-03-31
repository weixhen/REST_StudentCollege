using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace REST_StudentCollege.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttachmentController : ControllerBase
    {
        [HttpPost("uploadattachment")]
        public IActionResult UploadAttachment([FromQuery]int registrationid)
        {
            try
            {
                var file = Request.Form.Files[0];
                if (file.Length > 0)
                {
                    string filename = file.FileName;
                    string fileType = file.ContentType;
                    using (var ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        var fileBytes = ms.ToArray();

                        //string connectionString = "";//get connection string from config file.
                        //string storedProcName = "[dbo].[spInsertStudentRegistration]";
                        SqlParameter[] sqlParameter = new SqlParameter[4];
                        sqlParameter[0] = new SqlParameter("@filename", SqlDbType.VarChar);
                        sqlParameter[0].Value = filename;
                        sqlParameter[1] = new SqlParameter("@fileType", SqlDbType.VarChar);
                        sqlParameter[1].Value = fileType;
                        sqlParameter[2] = new SqlParameter("@registrationid", SqlDbType.Int);
                        sqlParameter[2].Value = registrationid;
                        sqlParameter[3] = new SqlParameter("@fileBytes", SqlDbType.VarBinary);
                        sqlParameter[3].Value = fileBytes;
                        //DataSet lDataSet = SqlHelper.ExecuteDataSet(connectionString, CommandType.StoredProcedure, storedProcName, null);
                    }
                }
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