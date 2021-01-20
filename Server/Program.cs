using System;
using System.Reflection;
using Owin;
using System.Web.Http;
using Microsoft.Owin.Hosting;
using Swashbuckle.Application;
using Microsoft.Owin;

class Program
{

    static void Main(string[] args)
    {
        string baseAddress = $"http://localhost:{(args.Length > 0 ? args[0] : "9001")}/";

        // Start OWIN host 
        using (WebApp.Start<Startup>(url: baseAddress))
        {
            Console.WriteLine($"Application Started at: {baseAddress}");
            Console.WriteLine($"Swagger available at: {baseAddress}swagger/");
            Console.ReadLine();
        }
    }
    public class Startup
    {
        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public void Configuration(IAppBuilder appBuilder)
        {
            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.MapHttpAttributeRoutes();
            config.EnableSystemDiagnosticsTracing();
            config.EnableSwagger(c =>
            {
                c.SingleApiVersion("v1", "OWIN version: " + Assembly.GetAssembly(typeof(OwinContext)).GetName().Version);
                c.IncludeXmlComments($"{System.AppDomain.CurrentDomain.BaseDirectory}{Assembly.GetExecutingAssembly().GetName().Name}.xml");

            }).EnableSwaggerUi();
            appBuilder.UseWebApi(config);
        }
    }
}