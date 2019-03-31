using System;
using Xunit;
using REST_StudentCollege;
using REST_StudentCollege.Controllers;

namespace XUnitTest
{
    public class UnitTest
    {
        [Theory]
        [InlineData(91, 4)]
        [InlineData(75, 3)]
        [InlineData(101, -1)]
        //[InlineData(62, 3.0)]
        public void TestGetGPA(double score, double gpa)
        {
            StudentCollegeController home = new StudentCollegeController();
            double result = home.GetGPA(score);
            Assert.Equal(gpa, result);
        }
    }
}
