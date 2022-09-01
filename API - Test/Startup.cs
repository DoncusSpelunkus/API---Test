using API.Core.AppService;
using API.Core.AppService.Service;
using API.Core.DataService;
using API.Data;
using API.Data.Repositories;
using Microsoft.EntityFrameworkCore;


namespace API___Test
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<ApiAppContext>(opt => opt.UseSqlite("Data Source=API___Test.db"));
            services.AddScoped<IUserRepo, UserRepository>();
            services.AddScoped<IUserService, UserService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetService<ApiAppContext>();
                    DBIntiializer.giveMeSeed(ctx);
                }
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
