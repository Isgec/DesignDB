Namespace SIS.SYS
  Public MustInherit Class InsertBaseControl
    Inherits System.Web.UI.UserControl
    Private _AddAndStay As Boolean = False
    Protected WithEvents _ToolBar1 As ToolBar0
    Protected WithEvents _FormView1 As FormView
    Private _dataClassName As String = ""
    Private _fvOK As Boolean = False
    Private _dcOK As Boolean = False
    Public Event DataInserted()
    Public Event InsertError(ByVal Message As String)
    Public ReadOnly Property FileName() As String
      Get
        Return _dataClassName & "." & _FormView1.ID
      End Get
    End Property
    Public Property DataClassName() As String
      Get
        Return _dataClassName
      End Get
      Set(ByVal value As String)
        _dataClassName = value
        _dcOK = True
        If _fvOK Then
          fvInit()
        End If
      End Set
    End Property
    Public Property SetToolBar() As ToolBar0
      Get
        Return _ToolBar1
      End Get
      Set(ByVal value As ToolBar0)
        _ToolBar1 = value
      End Set
    End Property
    Public Property SetFormView() As FormView
      Get
        Return _FormView1
      End Get
      Set(ByVal value As FormView)
        _FormView1 = value
        _fvOK = True
        If _dcOK Then
          fvInit()
        End If
      End Set
    End Property
    Protected Sub fvInit()
      Try
        If HttpContext.Current.Session("PageNoProvider") = True Then
          _FormView1.PageIndex = SIS.SYS.Utilities.GlobalVariables.PageNo(FileName, HttpContext.Current.Session("LoginID"))
        Else
          _FormView1.PageIndex = HttpContext.Current.Session("PageNo_" & FileName)
        End If
      Catch ex As Exception
        _FormView1.PageIndex = 0
      End Try
    End Sub
    Private Sub ExceptionHandling(ByVal InnerException As String, ByVal Message As String)
      If Not InnerException Is Nothing Then
        HttpContext.Current.Session("myError") = InnerException.ToString & vbCrLf & Message
      Else
        HttpContext.Current.Session("myError") = Message
      End If
      HttpContext.Current.Response.Redirect("~/ErrorPage.aspx")
    End Sub
    Private Sub _ToolBar1_CancelClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles _ToolBar1.CancelClicked
      HttpContext.Current.Response.Redirect(SIS.SYS.Utilities.SessionManager.PopNavBar)
    End Sub
    Private Sub _ToolBar1_PageChanged(ByVal NewPageNo As Integer, ByVal PageSize As Integer) Handles _ToolBar1.PageChanged
      _FormView1.PageIndex = NewPageNo
      If HttpContext.Current.Session("PageNoProvider") = True Then
        SIS.SYS.Utilities.GlobalVariables.PageNo(FileName, HttpContext.Current.Session("LoginID"), NewPageNo)
      Else
        HttpContext.Current.Session("PageNo_" & FileName) = NewPageNo
      End If
    End Sub
    Private Sub _ToolBar1_SaveClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles _ToolBar1.SaveClicked
      _FormView1.InsertItem(True)
    End Sub
    Private Sub _ToolBar1_SearchClicked(ByVal SearchText As String, ByVal SearchState As Boolean) Handles _ToolBar1.SearchClicked
      _FormView1.PageIndex = 0
      CType(_FormView1.DataSourceObject, ObjectDataSource).SelectParameters("SearchState").DefaultValue = SearchState
      CType(_FormView1.DataSourceObject, ObjectDataSource).SelectParameters("SearchText").DefaultValue = SearchText
    End Sub
    Private Sub _FormView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles _FormView1.DataBound
      With _ToolBar1
        .CurrentPage = _FormView1.PageIndex
        .TotalPages = _FormView1.PageCount
        .RecordsPerPage = 1
      End With
    End Sub
    Private Sub _FormView1_ItemInserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewInsertedEventArgs) Handles _FormView1.ItemInserted
      If e.Exception Is Nothing Then
        'If Not _ToolBar1.InsertAndStay Then
        '  If _ToolBar1.AfterInsertURL = String.Empty Then
        '    HttpContext.Current.Response.Redirect(SIS.SYS.Utilities.SessionManager.PopNavBar())
        '  Else
        '    HttpContext.Current.Response.Redirect(_ToolBar1.AfterInsertURL)
        '  End If
        'End If
        RaiseEvent DataInserted()
      Else
        Try
          e.ExceptionHandled = True
          Dim msg As String = IIf(e.Exception.InnerException IsNot Nothing, e.Exception.InnerException.ToString, e.Exception.Message)
          RaiseEvent InsertError(msg) 'e.Exception.Message)
          'ExceptionHandling(e.Exception.InnerException.ToString, e.Exception.Message)
        Catch ex As Exception
        End Try
      End If
    End Sub
    Private Sub _FormView1_PageIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _FormView1.PageIndexChanged
      If HttpContext.Current.Session("PageNoProvider") = True Then
        SIS.SYS.Utilities.GlobalVariables.PageNo(FileName, HttpContext.Current.Session("LoginID"), _FormView1.PageIndex)
      Else
        HttpContext.Current.Session("PageNo_" & FileName) = _FormView1.PageIndex
      End If
    End Sub
  End Class
End Namespace
