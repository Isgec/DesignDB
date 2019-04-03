Partial Class Login0
	Inherits System.Web.UI.UserControl
	Public Event SignOut(ByVal sender As Object, ByVal e As System.EventArgs)
	Public Event SignedIn(ByVal sender As Object, ByVal e As System.EventArgs)
	Dim Uid As String = ""
	Dim Upw As String = ""
	Sub LoggingIn(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LoginCancelEventArgs)
		For Each _key In Request.Form.Keys
			If _key.ToString.ToLower.IndexOf("username") > -1 Then
				If Request.Form(_key.ToString) <> String.Empty Then
					Uid = Request.Form(_key.ToString)
				End If
			End If
			If _key.ToString.ToLower.IndexOf("password") > -1 Then
				If Request.Form(_key).ToString <> String.Empty Then
					Upw = Request.Form(_key.ToString)
				End If
			End If
		Next
		e.Cancel = False
	End Sub
	Public Sub LoggedIn(ByVal sender As Object, ByVal e As System.EventArgs)
		Dim oLogin As System.Web.UI.WebControls.Login = CType(sender, Login)
		Dim Username As String = oLogin.UserName
		SIS.SYS.Utilities.SessionManager.InitializeEnvironment(Username)
    RaiseEvent SignedIn(sender, e)
	End Sub
	Public Sub LoginError(ByVal sender As Object, ByVal e As System.EventArgs)
		Dim oLogin As System.Web.UI.WebControls.Login = CType(sender, Login)
		Dim Username As String = oLogin.UserName
		Dim oUsr As MembershipUser = Membership.GetUser(Username)
		If oUsr Is Nothing Then
			oLogin.FailureText = "Invalid User ID."
		Else
			If oUsr.IsLockedOut Then
				oLogin.FailureText = "User ID is blocked. Contact system deptt."
			Else
				oLogin.FailureText = "Invalid Password."
			End If
		End If
	End Sub
	Public Sub LoggedOut(ByVal sender As Object, ByVal e As System.EventArgs)
    RaiseEvent SignOut(sender, e)
    SIS.SYS.Utilities.SessionManager.DestroySessionEnvironement()
    Response.Redirect("~/Default.aspx")

  End Sub
End Class
