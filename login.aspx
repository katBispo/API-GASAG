<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="js/masks.js" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceBody" runat="Server">
    
    <%--<asp:Panel runat="server" CssClass="panelTextLogin" >
        <asp:Label runat="server" Text="LOGIN NO PORTAL" CssClass="textLogin"></asp:Label>
    </asp:Panel>--%>
    <%--<br />--%>    
    <fieldset id="jh" class="fieldset">
        <br />
        <asp:Label ID="lblInfor" class="lblInfor" Visible="false" runat="server" Text="Label"></asp:Label>

       <%-- <legend class="textLogin" align="left"><a id="testeCadastro" name="ancora">Login no Portal</a></legend>--%>
        
        <div id="contact-form" class="wrapper" >
            <asp:Label ID="Label1" class="text-form" runat="server" Text="Matrícula: "></asp:Label>
            
            <asp:TextBox ID="TxtMatricula" CssClass="textBox1" MaxLength="8" runat="server" placeholder="Digite sua matrícula" onkeypress="return onlyNumbers(event)" AutoCompleteType="Disabled"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ValidationGroup="cadastrar" ControlToValidate="TxtMatricula"></asp:RequiredFieldValidator>           
            <br />
            <br />
            <asp:Label ID="Label7" class="text-form" runat="server" Text="Senha:"></asp:Label>
            <asp:TextBox ID="TxtSenha" CssClass="textBox1" TextMode="Password" runat="server" placeholder="Digite sua senha" AutoCompleteType="Disabled"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ControlToValidate="TxtSenha" ValidationGroup="cadastrar"> </asp:RequiredFieldValidator>
            <br />
        </div>
       <%--<asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/SolicitarRedefinirSenha.aspx">Esqueceu sua senha? Clique aqui!</asp:LinkButton>--%>
        <br style="clear: both;" />
        <br />
        <div class="buttons">
            <asp:Button CssClass="button" ID="BtnEnviar" runat="server" Text="Logar" ValidationGroup="cadastrar"
                OnClick="BtnEnviar_Click" />
            <asp:Button CssClass="button" ID="BtnLimpar" runat="server" Text="Limpar" />        
        </div>  
        <br />      
    </fieldset>  


    
    
   
</asp:Content>
