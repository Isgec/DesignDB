Partial Class Login1
  Inherits System.Web.UI.UserControl
  Public Sub LoggedIn(ByVal sender As Object, ByVal e As System.EventArgs)
    Dim oLogin As System.Web.UI.WebControls.Login = CType(sender, Login)
    Dim Username As String = oLogin.UserName
    SIS.SYS.Utilities.SessionManager.InitializeEnvironment(Username)
	End Sub
End Class
