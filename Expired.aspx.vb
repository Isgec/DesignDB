
Partial Class Expired
    Inherits System.Web.UI.Page

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    If Page.IsPostBack Then
      Response.Redirect("Default.aspx")
    End If
  End Sub
End Class
