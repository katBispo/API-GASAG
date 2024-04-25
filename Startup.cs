using System.Web.Http;
using System.Web.Http.Cors;
using Owin;

[assembly: OwinStartup(typeof(GasagApi.Startup))]

namespace GasagApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Habilita a configuração de CORS para permitir requisições de diferentes origens
            app.UseCors(CorsOptions.AllowAll);

            // Configura o roteamento da API
            HttpConfiguration config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();

            // Define a rota para o endpoint api/redirection/checkandredirect
            config.Routes.MapHttpRoute(
                name: "RedirectionApi",
                routeTemplate: "api/redirection/checkandredirect",
                defaults: new { controller = "UserRedirection", action = "CheckAndRedirect" }
            );

            app.UseWebApi(config);
        }
    }
}
