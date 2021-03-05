using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AspNetCore.Reporting.Angular
{
    public class RequestDiagnosticsMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestDiagnosticsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                if (context.Request.Form!=null)
                {
                    Console.WriteLine($"{context.Request.Method}: {context.Request.Path}");
                    var keys = context.Request.Form.Keys;
                    foreach (var key in keys)
                    {
                        var result = HttpUtility.UrlDecode(context.Request.Form[key].ToArray()[0]);
                        Console.WriteLine($"{key}:{result}");
                    }
                }

            }
            catch (Exception ex)
            {
                
            }
            await _next(context);
        }
    }
}
