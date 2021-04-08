using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SimpleWebApiExampleApp;

WebHost.CreateDefaultBuilder()
        .ConfigureServices(s =>
        {
            s.AddSingleton<ContactService>();
            // configure dependency injection and ASP.NET Core services
        })
        .Configure(app =>
        {
            // configure application pipeline
            app.UseRouting();
            app.UseEndpoints(e =>
            {
                e.MapGet("/", c => c.Response.WriteAsync("Hello world!"));
                e.MapGet("hello/{name}", c => c.Response.WriteAsync($"Hello, {c.Request.RouteValues["name"]}"));


                var contactService = e.ServiceProvider.GetRequiredService<ContactService>();

                e.MapGet("/contacts",
                    async c => await c.Response.WriteAsJsonAsync(await contactService.GetAll()));
                e.MapGet("/contacts/{id:int}",
                    async c => await c.Response.WriteAsJsonAsync(await contactService.Get(int.Parse((string)c.Request.RouteValues["id"]))));
                e.MapPost("/contacts",
                    async c =>
                    {
                        await contactService.Add(await c.Request.ReadFromJsonAsync<Contact>());
                        c.Response.StatusCode = 201;
                    });
                e.MapDelete("/contacts/{id:int}",
                    async c =>
                    {
                        await contactService.Delete(int.Parse((string)c.Request.RouteValues["id"]));
                        c.Response.StatusCode = 204;
                    });
            });
        })
        .Build().Run();