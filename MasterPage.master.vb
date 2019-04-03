Imports System.Web.Services
Imports System.IO
Partial Class lgMasterPage
  Inherits System.Web.UI.MasterPage
  Public WriteOnly Property SetEncType As String
    Set(value As String)
      Me.form1.Attributes.Add("enctype", "multipart/form-data")
    End Set
  End Property
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    If Not SIS.SYS.Utilities.ValidateURL.Validate(Request.AppRelativeCurrentExecutionFilePath) Then
      Response.Redirect("~/Login.aspx")
    End If
    If HttpContext.Current.User.Identity.IsAuthenticated Then
      Dim mFile As String = HttpContext.Current.Server.MapPath("~/../UserRights/") & HttpContext.Current.Session("ApplicationID") & "/" & HttpContext.Current.User.Identity.Name & "_nMenu.xml"
      If IO.File.Exists(mFile) Then
        Dim tmp As IO.StreamReader = New IO.StreamReader(mFile)
        algmnu.InnerHtml = tmp.ReadToEnd().Replace("~", HttpContext.Current.Request.Url.Scheme & Uri.SchemeDelimiter & HttpContext.Current.Request.Url.Authority & HttpContext.Current.Request.ApplicationPath)
        tmp.Close()
      End If
    End If

  End Sub
  Public Function GetRelativePath(ByVal mPath As String) As String
    Return VirtualPathUtility.MakeRelative(Page.AppRelativeVirtualPath, mPath)
  End Function
  Public Property Master_Form() As HtmlForm
    Get
      Return Me.form1
    End Get
    Set(ByVal value As HtmlForm)
      Me.form1 = value
    End Set
  End Property
  Protected Sub ToolkitScriptManager1_AsyncPostBackError(ByVal sender As Object, ByVal e As System.Web.UI.AsyncPostBackErrorEventArgs) Handles ToolkitScriptManager1.AsyncPostBackError
    If (e.Exception.Data("ExtraInfo") <> Nothing) Then
      ToolkitScriptManager1.AsyncPostBackErrorMessage = e.Exception.Data("ExtraInfo").ToString()
    Else
      ToolkitScriptManager1.AsyncPostBackErrorMessage = e.Exception.Message
    End If
  End Sub

  Private Sub LoginLine1_SignOut(sender As Object, e As EventArgs) Handles LoginLine1.SignOut

  End Sub
End Class

