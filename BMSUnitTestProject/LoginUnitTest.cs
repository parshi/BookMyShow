using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookMyShow.Controllers;
using BookMyShow.Models;

namespace BMSUnitTestProject
{
    [TestClass]
    public class LoginUnitTest
    {
        [TestMethod]
        public void LoginTest()
        {
            Login loginDetails = new Login();
            loginDetails.Email = "admin@bookmyshow.com";
            loginDetails.Password = "admin";
            var controller = new LoginController();
            //Response result = controller.UserLogin(loginDetails);
            //Response expectedResult =new Response { Status = "Success", Message = "Login Successfully" };
            //Assert.AreEqual<Response>(result,expectedResult);
        }

        [TestMethod]
        public void RegisterTest()
        {
            Register details = new Register();
            details.Name = "admin1";
            details.Email = "admin1@bookmyshow.com";
            details.Password = "admin1";
            var controller = new LoginController();
            Response result = controller.UserRegistration(details);
            Response expectedResult = new Response { Status = "Success", Message = "Record SuccessFully Saved." };
            Assert.AreEqual<Response>(result, expectedResult);
        }
    }
}
