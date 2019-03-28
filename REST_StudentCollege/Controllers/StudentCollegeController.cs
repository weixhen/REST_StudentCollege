using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace REST_StudentCollege.Controllers
{
    [Route("api/[controller]")]
    public class StudentCollegeController : Controller
    {
        [HttpGet("checkgpa")]
        public int CheckGPA([FromQuery]int gpa)
        {
            try
            {
                if (gpa > 4)
                {
                    return -1;
                } else if (gpa <= 2)
                {
                    return 0;
                }
                else return 1;
            }
            catch (Exception e)
            {
                return -1;
            }  
        }

        private int SetPrioritySeating(int gpa)
        {
            try
            {
                if (gpa > 4 || gpa < 4)
                {
                    return -1;
                }
                else if (gpa >= 3.5 && gpa <= 4)
                {
                    return 1;
                }
                else if (gpa >= 3 && gpa < 3.5)
                {
                    return 2;
                }
                else if (gpa > 2 && gpa < 3)
                {
                    return 4;
                }
                else return -1;
            }
            catch (Exception e)
            {
                return -1;
            }
        }
    }
}
