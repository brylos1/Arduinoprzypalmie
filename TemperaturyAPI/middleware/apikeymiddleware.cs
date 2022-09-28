using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace TemperaturyAPI.middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class apikeymiddleware
    {
        private readonly RequestDelegate _next;

        public apikeymiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue("APIKEY", out
                var extractedApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Nie dostarczono klucza api");
                return;
            }
            var appSettings = context.RequestServices.GetRequiredService<IConfiguration>();
            var apiKey = appSettings.GetValue<string>("APIKEY");
            if (!apiKey.Equals(extractedApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Nie poprawny klucz api");
                return;
            }
            await _next(context);
        }
    }
}

