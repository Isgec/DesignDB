Imports System.Web.Script.Serialization
Partial Class EF_dwgHoldList
  Inherits SIS.SYS.UpdateBase
  Public Property Editable() As Boolean
    Get
      If ViewState("Editable") IsNot Nothing Then
        Return CType(ViewState("Editable"), Boolean)
      End If
      Return True
    End Get
    Set(ByVal value As Boolean)
      ViewState.Add("Editable", value)
    End Set
  End Property
  Public Property Deleteable() As Boolean
    Get
      If ViewState("Deleteable") IsNot Nothing Then
        Return CType(ViewState("Deleteable"), Boolean)
      End If
      Return True
    End Get
    Set(ByVal value As Boolean)
      ViewState.Add("Deleteable", value)
    End Set
  End Property
  Public Property PrimaryKey() As String
    Get
      If ViewState("PrimaryKey") IsNot Nothing Then
        Return CType(ViewState("PrimaryKey"), String)
      End If
      Return True
    End Get
    Set(ByVal value As String)
      ViewState.Add("PrimaryKey", value)
    End Set
  End Property
  Public Property NewStatus() As Boolean
    Get
      If ViewState("NewStatus") IsNot Nothing Then
        Return CType(ViewState("NewStatus"), Boolean)
      End If
      Return True
    End Get
    Set(ByVal value As Boolean)
      ViewState.Add("NewStatus", value)
    End Set
  End Property
  Protected Sub ODSdwgHoldList_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSdwgHoldList.Selected
    Dim tmp As SIS.DMISG.dwgHoldList = CType(e.ReturnValue, SIS.DMISG.dwgHoldList)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVdwgHoldList_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVdwgHoldList.Init
    DataClassName = "EdwgHoldList"
    SetFormView = FVdwgHoldList
  End Sub
  Protected Sub TBLdwgHoldList_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLdwgHoldList.Init
    SetToolBar = TBLdwgHoldList
  End Sub
  Protected Sub FVdwgHoldList_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVdwgHoldList.PreRender
    TBLdwgHoldList.EnableSave = Editable
    TBLdwgHoldList.EnableDelete = Deleteable
    If Request.QueryString("SerialNo") = "1" Then
      CType(FVdwgHoldList.FindControl("F_HoldStatus"), DropDownList).SelectedValue = "True"
      NewStatus = True
      CType(FVdwgHoldList.FindControl("r_Part"), HtmlTableRow).Visible = True
      CType(FVdwgHoldList.FindControl("r_Reason"), HtmlTableRow).Visible = True
      CType(FVdwgHoldList.FindControl("r_Input"), HtmlTableRow).Visible = False
      CType(FVdwgHoldList.FindControl("r_Issue"), HtmlTableRow).Visible = False
    Else
      CType(FVdwgHoldList.FindControl("F_HoldStatus"), DropDownList).SelectedValue = "False"
      NewStatus = False
      CType(FVdwgHoldList.FindControl("r_Part"), HtmlTableRow).Visible = False
      CType(FVdwgHoldList.FindControl("r_Reason"), HtmlTableRow).Visible = False
      CType(FVdwgHoldList.FindControl("r_Input"), HtmlTableRow).Visible = True
      CType(FVdwgHoldList.FindControl("r_Issue"), HtmlTableRow).Visible = True
    End If
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/DMISG_Main/App_Edit") & "/EF_dwgHoldList.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptdwgHoldList") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptdwgHoldList", mStr)
    End If
  End Sub

End Class
