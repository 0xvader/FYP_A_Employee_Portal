using System;
using EmployeePortalTest.Areas.Identity.Data;
using EmployeePortalTest.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(EmployeePortalTest.Areas.Identity.IdentityHostingStartup))]
namespace EmployeePortalTest.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<bcckAuthDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("bcckContextConnection")));

                services.AddDefaultIdentity<EmployeePortalUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<bcckAuthDbContext>();
            });
        }
    }
}