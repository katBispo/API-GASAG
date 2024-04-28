using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Drawing;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["user"] != null) && (Session["user"].ToString() != ""))
        {
            Log.Logar("Session[user] on redirect to HomeUser.aspx = '" + Session["user"].ToString() + "'");
            //Response.Redirect("HomeUser.aspx");
            Response.Redirect("SistemasAcesso.aspx");
        }
        else
        {
            string mg = Request.QueryString["mg"];
            if (mg != null && mg != "")
            {
                lblInfor.ForeColor = System.Drawing.Color.White;
                lblInfor.BackColor = System.Drawing.Color.LightSeaGreen;
                lblInfor.Text = "Sucesso na atualização de seus dados, tente logar com a nova senha.";
                lblInfor.Visible = true;
            }
            //Response.Write("Nao esta logado");
        }
        SetFocus(TxtMatricula);
    }
    protected void BtnEnviar_Click(object sender, EventArgs e)
    {
        int matricula = 0;
        string senha = null;

        senha = TxtSenha.Text;

        try
        {
            string matr = TxtMatricula.Text;
            string catMatr = matr;
            //verificando quantos digitos tem na matricula
            if (matr.Length < 8 && matr.Length > 0)
            {
                if (matr.Length == 5)
                    catMatr = "010" + matr.ToString();
                else if (matr.Length == 6)
                    catMatr = "01" + matr.ToString();
                else if (matr.Length < 6)
                    catMatr = "0";
            }
            matricula = Convert.ToInt32(catMatr.ToString());
            //Response.Write("matricula: " + matricula);
        }
        catch (Exception exp)
        {
            //Response.Write("{0} Exception caught." + exp);
            Console.Write("{0} Exception caught.", exp);
        }

        Usuario user = new Usuario();

        if (user.ValidUserById(matricula) > 0)
        {
            if (user.GetFewFieldsOfValidateUser(matricula, senha) > 0)
            {

                lblInfor.ForeColor = System.Drawing.Color.White;
                lblInfor.BackColor = System.Drawing.Color.DodgerBlue;

                lblInfor.Text = "O usuario está logado";

                Session["user"] = matricula;
                //UsuarioDataAccess.UpdateLastLogon(matricula, DateTime.Now);

                DataSet dslogon = UsuarioDataAccess.GetUserByLogon(matricula);

                DateTime last_logon = String.IsNullOrEmpty(dslogon.Tables[0].Rows[0]["last_logon"].ToString()) ? DateTime.MinValue : Convert.ToDateTime(dslogon.Tables[0].Rows[0]["last_logon"]);
                DateTime fail_logon = String.IsNullOrEmpty(dslogon.Tables[0].Rows[0]["fail_logon"].ToString()) ? DateTime.MinValue : Convert.ToDateTime(dslogon.Tables[0].Rows[0]["fail_logon"]);
                int count_fail_access = String.IsNullOrEmpty(dslogon.Tables[0].Rows[0]["count_fail_access"].ToString()) ? 0 : Convert.ToInt32(dslogon.Tables[0].Rows[0]["count_fail_access"]);
                int user_block = String.IsNullOrEmpty(dslogon.Tables[0].Rows[0]["user_block"].ToString()) ? 0 : Convert.ToInt32(dslogon.Tables[0].Rows[0]["user_block"]);
                DateTime data_user_block = String.IsNullOrEmpty(dslogon.Tables[0].Rows[0]["data_user_block"].ToString()) ? DateTime.MinValue : Convert.ToDateTime(dslogon.Tables[0].Rows[0]["data_user_block"]);

                DataSet dsconfig = UsuarioDataAccess.GetAllTimeConfig();

                int fail_logon_access = Convert.ToInt32(dsconfig.Tables[0].Rows[0]["fail_logon_access"]);
                int time_block = Convert.ToInt32(dsconfig.Tables[0].Rows[0]["time_block"]);
                int time_try_access = Convert.ToInt32(dsconfig.Tables[0].Rows[0]["time_try_access"]);

                if (user_block == 1)
                {
                    if ((DateTime.Now - data_user_block).Minutes > time_block)
                    {
                        UsuarioDataAccess.UpdateBlockUser(matricula, 0, DateTime.MinValue);

                        last_logon = DateTime.Now;
                        UsuarioDataAccess.UpdateLastLogon(matricula, last_logon);

                        count_fail_access = 0;
                        UsuarioDataAccess.UpdateCountFail(matricula, count_fail_access);

                        //Response.Redirect("HomeUser.aspx");
                        Response.Redirect("SistemasAcesso.aspx");
                    }
                    else
                    {
                        lblInfor.ForeColor = System.Drawing.Color.White;
                        lblInfor.BackColor = System.Drawing.Color.Brown;
                        lblInfor.Text = "Usuário bloqueado! Aguarde " + time_block + " minutos, para desbloqueio automático, e tente novamente.";
                        lblInfor.Visible = true;
                    }
                }
                else
                {
                    Response.Redirect("SistemasAcesso.aspx");
                }
            }
            else
            {
                //Session["user"] = "";
                lblInfor.ForeColor = System.Drawing.Color.White;
                lblInfor.BackColor = System.Drawing.Color.Brown;
                lblInfor.Text = "Senha inválida, tente novamente.";
                lblInfor.Visible = true;

                DataSet dslogon = UsuarioDataAccess.GetUserByLogon(matricula);

                DateTime last_logon = String.IsNullOrEmpty(dslogon.Tables[0].Rows[0]["last_logon"].ToString()) ? DateTime.MinValue : Convert.ToDateTime(dslogon.Tables[0].Rows[0]["last_logon"]);
                DateTime fail_logon = String.IsNullOrEmpty(dslogon.Tables[0].Rows[0]["fail_logon"].ToString()) ? DateTime.MinValue : Convert.ToDateTime(dslogon.Tables[0].Rows[0]["fail_logon"]);
                int count_fail_access = String.IsNullOrEmpty(dslogon.Tables[0].Rows[0]["count_fail_access"].ToString()) ? 0 : Convert.ToInt32(dslogon.Tables[0].Rows[0]["count_fail_access"]);
                int user_block = String.IsNullOrEmpty(dslogon.Tables[0].Rows[0]["user_block"].ToString()) ? 0 : Convert.ToInt32(dslogon.Tables[0].Rows[0]["user_block"]);
                DateTime data_user_block = String.IsNullOrEmpty(dslogon.Tables[0].Rows[0]["data_user_block"].ToString()) ? DateTime.MinValue : Convert.ToDateTime(dslogon.Tables[0].Rows[0]["data_user_block"]);

                DataSet dsconfig = UsuarioDataAccess.GetAllTimeConfig();

                int fail_logon_access = Convert.ToInt32(dsconfig.Tables[0].Rows[0]["fail_logon_access"]);
                int time_block = Convert.ToInt32(dsconfig.Tables[0].Rows[0]["time_block"]);
                int time_try_access = Convert.ToInt32(dsconfig.Tables[0].Rows[0]["time_try_access"]);

                if (user_block == 1)
                {
                    if ((DateTime.Now - data_user_block).Minutes > time_block)
                    {
                        UsuarioDataAccess.UpdateBlockUser(matricula, 0, DateTime.MinValue);

                        fail_logon = DateTime.Now;
                        UsuarioDataAccess.UpdateFailLogon(matricula, fail_logon);

                        count_fail_access = 1;
                        UsuarioDataAccess.UpdateCountFail(matricula, count_fail_access);

                        lblInfor.ForeColor = System.Drawing.Color.White;
                        lblInfor.BackColor = System.Drawing.Color.Brown;
                        lblInfor.Text = "Senha inválida, tente novamente. Tentativa(s) restante(s) 4.";
                        lblInfor.Visible = true;
                    }
                    else
                    {
                        lblInfor.ForeColor = System.Drawing.Color.White;
                        lblInfor.BackColor = System.Drawing.Color.Brown;
                        lblInfor.Text = "Usuário bloqueado! Aguarde " + time_block + " minutos, para desbloqueio automático, e tente novamente.";
                        lblInfor.Visible = true;
                    }
                }
                else
                {
                    if (count_fail_access == fail_logon_access)
                    {
                        //Bloquear usuario update table
                        UsuarioDataAccess.UpdateBlockUser(matricula, 1, DateTime.Now);

                        lblInfor.ForeColor = System.Drawing.Color.White;
                        lblInfor.BackColor = System.Drawing.Color.Brown;
                        lblInfor.Text = "Usuário bloqueado! Aguarde " + time_block + " minutos, para desbloqueio automático.";
                        lblInfor.Visible = true;
                    }
                    else
                    {
                        if ((DateTime.Now - fail_logon).Minutes > time_try_access)
                        {
                            fail_logon = DateTime.Now;
                            UsuarioDataAccess.UpdateFailLogon(matricula, fail_logon);

                            count_fail_access = 1;
                            UsuarioDataAccess.UpdateCountFail(matricula, count_fail_access);

                            lblInfor.ForeColor = System.Drawing.Color.White;
                            lblInfor.BackColor = System.Drawing.Color.Brown;
                            lblInfor.Text = "Senha inválida, tente novamente. Tentativa(s) restante(s) 4.";
                            lblInfor.Visible = true;
                        }
                        else /*if ((DateTime.Now - fail_logon).Minutes < 20)*/
                        {
                            count_fail_access = count_fail_access + 1;
                            UsuarioDataAccess.UpdateCountFail(matricula, count_fail_access);

                            lblInfor.ForeColor = System.Drawing.Color.White;
                            lblInfor.BackColor = System.Drawing.Color.Brown;
                            lblInfor.Text = "Senha inválida, tente novamente. Tentativa(s) restante(s) " + (fail_logon_access - count_fail_access) + ".";
                            lblInfor.Visible = true;
                        }
                    }
                }
            }
            user = null;
        }
        else
        {
            //Session["user"] = "";
            lblInfor.ForeColor = System.Drawing.Color.White;
            lblInfor.BackColor = System.Drawing.Color.Brown;
            lblInfor.Text = "O usuario não existe no sistema.";
            lblInfor.Visible = true;
        }
    }//fim btn


    protected bool CountLogon(int matricula)
    {
        return true;
    }


    //protected bool ValidUser(lvMatricula)
    //{ 
    //    bool Value = false;

    //    DataSet ds = UsuarioDataAccess.GetUserById(lvMatricula);

    //    if(Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString()) > 0)
    //    {
    //        Value = true;
    //        return Value;
    //    }

    //    return Value;
    //}

    //protected Boolean ValidUser(lvMatricula)
    //{
    //    string Result = false;

    //    DataSet ds = UsuarioDataAccess.GetUserById(lvMatricula);

    //    if(ds > 0 )
    //    {
    //        Result = true;            
    //    }

    //    return Result;

    //}
    //    protected void LinkButton1_Click(object sender, EventArgs e)
    //    {
    //        int matricula = 0;

    //        //verificando se preencheu a matricula
    //        if (TxtMatricula.Text == "")
    //        {
    //            lblInfor.Text = "Para solicitar sua senha digite sua matrícula ao lado.";
    //            lblInfor.Visible = true;
    //        }
    //        else
    //        {
    //            string matr = TxtMatricula.Text;
    //            string catMatr = matr;
    //            //verificando quantos digitos tem na matricula
    //            if (matr.Length < 8 && matr.Length > 0)
    //            {
    //                if (matr.Length == 5)
    //                    catMatr = "010" + matr.ToString();
    //                else if (matr.Length == 6)
    //                    catMatr = "01" + matr.ToString();
    //                else if (matr.Length < 6)
    //                    catMatr = "0";
    //            }
    //            matricula = Convert.ToInt32(catMatr.ToString());

    //            DataSet ds = UsuarioDataAccess.GetUserById(matricula);

    //            //se existir esse usuario
    //            if (ds.Tables[0].Rows.Count > 0)
    //            {
    //                if (!String.IsNullOrEmpty(ds.Tables[0].Rows[0]["email"].ToString()))
    //                {
    //                    string dataAtual = Convert.ToString(DateTime.Now.ToString("yyyyMMdd_hhmmss"));

    //                    lblInfor.Text = "Prezado usuário(a) em instantes será enviado para seu email sua solicitação de senha.";
    //                    try
    //                    {

    //                        //Abrir o arquivo
    //                        //StreamWriter valor = new StreamWriter("\\\\" + Request.ServerVariables["SERVER_NAME"] + "\\inetpub\\ftproot\\raptors.txt", true, Encoding.ASCII);
    ////                        string arq = "C:\\inetpub\\ftproot\\mail_to_send_" + dataAtual + ".txt";
    ////                        StreamWriter valor = new StreamWriter(arq, true, Encoding.ASCII);

    //                        string textMg = "";
    //                        textMg += "Usuario: " + ds.Tables[0].Rows[0]["id"].ToString() + " - " + ds.Tables[0].Rows[0]["nome"].ToString() + " solicitou senha.";
    //                        textMg += " Para restaurar sua senha clique ou copie e cole o link a seguir: http://" + Request.ServerVariables["SERVER_NAME"] + "/gasag/Recover.aspx?token=" + ds.Tables[0].Rows[0]["recover_id"].ToString() + "#ancora";

    //                        UsuarioDataAccess.SendMessage(ds.Tables[0].Rows[0]["email"].ToString(), "Solicitacao de Senha - Gasag", textMg);

    ////                        valor.Write(textMg);


    //                        //Fecha o arquivo
    ////                        valor.Close();
    //                    }
    //                    catch (Exception ex)
    //                    {
    //                        Console.WriteLine("Exception: " + ex.Message);
    //                    }
    //                    finally
    //                    {
    //                        Console.WriteLine("Parabéns, agora mais um arquivo dos Raptors.");
    //                    }
    //                }
    //                else
    //                {
    //                    lblInfor.Text = "Esse usuario nao tem um email registrado, logo não se pode enviar a senha para seu email,";
    //                    lblInfor.Text += "por favor contate o MCCO para resolver essa pendência!";
    //                }
    //            }
    //            else
    //            {
    //                lblInfor.Text = "Esse usuario nao existe, efetue o cadastro!";
    //            }
    //            //lblInfor.Text = "Foi enviado para seu email uma solicitação de nova senha.";
    //            lblInfor.Visible = true;
    //        }
    //    }
}
