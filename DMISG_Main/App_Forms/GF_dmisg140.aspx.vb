Imports System.Web.Script.Serialization
Partial Class GF_dmisg140
  Inherits SIS.SYS.GridBase
  Protected Sub GVdmisg140_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVdmisg140.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim t_cprj As String = GVdmisg140.DataKeys(e.CommandArgument).Values("t_cprj")
        Dim t_docn As String = GVdmisg140.DataKeys(e.CommandArgument).Values("t_docn")
        Dim RedirectUrl As String = TBLdmisg140.EditUrl & "?t_cprj=" & t_cprj & "&t_docn=" & t_docn
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "approvewf".ToLower Then
      Try
        Dim t_cprj As String = GVdmisg140.DataKeys(e.CommandArgument).Values("t_cprj")
        Dim t_docn As String = GVdmisg140.DataKeys(e.CommandArgument).Values("t_docn")
        Dim RedirectUrl As String = TBLdmisg140.EditUrl & "?ProjectID=" & t_cprj & "&DocumentID=" & t_docn & "&SerialNo=1"
        Response.Redirect(RedirectUrl)
        'SIS.DMISG.dmisg140.ApproveWF(t_cprj, t_docn)
        'GVdmisg140.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "rejectwf".ToLower Then
      Try
        Dim t_cprj As String = GVdmisg140.DataKeys(e.CommandArgument).Values("t_cprj")
        Dim t_docn As String = GVdmisg140.DataKeys(e.CommandArgument).Values("t_docn")
        Dim RedirectUrl As String = TBLdmisg140.EditUrl & "?ProjectID=" & t_cprj & "&DocumentID=" & t_docn & "&SerialNo=0"
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVdmisg140_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVdmisg140.Init
    DataClassName = "Gdmisg140"
    SetGridView = GVdmisg140
  End Sub
  Protected Sub TBLdmisg140_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLdmisg140.Init
    SetToolBar = TBLdmisg140
  End Sub
  Protected Sub F_t_resp_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_t_resp.TextChanged
    Session("F_t_resp") = F_t_resp.Text
    InitGridPage()
  End Sub
  Protected Sub F_t_cprj_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_t_cprj.TextChanged
    Session("F_t_cprj") = F_t_cprj.Text
    InitGridPage()
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
