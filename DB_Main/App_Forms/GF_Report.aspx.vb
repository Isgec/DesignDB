Partial Class GF_Report
  Inherits System.Web.UI.Page


  'Public Property DocumentID As String
  '  Get
  '    If ViewState("DocumentID") IsNot Nothing Then
  '      Return ViewState("DocumentID")
  '    End If
  '    Return ""
  '  End Get
  '  Set(value As String)

  '    ViewState.Add("DocumentID", value)
  '  End Set
  'End Property

  'Private Sub cmdSubmit_Click(sender As Object, e As EventArgs) Handles cmdSubmit.Click
  '  Dim Textbx_Division As String = ""
  '  Dim Department As String = ""
  '  Dim SubGroups As String = ""
  '  Dim Report As String = ""

  '  DocumentID = F_t_docn.Text.ToUpper()
  '  F_t_docn.Text = DocumentID

  '  If DocumentID = "" Then Exit Sub




  '  Dim x As SIS.DB.dbDocumentDB = SIS.DB.dbDocumentDB.GetDocumentDB(DocumentID)







  'End Sub



  Private Sub GF_DocumentDB_Load(sender As Object, e As EventArgs) Handles Me.Load

    'Dim x As SIS.DB.dbDocumentDB = SIS.DB.dbDocumentDB.GetDocumentDB(DocumentID)


    'btn_documentname.Text = x.Tittle

    'If DocumentID = "" Then Exit Sub

    Dim lmonth As Integer = Now.Month()

    Dim lyear As Integer = Now.Year()


    'If lmonth = "12" Then lyear = lyear + 1 And lmonth = 1 Else lmonth = lmonth
    'label101.Text = lmonth & "-" & lyear

    'If lmonth = "12" Then lyear = lyear + 1 And lmonth = 1 Else lmonth = lmonth + 1
    'label102.Text = lmonth & "-" & lyear

    'If lmonth = "12" Then lyear = lyear + 1 And lmonth = 1 Else lmonth = lmonth + 1
    'label103.Text = lmonth & "-" & lyear

    'If lmonth = "12" Then lyear = lyear + 1 And lmonth = 1 Else lmonth = lmonth + 1
    'label104.Text = lmonth & "-" & lyear

    'If lmonth = "12" Then lyear = lyear + 1 And lmonth = 1 Else lmonth = lmonth + 1
    'label105.Text = lmonth & "-" & lyear

    'If lmonth = "12" Then lyear = lyear + 1 And lmonth = 1 Else lmonth = lmonth + 1
    'label106.Text = lmonth & "-" & lyear

    'If lmonth = "12" Then lyear = lyear + 1 And lmonth = 1 Else lmonth = lmonth + 1
    'label107.Text = lmonth & "-" & lyear

    'If lmonth = "12" Then lyear = lyear + 1 And lmonth = 1 Else lmonth = lmonth + 1
    'label108.Text = lmonth & "-" & lyear

    'If lmonth = "12" Then lyear = lyear + 1 And lmonth = 1 Else lmonth = lmonth + 1
    'label109.Text = lmonth & "-" & lyear

    'If lmonth = "12" Then lyear = lyear + 1 And lmonth = 1 Else lmonth = lmonth + 1
    'label110.Text = lmonth & "-" & lyear

    'If lmonth = "12" Then lyear = lyear + 1 And lmonth = 1 Else lmonth = lmonth + 1
    'label111.Text = lmonth & "-" & lyear









  End Sub



End Class