using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin.Hosting;
using Owin;

namespace OwinServer
{
    [Authorize]
    public class ValuesController : ApiController
    {
        // GET api/values 
        public IEnumerable<string> Get()
        {
            return new[] { "value1", "value2" };
        }

        //HEAD api/values
        public void Head()
        {

        }

        //DELETE api/values
        public void Delete()
        {
            
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var baseAddress = "http://localhost:9000/";

            // Start OWIN host 
            using (WebApp.Start(baseAddress, Configuration))
            {
                Console.WriteLine("Host started");
                Console.ReadLine();
            }
        }

        public static void Configuration(IAppBuilder appBuilder)
        {
            // Configure Web API for self-host. 
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            appBuilder.UseWebApi(config);
        }
    }
}
