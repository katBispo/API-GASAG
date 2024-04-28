<%@ Page Title="" Language="C#" MasterPageFile="~/MasterUser.master" AutoEventWireup="true" CodeFile="HomeUser.aspx.cs" Inherits="HomeUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:content id="Content2" contentplaceholderid="ContentPlaceBody" runat="Server" target="_blank">
    <asp:Label ID="Label1" runat="server" Text="Label" CssClass="lblInfor4"></asp:Label>
    <br />

 
    <fieldset class="fieldsetStyle1">
        <asp:Label ID="lblInfor" class="lblInfor" Visible="false" runat="server" Text="Label" target="_blank">
        </asp:Label>
        <legend style="width:100%;">            
            <asp:HyperLink ID="linkCadastro" name="ancora" runat="server" Text="" CssClass="sectionTitle"> Print's CCO - CCP - PN EFC - Restrições Pátios </asp:HyperLink>
        </legend>
       
        <!--   <ul>   
             <ul class="rrr">
                <li class="liApp">
                       
                       <a href="https://172.20.15.22/painelCCO/" target="_blank" rel= "noopeener noreferrer" text=" Painel CCO EFC" >
                        <img src="images/hist_cco.png " alt="Print CCO" class="imgLiApp">
                        <span style="font-size:11px" >Painel CCO EFC </span> 
                         
                       </a>
                    </li>
                    </ul>  -->
        

        <ul>   
            <ul class="rrr">
                <li class="liApp">
                     <asp:Button ID="BtnPainelCCO" runat="server" Text="Painel CCO EFC" OnClientClick="BtnPainelCCO_Click(); return false;" />
                </li>
             </ul>
        </ul>
           
        <script>
            
        </script>
        
         <ul>   
            <ul class="rrr">
                <li class="liApp">
                         <a href="https://172.20.15.22/Painelcco/prints/" target="_blank" rel= "noopeener noreferrer" text=" Histórico de Prints CCO">
                            <img src="images/historico_print_ihm.png " alt="Print CCO" class="imgLiApp">
                            <span style="font-size:11px" >Histórico Prints CCO</span>            
                        </a>
                    </li>
                    </ul>

         <ul>

         <ul class="rrr">
            <li class="liApp">
                
                <a href= "https://172.20.15.22/painelccpefc/" target="_blank" rel= "noopeener noreferrer">
                    <img src="images/ccp_hist.png" alt="Print CCP" class="imgLiApp">
                    <span style="font-size:11px" >Painel CCP EFC </span> 
                        </a>
                </li>
                </ul>
         <ul>      

          <ul class="rrr">
            <li class="liApp">
            <a href="https://172.20.15.22/painelCCPEFC/" target="_blank" rel= "noopeener noreferrer">
                <img src="images/tccp.png" alt="Print CCP" class="imgLiApp">
                    <span style="font-size:11px" >Histórico Prints CCP </span> 
                                                      
                       </a>
                   </li>
                   </ul>
         <ul>     
            <ul class="rrr">
            <li class="liApp">
            <a href="https://172.20.15.22/painelCCPEFC/" target="_blank" rel= "noopeener noreferrer">
                 <img src="images/pnefc.png" alt="Print CCP" class="imgLiApp">
                     <span style="font-size:11px" > Passagem em Nível PN-EFC </span> 
                                                                  
                        </a>
                     </li>
                    </ul>
         <ul>     
            <ul class="rrr">
            <li class="liApp">
            <a href="" target="_blank" rel= "noopeener noreferrer">
                  <img src="images/rest.jpg" alt="Restrições CCP" class="imgLiApp">
                        <span style="font-size:11px" > Restrições Pátios EFC </span> 
                                                                              
                        </a>
                     </li>
                    </ul>      
    </fieldset>
   <!-- <table border="1">
        <tr>
            <a href="" class="sectionTitle"> Todos os Sistemas da Eletro</a>
        </tr>       
       
        <tr>
            <td>
                <img src="images/relatorios.png" style="border: 0; padding-right: 15px;" height="100" width="105" />
            </td>
            <td style="margin-left: 100px;" colspan="3">
                <strong>SGF</strong> - Todos os relatórios do SGF, são eles: Gráfico de Trens, Movimentação
                de Trens, Movimentação de Trens Detalhada, Notas de Trens, Maquinas de Chave, RDO
                Excel, Tempos de Manutenção, Interdição, Restrições de Velocidade, Fuel Link, Playback.
            </td>
        </tr>
        <tr>
            <td>
                <asp:HyperLink ID="linkSilnImg" runat="server">
                    <img src="images/trem.png" style="border:0; padding-right: 15px;" />
                </asp:HyperLink>
            </td>
            <td>
                <strong>SILN</strong> - Sistema de Informações da Logística<br />
                Norte Indicadores On Line<br />
                <div id="dvRes" runat="server" visible="false"> 
                    <asp:HyperLink ID="linkSiln" runat="server">Para acessar clique aqui</asp:HyperLink>
                </div>
            </td>
            <td>
                <img src="images/tg.png" style="border: 0; padding-right: 15px; width: 100px; height: 90px" />
            </td>
            <td>
                <table style="width: 100%;">
                    <tr>
                        <th colspan="2" align="left">
                            Acesso Externo - clique no link
                        </th>
                    </tr>
                    <tr>
                        <th>
                            <asp:HyperLink ID="linkTG" runat="server" NavigateUrl="" ToolTip="Clique aqui para acesso ao Gráfico de Trens">TG</asp:HyperLink>
                        </th>
                        <td>
                            - External Train Graph
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <asp:HyperLink ID="linkRGV" runat="server" NavigateUrl="" ToolTip="Clique aqui para acesso ao RGV">RGV</asp:HyperLink>
                        </th>
                        <td>
                            - External RGV
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <asp:HyperLink ID="linkHM" runat="server" NavigateUrl="" ToolTip="Clique aqui para acesso ao HM">HM</asp:HyperLink>
                        </th>
                        <td>
                            - External Health Monitoring
                        </td>
                    </tr>
                    <tr>
                        <th colspan="2" align="left">
                            <asp:HyperLink ID="linkHelp" runat="server" NavigateUrl="">
                                <p style="color: #CC0000; text-transform: uppercase; font-size: 12px; font-weight: bold">
                                    Para qualquer erro, clique aqui!
                                </p>
                            </asp:HyperLink>
                        </th>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <img src="images/sinv.png" style="border: 0; padding-right: 15px;" height="100" width="105" />
            </td>
            <td style="margin-left: 100px;">
                <strong>SINV</strong> - Sistema de Inventário, onde são registrados todos os inventários,
                os que estão emprestados, etc...
            </td>
            <td>
                <img src="images/sind.JPG" style="border: 0; padding-right: 15px;" />
            </td>
            <td>
                <strong>SIND</strong> - Sistema de Indicadores, de eventos, falhas, MTBF, MTTR,
                equipamentos e disponibilidade.
            </td>
        </tr>
        <tr>
            <td>
                <img src="images/ldl2.png" style="border: 0; padding-right: 15px;" />
            </td>
            <td>
                <strong>LDL</strong> - Sistema que registra legalização de trabalho na pista, ou
                não.
            </td>
            <td>
                <img src="images/remota2.png" style="border: 0; padding-right: 15px; width: 100px;
                    height: 100px" />
            </td>
            <td>
                <strong>Remota Disconecta</strong> - Sistema que registra as remotas, mediante uma
                consulta.
            </td>
        </tr>
        <tr>
            <td>
                <img src="images/dbordo.png" style="border: 0; padding-right: 15px;" />
            </td>
            <td>
                <strong>Diário de Bordo</strong> - Sistema voltado para os supervisores para registro
                de seus dados, metas, etc, com relatórios, semanal, quinzenal e mensal.
            </td>
            <td>
                <img src="images/sapo.png" style="border: 0; padding-right: 15px; width: 100px; height: 90px" />
            </td>
            <td>
                <strong>SAPO</strong> - Sistema de Análise de Preditiva de Óleo, onde encontra-se
                um conjunto de relatorios e dados de amostras, preventivas, situação dos equipamentos,
                etc...
            </td>
        </tr>
    </table> -->
</asp:content>

