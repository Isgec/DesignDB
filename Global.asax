<%@ Application Language="VB" %>

<script runat="server">

  Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
  End Sub
    
    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application shutdown
    End Sub
        
    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
    ' StringBuilder message = new StringBuilder(); 
    ' if (Server != null) {
    '   Exception e;
    '   for (e = Server.GetLastError(); e != null; e = e.InnerException) 
    '   {
    '      message.AppendFormat("{0}: {1}{2}", 
    '                           e.GetType().FullName, 
    '                           e.Message,
    '                           e.StackTrace);
    '   }
    '   //Log the exception and inner exception information.
    '}
    '    The following is the sequence in which events occur when a master page is merged with a content page:
    'Master page controls Init event.
    'Content controls Init event.
    'Master page Init event.
    'Content page Init event.
    'Content page Load event.
    'Master page Load event.
    'Content controls Load event.
    'Content page PreRender event.
    'Master page PreRender event.
    'Master page controls PreRender event.
    'Content controls PreRender event.

  End Sub

	Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
		Try
			SIS.SYS.Utilities.SessionManager.CreateSessionEnvironement()
			
		Catch ex As Exception

		End Try
	End Sub

	Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
		Try
			SIS.SYS.Utilities.SessionManager.DestroySessionEnvironement()
		Catch ex As Exception
		End Try
	End Sub

  Protected Sub Application_BeginRequest(ByVal sender As Object, ByVal e As System.EventArgs)
    
    'Dim mFile As String = Server.MapPath(Request.AppRelativeCurrentExecutionFilePath)
    'If mFile.IndexOf("App_Forms") < 0 Then Exit Sub
    'Dim ts As IO.StreamReader = New IO.StreamReader(mFile)
    'Dim mstr As String = ts.ReadToEnd
    'ts.Close()
    'ts = New IO.StreamReader(Server.MapPath("~/cphid.txt"))
    'Dim ncphid As String = ts.ReadLine
    'ts.Close()
    'Dim aStr() As String = mstr.Split(" ".ToCharArray)
    'For I As Long = 0 To aStr.Length - 1
    '  If aStr(I).ToLower.StartsWith("contentplaceholderid") Then
    '    aStr(I) = "ContentPlaceHolderID=""" & ncphid & """"
    '    Exit For
    '  End If
    'Next
    'Dim tr As IO.StreamWriter = New IO.StreamWriter(mFile)
    'tr.Write(Join(aStr, " "))
    'tr.Close()
    

  End Sub
</script>