<%@ Page Title="" Language="C#" MasterPageFile="~/MasterUser.master" StylesheetTheme="ThemeGridViewTable"
    AutoEventWireup="true" CodeFile="Usuarios.aspx.cs" Inherits="Sistemas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:content id="Content2" contentplaceholderid="ContentPlaceBody" runat="Server">
     
    <%--link anterior--%>
    <%--<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/SearchUser.aspx">Para visualizar um usuário com perfil, clique aqui</asp:HyperLink>--%>
    
   
    <a href="" name="ancora"></a>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
        TypeName="Usuario" onobjectcreating="ObjectDataSource1_ObjectCreating" 
        SelectMethod="GetFewFieldsAppForAdm">
        <SelectParameters>
            <asp:SessionParameter Name="idUser" SessionField="idUser" Type="Int32" />            
        </SelectParameters>
    </asp:ObjectDataSource>
       
    <asp:GridView ID="GridView1" runat="server" CellPadding="3" DataSourceID="ObjectDataSource1"
        Caption="Administro os seguintes Sistemas" CssClass="GridViewStyle"
        OnRowDataBound="GridView1_RowDataBound" EmptyDataText="Não possui nenhum sistema cadastrado"
        OnRowCommand="GridView1_RowCommand" AllowPaging="True" >
        <AlternatingRowStyle HorizontalAlign="Justify" VerticalAlign="Middle" height="10px"/>
        <RowStyle HorizontalAlign="Justify" VerticalAlign="Middle" height="10px"/>
        <Columns>
            <asp:ButtonField CommandName="UsuariosSemAcess" Text="Usuários sem Autorização" />
            <asp:ButtonField CommandName="TodosUsuarios" Text="Todos Usuários" />            
        </Columns>
    </asp:GridView>
    <br />
        <div style="text-align: center; margin: 0 auto">
            <a class="buttonDestaque4" href="SearchUser.aspx">Para visualizar um usuário com perfil, clique aqui</a><br />
        </div>
</asp:content>

