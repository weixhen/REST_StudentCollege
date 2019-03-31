using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace REST_StudentCollege.Controllers
{
    [Route("api/[controller]")]
    public class StudentCollegeController : Controller
    {
        public double GetGPA(double score)
        {
            double gpa = 0;
            if (score >= 90 && score <= 100)
                gpa = 4;
            else if (score >= 80 && score < 90  )
                gpa = 3.5;
            else if (score >= 70 && score < 80 )
                gpa = 3;
            else if (score >= 60 && score < 70  )
                gpa = 2.5;
            else if (score < 60)
                gpa = 2;
            else return -1;

            return gpa;
        }
        [HttpPost("registerstudent")]
        public int RegisterStudent([FromQuery]string name, [FromQuery]string state, [FromQuery]double score)
        {
            double gpa = 0;
            
            if (state == "penang")
                score = score * 1.05;
            gpa = GetGPA(score);
            //if (score >= 90)
            //    gpa = 4;
            //else if (score < 90)
            //    gpa = 3.5;
            //else if (score < 80)
            //    gpa = 3;
            //else if (score < 70)
            //    gpa = 2.5;
            //else if (score < 60)
            //    gpa = 2;

            string connectionString = "";//get connection string from config file.
            string storedProcName = "[dbo].[spInsertStudentRegistration]";
            SqlParameter[] sqlParameter = new SqlParameter[4];
            sqlParameter[0] = new SqlParameter("@name", SqlDbType.VarChar);
            sqlParameter[0].Value = name;
            sqlParameter[1] = new SqlParameter("@state", SqlDbType.VarChar);
            sqlParameter[1].Value = state;
            sqlParameter[2] = new SqlParameter("@score", SqlDbType.Int);
            sqlParameter[2].Value = score;
            sqlParameter[3] = new SqlParameter("@gpa", SqlDbType.Int);
            sqlParameter[3].Value = gpa;
            try
            {
                if (@gpa <= 2)
                    return -1; //not qualified
                else
                {
                    object obj = SqlHelper.ExecuteScalar(connectionString, CommandType.StoredProcedure, storedProcName, sqlParameter);
                    return Convert.ToInt32(obj);
                }
            }
            catch (Exception e)
            {
                FileLogger.WriteLog(e.Message);
                return 0; //error
            }  
        }
    }
}
