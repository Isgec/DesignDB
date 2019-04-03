Imports System.Web.Script.Serialization
Partial Class lgToolBar
  Inherits ToolBar0
  Public Enum ToolTypes
    lgNMGrid = 1
    lgNMAdd = 2
    lgNMEdit = 3
    lgSMGrid = 11
    lgSDGrid = 12
    lgNDGrid = 4
    lgNDEdit = 5
    lgWMSGrid = 6
    lgWMSAdd = 7
    lgWMPGrid = 8
    lgWMPEdit = 9
    lgNReport = 10
  End Enum
  Private _ToolType As ToolTypes
  Private _AddUrl As String = ""
  Private _EditUrl As String = ""
  Private _PrintUrl As String = ""
  Private _CancelUrl As String = ""
  Private _SearchUrl As String = ""
  Private _ValidationGroup As String = ""
  Private _SearchContext As String = ""
  Private _AfterInsertURL As String = ""
  Private _AfterUpdateURL As String = ""
  Private _InsertAndStay As Boolean = True
  Private _UpdateAndStay As Boolean = False
  Private _AddPostBack As Boolean = False
  Private _PrintKey As String = ""
  Public Event SaveAddClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
  Public Event UpdateClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
  Public Event ReturnClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
  Public Sub SetUniqueID(ByVal prefix As String)
    MaskedEditExtenderPageSize.ID = prefix & MaskedEditExtenderPageSize.ID
    MaskedEditValidatorPageSize.ID = prefix & MaskedEditValidatorPageSize.ID
    MaskedEditValidatorPageSize.ControlExtender = MaskedEditExtenderPageSize.ID
    MaskedEditExtenderCurrentPage.ID = prefix & MaskedEditExtenderCurrentPage.ID
  End Sub
  Public Property HideSearch As Boolean
    Get
      Return tdSearch.Visible
    End Get
    Set(value As Boolean)
      tdSearch.Visible = value
    End Set
  End Property
  Public Property HidePaging As Boolean
    Get
      Return tdPage.Visible
    End Get
    Set(value As Boolean)
      tdPage.Visible = value
    End Set
  End Property
  Public Property AddPostBack() As Boolean
    Get
      Return _AddPostBack
    End Get
    Set(ByVal value As Boolean)
      _AddPostBack = value
      If value Then
        CmdExit.Enabled = False
        SetImage()
      End If
    End Set
  End Property
  Public Property Skin() As String
    Get
      Return tbldiv.Attributes("class")
    End Get
    Set(ByVal value As String)
      tbldiv.Attributes("class") = value
    End Set
  End Property
  Public Overrides Property UpdateAndStay() As Boolean
    Get
      Return _UpdateAndStay
    End Get
    Set(ByVal value As Boolean)
      _UpdateAndStay = value
    End Set
  End Property
  Public Overrides Property InsertAndStay() As Boolean
    Get
      Return _InsertAndStay
    End Get
    Set(ByVal value As Boolean)
      _InsertAndStay = value
    End Set
  End Property
  Public Overrides Property AfterUpdateURL() As String
    Get
      Return _AfterUpdateURL
    End Get
    Set(ByVal value As String)
      _AfterUpdateURL = value
    End Set
  End Property
  Public Overrides Property AfterInsertURL() As String
    Get
      Return _AfterInsertURL
    End Get
    Set(ByVal value As String)
      _AfterInsertURL = value
    End Set
  End Property
  Public Property SearchState() As Boolean
    Get
      Return DisableSearch.Checked
    End Get
    Set(ByVal value As Boolean)
      DisableSearch.Checked = value
    End Set
  End Property
  Public Property ToolType() As ToolTypes
    Get
      Return _ToolType
    End Get
    Set(ByVal value As ToolTypes)
      _ToolType = value
      SetToolType(value)
    End Set
  End Property
  Private Sub SetToolType(ByVal Type As ToolTypes)
    Select Case Type
      Case ToolTypes.lgNMGrid
        SetNMGrid()
      Case ToolTypes.lgNMAdd
        SetNMAdd()
      Case ToolTypes.lgNMEdit
        SetNMEdit()
      Case ToolTypes.lgSMGrid
        SetSMGrid()
      Case ToolTypes.lgSDGrid
        SetSDGrid()
      Case ToolTypes.lgNDGrid
        SetNDGrid()
      Case ToolTypes.lgNDEdit
        SetNDEdit()
      Case ToolTypes.lgWMSGrid
        SetWMSGrid()
      Case ToolTypes.lgWMSAdd
        SetWMSAdd()
      Case ToolTypes.lgWMPGrid
        SetWMPGrid()
      Case ToolTypes.lgWMPEdit
        SetWMPEdit()
      Case ToolTypes.lgNReport
        SetNDEdit()
        tdPage.Visible = False
        tdSearch.Visible = False
    End Select
    SetImage()
  End Sub
  Private Sub SetWMPEdit()
    tdDefault.Visible = True
    tdPage.Visible = False
    tdSearch.Visible = True

    'CmdExit.Enabled = True
    CmdSave.Enabled = False
    CmdAdd.Enabled = False
    CmdDelete.Enabled = False
    CmdForward.Enabled = True
    CmdReturn.Enabled = True
  End Sub
  Private Sub SetWMPGrid()
    tdDefault.Visible = True
    tdPage.Visible = True
    tdSearch.Visible = True

    'CmdExit.Enabled = False
    CmdSave.Enabled = False
    CmdAdd.Enabled = False
    CmdDelete.Enabled = False
    CmdForward.Enabled = False
    CmdReturn.Enabled = False
  End Sub
  Private Sub SetWMSAdd()
    tdDefault.Visible = True
    tdPage.Visible = False
    tdSearch.Visible = True

    'CmdExit.Enabled = True
    CmdSave.Enabled = False
    CmdAdd.Enabled = False
    CmdDelete.Enabled = False
    CmdForward.Enabled = True
    CmdReturn.Enabled = False
  End Sub
  Private Sub SetWMSGrid()
    tdDefault.Visible = True
    tdPage.Visible = True
    tdSearch.Visible = True

    'CmdExit.Enabled = False
    CmdSave.Enabled = False
    CmdAdd.Enabled = True
    CmdDelete.Enabled = False
    CmdForward.Enabled = False
    CmdReturn.Enabled = False
  End Sub
  Private Sub SetNDEdit()
    tdDefault.Visible = True
    tdPage.Visible = False
    tdSearch.Visible = True

    'CmdExit.Enabled = True
    CmdSave.Enabled = False
    CmdAdd.Enabled = False
    CmdDelete.Enabled = False
    CmdForward.Enabled = False
    CmdReturn.Enabled = False
  End Sub
  Private Sub SetNDGrid()
    tdDefault.Visible = True
    tdPage.Visible = True
    tdSearch.Visible = True

    'CmdExit.Enabled = False
    CmdSave.Enabled = False
    CmdAdd.Enabled = False
    CmdDelete.Enabled = False
    CmdForward.Enabled = False
    CmdReturn.Enabled = False
  End Sub
  Private Sub SetNMEdit()
    tdDefault.Visible = True
    tdPage.Visible = False
    tdSearch.Visible = False

    'CmdExit.Enabled = True
    CmdSave.Enabled = True
    CmdAdd.Enabled = False
    CmdDelete.Enabled = True
    CmdForward.Enabled = False
    CmdReturn.Enabled = False
  End Sub
  Private Sub SetNMAdd()
    tdDefault.Visible = True
    tdPage.Visible = False
    tdSearch.Visible = False

    'CmdExit.Enabled = True
    CmdSave.Enabled = True
    CmdAdd.Enabled = False
    CmdDelete.Enabled = False
    CmdForward.Enabled = False
    CmdReturn.Enabled = False
  End Sub
  Private Sub SetSDGrid()
    tdDefault.Visible = True
    tdPage.Visible = True
    tdSearch.Visible = True

    'CmdExit.Enabled = False
    CmdSave.Enabled = False
    CmdAdd.Enabled = False
    CmdDelete.Enabled = False
    CmdForward.Enabled = False
    CmdReturn.Enabled = False
  End Sub
  Private Sub SetSMGrid()
    tdDefault.Visible = True
    tdPage.Visible = True
    tdSearch.Visible = True

    'CmdExit.Enabled = False
    CmdSave.Enabled = False
    CmdAdd.Enabled = True
    CmdDelete.Enabled = False
    CmdForward.Enabled = False
    CmdReturn.Enabled = False
  End Sub
  Private Sub SetNMGrid()
    tdDefault.Visible = True
    tdPage.Visible = True
    tdSearch.Visible = True

    'CmdExit.Enabled = True
    CmdSave.Enabled = False
    CmdAdd.Enabled = True
    CmdDelete.Enabled = False
    CmdForward.Enabled = False
    CmdReturn.Enabled = False
  End Sub
  Public Property EnableExit() As Boolean
    Get
      Return CmdExit.Enabled
    End Get
    Set(ByVal value As Boolean)
      CmdExit.Enabled = value
      SetImage()
    End Set
  End Property
  Public Property EnablePrint() As Boolean
    Get
      Return CmdPrint.Enabled
    End Get
    Set(ByVal value As Boolean)
      CmdPrint.Enabled = value
      SetImage()
    End Set
  End Property
  Public Property EnableSave() As Boolean
    Get
      Return CmdSave.Enabled
    End Get
    Set(ByVal value As Boolean)
      CmdSave.Enabled = value
      SetImage()
    End Set
  End Property
  Private Sub SetImage()
    If tdDefault.Visible Then
      With CmdPrint
        If .Enabled Then
          .ImageUrl = .ImageUrl.Replace("1", "0")
          .Attributes.Add("onmouseover", "this.src='../../TblImages/prt2.png';")
          .Attributes.Add("onmouseout", "this.src='../../TblImages/prt0.png';")
        Else
          .ImageUrl = .ImageUrl.Replace("0", "1")
        End If

      End With
      With CmdExit
        If .Enabled Then
          .ImageUrl = .ImageUrl.Replace("1", "0")
          .Attributes.Add("onmouseover", "this.src='../../TblImages/can2.png';")
          .Attributes.Add("onmouseout", "this.src='../../TblImages/can0.png';")
        Else
          .ImageUrl = .ImageUrl.Replace("0", "1")
        End If

      End With
      With CmdSave
        If .Enabled Then
          .ImageUrl = .ImageUrl.Replace("1", "0")
          .Attributes.Add("onmouseover", "this.src='../../TblImages/sav2.png';")
          .Attributes.Add("onmouseout", "this.src='../../TblImages/sav0.png';")
        Else
          .ImageUrl = .ImageUrl.Replace("0", "1")
        End If
      End With
      With CmdAdd
        If .Enabled Then
          .ImageUrl = .ImageUrl.Replace("1", "0")
          .Attributes.Add("onmouseover", "this.src='../../TblImages/add2.png';")
          .Attributes.Add("onmouseout", "this.src='../../TblImages/add0.png';")
        Else
          .ImageUrl = .ImageUrl.Replace("0", "1")
        End If
      End With
      With CmdDelete
        If .Enabled Then
          .ImageUrl = .ImageUrl.Replace("1", "0")
          .Attributes.Add("onmouseover", "this.src='../../TblImages/del2.png';")
          .Attributes.Add("onmouseout", "this.src='../../TblImages/del0.png';")
        Else
          .ImageUrl = .ImageUrl.Replace("0", "1")
        End If
      End With
      With CmdForward
        If .Enabled Then
          .ImageUrl = .ImageUrl.Replace("1", "0")
          .Attributes.Add("onmouseover", "this.src='../../TblImages/fwd2.png';")
          .Attributes.Add("onmouseout", "this.src='../../TblImages/fwd0.png';")
        Else
          .ImageUrl = .ImageUrl.Replace("0", "1")
        End If
      End With
      With CmdReturn
        If .Enabled Then
          .ImageUrl = .ImageUrl.Replace("1", "0")
          .Attributes.Add("onmouseover", "this.src='../../TblImages/ret2.png';")
          .Attributes.Add("onmouseout", "this.src='../../TblImages/ret0.png';")
        Else
          .ImageUrl = .ImageUrl.Replace("0", "1")
        End If
      End With
    End If
    If tdPage.Visible Then

    End If
    If tdSearch.Visible Then

    End If
  End Sub
  Public Property CancelClientScript() As String
    Get
      Return CmdExit.OnClientClick
    End Get
    Set(ByVal value As String)
      CmdExit.OnClientClick = value
    End Set
  End Property
  Public Property EnableReturn() As Boolean
    Get
      Return CmdReturn.Enabled
    End Get
    Set(ByVal value As Boolean)
      CmdReturn.Enabled = value
      With CmdReturn
        If .Enabled Then
          .ImageUrl = .ImageUrl.Replace("1", "0")
          .Attributes.Add("onmouseover", "this.src='../../TblImages/ret2.png';")
          .Attributes.Add("onmouseout", "this.src='../../TblImages/ret0.png';")
        Else
          .ImageUrl = .ImageUrl.Replace("0", "1")
        End If
      End With
    End Set
  End Property
  Public Property EnableForward() As Boolean
    Get
      Return CmdForward.Enabled
    End Get
    Set(ByVal value As Boolean)
      CmdForward.Enabled = value
      With CmdForward
        If .Enabled Then
          .ImageUrl = .ImageUrl.Replace("1", "0")
          .Attributes.Add("onmouseover", "this.src='../../TblImages/fwd2.png';")
          .Attributes.Add("onmouseout", "this.src='../../TblImages/fwd0.png';")
        Else
          .ImageUrl = .ImageUrl.Replace("0", "1")
        End If
      End With
    End Set
  End Property
  Public Property EnableSearch() As Boolean
    Get
      Return CmdSearch.Enabled
    End Get
    Set(ByVal value As Boolean)
      CmdSearch.Enabled = value
      With CmdSearch
        If .Enabled Then .ImageUrl = .ImageUrl.Replace("1", "0") Else .ImageUrl = .ImageUrl.Replace("0", "1")
      End With
    End Set
  End Property
  Public Property EnableAdd() As Boolean
    Get
      Return CmdAdd.Enabled
    End Get
    Set(ByVal value As Boolean)
      CmdAdd.Enabled = value
      With CmdAdd
        If .Enabled Then
          .ImageUrl = .ImageUrl.Replace("1", "0")
          .Attributes.Add("onmouseover", "this.src='../../TblImages/add2.png';")
          .Attributes.Add("onmouseout", "this.src='../../TblImages/add0.png';")
        Else
          .ImageUrl = .ImageUrl.Replace("0", "1")
        End If
      End With
    End Set
  End Property
  Public Property EnableDelete() As Boolean
    Get
      Return CmdDelete.Enabled
    End Get
    Set(ByVal value As Boolean)
      CmdDelete.Enabled = value
      With CmdDelete
        If .Enabled Then
          .ImageUrl = .ImageUrl.Replace("1", "0")
          .Attributes.Add("onmouseover", "this.src='../../TblImages/del2.png';")
          .Attributes.Add("onmouseout", "this.src='../../TblImages/del0.png';")
        Else
          .ImageUrl = .ImageUrl.Replace("0", "1")
        End If
      End With
    End Set
  End Property
  Public Property TotalRecords() As Integer
    Get
      Return _PageSizeButton.Text
    End Get
    Set(ByVal value As Integer)
      _PageSizeButton.Text = value
    End Set
  End Property
  Public Overrides Property RecordsPerPage() As Integer
    Get
      Return _PageSize.Text
    End Get
    Set(ByVal value As Integer)
      _PageSize.Text = value
    End Set
  End Property
  Public Overrides Property TotalPages() As Integer
    Get
      Return _TotalPages.Text
    End Get
    Set(ByVal value As Integer)
      _TotalPages.Text = value
      'Dim oMEV As New AjaxControlToolkit.MaskedEditValidator
      'With (oMEV)
      '	.ID = prefix & "MaskedEditValidatorCurrentPage"
      '	.ControlToValidate = "_CurrentPage"
      '	.ControlExtender = MaskedEditExtenderCurrentPage.ID
      '	' "MaskedEditExtenderCurrentPage"
      '	.InvalidValueMessage = ""
      '	.EmptyValueMessage = ""
      '	.EmptyValueBlurredText = ""
      '	.Display = ValidatorDisplay.Dynamic
      '	.EnableClientScript = True
      '	.ValidationGroup = "currentpage"
      '	.IsValidEmpty = False
      '	.MaximumValue = value
      '	.MinimumValue = 1
      '	.SetFocusOnError = True
      'End With
      'Me.Controls.Add(oMEV)
    End Set
  End Property
  Public Overrides Property CurrentPage() As Integer
    Get
      Return _CurrentPage.Text
    End Get
    Set(ByVal value As Integer)
      _CurrentPage.Text = value + 1
    End Set
  End Property
  Public Property SearchContext() As String
    Get
      Return _SearchContext
    End Get
    Set(ByVal value As String)
      _SearchContext = value
    End Set
  End Property
  Private _SearchValidationGroup As String = ""
  Public Overrides Property SearchValidationGroup() As String
    Get
      Return _SearchValidationGroup
    End Get
    Set(ByVal value As String)
      _SearchValidationGroup = value
      CmdSearch.ValidationGroup = value
      rfvst.ValidationGroup = value
      SearchTextBox.ValidationGroup = value
    End Set
  End Property
  Public Property ValidationGroup() As String
    Get
      Return _ValidationGroup
    End Get
    Set(ByVal value As String)
      _ValidationGroup = value
      CmdSave.ValidationGroup = value
      CmdForward.ValidationGroup = value
    End Set
  End Property
  Public Property AddUrl() As String
    Get
      Return _AddUrl
    End Get
    Set(ByVal value As String)
      _AddUrl = value
    End Set
  End Property
  Public Property EditUrl() As String
    Get
      Return _EditUrl
    End Get
    Set(ByVal value As String)
      _EditUrl = value
    End Set
  End Property
  Public Property PrintUrl() As String
    Get
      Return _PrintUrl
    End Get
    Set(ByVal value As String)
      _PrintUrl = value
      CmdPrint.AlternateText = _PrintUrl
    End Set
  End Property
  Public Property CancelUrl() As String
    Get
      Return _CancelUrl
    End Get
    Set(ByVal value As String)
      _CancelUrl = value
      Me.CmdExit.PostBackUrl = value
    End Set
  End Property
  Protected Sub CmdCancel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles CmdExit.Click
    RaiseCancelClicked(sender, e)
  End Sub
  Protected Sub CmdAdd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles CmdAdd.Click
    RaiseAddClicked(sender, e)
    If _AddPostBack Then
      If _AddUrl <> String.Empty Then
        Response.Redirect(_AddUrl)
      End If
    End If
  End Sub
  Protected Sub CmdSave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles CmdSave.Click
    Try
      RaiseSaveClicked(sender, e)
    Catch ex As Exception
      Dim str As String = New JavaScriptSerializer().Serialize(ex.Message)
      Dim script As String = String.Format("alert({0});", str)
      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
    End Try
  End Sub
  Protected Sub CmdForward_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles CmdForward.Click
    RaiseEvent UpdateClicked(sender, e)
  End Sub
  Protected Sub CmdReturn_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles CmdReturn.Click
    RaiseEvent ReturnClicked(sender, e)
  End Sub
  Protected Sub SearchButton_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles CmdSearch.Click
    If Not SearchTextBox.Text = String.Empty Then
      DisableSearch.Enabled = True
      DisableSearch.Checked = True
      RaiseSearchClicked(SearchTextBox.Text, True)
    End If
  End Sub
  Protected Sub DisableSearch_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DisableSearch.CheckedChanged
    DisableSearch.Enabled = False
    DisableSearch.Checked = False
    RaiseSearchClicked(SearchTextBox.Text, False)
  End Sub
  Protected Sub _CurrentPage_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _CurrentPage.TextChanged
    RaisePageChanged(Convert.ToInt32(_CurrentPage.Text) - 1, Convert.ToInt32(_PageSize.Text))
  End Sub
  Protected Sub navFirst_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles navFirst.Click
    RaisePageChanged(0, Convert.ToInt32(_PageSize.Text))
  End Sub
  Protected Sub navPrev_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles navPrev.Click
    Dim cp As Integer = Convert.ToInt32(_CurrentPage.Text)
    If cp - 1 >= 1 Then
      RaisePageChanged(cp - 2, Convert.ToInt32(_PageSize.Text))
    End If
  End Sub
  Protected Sub navNext_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles navNext.Click
    Dim cp As Integer = Convert.ToInt32(_CurrentPage.Text)
    Dim lp As Integer = Convert.ToInt32(_TotalPages.Text)
    If cp + 1 <= lp Then
      RaisePageChanged(cp, Convert.ToInt32(_PageSize.Text))
    End If
  End Sub
  Protected Sub navLast_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles navLast.Click
    Dim lp As Integer = Convert.ToInt32(_TotalPages.Text)
    RaisePageChanged(lp - 1, Convert.ToInt32(_PageSize.Text))
  End Sub
  Protected Sub _PageSizeButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _PageSizeButton.Click
    RaisePageChanged(Convert.ToInt32(_CurrentPage.Text) - 1, Convert.ToInt32(_PageSize.Text))
  End Sub
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    If Not Page.IsPostBack And Not Page.IsCallback Then
      Try
        SIS.SYS.Utilities.SessionManager.PushNavBar(System.IO.Path.GetFileName(System.Web.HttpContext.Current.Request.Url.AbsolutePath), Request.UrlReferrer.AbsoluteUri)
      Catch ex As Exception
        SIS.SYS.Utilities.SessionManager.DestroySessionEnvironement()
        Response.Redirect("~/SISError.aspx")
      End Try
    End If
  End Sub
  Protected Sub CmdDelete_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles CmdDelete.Click
    RaiseDeleteClicked(sender, e)
  End Sub
  Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
    If Not _AddPostBack Then
      If _AddUrl <> String.Empty Then
        CmdAdd.CommandArgument = _AddUrl
        CmdAdd.PostBackUrl = _AddUrl
      End If
    End If
  End Sub
End Class
