﻿using FishingManiaBulgaria.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CinemaApp.Web.Infrastructure.Extensions
{
    

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder ApplyMigrations(this IApplicationBuilder app)
        {
            using IServiceScope serviceScope = app.ApplicationServices.CreateScope();
            
            ApplicationDbContext dbContext = serviceScope
                .ServiceProvider
                .GetRequiredService<ApplicationDbContext>()!;
            dbContext.Database.Migrate();

            return app;
        }
    }
}
