<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Expired.aspx.vb" Inherits="Expired" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Perk: Session expired !!!</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <table style="width: 603px; height: 155px">
        <tr>
          <td style="text-align: center">
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="16px" ForeColor="DimGray"
              Text="Session Expired !!!"></asp:Label></td>
        </tr>
        <tr>
          <td style="text-align: center">
            <asp:HyperLink ID="HyperLink1" runat="server">Click here to go to Login page.</asp:HyperLink></td>
        </tr>
      </table>
    
    </div>
    </form>
</body>
</html>
