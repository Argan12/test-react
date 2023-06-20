using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using TestReact.Middlewares;
using TestReact.Models.Entities;
using TestReact.Models.Interfaces;
using TestReact.Models.Services;
using TestReact.Models.StoredProcedures;

namespace TestReact;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Musicozor", Version = "v1" });
        });
        services.AddTransient<IArticleService, ArticleService>();
        services.AddTransient<ICommentService, CommentService>();
        services.AddTransient<IJwtService, JwtService>();
        services.AddTransient<ISecurityService, SecurityService>();
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<TestReactContext>();
        services.AddTransient<StoredProceduresContext>();
        services.AddDbContext<TestReactContext>(options => 
            options.UseSqlServer(Configuration.GetConnectionString("TestReactContext")), ServiceLifetime.Scoped);
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "csharp_goodfood_users v1"));
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
        );

        app.UseMiddleware<JwtMiddleware>();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}