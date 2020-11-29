using Employee_Portal_Test.Areas.Identity.Data;
using Employee_Portal_Test.Areas.Identity.Pages.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;


namespace UnitTestProject1
{
    public static class MockHelpers
    {
    
        public static Mock<UserManager<TUser>> MockUserManager<TUser>() where TUser : class
        {
            IList<IUserValidator<TUser>> UserValidators = new List<IUserValidator<TUser>>();
            IList<IPasswordValidator<TUser>> PasswordValidators = new List<IPasswordValidator<TUser>>();

            var store = new Mock<IUserStore<TUser>>();
            UserValidators.Add(new UserValidator<TUser>());
            PasswordValidators.Add(new PasswordValidator<TUser>());
            var mgr = new Mock<UserManager<TUser>>(store.Object, null, null, UserValidators, PasswordValidators, null, null, null, null, null);
            return mgr;
        }

        public static Mock<SignInManager<TUser>> MockSignInManager<TUser>() where TUser : class
        {
            var context = new Mock<HttpContext>();
            var manager = MockUserManager<TUser>();
            return new Mock<SignInManager<TUser>>(manager.Object,
                new HttpContextAccessor { HttpContext = context.Object },
                new Mock<IUserClaimsPrincipalFactory<TUser>>().Object,
                null, null)
            { CallBase = true };
        }


    }
}






    [TestClass]
    public class UnitTest1
    {

    private  Mock<UserManager<Employee_Portal_TestUser>> _user;
    private  Mock<SignInManager<Employee_Portal_TestUser>> _sign;



    private readonly UserManager<Employee_Portal_TestUser> _userManager;
        private readonly SignInManager<Employee_Portal_TestUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;


        public UnitTest1(SignInManager<Employee_Portal_TestUser> signInManager,
            ILogger<LoginModel> logger,
            UserManager<Employee_Portal_TestUser> userManager, Mock<UserManager<Employee_Portal_TestUser>> user, Mock<SignInManager<Employee_Portal_TestUser>> sign)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        _user = user;
        _sign = sign;
        }



        [TestMethod]
        public void TestMethod1()
        {

        bool re = false;

            var result = _signInManager.PasswordSignInAsync("testp@gmail.com", "123456*", true, lockoutOnFailure: false);
            

            if(result.Result.Succeeded)
            {
                re = true;
                Assert.IsTrue(re);
            }
            Assert.IsFalse(re);
   
        }
    [TestMethod]
    public void TestMethod2()
    {
        Employee_Portal_Test.Models.Pmast Pmast = new Employee_Portal_Test.Models.Pmast();
        Employee_Portal_Test.Models.PmastTemp tem = new Employee_Portal_Test.Models.PmastTemp();
        Employee_Portal_Test.Models.bcckContext db = new Employee_Portal_Test.Models.bcckContext();
        Employee_Portal_Test.Models.bcck_tempContext dbt = new Employee_Portal_Test.Models.bcck_tempContext();

    }
}



    

