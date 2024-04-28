using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.IdentityModel.Tokens.Jwt;


public partial class HomeUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        linkSiln.NavigateUrl = "http://" + Request.ServerVariables["SERVER_NAME"] + "/siln";

        linkSilnImg.NavigateUrl = "http://" + Request.ServerVariables["SERVER_NAME"] + "/siln";

        linkHelp.NavigateUrl = "http://" + Request.ServerVariables["SERVER_NAME"] + "/gasag/Info.aspx#perg1";

        //link para Acesso Externo a aplicação
        string server = Request.ServerVariables["SERVER_NAME"];
        if (server == "172.20.15.20" || server == "gasag")
        {
            linkTG.NavigateUrl = "http://172.20.15.10/mms/rail/tg.jnlp";
            linkRGV.NavigateUrl = "http://172.20.15.10/mms/rail/rgv.jnlp";
            linkHM.NavigateUrl = "http://172.20.15.10/mms/rail/hm.jnlp";
        }
        else if (server == "192.168.13.5" || server == "gasag")
        {
            linkTG.NavigateUrl = "http://192.168.33.101/mms/rail/tg.jnlp";
            linkRGV.NavigateUrl = "http://192.168.33.101/mms/rail/rgv.jnlp";
            linkHM.NavigateUrl = "http://192.168.33.101/mms/rail/hm.jnlp";
        }

        if ((Session["user"] != null) && (Session["user"].ToString() != ""))
        {
            int userId = Convert.ToInt32(Session["user"]);
            Label1.ForeColor = System.Drawing.Color.White;
            // Label1.BackColor = System.Drawing.Color.Teal;
            Label1.Text = "Prezado usuário, você está logado com a matricula:" + userId + ". Fique a vontade para usufruir de todos nossos sistemas. Você terá acesso normalmente aos Print's do CCO, CCP EFC e Restrições CCP.";

        }
        else
        {
            //Response.Redirect("Sistemas.aspx");
            //int userId = Convert.ToInt32(Session["user"]);
            //Label1.Text = "Prezado usuário, você NAO está logado com a matricula:" + userId + ". Fique a vontade para usufruir de todos nossos sistemas.<br><br>";

        }


    }

    protected void BtnPainelCCO_Click(object sender, EventArgs e)
    {
        // Gera o token JWT com o valor true
        string tokenJWT = GerarTokenJWT(true);

        Response.Redirect($"https://172.20.15.22/Painelcco/?token={tokenJWT}");
    }

    //gerar o token JWT
    private string GenerateJwtToken(bool isAuthenticated)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes("123");//chave secreta
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim("isAuthenticated", isAuthenticated.ToString())
            }),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                                                        SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}



