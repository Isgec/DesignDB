Namespace SIS.SYS
  Public MustInherit Class GridBase
    Inherits System.Web.UI.Page
    Protected WithEvents _GridView1 As GridView
    Protected WithEvents _ToolBar1 As ToolBar0
    Private _dataClassName As String = ""
    Private _gvOK As Boolean = False
    Private _dcOK As Boolean = False
    Public Sub InitGridPage()
      If Session("PageNoProvider") = True Then
        SIS.SYS.Utilities.GlobalVariables.PageNo(FileName, HttpContext.Current.Session("LoginID"), 0)
      Else
        Session("PageNo_" & FileName) = 0
      End If
    End Sub
    Public ReadOnly Property FileName() As String
      Get
        Return _dataClassName & "." & _GridView1.ID
      End Get
    End Property
    Public Property DataClassName() As String
      Get
        Return _dataClassName
      End Get
      Set(ByVal value As String)
        _dataClassName = value
        _dcOK = True
        If _gvOK Then
          gvInit()
        End If
      End Set
    End Property

    Public Property SetGridView() As GridView
      Get
        Return _GridView1
      End Get
      Set(ByVal value As GridView)
        _GridView1 = value
        _gvOK = True
        If _dcOK Then
          gvInit()
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
    Private Sub _GridView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles _GridView1.DataBound
      With _ToolBar1
        .CurrentPage = _GridView1.PageIndex
        .TotalPages = _GridView1.PageCount
        .RecordsPerPage = _GridView1.PageSize
      End With
    End Sub
    Private Sub _GridView1_PageIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _GridView1.PageIndexChanged
      If Session("PageNoProvider") = True Then
        SIS.SYS.Utilities.GlobalVariables.PageNo(FileName, HttpContext.Current.Session("LoginID"), _GridView1.PageIndex)
      Else
        Session("PageNo_" & FileName) = _GridView1.PageIndex
      End If
    End Sub
    Private Sub gvInit()
      Try
        If Session("PageNoProvider") = True Then
          _GridView1.PageIndex = SIS.SYS.Utilities.GlobalVariables.PageNo(FileName, HttpContext.Current.Session("LoginID"))
        Else
          _GridView1.PageIndex = Session("PageNo_" & FileName)
        End If
        If Session("PageSizeProvider") = True Then
          _GridView1.PageSize = SIS.SYS.Utilities.GlobalVariables.PageSize(FileName, HttpContext.Current.Session("LoginID"))
        Else
          _GridView1.PageSize = Session("PageSize_" & FileName)
        End If
      Catch ex As Exception
        _GridView1.PageIndex = 0
        _GridView1.PageSize = 25
      End Try
    End Sub
    Private Sub _ToolBar1_CancelClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles _ToolBar1.CancelClicked
      Response.Redirect(SIS.SYS.Utilities.SessionManager.PopNavBar)
    End Sub
    Private Sub _ToolBar1_PageChanged(ByVal NewPageNo As Integer, ByVal PageSize As Integer) Handles _ToolBar1.PageChanged
      If NewPageNo < 0 Then NewPageNo = 0
      _GridView1.PageIndex = NewPageNo
      _GridView1.PageSize = PageSize
      If Session("PageNoProvider") = True Then
        SIS.SYS.Utilities.GlobalVariables.PageNo(FileName, HttpContext.Current.Session("LoginID"), NewPageNo)
      Else
        Session("PageNo_" & FileName) = NewPageNo
      End If
      If Session("PageSizeProvider") = True Then
        SIS.SYS.Utilities.GlobalVariables.PageSize(FileName, HttpContext.Current.Session("LoginID"), PageSize)
      Else
        Session("PageSize_" & FileName) = PageSize
      End If
    End Sub
    Private Sub _ToolBar1_SearchClicked(ByVal SearchText As String, ByVal SearchState As Boolean) Handles _ToolBar1.SearchClicked
      _GridView1.PageIndex = 0
      CType(_GridView1.DataSourceObject, ObjectDataSource).SelectParameters("SearchState").DefaultValue = SearchState
      CType(_GridView1.DataSourceObject, ObjectDataSource).SelectParameters("SearchText").DefaultValue = SearchText
    End Sub
    Public Sub Saved()
      If Not _ToolBar1.InsertAndStay Then
        If _ToolBar1.AfterInsertURL = String.Empty Then
          Response.Redirect(SIS.SYS.Utilities.SessionManager.PopNavBar())
        Else
          Response.Redirect(_ToolBar1.AfterInsertURL)
        End If
      End If
    End Sub
  End Class
  Public MustInherit Class psGridBase
    Inherits System.Web.UI.Page
    Protected WithEvents _GridView1 As GridView
    Protected WithEvents _ToolBar1 As IpsBar
    Private _dataClassName As String = ""
    Private _gvOK As Boolean = False
    Private _dcOK As Boolean = False
    Public Sub InitGridPage()
      If Session("PageNoProvider") = True Then
        SIS.SYS.Utilities.GlobalVariables.PageNo(FileName, HttpContext.Current.Session("LoginID"), 0)
      Else
        Session("PageNo_" & FileName) = 0
      End If
    End Sub
    Public ReadOnly Property FileName() As String
      Get
        Return _dataClassName & "." & _GridView1.ID
      End Get
    End Property
    Public Property DataClassName() As String
      Get
        Return _dataClassName
      End Get
      Set(ByVal value As String)
        _dataClassName = value
        _dcOK = True
        If _gvOK Then
          gvInit()
        End If
      End Set
    End Property

    Public Property SetGridView() As GridView
      Get
        Return _GridView1
      End Get
      Set(ByVal value As GridView)
        _GridView1 = value
        _gvOK = True
        If _dcOK Then
          gvInit()
        End If
      End Set
    End Property
    Public Property SetToolBar() As IpsBar
      Get
        Return _ToolBar1
      End Get
      Set(ByVal value As IpsBar)
        _ToolBar1 = value
      End Set
    End Property
    Private Sub _GridView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles _GridView1.DataBound
      With _ToolBar1
        .CurrentPage = _GridView1.PageIndex
        .TotalPages = _GridView1.PageCount
        .RecordsPerPage = _GridView1.PageSize
      End With
    End Sub
    Private Sub _GridView1_PageIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _GridView1.PageIndexChanged
      If Session("PageNoProvider") = True Then
        SIS.SYS.Utilities.GlobalVariables.PageNo(FileName, HttpContext.Current.Session("LoginID"), _GridView1.PageIndex)
      Else
        Session("PageNo_" & FileName) = _GridView1.PageIndex
      End If
    End Sub
    Private Sub gvInit()
      Try
        If Session("PageNoProvider") = True Then
          _GridView1.PageIndex = SIS.SYS.Utilities.GlobalVariables.PageNo(FileName, HttpContext.Current.Session("LoginID"))
        Else
          _GridView1.PageIndex = Session("PageNo_" & FileName)
        End If
        If Session("PageSizeProvider") = True Then
          _GridView1.PageSize = SIS.SYS.Utilities.GlobalVariables.PageSize(FileName, HttpContext.Current.Session("LoginID"))
        Else
          _GridView1.PageSize = Session("PageSize_" & FileName)
        End If
      Catch ex As Exception
        _GridView1.PageIndex = 0
        _GridView1.PageSize = 10
      End Try
    End Sub
    Private Sub _ToolBar1_PageChanged(ByVal NewPageNo As Integer, ByVal PageSize As Integer) Handles _ToolBar1.PageChanged
      If NewPageNo < 0 Then NewPageNo = 0
      _GridView1.PageIndex = NewPageNo
      _GridView1.PageSize = PageSize
      If Session("PageNoProvider") = True Then
        SIS.SYS.Utilities.GlobalVariables.PageNo(FileName, HttpContext.Current.Session("LoginID"), NewPageNo)
      Else
        Session("PageNo_" & FileName) = NewPageNo
      End If
      If Session("PageSizeProvider") = True Then
        SIS.SYS.Utilities.GlobalVariables.PageSize(FileName, HttpContext.Current.Session("LoginID"), PageSize)
      Else
        Session("PageSize_" & FileName) = PageSize
      End If
    End Sub
    Private Sub _ToolBar1_SearchClicked(ByVal SearchText As String, ByVal SearchState As Boolean) Handles _ToolBar1.SearchClicked
      _GridView1.PageIndex = 0
      CType(_GridView1.DataSourceObject, ObjectDataSource).SelectParameters("SearchState").DefaultValue = SearchState
      CType(_GridView1.DataSourceObject, ObjectDataSource).SelectParameters("SearchText").DefaultValue = SearchText
    End Sub
  End Class
	Public MustInherit Class attachGridBase
		Inherits System.Web.UI.Page
		Protected WithEvents _GridView1 As GridView
		Protected WithEvents _ToolBar1 As IattachBar
		Private _dataClassName As String = ""
		Private _gvOK As Boolean = False
		Private _dcOK As Boolean = False
		Public Sub InitGridPage()
			If Session("PageNoProvider") = True Then
				SIS.SYS.Utilities.GlobalVariables.PageNo(FileName, HttpContext.Current.Session("LoginID"), 0)
			Else
				Session("PageNo_" & FileName) = 0
			End If
		End Sub
		Public ReadOnly Property FileName() As String
			Get
				Return _dataClassName & "." & _GridView1.ID
			End Get
		End Property
		Public Property DataClassName() As String
			Get
				Return _dataClassName
			End Get
			Set(ByVal value As String)
				_dataClassName = value
				_dcOK = True
				If _gvOK Then
					gvInit()
				End If
			End Set
		End Property

		Public Property SetGridView() As GridView
			Get
				Return _GridView1
			End Get
			Set(ByVal value As GridView)
				_GridView1 = value
				_gvOK = True
				If _dcOK Then
					gvInit()
				End If
			End Set
		End Property
		Public Property SetToolBar() As IattachBar
			Get
				Return _ToolBar1
			End Get
			Set(ByVal value As IattachBar)
				_ToolBar1 = value
			End Set
		End Property
		Private Sub _GridView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles _GridView1.DataBound
			With _ToolBar1
				.CurrentPage = _GridView1.PageIndex
				.TotalPages = _GridView1.PageCount
				.RecordsPerPage = _GridView1.PageSize
			End With
		End Sub
		Private Sub _GridView1_PageIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _GridView1.PageIndexChanged
			If Session("PageNoProvider") = True Then
				SIS.SYS.Utilities.GlobalVariables.PageNo(FileName, HttpContext.Current.Session("LoginID"), _GridView1.PageIndex)
			Else
				Session("PageNo_" & FileName) = _GridView1.PageIndex
			End If
		End Sub
		Private Sub gvInit()
			Try
				If Session("PageNoProvider") = True Then
					_GridView1.PageIndex = SIS.SYS.Utilities.GlobalVariables.PageNo(FileName, HttpContext.Current.Session("LoginID"))
				Else
					_GridView1.PageIndex = Session("PageNo_" & FileName)
				End If
				If Session("PageSizeProvider") = True Then
					_GridView1.PageSize = SIS.SYS.Utilities.GlobalVariables.PageSize(FileName, HttpContext.Current.Session("LoginID"))
				Else
					_GridView1.PageSize = Session("PageSize_" & FileName)
				End If
			Catch ex As Exception
				_GridView1.PageIndex = 0
				_GridView1.PageSize = 10
			End Try
		End Sub
		Private Sub _ToolBar1_PageChanged(ByVal NewPageNo As Integer, ByVal PageSize As Integer) Handles _ToolBar1.PageChanged
			If NewPageNo < 0 Then NewPageNo = 0
			_GridView1.PageIndex = NewPageNo
			_GridView1.PageSize = PageSize
			If Session("PageNoProvider") = True Then
				SIS.SYS.Utilities.GlobalVariables.PageNo(FileName, HttpContext.Current.Session("LoginID"), NewPageNo)
			Else
				Session("PageNo_" & FileName) = NewPageNo
			End If
			If Session("PageSizeProvider") = True Then
				SIS.SYS.Utilities.GlobalVariables.PageSize(FileName, HttpContext.Current.Session("LoginID"), PageSize)
			Else
				Session("PageSize_" & FileName) = PageSize
			End If
		End Sub
		Private Sub _ToolBar1_SearchClicked(ByVal SearchText As String, ByVal SearchState As Boolean) Handles _ToolBar1.SearchClicked
			_GridView1.PageIndex = 0
			CType(_GridView1.DataSourceObject, ObjectDataSource).SelectParameters("SearchState").DefaultValue = SearchState
			CType(_GridView1.DataSourceObject, ObjectDataSource).SelectParameters("SearchText").DefaultValue = SearchText
		End Sub
	End Class
End Namespace
