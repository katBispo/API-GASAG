using System;
using System.Web.Http;

namespace GasagApi.Controllers
{
    public class UserRedirectionController : ApiController
    {
        // Endpoint para verificar e redirecionar para o painelcco
        [HttpPost]
        [Route("api/redirection/checkandredirect")]
        public IHttpActionResult CheckAndRedirect(LoginData loginData)
        {
            // Verificar se o usuário está autenticado no Portal GASAG  
            Usuario user = new Usuario();
            //login log = new login();

            bool isAuthenticated = user.AuthenticateUser(loginData.Matricula, loginData.Senha);

            if (isAuthenticated)
            {
                // Redirecionar para o painelcco no servidor http://172.20.15.22/painelCCo
                return Redirect("http://172.20.15.22/painelCCO");
            }
            else
            {
                // Retornar mensagem de erro ou redirecionar para página de login no Portal GASAG
                return Redirect("http://172.20.15.22/gasag/login"); // ARRUMAR ENDEREÇO DE LOGIN DPS
            }
        }
    }

    private bool AuthenticateUser(int matricula, string senha)//nesse parametro aqui tem que ser loginData?
    {
        Usuario user = new Usuario();

        // Lógica de autenticação
        if (user.ValidUserById(matricula) > 0 && user.GetFewFieldsOfValidateUser(matricula, senha) > 0)
        {
            // Autenticação bem-sucedida
            Session["user"] = matricula;
            return true;
        }
        else
        {
            // Autenticação falhou
            return false;
        }
    }

    public class LoginData
    {
        public int Matricula { get; set; }
        public string Senha { get; set; }
    }
}
