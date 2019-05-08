Imports System.IO
Imports OfficeOpenXml
Imports System.Web.Script.Serialization
Partial Class LGDefault
  Inherits System.Web.UI.Page
  Dim vc As String = ""
  Dim aList As New ArrayList
  Private Sub LGDefault_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender
    abc.Visible = False
    If Not HttpContext.Current.User.Identity.IsAuthenticated Then
      abc.Visible = True
      With aList
        .Add("http://192.9.200.146/HoldList/Default.aspx, HLL.jpg")
        .Add("http://192.9.200.172:8080/joomlakm/index.php?option=com_users&view=login, EPM.jpg")
        .Add("http://192.9.200.161/Citrix/XenApp1/clientDetection/downloadNative.aspx, CITRIX.jpg")
        .Add("http://192.9.200.146/Webmapp1/DM_mMain/App_Forms/mGdmisg121.aspx, RDL.jpg")
        .Add("http://192.9.200.146/Webmapp1/DM_mMain/App_Forms/mGdmisg121_all.aspx, ADL.jpg")
        .Add("http://192.9.200.233:8069/web/login, PAT.jpg")
        .Add("http://192.168.25.44:8080/OpenKM/login.jsp, OKM.jpg")
        .Add("http://192.9.200.146/WebERP1/Default.aspx, ER.jpg")
      End With
      For Each itm As String In aList
        Dim aTmp() As String = itm.Split(",".ToCharArray)
        Dim pnl As New Panel
        pnl.Attributes.Add("style", "float:left;margin:10px;")
        pnl.Visible = True
        pnl.BorderColor = System.Drawing.Color.Blue
        pnl.BorderStyle = BorderStyle.Solid
        pnl.BorderWidth = Unit.Point(1)

        Dim img As New ImageButton
        With img
          .Height = Unit.Pixel(50)
          .Width = Unit.Pixel(200)
          .ImageUrl = "~/" & aTmp(1).Trim
          .AlternateText = "x"
          .PostBackUrl = aTmp(0)
          .Visible = True
        End With
        pnl.Controls.Add(img)
        abc.Controls.Add(pnl)
      Next
    End If
  End Sub
End Class
