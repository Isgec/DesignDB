Imports System.Web.Script.Serialization
Partial Class EF_dmisg140
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
  Protected Sub ODSdmisg140_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSdmisg140.Selected
    Dim tmp As SIS.DMISG.dmisg140 = CType(e.ReturnValue, SIS.DMISG.dmisg140)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVdmisg140_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVdmisg140.Init
    DataClassName = "Edmisg140"
    SetFormView = FVdmisg140
  End Sub
  Protected Sub TBLdmisg140_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLdmisg140.Init
    SetToolBar = TBLdmisg140
  End Sub
  Protected Sub FVdmisg140_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVdmisg140.PreRender
    TBLdmisg140.EnableSave = Editable
    TBLdmisg140.EnableDelete = Deleteable
    TBLdmisg140.PrintUrl &= Request.QueryString("t_cprj") & "|"
    TBLdmisg140.PrintUrl &= Request.QueryString("t_docn") & "|"
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/DMISG_Main/App_Edit") & "/EF_dmisg140.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptdmisg140") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptdmisg140", mStr)
    End If
  End Sub
  Partial Class gvBase
    Inherits SIS.SYS.GridBase
  End Class
  Private WithEvents gvdwgHoldListCC As New gvBase
  Protected Sub GVdwgHoldList_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVdwgHoldList.Init
    gvdwgHoldListCC.DataClassName = "GdwgHoldList"
    gvdwgHoldListCC.SetGridView = GVdwgHoldList
  End Sub
  Protected Sub TBLdwgHoldList_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLdwgHoldList.Init
    gvdwgHoldListCC.SetToolBar = TBLdwgHoldList
  End Sub
  Protected Sub GVdwgHoldList_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVdwgHoldList.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim ProjectID As String = GVdwgHoldList.DataKeys(e.CommandArgument).Values("ProjectID")  
        Dim DocumentID As String = GVdwgHoldList.DataKeys(e.CommandArgument).Values("DocumentID")  
        Dim SerialNo As Int32 = GVdwgHoldList.DataKeys(e.CommandArgument).Values("SerialNo")  
        Dim RedirectUrl As String = TBLdwgHoldList.EditUrl & "?ProjectID=" & ProjectID & "&DocumentID=" & DocumentID & "&SerialNo=" & SerialNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub

End Class
