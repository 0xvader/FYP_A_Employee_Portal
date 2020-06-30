using System;
using Employee_Portal_Test.Areas.Identity.Data;
using Employee_Portal_Test.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Employee_Portal_Test.Areas.Identity.IdentityHostingStartup))]
namespace Employee_Portal_Test.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<Employee_Portal_TestDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("Employee_Portal_TestDbContextConnection")));
                 
                services.AddDefaultIdentity<Employee_Portal_TestUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;//true
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                })
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<Employee_Portal_TestDbContext>();
            });
        }
    }
}