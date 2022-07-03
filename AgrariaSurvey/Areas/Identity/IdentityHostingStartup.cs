using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(AgrariaSurvey.Areas.Identity.IdentityHostingStartup))]
namespace AgrariaSurvey.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
            //builder.ConfigureServices((context, services) => {
            //    services.AddDbContext<AgrariaSurveyContext>(options =>
            //        options.UseSqlServer(
            //            context.Configuration.GetConnectionString("AgrariaSurveyContext")));

            //services.AddDefaultIdentity<AgrariaSurveyUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<AgrariaSurveyContext>();
            //});
        }
    }
}