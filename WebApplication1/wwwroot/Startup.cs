using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews();

        // Oturum yönetimi için gerekli servisleri ekler.
        services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromMinutes(30); // Oturum zaman aşım süresi, örnek olarak 30 dakika
        });

        services.AddMvc();

        services.AddDbContext<HospitalDbContext>(options =>
        {
            options.UseSqlite("Data Source=C:\\Users\\Administrator\\Desktop\\hastane.sqlite");
        });

        services.AddCors(options =>
        {
            options.AddPolicy("AllowAny", builder =>
            {
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            });
        });



    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            // Hata sayfasını geliştirme modunda gösterir.
            app.UseDeveloperExceptionPage();
        }
        else
        {
            // Hata durumunda "/Home/Error" sayfasına yönlendirir.
            app.UseExceptionHandler("/Home/Error");
        }

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            // Controller ve action yönlendirmelerini yapılandırır.
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            // Oturum yönetimini etkinleştirir.
            app.UseSession();

            // Ana sayfayı "Security" sayfasına yönlendirir.
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Security}/{id?}");
        });
    }
    


}
