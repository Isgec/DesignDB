<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ErrorPage.aspx.vb" Inherits="ErrorPage" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
  <div id="div1" class="page">
  <br />
  <br />
  
    <table style="width: 750px">
      <tr>
        <td style="height: 30px; background-color: #999966">
          <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="12px" Text="Error:"></asp:Label></td>
      </tr>
      <tr>
        <td>
        <asp:Label ID="LabelError" runat="server" Text="Label"></asp:Label>
        </td>
      </tr>
    </table>
  <br />
  <br />
  </div>
</asp:Content>

