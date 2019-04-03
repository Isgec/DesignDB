<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Informations.ascx.vb" Inherits="Informations" %>
<table id="TblEmp" style="min-width:300px" runat="server" >
<tr><td style="text-align: right;"><b>
  <asp:Label ID="Label2" runat="server"  Text="Name:"></asp:Label></b></td>
	<td >
  	<asp:Label ID="F_EmployeeName" runat="server" Font-Bold="False" Font-Size="10px"></asp:Label></td>
  </tr><tr>
	<td style="text-align: right;"><b>
  	<asp:Label ID="Label4" runat="server"  Text="Department:"></asp:Label></b></td>
	<td >
  	<asp:Label ID="F_Department" runat="server" Font-Bold="False" Font-Size="10px"></asp:Label></td>
  </tr><tr>
	<td style="text-align: right;"><b>
  	<asp:Label ID="Label6" runat="server"  Text="Designation:"></asp:Label></b></td>
	<td >
  	<asp:Label ID="F_Designation" runat="server" Font-Bold="False" Font-Size="10px"></asp:Label></td>
  </tr>
</table>



