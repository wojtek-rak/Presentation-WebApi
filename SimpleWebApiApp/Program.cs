using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

WebHost.CreateDefaultBuilder()
        .Configure(app =>
        {
            // configure application pipeline
            app.UseRouting();
            app.UseEndpoints(e =>
            {
                e.MapGet("/", c => c.Response.WriteAsync("Hello world!"));
                e.MapGet("hello/{name}", c => c.Response.WriteAsync($"Hello, {c.Request.RouteValues["name"]}"));
            });
        })
        .Build().Run();